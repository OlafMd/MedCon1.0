/* 
 * Generated on 7/8/2013 11:12:58 AM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Linq;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using CL1_HEC;

namespace CL5_Lucentis_Treatments.Atomic.Manipulation
{
	[Serializable]
	public class cls_Save_HEC_Patient_Treatment_RequiredProduct
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5TR_SRP_1317 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_Guid();

            foreach (var param in Parameter.Products) {

                var item = new ORM_HEC_Patient_Treatment_RequiredProduct();
                if (param.HEC_Patient_Treatment_RequiredProductID != Guid.Empty)
                {
                    var result = item.Load(Connection, Transaction, param.HEC_Patient_Treatment_RequiredProductID);
                    if (result.Status != FR_Status.Success || item.HEC_Patient_Treatment_RequiredProductID == Guid.Empty)
                    {
                        //Item doesn't exist, create it
                        param.HEC_Patient_Treatment_RequiredProductID = Guid.Empty;

                        if (param.IsDeleted)
                            continue;
                    }
                }

                if (param.IsDeleted == true)
                {
                    item.IsDeleted = true;
                    item.Save(Connection, Transaction);
                    continue;
                }

                //Creation specific parameters (Tenant, Account ... )
                if (param.HEC_Patient_Treatment_RequiredProductID == Guid.Empty)
                {
                    item.HEC_Patient_Treatment_RequiredProductID = Guid.NewGuid();
                    item.HEC_Patient_Treatment_RefID = param.HEC_Patient_Treatment_RefID;
                    item.HEC_Product_RefID = param.HEC_Product_RefID;
                    item.BoundTo_CustomerOrderPosition_RefID = Guid.Empty;
                    item.Tenant_RefID = securityTicket.TenantID;

                }

                item.ExpectedDateOfDelivery = param.ExpectedDateOfDelivery;
                item.ProductProvidingPharmacy_RefID = param.ProductProvidingPharmacy_RefID;
                item.Quantity = param.Quantity;

                item.Save(Connection, Transaction);
            }
            
            return returnValue;

			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5TR_SRP_1317 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5TR_SRP_1317 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5TR_SRP_1317 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5TR_SRP_1317 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5TR_SRP_1317 for attribute P_L5TR_SRP_1317
		[Serializable]
		public class P_L5TR_SRP_1317 
		{
			public P_L5TR_SRP_1317a[] Products;  

			//Standard type parameters
		}
		#endregion
		#region SClass P_L5TR_SRP_1317a for attribute Products
		[Serializable]
		public class P_L5TR_SRP_1317a 
		{
			//Standard type parameters
			public Guid HEC_Patient_Treatment_RequiredProductID; 
			public Guid HEC_Patient_Treatment_RefID; 
			public Guid HEC_Product_RefID; 
			public DateTime ExpectedDateOfDelivery; 
			public Guid ProductProvidingPharmacy_RefID; 
			public double Quantity; 
			public Boolean IsDeleted; 

		}
		#endregion

	#endregion
}
