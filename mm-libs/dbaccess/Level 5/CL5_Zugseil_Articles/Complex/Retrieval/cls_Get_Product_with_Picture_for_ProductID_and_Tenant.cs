/* 
 * Generated on 11/12/2014 12:41:45 PM
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
using CL5_Zugseil_Articles.Atomic.Retrieval;
using CL3_Document.Atomic.Retrieval;

namespace CL5_Zugseil_Articles.Complex.Retrieval
{
	/// <summary>
    /// Get_Product_with_Picture_for_ProductID_and_Tenant
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Product_with_Picture_for_ProductID_and_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Product_with_Picture_for_ProductID_and_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5ZA_GPwPfPaT_1208 Execute(DbConnection Connection,DbTransaction Transaction,P_L5ZA_GPwPfPaT_1208 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5ZA_GPwPfPaT_1208();
            returnValue.Result = new L5ZA_GPwPfPaT_1208();
			//Put your code here

            var parameter = new P_L5AR_GPfPaT_1542();
            parameter.ProductID = Parameter.ProductID;
            var product = cls_Get_Product_for_ProductID_and_Tenant.Invoke(Connection, Transaction, parameter,securityTicket).Result;

            var docParam = new P_L3DO_GDfDH_1133();
            docParam.DHeaderID = product.Product_DocumentationStructure_RefID;

            if (docParam.DHeaderID != Guid.Empty)
            {
                var documents = cls_Get_Documents_for_DHeaderID.Invoke(Connection, Transaction, docParam, securityTicket).Result;
                var pictureDocumentID = documents.Select(x => x.DOC_DocumentID).FirstOrDefault();

                returnValue.Result.PictureDocumentID = pictureDocumentID;
            }
            else
            {
                returnValue.Result.PictureDocumentID = Guid.Empty;
            }
    
            returnValue.Result.Product = product;
          
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5ZA_GPwPfPaT_1208 Invoke(string ConnectionString,P_L5ZA_GPwPfPaT_1208 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5ZA_GPwPfPaT_1208 Invoke(DbConnection Connection,P_L5ZA_GPwPfPaT_1208 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5ZA_GPwPfPaT_1208 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5ZA_GPwPfPaT_1208 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5ZA_GPwPfPaT_1208 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5ZA_GPwPfPaT_1208 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5ZA_GPwPfPaT_1208 functionReturn = new FR_L5ZA_GPwPfPaT_1208();
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

				throw new Exception("Exception occured in method cls_Get_Product_with_Picture_for_ProductID_and_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5ZA_GPwPfPaT_1208 : FR_Base
	{
		public L5ZA_GPwPfPaT_1208 Result	{ get; set; }

		public FR_L5ZA_GPwPfPaT_1208() : base() {}

		public FR_L5ZA_GPwPfPaT_1208(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5ZA_GPwPfPaT_1208 for attribute P_L5ZA_GPwPfPaT_1208
		[DataContract]
		public class P_L5ZA_GPwPfPaT_1208 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProductID { get; set; } 

		}
		#endregion
		#region SClass L5ZA_GPwPfPaT_1208 for attribute L5ZA_GPwPfPaT_1208
		[DataContract]
		public class L5ZA_GPwPfPaT_1208 
		{
			//Standard type parameters
			[DataMember]
			public L5AR_GPfPaT_1542 Product { get; set; } 
			[DataMember]
			public Guid PictureDocumentID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5ZA_GPwPfPaT_1208 cls_Get_Product_with_Picture_for_ProductID_and_Tenant(,P_L5ZA_GPwPfPaT_1208 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5ZA_GPwPfPaT_1208 invocationResult = cls_Get_Product_with_Picture_for_ProductID_and_Tenant.Invoke(connectionString,P_L5ZA_GPwPfPaT_1208 Parameter,securityTicket);
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
var parameter = new CL5_Zugseil_Articles.Complex.Retrieval.P_L5ZA_GPwPfPaT_1208();
parameter.ProductID = ...;

*/
