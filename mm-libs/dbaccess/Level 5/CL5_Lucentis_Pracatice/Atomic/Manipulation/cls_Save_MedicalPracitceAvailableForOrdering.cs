/* 
 * Generated on 7/25/2013 1:01:13 PM
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

namespace CL5_Lucentis_Practice.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_MedicalPracitceAvailableForOrdering.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_MedicalPracitceAvailableForOrdering
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5PR_SMPAfO__1213 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            foreach (var pharm in Parameter.AvailablePharmacies)
            {


                ORM_HEC_MedicalPractise_AvailablePharmaciesForOrdering item = new ORM_HEC_MedicalPractise_AvailablePharmaciesForOrdering();

                if (pharm.isDeleted == true)
                {
                    var MedicalPractise_AvailablePharmaciesForOrderingQuery = new ORM_HEC_MedicalPractise_AvailablePharmaciesForOrdering.Query();
                    MedicalPractise_AvailablePharmaciesForOrderingQuery.Tenant_RefID = securityTicket.TenantID;
                    MedicalPractise_AvailablePharmaciesForOrderingQuery.HEC_Pharmacy_RefID = pharm.PharmacyID;
                    MedicalPractise_AvailablePharmaciesForOrderingQuery.HEC_MedicalPractise_RefID = pharm.PracticeID;
                    MedicalPractise_AvailablePharmaciesForOrderingQuery.IsDeleted = false;

                    var MedicalPractise_AvailablePharmaciesForOrdering = ORM_HEC_MedicalPractise_AvailablePharmaciesForOrdering.Query.Search(Connection, Transaction, MedicalPractise_AvailablePharmaciesForOrderingQuery).FirstOrDefault();

                    if (MedicalPractise_AvailablePharmaciesForOrdering != null)
                    {
                        MedicalPractise_AvailablePharmaciesForOrdering.IsDeleted = true;
                        MedicalPractise_AvailablePharmaciesForOrdering.Save(Connection, Transaction);
                    }
                }

                if (pharm.isDeleted == false)
                {
                    var MedicalPractise_AvailablePharmaciesForOrderingQuery = new ORM_HEC_MedicalPractise_AvailablePharmaciesForOrdering.Query();
                    MedicalPractise_AvailablePharmaciesForOrderingQuery.Tenant_RefID = securityTicket.TenantID;
                    MedicalPractise_AvailablePharmaciesForOrderingQuery.HEC_Pharmacy_RefID = pharm.PharmacyID;
                    MedicalPractise_AvailablePharmaciesForOrderingQuery.HEC_MedicalPractise_RefID = pharm.PracticeID;
                    MedicalPractise_AvailablePharmaciesForOrderingQuery.IsDeleted = false;

                    var MedicalPractise_AvailablePharmaciesForOrdering = ORM_HEC_MedicalPractise_AvailablePharmaciesForOrdering.Query.Search(Connection, Transaction, MedicalPractise_AvailablePharmaciesForOrderingQuery).FirstOrDefault();

                    if (MedicalPractise_AvailablePharmaciesForOrdering != null)
                    {
                        continue;
                    }
                    else
                    {
                        item.HEC_MedicalPractise_AvailablePharmaciesForOrderingID = Guid.NewGuid();
                        item.Creation_Timestamp = DateTime.Now;
                        item.Tenant_RefID = securityTicket.TenantID;
                        item.HEC_Pharmacy_RefID = pharm.PharmacyID;
                        item.HEC_MedicalPractise_RefID = pharm.PracticeID;
                        item.IsDeleted = pharm.isDeleted;
                        item.Save(Connection, Transaction);
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
		public static FR_Guid Invoke(string ConnectionString,P_L5PR_SMPAfO__1213 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5PR_SMPAfO__1213 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PR_SMPAfO__1213 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PR_SMPAfO__1213 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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
		#region SClass P_L5PR_SMPAfO__1213 for attribute P_L5PR_SMPAfO__1213
		[DataContract]
		public class P_L5PR_SMPAfO__1213 
		{
			[DataMember]
			public P_L5PR_SMPAfO__1213a[] AvailablePharmacies { get; set; }

			//Standard type parameters
		}
		#endregion
		#region SClass P_L5PR_SMPAfO__1213a for attribute AvailablePharmacies
		[DataContract]
		public class P_L5PR_SMPAfO__1213a 
		{
			//Standard type parameters
			[DataMember]
			public Guid ID { get; set; } 
			[DataMember]
			public Guid PracticeID { get; set; } 
			[DataMember]
			public Guid PharmacyID { get; set; } 
			[DataMember]
			public Boolean isDeleted { get; set; } 

		}
		#endregion

	#endregion
}
