using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.IO;
using CSV2Core.Support;
using System.Data.Common;
using MySql.Data.MySqlClient;

//CSV2Core_MySQL.Dictionaries.MultiTable.SQL
namespace CSV2Core_MySQL.Dictionaries.MultiTable.Loader
{
    //CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader
    public class DictionaryLoader
    {
        protected static string InsertSQL = null;
        protected static string UpdateSQL = null;
        protected static string SelectSQL = null;
        protected List<Dict> dictionaries = new List<Dict>();

        protected MySqlConnection connection;
        protected MySqlTransaction transaction;

        #region Constructor
        //Initialize ito static variables to be reused instead of reloaded
        //Making the process a little bit faster
        public DictionaryLoader(DbConnection connection, DbTransaction transaction)
        {
            if (InsertSQL == null)
            {
                var stream =  Assembly.GetExecutingAssembly().GetManifestResourceStream("CSV2Core_MySQL.Dictionaries.MultiTable.SQL.Insert.sql");
                InsertSQL = new StreamReader(stream).ReadToEnd();
            }
            if (UpdateSQL == null)
            {
                var stream =  Assembly.GetExecutingAssembly().GetManifestResourceStream("CSV2Core_MySQL.Dictionaries.MultiTable.SQL.Update.sql");
                UpdateSQL = new StreamReader(stream).ReadToEnd();
            }
            if (SelectSQL == null)
            {
                var stream =  Assembly.GetExecutingAssembly().GetManifestResourceStream("CSV2Core_MySQL.Dictionaries.MultiTable.SQL.Select.sql");
                SelectSQL = new StreamReader(stream).ReadToEnd();
            }

            this.connection = (MySqlConnection)connection;
            this.transaction = (MySqlTransaction)transaction;
        }
        #endregion

        #region Query Creators
        /// <summary>
        /// Special select function for handling multiple dictionary entries
        /// to speed up the slection process when having multiple IDs
        /// </summary>
        /// <param name="tableName">Dictionary TableName</param>
        /// <param name="IDs">Guid identificators</param>
        /// <returns>Select Query</returns>
        protected string GetSelectQuery(string tableName, Guid[] IDs)
        {
            var query = SelectSQL.Replace("$$TABLE$$", tableName);
            //Now we need to inject the IDs into the table
            query = query.Replace("$$DICTID$$", SQLSupport.GenerateInStatement(IDs));

            return query;
        }

        protected string GetInsertQuery(string tableName)
        {
            return InsertSQL.Replace("$$TABLE$$", tableName);
        }

        protected string GetUpdateQuery(string tableName)
        {
            return UpdateSQL.Replace("$$TABLE$$", tableName);
        }
        #endregion
         
        public void Append(Dict dictionary,String sourceTable = null)
        {
            //Append
            if (sourceTable!=null) { 
                dictionary.SourceTable = sourceTable;
            }
            dictionaries.Add(dictionary);
        }

        public void Update()
        {
            //Do a group dictionary
            var group = dictionaries.GroupBy(x => x.SourceTable).ToDictionary(item => item.Key, item => item.ToList());
            foreach (string key in group.Keys)
            {
                this.Update(key, group[key]);
            }
        }

        /// <summary>
        /// Uptade
        /// </summary>
        /// <param name="table"></param>
        /// <param name="list"></param>
        protected void Update(string table, List<Dict> list)
        {
            List<DictEntry> entriesSnapshot = new List<DictEntry>();
            List<DictEntry> entriesCurrent  = new List<DictEntry>();

            //First we need to filter all the dictionaries that are not dirty
            List<Dict> filteredList = list.Where(x => x.IsDirty == true).ToList();
            List<Dict> databaseSnapshot = new List<Dict>();
            //Lame copying
            foreach (var dictionary in filteredList)
                databaseSnapshot.Add(new Dict(dictionary.SourceTable, dictionary.DictionaryID));

            this.Load(table, databaseSnapshot);

            foreach (var item in filteredList)
            {
                entriesCurrent.AddRange(item.Contents);
            }
            foreach (var item in databaseSnapshot)
            {
                entriesSnapshot.AddRange(item.Contents);
            }
            //We have all the required changes to make the updates
            //Set all entries that need to be deleted
            var toDelete = new List<DictEntry>();
            var toUpdate = new List<DictEntry>();
            var toCreate = new List<DictEntry>();
            //Select all the entries in the snapshot which are not in the current entries
            toDelete = entriesSnapshot.Where(
                snapshot =>
                    entriesCurrent.FirstOrDefault(
                        current =>
                            snapshot.DictID == current.DictID && 
                            snapshot.LanguageID == current.LanguageID) == null).ToList();
            //Select all the entries from the snapshot which have different content
            toUpdate = entriesCurrent.Where(
                current =>
                    entriesSnapshot.FirstOrDefault(
                        snapshot=>
                            snapshot.DictID == current.DictID && 
                                snapshot.LanguageID == current.LanguageID && 
                                snapshot.Content != current.Content) != null).ToList();
            //Select all the current entries that are not in the database snapshot
            toCreate = entriesCurrent.Where(
                current =>
                    entriesSnapshot.FirstOrDefault(
                        snapshot =>
                            snapshot.DictID == current.DictID && 
                                snapshot.LanguageID == current.LanguageID) == null).ToList();

            //If there is nothing to do, just return
            if (toDelete.Count == 0 && toUpdate.Count == 0 && toCreate.Count == 0)
            {
                return;
            }
            //Set all deleted items 
            foreach (var deleted in toDelete)
            {
                deleted.IsDeleted = true;
            }

            //To Update
            Dict updateWrapper = new Dict(table);
            updateWrapper.Contents.AddRange(toDelete);
            updateWrapper.Contents.AddRange(toUpdate);

            //To Create
            Dict saveWrapper = new Dict(table);
            saveWrapper.Contents.AddRange(toCreate);

            if (toDelete.Count + toUpdate.Count != 0)
            {
                this.Save(table, new Dict[] { updateWrapper }.ToList(), true);
            }
            if (toCreate.Count != 0)
            {
                this.Save(table, new Dict[] { saveWrapper }.ToList(), false);
            }
        }



        public void Save()
        {
            //Do a group dictionary
            var group = dictionaries.GroupBy(x => x.SourceTable).ToDictionary(item => item.Key, item => item.ToList());
            foreach (string key in group.Keys)
            {
                this.Save(key, group[key]);
            }
        }



        /// <summary>
        /// Saves perticular set for the given table
        /// </summary>
        /// <param name="table"></param>
        /// <param name="dicts"></param>
        protected void Save(string table, List<Dict> dicts, Boolean update=false)
        {
            if (!table.EndsWith("_DE"))
                table+="_DE";

            string query = "";
            if (update == false)
            {
                query = GetInsertQuery(table);
            }
            else
            {
                query = GetUpdateQuery(table);
            }


            MySqlCommand command = connection.CreateCommand();
            command.Transaction = this.transaction;
            command.Connection = this.connection;
            command.CommandText = query;

            command.Parameters.Add(new MySqlParameter("EntityID", MySqlDbType.Binary));
            command.Parameters.Add(new MySqlParameter("DictID", MySqlDbType.Binary));
            command.Parameters.Add(new MySqlParameter("LanguageID", MySqlDbType.Binary));
            command.Parameters.Add(new MySqlParameter("Content", MySqlDbType.Text));
            command.Parameters.Add(new MySqlParameter("Creation_Timestamp", MySqlDbType.DateTime));
            command.Parameters.Add(new MySqlParameter("IsDeleted", MySqlDbType.Bit));
            command.Prepare();

            foreach (var d in dicts)
            {
                foreach (var entry in d.Contents)
                {
                    //Execute prepared statement
                    command.Parameters[0].Value = entry.EntityID.ToByteArray();
                    command.Parameters[1].Value = entry.DictID.ToByteArray();
                    command.Parameters[2].Value = entry.LanguageID.ToByteArray();
                    command.Parameters[3].Value = entry.Content;
                    command.Parameters[4].Value = entry.Creation_Timestamp;
                    command.Parameters[5].Value = entry.IsDeleted;

                    command.ExecuteNonQuery();

                    //Set query optmization parameters
                    entry.IsSaved = true;
                    entry.IsDirty = false;
                }
            }
        }

        public void Load()
        {
            //Do a group dictionary
            var group = dictionaries.GroupBy(x => x.SourceTable).ToDictionary(item => item.Key, item => item.ToList());
            foreach (string key in group.Keys)
            {
                this.Load(key, group[key]);
            }
        }

        protected void Load(string table, List<Dict> list)
        {
            if (table.EndsWith("_DE"))
                table = table.Substring(0, table.Length - 2) + "de";
            if (!table.EndsWith("_de"))
                table+="_de";
            string query = GetSelectQuery(table, list.Select(x => x.DictionaryID).ToArray());

            var hashTable = list.GroupBy(x => x.DictionaryID).ToDictionary(item => item.Key, x => x.ToList());


            MySqlCommand command = connection.CreateCommand();
            command.Transaction = this.transaction;
            command.Connection = this.connection;
            command.CommandText = query;


            for (int i=0; i < list.Count; i++)
            {
                list[i].Contents.Clear();
                command.Parameters.AddWithValue("D"+i, list[i].DictionaryID.ToByteArray());
            }

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                DictEntry entry = new DictEntry();
                entry.EntityID = reader.GetGuid(0);
                entry.DictID = reader.GetGuid(1);
                entry.LanguageID = reader.GetGuid(2);
                entry.Content = reader.IsDBNull(3) ? "": reader.GetString(3);
                entry.Creation_Timestamp = reader.GetDateTime(4);
                entry.IsDeleted = reader.GetBoolean(5);
                //Set entry IsDirty to false because it was loaded
                entry.IsDirty = false;
                entry.IsSaved = true;
                foreach(var item in hashTable[entry.DictID])
                    item.Contents.Add(entry);
            }
            reader.Close();

        }




    }
}
