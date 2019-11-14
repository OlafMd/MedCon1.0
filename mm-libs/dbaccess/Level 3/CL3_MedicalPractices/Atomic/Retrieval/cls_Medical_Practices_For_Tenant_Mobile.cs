/* 
 * Generated on 11/4/2014 3:43:01 PM
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
    /// var result = cls_Medical_Practices_For_Tenant_Mobile.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Medical_Practices_For_Tenant_Mobile
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3MP_MPfTM_1448_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3_MPfTM_1448 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3MP_MPfTM_1448_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_MedicalPractices.Atomic.Retrieval.SQL.cls_Medical_Practices_For_Tenant_Mobile.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"Tenant", Parameter.Tenant);



			List<L3MP_MPfTM_1448> results = new List<L3MP_MPfTM_1448>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "OrganizationalUnit_Name_DictID","Default_PhoneNumber","ContactFirstname","ContactLastname","Street_Name","Street_Number","Town","HEC_MedicalPractiseID","IsDeleted","Modification_Timestamp","Modification_Timestamp1","Modification_Timestamp2","Modification_Timestamp3","Modification_Timestamp4","Modification_Timestamp5","Tenant_RefID","Creation_Timestamp","IsHospital" });
				while(reader.Read())
				{
					L3MP_MPfTM_1448 resultItem = new L3MP_MPfTM_1448();
					//0:Parameter OrganizationalUnit_Name of type Dict
					resultItem.OrganizationalUnit_Name = reader.GetDictionary(0);
					resultItem.OrganizationalUnit_Name.SourceTable = "cmn_bpt_ctm_organizationalunits";
					loader.Append(resultItem.OrganizationalUnit_Name);
					//1:Parameter Default_PhoneNumber of type String
					resultItem.Default_PhoneNumber = reader.GetString(1);
					//2:Parameter ContactFirstname of type String
					resultItem.ContactFirstname = reader.GetString(2);
					//3:Parameter ContactLastname of type String
					resultItem.ContactLastname = reader.GetString(3);
					//4:Parameter Street_Name of type String
					resultItem.Street_Name = reader.GetString(4);
					//5:Parameter Street_Number of type String
					resultItem.Street_Number = reader.GetString(5);
					//6:Parameter Town of type String
					resultItem.Town = reader.GetString(6);
					//7:Parameter HEC_MedicalPractiseID of type Guid
					resultItem.HEC_MedicalPractiseID = reader.GetGuid(7);
					//8:Parameter IsDeleted of type bool
					resultItem.IsDeleted = reader.GetBoolean(8);
					//9:Parameter Modification_Timestamp of type DateTime
					resultItem.Modification_Timestamp = reader.GetDate(9);
					//10:Parameter Modification_Timestamp1 of type DateTime
					resultItem.Modification_Timestamp1 = reader.GetDate(10);
					//11:Parameter Modification_Timestamp2 of type DateTime
					resultItem.Modification_Timestamp2 = reader.GetDate(11);
					//12:Parameter Modification_Timestamp3 of type DateTime
					resultItem.Modification_Timestamp3 = reader.GetDate(12);
					//13:Parameter Modification_Timestamp4 of type DateTime
					resultItem.Modification_Timestamp4 = reader.GetDate(13);
					//14:Parameter Modification_Timestamp5 of type DateTime
					resultItem.Modification_Timestamp5 = reader.GetDate(14);
					//15:Parameter Tenant_RefID of type Guid
					resultItem.Tenant_RefID = reader.GetGuid(15);
					//16:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(16);
					//17:Parameter IsHospital of type bool
					resultItem.IsHospital = reader.GetBoolean(17);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Medical_Practices_For_Tenant_Mobile",ex);
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
		public static FR_L3MP_MPfTM_1448_Array Invoke(string ConnectionString,P_L3_MPfTM_1448 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3MP_MPfTM_1448_Array Invoke(DbConnection Connection,P_L3_MPfTM_1448 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3MP_MPfTM_1448_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3_MPfTM_1448 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3MP_MPfTM_1448_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3_MPfTM_1448 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3MP_MPfTM_1448_Array functionReturn = new FR_L3MP_MPfTM_1448_Array();
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

				throw new Exception("Exception occured in method cls_Medical_Practices_For_Tenant_Mobile",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3MP_MPfTM_1448_Array : FR_Base
	{
		public L3MP_MPfTM_1448[] Result	{ get; set; } 
		public FR_L3MP_MPfTM_1448_Array() : base() {}

		public FR_L3MP_MPfTM_1448_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3_MPfTM_1448 for attribute P_L3_MPfTM_1448
		[DataContract]
		public class P_L3_MPfTM_1448 
		{
			//Standard type parameters
			[DataMember]
			public Guid Tenant { get; set; } 

		}
		#endregion
		#region SClass L3MP_MPfTM_1448 for attribute L3MP_MPfTM_1448
		[DataContract]
		public class L3MP_MPfTM_1448 
		{
			//Standard type parameters
			[DataMember]
			public Dict OrganizationalUnit_Name { get; set; } 
			[DataMember]
			public String Default_PhoneNumber { get; set; } 
			[DataMember]
			public String ContactFirstname { get; set; } 
			[DataMember]
			public String ContactLastname { get; set; } 
			[DataMember]
			public String Street_Name { get; set; } 
			[DataMember]
			public String Street_Number { get; set; } 
			[DataMember]
			public String Town { get; set; } 
			[DataMember]
			public Guid HEC_MedicalPractiseID { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 
			[DataMember]
			public DateTime Modification_Timestamp { get; set; } 
			[DataMember]
			public DateTime Modification_Timestamp1 { get; set; } 
			[DataMember]
			public DateTime Modification_Timestamp2 { get; set; } 
			[DataMember]
			public DateTime Modification_Timestamp3 { get; set; } 
			[DataMember]
			public DateTime Modification_Timestamp4 { get; set; } 
			[DataMember]
			public DateTime Modification_Timestamp5 { get; set; } 
			[DataMember]
			public Guid Tenant_RefID { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public bool IsHospital { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3MP_MPfTM_1448_Array cls_Medical_Practices_For_Tenant_Mobile(,P_L3_MPfTM_1448 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3MP_MPfTM_1448_Array invocationResult = cls_Medical_Practices_For_Tenant_Mobile.Invoke(connectionString,P_L3_MPfTM_1448 Parameter,securityTicket);
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
var parameter = new CL3_MedicalPractices.Atomic.Retrieval.P_L3_MPfTM_1448();
parameter.Tenant = ...;

*/
