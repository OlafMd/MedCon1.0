/* 
 * Generated on 09/11/2014 16:58:17
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
using System.Runtime.Serialization;
using CL1_LOG_WRH;
using CL5_APOAdmin_Articles.Atomic.Retrieval;

namespace CL5_APOAdmin_Articles.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_ArticleStorageQuantityLevel.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_ArticleStorageQuantityLevel
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5AR_SASQL_1340 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
            var newQuantityLevel = false; 
            Guid shelfID = Guid.Empty;
            ORM_LOG_WRH_QuantityLevel quantityLevel = new ORM_LOG_WRH_QuantityLevel();

            if (Parameter.QuantityLevelID != Guid.Empty)
            {
                var fetched = quantityLevel.Load(Connection, Transaction, Parameter.QuantityLevelID);

                if (fetched.Status != FR_Status.Success || quantityLevel.LOG_WRH_QuantityLevelID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }
            else
            {
                // new Quantity Level
                quantityLevel.LOG_WRH_QuantityLevelID = Guid.NewGuid();
                quantityLevel.Tenant_RefID = securityTicket.TenantID;
                quantityLevel.Creation_Timestamp = DateTime.Now;
                quantityLevel.Product_RefID = Parameter.ArticleID;
                newQuantityLevel = true;
                shelfID = Parameter.ShelfID;
            }

            // Delete assignments for Warehouse quantity levels if Quantity Level is deleted
            if (Parameter.IsDeleted)
            {
                #region Delete assignments
                var query1 = new ORM_LOG_WRH_Warehouse_2_QuantityLevel.Query()
                {
                    LOG_WRH_QuantityLevel_RefID = quantityLevel.LOG_WRH_QuantityLevelID,
                    Tenant_RefID = securityTicket.TenantID
                };
                ORM_LOG_WRH_Warehouse_2_QuantityLevel.Query.SoftDelete(Connection, Transaction, query1);

                var query2 = new ORM_LOG_WRH_Area_2_QuantityLevel.Query()
                {
                    LOG_WRH_QuantityLevel_RefID = quantityLevel.LOG_WRH_QuantityLevelID,
                    Tenant_RefID = securityTicket.TenantID
                };
                ORM_LOG_WRH_Area_2_QuantityLevel.Query.SoftDelete(Connection, Transaction, query2);

                var query3 = new ORM_LOG_WRH_Warehouse_Group_2_QuantityLevel.Query()
                {
                    LOG_WRH_QuantityLevel_RefID = quantityLevel.LOG_WRH_QuantityLevelID,
                    Tenant_RefID = securityTicket.TenantID
                };
                ORM_LOG_WRH_Warehouse_Group_2_QuantityLevel.Query.SoftDelete(Connection, Transaction, query3);
                var query4 = new ORM_LOG_WRH_Rack_2_QuantityLevel.Query()
                {
                    LOG_WRH_QuantityLevel_RefID = quantityLevel.LOG_WRH_QuantityLevelID,
                    Tenant_RefID = securityTicket.TenantID
                };
                ORM_LOG_WRH_Rack_2_QuantityLevel.Query.SoftDelete(Connection, Transaction, query4);
                
                var query5 = new ORM_LOG_WRH_Shelf_2_QuantityLevel.Query()
                {
                    LOG_WRH_QuantityLevel_RefID = quantityLevel.LOG_WRH_QuantityLevelID,
                    Tenant_RefID = securityTicket.TenantID
                };
                ORM_LOG_WRH_Shelf_2_QuantityLevel.Query.SoftDelete(Connection, Transaction, query5);

                if (Parameter.PredefinedLocationID != Guid.Empty)
                {
                    var query6 = new ORM_LOG_WRH_Shelf_PredefinedProductLocation.Query()
                    {
                        LOG_WRH_Shelf_PredefinedProductLocationID = Parameter.PredefinedLocationID,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    };
                    ORM_LOG_WRH_Shelf_PredefinedProductLocation.Query.SoftDelete(Connection, Transaction, query6);

                    var tempShelf = ORM_LOG_WRH_Shelf.Query.Search(Connection, Transaction, new ORM_LOG_WRH_Shelf.Query
                    {
                        LOG_WRH_ShelfID = Parameter.ShelfID
                    }).SingleOrDefault();

                    var tempArea = ORM_LOG_WRH_Area.Query.Search(Connection, Transaction, new ORM_LOG_WRH_Area.Query
                    {
                        LOG_WRH_AreaID = tempShelf.R_Area_RefID
                    }).SingleOrDefault();

                    var allArticleStorages = cls_Get_ArticleStorages_for_ArticleID.Invoke(Connection, Transaction, new P_L5AR_GASfA_1520 { ArticleID = Parameter.ArticleID }, securityTicket).Result;

                    List<L5AR_GASfA_1520> articleStoragesByOffice = new List<L5AR_GASfA_1520>();
                    if (tempArea.IsPointOfSalesArea)
                    {
                        articleStoragesByOffice = allArticleStorages.Where(x => x.IsPointOfSalesArea).OrderBy(x => x.LocationPriority).ToList();
                    }
                    if (tempArea.IsLongTermStorageArea)
                    {
                        articleStoragesByOffice = allArticleStorages.Where(x => x.IsLongTermStorageArea).OrderBy(x => x.LocationPriority).ToList();
                    }

                    if (articleStoragesByOffice.Count > 1)
                    {
                        int counter = 1;
                        foreach (var item in articleStoragesByOffice)
                        {
                            if (counter != item.LocationPriority)
                            {
                                var ArticleLocationPosition = ORM_LOG_WRH_Shelf_PredefinedProductLocation.Query.Search(Connection, Transaction, new ORM_LOG_WRH_Shelf_PredefinedProductLocation.Query
                                {
                                    IsDeleted = false,
                                    LOG_WRH_Shelf_PredefinedProductLocationID = item.PredefinedProductLocationID,
                                    Tenant_RefID = securityTicket.TenantID
                                }).Single();

                                ArticleLocationPosition.LocationPriority = counter;
                                ArticleLocationPosition.Save(Connection, Transaction);
                            }
                            counter++;
                        }
                    }
                }
                #endregion
            }
            else
            {
                quantityLevel.Quantity_Maximum = Parameter.MaximumQuantity;
                quantityLevel.Quantity_Minimum = Parameter.MinimumQuantity;
                quantityLevel.Quantity_RecommendedMinimumCalculation = Parameter.RecommendedMinimumQuantity;
                quantityLevel.Save(Connection, Transaction);

                returnValue.Result = quantityLevel.LOG_WRH_QuantityLevelID;

                #region Write priority to the LOG_WRH_Shelf_PredefinedProductLocations

                var tempShelf = ORM_LOG_WRH_Shelf.Query.Search(Connection, Transaction, new ORM_LOG_WRH_Shelf.Query
                {
                    LOG_WRH_ShelfID = Parameter.ShelfID
                }).SingleOrDefault();

                var tempArea = ORM_LOG_WRH_Area.Query.Search(Connection, Transaction, new ORM_LOG_WRH_Area.Query
                {
                    LOG_WRH_AreaID = tempShelf.R_Area_RefID
                }).SingleOrDefault();

                int priorityNumber = 1;
                var allArticleStorages = cls_Get_ArticleStorages_for_ArticleID.Invoke(Connection, Transaction, new P_L5AR_GASfA_1520 { ArticleID = Parameter.ArticleID }, securityTicket).Result;

                List<L5AR_GASfA_1520> articleStoragesByOffice = new List<L5AR_GASfA_1520>();
                if (tempArea.IsPointOfSalesArea) articleStoragesByOffice = allArticleStorages.Where(x => x.IsPointOfSalesArea).ToList();
                if (tempArea.IsLongTermStorageArea) articleStoragesByOffice = allArticleStorages.Where(x => x.IsLongTermStorageArea).ToList();
                if (articleStoragesByOffice.Any()) priorityNumber = articleStoragesByOffice.Max(x => x.LocationPriority) + 1;

                if (newQuantityLevel && Parameter.ShelfID != Guid.Empty)
                {
                    var predefinedProductLocation = ORM_LOG_WRH_Shelf_PredefinedProductLocation.Query.Search(Connection, Transaction, new ORM_LOG_WRH_Shelf_PredefinedProductLocation.Query
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        Product_RefID = Parameter.ArticleID,
                        Shelf_RefID = Parameter.ShelfID,
                        IsDeleted = false
                    }).SingleOrDefault();

                    if (predefinedProductLocation == null)
                    {
                        predefinedProductLocation = new ORM_LOG_WRH_Shelf_PredefinedProductLocation();
                        predefinedProductLocation.LOG_WRH_Shelf_PredefinedProductLocationID = Guid.NewGuid();
                    }
                    
                    predefinedProductLocation.LocationPriority = priorityNumber;
                    predefinedProductLocation.Product_RefID = Parameter.ArticleID;
                    predefinedProductLocation.Shelf_RefID = Parameter.ShelfID;
                    predefinedProductLocation.Tenant_RefID = securityTicket.TenantID;
                    predefinedProductLocation.Save(Connection, Transaction);
                }
                #endregion

                bool makeNewAssignment = (newQuantityLevel) || Parameter.WarehouseLevelIsChanged;
                #region Make assignment
                if (makeNewAssignment)
                {
                    if (Parameter.WarehouseID != Guid.Empty)
                    {
                        ORM_LOG_WRH_Warehouse_2_QuantityLevel quantityLevelAssignment = new ORM_LOG_WRH_Warehouse_2_QuantityLevel();
                        quantityLevelAssignment.AssignmentID = Guid.NewGuid();
                        quantityLevelAssignment.LOG_WRH_QuantityLevel_RefID = quantityLevel.LOG_WRH_QuantityLevelID;
                        quantityLevelAssignment.LOG_WRH_Warehouse_RefID = Parameter.WarehouseID;
                        quantityLevelAssignment.Tenant_RefID = securityTicket.TenantID;
                        quantityLevelAssignment.Creation_Timestamp = DateTime.Now;
                        quantityLevelAssignment.Save(Connection, Transaction);
                        return returnValue;
                    }
                    if (Parameter.AreaID != Guid.Empty)
                    {
                        ORM_LOG_WRH_Area_2_QuantityLevel quantityLevelAssignment = new ORM_LOG_WRH_Area_2_QuantityLevel();
                        quantityLevelAssignment.AssignmentID = Guid.NewGuid();
                        quantityLevelAssignment.LOG_WRH_QuantityLevel_RefID = quantityLevel.LOG_WRH_QuantityLevelID;
                        quantityLevelAssignment.LOG_WRH_Area_RefID = Parameter.AreaID;
                        quantityLevelAssignment.Tenant_RefID = securityTicket.TenantID;
                        quantityLevelAssignment.Creation_Timestamp = DateTime.Now;
                        quantityLevelAssignment.Save(Connection, Transaction);
                        return returnValue;
                    }
                    if (Parameter.GroupID != Guid.Empty)
                    {
                        ORM_LOG_WRH_Warehouse_Group_2_QuantityLevel quantityLevelAssignment = new ORM_LOG_WRH_Warehouse_Group_2_QuantityLevel();
                        quantityLevelAssignment.AssignmentID = Guid.NewGuid();
                        quantityLevelAssignment.LOG_WRH_QuantityLevel_RefID = quantityLevel.LOG_WRH_QuantityLevelID;
                        quantityLevelAssignment.LOG_WRH_Warehouse_Group_RefID = Parameter.GroupID;
                        quantityLevelAssignment.Tenant_RefID = securityTicket.TenantID;
                        quantityLevelAssignment.Creation_Timestamp = DateTime.Now;
                        quantityLevelAssignment.Save(Connection, Transaction);
                        return returnValue;
                    }
                    if (Parameter.RackID != Guid.Empty)
                    {
                        ORM_LOG_WRH_Rack_2_QuantityLevel quantityLevelAssignment = new ORM_LOG_WRH_Rack_2_QuantityLevel();
                        quantityLevelAssignment.AssignmentID = Guid.NewGuid();
                        quantityLevelAssignment.LOG_WRH_QuantityLevel_RefID = quantityLevel.LOG_WRH_QuantityLevelID;
                        quantityLevelAssignment.LOG_WRH_Rack_RefID = Parameter.RackID;
                        quantityLevelAssignment.Tenant_RefID = securityTicket.TenantID;
                        quantityLevelAssignment.Creation_Timestamp = DateTime.Now;
                        quantityLevelAssignment.Save(Connection, Transaction);
                        return returnValue;
                    }
                    if (Parameter.ShelfID != Guid.Empty)
                    {
                        ORM_LOG_WRH_Shelf_2_QuantityLevel quantityLevelAssignment = new ORM_LOG_WRH_Shelf_2_QuantityLevel();
                        quantityLevelAssignment.AssignmentID = Guid.NewGuid();
                        quantityLevelAssignment.LOG_WRH_QuantityLevel_RefID = quantityLevel.LOG_WRH_QuantityLevelID;
                        quantityLevelAssignment.LOG_WRH_Shelf_RefID = Parameter.ShelfID;
                        quantityLevelAssignment.Tenant_RefID = securityTicket.TenantID;
                        quantityLevelAssignment.Creation_Timestamp = DateTime.Now;
                        quantityLevelAssignment.Save(Connection, Transaction);
                        return returnValue;
                    }
                }
            }
            
            #endregion Make assignment

            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5AR_SASQL_1340 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5AR_SASQL_1340 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AR_SASQL_1340 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AR_SASQL_1340 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_ArticleStorageQuantityLevel",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5AR_SASQL_1340 for attribute P_L5AR_SASQL_1340
		[DataContract]
		public class P_L5AR_SASQL_1340 
		{
			//Standard type parameters
			[DataMember]
			public Guid QuantityLevelID { get; set; } 
			[DataMember]
			public Guid ArticleID { get; set; } 
			[DataMember]
			public Double MinimumQuantity { get; set; } 
			[DataMember]
			public Double MaximumQuantity { get; set; } 
			[DataMember]
			public Double RecommendedMinimumQuantity { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 
			[DataMember]
			public Boolean WarehouseLevelIsChanged { get; set; } 
			[DataMember]
			public Guid WarehouseID { get; set; } 
			[DataMember]
			public Guid AreaID { get; set; } 
			[DataMember]
			public Guid GroupID { get; set; } 
			[DataMember]
			public Guid ShelfID { get; set; } 
			[DataMember]
			public Guid RackID { get; set; } 
			[DataMember]
			public Guid? PredefinedLocationID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_ArticleStorageQuantityLevel(,P_L5AR_SASQL_1340 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_ArticleStorageQuantityLevel.Invoke(connectionString,P_L5AR_SASQL_1340 Parameter,securityTicket);
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
var parameter = new CL5_APOAdmin_Articles.Complex.Manipulation.P_L5AR_SASQL_1340();
parameter.QuantityLevelID = ...;
parameter.ArticleID = ...;
parameter.MinimumQuantity = ...;
parameter.MaximumQuantity = ...;
parameter.RecommendedMinimumQuantity = ...;
parameter.IsDeleted = ...;
parameter.WarehouseLevelIsChanged = ...;
parameter.WarehouseID = ...;
parameter.AreaID = ...;
parameter.GroupID = ...;
parameter.ShelfID = ...;
parameter.RackID = ...;
parameter.PredefinedLocationID = ...;

*/
