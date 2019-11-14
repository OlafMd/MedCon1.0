/* 
 * Generated on 9/3/2013 11:11:49 AM
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

namespace CL5_OphthalProduct.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Products_for_DoctorID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Products_for_DoctorID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3PR_GPfD_1702_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3PR_GPfD_1702 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3PR_GPfD_1702_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_OphthalProduct.Atomic.Retrieval.SQL.cls_Get_Products_for_DoctorID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"DoctorID", Parameter.DoctorID);



			List<L3PR_GPfD_1702> results = new List<L3PR_GPfD_1702>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "Product_Name_DictID","Product_Number","Tenant_RefID","Creation_Timestamp","Product_Description_DictID","CMN_PRO_ProductID","HEC_Doctor_RequiredProductID" });
				while(reader.Read())
				{
					L3PR_GPfD_1702 resultItem = new L3PR_GPfD_1702();
					//0:Parameter Product_Name of type Dict
					resultItem.Product_Name = reader.GetDictionary(0);
					resultItem.Product_Name.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Product_Name);
					//1:Parameter Product_Number of type String
					resultItem.Product_Number = reader.GetString(1);
					//2:Parameter Tenant_RefID of type Guid
					resultItem.Tenant_RefID = reader.GetGuid(2);
					//3:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(3);
					//4:Parameter Product_Description of type Dict
					resultItem.Product_Description = reader.GetDictionary(4);
					resultItem.Product_Description.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Product_Description);
					//5:Parameter CMN_PRO_ProductID of type Guid
					resultItem.CMN_PRO_ProductID = reader.GetGuid(5);
					//6:Parameter HEC_Doctor_RequiredProductID of type Guid
					resultItem.HEC_Doctor_RequiredProductID = reader.GetGuid(6);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Products_for_DoctorID",ex);
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
		public static FR_L3PR_GPfD_1702_Array Invoke(string ConnectionString,P_L3PR_GPfD_1702 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3PR_GPfD_1702_Array Invoke(DbConnection Connection,P_L3PR_GPfD_1702 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3PR_GPfD_1702_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3PR_GPfD_1702 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3PR_GPfD_1702_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3PR_GPfD_1702 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3PR_GPfD_1702_Array functionReturn = new FR_L3PR_GPfD_1702_Array();
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

				throw new Exception("Exception occured in method cls_Get_Products_for_DoctorID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3PR_GPfD_1702_Array : FR_Base
	{
		public L3PR_GPfD_1702[] Result	{ get; set; } 
		public FR_L3PR_GPfD_1702_Array() : base() {}

		public FR_L3PR_GPfD_1702_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3PR_GPfD_1702 for attribute P_L3PR_GPfD_1702
		[DataContract]
		public class P_L3PR_GPfD_1702 
		{
			//Standard type parameters
			[DataMember]
			public Guid DoctorID { get; set; } 

		}
		#endregion
		#region SClass L3PR_GPfD_1702 for attribute L3PR_GPfD_1702
		[DataContract]
		public class L3PR_GPfD_1702 
		{
			//Standard type parameters
			[DataMember]
			public Dict Product_Name { get; set; } 
			[DataMember]
			public String Product_Number { get; set; } 
			[DataMember]
			public Guid Tenant_RefID { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public Dict Product_Description { get; set; } 
			[DataMember]
			public Guid CMN_PRO_ProductID { get; set; } 
			[DataMember]
			public Guid HEC_Doctor_RequiredProductID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3PR_GPfD_1702_Array cls_Get_Products_for_DoctorID(,P_L3PR_GPfD_1702 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3PR_GPfD_1702_Array invocationResult = cls_Get_Products_for_DoctorID.Invoke(connectionString,P_L3PR_GPfD_1702 Parameter,securityTicket);
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
var parameter = new CL5_OphthalProduct.Atomic.Retrieval.P_L3PR_GPfD_1702();
parameter.DoctorID = ...;

*/
