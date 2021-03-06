/* 
 * Generated on 8/30/2013 11:01:16 AM
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
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ShippmentPositionInfo_for_labelID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ShippmentPositionInfo_for_labelID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5OS_GSPIfLID_1253 Execute(DbConnection Connection,DbTransaction Transaction,P_L5OS_GSPIfLID_1253 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5OS_GSPIfLID_1253();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_OphthalShipments.Atomic.Retrieval.SQL.cls_Get_ShippmentPositionInfo_for_labelID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"LabelID", Parameter.LabelID);



			List<L5OS_GSPIfLID_1253> results = new List<L5OS_GSPIfLID_1253>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_ShippingPosition_BarcodeLabelID","FirstName","PrimaryEmail","LastName","Title","Salutation_Letter","Salutation_General","PracticeName","PracticeAddress","ShippingPosition_BarcodeLabel","R_IsSubmission_Complete" });
				while(reader.Read())
				{
					L5OS_GSPIfLID_1253 resultItem = new L5OS_GSPIfLID_1253();
					//0:Parameter HEC_ShippingPosition_BarcodeLabelID of type Guid
					resultItem.HEC_ShippingPosition_BarcodeLabelID = reader.GetGuid(0);
					//1:Parameter FirstName of type String
					resultItem.FirstName = reader.GetString(1);
					//2:Parameter PrimaryEmail of type String
					resultItem.PrimaryEmail = reader.GetString(2);
					//3:Parameter LastName of type String
					resultItem.LastName = reader.GetString(3);
					//4:Parameter Title of type String
					resultItem.Title = reader.GetString(4);
					//5:Parameter Salutation_Letter of type String
					resultItem.Salutation_Letter = reader.GetString(5);
					//6:Parameter Salutation_General of type String
					resultItem.Salutation_General = reader.GetString(6);
					//7:Parameter PracticeName of type String
					resultItem.PracticeName = reader.GetString(7);
					//8:Parameter PracticeAddress of type String
					resultItem.PracticeAddress = reader.GetString(8);
					//9:Parameter ShippingPosition_BarcodeLabel of type String
					resultItem.ShippingPosition_BarcodeLabel = reader.GetString(9);
					//10:Parameter R_IsSubmission_Complete of type bool
					resultItem.R_IsSubmission_Complete = reader.GetBoolean(10);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_ShippmentPositionInfo_for_labelID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = results.FirstOrDefault();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5OS_GSPIfLID_1253 Invoke(string ConnectionString,P_L5OS_GSPIfLID_1253 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5OS_GSPIfLID_1253 Invoke(DbConnection Connection,P_L5OS_GSPIfLID_1253 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5OS_GSPIfLID_1253 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5OS_GSPIfLID_1253 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5OS_GSPIfLID_1253 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5OS_GSPIfLID_1253 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5OS_GSPIfLID_1253 functionReturn = new FR_L5OS_GSPIfLID_1253();
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

				throw new Exception("Exception occured in method cls_Get_ShippmentPositionInfo_for_labelID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5OS_GSPIfLID_1253 : FR_Base
	{
		public L5OS_GSPIfLID_1253 Result	{ get; set; }

		public FR_L5OS_GSPIfLID_1253() : base() {}

		public FR_L5OS_GSPIfLID_1253(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5OS_GSPIfLID_1253 for attribute P_L5OS_GSPIfLID_1253
		[DataContract]
		public class P_L5OS_GSPIfLID_1253 
		{
			//Standard type parameters
			[DataMember]
			public Guid LabelID { get; set; } 

		}
		#endregion
		#region SClass L5OS_GSPIfLID_1253 for attribute L5OS_GSPIfLID_1253
		[DataContract]
		public class L5OS_GSPIfLID_1253 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_ShippingPosition_BarcodeLabelID { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String PrimaryEmail { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public String Title { get; set; } 
			[DataMember]
			public String Salutation_Letter { get; set; } 
			[DataMember]
			public String Salutation_General { get; set; } 
			[DataMember]
			public String PracticeName { get; set; } 
			[DataMember]
			public String PracticeAddress { get; set; } 
			[DataMember]
			public String ShippingPosition_BarcodeLabel { get; set; } 
			[DataMember]
			public bool R_IsSubmission_Complete { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5OS_GSPIfLID_1253 cls_Get_ShippmentPositionInfo_for_labelID(,P_L5OS_GSPIfLID_1253 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5OS_GSPIfLID_1253 invocationResult = cls_Get_ShippmentPositionInfo_for_labelID.Invoke(connectionString,P_L5OS_GSPIfLID_1253 Parameter,securityTicket);
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
var parameter = new CL5_OphthalShipments.Atomic.Retrieval.P_L5OS_GSPIfLID_1253();
parameter.LabelID = ...;

*/
