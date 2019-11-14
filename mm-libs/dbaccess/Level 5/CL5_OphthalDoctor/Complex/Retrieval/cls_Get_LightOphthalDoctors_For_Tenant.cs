/* 
 * Generated on 9/11/2013 11:59:53 AM
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
using CL1_CMN_BPT_CTM;

namespace CL5_OphthalDoctors.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_LightOphthalDoctors_For_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_LightOphthalDoctors_For_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5OD_GLDfT_1111_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5OD_GLDfT_1111_Array();

            var basicInfos = cls_Get_Doctor_BaseInfo_forTenant.Invoke(Connection, Transaction, securityTicket).Result;

            var customerQuery = new ORM_CMN_BPT_CTM_Customer.Query();
            customerQuery.Tenant_RefID = securityTicket.TenantID;
            var customers = ORM_CMN_BPT_CTM_Customer.Query.Search(Connection, Transaction, customerQuery);

            var customer2SRQuery = new ORM_CMN_BPT_CTM_Customer_2_SalesRepresentative.Query();
            customer2SRQuery.Tenant_RefID = securityTicket.TenantID;
            var customer2SRs = ORM_CMN_BPT_CTM_Customer_2_SalesRepresentative.Query.Search(Connection, Transaction, customer2SRQuery);

            List<L5OD_GLDfT_1111> retVal = new List<L5OD_GLDfT_1111>();
            foreach (var item in basicInfos)
            {
                var doc = new L5OD_GLDfT_1111();
                doc.BaseInfo = item;
                doc.FirstName = item.FirstName;
                doc.LastName = item.LastName;
                doc.HEC_DoctorID = item.HEC_DoctorID;
                doc.Title = item.Title;
                
                var customer = customers.FirstOrDefault(c => c.Ext_BusinessParticipant_RefID == item.Doctor_CMN_BPT_BusinessParticipantID);
                if (customer != null)
                {
                    var c2sr = customer2SRs.FirstOrDefault(c => c.Customer_RefID == customer.CMN_BPT_CTM_CustomerID);
                    if (c2sr != null)
                    {
                        doc.SalesRepresentative = new L5OD_GLDfT_1111_SalesRepresentative();
                        doc.SalesRepresentative.SalesRepresentative_RefID = c2sr.SalesRepresentative_RefID;
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
		public static FR_L5OD_GLDfT_1111_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5OD_GLDfT_1111_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5OD_GLDfT_1111_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5OD_GLDfT_1111_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5OD_GLDfT_1111_Array functionReturn = new FR_L5OD_GLDfT_1111_Array();
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

				throw new Exception("Exception occured in method cls_Get_LightOphthalDoctors_For_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5OD_GLDfT_1111_raw 
	{
		public L3MD_GDBIfT_1149 BaseInfo; 
		public String FirstName; 
		public String LastName; 
		public String Title; 
		public Guid HEC_DoctorID; 
		public Guid SalesRepresentative_RefID; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5OD_GLDfT_1111[] Convert(List<L5OD_GLDfT_1111_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5OD_GLDfT_1111 in gfunct_rawResult.ToArray()
	group el_L5OD_GLDfT_1111 by new 
	{ 
	}
	into gfunct_L5OD_GLDfT_1111
	select new L5OD_GLDfT_1111
	{     
		BaseInfo = gfunct_L5OD_GLDfT_1111.FirstOrDefault().BaseInfo ,
		FirstName = gfunct_L5OD_GLDfT_1111.FirstOrDefault().FirstName ,
		LastName = gfunct_L5OD_GLDfT_1111.FirstOrDefault().LastName ,
		Title = gfunct_L5OD_GLDfT_1111.FirstOrDefault().Title ,
		HEC_DoctorID = gfunct_L5OD_GLDfT_1111.FirstOrDefault().HEC_DoctorID ,

		SalesRepresentative = 
		(
			from el_SalesRepresentative in gfunct_L5OD_GLDfT_1111.ToArray()
			select new L5OD_GLDfT_1111_SalesRepresentative
			{     
				SalesRepresentative_RefID = el_SalesRepresentative.SalesRepresentative_RefID,

			}
		).FirstOrDefault(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5OD_GLDfT_1111_Array : FR_Base
	{
		public L5OD_GLDfT_1111[] Result	{ get; set; } 
		public FR_L5OD_GLDfT_1111_Array() : base() {}

		public FR_L5OD_GLDfT_1111_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5OD_GLDfT_1111 for attribute L5OD_GLDfT_1111
		[DataContract]
		public class L5OD_GLDfT_1111 
		{
			[DataMember]
			public L5OD_GLDfT_1111_SalesRepresentative SalesRepresentative { get; set; }

			//Standard type parameters
			[DataMember]
			public L3MD_GDBIfT_1149 BaseInfo { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public String Title { get; set; } 
			[DataMember]
			public Guid HEC_DoctorID { get; set; } 

		}
		#endregion
		#region SClass L5OD_GLDfT_1111_SalesRepresentative for attribute SalesRepresentative
		[DataContract]
		public class L5OD_GLDfT_1111_SalesRepresentative 
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
FR_L5OD_GLDfT_1111_Array cls_Get_LightOphthalDoctors_For_Tenant(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5OD_GLDfT_1111_Array invocationResult = cls_Get_LightOphthalDoctors_For_Tenant.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

