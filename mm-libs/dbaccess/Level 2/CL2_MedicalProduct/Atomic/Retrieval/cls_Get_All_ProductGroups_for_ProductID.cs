/* 
 * Generated on 3/4/2014 5:38:42 PM
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

namespace CL2_MedicalProduct.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_All_ProductGroups_for_ProductID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_All_ProductGroups_for_ProductID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_CL2_MP_GAPGfP_1735_Array Execute(DbConnection Connection,DbTransaction Transaction,P_CL2_MP_GAPGfP_1735 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_CL2_MP_GAPGfP_1735_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_MedicalProduct.Atomic.Retrieval.SQL.cls_Get_All_ProductGroups_for_ProductID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ProductID", Parameter.ProductID);



			List<CL2_MP_GAPGfP_1735> results = new List<CL2_MP_GAPGfP_1735>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_PRO_ProductGroupID","ProductGroup_Name_DictID","ProductGroup_Description_DictID","Parent_RefID","GlobalPropertyMatchingID" });
				while(reader.Read())
				{
					CL2_MP_GAPGfP_1735 resultItem = new CL2_MP_GAPGfP_1735();
					//0:Parameter CMN_PRO_ProductGroupID of type Guid
					resultItem.CMN_PRO_ProductGroupID = reader.GetGuid(0);
					//1:Parameter ProductGroup_Name of type Dict
					resultItem.ProductGroup_Name = reader.GetDictionary(1);
					resultItem.ProductGroup_Name.SourceTable = "cmn_pro_productgroups";
					loader.Append(resultItem.ProductGroup_Name);
					//2:Parameter ProductGroup_Description of type Dict
					resultItem.ProductGroup_Description = reader.GetDictionary(2);
					resultItem.ProductGroup_Description.SourceTable = "cmn_pro_productgroups";
					loader.Append(resultItem.ProductGroup_Description);
					//3:Parameter Parent_RefID of type Guid
					resultItem.Parent_RefID = reader.GetGuid(3);
					//4:Parameter GlobalPropertyMatchingID of type String
					resultItem.GlobalPropertyMatchingID = reader.GetString(4);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_All_ProductGroups_for_ProductID",ex);
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
		public static FR_CL2_MP_GAPGfP_1735_Array Invoke(string ConnectionString,P_CL2_MP_GAPGfP_1735 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_CL2_MP_GAPGfP_1735_Array Invoke(DbConnection Connection,P_CL2_MP_GAPGfP_1735 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_CL2_MP_GAPGfP_1735_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_CL2_MP_GAPGfP_1735 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_CL2_MP_GAPGfP_1735_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_CL2_MP_GAPGfP_1735 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_CL2_MP_GAPGfP_1735_Array functionReturn = new FR_CL2_MP_GAPGfP_1735_Array();
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

				throw new Exception("Exception occured in method cls_Get_All_ProductGroups_for_ProductID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_CL2_MP_GAPGfP_1735_Array : FR_Base
	{
		public CL2_MP_GAPGfP_1735[] Result	{ get; set; } 
		public FR_CL2_MP_GAPGfP_1735_Array() : base() {}

		public FR_CL2_MP_GAPGfP_1735_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_CL2_MP_GAPGfP_1735 for attribute P_CL2_MP_GAPGfP_1735
		[DataContract]
		public class P_CL2_MP_GAPGfP_1735 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProductID { get; set; } 

		}
		#endregion
		#region SClass CL2_MP_GAPGfP_1735 for attribute CL2_MP_GAPGfP_1735
		[DataContract]
		public class CL2_MP_GAPGfP_1735 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_ProductGroupID { get; set; } 
			[DataMember]
			public Dict ProductGroup_Name { get; set; } 
			[DataMember]
			public Dict ProductGroup_Description { get; set; } 
			[DataMember]
			public Guid Parent_RefID { get; set; } 
			[DataMember]
			public String GlobalPropertyMatchingID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CL2_MP_GAPGfP_1735_Array cls_Get_All_ProductGroups_for_ProductID(,P_CL2_MP_GAPGfP_1735 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CL2_MP_GAPGfP_1735_Array invocationResult = cls_Get_All_ProductGroups_for_ProductID.Invoke(connectionString,P_CL2_MP_GAPGfP_1735 Parameter,securityTicket);
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
var parameter = new CL2_MedicalProduct.Atomic.Retrieval.P_CL2_MP_GAPGfP_1735();
parameter.ProductID = ...;

*/
