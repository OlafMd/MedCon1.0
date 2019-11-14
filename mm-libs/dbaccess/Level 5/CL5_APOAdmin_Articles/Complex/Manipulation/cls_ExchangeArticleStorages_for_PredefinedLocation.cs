/* 
 * Generated on 09/08/2014 15:13:15
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
using CSV2Core.Core;
using System.Runtime.Serialization;
using CL1_LOG_WRH;

namespace CL5_APOAdmin_Articles.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_ExchangeArticleStorages_for_PredefinedLocation.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_ExchangeArticleStorages_for_PredefinedLocation
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Bool Execute(DbConnection Connection,DbTransaction Transaction,P_L5AR_EASfPL_1301 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Bool();
			//Put your code here
            returnValue.Result = false;

            var firstPredefinedLocation = ORM_LOG_WRH_Shelf_PredefinedProductLocation.Query.Search(Connection, Transaction, new ORM_LOG_WRH_Shelf_PredefinedProductLocation.Query
            {
                LOG_WRH_Shelf_PredefinedProductLocationID = Parameter.FirstPredefinedLocationID
            }).SingleOrDefault();


            var secondPredefinedLocation = ORM_LOG_WRH_Shelf_PredefinedProductLocation.Query.Search(Connection, Transaction, new ORM_LOG_WRH_Shelf_PredefinedProductLocation.Query
            {
                LOG_WRH_Shelf_PredefinedProductLocationID = Parameter.SecondPredefinedLocationID
            }).SingleOrDefault();

            var tempLocationPriority = firstPredefinedLocation.LocationPriority;


            firstPredefinedLocation.LocationPriority = secondPredefinedLocation.LocationPriority;
            secondPredefinedLocation.LocationPriority = tempLocationPriority;


            firstPredefinedLocation.Save(Connection, Transaction);
            secondPredefinedLocation.Save(Connection, Transaction);

            returnValue.Result = true;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Bool Invoke(string ConnectionString,P_L5AR_EASfPL_1301 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection,P_L5AR_EASfPL_1301 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AR_EASfPL_1301 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AR_EASfPL_1301 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_ExchangeArticleStorages_for_PredefinedLocation",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5AR_EASfPL_1301 for attribute P_L5AR_EASfPL_1301
		[DataContract]
		public class P_L5AR_EASfPL_1301 
		{
			//Standard type parameters
			[DataMember]
			public Guid FirstPredefinedLocationID { get; set; } 
			[DataMember]
			public int FirstPredefinedLocation { get; set; } 
			[DataMember]
			public Guid SecondPredefinedLocationID { get; set; } 
			[DataMember]
			public int SecondPredefinedLocation { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Bool cls_ExchangeArticleStorages_for_PredefinedLocation(,P_L5AR_EASfPL_1301 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Bool invocationResult = cls_ExchangeArticleStorages_for_PredefinedLocation.Invoke(connectionString,P_L5AR_EASfPL_1301 Parameter,securityTicket);
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
var parameter = new CL5_APOAdmin_Articles.Complex.Manipulation.P_L5AR_EASfPL_1301();
parameter.FirstPredefinedLocationID = ...;
parameter.FirstPredefinedLocation = ...;
parameter.SecondPredefinedLocationID = ...;
parameter.SecondPredefinedLocation = ...;

*/
