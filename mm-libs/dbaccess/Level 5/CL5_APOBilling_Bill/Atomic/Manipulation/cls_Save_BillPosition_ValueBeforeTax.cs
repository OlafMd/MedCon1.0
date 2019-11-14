/* 
 * Generated on 24/9/2014 01:34:12
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
using System.Runtime.Serialization;
using DLUtils_Common.Calculations;
using System.Collections.Generic;
using System.Linq;
using CL5_APOBilling_Bill.Complex;
using CL5_APOBilling_Bill.Complex.Retrieval;

namespace CL5_APOBilling_Bill.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_BillPosition_ValueBeforeTax.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_BillPosition_ValueBeforeTax
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Bool Execute(DbConnection Connection,DbTransaction Transaction,P_L5BL_SBPVBT_1153 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Bool();
			//Put your code here

            foreach(var position in Parameter.BillPositions)
            {
                var billPosition = new CL1_BIL.ORM_BIL_BillPosition();
                billPosition.Load(Connection, Transaction, position.BillPositionID);

                if (billPosition != null)
                {
                    billPosition.PositionPricePerUnitValue_BeforeTax =  position.ChangedPrice;
                    billPosition.PositionValue_BeforeTax = position.ChangedPrice * billPosition.Quantity;


                    var tax = CL1_ACC_TAX.ORM_ACC_TAX_Tax.Query.Search(Connection, Transaction , new CL1_ACC_TAX.ORM_ACC_TAX_Tax.Query
                    {
                        ACC_TAX_TaxeID = billPosition.ApplicableSalesTax_RefID,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).SingleOrDefault();
                    if (tax != null)
                    {
                        billPosition.PositionPricePerUnitValue_IncludingTax = MoneyUtils.CalculateGrossPriceForTaxInPercent(position.ChangedPrice, (decimal)tax.TaxRate);
                        billPosition.PositionValue_IncludingTax = billPosition.PositionPricePerUnitValue_IncludingTax * billPosition.Quantity;
                    }

                    billPosition.Save(Connection, Transaction);

                    var billHeader = new CL1_BIL.ORM_BIL_BillHeader();
                    billHeader.Load(Connection, Transaction, billPosition.BIL_BilHeader_RefID);

                    var allPositionsForHeader = CL5_APOBilling_Bill.Complex.Retrieval.cls_Get_BillPositions_with_Articles_for_BillHeader.Invoke(Connection, Transaction, new P_L5BL_GBPwAfBH_1848 { BillHeaderID = billHeader.BIL_BillHeaderID }, securityTicket).Result;
                    var billSumIncludeTax = allPositionsForHeader.Sum( x => x.BillPosition.PositionValue_IncludingTax);
                    var billSumBeforeTax = allPositionsForHeader.Sum( x => x.BillPosition.PositionValue_BeforeTax);

                    billHeader.TotalValue_BeforeTax =  billSumBeforeTax;
                    billHeader.TotalValue_IncludingTax = billSumIncludeTax;

                    billHeader.Save(Connection, Transaction);

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
		public static FR_Bool Invoke(string ConnectionString,P_L5BL_SBPVBT_1153 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection,P_L5BL_SBPVBT_1153 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction,P_L5BL_SBPVBT_1153 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5BL_SBPVBT_1153 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Bool functionReturn = new FR_Bool();
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

				throw new Exception("Exception occured in method cls_Save_BillPosition_ValueBeforeTax",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5BL_SBPVBT_1153 for attribute P_L5BL_SBPVBT_1153
		[DataContract]
		public class P_L5BL_SBPVBT_1153 
		{
			[DataMember]
			public P_L5BL_SBPVBT_1153a[] BillPositions { get; set; }

			//Standard type parameters
		}
		#endregion
		#region SClass P_L5BL_SBPVBT_1153a for attribute BillPositions
		[DataContract]
		public class P_L5BL_SBPVBT_1153a 
		{
			//Standard type parameters
			[DataMember]
			public Guid BillPositionID { get; set; } 
			[DataMember]
			public decimal ChangedPrice { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Bool cls_Save_BillPosition_ValueBeforeTax(,P_L5BL_SBPVBT_1153 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Bool invocationResult = cls_Save_BillPosition_ValueBeforeTax.Invoke(connectionString,P_L5BL_SBPVBT_1153 Parameter,securityTicket);
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
var parameter = new CL5_APOBilling_Bill.Atomic.Manipulation.P_L5BL_SBPVBT_1153();
parameter.BillPositions = ...;


*/
