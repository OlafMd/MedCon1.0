/* 
 * Generated on 9/8/2014 9:51:01 AM
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
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Runtime.Serialization;
using CL3_Warehouse.Atomic.Retrieval;
using CL1_LOG_WRH;
using System.Linq;
using System.Runtime.Serialization;
using CL1_LOG_WRH;
using CL3_Warehouse.Atomic.Retrieval;
using CSV2Core.Core;

namespace CL5_APOLogistic_Storage.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_StoragePlaces_with_Predefined.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_StoragePlaces_with_Predefined
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5SG_GSPwP_1825 Execute(DbConnection Connection,DbTransaction Transaction,P_L5SG_GSPwP_1825 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_L5SG_GSPwP_1825();
            returnValue.Result = new L5SG_GSPwP_1825();

            var filterCriteria = new P_L3WH_GSPfFC_1504()
            {
                WarehouseGroupID = Parameter.Warehouse_GroupID,
                WarehouseID = Parameter.WarehouseID,
                AreaID = Parameter.AreaID,
                RackID = Parameter.RackID,
                UseShelfIDList = Parameter.UseShelfList,
                ShelfIDs = Parameter.ShelfID_List,
                UseProductIDList = false,
                ProductIDs = new Guid[] { Guid.Empty },
                BottomShelfQuantity = (int?)Parameter.QuantityBottom,
                TopShelfQuantity = (int?)Parameter.QuantityTop,
                UseProductTrackingInstanceIDList = false,
                ProductTrackingInstanceIDs = new Guid[] { Guid.Empty },
                StartExpirationDate = null,
                EndExpirationDate = null
            };
            returnValue.Result.WareHouseStructure = cls_Get_StoragePlaces_for_FilterCriteria.Invoke(
                Connection,
                Transaction,
                filterCriteria,
                securityTicket).Result;
            
            if (Parameter.PredefinedProduct != null && Parameter.PredefinedProduct != Guid.Empty && Parameter.IsMultiSelect == false)
            {
                foreach (L3WH_GSPfFC_1504 whStructure in returnValue.Result.WareHouseStructure.Where(whStructure => whStructure.Predefined_Product_RefID == Parameter.PredefinedProduct))
                {
                    returnValue.Result.HasDefaultShelf = true;
                    returnValue.Result.ShelfID = whStructure.LOG_WRH_ShelfID;
                    return returnValue;
                }
            }

            // second case. Area has flag IsDefaultIntakeArea set to true
            foreach (L3WH_GSPfFC_1504 whStructure in returnValue.Result.WareHouseStructure)
            {
                if (whStructure.IsDefaultIntakeArea)
                {
                    var rack = ORM_LOG_WRH_Rack.Query.Search(Connection, Transaction, new ORM_LOG_WRH_Rack.Query
                    {
                        Area_RefID = whStructure.LOG_WRH_AreaID,
                        IsDeleted = false
                    }).FirstOrDefault();

                    if (rack != null)
                    {
                        var shelf =
                            ORM_LOG_WRH_Shelf.Query.Search(Connection, Transaction, new ORM_LOG_WRH_Shelf.Query
                            {
                                Rack_RefID = rack.LOG_WRH_RackID,
                                IsDeleted = false
                            }).FirstOrDefault();


                        if (shelf != null)
                        {
                            returnValue.Result.ShelfID = whStructure.LOG_WRH_ShelfID;


                            returnValue.Result.HasDefaultShelf = false;
                            return returnValue;
                        }
                    }
                }


            }

            // third case - no default settings at all
            returnValue.Result.HasDefaultShelf = false;
            returnValue.Result.ShelfID = null;

            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5SG_GSPwP_1825 Invoke(string ConnectionString,P_L5SG_GSPwP_1825 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5SG_GSPwP_1825 Invoke(DbConnection Connection,P_L5SG_GSPwP_1825 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5SG_GSPwP_1825 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5SG_GSPwP_1825 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5SG_GSPwP_1825 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5SG_GSPwP_1825 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5SG_GSPwP_1825 functionReturn = new FR_L5SG_GSPwP_1825();
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

				throw new Exception("Exception occured in method cls_Get_StoragePlaces_with_Predefined",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5SG_GSPwP_1825 : FR_Base
	{
		public L5SG_GSPwP_1825 Result	{ get; set; }

		public FR_L5SG_GSPwP_1825() : base() {}

		public FR_L5SG_GSPwP_1825(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5SG_GSPwP_1825 for attribute P_L5SG_GSPwP_1825
		[DataContract]
		public class P_L5SG_GSPwP_1825 
		{
			//Standard type parameters
			[DataMember]
			public Guid? PredefinedProduct { get; set; } 
			[DataMember]
			public bool IsMultiSelect { get; set; } 
			[DataMember]
			public Guid? Warehouse_GroupID { get; set; } 
			[DataMember]
			public Guid? WarehouseID { get; set; } 
			[DataMember]
			public Guid? AreaID { get; set; } 
			[DataMember]
			public Guid? RackID { get; set; } 
			[DataMember]
			public Guid? ShelfID { get; set; } 
			[DataMember]
			public bool UseShelfList { get; set; } 
			[DataMember]
			public Guid[] ShelfID_List { get; set; } 
			[DataMember]
			public float? QuantityTop { get; set; } 
			[DataMember]
			public float? QuantityBottom { get; set; } 

		}
		#endregion
		#region SClass L5SG_GSPwP_1825 for attribute L5SG_GSPwP_1825
		[DataContract]
		public class L5SG_GSPwP_1825 
		{
			//Standard type parameters
			[DataMember]
			public CL3_Warehouse.Atomic.Retrieval.L3WH_GSPfFC_1504[] WareHouseStructure { get; set; } 
			[DataMember]
			public bool HasDefaultShelf { get; set; } 
			[DataMember]
			public Guid? ShelfID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5SG_GSPwP_1825 cls_Get_StoragePlaces_with_Predefined(,P_L5SG_GSPwP_1825 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5SG_GSPwP_1825 invocationResult = cls_Get_StoragePlaces_with_Predefined.Invoke(connectionString,P_L5SG_GSPwP_1825 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_Storage.Complex.Retrieval.P_L5SG_GSPwP_1825();
parameter.PredefinedProduct = ...;
parameter.IsMultiSelect = ...;
parameter.Warehouse_GroupID = ...;
parameter.WarehouseID = ...;
parameter.AreaID = ...;
parameter.RackID = ...;
parameter.ShelfID = ...;
parameter.UseShelfList = ...;
parameter.ShelfID_List = ...;
parameter.QuantityTop = ...;
parameter.QuantityBottom = ...;

*/