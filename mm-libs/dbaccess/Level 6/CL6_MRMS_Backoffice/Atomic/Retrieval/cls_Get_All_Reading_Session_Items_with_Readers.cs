/* 
 * Generated on 3/8/2015 6:58:35 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 * Required Assemblies:
 * System.Runtime.Serialization
 * CSV2Core
 * CSV2Core_MySQL
 */
using System;
using System.Linq;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Runtime.Serialization;

namespace CL6_MRMS_Backoffice.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_All_Reading_Session_Items_with_Readers.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_All_Reading_Session_Items_with_Readers
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6MRMS_GARSIwR_1056_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L6MRMS_GARSIwR_1056 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L6MRMS_GARSIwR_1056_Array();

            var resItems = new List<L6MRMS_GARSIwR_1056>();

            var readers = cls_Get_All_Accounts_For_MeasurementRun.Invoke(Connection, Transaction, new P_L6MRMS_GAAfMR_0930() { MeasurementRunID = Parameter.ReadingSessionId }, securityTicket).Result;

            var details = cls_Get_All_Reading_Session_Items.Invoke(Connection, Transaction, new P_L6MRMS_GARSI_2117() { ReadingSessionId = Parameter.ReadingSessionId }, securityTicket).Result;

            foreach(var item in details)
            {
                var detail = new L6MRMS_GARSIwR_1056()
                    {
                        City = item.City,
                        ContractNumber = item.ContractNumber,
                        MeasurementID = item.MeasurementID,
                        MeterSerialNumber = item.MeterSerialNumber,
                        OwnerFirstName = item.OwnerFirstName,
                        OwnerLastName = item.OwnerLastName,
                        RouteName = item.RouteName,
                        SequenceInRoute = item.SequenceInRoute,
                        StreetName = item.StreetName,
                        StreetNumber = item.StreetNumber,
                        City_PostalCode = item.City_PostalCode
                    };

                if (item.MeasurementValues.Count() > 0)
                {
                    detail.MeasuredOn = item.MeasurementValues.First().MeasuredAt_Time;
                }
                else
                {
                    detail.MeasuredOn = DateTime.MinValue;
                }

                var values = new List<L6MRMS_GARSIwR_1056_MeasurementValue>();
                foreach (var val in item.MeasurementValues)
                {
                    values.Add(new L6MRMS_GARSIwR_1056_MeasurementValue()
                    {
                        MeasuredAt_Time = val.MeasuredAt_Time,
                        MeasurementTariffName = val.MeasurementTariffName,
                        MeasurementValue = val.MeasurementValue,
                        MRS_RUN_Measurement_TariffID = val.MRS_RUN_Measurement_TariffID,
                        AcqusitionTypeGPM = val.AcqusitionTypeGPM,
                        MRS_RUN_Measurement_ValueID = val.MRS_RUN_Measurement_ValueID,
                        Tariff_GlobalPropertyMatchingID = val.Tariff_GlobalPropertyMatchingID
                    });
                }
                detail.MeasurementValues = values.ToArray();

                var reader = readers.First(r => r.CMN_BPT_BusinessParticipantID == item.BoundTo_Account_RefID);

                detail.ReaderEmail = reader.PrimaryEmail;
                detail.ReaderFirstName = reader.FirstName;
                detail.ReaderLastName = reader.LastName;

                resItems.Add(detail);
            }
            returnValue.Result = resItems.ToArray();
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6MRMS_GARSIwR_1056_Array Invoke(string ConnectionString,P_L6MRMS_GARSIwR_1056 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6MRMS_GARSIwR_1056_Array Invoke(DbConnection Connection,P_L6MRMS_GARSIwR_1056 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6MRMS_GARSIwR_1056_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L6MRMS_GARSIwR_1056 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6MRMS_GARSIwR_1056_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6MRMS_GARSIwR_1056 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6MRMS_GARSIwR_1056_Array functionReturn = new FR_L6MRMS_GARSIwR_1056_Array();
			try
			{

				if (cleanupConnection == true) 
				{
					Connection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(ConnectionString);
					Connection.Open();
				}
				if (cleanupTransaction == true)
				{
					Transaction = Connection.BeginTransaction();
				}

				functionReturn = Execute(Connection, Transaction,Parameter,securityTicket);

				#region Cleanup Connection/Transaction
				//Commit the transaction 
				if (cleanupTransaction == true)
				{
					Transaction.Commit();
				}
				//Close the connection
				if (cleanupConnection == true)
				{
					Connection.Close();
				}
				#endregion
			}
			catch (Exception ex)
			{
				try
				{
					if (cleanupTransaction == true && Transaction!=null)
					{
						Transaction.Rollback();
					}
				}
				catch { }

				try
				{
					if (cleanupConnection == true && Connection != null)
					{
						Connection.Close();
					}
				}
				catch { }

				throw new Exception("Exception occured in method cls_Get_All_Reading_Session_Items_with_Readers",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6MRMS_GARSIwR_1056_Array : FR_Base
	{
		public L6MRMS_GARSIwR_1056[] Result	{ get; set; } 
		public FR_L6MRMS_GARSIwR_1056_Array() : base() {}

		public FR_L6MRMS_GARSIwR_1056_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6MRMS_GARSIwR_1056 for attribute P_L6MRMS_GARSIwR_1056
		[DataContract]
		public class P_L6MRMS_GARSIwR_1056 
		{
			//Standard type parameters
			[DataMember]
			public Guid ReadingSessionId { get; set; } 

		}
		#endregion
		#region SClass L6MRMS_GARSIwR_1056 for attribute L6MRMS_GARSIwR_1056
		[DataContract]
		public class L6MRMS_GARSIwR_1056 
		{
			[DataMember]
			public L6MRMS_GARSIwR_1056_MeasurementValue[] MeasurementValues { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid MeasurementID { get; set; } 
			[DataMember]
			public string MeterSerialNumber { get; set; } 
			[DataMember]
			public string ContractNumber { get; set; } 
			[DataMember]
			public string OwnerFirstName { get; set; } 
			[DataMember]
			public string OwnerLastName { get; set; } 
			[DataMember]
			public string StreetName { get; set; } 
			[DataMember]
			public string StreetNumber { get; set; } 
			[DataMember]
			public string City { get; set; } 
			[DataMember]
			public string City_PostalCode { get; set; } 
			[DataMember]
			public string RouteName { get; set; } 
			[DataMember]
			public int SequenceInRoute { get; set; } 
			[DataMember]
			public string ReaderFirstName { get; set; } 
			[DataMember]
			public string ReaderLastName { get; set; } 
			[DataMember]
			public string ReaderEmail { get; set; } 
			[DataMember]
			public DateTime MeasuredOn { get; set; } 

		}
		#endregion
		#region SClass L6MRMS_GARSIwR_1056_MeasurementValue for attribute MeasurementValues
		[DataContract]
		public class L6MRMS_GARSIwR_1056_MeasurementValue 
		{
			//Standard type parameters
			[DataMember]
			public Guid MRS_RUN_Measurement_TariffID { get; set; } 
			[DataMember]
			public Guid MRS_RUN_Measurement_ValueID { get; set; } 
			[DataMember]
			public DateTime MeasuredAt_Time { get; set; } 
			[DataMember]
			public double MeasurementValue { get; set; } 
			[DataMember]
			public string AcqusitionTypeGPM { get; set; } 
			[DataMember]
			public string Tariff_GlobalPropertyMatchingID { get; set; } 
			[DataMember]
			public Dict MeasurementTariffName { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6MRMS_GARSIwR_1056_Array cls_Get_All_Reading_Session_Items_with_Readers(,P_L6MRMS_GARSIwR_1056 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6MRMS_GARSIwR_1056_Array invocationResult = cls_Get_All_Reading_Session_Items_with_Readers.Invoke(connectionString,P_L6MRMS_GARSIwR_1056 Parameter,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

/* Support for Parameter Invocation (Copy&Paste)
var parameter = new CL6_MRMS_Backoffice.Atomic.Retrieval.P_L6MRMS_GARSIwR_1056();
parameter.ReadingSessionId = ...;

*/
