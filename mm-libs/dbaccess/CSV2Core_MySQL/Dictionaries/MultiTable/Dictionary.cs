using System;
using System.Collections.Generic;
using System.Linq;

namespace CSV2Core_MySQL.Dictionaries.MultiTable
{
    [Serializable ]
    public class Dict 
    {
        public string SourceTable { get; set; }
        public Guid DictionaryID { get; set; }
        //Contents are only used for the loader, users should use Dictionaries parameter
        public List<DictEntry> Contents { get; set; }
        [NonSerialized]
        private bool _IsDirty = true;

        public Dict()
        {
            this.Contents = new List<DictEntry>();
        }

        public Dict(string sourceTable)
        {
            this.SourceTable = sourceTable;
            this.DictionaryID = Guid.NewGuid();
            this.Contents = new List<DictEntry>();
        }

        public Dict(string sourceTable, Guid dictionaryID)
        {
            this.SourceTable = sourceTable;
            this.DictionaryID = dictionaryID;
            this.Contents = new List<DictEntry>();
        }

        public Dict CopyContents(string tableName)
        {
            Dict copy = new Dict(tableName);
            foreach (DictEntry entry in Contents)
            {
                copy.UpdateEntry(entry.LanguageID, entry.Content);
            }
            return copy;
        }

        /// <summary>
        /// Standard IsDirty check
        /// </summary>
        public bool IsDirty
        {
            get
            {
                return _IsDirty || (Contents.FirstOrDefault(x => x.IsDirty == true) != null);
            }
        }

        #region Dictionary Manipulation
        /// <summary>
        /// Add new component
        /// </summary>
        /// <param name="languageID"></param>
        /// <param name="content"></param>
        public void AddEntry(Guid languageID, string content)
        {
            this._IsDirty = true;
            DictEntry entry = new DictEntry();
            entry.DictID = this.DictionaryID;
            entry.EntityID = Guid.NewGuid();
            entry.LanguageID = languageID;
            entry.Content = content;
            entry.IsDirty = true;
            this.Contents.Add(entry);
        }

        public void RemoveEntry(Guid languageID)
        {
            DictEntry entry = Contents.FirstOrDefault(x => x.LanguageID == languageID);
            if (entry == null)
                return;

            this._IsDirty = true;
            entry.IsDeleted = true;
            Contents.Remove(entry);
        }

        /// <summary>
        /// Adds/Updates dictionary content
        /// </summary>
        /// <param name="languageID"></param>
        /// <param name="content"></param>
        public void UpdateEntry(Guid languageID, string content)
        {
            DictEntry entry = Contents.FirstOrDefault(x => x.LanguageID == languageID);
            this._IsDirty = true;
            //Add if it not exists, or update if it exists
            if (entry == null)
            {
                AddEntry(languageID, content);
            }
            else
            {
                entry.Content = content;
            }
        }

        public void UpdateEntry(string language, string content)
        {
            var lang =  CSV2Core.Support.LanguageMap.GetLanguageFor(language);
            if(lang == null) return;


            DictEntry entry = Contents.FirstOrDefault(x => x.LanguageID == lang.LanguageID);
            this._IsDirty = true;
            //Add if it not exists, or update if it exists
            if (entry == null)
            {
                AddEntry(lang.LanguageID, content);
            }
            else
            {
                entry.Content = content;
            }
        }


        public string GetContent(params Guid[] languages)
        {
            foreach (Guid language in languages)
            {
                string contentForLanguage = GetContentFor(language);
                if (contentForLanguage != null && contentForLanguage != "")
                {
                    return contentForLanguage;
                }
            }
            return "";
        }

        /// <summary>
        /// Gets the content of the dictionary for the ISO text, based on CSV2Core.Support.LanguageMap
        /// </summary>
        /// <param name="languages">The languages.</param>
        /// <returns></returns>
        public string GetContent(params string[] languages)
        {
            List<Guid> languageGuids = new List<Guid>();
            foreach (var lang in languages)
            {
                var language = CSV2Core.Support.LanguageMap.GetLanguageFor(lang);
                if (language!= null)
                {
                    languageGuids.Add(language.LanguageID);
                }
            }
            return GetContent(languageGuids.ToArray());
        }

        public string GetContent(String dafaultString, params Guid[] languages)
        {
            foreach (Guid language in languages)
            {
                string contentForLanguage = GetContentFor(language);
                if (contentForLanguage != null && contentForLanguage != "")
                {
                    return contentForLanguage;
                }
            }

            return dafaultString;
        }


        /// <summary>
        /// Gets the content for the given language
        /// </summary>
        /// <param name="languageID">Language that we are searching for</param>
        /// <returns>the content or an empty string if there is none</returns>
        private string GetContentFor(Guid languageID)
        {
            DictEntry entry = Contents.FirstOrDefault(x => x.LanguageID == languageID);
            //Add if it not exists, or update if it exists
            if (entry == null)
            {
                return null;
            }
            else
            {
                return entry.Content;
            }
        }
        #endregion

    }
       [Serializable()]
    public class DictEntry
    {
        private bool _IsDirty = true;

        public bool IsDirty { get { return _IsDirty; } set { _IsDirty = value; } }
        public bool IsSaved { get; set; }

        #region Class Parameters


        private Guid _EntityID;
        private Guid _DictID;
        private Guid _LanguageID;
        private string _Content;
        private DateTime _Creation_Timestamp;
        private bool _IsDeleted;

        public Guid EntityID
        {
            get { return _EntityID; }
            set
            {
                if (_EntityID != value)
                {
                    _EntityID = value;
                    IsDirty = true;
                }
            }
        }


        public Guid DictID
        {
            get { return _DictID; }
            set
            {
                if (_DictID != value)
                {
                    IsDirty = true;
                    _DictID = value;
                }
            }
        }


        public Guid LanguageID
        {
            get { return _LanguageID; }
            set
            {
                if (_LanguageID != value)
                {
                    _LanguageID = value;
                    IsDirty = true;
                }
            }
        }


        public string Content
        {
            get { return _Content; }
            set
            {
                if (_Content != value)
                {
                    IsDirty = true;
                    _Content = value;
                }
            }
        }


        public DateTime Creation_Timestamp
        {
            get { return _Creation_Timestamp; }
            set
            {
                if (_Creation_Timestamp != value)
                {
                    _Creation_Timestamp = value;
                    IsDirty = true;
                }
            }
        }



        public bool IsDeleted
        {
            get { return _IsDeleted; }
            set
            {
                if (_IsDeleted != value)
                {
                    IsDirty = true;
                    _IsDeleted = value;
                }

            }
        }



        #endregion

        public DictEntry()
        {
            Clear();
            Creation_Timestamp = DateTime.Now;
        }

        public void Clear()
        {
            EntityID = Guid.NewGuid();
            DictID = Guid.Empty;
            LanguageID = Guid.Empty;

            Content = "";
            Creation_Timestamp = DateTime.MinValue;
            IsDeleted = false;
            IsDirty = true;
            IsSaved = false;
        }
    }
}
