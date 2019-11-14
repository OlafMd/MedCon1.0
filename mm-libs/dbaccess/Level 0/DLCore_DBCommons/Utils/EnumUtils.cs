using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ComponentModel;
using System.Xml;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace DLCore_DBCommons.Utils
{
    public static class EnumUtils
    {
        public static String GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        [Obsolete("GetEnumValueByDescription is deprecated, please use generic method instead.")]
        public static Enum GetEnumValueByDescription(string description, Type enumType)
        {
            var values = Enum.GetValues(enumType);
            foreach (Enum type in values)
            {
                if (GetEnumDescription(type) == description)
                    return type;
            }

            throw new Exception("There are no enum value that match description.");
        }

        public static T GetEnumValueByDescription<T>(string description) where T : struct, IConvertible
        {
            var values = Enum.GetValues(typeof(T));
            foreach (T type in values)
            {
                Enum e = (Enum)Enum.Parse(typeof(T), type.ToString());
                if (GetEnumDescription(e) == description)
                    return type;
            }

            throw new Exception("There are no enum value that match description.");
        }

        public static List<String> GetAllEnumDescriptions<T>()
        {
            var enumValues = Enum.GetValues(typeof(T)).Cast<T>();

            var contactTypes = enumValues.Select(i => GetEnumDescription((Enum)(object)i)).ToList();

            return contactTypes;
        }

        public static Dictionary<String, T> GetAllEnumTypeDescriptionPairs<T>()
        {
            var returnValue = new Dictionary<String, T>();

            var enumValues = Enum.GetValues(typeof(T)).Cast<T>();

            foreach (var item in enumValues) {

                var descriptions = GetEnumDescription((Enum)(object)item);

                returnValue.Add(descriptions, item);
            }



            return returnValue;

        } 

        public static Dictionary<String, Dict> GetDictObjectsForStaticListData<T>(String resourceFilePath, String tableName, List<ISOLanguage> languages)
        {            
            Assembly asm = Assembly.GetExecutingAssembly();
            XmlDocument resource = new XmlDocument();            
            XmlTextReader reader = new XmlTextReader(asm.GetManifestResourceStream(resourceFilePath));
            resource.Load(reader);

            var enumDescriptions = GetAllEnumDescriptions<T>();

            return DBCommonsReader.Instance.GetDictObjectsFromResourceFile(enumDescriptions, resource, tableName, languages);
        }
    }
}
