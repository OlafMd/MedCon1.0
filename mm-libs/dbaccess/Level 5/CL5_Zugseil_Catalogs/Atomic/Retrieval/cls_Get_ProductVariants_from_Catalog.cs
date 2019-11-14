/* 
 * Generated on 1/21/2015 09:34:09
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

namespace CL5_Zugseil_Catalogs.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ProductVariants_from_Catalog.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ProductVariants_from_Catalog
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5CA_GPVfC_1612_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5CA_GPVfC_1612 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5CA_GPVfC_1612_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Zugseil_Catalogs.Atomic.Retrieval.SQL.cls_Get_ProductVariants_from_Catalog.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ProductID", Parameter.ProductID);



			List<L5CA_GPVfC_1612> results = new List<L5CA_GPVfC_1612>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_PRO_Product_VariantID","ProductVariantITL","VariantName_DictID","IsStandardProductVariant" });
				while(reader.Read())
				{
					L5CA_GPVfC_1612 resultItem = new L5CA_GPVfC_1612();
					//0:Parameter CMN_PRO_Product_VariantID of type Guid
					resultItem.CMN_PRO_Product_VariantID = reader.GetGuid(0);
					//1:Parameter ProductVariantITL of type String
					resultItem.ProductVariantITL = reader.GetString(1);
					//2:Parameter VariantName of type Dict
					resultItem.VariantName = reader.GetDictionary(2);
					resultItem.VariantName.SourceTable = "CMN_PRO_Product_Variants";
					loader.Append(resultItem.VariantName);
					//3:Parameter IsStandardProductVariant of type bool
					resultItem.IsStandardProductVariant = reader.GetBoolean(3);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_ProductVariants_from_Catalog",ex);
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
		public static FR_L5CA_GPVfC_1612_Array Invoke(string ConnectionString,P_L5CA_GPVfC_1612 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5CA_GPVfC_1612_Array Invoke(DbConnection Connection,P_L5CA_GPVfC_1612 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5CA_GPVfC_1612_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5CA_GPVfC_1612 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5CA_GPVfC_1612_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5CA_GPVfC_1612 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5CA_GPVfC_1612_Array functionReturn = new FR_L5CA_GPVfC_1612_Array();
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

				throw new Exception("Exception occured in method cls_Get_ProductVariants_from_Catalog",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5CA_GPVfC_1612_Array : FR_Base
	{
		public L5CA_GPVfC_1612[] Result	{ get; set; } 
		public FR_L5CA_GPVfC_1612_Array() : base() {}

		public FR_L5CA_GPVfC_1612_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5CA_GPVfC_1612 for attribute P_L5CA_GPVfC_1612
		[DataContract]
		public class P_L5CA_GPVfC_1612 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProductID { get; set; } 

		}
		#endregion
		#region SClass L5CA_GPVfC_1612 for attribute L5CA_GPVfC_1612
		[DataContract]
		public class L5CA_GPVfC_1612 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_Product_VariantID { get; set; } 
			[DataMember]
			public String ProductVariantITL { get; set; } 
			[DataMember]
			public Dict VariantName { get; set; } 
			[DataMember]
			public bool IsStandardProductVariant { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5CA_GPVfC_1612_Array cls_Get_ProductVariants_from_Catalog(,P_L5CA_GPVfC_1612 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5CA_GPVfC_1612_Array invocationResult = cls_Get_ProductVariants_from_Catalog.Invoke(connectionString,P_L5CA_GPVfC_1612 Parameter,securityTicket);
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
var parameter = new CL5_Zugseil_Catalogs.Atomic.Retrieval.P_L5CA_GPVfC_1612();
parameter.ProductID = ...;

*/
