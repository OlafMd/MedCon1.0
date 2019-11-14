using System;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace DLCore_DBCommons
{
    public static class SerializationUtils
    {
        public static string SerializeObject<T>(this T toSerialize)
        {

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;

            MemoryStream ms = new MemoryStream();
            XmlWriter writer = XmlWriter.Create(ms, settings);

            XmlSerializerNamespaces names = new XmlSerializerNamespaces();
            names.Add("", "");

            XmlSerializer cs = new XmlSerializer(typeof(T));

            cs.Serialize(writer, toSerialize, names);

            ms.Flush();
            ms.Seek(0, SeekOrigin.Begin);
            StreamReader sr = new StreamReader(ms);
            string serializedString = sr.ReadToEnd();
            return serializedString;
        }

        public static T ParseFromPayload<T>(String payload)
        {
            if (string.IsNullOrEmpty(payload))
            {
                return default(T);
            }
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            
            XmlReaderSettings settings = new XmlReaderSettings();
            // No settings need modifying here
            string decodedString = Uri.UnescapeDataString(payload);
            using (StringReader textReader = new StringReader(decodedString))
            {
                using (XmlReader xmlReader = XmlReader.Create(textReader, settings))
                {
                    return (T)serializer.Deserialize(xmlReader);
                }
            }
        }
    }
}
