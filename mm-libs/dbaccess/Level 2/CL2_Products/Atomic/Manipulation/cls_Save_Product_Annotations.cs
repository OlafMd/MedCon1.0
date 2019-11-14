/* 
 * Generated on 11/18/2013 3:52:27 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 * Required Assemblies:
 * System.Runtime.Serialization
 * CSV2Core
 * CSV2Core_MySQL
 */
using System;
using System.Data.Common;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Runtime.Serialization;

namespace CL2_Products.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Product_Annotations.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Product_Annotations
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L2PD_SPA_1337 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){

		  var returnValue = new FR_Guid();

		  var item = new CL1_CMN_PRO.ORM_CMN_PRO_Product_Annotations();
		  if (Parameter.CMN_PRO_Product_AnnotationID != Guid.Empty)
		  {
		  var result = item.Load(Connection, Transaction, Parameter.CMN_PRO_Product_AnnotationID);
		  if (result.Status != FR_Status.Success || item.CMN_PRO_Product_AnnotationID == Guid.Empty)
		  {
		  var error = new FR_Guid();
		  error.ErrorMessage = "No Such ID";
		  error.Status =  FR_Status.Error_Internal;
		  return error;
		  }
		  }

		  if(Parameter.IsDeleted == true){
		  item.IsDeleted = true;
		  return new FR_Guid(item.Save(Connection, Transaction),item.CMN_PRO_Product_AnnotationID);
		  }

		  //Creation specific parameters (Tenant, Account ... )
		  if (Parameter.CMN_PRO_Product_AnnotationID == Guid.Empty)
		  {
		  item.Tenant_RefID = securityTicket.TenantID;
		  }

		  item.GlobalPropertyMatchingID = Parameter.GlobalPropertyMatchingID;
		  item.ProductAnnotation_Abbreviation = Parameter.ProductAnnotation_Abbreviation;
		  item.ProductAnnotation_Name_DictID = Parameter.ProductAnnotation_Name_DictID;
		  item.IsValueBoolean = Parameter.IsValueBoolean;
		  item.IsValueNumber = Parameter.IsValueNumber;


		  return new FR_Guid(item.Save(Connection, Transaction),item.CMN_PRO_Product_AnnotationID);
  
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L2PD_SPA_1337 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L2PD_SPA_1337 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L2PD_SPA_1337 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2PD_SPA_1337 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Guid functionReturn = new FR_Guid();
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

				throw new Exception("Exception occured in method cls_Save_Product_Annotations",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L2PD_SPA_1337 for attribute P_L2PD_SPA_1337
		[DataContract]
		public class P_L2PD_SPA_1337 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_Product_AnnotationID { get; set; } 
			[DataMember]
			public String GlobalPropertyMatchingID { get; set; } 
			[DataMember]
			public String ProductAnnotation_Abbreviation { get; set; } 
			[DataMember]
			public Dict ProductAnnotation_Name_DictID { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 
			[DataMember]
			public Boolean IsValueBoolean { get; set; } 
			[DataMember]
			public Boolean IsValueNumber { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Product_Annotations(,P_L2PD_SPA_1337 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Product_Annotations.Invoke(connectionString,P_L2PD_SPA_1337 Parameter,securityTicket);
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
var parameter = new CL2_Products.Atomic.Manipulation.P_L2PD_SPA_1337();
parameter.CMN_PRO_Product_AnnotationID = ...;
parameter.GlobalPropertyMatchingID = ...;
parameter.ProductAnnotation_Abbreviation = ...;
parameter.ProductAnnotation_Name_DictID = ...;
parameter.IsDeleted = ...;
parameter.IsValueBoolean = ...;
parameter.IsValueNumber = ...;

*/
