/* 
 * Generated on 2/2/2015 04:22:41
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

namespace CL5_Zugseil_Assortments.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_AssortmentVariants_for_ProductID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AssortmentVariants_for_ProductID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5AS_GAVfP_2216_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5AS_GAVfP_2216 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5AS_GAVfP_2216_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Zugseil_Assortments.Atomic.Retrieval.SQL.cls_Get_AssortmentVariants_for_ProductID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ProductID", Parameter.ProductID);



			List<L5AS_GAVfP_2216> results = new List<L5AS_GAVfP_2216>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_PRO_Product_VariantID","VariantName_DictID","CMN_PRO_ASS_AssortmentVariantID" });
				while(reader.Read())
				{
					L5AS_GAVfP_2216 resultItem = new L5AS_GAVfP_2216();
					//0:Parameter CMN_PRO_Product_VariantID of type Guid
					resultItem.CMN_PRO_Product_VariantID = reader.GetGuid(0);
					//1:Parameter VariantName_DictID of type Dict
					resultItem.VariantName_DictID = reader.GetDictionary(1);
					resultItem.VariantName_DictID.SourceTable = "cmn_pro_product_Variants";
					loader.Append(resultItem.VariantName_DictID);
					//2:Parameter CMN_PRO_ASS_AssortmentVariantID of type Guid
					resultItem.CMN_PRO_ASS_AssortmentVariantID = reader.GetGuid(2);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_AssortmentVariants_for_ProductID",ex);
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
		public static FR_L5AS_GAVfP_2216_Array Invoke(string ConnectionString,P_L5AS_GAVfP_2216 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5AS_GAVfP_2216_Array Invoke(DbConnection Connection,P_L5AS_GAVfP_2216 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5AS_GAVfP_2216_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AS_GAVfP_2216 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5AS_GAVfP_2216_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AS_GAVfP_2216 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5AS_GAVfP_2216_Array functionReturn = new FR_L5AS_GAVfP_2216_Array();
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

				throw new Exception("Exception occured in method cls_Get_AssortmentVariants_for_ProductID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5AS_GAVfP_2216_Array : FR_Base
	{
		public L5AS_GAVfP_2216[] Result	{ get; set; } 
		public FR_L5AS_GAVfP_2216_Array() : base() {}

		public FR_L5AS_GAVfP_2216_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5AS_GAVfP_2216 for attribute P_L5AS_GAVfP_2216
		[DataContract]
		public class P_L5AS_GAVfP_2216 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProductID { get; set; } 

		}
		#endregion
		#region SClass L5AS_GAVfP_2216 for attribute L5AS_GAVfP_2216
		[DataContract]
		public class L5AS_GAVfP_2216 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_Product_VariantID { get; set; } 
			[DataMember]
			public Dict VariantName_DictID { get; set; } 
			[DataMember]
			public Guid CMN_PRO_ASS_AssortmentVariantID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5AS_GAVfP_2216_Array cls_Get_AssortmentVariants_for_ProductID(,P_L5AS_GAVfP_2216 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5AS_GAVfP_2216_Array invocationResult = cls_Get_AssortmentVariants_for_ProductID.Invoke(connectionString,P_L5AS_GAVfP_2216 Parameter,securityTicket);
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
var parameter = new CL5_Zugseil_Assortments.Atomic.Retrieval.P_L5AS_GAVfP_2216();
parameter.ProductID = ...;

*/
