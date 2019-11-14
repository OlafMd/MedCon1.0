/* 
 * Generated on 4/15/2014 9:48:19 AM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 * Required Assemblies:
 * System.Runtime.Serialization
 * CSV2Core
 * CSV2Core_MySQL
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Runtime.Serialization;

namespace CL2_OrganizationalUnit.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_AllOrganizationalUnits_for_CustomerID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AllOrganizationalUnits_for_CustomerID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2OU_GAOUfC_1159_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L2OU_GAOUfC_1159 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2OU_GAOUfC_1159_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_OrganizationalUnit.Atomic.Retrieval.SQL.cls_Get_AllOrganizationalUnits_for_CustomerID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CustomerID", Parameter.CustomerID);



			List<L2OU_GAOUfC_1159> results = new List<L2OU_GAOUfC_1159>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_BPT_CTM_OrganizationalUnitID","CustomerTenant_OfficeITL","Parent_OrganizationalUnit_RefID","OrganizationalUnit_SimpleName","OrganizationalUnit_Name_DictID","OrganizationalUnit_Description_DictID","InternalOrganizationalUnitNumber","InternalOrganizationalUnitSimpleName","ExternalOrganizationalUnitNumber","Default_PhoneNumber","Default_FaxNumber" });
				while(reader.Read())
				{
					L2OU_GAOUfC_1159 resultItem = new L2OU_GAOUfC_1159();
					//0:Parameter CMN_BPT_CTM_OrganizationalUnitID of type Guid
					resultItem.CMN_BPT_CTM_OrganizationalUnitID = reader.GetGuid(0);
					//1:Parameter CustomerTenant_OfficeITL of type String
					resultItem.CustomerTenant_OfficeITL = reader.GetString(1);
					//2:Parameter Parent_OrganizationalUnit_RefID of type Guid
					resultItem.Parent_OrganizationalUnit_RefID = reader.GetGuid(2);
					//3:Parameter OrganizationalUnit_SimpleName of type String
					resultItem.OrganizationalUnit_SimpleName = reader.GetString(3);
					//4:Parameter OrganizationalUnit_Name of type Dict
					resultItem.OrganizationalUnit_Name = reader.GetDictionary(4);
					resultItem.OrganizationalUnit_Name.SourceTable = "cmn_bpt_ctm_organizationalunits";
					loader.Append(resultItem.OrganizationalUnit_Name);
					//5:Parameter OrganizationalUnit_Description of type Dict
					resultItem.OrganizationalUnit_Description = reader.GetDictionary(5);
					resultItem.OrganizationalUnit_Description.SourceTable = "cmn_bpt_ctm_organizationalunits";
					loader.Append(resultItem.OrganizationalUnit_Description);
					//6:Parameter InternalOrganizationalUnitNumber of type String
					resultItem.InternalOrganizationalUnitNumber = reader.GetString(6);
					//7:Parameter InternalOrganizationalUnitSimpleName of type String
					resultItem.InternalOrganizationalUnitSimpleName = reader.GetString(7);
					//8:Parameter ExternalOrganizationalUnitNumber of type String
					resultItem.ExternalOrganizationalUnitNumber = reader.GetString(8);
					//9:Parameter Default_PhoneNumber of type String
					resultItem.Default_PhoneNumber = reader.GetString(9);
					//10:Parameter Default_FaxNumber of type String
					resultItem.Default_FaxNumber = reader.GetString(10);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_AllOrganizationalUnits_for_CustomerID",ex);
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
		public static FR_L2OU_GAOUfC_1159_Array Invoke(string ConnectionString,P_L2OU_GAOUfC_1159 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2OU_GAOUfC_1159_Array Invoke(DbConnection Connection,P_L2OU_GAOUfC_1159 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2OU_GAOUfC_1159_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L2OU_GAOUfC_1159 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2OU_GAOUfC_1159_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2OU_GAOUfC_1159 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2OU_GAOUfC_1159_Array functionReturn = new FR_L2OU_GAOUfC_1159_Array();
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

				throw new Exception("Exception occured in method cls_Get_AllOrganizationalUnits_for_CustomerID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2OU_GAOUfC_1159_Array : FR_Base
	{
		public L2OU_GAOUfC_1159[] Result	{ get; set; } 
		public FR_L2OU_GAOUfC_1159_Array() : base() {}

		public FR_L2OU_GAOUfC_1159_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L2OU_GAOUfC_1159 for attribute P_L2OU_GAOUfC_1159
		[DataContract]
		public class P_L2OU_GAOUfC_1159 
		{
			//Standard type parameters
			[DataMember]
			public Guid CustomerID { get; set; } 

		}
		#endregion
		#region SClass L2OU_GAOUfC_1159 for attribute L2OU_GAOUfC_1159
		[DataContract]
		public class L2OU_GAOUfC_1159 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_BPT_CTM_OrganizationalUnitID { get; set; } 
			[DataMember]
			public String CustomerTenant_OfficeITL { get; set; } 
			[DataMember]
			public Guid Parent_OrganizationalUnit_RefID { get; set; } 
			[DataMember]
			public String OrganizationalUnit_SimpleName { get; set; } 
			[DataMember]
			public Dict OrganizationalUnit_Name { get; set; } 
			[DataMember]
			public Dict OrganizationalUnit_Description { get; set; } 
			[DataMember]
			public String InternalOrganizationalUnitNumber { get; set; } 
			[DataMember]
			public String InternalOrganizationalUnitSimpleName { get; set; } 
			[DataMember]
			public String ExternalOrganizationalUnitNumber { get; set; } 
			[DataMember]
			public String Default_PhoneNumber { get; set; } 
			[DataMember]
			public String Default_FaxNumber { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2OU_GAOUfC_1159_Array cls_Get_AllOrganizationalUnits_for_CustomerID(,P_L2OU_GAOUfC_1159 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2OU_GAOUfC_1159_Array invocationResult = cls_Get_AllOrganizationalUnits_for_CustomerID.Invoke(connectionString,P_L2OU_GAOUfC_1159 Parameter,securityTicket);
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
var parameter = new CL2_OrganizationalUnit.Atomic.Retrieval.P_L2OU_GAOUfC_1159();
parameter.CustomerID = ...;

*/
