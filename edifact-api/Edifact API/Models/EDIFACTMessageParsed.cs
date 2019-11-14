using Edifact_API.EDIFACT_Segments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edifact_API.Models
{
    public class EDIFACTMessageParsed
    {
        public MessageProperties messageProperties { get; set; }
        public List<Message> messages { get; set; }
    }

    public class MessageProperties
    {
        public Int32 messageCount { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public string sender { get; set; }
        public string receiver { get; set; }
    }

    public class Message
    {
        public UNH unh { get; set; }
        public IVK ivk { get; set; }
        public IBH ibh { get; set; }
        public INF inf { get; set; }
        public INV inv { get; set; }
        public DIA dia { get; set; }
        public ABR abr { get; set; }
        public FKI fki { get; set; }
        public RGI rgi { get; set; }
        public List<FHL> fhl { get; set; }
        public UNT unt { get; set; }

        public Message()
        {
            this.fhl = new List<FHL>();
        }
    }
}
