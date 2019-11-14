/* 
 * Generated on 12/11/2013 2:22:23 PM
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
using CL1_CMN_SLS;

namespace CL5_APOAdmin_Articles.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Price_for_ArticleID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Price_for_ArticleID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5AR_SPfAID_1347 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode
            var returnValue = new FR_Guid();
			//Put your code here

            var price = new ORM_CMN_SLS_Price();

            //edit
            if (Parameter.CMN_SLS_PriceID != Guid.Empty)
            {
                var priceLoaded = price.Load(Connection, Transaction, Parameter.CMN_SLS_PriceID);
                if (priceLoaded.Status != FR_Status.Success)
                {
                    return new FR_Guid("Not exist", FR_Status.Error_Internal);
                }
            }

            
            //fill price properties
            price.PricelistRelease_RefID = Parameter.PricelistRelease_RefID;
            price.CMN_PRO_Product_RefID = Parameter.CMN_PRO_Product_RefID;
            price.PriceAmount = Parameter.PriceAmount;

            returnValue = new FR_Guid(price.Save(Connection, Transaction), price.CMN_SLS_PriceID);

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5AR_SPfAID_1347 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5AR_SPfAID_1347 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AR_SPfAID_1347 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AR_SPfAID_1347 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Price_for_ArticleID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5AR_SPfAID_1347 for attribute P_L5AR_SPfAID_1347
		[DataContract]
		public class P_L5AR_SPfAID_1347 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_SLS_PriceID { get; set; } 
			[DataMember]
			public Guid CMN_PRO_Product_RefID { get; set; } 
			[DataMember]
			public Guid PricelistRelease_RefID { get; set; } 
			[DataMember]
			public Decimal PriceAmount { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Price_for_ArticleID(,P_L5AR_SPfAID_1347 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Price_for_ArticleID.Invoke(connectionString,P_L5AR_SPfAID_1347 Parameter,securityTicket);
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
var parameter = new CL5_APOAdmin_Articles.Atomic.Manipulation.P_L5AR_SPfAID_1347();
parameter.CMN_SLS_PriceID = ...;
parameter.CMN_PRO_Product_RefID = ...;
parameter.PricelistRelease_RefID = ...;
parameter.PriceAmount = ...;
parameter.IsDeleted = ...;

*/
