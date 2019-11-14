using Edifact_API.EDIFACT_Segments;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edifact_API.Models
{
    public class EDIMessage
    {
        private Parser parser;

        private string _rawMessage;
        public static Segment[] segmentArray;
        public string RawMessage
        {
            get { return _rawMessage; }
            set { _rawMessage = value; }
        }


        /// <summary>
        /// Instantiates the EDIFACT message interface for processing EDI files
        /// </summary>
        /// <param name="filename">Path of the UN/EDIFACT file.</param>
        public EDIMessage(string filename)
        {
            if (File.Exists(filename))
            {
                _rawMessage = FileUtils.Read(filename);
                if (!_rawMessage.StartsWith("UN"))
                    throw new ArgumentException("File is not a valid EDI message", filename);
                parser = new Parser(ref _rawMessage);
                segmentArray = parser.GetSegments();
            }
            else
                throw new FileNotFoundException("EDI message file was not found", filename);
        }
        /// <summary>
        /// Instantiates the EDIFACT message interface for processing EDI files (Stream)
        /// </summary>
        /// <param name="filename">Path of the UN/EDIFACT file.</param>
        public EDIMessage(Stream filename)
        {
            _rawMessage = FileUtils.Read(filename);
            if (!_rawMessage.StartsWith("UN"))
                throw new ArgumentException("File is not a valid EDI message");
            parser = new Parser(ref _rawMessage);
            segmentArray = parser.GetSegments();


        }



        public EDIFACT GetParsedEdifactFile()
        {
            var parsedEdifact = SegmentsToParsedEdifact();
            return parsedEdifact;
        }

        private static T ParseSegment<T>(FieldCollection src) where T : DataSegment, new()
        {
            var result = new T();
            var properties = typeof(T).GetProperties();
            for (var i = 0; i < src.Count; i++)
            {
                var prop = properties.Single(t => t.Name == String.Format("Segment{0}", i + 1));
                var value = prop.PropertyType.GetConstructors().First().Invoke(null);
                ((AbstractElement)value).Value = src.Item(i).Value;
                prop.SetValue(result, value);
            }

            return result;
        }

        public static EDIFACT SegmentsToParsedEdifact()
        {
            var result = new EDIFACT();
            result.transmitionMessages = new List<TransmitionMessage>();
            var message = new TransmitionMessage();
            var messageCount = 0;
            for (var i = 0; i < segmentArray.Length; i++)
            {
                var segment = segmentArray[i];
                switch (segment.Name)
                {
                    case "UNA":
                        {
                            continue;
                        }
                    case "UNB":
                        result.Unb = ParseSegment<UNB>(segment.Fields);
                        break;
                    case "UNH":
                        if (messageCount != 0)
                        {
                            result.transmitionMessages.Add(message);
                            message = new TransmitionMessage();
                        }

                        message.Unh = ParseSegment<UNH>(segment.Fields);
                        messageCount++;
                        break;
                    case "IVK":
                        message.Ivk = ParseSegment<IVK>(segment.Fields);
                        break;
                    case "IBH":
                        break;
                    case "INF":
                        break;
                    case "INV":
                        break;
                    case "DIA":
                        break;
                    case "ABR":
                        break;
                    case "FKI":
                        break;
                    case "RGI":
                        message.Rgi = ParseSegment<RGI>(segment.Fields);
                        break;
                    case "FHL":
                        var fhl = ParseSegment<FHL>(segment.Fields);
                        message.Fhl.Add(fhl);
                        break;
                    case "UNT":
                        break;
                    case "UNZ":
                        {
                            continue;
                        }
                }
            }

            result.transmitionMessages.Add(message);
            return result;
        }
    }
}
