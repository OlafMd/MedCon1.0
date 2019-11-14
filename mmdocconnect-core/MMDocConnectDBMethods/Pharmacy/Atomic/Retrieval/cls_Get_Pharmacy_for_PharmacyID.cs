/* 
 * Generated on 2/2/2017 3:40:35 PM
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

namespace MMDocConnectDBMethods.Pharmacy.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Pharmacy_for_PharmacyID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Pharmacy_for_PharmacyID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_PH_GPfPID_1535 Execute(DbConnection Connection,DbTransaction Transaction,P_PH_GPfPID_1535 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_PH_GPfPID_1535();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.Pharmacy.Atomic.Retrieval.SQL.cls_Get_Pharmacy_for_PharmacyID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PharmacyID", Parameter.PharmacyID);



			List<PH_GPfPID_1535> results = new List<PH_GPfPID_1535>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "PharmacyID","PharmacyName","Contact_Email","Contact_Telephone","Contact_Fax","Street_Name","Street_Number","ZIP","Town","PharmacyType","ContactPersonName","CompanyBPID" });
				while(reader.Read())
				{
					PH_GPfPID_1535 resultItem = new PH_GPfPID_1535();
					//0:Parameter PharmacyID of type Guid
					resultItem.PharmacyID = reader.GetGuid(0);
					//1:Parameter PharmacyName of type string
					resultItem.PharmacyName = reader.GetString(1);
					//2:Parameter Contact_Email of type string
					resultItem.Contact_Email = reader.GetString(2);
					//3:Parameter Contact_Telephone of type string
					resultItem.Contact_Telephone = reader.GetString(3);
					//4:Parameter Contact_Fax of type string
					resultItem.Contact_Fax = reader.GetString(4);
					//5:Parameter Street_Name of type string
					resultItem.Street_Name = reader.GetString(5);
					//6:Parameter Street_Number of type string
					resultItem.Street_Number = reader.GetString(6);
					//7:Parameter ZIP of type string
					resultItem.ZIP = reader.GetString(7);
					//8:Parameter Town of type string
					resultItem.Town = reader.GetString(8);
					//9:Parameter PharmacyType of type string
					resultItem.PharmacyType = reader.GetString(9);
					//10:Parameter ContactPersonName of type string
					resultItem.ContactPersonName = reader.GetString(10);
					//11:Parameter CompanyBPID of type Guid
					resultItem.CompanyBPID = reader.GetGuid(11);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Pharmacy_for_PharmacyID",ex);
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
		public static FR_PH_GPfPID_1535 Invoke(string ConnectionString,P_PH_GPfPID_1535 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_PH_GPfPID_1535 Invoke(DbConnection Connection,P_PH_GPfPID_1535 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_PH_GPfPID_1535 Invoke(DbConnection Connection, DbTransaction Transaction,P_PH_GPfPID_1535 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_PH_GPfPID_1535 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_PH_GPfPID_1535 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_PH_GPfPID_1535 functionReturn = new FR_PH_GPfPID_1535();
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

				throw new Exception("Exception occured in method cls_Get_Pharmacy_for_PharmacyID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_PH_GPfPID_1535 : FR_Base
	{
		public PH_GPfPID_1535 Result	{ get; set; }

		public FR_PH_GPfPID_1535() : base() {}

		public FR_PH_GPfPID_1535(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_PH_GPfPID_1535 for attribute P_PH_GPfPID_1535
		[DataContract]
		public class P_PH_GPfPID_1535 
		{
			//Standard type parameters
			[DataMember]
			public Guid PharmacyID { get; set; } 

		}
		#endregion
		#region SClass PH_GPfPID_1535 for attribute PH_GPfPID_1535
		[DataContract]
		public class PH_GPfPID_1535 
		{
			//Standard type parameters
			[DataMember]
			public Guid PharmacyID { get; set; } 
			[DataMember]
			public string PharmacyName { get; set; } 
			[DataMember]
			public string Contact_Email { get; set; } 
			[DataMember]
			public string Contact_Telephone { get; set; } 
			[DataMember]
			public string Contact_Fax { get; set; } 
			[DataMember]
			public string Street_Name { get; set; } 
			[DataMember]
			public string Street_Number { get; set; } 
			[DataMember]
			public string ZIP { get; set; } 
			[DataMember]
			public string Town { get; set; } 
			[DataMember]
			public string PharmacyType { get; set; } 
			[DataMember]
			public string ContactPersonName { get; set; } 
			[DataMember]
			public Guid CompanyBPID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_PH_GPfPID_1535 cls_Get_Pharmacy_for_PharmacyID(,P_PH_GPfPID_1535 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_PH_GPfPID_1535 invocationResult = cls_Get_Pharmacy_for_PharmacyID.Invoke(connectionString,P_PH_GPfPID_1535 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Pharmacy.Atomic.Retrieval.P_PH_GPfPID_1535();
parameter.PharmacyID = ...;

*/
