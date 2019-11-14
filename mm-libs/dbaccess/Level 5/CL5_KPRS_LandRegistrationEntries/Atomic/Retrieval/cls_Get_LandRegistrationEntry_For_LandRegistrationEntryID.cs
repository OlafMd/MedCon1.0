/* 
 * Generated on 7/8/2013 11:48:24 AM
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

namespace CL5_KPRS_LandRegistrationEntries.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_LandRegistrationEntry_For_LandRegistrationEntryID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_LandRegistrationEntry_For_LandRegistrationEntryID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5LR_GLREFLREID_1107 Execute(DbConnection Connection,DbTransaction Transaction,P_L5LR_GLREFLREID_1107 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5LR_GLREFLREID_1107();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_KPRS_LandRegistrationEntries.Atomic.Retrieval.SQL.cls_Get_LandRegistrationEntry_For_LandRegistrationEntryID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"LandRegistrationEntryID", Parameter.LandRegistrationEntryID);



			List<L5LR_GLREFLREID_1107> results = new List<L5LR_GLREFLREID_1107>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "RES_RealestateProperty_LandRegistrationEntryID","LandRegistrationEntry_LandTitleRegister","LandRegistrationEntry_Marking","LandRegistrationEntry_LandLot","LandRegistrationEntry_Parcel_FromNumber","LandRegistrationEntry_Parcel_ToNumber","LandRegistrationEntry_Sheet","LandRegistrationEntry_GroundAreaSize_in_sqm","RealestateProperty_RefID","Tenant_RefID","IsDeleted" });
				while(reader.Read())
				{
					L5LR_GLREFLREID_1107 resultItem = new L5LR_GLREFLREID_1107();
					//0:Parameter RES_RealestateProperty_LandRegistrationEntryID of type Guid
					resultItem.RES_RealestateProperty_LandRegistrationEntryID = reader.GetGuid(0);
					//1:Parameter LandRegistrationEntry_LandTitleRegister of type String
					resultItem.LandRegistrationEntry_LandTitleRegister = reader.GetString(1);
					//2:Parameter LandRegistrationEntry_Marking of type String
					resultItem.LandRegistrationEntry_Marking = reader.GetString(2);
					//3:Parameter LandRegistrationEntry_LandLot of type int
					resultItem.LandRegistrationEntry_LandLot = reader.GetInteger(3);
					//4:Parameter LandRegistrationEntry_Parcel_FromNumber of type int
					resultItem.LandRegistrationEntry_Parcel_FromNumber = reader.GetInteger(4);
					//5:Parameter LandRegistrationEntry_Parcel_ToNumber of type int
					resultItem.LandRegistrationEntry_Parcel_ToNumber = reader.GetInteger(5);
					//6:Parameter LandRegistrationEntry_Sheet of type int
					resultItem.LandRegistrationEntry_Sheet = reader.GetInteger(6);
					//7:Parameter LandRegistrationEntry_GroundAreaSize_in_sqm of type double
					resultItem.LandRegistrationEntry_GroundAreaSize_in_sqm = reader.GetDouble(7);
					//8:Parameter RealestateProperty_RefID of type Guid
					resultItem.RealestateProperty_RefID = reader.GetGuid(8);
					//9:Parameter Tenant_RefID of type Guid
					resultItem.Tenant_RefID = reader.GetGuid(9);
					//10:Parameter IsDeleted of type bool
					resultItem.IsDeleted = reader.GetBoolean(10);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_LandRegistrationEntry_For_LandRegistrationEntryID",ex);
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
		public static FR_L5LR_GLREFLREID_1107 Invoke(string ConnectionString,P_L5LR_GLREFLREID_1107 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5LR_GLREFLREID_1107 Invoke(DbConnection Connection,P_L5LR_GLREFLREID_1107 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5LR_GLREFLREID_1107 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5LR_GLREFLREID_1107 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5LR_GLREFLREID_1107 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5LR_GLREFLREID_1107 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5LR_GLREFLREID_1107 functionReturn = new FR_L5LR_GLREFLREID_1107();
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

				throw new Exception("Exception occured in method cls_Get_LandRegistrationEntry_For_LandRegistrationEntryID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5LR_GLREFLREID_1107 : FR_Base
	{
		public L5LR_GLREFLREID_1107 Result	{ get; set; }

		public FR_L5LR_GLREFLREID_1107() : base() {}

		public FR_L5LR_GLREFLREID_1107(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5LR_GLREFLREID_1107 for attribute P_L5LR_GLREFLREID_1107
		[DataContract]
		public class P_L5LR_GLREFLREID_1107 
		{
			//Standard type parameters
			[DataMember]
			public Guid LandRegistrationEntryID { get; set; } 

		}
		#endregion
		#region SClass L5LR_GLREFLREID_1107 for attribute L5LR_GLREFLREID_1107
		[DataContract]
		public class L5LR_GLREFLREID_1107 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_RealestateProperty_LandRegistrationEntryID { get; set; } 
			[DataMember]
			public String LandRegistrationEntry_LandTitleRegister { get; set; } 
			[DataMember]
			public String LandRegistrationEntry_Marking { get; set; } 
			[DataMember]
			public int LandRegistrationEntry_LandLot { get; set; } 
			[DataMember]
			public int LandRegistrationEntry_Parcel_FromNumber { get; set; } 
			[DataMember]
			public int LandRegistrationEntry_Parcel_ToNumber { get; set; } 
			[DataMember]
			public int LandRegistrationEntry_Sheet { get; set; } 
			[DataMember]
			public double LandRegistrationEntry_GroundAreaSize_in_sqm { get; set; } 
			[DataMember]
			public Guid RealestateProperty_RefID { get; set; } 
			[DataMember]
			public Guid Tenant_RefID { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5LR_GLREFLREID_1107 cls_Get_LandRegistrationEntry_For_LandRegistrationEntryID(,P_L5LR_GLREFLREID_1107 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5LR_GLREFLREID_1107 invocationResult = cls_Get_LandRegistrationEntry_For_LandRegistrationEntryID.Invoke(connectionString,P_L5LR_GLREFLREID_1107 Parameter,securityTicket);
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
var parameter = new CL5_KPRS_LandRegistrationEntries.Atomic.Retrieval.P_L5LR_GLREFLREID_1107();
parameter.LandRegistrationEntryID = ...;

*/