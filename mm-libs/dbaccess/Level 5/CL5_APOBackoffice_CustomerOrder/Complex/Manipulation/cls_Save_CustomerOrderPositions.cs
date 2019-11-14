/* 
 * Generated on 4/10/2014 1:07:00 PM
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

namespace CL5_APOBackoffice_CustomerOrder.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_CustomerOrderPositions.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_CustomerOrderPositions
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5CO_COP_1459 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            int positionsCount = CL1_ORD_CUO.ORM_ORD_CUO_CustomerOrder_Position.Query.Search(Connection, Transaction,
               new CL1_ORD_CUO.ORM_ORD_CUO_CustomerOrder_Position.Query()
               {
                   CustomerOrder_Header_RefID = Parameter.CustomerOrderHeaderID,
                   IsDeleted = false,
                   Tenant_RefID = securityTicket.TenantID
               }).Count();

            foreach (var item in Parameter.Positions)
            {
                #region Create Position
                
                CL1_ORD_CUO.ORM_ORD_CUO_CustomerOrder_Position position = null;

                if (item.CustomerOrderPositionID == Guid.Empty)
                {
                    #region Load referenced data

                    var product = CL1_CMN_PRO.ORM_CMN_PRO_Product.Query.Search(Connection, Transaction, new CL1_CMN_PRO.ORM_CMN_PRO_Product.Query
                        {
                            CMN_PRO_ProductID = item.ArticleID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        }).Single();

                    var packageInfo = CL1_CMN_PRO_PAC.ORM_CMN_PRO_PAC_PackageInfo.Query.Search(Connection, Transaction,
                        new CL1_CMN_PRO_PAC.ORM_CMN_PRO_PAC_PackageInfo.Query
                        {
                            CMN_PRO_PAC_PackageInfoID = product.PackageInfo_RefID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        }).Single();

                    var unitID = packageInfo.PackageContent_MeasuredInUnit_RefID;

                    #endregion

                    position = new CL1_ORD_CUO.ORM_ORD_CUO_CustomerOrder_Position
                    {
                        ORD_CUO_CustomerOrder_PositionID = Guid.NewGuid(),
                        Creation_Timestamp = DateTime.Now,
                        IsProductReplacementAllowed = true,
                        Tenant_RefID = securityTicket.TenantID,
                        CustomerOrder_Header_RefID = Parameter.CustomerOrderHeaderID,
                        CMN_PRO_Product_RefID = item.ArticleID,
                        Position_Comment = null,
                        Position_OrdinalNumber = ++positionsCount,
                        Position_Unit_RefID = unitID,
                    };

                    // if org. unit is selected on parameter creation, create org unit distribution
                    if (Parameter.OrganizationalUnitID != Guid.Empty)
                    {
                        var positionOrgUnitDist = new CL1_ORD_CUO.ORM_ORD_CUO_Position_CustomerOrganizationalUnitDistribution
                        {
                            ORD_CUO_Position_CustomerOrganizationalUnitDistributionID = Guid.NewGuid(),
                            CMN_BPT_CTM_OrganizationalUnit_RefID = Parameter.OrganizationalUnitID,
                            ORD_CUO_CustomerOrder_Position_RefID = position.ORD_CUO_CustomerOrder_PositionID,
                            Quantity = item.Quantity,
                            Creation_Timestamp = DateTime.Now,
                            Tenant_RefID = securityTicket.TenantID
                        };
                        positionOrgUnitDist.Save(Connection, Transaction);
                    }
                }
                else
                {
                    position = CL1_ORD_CUO.ORM_ORD_CUO_CustomerOrder_Position.Query.Search(Connection, Transaction,
                        new CL1_ORD_CUO.ORM_ORD_CUO_CustomerOrder_Position.Query
                        {
                            ORD_CUO_CustomerOrder_PositionID = item.CustomerOrderPositionID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        }).Single();

                    var positionOrgUnitDist = CL1_ORD_CUO.ORM_ORD_CUO_Position_CustomerOrganizationalUnitDistribution.Query.Search(Connection, Transaction,
                        new CL1_ORD_CUO.ORM_ORD_CUO_Position_CustomerOrganizationalUnitDistribution.Query {
                            ORD_CUO_CustomerOrder_Position_RefID = position.ORD_CUO_CustomerOrder_PositionID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        }).SingleOrDefault();

                    // if ORD_CUO_Position_CustomerOrganizationalUnitDistribution entry exists, update organizational unit and quantity.
                    if (positionOrgUnitDist != default(CL1_ORD_CUO.ORM_ORD_CUO_Position_CustomerOrganizationalUnitDistribution))
                    {
                        positionOrgUnitDist.ORD_CUO_Position_CustomerOrganizationalUnitDistributionID = Parameter.OrganizationalUnitID;
                        positionOrgUnitDist.Quantity = item.Quantity;
                        positionOrgUnitDist.Save(Connection, Transaction);
                    }
                    //  if ORD_CUO_Position_CustomerOrganizationalUnitDistribution entry does not exists create new
                    else
                    {
                        positionOrgUnitDist = new CL1_ORD_CUO.ORM_ORD_CUO_Position_CustomerOrganizationalUnitDistribution
                        {
                            ORD_CUO_Position_CustomerOrganizationalUnitDistributionID = Guid.NewGuid(),
                            CMN_BPT_CTM_OrganizationalUnit_RefID = Parameter.OrganizationalUnitID,
                            ORD_CUO_CustomerOrder_Position_RefID = position.ORD_CUO_CustomerOrder_PositionID,
                            Quantity = item.Quantity,
                            Creation_Timestamp = DateTime.Now,
                            Tenant_RefID = securityTicket.TenantID
                        };
                        positionOrgUnitDist.Save(Connection, Transaction);
                    }
                }
                
                position.Position_Quantity = item.Quantity;
                position.Position_ValuePerUnit = item.OrderPrice;
                position.Position_ValueTotal = (position.Position_ValuePerUnit * (decimal)position.Position_Quantity);

                position.Save(Connection, Transaction);

                #endregion
            }
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5CO_COP_1459 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5CO_COP_1459 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5CO_COP_1459 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5CO_COP_1459 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_CustomerOrderPositions",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5CO_COP_1459 for attribute P_L5CO_COP_1459
		[DataContract]
		public class P_L5CO_COP_1459 
		{
			[DataMember]
			public P_L5CO_COP_1459a[] Positions { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid CustomerOrderHeaderID { get; set; } 
			[DataMember]
			public Guid OrganizationalUnitID { get; set; } 

		}
		#endregion
		#region SClass P_L5CO_COP_1459a for attribute Positions
		[DataContract]
		public class P_L5CO_COP_1459a 
		{
			//Standard type parameters
			[DataMember]
			public Guid CustomerOrderPositionID { get; set; } 
			[DataMember]
			public Guid ArticleID { get; set; } 
			[DataMember]
			public double Quantity { get; set; } 
			[DataMember]
			public decimal OrderPrice { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_CustomerOrderPositions(,P_L5CO_COP_1459 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_CustomerOrderPositions.Invoke(connectionString,P_L5CO_COP_1459 Parameter,securityTicket);
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
var parameter = new CL5_APOBackoffice_CustomerOrder.Complex.Manipulation.P_L5CO_COP_1459();
parameter.Positions = ...;

parameter.CustomerOrderHeaderID = ...;
parameter.OrganizationalUnitID = ...;

*/
