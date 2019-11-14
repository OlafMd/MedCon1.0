using System;
using System.Collections.Generic;
using System.Data.Common;
using MySql.Data.MySqlClient;
using CSV2Core_MySQL.Dictionaries.MultiTable;
//Stefan Martinov <stefan.martinov@danulabs.com>
//Danulabs 2012
namespace CSV2Core_MySQL.Support
{
    public class DBSQLReader
    {
        protected MySqlDataReader reader;
        protected int[] ordinalMapping;

        public DBSQLReader(DbDataReader reader)
        {
            this.reader = (MySqlDataReader) reader;
                   
        }

        public void SetOrdinals(string[] parameters)
        {
            List<int> ordinals = new List<int>();
            for (int i=0; i<parameters.Length; i++)
            {
                ordinals.Add(reader.GetOrdinal(parameters[i]));
            }
            ordinalMapping = ordinals.ToArray();
        }

        public bool HasRows
        {
            get
            {
                return reader.HasRows;
            }
        }

        public bool Read()
        {
            return reader.Read();
        }

        public void Close()
        {
            reader.Close();
        }

        #region DataReader Custom Get Methods

        public Boolean GetBoolean(int ordinal)
        {
            ordinal = ordinalMapping[ordinal];
            return reader.IsDBNull(ordinal)? default(Boolean):reader.GetBoolean(ordinal);
        }

        public int GetInteger(int ordinal)
        {
            ordinal = ordinalMapping[ordinal];
            return reader.IsDBNull(ordinal)? default(Int32):reader.GetInt32(ordinal);
        }

        public long GetLong(int ordinal)
        {
            ordinal = ordinalMapping[ordinal];
            return reader.IsDBNull(ordinal)? default(long):reader.GetInt64(ordinal);
        }

        public double GetDouble(int ordinal)
        {
            ordinal = ordinalMapping[ordinal];
            return reader.IsDBNull(ordinal)? default(double):reader.GetDouble(ordinal);
        }

        public decimal GetDecimal(int ordinal)
        {
            ordinal = ordinalMapping[ordinal];
            return reader.IsDBNull(ordinal) ? default(decimal) : reader.GetDecimal(ordinal);
        }

        public Guid GetGuid(int ordinal)
        {
            ordinal = ordinalMapping[ordinal];
            if(reader.IsDBNull(ordinal) == true)
            {
                return default(Guid);
            }
            else
            {
                var guidBytes = reader[ordinal] as byte[];
                return new Guid(guidBytes);
            }
            
        }

        public DateTime GetDate(int ordinal)
        {
            ordinal = ordinalMapping[ordinal];
            return reader.IsDBNull(ordinal)? default(DateTime):reader.GetDateTime(ordinal);
        }

        public string GetString(int ordinal)
        {
            ordinal = ordinalMapping[ordinal];
            return reader.IsDBNull(ordinal)? default(string):reader.GetString(ordinal);
        }
        
        public Dict GetDictionary(int ordinal)
        {
            Dict dict = new Dict(null);
            dict.DictionaryID =  GetGuid(ordinal);
            return dict;
        }

        #endregion

      
    }

    
}
