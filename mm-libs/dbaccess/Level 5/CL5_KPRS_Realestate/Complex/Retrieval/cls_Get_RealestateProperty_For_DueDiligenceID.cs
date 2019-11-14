/* 
 * Generated on 8/15/2013 11:53:48 AM
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
using CL1_RES_DUD;

namespace CL5_KPRS_Realestate.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_RealestateProperty_For_DueDiligenceID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_RealestateProperty_For_DueDiligenceID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5RP_GRPFDD_1148 Execute(DbConnection Connection,DbTransaction Transaction,P_L5RP_GRPFDD_1148 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
            var returnValue = new FR_L5RP_GRPFDD_1148();

            ORM_RES_DUD_RevisionGroup.Query revisionGroup = new ORM_RES_DUD_RevisionGroup.Query();
            revisionGroup.RES_DUD_Revision_GroupID = Parameter.DueDiligenceID;
            revisionGroup.Tenant_RefID = securityTicket.TenantID;
            revisionGroup.IsDeleted = false;
            returnValue.Result = new L5RP_GRPFDD_1148();
            returnValue.Result.RES_RealestatePropertyID = ORM_RES_DUD_RevisionGroup.Query.Search(Connection, Transaction, revisionGroup).FirstOrDefault().RealestateProperty_RefID;
		
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5RP_GRPFDD_1148 Invoke(string ConnectionString,P_L5RP_GRPFDD_1148 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5RP_GRPFDD_1148 Invoke(DbConnection Connection,P_L5RP_GRPFDD_1148 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5RP_GRPFDD_1148 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5RP_GRPFDD_1148 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5RP_GRPFDD_1148 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5RP_GRPFDD_1148 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5RP_GRPFDD_1148 functionReturn = new FR_L5RP_GRPFDD_1148();
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

				throw new Exception("Exception occured in method cls_Get_RealestateProperty_For_DueDiligenceID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5RP_GRPFDD_1148_raw 
	{
		public Guid RES_RealestatePropertyID; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5RP_GRPFDD_1148[] Convert(List<L5RP_GRPFDD_1148_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5RP_GRPFDD_1148 in gfunct_rawResult.ToArray()
	group el_L5RP_GRPFDD_1148 by new 
	{ 
	}
	into gfunct_L5RP_GRPFDD_1148
	select new L5RP_GRPFDD_1148
	{     
		RES_RealestatePropertyID = gfunct_L5RP_GRPFDD_1148.FirstOrDefault().RES_RealestatePropertyID ,

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5RP_GRPFDD_1148 : FR_Base
	{
		public L5RP_GRPFDD_1148 Result	{ get; set; }

		public FR_L5RP_GRPFDD_1148() : base() {}

		public FR_L5RP_GRPFDD_1148(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5RP_GRPFDD_1148 for attribute P_L5RP_GRPFDD_1148
		[DataContract]
		public class P_L5RP_GRPFDD_1148 
		{
			//Standard type parameters
			[DataMember]
			public Guid DueDiligenceID { get; set; } 

		}
		#endregion
		#region SClass L5RP_GRPFDD_1148 for attribute L5RP_GRPFDD_1148
		[DataContract]
		public class L5RP_GRPFDD_1148 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_RealestatePropertyID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5RP_GRPFDD_1148 cls_Get_RealestateProperty_For_DueDiligenceID(,P_L5RP_GRPFDD_1148 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5RP_GRPFDD_1148 invocationResult = cls_Get_RealestateProperty_For_DueDiligenceID.Invoke(connectionString,P_L5RP_GRPFDD_1148 Parameter,securityTicket);
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
var parameter = new CL5_KPRS_Realestate.Complex.Retrieval.P_L5RP_GRPFDD_1148();
parameter.DueDiligenceID = ...;

*/