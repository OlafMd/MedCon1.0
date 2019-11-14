/* 
 * Generated on 8/1/2013 10:52:10 AM
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
using CL5_KPRS_Realestate.Atomic.Retrieval;

namespace CL5_KPRS_Realestate.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Realestates_For_Tenant_With_SearchParams.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Realestates_For_Tenant_With_SearchParams
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5RE_GREFTWSP_0846 Execute(DbConnection Connection,DbTransaction Transaction,P_L5RE_GREFTWSP_0846 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5RE_GREFTWSP_0846();


            L5RE_GREFT_1534[] allRealEstates = cls_Get_Realestates_For_Tenant.Invoke(Connection,Transaction,securityTicket).Result;


            if (Parameter.FromDate.Ticks != 0)
            {
                allRealEstates=allRealEstates.Where(i => i.Creation_Timestamp.Date >= Parameter.FromDate).ToArray();
            }
            if (Parameter.ToDate.Ticks != 0)
            {
                allRealEstates = allRealEstates.Where(i => i.Creation_Timestamp.Date <= Parameter.ToDate).ToArray();
            }
            if (Parameter.FirstName != "")
            {
                allRealEstates = allRealEstates.Where(i => i.FirstName.ToLower().Contains(Parameter.FirstName.ToLower())).ToArray();
            }
            if (Parameter.LastName != "")
            {
                allRealEstates = allRealEstates.Where(i => i.LastName.ToLower().Contains(Parameter.LastName.ToLower())).ToArray();
            }
            if (Parameter.Title != "")
            {
                allRealEstates = allRealEstates.Where(i => i.RealestateProperty_Title.ToLower().Contains(Parameter.Title.ToLower())).ToArray();
            }

            if (Parameter.IsArchived && !Parameter.IsLocked)
                allRealEstates = allRealEstates.Where(i => i.IsArchived == Parameter.IsArchived).ToArray();
            else if (!Parameter.IsArchived && Parameter.IsLocked)
                allRealEstates = allRealEstates.Where(i => i.IsLocked == Parameter.IsLocked).ToArray();
            else if (Parameter.IsArchived && Parameter.IsLocked)
                allRealEstates = allRealEstates.Where(i => i.IsArchived == Parameter.IsArchived || i.IsLocked == Parameter.IsLocked).ToArray();


            returnValue.Result = new L5RE_GREFTWSP_0846();
            returnValue.Result.RealestateProperties = allRealEstates;

			//Put your code here
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5RE_GREFTWSP_0846 Invoke(string ConnectionString,P_L5RE_GREFTWSP_0846 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5RE_GREFTWSP_0846 Invoke(DbConnection Connection,P_L5RE_GREFTWSP_0846 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5RE_GREFTWSP_0846 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5RE_GREFTWSP_0846 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5RE_GREFTWSP_0846 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5RE_GREFTWSP_0846 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5RE_GREFTWSP_0846 functionReturn = new FR_L5RE_GREFTWSP_0846();
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

				throw new Exception("Exception occured in method cls_Get_Realestates_For_Tenant_With_SearchParams",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5RE_GREFTWSP_0846_raw 
	{
		public L5RE_GREFT_1534[] RealestateProperties; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5RE_GREFTWSP_0846[] Convert(List<L5RE_GREFTWSP_0846_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5RE_GREFTWSP_0846 in gfunct_rawResult.ToArray()
	group el_L5RE_GREFTWSP_0846 by new 
	{ 
	}
	into gfunct_L5RE_GREFTWSP_0846
	select new L5RE_GREFTWSP_0846
	{     
		RealestateProperties = gfunct_L5RE_GREFTWSP_0846.FirstOrDefault().RealestateProperties ,

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5RE_GREFTWSP_0846 : FR_Base
	{
		public L5RE_GREFTWSP_0846 Result	{ get; set; }

		public FR_L5RE_GREFTWSP_0846() : base() {}

		public FR_L5RE_GREFTWSP_0846(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5RE_GREFTWSP_0846 for attribute P_L5RE_GREFTWSP_0846
		[DataContract]
		public class P_L5RE_GREFTWSP_0846 
		{
			//Standard type parameters
			[DataMember]
			public DateTime FromDate { get; set; } 
			[DataMember]
			public DateTime ToDate { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public String Title { get; set; } 
			[DataMember]
			public bool IsLocked { get; set; } 
			[DataMember]
			public bool IsArchived { get; set; } 

		}
		#endregion
		#region SClass L5RE_GREFTWSP_0846 for attribute L5RE_GREFTWSP_0846
		[DataContract]
		public class L5RE_GREFTWSP_0846 
		{
			//Standard type parameters
			[DataMember]
			public L5RE_GREFT_1534[] RealestateProperties { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5RE_GREFTWSP_0846 cls_Get_Realestates_For_Tenant_With_SearchParams(,P_L5RE_GREFTWSP_0846 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5RE_GREFTWSP_0846 invocationResult = cls_Get_Realestates_For_Tenant_With_SearchParams.Invoke(connectionString,P_L5RE_GREFTWSP_0846 Parameter,securityTicket);
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
var parameter = new CL5_KPRS_Realestate.Complex.Retrieval.P_L5RE_GREFTWSP_0846();
parameter.FromDate = ...;
parameter.ToDate = ...;
parameter.FirstName = ...;
parameter.LastName = ...;
parameter.Title = ...;
parameter.IsLocked = ...;
parameter.IsArchived = ...;

*/