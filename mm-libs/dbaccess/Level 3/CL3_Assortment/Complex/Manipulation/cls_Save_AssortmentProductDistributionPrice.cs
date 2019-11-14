/* 
 * Generated on 11/29/2014 8:41:52 PM
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
using CL1_CMN;

namespace CL3_Assortment.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_AssortmentProductDistributionPrice.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_AssortmentProductDistributionPrice
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Base Execute(DbConnection Connection,DbTransaction Transaction,P_L3AS_SAPDP_1928[] Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Base();
            foreach (var distributionPrice in Parameter)
            {
                
                    foreach (var distributionPriceValue in distributionPrice.DistributionPriceValues.Where(x=>x.IsAssigned==false))
                    {

                        ORM_CMN_PRO_ASS_DistributionPrice_Value distributionPriceValueToDelete = new ORM_CMN_PRO_ASS_DistributionPrice_Value();
                        FR_Base distributionPriceValueLoad = distributionPriceValueToDelete.Load(Connection, Transaction, distributionPriceValue.CMN_PRO_ASS_DistributionPrice_ValueID);
                        if (distributionPriceValueLoad.Status == FR_Status.Success && distributionPriceValueToDelete.CMN_PRO_ASS_DistributionPrice_ValueID != Guid.Empty)
                        {
                            distributionPriceValueToDelete.IsDeleted = true;
                            distributionPriceValueToDelete.Save(Connection, Transaction);
                        }
                        ORM_CMN_Price priceToCreateToDelete = new ORM_CMN_Price();

                        FR_Base loadPriceToDelete = priceToCreateToDelete.Load(Connection, Transaction, distributionPriceValueToDelete.CMN_Price_RefID);
                        if (loadPriceToDelete.Status == FR_Status.Success && priceToCreateToDelete.CMN_PriceID != Guid.Empty)
                        {
                            priceToCreateToDelete.IsDeleted = true;
                            priceToCreateToDelete.Save(Connection, Transaction);
                        }
                        foreach (var priceValues in distributionPriceValue.Prices)
                        {

                            ORM_CMN_Price_Value priceValueToDelete = new ORM_CMN_Price_Value();
                            FR_Base loadPriceValue = priceValueToDelete.Load(Connection, Transaction, priceValues.CMN_Price_ValueID);
                            if (loadPriceValue.Status != FR_Status.Success  && priceValueToDelete.CMN_Price_ValueID == Guid.Empty)
                            {
                                priceValueToDelete.IsDeleted = true;
                                priceToCreateToDelete.Save(Connection, Transaction);
                            }
                        }
                    
                }
                
                    foreach (var distributionPriceValue in distributionPrice.DistributionPriceValues.Where(x=>x.IsAssigned==true))
                    {
                        bool createNewDistributionPriceValue = false;
                        bool pricesExists = true;
                        ORM_CMN_PRO_ASS_DistributionPrice_Value distributionPriceValueToCreateUpdate = new ORM_CMN_PRO_ASS_DistributionPrice_Value();
                        FR_Base distributionPriceLoad = distributionPriceValueToCreateUpdate.Load(Connection, Transaction, distributionPriceValue.CMN_PRO_ASS_DistributionPrice_ValueID);
                        if (distributionPriceLoad.Status != FR_Status.Success || distributionPriceValueToCreateUpdate.CMN_PRO_ASS_DistributionPrice_ValueID == Guid.Empty)
                        {
                            createNewDistributionPriceValue = true;
                        }
                      
                        if (distributionPriceValue.Prices != null)
                        {
                            if (distributionPriceValue.Prices.Where(x => x.PriceValue_Amount > 0).Count() == 0 && !distributionPriceValue.IsDefault)
                            {
                                pricesExists = false;
                                if (!createNewDistributionPriceValue)
                                {
                                    distributionPriceValueToCreateUpdate.IsDeleted = true;
                                    distributionPriceValueToCreateUpdate.Save(Connection, Transaction);
                                }
                            }
                        }
                        else
                        {
                            pricesExists = false;
                            
                        }

                       // if (pricesExists)
                        //{
                            if (createNewDistributionPriceValue)
                            {
                                distributionPriceValueToCreateUpdate.CMN_PRO_ASS_DistributionPrice_ValueID = distributionPriceValue.CMN_PRO_ASS_DistributionPrice_ValueID;


                            }
                            distributionPriceValueToCreateUpdate.DistributionPrice_RefID = distributionPrice.CMN_PRO_ASS_DistributionPriceID;
                            distributionPriceValueToCreateUpdate.CMN_Price_RefID = (pricesExists == false) ? Guid.Empty : distributionPriceValue.CMN_Price_RefID;
                            distributionPriceValueToCreateUpdate.Tenant_RefID = securityTicket.TenantID;
                            distributionPriceValueToCreateUpdate.IsDeleted = false;
                            distributionPriceValueToCreateUpdate.DefaultPointValue = distributionPriceValue.DefaultPointValue;
                            distributionPriceValueToCreateUpdate.ValidFrom = distributionPriceValue.ValidFrom;
                            distributionPriceValueToCreateUpdate.ValidThrough = distributionPriceValue.ValidThrough;


                        //}
                        if (distributionPriceValueToCreateUpdate.DistributionPrice_RefID != Guid.Empty)
                            distributionPriceValueToCreateUpdate.Save(Connection, Transaction);

                        ORM_CMN_Price priceToCreateUpdate = new ORM_CMN_Price();
                        bool createNewPrice = false;
                        if (distributionPriceValueToCreateUpdate.CMN_Price_RefID != Guid.Empty)
                        {
                            FR_Base loadPrice = priceToCreateUpdate.Load(Connection, Transaction, distributionPriceValueToCreateUpdate.CMN_Price_RefID);
                            if (loadPrice.Status != FR_Status.Success || priceToCreateUpdate.CMN_PriceID == Guid.Empty)
                            {
                                createNewPrice = true;
                            }
                            if (pricesExists)
                            {
                                if (createNewPrice)
                                {
                                    priceToCreateUpdate.CMN_PriceID = distributionPriceValue.CMN_Price_RefID;

                                    priceToCreateUpdate.IsDeleted = false;

                                }
                                priceToCreateUpdate.IsDeleted = false;
                                priceToCreateUpdate.Tenant_RefID = securityTicket.TenantID;

                            }
                            else
                            {
                                priceToCreateUpdate.IsDeleted = true;

                            }
                            if (priceToCreateUpdate.CMN_PriceID != Guid.Empty)
                                priceToCreateUpdate.Save(Connection, Transaction);

                            foreach (var priceValues in distributionPriceValue.Prices)
                            {
                                bool createNewPriceValue = false;
                                bool hasPrice = false;
                                ORM_CMN_Price_Value priceValueToCreateUpdate = new ORM_CMN_Price_Value();
                                FR_Base loadPriceValue = priceValueToCreateUpdate.Load(Connection, Transaction, priceValues.CMN_Price_ValueID);
                                if (loadPriceValue.Status != FR_Status.Success || priceValueToCreateUpdate.CMN_Price_ValueID == Guid.Empty)
                                {
                                    createNewPriceValue = true;
                                }
                                if (priceValues.PriceValue_Amount > 0)
                                {
                                    hasPrice = true;
                                }
                                if (distributionPriceValue.IsDefault)
                                { hasPrice = true; }
                                if (!hasPrice && !createNewPriceValue)
                                {
                                    priceValueToCreateUpdate.IsDeleted = true;
                                }
                                else if (hasPrice)
                                {
                                    if (createNewPriceValue)
                                    {
                                        priceValueToCreateUpdate.CMN_Price_ValueID = priceValues.CMN_Price_ValueID;

                                    }
                                    priceValueToCreateUpdate.Price_RefID = priceToCreateUpdate.CMN_PriceID;
                                    priceValueToCreateUpdate.PriceValue_Currency_RefID = priceValues.DefaultCurrency_RefID;
                                    priceValueToCreateUpdate.Tenant_RefID = securityTicket.TenantID;
                                    priceValueToCreateUpdate.IsDeleted = false;
                                    priceValueToCreateUpdate.PriceValue_Amount = Double.Parse(priceValues.PriceValue_Amount.ToString());
                                }
                                if (priceValueToCreateUpdate.CMN_Price_ValueID != Guid.Empty)
                                {
                                    priceValueToCreateUpdate.Save(Connection, Transaction);
                                }
                            }
                        }
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
		public static FR_Base Invoke(string ConnectionString,P_L3AS_SAPDP_1928[] Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection,P_L3AS_SAPDP_1928[] Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction,P_L3AS_SAPDP_1928[] Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3AS_SAPDP_1928[] Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Base functionReturn = new FR_Base();
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

				throw new Exception("Exception occured in method cls_Save_AssortmentProductDistributionPrice",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3AS_SAPDP_1928[] for attribute P_L3AS_SAPDP_1928[]
		[DataContract]
		public class P_L3AS_SAPDP_1928
		{
			[DataMember]
			public P_L3AS_SAPDP_1928a[] DistributionPriceValues { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_ASS_DistributionPriceID { get; set; } 

		}
		#endregion
		#region SClass P_L3AS_SAPDP_1928a for attribute DistributionPriceValues
		[DataContract]
		public class P_L3AS_SAPDP_1928a 
		{
			[DataMember]
			public P_L3AS_SAPDP_1928b[] Prices { get; set; }

			//Standard type parameters
			[DataMember]
			public bool IsAssigned { get; set; }
            [DataMember]
            public bool IsDefault { get; set; } 
			[DataMember]
			public Guid CMN_PRO_ASS_DistributionPrice_ValueID { get; set; } 
			[DataMember]
			public double DefaultPointValue { get; set; } 
			[DataMember]
			public DateTime ValidFrom { get; set; } 
			[DataMember]
			public DateTime ValidThrough { get; set; } 
			[DataMember]
			public Guid CMN_Price_RefID { get; set; } 

		}
		#endregion
		#region SClass P_L3AS_SAPDP_1928b for attribute Prices
		[DataContract]
		public class P_L3AS_SAPDP_1928b 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_Price_ValueID { get; set; } 
			[DataMember]
			public Guid DefaultCurrency_RefID { get; set; } 
			[DataMember]
			public Decimal PriceValue_Amount { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Base cls_Save_AssortmentProductDistributionPrice(,P_L3AS_SAPDP_1928 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Base invocationResult = cls_Save_AssortmentProductDistributionPrice.Invoke(connectionString,P_L3AS_SAPDP_1928 Parameter,securityTicket);
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
var parameter = new CL3_Assortment.Complex.Manipulation.P_L3AS_SAPDP_1928();
parameter.DistributionPriceValues = ...;

parameter.CMN_PRO_ASS_DistributionPriceID = ...;

*/
