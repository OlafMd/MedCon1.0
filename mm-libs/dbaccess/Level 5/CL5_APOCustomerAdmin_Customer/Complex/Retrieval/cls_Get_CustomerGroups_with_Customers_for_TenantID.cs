/* 
 * Generated on 15.11.2014 00:38:51
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
using CL5_APOCustomerAdmin_Customer.Atomic.Retrieval;

namespace CL5_APOCustomerAdmin_Customer.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_CustomerGroups_with_Customers_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_CustomerGroups_with_Customers_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5CU_GCGwCfT_1735 Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5CU_GCGwCfT_1735();
            returnValue.Result = new L5CU_GCGwCfT_1735();
			//Put your code here

            var resListCustomers = new List<L5CU_GCGwCfT_1735a>();
            var resListGroups = new List<L5CU_GCGwCfT_1735g>();

            var persons = cls_Get_PersonCustomers_for_TenantID.Invoke(Connection, Transaction, securityTicket).Result;
            var companies = cls_Get_CompanyCustomers_for_TenantID.Invoke(Connection, Transaction, securityTicket).Result;
            var groupsWithAssignments = cls_Get_CustomerGroups_with_Assignment.Invoke(Connection, Transaction, securityTicket).Result;



            if (persons != null)
            {
                foreach (var p in persons)
                {
                    var item = new L5CU_GCGwCfT_1735a();
                    item.CMN_BPT_BusinessParticipantID = p.CMN_BPT_BusinessParticipantID;
                    item.CMN_BPT_CTM_CustomerID = p.CMN_BPT_CTM_CustomerID;
                    item.FirstName = p.FirstName;
                    item.LastName = p.LastName;
                    item.IsPerson = true;
                    item.IfPerson_CMN_PER_PersonInfoID = p.CMN_PER_PersonInfoID;
                    item.InternalCustomerNumber = p.InternalCustomerNumber;
                    item.DispayName = p.DisplayName;
                    resListCustomers.Add(item);
                }
            }
            if (companies != null)
            {
                foreach (var c in companies)
                {
                    var item = new L5CU_GCGwCfT_1735a();
                    item.CMN_BPT_BusinessParticipantID = c.CMN_BPT_BusinessParticipantID;
                    item.CMN_BPT_CTM_CustomerID = c.CMN_BPT_CTM_CustomerID;
                    item.FirmName = c.CompanyName_Line1;
                    item.IsCompany = true;
                    item.InternalCustomerNumber = c.InternalCustomerNumber;
                    item.DispayName = c.DisplayName;
                    resListCustomers.Add(item);
                }
            }

            returnValue.Result.Customers = resListCustomers.OrderBy(l => l.LastName).ToArray();


            foreach (var groupWA in groupsWithAssignments)
	        {
                var item = new L5CU_GCGwCfT_1735g();
                item.CMN_BPT_BP_GroupID = groupWA.CMN_BPT_BusinessParticipant_GroupID;
                item.BusinessParticipantGroup_Name = groupWA.BusinessParticipantGroup_Name;
                item.BusinessParticipantGroup_Description = groupWA.BusinessParticipantGroup_Description;


                if (groupsWithAssignments.Any(x => x.Assignments.Any(y => resListCustomers.Any(z => z.CMN_BPT_BusinessParticipantID == y.CMN_BPT_BusinessParticipant_RefID))))
                {

                    var listGroupedCustomers = new List<L5CU_GCGwCfT_1735b>();
                    foreach (var cust in resListCustomers)
	                {
		                if (groupWA.Assignments.Any(x=> x.CMN_BPT_BusinessParticipant_RefID == cust.CMN_BPT_BusinessParticipantID ))
                        {
                            var customerInGroup = groupWA.Assignments.Where(x=> x.CMN_BPT_BusinessParticipant_RefID == cust.CMN_BPT_BusinessParticipantID)
                                .Select(x=> new L5CU_GCGwCfT_1735b {
                                    CustomerID = cust.CMN_BPT_CTM_CustomerID
                                }).SingleOrDefault();
                            if (customerInGroup != null)
                                listGroupedCustomers.Add(customerInGroup);
                        }
                        

	                } 

                    item.GroupedCustomers = listGroupedCustomers.ToArray();
                }

                resListGroups.Add(item);
        	}

            returnValue.Result.Groups = resListGroups.ToArray();

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5CU_GCGwCfT_1735 Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5CU_GCGwCfT_1735 Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5CU_GCGwCfT_1735 Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5CU_GCGwCfT_1735 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5CU_GCGwCfT_1735 functionReturn = new FR_L5CU_GCGwCfT_1735();
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

				functionReturn = Execute(Connection, Transaction,securityTicket);

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

				throw new Exception("Exception occured in method cls_Get_CustomerGroups_with_Customers_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5CU_GCGwCfT_1735 : FR_Base
	{
		public L5CU_GCGwCfT_1735 Result	{ get; set; }

		public FR_L5CU_GCGwCfT_1735() : base() {}

		public FR_L5CU_GCGwCfT_1735(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5CU_GCGwCfT_1735 for attribute L5CU_GCGwCfT_1735
		[DataContract]
		public class L5CU_GCGwCfT_1735 
		{
			[DataMember]
			public L5CU_GCGwCfT_1735g[] Groups { get; set; }
			[DataMember]
			public L5CU_GCGwCfT_1735a[] Customers { get; set; }

			//Standard type parameters
		}
		#endregion
		#region SClass L5CU_GCGwCfT_1735g for attribute Groups
		[DataContract]
		public class L5CU_GCGwCfT_1735g 
		{
			[DataMember]
			public L5CU_GCGwCfT_1735b[] GroupedCustomers { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid CMN_BPT_BP_GroupID { get; set; } 
			[DataMember]
			public Dict BusinessParticipantGroup_Name { get; set; } 
			[DataMember]
			public Dict BusinessParticipantGroup_Description { get; set; } 

		}
		#endregion
		#region SClass L5CU_GCGwCfT_1735b for attribute GroupedCustomers
		[DataContract]
		public class L5CU_GCGwCfT_1735b 
		{
			//Standard type parameters
			[DataMember]
			public Guid CustomerID { get; set; } 

		}
		#endregion
		#region SClass L5CU_GCGwCfT_1735a for attribute Customers
		[DataContract]
		public class L5CU_GCGwCfT_1735a 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_BPT_CTM_CustomerID { get; set; } 
			[DataMember]
			public Guid CMN_BPT_BusinessParticipantID { get; set; } 
			[DataMember]
			public bool IsPerson { get; set; } 
			[DataMember]
			public bool IsCompany { get; set; } 
			[DataMember]
			public Guid IfPerson_CMN_PER_PersonInfoID { get; set; } 
			[DataMember]
			public Guid IfCompany_CMN_COM_CompanyInfoID { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String FirmName { get; set; } 
			[DataMember]
			public String InternalCustomerNumber { get; set; } 
			[DataMember]
			public String CompanyName_Line2 { get; set; } 
			[DataMember]
			public String DispayName { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5CU_GCGwCfT_1735 cls_Get_CustomerGroups_with_Customers_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5CU_GCGwCfT_1735 invocationResult = cls_Get_CustomerGroups_with_Customers_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

