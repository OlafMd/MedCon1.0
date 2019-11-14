/* 
 * Generated on 18/11/2014 05:52:37
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

namespace CL3_Dimension.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_DimensionNameAndValue_for_ProductVariantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_DimensionNameAndValue_for_ProductVariantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3DM_GDNAVfPV_1751_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3DM_GDNAVfPV_1751 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3DM_GDNAVfPV_1751_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_Dimension.Atomic.Retrieval.SQL.cls_Get_DimensionNameAndValue_for_ProductVariantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ProductVariantID", Parameter.ProductVariantID);



			List<L3DM_GDNAVfPV_1751> results = new List<L3DM_GDNAVfPV_1751>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "DimensionValue_Text_DictID","DimensionName_DictID" });
				while(reader.Read())
				{
					L3DM_GDNAVfPV_1751 resultItem = new L3DM_GDNAVfPV_1751();
					//0:Parameter DimensionValue_Text of type Dict
					resultItem.DimensionValue_Text = reader.GetDictionary(0);
					resultItem.DimensionValue_Text.SourceTable = "CMN_PRO_Dimension_Values";
					loader.Append(resultItem.DimensionValue_Text);
					//1:Parameter DimensionName of type Dict
					resultItem.DimensionName = reader.GetDictionary(1);
					resultItem.DimensionName.SourceTable = "CMN_PRO_Dimensions";
					loader.Append(resultItem.DimensionName);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_DimensionNameAndValue_for_ProductVariantID",ex);
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
		public static FR_L3DM_GDNAVfPV_1751_Array Invoke(string ConnectionString,P_L3DM_GDNAVfPV_1751 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3DM_GDNAVfPV_1751_Array Invoke(DbConnection Connection,P_L3DM_GDNAVfPV_1751 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3DM_GDNAVfPV_1751_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3DM_GDNAVfPV_1751 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3DM_GDNAVfPV_1751_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3DM_GDNAVfPV_1751 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3DM_GDNAVfPV_1751_Array functionReturn = new FR_L3DM_GDNAVfPV_1751_Array();
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

				throw new Exception("Exception occured in method cls_Get_DimensionNameAndValue_for_ProductVariantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3DM_GDNAVfPV_1751_Array : FR_Base
	{
		public L3DM_GDNAVfPV_1751[] Result	{ get; set; } 
		public FR_L3DM_GDNAVfPV_1751_Array() : base() {}

		public FR_L3DM_GDNAVfPV_1751_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3DM_GDNAVfPV_1751 for attribute P_L3DM_GDNAVfPV_1751
		[DataContract]
		public class P_L3DM_GDNAVfPV_1751 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProductVariantID { get; set; } 

		}
		#endregion
		#region SClass L3DM_GDNAVfPV_1751 for attribute L3DM_GDNAVfPV_1751
		[DataContract]
		public class L3DM_GDNAVfPV_1751 
		{
			//Standard type parameters
			[DataMember]
			public Dict DimensionValue_Text { get; set; } 
			[DataMember]
			public Dict DimensionName { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3DM_GDNAVfPV_1751_Array cls_Get_DimensionNameAndValue_for_ProductVariantID(,P_L3DM_GDNAVfPV_1751 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3DM_GDNAVfPV_1751_Array invocationResult = cls_Get_DimensionNameAndValue_for_ProductVariantID.Invoke(connectionString,P_L3DM_GDNAVfPV_1751 Parameter,securityTicket);
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
var parameter = new CL3_Dimension.Atomic.Retrieval.P_L3DM_GDNAVfPV_1751();
parameter.ProductVariantID = ...;

*/
