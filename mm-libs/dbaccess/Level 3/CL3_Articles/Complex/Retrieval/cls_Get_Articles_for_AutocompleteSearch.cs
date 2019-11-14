/* 
 * Generated on 8/22/2014 1:44:39 PM
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
using System.Runtime.Serialization;
using CL3_ABDA.Atomic.Retrieval;
using CL3_Articles.Atomic.Retrieval;
using CL3_Articles.Utils;

namespace CL3_Articles.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Articles_for_AutocompleteSearch.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Articles_for_AutocompleteSearch
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3AR_GAfAS_1248_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3AR_GAfAS_1248 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L3AR_GAfAS_1248_Array();
            var result = new List<L3AR_GAfAS_1248>();

            #region ABDA Articles

            var abdaParam = new P_L3ABDA_GAAfAS_1256()
            {
                SearchCondition = Parameter.SearchCondition
            };
            var abdaParamResult = cls_Get_ABDA_Articles_for_AutocompleteSearch.Invoke(Connection, Transaction, abdaParam, securityTicket).Result;

            foreach(var product in abdaParamResult){

                result.Add(new L3AR_GAfAS_1248(){
                    ProductITL = product.ProductITL,
                    ProductNumber = product.ProductNumber,
                    ProductName = product.ProductName,
                    IsABDAProduct= true
                } );
            }

            #endregion

            #region Local Articles

            var localParam = new P_L3AR_GLAfACS_1339
            {
                SearchCondition = LocalDBSearchCondition.GetConditionForSearchText(Parameter.SearchCondition),
                LanguageID = Parameter.LanguageID,
                IsAvailableForOrdering = Parameter.IsAvailableForOrdering,
            };

            var localParamResult = cls_Get_LocalArticles_for_AutoCompleteSearch.Invoke(Connection, Transaction, localParam, securityTicket).Result;

            foreach (var product in localParamResult)
            {
                result.Add(new L3AR_GAfAS_1248()
                {
                    ProductITL = product.ProductITL,
                    ProductNumber = product.Product_Number,
                    ProductName = product.ProductName,
                    IsABDAProduct = true
                });
            }

            #endregion

            returnValue.Result = result.ToArray();

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3AR_GAfAS_1248_Array Invoke(string ConnectionString,P_L3AR_GAfAS_1248 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3AR_GAfAS_1248_Array Invoke(DbConnection Connection,P_L3AR_GAfAS_1248 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3AR_GAfAS_1248_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3AR_GAfAS_1248 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3AR_GAfAS_1248_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3AR_GAfAS_1248 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3AR_GAfAS_1248_Array functionReturn = new FR_L3AR_GAfAS_1248_Array();
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

				
                throw new Exception("Exception occured in method cls_Get_Articles_for_AutocompleteSearch",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3AR_GAfAS_1248_Array : FR_Base
	{
		public L3AR_GAfAS_1248[] Result	{ get; set; } 
		public FR_L3AR_GAfAS_1248_Array() : base() {}

		public FR_L3AR_GAfAS_1248_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3AR_GAfAS_1248 for attribute P_L3AR_GAfAS_1248
		[DataContract]
		public class P_L3AR_GAfAS_1248 
		{
			//Standard type parameters
			[DataMember]
			public String SearchCondition { get; set; } 
			[DataMember]
			public Guid LanguageID { get; set; } 
			[DataMember]
			public bool? IsAvailableForOrdering { get; set; } 

		}
		#endregion
		#region SClass L3AR_GAfAS_1248 for attribute L3AR_GAfAS_1248
		[DataContract]
		public class L3AR_GAfAS_1248 
		{
			//Standard type parameters
			[DataMember]
			public String ProductITL { get; set; } 
			[DataMember]
			public String ProductNumber { get; set; } 
			[DataMember]
			public String ProductName { get; set; } 
			[DataMember]
			public bool IsABDAProduct { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3AR_GAfAS_1248_Array cls_Get_Articles_for_AutocompleteSearch(,P_L3AR_GAfAS_1248 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3AR_GAfAS_1248_Array invocationResult = cls_Get_Articles_for_AutocompleteSearch.Invoke(connectionString,P_L3AR_GAfAS_1248 Parameter,securityTicket);
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
var parameter = new CL3_Articles.Complex.Retrieval.P_L3AR_GAfAS_1248();
parameter.SearchCondition = ...;
parameter.LanguageID = ...;
parameter.IsAvailableForOrdering = ...;

*/
