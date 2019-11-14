/* 
 * Generated on 10/22/2014 15:30:25
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
    /// var result = cls_Save_CostCentersList.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_CostCentersList
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L2CC_SCCL_1355 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
            var savingResult = new FR_Guid();
            foreach (var par in Parameter.Results)
            {
                var item = new CL1_CMN_STR.ORM_CMN_STR_CostCenter();
                var costCenterOffice = new CL1_CMN_STR.ORM_CMN_STR_Office_2_CostCenter();
                if (par.CMN_STR_CostCenterID != Guid.Empty)
                {
                    var result = item.Load(Connection, Transaction, par.CMN_STR_CostCenterID);
                    costCenterOffice = ORM_CMN_STR_Office_2_CostCenter.Query.Search(Connection, Transaction,
                        new ORM_CMN_STR_Office_2_CostCenter.Query
                        {
                            CostCenter_RefID = item.CMN_STR_CostCenterID,
                            IsDeleted = false
                        }).FirstOrDefault();
                    costCenterOffice = costCenterOffice ?? new CL1_CMN_STR.ORM_CMN_STR_Office_2_CostCenter();
                }


                // Get childrens of this item.
                var childrens = ORM_CMN_STR_CostCenter.Query.Search(Connection, Transaction,
                                new CL1_CMN_STR.ORM_CMN_STR_CostCenter.Query { IsDeleted = false, CostCenter_Parent_RefID = item.CMN_STR_CostCenterID });
                item.R_CostCenter_HasChildren = childrens.Count > 0 ? true : false;

                // Check parent property HasChildren
                if (item.CostCenter_Parent_RefID != Guid.Empty)
                {
                    var parent = ORM_CMN_STR_CostCenter.Query.Search(Connection, Transaction,
                        new ORM_CMN_STR_CostCenter.Query { IsDeleted = false, CMN_STR_CostCenterID = item.CostCenter_Parent_RefID }).SingleOrDefault();

                    if (item.IsDeleted && parent != null)
                    {
                        var parentChildrens = ORM_CMN_STR_CostCenter.Query.Search(Connection, Transaction,
                                new ORM_CMN_STR_CostCenter.Query { IsDeleted = false, CostCenter_Parent_RefID = parent.CMN_STR_CostCenterID });
                        if (parentChildrens.Count == 1 && parentChildrens.FirstOrDefault().CMN_STR_CostCenterID == item.CMN_STR_CostCenterID)
                        {
                            parent.R_CostCenter_HasChildren = false;
                            parent.Save(Connection, Transaction);
                        }
                    }
                    else if (parent != null && !parent.R_CostCenter_HasChildren)
                    {
                        parent.R_CostCenter_HasChildren = true;
                        parent.Save(Connection, Transaction);
                    }
                }

                if (par.IsDeleted == true)
                {
                    foreach (var c in childrens)
                    {
                        c.IsDeleted = true;
                        c.Save(Connection, Transaction);
                    }
                    costCenterOffice.IsDeleted = true;
                    item.IsDeleted = true;
                    costCenterOffice.Save(Connection, Transaction);
                    savingResult= new FR_Guid(item.Save(Connection, Transaction), item.CMN_STR_CostCenterID);
                }

                //Creation specific pars (Tenant, Account ... )
                if (par.CMN_STR_CostCenterID == Guid.Empty)
                {
                    item.Tenant_RefID = securityTicket.TenantID;
                }

                item.InternalID = par.InternalID;
                item.Name = par.Name;
                item.Description = par.Description;
                item.CostCenterType_RefID = par.CostCenterType_RefID;
                item.Currency_RefID = par.Currency_RefID;
                item.CostCenter_Parent_RefID = par.CostCenter_Parent_RefID;
                item.OpenForBooking = par.OpenForBooking;
                item.ResponsiblePerson_RefID = par.ResponsiblePerson_RefID;
                costCenterOffice.CostCenter_RefID = item.CMN_STR_CostCenterID;
                costCenterOffice.Office_RefID = par.OfficeID;
                costCenterOffice.Tenant_RefID = item.Tenant_RefID;
                costCenterOffice.Save(Connection, Transaction);
                savingResult=new FR_Guid(item.Save(Connection, Transaction), item.CMN_STR_CostCenterID);
            
            
            }
            returnValue = savingResult;
			//Put your code here
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L2CC_SCCL_1355 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L2CC_SCCL_1355 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L2CC_SCCL_1355 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2CC_SCCL_1355 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_CostCentersList",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L2CC_SCCL_1355 for attribute P_L2CC_SCCL_1355
		[DataContract]
		public class P_L2CC_SCCL_1355 
		{
			[DataMember]
			public P_L2CC_SCCL_1355a[] Results { get; set; }

			//Standard type parameters
		}
		#endregion
		#region SClass P_L2CC_SCCL_1355a for attribute Results
		[DataContract]
		public class P_L2CC_SCCL_1355a 
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
FR_Guid cls_Save_CostCentersList(,P_L2CC_SCCL_1355 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_CostCentersList.Invoke(connectionString,P_L2CC_SCCL_1355 Parameter,securityTicket);
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
var parameter = new CL2_CostCenter.Complex.Manipulation.P_L2CC_SCCL_1355();
parameter.Results = ...;


*/
