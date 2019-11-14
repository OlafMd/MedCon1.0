/* 
 * Generated on 6/24/2013 8:42:22 AM
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
using CL1_CMN;
using CL1_CMN_PER;

namespace CL6_BBV_Patient.Complex.Manipulation
{
	[DataContract]
	public class cls_Set_BBV_AddressAsPrimery
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L6PA_SBBVAAP_0842 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();

            ORM_CMN_Address address = new ORM_CMN_Address();
            if (Parameter.CMN_AddressID != Guid.Empty)
            {
                var result = address.Load(Connection, Transaction, Parameter.CMN_AddressID);
                if (result.Status != FR_Status.Success || address.CMN_AddressID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
                else
                {

                    ORM_CMN_PER_PersonInfo_2_Address.Query query = new ORM_CMN_PER_PersonInfo_2_Address.Query();
                    query.CMN_Address_RefID = address.CMN_AddressID;
                    query.Tenant_RefID = securityTicket.TenantID;
                    query.IsDeleted = false;
                    var queryRes = ORM_CMN_PER_PersonInfo_2_Address.Query.Search(Connection, Transaction, query);
                    if (queryRes.Count == 1)
                    {
                        queryRes[0].IsPrimary = true;
                        queryRes[0].Save(Connection, Transaction);

                        ORM_CMN_PER_PersonInfo_2_Address.Query queryOther = new ORM_CMN_PER_PersonInfo_2_Address.Query();
                        queryOther.CMN_PER_PersonInfo_RefID = queryRes[0].CMN_PER_PersonInfo_RefID;
                        queryOther.Tenant_RefID = securityTicket.TenantID;
                        queryOther.IsDeleted = false;
                        var queryOtherRes = ORM_CMN_PER_PersonInfo_2_Address.Query.Search(Connection, Transaction, queryOther);
                        if (queryOtherRes.Count > 0)
                        {
                            foreach (ORM_CMN_PER_PersonInfo_2_Address item in queryOtherRes)
                            {
                                if (item.AssignmentID != queryRes[0].AssignmentID)
                                {
                                    item.IsPrimary = false;
                                    item.Save(Connection, Transaction);
                                }
                            }
                        }
                    }
                    else
                    {
                        var error = new FR_Guid();
                        error.ErrorMessage = "No Such ID";
                        error.Status = FR_Status.Error_Internal;
                        return error;
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
		public static FR_Guid Invoke(string ConnectionString,P_L6PA_SBBVAAP_0842 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L6PA_SBBVAAP_0842 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L6PA_SBBVAAP_0842 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6PA_SBBVAAP_0842 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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
		#region SClass P_L6PA_SBBVAAP_0842 for attribute P_L6PA_SBBVAAP_0842
		[DataContract]
		public class P_L6PA_SBBVAAP_0842 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_AddressID { get; set; } 

		}
		#endregion

	#endregion
}
