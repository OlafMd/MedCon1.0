using System;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System.Xml.Linq;

namespace CSV2Core.Support
{
    public enum GeneratorFileType
    {
        Unknown,
        BaseClass,
        AtomicMethod,
        ComplexMethod
    }

    public class XMLSupport
    {
      


        public static GeneratorFileType ParseGeneratorTypeFromText(string xmlText)
        {
            GeneratorFileType gtype = GeneratorFileType.Unknown;
            try
            {
                XDocument document = XDocument.Parse(xmlText);
                string  componentType = document.Descendants("Componenttype").First().Value;
                gtype = (GeneratorFileType)Enum.Parse(typeof(GeneratorFileType), componentType);
            }
            catch
            {
                gtype = GeneratorFileType.Unknown;
            }

            return gtype;
        }
        

        /// <summary>
        /// To convert a Byte Array of Unicode values (UTF-8 encoded) to a complete String.
        /// </summary>
        /// <param name="characters">Unicode Byte Array to be converted to String</param>
        /// <returns>String converted from Unicode Byte Array</returns>
        private static string UTF8ByteArrayToString(Byte[] _characters)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            string constructedString = encoding.GetString(_characters);
            return constructedString;
        }
        /// <summary>
        /// To convert a Byte Array of Unicode values (UTF-16 encoded) to a complete String.
        /// </summary>
        /// <param name="_characters">UTF-16 Byte Array to be converted to String</param>
        /// <returns>String converted from Unicode Byte Array</returns>
        private static string UnicodeByteArrayToString(Byte[] _characters)
        {
            UnicodeEncoding encoding = new UnicodeEncoding();
            string constructedString = encoding.GetString(_characters);
            return constructedString;
        }

        /// <summary>
        /// Converts the String to UTF8 Byte array and is used in De serialization
        /// </summary>
        /// <param name="pXmlString"></param>
        /// <returns></returns>
        private static Byte[] StringToUTF8ByteArray(string _XmlString)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            Byte[] byteArray = encoding.GetBytes(_XmlString);
            return byteArray;
        }
        /// <summary>
        /// Converts the String to UTF-16 Byte array and is used in De serialization
        /// </summary>
        /// <param name="_XmlString"></param>
        /// <returns></returns>
        private static Byte[] StringToUnicodeByteArray(string _XmlString)
        {
            UnicodeEncoding encoding = new UnicodeEncoding();
            Byte[] byteArray = encoding.GetBytes(_XmlString);
            return byteArray;
        }

        public static string SerializeObject(Object _Object, System.Type _Type)
        {

            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");                                                // Disables Microsoft-Specific namespaces of xml-header

            string XmlizedString = null;
            MemoryStream memoryStream = new MemoryStream();
            XmlSerializer xs = new XmlSerializer(_Type);
            XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
            xmlTextWriter.Formatting = Formatting.Indented;
            xs.Serialize(xmlTextWriter, _Object, ns);
            memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
            XmlizedString = XMLSupport.UTF8ByteArrayToString(memoryStream.ToArray());

            return XmlizedString;
        }

        /// <summary>
        /// Provides to option to enable/disable the addition of the UTF8 byte order mark.
        /// </summary>
        /// <param name="_Object"></param>
        /// <param name="_Type"></param>
        /// <param name="_byteOrderMark"></param>
        /// <returns></returns>
        public static string SerializeObject(Object _Object, System.Type _Type, bool _byteOrderMark)
        {
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");                                                // Disables Microsoft-Specific namespaces of xml-header

            string XmlizedString = null;
            MemoryStream memoryStream = new MemoryStream();
            XmlSerializer xs = new XmlSerializer(_Type);
            UTF8Encoding encoding = new UTF8Encoding(_byteOrderMark);
            XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, encoding);
            xmlTextWriter.Formatting = Formatting.Indented;
            xs.Serialize(xmlTextWriter, _Object, ns);
            memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
            XmlizedString = XMLSupport.UTF8ByteArrayToString(memoryStream.ToArray());

            return XmlizedString;
        }

        public static Object DeserializeObject(string _XMLString, System.Type _Type)
        {
            XmlSerializer xs = new XmlSerializer(_Type);
            MemoryStream memoryStream = new MemoryStream(XMLSupport.StringToUTF8ByteArray(_XMLString));
            XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
            Object DeserializedObject = xs.Deserialize(memoryStream);
            return DeserializedObject;
        }

        public static Object DeserializeObject(string _XMLString, System.Type _Type, Encoding _EncType)
        {
            if (_EncType.EncodingName.ToLower().Contains("utf-8"))
            {
                return DeserializeObject(_XMLString, _Type);
            }
            if (_EncType.EncodingName.ToLower() == "unicode")//== utf-16 but 
            {
                XmlSerializer xs = new XmlSerializer(_Type);
                MemoryStream memoryStream = new MemoryStream(XMLSupport.StringToUnicodeByteArray(_XMLString));
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.Unicode);
                Object DeserializedObject = xs.Deserialize(memoryStream);
                return DeserializedObject;
            }
            else
            {
                return null;
            }
        }

        public static string SerializeObject(Object _Object, System.Type _Type, Encoding _EncType)
        {
            if (_EncType.EncodingName.ToLower().Contains("utf-8"))
            {
                return SerializeObject(_Object, _Type);
            }
            if (_EncType.EncodingName.ToLower() == "unicode")//== utf-16 but 
            {

                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");

                string XmlizedString = null;
                MemoryStream memoryStream = new MemoryStream();
                XmlSerializer xs = new XmlSerializer(_Type);
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.Unicode);
                xmlTextWriter.Formatting = Formatting.Indented;
                xs.Serialize(xmlTextWriter, _Object, ns);
                memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
                XmlizedString = XMLSupport.UnicodeByteArrayToString(memoryStream.ToArray());

                return XmlizedString;

            }
            else
            { return "<?xml encoding=\"not_provided\"?>"; }
        }


    }
}
