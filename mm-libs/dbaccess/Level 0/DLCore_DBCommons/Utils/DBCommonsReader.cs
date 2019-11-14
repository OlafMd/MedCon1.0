using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace DLCore_DBCommons
{
    ///<summary>
    /// Enum name from Resource.xml file
    ///<summary>
    public enum ResourceType { ComunicationCotactTypes }

    public class DBCommonsReader
    {
        #region Singleton Support

        private static DBCommonsReader instance = null;

        private DBCommonsReader()
        {
        }

        public static DBCommonsReader Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DBCommonsReader();
                }

                return instance;
            }
        }

        #endregion

        ///<summary>
        /// Get all items with all available translations from Resource.xml (DatabaseCommons)
        ///</summary>
        ///<param name="type">Node name of the resource</param>
        public List<ResourceItem> ReadResourceItemsFromResourceFile(XmlDocument resourceFile)
        {
            var results = new List<ResourceItem>();

            var xnList = resourceFile.SelectNodes("/Resources/Item");

            foreach (XmlNode  xnNode in xnList) {

                var result = new ResourceItem();

                String itemName = xnNode.Attributes["ID"].Value;
                result.ItemName = itemName;
                result.Translations = new List<Translation>();
                var xnTranslations = xnNode.SelectNodes("Lang");

                foreach (XmlNode xnTranslation in xnTranslations)
                {
                    var iso = xnTranslation.Attributes["ISO"].Value;
                    var value = xnTranslation.Attributes["Content"].Value;

                    var translation = new Translation() { ISO = iso, Content = value };
                    result.Translations.Add(translation);
                }

                results.Add(result);
            }
            return results;
        }

        ///<summary>
        /// Get Dict objects for the list of items from Resource.xml file and list of languages 
        ///</summary>
        ///<param name="enumValues">Specified enum values for type</param>
        ///<param name="path">Path to file</param>
        ///<param name="tableName">Table name of type in DB </param>
        ///<param name="languages">LanguageID values for current tenant</param>
        public Dictionary<String, Dict> GetDictObjectsFromResourceFile(List<String> enumValues, XmlDocument resourceFile,String tableName, List<ISOLanguage> languages){

            var result = new Dictionary<String, Dict>();

            var resourceItems = ReadResourceItemsFromResourceFile(resourceFile);

            foreach (var item in enumValues)
            {
                var labels = resourceItems.Where(i => i.ItemName == item).FirstOrDefault();

                var dict = new Dict(tableName);

                foreach (var label in labels.Translations)
                {
                    var language = languages.Where(i => i.ISO.ToLower() == label.ISO.ToLower()).FirstOrDefault();

                    if (language == null)
                        continue;

                    dict.AddEntry(language.LanguageID, label.Content);
                }
                result.Add(item, dict);
            }

            return result;
        }
    }

    #region Support Classes

    public class ResourceItem
    {
        public String ItemName { get; set; }
        public List<Translation> Translations { get; set; }
    }

    public class Translation
    {
        public String ISO { get; set; }
        public String Content { get; set; }
    }

    public class ISOLanguage {
        public String ISO { get; set; }
        public Guid LanguageID { get; set; }
    
    }

    #endregion

}
