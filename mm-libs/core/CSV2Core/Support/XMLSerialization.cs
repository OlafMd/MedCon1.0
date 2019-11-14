using System;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using CSV2Core.Logging;
using System.Xml;

namespace CSV2Core.Support
{
    /// <summary>
    /// Class to help in document serialization/deserialization to/from files, strings inputstreams
    /// </summary>
    public class XMLSerialization
    {    
        #region Save/Load Functions

        public static string SerializeToString(object obj)
        {
            XmlSerializer serializer = new XmlSerializer(obj.GetType());

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = new UTF8Encoding();
            settings.Indent = false;
            settings.OmitXmlDeclaration = true;

            using (StringWriter writer = new StringWriter())
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(writer, settings))
                { 
                    serializer.Serialize(xmlWriter, obj);
                }
                return writer.ToString();
            }
        }


        public static void saveToXML<T>(String fileLocation, T obj)
        {
            Exception exception = null;
            TextWriter textWriter = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                textWriter = new StreamWriter(fileLocation);
                serializer.Serialize(textWriter, obj);

            }
            catch (Exception ex)
            {
                DLSystemLog.add("Exception Occured", DLLogSeverity.ERROR, ex);
                exception = ex;
            }
            finally
            {
                if (textWriter != null)
                    textWriter.Close();
            }

            if (exception != null)
            {
                throw exception;
            }
        }

        public static T loadFromText<T>(String xml)
        {
            if (string.IsNullOrEmpty(xml))
            {
                return default(T);
            }

            XmlSerializer serializer = new XmlSerializer(typeof(T));
           
            XmlReaderSettings settings = new XmlReaderSettings();
            // No settings need modifying here
            using (StringReader textReader = new StringReader(xml))
            {
                using (XmlReader xmlReader = XmlReader.Create(textReader, settings))
                {
                    return (T)serializer.Deserialize(xmlReader);
                }
            }
        }


        public static T loadFromStream<T>(Stream stream)
        {
            TextReader textReader = null;
            object temp = null;
            Exception exception = null;

            try
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(T));
                textReader = new StreamReader(stream,Encoding.UTF8);
                temp = (T)deserializer.Deserialize(textReader);
            }
            catch (Exception ex)
            {
                DLSystemLog.add("Exception Occured", DLLogSeverity.ERROR, ex);
                exception = ex;
            }
            finally
            {
                if (textReader != null)
                    textReader.Close();
            }

            if (exception != null)
            {
                throw exception;
            }


            return (T)temp;
        }


        public static T loadFromFile<T>(String fileLocation)
        {
            Exception exception = null;

            TextReader textReader = null;
            object temp = null;
            try
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(T));
                textReader = new StreamReader(fileLocation);
                temp = (T)deserializer.Deserialize(textReader);
            }
            catch (Exception ex)
            {
                DLSystemLog.add("Exception Occured", DLLogSeverity.ERROR, ex);
                exception = ex;
            }
            finally
            {
                if (textReader != null)
                    textReader.Close();
            }

            if (exception != null)
            {
                throw exception;
            }

            return (T)temp;
        }
        #endregion
    }
}
