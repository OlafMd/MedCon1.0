using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Realm.APODemand
{
    public class CustomerRequestResponseCreate
    {
        public const string MESSAGE_TYPE = "realm.cmn.customer.request_response.create";

        public CustomerRequestResponseCreate(){}

        [XmlElement]
        public RequestResponse_ContentHeader ContentHeader { get; set; }

        [XmlElement]
        public RequestResponse_Positions Positions { get; set; }

        public class RequestResponse_ContentHeader
        {
            [XmlElement(ElementName = "RequestResponse")]
            public RequestResponseItem RequestResponse { get; set; }

            [XmlElement(ElementName = "RequestForProposal")]
            public RequestForProposalItem RequestForProposal { get; set; }

            [XmlElement(ElementName = "IsProposalDeclined")]
            public IsProposalDeclinedItem IsProposalDeclined { get; set; }
        }

        public class RequestResponse_Positions
        {
            public RequestResponse_Positions()
            {
                OrderSequence = new List<RequestResponsePosition>();
            }

            [XmlArray(ElementName = "OrderSequence")]
            public List<RequestResponsePosition> OrderSequence { get; set; }
        }
    }

    public class RequestResponseItem
    {
        public RequestResponseItem(){}

        public RequestResponseItem(string requestResponseITPL = "")
        {
            RequestResponseITPL = requestResponseITPL;
        }

        [XmlAttribute(AttributeName = "RequestResponseITPL")]
        public String RequestResponseITPL { get; set; }
    }

    public class IsProposalDeclinedItem
    {
        public IsProposalDeclinedItem() { }

        public IsProposalDeclinedItem(string comment = "", string value = "")
        {
            Value = value;
            Comment = comment;
        }

        [XmlAttribute(AttributeName = "Value")]
        public String Value { get; set; }

        [XmlElement(ElementName = "Comment")]
        public String Comment { get; set; }
    }

    public class RequestResponsePosition : Position
    {
        public RequestResponsePosition() : base()
        {
            IsReplacementProduct = new IsReplacementProductItem();
        }

        [XmlAttribute(AttributeName = "RequestResponsePositionITPL")]
        public String RequestResponsePositionITPL { get; set; }

        [XmlAttribute(AttributeName = "ProposalPositionITPL")]
        public String ProposalPositionITPL { get; set; }

        [XmlElement(ElementName = "PricePerItemWithoutTax")]
        public String PricePerItemWithoutTax { get; set; }

        [XmlElement(ElementName = "IsReplacementProduct")]
        public IsReplacementProductItem IsReplacementProduct { get; set; }

        [XmlElement(ElementName = "ResponseValidUntil")]
        public String ResponseValidUntil { get; set; }
    }

    public class IsReplacementProductItem
    {
        [XmlAttribute(AttributeName = "Value")]
        public String Value { get; set; }
    }
}
