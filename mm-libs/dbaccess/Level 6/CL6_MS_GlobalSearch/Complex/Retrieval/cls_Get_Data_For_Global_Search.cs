/* 
 * Generated on 7/23/2013 2:32:16 PM
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
using CL6_MS_Patient.Atomic.Retrieval;

namespace CL6_MS_GlobalSearch.Complex.Retrieval
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Data_For_Global_Search.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Data_For_Global_Search
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6GL_MSGDFGS_0944 Execute(DbConnection Connection,DbTransaction Transaction,P_L6GL_MSGDFGS_0944 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_L6GL_MSGDFGS_0944();

            Parameter.Term = Parameter.Term.ToLower();

            P_L6PA_GMSPSIfT_1542 param = new P_L6PA_GMSPSIfT_1542();
            param.IncludeOnlyConfirmedPolicy = false;
            var allPatients = cls_Get_MS_PatientsSimpleInfo_for_Tenant.Invoke(Connection, Transaction, param, securityTicket).Result;

            var filteredPatients = allPatients.Where(i => i.FirstName != null && i.LastName != null)
                    .Where(p => p.FirstName.ToLower().Contains(Parameter.Term) || p.LastName.ToLower().Contains(Parameter.Term));

            returnValue.Result = new L6GL_MSGDFGS_0944();
            returnValue.Result.Patients = filteredPatients.ToArray();

            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6GL_MSGDFGS_0944 Invoke(string ConnectionString,P_L6GL_MSGDFGS_0944 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6GL_MSGDFGS_0944 Invoke(DbConnection Connection,P_L6GL_MSGDFGS_0944 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6GL_MSGDFGS_0944 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6GL_MSGDFGS_0944 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6GL_MSGDFGS_0944 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6GL_MSGDFGS_0944 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6GL_MSGDFGS_0944 functionReturn = new FR_L6GL_MSGDFGS_0944();
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

				throw new Exception("Exception occured in method cls_Get_Data_For_Global_Search",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6GL_MSGDFGS_0944 : FR_Base
	{
		public L6GL_MSGDFGS_0944 Result	{ get; set; }

		public FR_L6GL_MSGDFGS_0944() : base() {}

		public FR_L6GL_MSGDFGS_0944(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6GL_MSGDFGS_0944 for attribute P_L6GL_MSGDFGS_0944
		[DataContract]
		public class P_L6GL_MSGDFGS_0944 
		{
			//Standard type parameters
			[DataMember]
			public Guid LanguageID { get; set; } 
			[DataMember]
			public String Term { get; set; } 

		}
		#endregion
		#region SClass L6GL_MSGDFGS_0944 for attribute L6GL_MSGDFGS_0944
		[DataContract]
		public class L6GL_MSGDFGS_0944 
		{
			//Standard type parameters
			[DataMember]
			public L6PA_GMSPSIfT_1542[] Patients { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6GL_MSGDFGS_0944 cls_Get_Data_For_Global_Search(,P_L6GL_MSGDFGS_0944 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6GL_MSGDFGS_0944 invocationResult = cls_Get_Data_For_Global_Search.Invoke(connectionString,P_L6GL_MSGDFGS_0944 Parameter,securityTicket);
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
var parameter = new CL6_MS_GlobalSearch.Complex.Retrieval.P_L6GL_MSGDFGS_0944();
parameter.LanguageID = ...;
parameter.Term = ...;

*/
