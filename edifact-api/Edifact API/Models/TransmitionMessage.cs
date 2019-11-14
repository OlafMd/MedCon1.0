using Edifact_API.EDIFACT_Segments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edifact_API.Models
{
    public class TransmitionMessage
    {
        public UNH Unh { get; set; }

        public IVK Ivk { get; set; }

        public IBH Ibh { get; set; }

        public INF Inf { get; set; }

        public INV Inv { get; set; }

        public DIA Dia { get; set; }
        
        public ABR Abr { get; set; }

        public FKI Fki { get; set; }

        public RGI Rgi { get; set; }

        public UNT Unt { get; set; }

        public List<FHL> Fhl { get; set; }

        public TransmitionMessage()
        {
            var properties = this.GetType().GetProperties();
            foreach (var prop in properties)
            {
                var val = prop.PropertyType.GetConstructors().First().Invoke(null);
                prop.SetValue(this, val);
            }
        }

        public override string ToString()
        {
            var properties = this.GetType().GetProperties();
            var message = "";
            foreach (var prop in properties.Where(t => t.Name != "Fhl"))
            {
                message += prop.GetValue(this).ToString();
            }

            return message;
        }
    }


    public class DefaultTransmitionMessageData
    {
        /// <summary>
        /// Code identifying a type of message and assigned by its controlling agency.
        /// Default DIR73C.
        /// </summary>
        public string messageTypeIdentifier { get; set; }
        /// <summary>
        /// Version number of a message type.
        /// Default 3.
        /// </summary>
        public uint messageVersionNumber { get; set; }
        /// <summary>
        /// Release number within the current message version number.
        /// Default 0.
        /// </summary>
        public uint messageReleaseNumber { get; set; }

        /// <summary>
        /// Code identifying a controlling agency.
        /// Default DR.
        /// </summary>
        public string controllingAgency { get; set; }
        /// <summary>
        /// Key 6.1.9
        /// Default value: 10.
        /// </summary>
        public uint processingFlag { get; set; }
        /// <summary>
        /// Default 01
        /// </summary>
        public string serialNumberOfTheTransaction { get; set; }
        /// <summary>
        /// 0 Default
        /// 2 Accident
        /// 3 Chronic illness
        /// Default value is 0.
        /// </summary>
        public uint accidentIndicator { get; set; }
        /// <summary>
        /// 0 Direct (default)
        /// 1 original form (transfer)
        /// 2 Representatives bill
        /// 3 emergency bill
        /// 4 target job
        /// 5 Konsiliarauftrag
        /// 6 co- / further processing
        /// 7 Settlement agreements pursuant to §§ 73b, c SGB V
        /// 8 Settlement agreements pursuant to § 140a SGB V
        /// Default value 7.
        /// </summary>
        public int typeOfUse { get; set; }
        /// <summary>
        /// <para>Quantity of how often this position is charged.</para>
        /// <para>Default value 1.</para>
        /// </summary>
        public int numberOfCharges { get; set; }
        /// <summary>
        /// <para>1 single billing</para>
        /// <para>2 collective invoice</para>
        /// <para>3 Addendum account</para>
        /// <para>4 credit / Cancellation</para>
        /// <para>5 reminder</para>
        /// <para>6 1st reminder</para>
        /// <para>7 2nd reminder</para>
        /// <para>Default 1</para>
        /// </summary>
        public int typeOfAccounting { get; set; }
        /// <summary>
        /// <para>Provides information on the number of corrections.</para>
        /// <para>Billing is marked with "0".</para>
        /// </summary>
        public uint correctionCounter { get; set; }
    }
}
