/* 
 * Generated on 8/31/2013 1:51:23 PM
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

namespace CL3_MedicalPractices.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_CooperatingPractices_For_PracticeBussinessID_and_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_CooperatingPractices_For_PracticeBussinessID_and_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3MP_GCPfPBITID_1228_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3MP_GCPfPBITID_1228 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3MP_GCPfPBITID_1228_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_MedicalPractices.Atomic.Retrieval.SQL.cls_Get_CooperatingPractices_For_PracticeBussinessID_and_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PracticeBussinessParticipant_RefID", Parameter.PracticeBussinessParticipant_RefID);



			List<L3MP_GCPfPBITID_1228> results = new List<L3MP_GCPfPBITID_1228>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_MedicalPractiseID","Practice_CMN_BPT_BusinessParticipantID","PracticeName","ContactPersonName","ContactTypePhoneID","ContactTypePhoneNumber","ContactTypeFirstName","ContactTypeLastName","ContactTypeEmail","BSNR" });
				while(reader.Read())
				{
					L3MP_GCPfPBITID_1228 resultItem = new L3MP_GCPfPBITID_1228();
					//0:Parameter HEC_MedicalPractiseID of type Guid
					resultItem.HEC_MedicalPractiseID = reader.GetGuid(0);
					//1:Parameter Practice_CMN_BPT_BusinessParticipantID of type Guid
					resultItem.Practice_CMN_BPT_BusinessParticipantID = reader.GetGuid(1);
					//2:Parameter PracticeName of type String
					resultItem.PracticeName = reader.GetString(2);
					//3:Parameter ContactPersonName of type String
					resultItem.ContactPersonName = reader.GetString(3);
					//4:Parameter ContactTypePhoneID of type Guid
					resultItem.ContactTypePhoneID = reader.GetGuid(4);
					//5:Parameter ContactTypePhoneNumber of type String
					resultItem.ContactTypePhoneNumber = reader.GetString(5);
					//6:Parameter ContactTypeFirstName of type String
					resultItem.ContactTypeFirstName = reader.GetString(6);
					//7:Parameter ContactTypeLastName of type String
					resultItem.ContactTypeLastName = reader.GetString(7);
					//8:Parameter ContactTypeEmail of type String
					resultItem.ContactTypeEmail = reader.GetString(8);
					//9:Parameter BSNR of type String
					resultItem.BSNR = reader.GetString(9);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_CooperatingPractices_For_PracticeBussinessID_and_TenantID",ex);
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
		public static FR_L3MP_GCPfPBITID_1228_Array Invoke(string ConnectionString,P_L3MP_GCPfPBITID_1228 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3MP_GCPfPBITID_1228_Array Invoke(DbConnection Connection,P_L3MP_GCPfPBITID_1228 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3MP_GCPfPBITID_1228_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3MP_GCPfPBITID_1228 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3MP_GCPfPBITID_1228_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3MP_GCPfPBITID_1228 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3MP_GCPfPBITID_1228_Array functionReturn = new FR_L3MP_GCPfPBITID_1228_Array();
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

				throw new Exception("Exception occured in method cls_Get_CooperatingPractices_For_PracticeBussinessID_and_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3MP_GCPfPBITID_1228_Array : FR_Base
	{
		public L3MP_GCPfPBITID_1228[] Result	{ get; set; } 
		public FR_L3MP_GCPfPBITID_1228_Array() : base() {}

		public FR_L3MP_GCPfPBITID_1228_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3MP_GCPfPBITID_1228 for attribute P_L3MP_GCPfPBITID_1228
		[DataContract]
		public class P_L3MP_GCPfPBITID_1228 
		{
			//Standard type parameters
			[DataMember]
			public Guid PracticeBussinessParticipant_RefID { get; set; } 

		}
		#endregion
		#region SClass L3MP_GCPfPBITID_1228 for attribute L3MP_GCPfPBITID_1228
		[DataContract]
		public class L3MP_GCPfPBITID_1228 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_MedicalPractiseID { get; set; } 
			[DataMember]
			public Guid Practice_CMN_BPT_BusinessParticipantID { get; set; } 
			[DataMember]
			public String PracticeName { get; set; } 
			[DataMember]
			public String ContactPersonName { get; set; } 
			[DataMember]
			public Guid ContactTypePhoneID { get; set; } 
			[DataMember]
			public String ContactTypePhoneNumber { get; set; } 
			[DataMember]
			public String ContactTypeFirstName { get; set; } 
			[DataMember]
			public String ContactTypeLastName { get; set; } 
			[DataMember]
			public String ContactTypeEmail { get; set; } 
			[DataMember]
			public String BSNR { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3MP_GCPfPBITID_1228_Array cls_Get_CooperatingPractices_For_PracticeBussinessID_and_TenantID(,P_L3MP_GCPfPBITID_1228 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = VerifySessionToken(sessionToken);
		FR_L3MP_GCPfPBITID_1228_Array invocationResult = cls_Get_CooperatingPractices_For_PracticeBussinessID_and_TenantID.Invoke(connectionString,P_L3MP_GCPfPBITID_1228 Parameter,securityTicket);
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
var parameter = new CL3_MedicalPractices.Atomic.Retrieval.P_L3MP_GCPfPBITID_1228();
parameter.PracticeBussinessParticipant_RefID = ...;

*/
