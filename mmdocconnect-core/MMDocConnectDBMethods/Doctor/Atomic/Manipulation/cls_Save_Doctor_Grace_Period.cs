/* 
 * Generated on 2/10/2017 3:56:45 PM
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
using CL1_HEC;
using MMDocConnectDBMethods.Doctor.Model;
using MMDocConnectUtils;

namespace MMDocConnectDBMethods.Doctor.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Doctor_Grace_Period.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Doctor_Grace_Period
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Bool Execute(DbConnection Connection,DbTransaction Transaction,P_DO_SDGP_1639 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_Bool();
            //Put your code here

            var doctor = ORM_HEC_Doctor.Query.Search(Connection, Transaction, new ORM_HEC_Doctor.Query
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                HEC_DoctorID = Parameter.DoctorID
            }).SingleOrDefault();

            if (doctor != null)
            {
                var passwordGracePeriodGPM = ORM_HEC_Doctor_UniversalProperty.Query.Search(Connection, Transaction, new ORM_HEC_Doctor_UniversalProperty.Query
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    GlobalPropertyMatchingID = EGracePeriod.DoctorGracePeriod.Value()
                }).SingleOrDefault();
                if (passwordGracePeriodGPM == null)
                {
                    passwordGracePeriodGPM = new ORM_HEC_Doctor_UniversalProperty()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        GlobalPropertyMatchingID = EGracePeriod.DoctorGracePeriod.Value(),
                        IsValue_String = true,
                        PropertyName = String.Empty
                    };
                    passwordGracePeriodGPM.Save(Connection, Transaction);
                }

                var passwordGracePeriodValue = ORM_HEC_Doctor_UniversalPropertyValue.Query.Search(Connection, Transaction, new ORM_HEC_Doctor_UniversalPropertyValue.Query
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    UniversalProperty_RefID = passwordGracePeriodGPM.HEC_Doctor_UniversalPropertyID,
                    HEC_Doctor_RefID = doctor.HEC_DoctorID
                }).SingleOrDefault();
                if (passwordGracePeriodValue == null)
                {
                    passwordGracePeriodValue = new ORM_HEC_Doctor_UniversalPropertyValue
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        UniversalProperty_RefID = passwordGracePeriodGPM.HEC_Doctor_UniversalPropertyID,
                        HEC_Doctor_RefID = doctor.HEC_DoctorID
                    };  
                }
                passwordGracePeriodValue.Value_String = Parameter.ResetGracePeriod ? DateTime.MinValue.ToString("yyyy-MM-ddTHH:mm:ss") : DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
                passwordGracePeriodValue.Save(Connection, Transaction);

                returnValue.Result = true;
            }


            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Bool Invoke(string ConnectionString,P_DO_SDGP_1639 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection,P_DO_SDGP_1639 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction,P_DO_SDGP_1639 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_DO_SDGP_1639 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Doctor_Grace_Period",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_DO_SDGP_1639 for attribute P_DO_SDGP_1639
		[DataContract]
		public class P_DO_SDGP_1639 
		{
			//Standard type parameters
			[DataMember]
			public Guid DoctorID { get; set; } 
			[DataMember]
			public bool ResetGracePeriod { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Bool cls_Save_Doctor_Grace_Period(,P_DO_SDGP_1639 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Bool invocationResult = cls_Save_Doctor_Grace_Period.Invoke(connectionString,P_DO_SDGP_1639 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Doctor.Atomic.Manipulation.P_DO_SDGP_1639();
parameter.DoctorID = ...;
parameter.ResetGracePeriod = ...;

*/