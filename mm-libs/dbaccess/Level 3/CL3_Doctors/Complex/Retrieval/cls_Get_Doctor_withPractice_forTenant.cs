/* 
 * Generated on 9/3/2013 2:51:27 PM
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
using CL3_Doctors.Atomic.Retrieval;
using CL3_DeviceAccountCodes.Atomic.Retrieval;
using CL1_CMN_BPT_CTM;

namespace CL3_Doctors.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Doctor_withPractice_forTenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Doctor_withPractice_forTenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3MD_GDwPfT_1404_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L3MD_GDwPfT_1404_Array();

            var basicInfos = cls_Get_Doctor_BaseInfo_withPractice_forTenant.Invoke(Connection, Transaction, securityTicket).Result;
            var accs = cls_Retrive_Account_Code_Details_forTenant.Invoke(Connection, Transaction, securityTicket).Result;

            var customerQuery = new ORM_CMN_BPT_CTM_Customer.Query();
            customerQuery.Tenant_RefID = securityTicket.TenantID;
            customerQuery.IsDeleted = false;
            var customerRes = ORM_CMN_BPT_CTM_Customer.Query.Search(Connection, Transaction, customerQuery);

            var ORM_CMN_BPT_CTM_Customer_2_SalesRepresentativeQuery = new ORM_CMN_BPT_CTM_Customer_2_SalesRepresentative.Query();
            ORM_CMN_BPT_CTM_Customer_2_SalesRepresentativeQuery.Tenant_RefID = securityTicket.TenantID;
            ORM_CMN_BPT_CTM_Customer_2_SalesRepresentativeQuery.IsDeleted = false;
            var cust2SalesRespRes = ORM_CMN_BPT_CTM_Customer_2_SalesRepresentative.Query.Search(Connection, Transaction, ORM_CMN_BPT_CTM_Customer_2_SalesRepresentativeQuery);

            List<L3MD_GDwPfT_1404> retVal = new List<L3MD_GDwPfT_1404>();
            foreach (var item in basicInfos)
            {
                var doc = new L3MD_GDwPfT_1404();
                doc.BaseInfo = item;
                
                if(item.Account_RefID != Guid.Empty)
                {
                    var accountInfo = accs.FirstOrDefault(a => a.BusinessParticipant_RefID == item.Doctor_CMN_BPT_BusinessParticipantID);
                    if (accountInfo != null)
                    {
                        doc.AccountInfo = new L3MD_GDwPfT_1404_AccountInfo();
                        doc.AccountInfo.AccountCode_ValidFrom = accountInfo.AccountCode_ValidFrom;
                        doc.AccountInfo.AccountCode_Value = accountInfo.AccountCode_Value;
                        doc.AccountInfo.USR_AccountID = accountInfo.Account_RefID;
                        doc.AccountInfo.USR_Device_AccountCodeID = accountInfo.USR_Device_AccountCodeID;
                    }

                    var customer = customerRes.FirstOrDefault(c => c.Ext_BusinessParticipant_RefID == item.Doctor_CMN_BPT_BusinessParticipantID);
                    if (customer != null)
                    {
                        var c2SalesResp = cust2SalesRespRes.FirstOrDefault(sr => sr.Customer_RefID == customer.CMN_BPT_CTM_CustomerID);
                        if (c2SalesResp != null)
                        {
                            doc.SalesRepresentative = new L3MD_GDwPfT_1404_SalesRepresentative();
                            doc.SalesRepresentative.SalesRepresentative_RefID = c2SalesResp.SalesRepresentative_RefID;
                        }
                    }
                }

                retVal.Add(doc);
            }
            returnValue.Result = retVal.ToArray();

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3MD_GDwPfT_1404_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3MD_GDwPfT_1404_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3MD_GDwPfT_1404_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3MD_GDwPfT_1404_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3MD_GDwPfT_1404_Array functionReturn = new FR_L3MD_GDwPfT_1404_Array();
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

				throw new Exception("Exception occured in method cls_Get_Doctor_withPractice_forTenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L3MD_GDwPfT_1404_raw 
	{
		public L3MD_GDBIwPfT_1557 BaseInfo; 
		public String AccountCode_Value; 
		public DateTime AccountCode_ValidFrom; 
		public Guid USR_AccountID; 
		public Guid USR_Device_AccountCodeID; 
		public Guid SalesRepresentative_RefID; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L3MD_GDwPfT_1404[] Convert(List<L3MD_GDwPfT_1404_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L3MD_GDwPfT_1404 in gfunct_rawResult.ToArray()
	group el_L3MD_GDwPfT_1404 by new 
	{ 
	}
	into gfunct_L3MD_GDwPfT_1404
	select new L3MD_GDwPfT_1404
	{     
		BaseInfo = gfunct_L3MD_GDwPfT_1404.FirstOrDefault().BaseInfo ,

		AccountInfo = 
		(
			from el_AccountInfo in gfunct_L3MD_GDwPfT_1404.Where(element => !EqualsDefaultValue(element.USR_Device_AccountCodeID)).ToArray()
			group el_AccountInfo by new 
			{ 
				el_AccountInfo.USR_Device_AccountCodeID,

			}
			into gfunct_AccountInfo
			select new L3MD_GDwPfT_1404_AccountInfo
			{     
				AccountCode_Value = gfunct_AccountInfo.FirstOrDefault().AccountCode_Value ,
				AccountCode_ValidFrom = gfunct_AccountInfo.FirstOrDefault().AccountCode_ValidFrom ,
				USR_AccountID = gfunct_AccountInfo.FirstOrDefault().USR_AccountID ,
				USR_Device_AccountCodeID = gfunct_AccountInfo.Key.USR_Device_AccountCodeID ,

			}
		).FirstOrDefault(),
		SalesRepresentative = 
		(
			from el_SalesRepresentative in gfunct_L3MD_GDwPfT_1404.ToArray()
			group el_SalesRepresentative by new 
			{ 
			}
			into gfunct_SalesRepresentative
			select new L3MD_GDwPfT_1404_SalesRepresentative
			{     
				SalesRepresentative_RefID = gfunct_SalesRepresentative.FirstOrDefault().SalesRepresentative_RefID ,

			}
		).FirstOrDefault(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L3MD_GDwPfT_1404_Array : FR_Base
	{
		public L3MD_GDwPfT_1404[] Result	{ get; set; } 
		public FR_L3MD_GDwPfT_1404_Array() : base() {}

		public FR_L3MD_GDwPfT_1404_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L3MD_GDwPfT_1404 for attribute L3MD_GDwPfT_1404
		[DataContract]
		public class L3MD_GDwPfT_1404 
		{
			[DataMember]
			public L3MD_GDwPfT_1404_AccountInfo AccountInfo { get; set; }
			[DataMember]
			public L3MD_GDwPfT_1404_SalesRepresentative SalesRepresentative { get; set; }

			//Standard type parameters
			[DataMember]
			public L3MD_GDBIwPfT_1557 BaseInfo { get; set; } 

		}
		#endregion
		#region SClass L3MD_GDwPfT_1404_AccountInfo for attribute AccountInfo
		[DataContract]
		public class L3MD_GDwPfT_1404_AccountInfo 
		{
			//Standard type parameters
			[DataMember]
			public String AccountCode_Value { get; set; } 
			[DataMember]
			public DateTime AccountCode_ValidFrom { get; set; } 
			[DataMember]
			public Guid USR_AccountID { get; set; } 
			[DataMember]
			public Guid USR_Device_AccountCodeID { get; set; } 

		}
		#endregion
		#region SClass L3MD_GDwPfT_1404_SalesRepresentative for attribute SalesRepresentative
		[DataContract]
		public class L3MD_GDwPfT_1404_SalesRepresentative 
		{
			//Standard type parameters
			[DataMember]
			public Guid SalesRepresentative_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3MD_GDwPfT_1404_Array cls_Get_Doctor_withPractice_forTenant(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3MD_GDwPfT_1404_Array invocationResult = cls_Get_Doctor_withPractice_forTenant.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

