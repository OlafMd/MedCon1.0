/* 
 * Generated on 3/6/2014 09:51:50
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
using CL1_LOG_WRH_INJ;

namespace CL5_APOLogistic_Inventory.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Inventory_Job_Series.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Inventory_Job_Series
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5IJ_SIJS_0944 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here

            if (Parameter.ID != null && Parameter.ID != Guid.Empty)
            {
                ORM_LOG_WRH_INJ_InventoryJob_Series.Query invJobSeriesQuery = new ORM_LOG_WRH_INJ_InventoryJob_Series.Query();
                invJobSeriesQuery.IsDeleted = false;
                invJobSeriesQuery.Tenant_RefID = securityTicket.TenantID;
                invJobSeriesQuery.LOG_WRH_INJ_InventoryJob_SeriesID = Parameter.ID;
                ORM_LOG_WRH_INJ_InventoryJob_Series invJobSeries = ORM_LOG_WRH_INJ_InventoryJob_Series.Query.Search(Connection, Transaction, invJobSeriesQuery).Single();

                invJobSeries.InventoryJobSeries_DisplayName = Parameter.DisplayName;
                invJobSeries.IsUsingNumberOfProductsSeriesType = Parameter.IsUsingNumber;
                if (Parameter.IsUsingNumber)
                {
                    invJobSeries.NumberOfProductsToSelect = Parameter.Number;
                }

                ORM_LOG_WRH_INJ_InventoryJob_Series_Rythm.Query invJobSeriesRythmsQuery = new ORM_LOG_WRH_INJ_InventoryJob_Series_Rythm.Query();
                invJobSeriesRythmsQuery.IsDeleted = false;
                invJobSeriesRythmsQuery.Tenant_RefID = securityTicket.TenantID;
                invJobSeriesRythmsQuery.InventoryJob_Series_RefID = invJobSeries.LOG_WRH_INJ_InventoryJob_SeriesID;
                ORM_LOG_WRH_INJ_InventoryJob_Series_Rythm invJobSeriesRythms = ORM_LOG_WRH_INJ_InventoryJob_Series_Rythm.Query.Search(Connection, Transaction, invJobSeriesRythmsQuery).Single();

                invJobSeriesRythms.RythmCronExpression = Parameter.RythmCronExpression;

                ORM_LOG_WRH_INJ_InventoryJob_Series_ParticipatingShelf.Query existingShelvesQuery = new ORM_LOG_WRH_INJ_InventoryJob_Series_ParticipatingShelf.Query();
                existingShelvesQuery.Tenant_RefID = securityTicket.TenantID;
                existingShelvesQuery.IsDeleted = false;
                existingShelvesQuery.LOG_WRH_INJ_InventoryJob_Series_RefID = Parameter.ID;
                List<ORM_LOG_WRH_INJ_InventoryJob_Series_ParticipatingShelf> existingShelves = ORM_LOG_WRH_INJ_InventoryJob_Series_ParticipatingShelf.Query.Search(Connection, Transaction, existingShelvesQuery);

                List<Guid> shelfIDs = existingShelves.Select(x => x.LOG_WRH_Shelf_RefID).ToList();

                List<Guid> listForDeleting = shelfIDs.Except(Parameter.ShelfList).ToList();
                List<Guid> listForAdding = Parameter.ShelfList.Except(shelfIDs).ToList();

                #region remove shelves

                foreach (var item in listForDeleting)
                {
                    ORM_LOG_WRH_INJ_InventoryJob_Series_ParticipatingShelf shelfToDelete = existingShelves.Single(x => x.LOG_WRH_Shelf_RefID == item);
                    shelfToDelete.IsDeleted = true;
                    shelfToDelete.Save(Connection, Transaction);
                }

                #endregion

                #region add shelves

                foreach (var item in listForAdding)
                {
                    ORM_LOG_WRH_INJ_InventoryJob_Series_ParticipatingShelf shelfToAdd = new ORM_LOG_WRH_INJ_InventoryJob_Series_ParticipatingShelf();
                    shelfToAdd.IsDeleted = false;
                    shelfToAdd.Tenant_RefID = securityTicket.TenantID;
                    shelfToAdd.LOG_WRH_INJ_InventoryJob_Series_ParticipatingShelfID = Guid.NewGuid();
                    shelfToAdd.LOG_WRH_INJ_InventoryJob_Series_RefID = Parameter.ID;
                    shelfToAdd.LOG_WRH_Shelf_RefID = item;
                    shelfToAdd.Creation_Timestamp = DateTime.Now;
                    shelfToAdd.Save(Connection, Transaction);
                }
                #endregion

                invJobSeries.Save(Connection, Transaction);
                invJobSeriesRythms.Save(Connection, Transaction);
            }
            else
            {
                ORM_LOG_WRH_INJ_InventoryJob_Series newInventoryJobSeries = new ORM_LOG_WRH_INJ_InventoryJob_Series();
                newInventoryJobSeries.IsDeleted = false;
                newInventoryJobSeries.Tenant_RefID = securityTicket.TenantID;
                newInventoryJobSeries.Creation_Timestamp = DateTime.Now;
                newInventoryJobSeries.LOG_WRH_INJ_InventoryJob_SeriesID = Guid.NewGuid();
                newInventoryJobSeries.IsUsingNumberOfProductsSeriesType = Parameter.IsUsingNumber;
                newInventoryJobSeries.NumberOfProductsToSelect = Parameter.Number;
                newInventoryJobSeries.InventoryJobSeries_DisplayName = Parameter.DisplayName;
                newInventoryJobSeries.Save(Connection, Transaction);

                ORM_LOG_WRH_INJ_InventoryJob_Series_Rythm newInventoryJobSeriesRythm = new ORM_LOG_WRH_INJ_InventoryJob_Series_Rythm();
                newInventoryJobSeriesRythm.IsDeleted = false;
                newInventoryJobSeriesRythm.Creation_Timestamp = DateTime.Now;
                newInventoryJobSeriesRythm.Tenant_RefID = securityTicket.TenantID;
                newInventoryJobSeriesRythm.LOG_WRH_INJ_InventoryJob_Series_RythmID = Guid.NewGuid();
                newInventoryJobSeriesRythm.InventoryJob_Series_RefID = newInventoryJobSeries.LOG_WRH_INJ_InventoryJob_SeriesID;
                newInventoryJobSeriesRythm.RythmCronExpression = Parameter.RythmCronExpression;
                newInventoryJobSeriesRythm.Save(Connection, Transaction);

                foreach(var shelf in Parameter.ShelfList)
                {
                    ORM_LOG_WRH_INJ_InventoryJob_Series_ParticipatingShelf newParticipatingShelf = new ORM_LOG_WRH_INJ_InventoryJob_Series_ParticipatingShelf();
                    newParticipatingShelf.IsDeleted = false;
                    newParticipatingShelf.Creation_Timestamp = DateTime.Now;
                    newParticipatingShelf.Tenant_RefID = securityTicket.TenantID;
                    newParticipatingShelf.LOG_WRH_INJ_InventoryJob_Series_ParticipatingShelfID = Guid.NewGuid();
                    newParticipatingShelf.LOG_WRH_INJ_InventoryJob_Series_RefID = newInventoryJobSeries.LOG_WRH_INJ_InventoryJob_SeriesID;
                    newParticipatingShelf.LOG_WRH_Shelf_RefID = shelf;
                    newParticipatingShelf.Save(Connection, Transaction);
                }
            }



			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5IJ_SIJS_0944 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5IJ_SIJS_0944 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5IJ_SIJS_0944 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5IJ_SIJS_0944 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Inventory_Job_Series",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5IJ_SIJS_0944 for attribute P_L5IJ_SIJS_0944
		[DataContract]
		public class P_L5IJ_SIJS_0944 
		{
			//Standard type parameters
			[DataMember]
			public Guid ID { get; set; } 
			[DataMember]
			public string DisplayName { get; set; } 
			[DataMember]
			public bool IsUsingNumber { get; set; } 
			[DataMember]
			public int Number { get; set; } 
			[DataMember]
			public string RythmCronExpression { get; set; } 
			[DataMember]
			public Guid[] ShelfList { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Inventory_Job_Series(,P_L5IJ_SIJS_0944 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Inventory_Job_Series.Invoke(connectionString,P_L5IJ_SIJS_0944 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_Inventory.Complex.Manipulation.P_L5IJ_SIJS_0944();
parameter.ID = ...;
parameter.DisplayName = ...;
parameter.IsUsingNumber = ...;
parameter.Number = ...;
parameter.RythmCronExpression = ...;
parameter.ShelfList = ...;

*/
