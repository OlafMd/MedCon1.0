/* 
 * Generated on 8/30/2013 11:21:19 AM
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

namespace CL5_OphthalShipments.Atomic.Retrieval
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ActiveShippmentForDoctorID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ActiveShippmentForDoctorID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5OD_GASFD_1234_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5OS_GASFD_1234 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5OD_GASFD_1234_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_OphthalShipments.Atomic.Retrieval.SQL.cls_Get_ActiveShippmentForDoctorID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"HEC_DoctorID", Parameter.HEC_DoctorID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"FormDate", Parameter.FormDate);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ToDate", Parameter.ToDate);



			List<L5OD_GASFD_1234> results = new List<L5OD_GASFD_1234>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_ShippingPosition_BarcodeLabelID","LOG_SHP_Shipment_PositionID","LOG_SHP_Shipment_HeaderID","ShippingPosition_BarcodeLabel","Header_Creation_Timestamp","Creation_Timestamp","R_IsSubmission_Complete" });
				while(reader.Read())
				{
					L5OD_GASFD_1234 resultItem = new L5OD_GASFD_1234();
					//0:Parameter HEC_ShippingPosition_BarcodeLabelID of type Guid
					resultItem.HEC_ShippingPosition_BarcodeLabelID = reader.GetGuid(0);
					//1:Parameter LOG_SHP_Shipment_PositionID of type Guid
					resultItem.LOG_SHP_Shipment_PositionID = reader.GetGuid(1);
					//2:Parameter LOG_SHP_Shipment_HeaderID of type Guid
					resultItem.LOG_SHP_Shipment_HeaderID = reader.GetGuid(2);
					//3:Parameter ShippingPosition_BarcodeLabel of type String
					resultItem.ShippingPosition_BarcodeLabel = reader.GetString(3);
					//4:Parameter Header_Creation_Timestamp of type DateTime
					resultItem.Header_Creation_Timestamp = reader.GetDate(4);
					//5:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(5);
					//6:Parameter R_IsSubmission_Complete of type bool
					resultItem.R_IsSubmission_Complete = reader.GetBoolean(6);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_ActiveShippmentForDoctorID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = results.ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5OD_GASFD_1234_Array Invoke(string ConnectionString,P_L5OS_GASFD_1234 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5OD_GASFD_1234_Array Invoke(DbConnection Connection,P_L5OS_GASFD_1234 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5OD_GASFD_1234_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5OS_GASFD_1234 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5OD_GASFD_1234_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5OS_GASFD_1234 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5OD_GASFD_1234_Array functionReturn = new FR_L5OD_GASFD_1234_Array();
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

				throw new Exception("Exception occured in method cls_Get_ActiveShippmentForDoctorID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5OD_GASFD_1234_Array : FR_Base
	{
		public L5OD_GASFD_1234[] Result	{ get; set; } 
		public FR_L5OD_GASFD_1234_Array() : base() {}

		public FR_L5OD_GASFD_1234_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5OS_GASFD_1234 for attribute P_L5OS_GASFD_1234
		[DataContract]
		public class P_L5OS_GASFD_1234 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_DoctorID { get; set; } 
			[DataMember]
			public DateTime FormDate { get; set; } 
			[DataMember]
			public DateTime ToDate { get; set; } 

		}
		#endregion
		#region SClass L5OD_GASFD_1234 for attribute L5OD_GASFD_1234
		[DataContract]
		public class L5OD_GASFD_1234 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_ShippingPosition_BarcodeLabelID { get; set; } 
			[DataMember]
			public Guid LOG_SHP_Shipment_PositionID { get; set; } 
			[DataMember]
			public Guid LOG_SHP_Shipment_HeaderID { get; set; } 
			[DataMember]
			public String ShippingPosition_BarcodeLabel { get; set; } 
			[DataMember]
			public DateTime Header_Creation_Timestamp { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public bool R_IsSubmission_Complete { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5OD_GASFD_1234_Array cls_Get_ActiveShippmentForDoctorID(,P_L5OS_GASFD_1234 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5OD_GASFD_1234_Array invocationResult = cls_Get_ActiveShippmentForDoctorID.Invoke(connectionString,P_L5OS_GASFD_1234 Parameter,securityTicket);
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
var parameter = new CL5_OphthalShipments.Atomic.Retrieval.P_L5OS_GASFD_1234();
parameter.HEC_DoctorID = ...;
parameter.FormDate = ...;
parameter.ToDate = ...;

*/
