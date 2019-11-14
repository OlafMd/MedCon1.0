/* 
 * Generated on 2/10/2015 3:28:48 PM
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
using CL1_CMN_PRO_ASS;

namespace CL5_Zugseil_Assortments.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Assortment_BaseData.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Assortment_BaseData
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5SABD_1714 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here
            

            bool createNew = false;
            if (Parameter.CMN_PRO_ASS_AssortmentID == Guid.Empty)
            {
                createNew = true;
                
                
            }

            ORM_CMN_PRO_ASS_Assortment item = null;
            if (createNew)
            {
                item = new ORM_CMN_PRO_ASS_Assortment();
                item.CMN_PRO_ASS_AssortmentID = Guid.NewGuid();
                item.Tenant_RefID = securityTicket.TenantID;
                item.Creation_Timestamp = DateTime.Now;
            }
            else
            {

                item = ORM_CMN_PRO_ASS_Assortment.Query.Search(Connection, Transaction, new ORM_CMN_PRO_ASS_Assortment.Query
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    CMN_PRO_ASS_AssortmentID = Parameter.CMN_PRO_ASS_AssortmentID
                }).FirstOrDefault();

                if (item == null)
                {
                    returnValue.Status = FR_Status.Error_Internal;
                    returnValue.ErrorMessage = String.Format("No assortment with id = {1} found.", Parameter.CMN_PRO_ASS_AssortmentID.ToString());
                    return returnValue;
                }


            }
            item.AssortmentName = Parameter.AssortmentName_DictID;
            item.AvailableForOrderingFrom = Parameter.AvailableForOrderingFrom;
            item.AvailableForOrderingThrough = Parameter.AvailableForOrderingThrough;
            item.IsDefaultAssortment_ForCostcenterOrder = Parameter.IsDefaultAssortment_ForCostcenterOrder;
            item.IsDefaultAssortment_ForOfficeOrder = Parameter.IsDefaultAssortment_ForOfficeOrder;
            item.IsDefaultAssortment_ForPersonalOrder = Parameter.IsDefaultAssortment_ForPersonalOrder;
            item.IsDefaultAssortment_ForWarehouseOrder = Parameter.IsDefaultAssortment_ForWarehouseOrder;
            item.IsDeleted = Parameter.isDeleted;
            item.Modification_Timestamp = DateTime.Now;

            item.Save(Connection, Transaction);
            returnValue.Result = item.CMN_PRO_ASS_AssortmentID;

			return returnValue;          

			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5SABD_1714 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5SABD_1714 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5SABD_1714 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5SABD_1714 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Assortment_BaseData",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5SABD_1714 for attribute P_L5SABD_1714
		[DataContract]
		public class P_L5SABD_1714 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_ASS_AssortmentID { get; set; } 
			[DataMember]
			public Dict AssortmentName_DictID { get; set; } 
			[DataMember]
			public DateTime AvailableForOrderingFrom { get; set; } 
			[DataMember]
			public DateTime AvailableForOrderingThrough { get; set; } 
			[DataMember]
			public bool IsDefaultAssortment_ForCostcenterOrder { get; set; } 
			[DataMember]
			public bool IsDefaultAssortment_ForOfficeOrder { get; set; } 
			[DataMember]
			public bool IsDefaultAssortment_ForPersonalOrder { get; set; } 
			[DataMember]
			public bool IsDefaultAssortment_ForWarehouseOrder { get; set; } 
			[DataMember]
			public bool isDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Assortment_BaseData(,P_L5SABD_1714 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Assortment_BaseData.Invoke(connectionString,P_L5SABD_1714 Parameter,securityTicket);
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
var parameter = new CL5_Zugseil_Assortments.Atomic.Manipulation.P_L5SABD_1714();
parameter.CMN_PRO_ASS_AssortmentID = ...;
parameter.AssortmentName_DictID = ...;
parameter.AvailableForOrderingFrom = ...;
parameter.AvailableForOrderingThrough = ...;
parameter.IsDefaultAssortment_ForCostcenterOrder = ...;
parameter.IsDefaultAssortment_ForOfficeOrder = ...;
parameter.IsDefaultAssortment_ForPersonalOrder = ...;
parameter.IsDefaultAssortment_ForWarehouseOrder = ...;
parameter.isDeleted = ...;

*/
