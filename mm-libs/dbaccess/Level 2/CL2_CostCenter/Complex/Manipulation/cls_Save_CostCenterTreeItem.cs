/* 
 * Generated on 3/3/2015 3:59:57 PM
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
using CL1_CMN_STR;

namespace CL2_CostCenter.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_CostCenterTreeItem.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_CostCenterTreeItem
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L2CC_SCCTI_1556 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();

			//Put your code here
            var item = new CL1_CMN_STR.ORM_CMN_STR_CostCenter();
            var costCenterOffice = new CL1_CMN_STR.ORM_CMN_STR_Office_2_CostCenter();
            if (Parameter.CMN_STR_CostCenterID != Guid.Empty)
            {
                var result = item.Load(Connection, Transaction, Parameter.CMN_STR_CostCenterID);
                costCenterOffice = ORM_CMN_STR_Office_2_CostCenter.Query.Search(Connection, Transaction,
                    new ORM_CMN_STR_Office_2_CostCenter.Query
                    {
                        CostCenter_RefID = item.CMN_STR_CostCenterID,
                        IsDeleted = false
                    }).FirstOrDefault();
                costCenterOffice = costCenterOffice ?? new CL1_CMN_STR.ORM_CMN_STR_Office_2_CostCenter();
            }

            if (Parameter.IsDeleted == true)
            {
                costCenterOffice.IsDeleted = true;
                costCenterOffice.Save(Connection, Transaction);

                item.IsDeleted = true;
                return new FR_Guid(item.Save(Connection, Transaction), item.CMN_STR_CostCenterID);
            }

            item.Tenant_RefID = securityTicket.TenantID;
            item.InternalID = Parameter.InternalID;
            item.Name = Parameter.Name;
            item.Description = Parameter.Description;
            item.CostCenterType_RefID = Parameter.CostCenterType_RefID;
            item.Currency_RefID = Parameter.Currency_RefID;
            item.CostCenter_Parent_RefID = Parameter.CostCenter_Parent_RefID;
            item.OpenForBooking = Parameter.OpenForBooking;
            item.ResponsiblePerson_RefID = Parameter.ResponsiblePerson_RefID;

            costCenterOffice.CostCenter_RefID = item.CMN_STR_CostCenterID;
            costCenterOffice.Office_RefID = Parameter.OfficeID;
            costCenterOffice.Tenant_RefID = item.Tenant_RefID;
            costCenterOffice.Save(Connection, Transaction);

            return new FR_Guid(item.Save(Connection, Transaction), item.CMN_STR_CostCenterID);

			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L2CC_SCCTI_1556 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L2CC_SCCTI_1556 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L2CC_SCCTI_1556 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2CC_SCCTI_1556 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_CostCenterTreeItem",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L2CC_SCCTI_1556 for attribute P_L2CC_SCCTI_1556
		[DataContract]
		public class P_L2CC_SCCTI_1556 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_STR_CostCenterID { get; set; } 
			[DataMember]
			public Guid OfficeID { get; set; } 
			[DataMember]
			public String InternalID { get; set; } 
			[DataMember]
			public Dict Name { get; set; } 
			[DataMember]
			public Dict Description { get; set; } 
			[DataMember]
			public Guid CostCenterType_RefID { get; set; } 
			[DataMember]
			public Guid ResponsiblePerson_RefID { get; set; } 
			[DataMember]
			public Guid Currency_RefID { get; set; } 
			[DataMember]
			public Guid CostCenter_Parent_RefID { get; set; } 
			[DataMember]
			public bool OpenForBooking { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_CostCenterTreeItem(,P_L2CC_SCCTI_1556 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_CostCenterTreeItem.Invoke(connectionString,P_L2CC_SCCTI_1556 Parameter,securityTicket);
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
var parameter = new CL2_CostCenter.Complex.Manipulation.P_L2CC_SCCTI_1556();
parameter.CMN_STR_CostCenterID = ...;
parameter.OfficeID = ...;
parameter.InternalID = ...;
parameter.Name = ...;
parameter.Description = ...;
parameter.CostCenterType_RefID = ...;
parameter.ResponsiblePerson_RefID = ...;
parameter.Currency_RefID = ...;
parameter.CostCenter_Parent_RefID = ...;
parameter.OpenForBooking = ...;
parameter.IsDeleted = ...;

*/
