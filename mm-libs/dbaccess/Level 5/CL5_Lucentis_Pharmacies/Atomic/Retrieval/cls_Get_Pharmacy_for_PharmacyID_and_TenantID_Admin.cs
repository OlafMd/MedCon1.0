/* 
 * Generated on 8/22/2013 4:36:25 PM
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

namespace CL5_Lucentis_Pharmacies.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Pharmacy_for_PharmacyID_and_TenantID_Admin.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Pharmacy_for_PharmacyID_and_TenantID_Admin
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5PH_GPfPIDaTIDA_1108 Execute(DbConnection Connection,DbTransaction Transaction,P_L5PH_GPfPIDaTIDA_1108 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5PH_GPfPIDaTIDA_1108();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Lucentis_Pharmacies.Atomic.Retrieval.SQL.cls_Get_Pharmacy_for_PharmacyID_and_TenantID_Admin.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PharmacyID", Parameter.PharmacyID);



			List<L5PH_GPfPIDaTIDA_1108> results = new List<L5PH_GPfPIDaTIDA_1108>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "PharmacyStreetName","PharmacyStreetNumber","ZIP","Town","PharmacyEmail","PharmacyStreet2","HEC_PharmacyID","DisplayName","ContactTypePhoneID","ContactTypePhoneNumber","ContactTypeFirstName","ContactTypeLastName","CMN_PER_PersonInfoID","ContactTypeEmail" });
				while(reader.Read())
				{
					L5PH_GPfPIDaTIDA_1108 resultItem = new L5PH_GPfPIDaTIDA_1108();
					//0:Parameter PharmacyStreetName of type String
					resultItem.PharmacyStreetName = reader.GetString(0);
					//1:Parameter PharmacyStreetNumber of type String
					resultItem.PharmacyStreetNumber = reader.GetString(1);
					//2:Parameter ZIP of type String
					resultItem.ZIP = reader.GetString(2);
					//3:Parameter Town of type String
					resultItem.Town = reader.GetString(3);
					//4:Parameter PharmacyEmail of type String
					resultItem.PharmacyEmail = reader.GetString(4);
					//5:Parameter PharmacyStreet2 of type String
					resultItem.PharmacyStreet2 = reader.GetString(5);
					//6:Parameter HEC_PharmacyID of type Guid
					resultItem.HEC_PharmacyID = reader.GetGuid(6);
					//7:Parameter DisplayName of type String
					resultItem.DisplayName = reader.GetString(7);
					//8:Parameter ContactTypePhoneID of type Guid
					resultItem.ContactTypePhoneID = reader.GetGuid(8);
					//9:Parameter ContactTypePhoneNumber of type String
					resultItem.ContactTypePhoneNumber = reader.GetString(9);
					//10:Parameter ContactTypeFirstName of type String
					resultItem.ContactTypeFirstName = reader.GetString(10);
					//11:Parameter ContactTypeLastName of type String
					resultItem.ContactTypeLastName = reader.GetString(11);
					//12:Parameter CMN_PER_PersonInfoID of type Guid
					resultItem.CMN_PER_PersonInfoID = reader.GetGuid(12);
					//13:Parameter ContactTypeEmail of type String
					resultItem.ContactTypeEmail = reader.GetString(13);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Pharmacy_for_PharmacyID_and_TenantID_Admin",ex);
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
		public static FR_L5PH_GPfPIDaTIDA_1108 Invoke(string ConnectionString,P_L5PH_GPfPIDaTIDA_1108 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5PH_GPfPIDaTIDA_1108 Invoke(DbConnection Connection,P_L5PH_GPfPIDaTIDA_1108 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5PH_GPfPIDaTIDA_1108 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PH_GPfPIDaTIDA_1108 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5PH_GPfPIDaTIDA_1108 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PH_GPfPIDaTIDA_1108 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5PH_GPfPIDaTIDA_1108 functionReturn = new FR_L5PH_GPfPIDaTIDA_1108();
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

				throw new Exception("Exception occured in method cls_Get_Pharmacy_for_PharmacyID_and_TenantID_Admin",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5PH_GPfPIDaTIDA_1108 : FR_Base
	{
		public L5PH_GPfPIDaTIDA_1108 Result	{ get; set; }

		public FR_L5PH_GPfPIDaTIDA_1108() : base() {}

		public FR_L5PH_GPfPIDaTIDA_1108(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5PH_GPfPIDaTIDA_1108 for attribute P_L5PH_GPfPIDaTIDA_1108
		[DataContract]
		public class P_L5PH_GPfPIDaTIDA_1108 
		{
			//Standard type parameters
			[DataMember]
			public Guid PharmacyID { get; set; } 

		}
		#endregion
		#region SClass L5PH_GPfPIDaTIDA_1108 for attribute L5PH_GPfPIDaTIDA_1108
		[DataContract]
		public class L5PH_GPfPIDaTIDA_1108 
		{
			//Standard type parameters
			[DataMember]
			public String PharmacyStreetName { get; set; } 
			[DataMember]
			public String PharmacyStreetNumber { get; set; } 
			[DataMember]
			public String ZIP { get; set; } 
			[DataMember]
			public String Town { get; set; } 
			[DataMember]
			public String PharmacyEmail { get; set; } 
			[DataMember]
			public String PharmacyStreet2 { get; set; } 
			[DataMember]
			public Guid HEC_PharmacyID { get; set; } 
			[DataMember]
			public String DisplayName { get; set; } 
			[DataMember]
			public Guid ContactTypePhoneID { get; set; } 
			[DataMember]
			public String ContactTypePhoneNumber { get; set; } 
			[DataMember]
			public String ContactTypeFirstName { get; set; } 
			[DataMember]
			public String ContactTypeLastName { get; set; } 
			[DataMember]
			public Guid CMN_PER_PersonInfoID { get; set; } 
			[DataMember]
			public String ContactTypeEmail { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5PH_GPfPIDaTIDA_1108 cls_Get_Pharmacy_for_PharmacyID_and_TenantID_Admin(,P_L5PH_GPfPIDaTIDA_1108 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5PH_GPfPIDaTIDA_1108 invocationResult = cls_Get_Pharmacy_for_PharmacyID_and_TenantID_Admin.Invoke(connectionString,P_L5PH_GPfPIDaTIDA_1108 Parameter,securityTicket);
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
var parameter = new CL5_Lucentis_Pharmacies.Atomic.Retrieval.P_L5PH_GPfPIDaTIDA_1108();
parameter.PharmacyID = ...;

*/
