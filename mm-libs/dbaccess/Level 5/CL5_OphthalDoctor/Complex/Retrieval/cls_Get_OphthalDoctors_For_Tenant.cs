/* 
 * Generated on 9/17/2013 12:43:55 PM
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
using CL3_MedicalPractices.Complex.Retrieval;
using CL1_CMN_BPT_CTM;
using CL3_DeviceAccountCodes.Atomic.Retrieval;

namespace CL5_OphthalDoctors.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_OphthalDoctors_For_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_OphthalDoctors_For_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5OD_GDfT_1126_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5OD_GDfT_1126_Array();

			var basicInfos = cls_Get_Doctor_BaseInfo_withPractice_forTenant.Invoke(Connection, Transaction, securityTicket).Result;
            var allPractices = cls_Get_Practice_For_Tenant.Invoke(Connection, Transaction, securityTicket).Result;
            var accs = cls_Retrive_Account_Code_Details_forTenant.Invoke(Connection, Transaction, securityTicket).Result;

            var customerQuery = new ORM_CMN_BPT_CTM_Customer.Query();
            customerQuery.Tenant_RefID = securityTicket.TenantID;
            var customers = ORM_CMN_BPT_CTM_Customer.Query.Search(Connection, Transaction, customerQuery);

            var customer2SRQuery = new ORM_CMN_BPT_CTM_Customer_2_SalesRepresentative.Query();
            customer2SRQuery.Tenant_RefID = securityTicket.TenantID;
            var customer2SRs = ORM_CMN_BPT_CTM_Customer_2_SalesRepresentative.Query.Search(Connection, Transaction, customer2SRQuery);

            List<L5OD_GDfT_1126> retVal = new List<L5OD_GDfT_1126>();
            foreach (var item in basicInfos)
            {
                var doc = new L5OD_GDfT_1126();
                doc.BaseInfo = item;
                doc.FirstName = item.FirstName;
                doc.LastName = item.LastName;
                doc.HEC_DoctorID = item.HEC_DoctorID;
                doc.Title = item.Title;
                if (item.AllPractices != null)
                {
                    var practices = item.AllPractices.OrderBy(p => p.Creation_Timestamp);
                    var doctorsPractice = practices.FirstOrDefault();
                    if(doctorsPractice != null)
                    {
                        var practicesForDoctor = allPractices.FirstOrDefault(p => p.BaseInfo.HEC_MedicalPractiseID == doctorsPractice.PracticeID);
                        if (practicesForDoctor != null)
                        {
                            L5OD_GDfT_1126_Practice practice = new L5OD_GDfT_1126_Practice();
                            practice.AssociatedParticipant_FunctionName = doctorsPractice.AssociatedParticipant_FunctionName;
                            practice.CMN_BPT_BusinessParticipantID = doctorsPractice.CMN_BPT_BusinessParticipantID;
                            if (practicesForDoctor.OtherOphthal_PracticeData != null) practice.HealthAssociation_Name = practicesForDoctor.OtherOphthal_PracticeData.HealthAssociation_Name;
                            practice.PracticeID = practicesForDoctor.BaseInfo.HEC_MedicalPractiseID;
                            practice.PracticeName = practicesForDoctor.BaseInfo.PracticeName;
                            practice.Region_Name = practicesForDoctor.BaseInfo.Region_Name;
                            practice.Street_Name = practicesForDoctor.BaseInfo.Street_Name;
                            practice.Street_Number = practicesForDoctor.BaseInfo.Street_Number;
                            practice.Town = practicesForDoctor.BaseInfo.Town;
                            practice.ZIP = practicesForDoctor.BaseInfo.ZIP;
                            doc.Practice = practice;
                        }
                    }

                    var customer = customers.FirstOrDefault(c => c.Ext_BusinessParticipant_RefID == item.Doctor_CMN_BPT_BusinessParticipantID);
                    if (customer != null)
                    {
                        var c2sr = customer2SRs.FirstOrDefault(c => c.Customer_RefID == customer.CMN_BPT_CTM_CustomerID);
                        if (c2sr != null)
                        {
                            doc.SalesRepresentative = new L5OD_GDfT_1126_SalesRepresentative();
                            doc.SalesRepresentative.SalesRepresentative_RefID = c2sr.SalesRepresentative_RefID;
                        }
                    }

                    var accountInfo = accs.FirstOrDefault(a => a.BusinessParticipant_RefID == item.Doctor_CMN_BPT_BusinessParticipantID);
                    if (accountInfo != null)
                    {
                        doc.AccountInfo = new L5OD_GDfT_1126_AccountInfo();
                        doc.AccountInfo.AccountCode_Value = accountInfo.AccountCode_Value;
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
		public static FR_L5OD_GDfT_1126_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5OD_GDfT_1126_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5OD_GDfT_1126_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5OD_GDfT_1126_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5OD_GDfT_1126_Array functionReturn = new FR_L5OD_GDfT_1126_Array();
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

				throw new Exception("Exception occured in method cls_Get_OphthalDoctors_For_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5OD_GDfT_1126_raw 
	{
		public L3MD_GDBIwPfT_1557 BaseInfo; 
		public String FirstName; 
		public String LastName; 
		public String Title; 
		public Guid HEC_DoctorID; 
		public String AccountCode_Value; 
		public String PracticeName; 
		public Guid PracticeID; 
		public Guid CMN_BPT_BusinessParticipantID; 
		public String AssociatedParticipant_FunctionName; 
		public String Street_Name; 
		public String Street_Number; 
		public String ZIP; 
		public String Town; 
		public String Region_Name; 
		public String HealthAssociation_Name; 
		public Guid SalesRepresentative_RefID; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5OD_GDfT_1126[] Convert(List<L5OD_GDfT_1126_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5OD_GDfT_1126 in gfunct_rawResult.ToArray()
	group el_L5OD_GDfT_1126 by new 
	{ 
	}
	into gfunct_L5OD_GDfT_1126
	select new L5OD_GDfT_1126
	{     
		BaseInfo = gfunct_L5OD_GDfT_1126.FirstOrDefault().BaseInfo ,
		FirstName = gfunct_L5OD_GDfT_1126.FirstOrDefault().FirstName ,
		LastName = gfunct_L5OD_GDfT_1126.FirstOrDefault().LastName ,
		Title = gfunct_L5OD_GDfT_1126.FirstOrDefault().Title ,
		HEC_DoctorID = gfunct_L5OD_GDfT_1126.FirstOrDefault().HEC_DoctorID ,

		AccountInfo = 
		(
			from el_AccountInfo in gfunct_L5OD_GDfT_1126.ToArray()
			select new L5OD_GDfT_1126_AccountInfo
			{     
				AccountCode_Value = el_AccountInfo.AccountCode_Value,

			}
		).FirstOrDefault(),
		Practice = 
		(
			from el_Practice in gfunct_L5OD_GDfT_1126.Where(element => !EqualsDefaultValue(element.CMN_BPT_BusinessParticipantID)).ToArray()
			group el_Practice by new 
			{ 
				el_Practice.CMN_BPT_BusinessParticipantID,

			}
			into gfunct_Practice
			select new L5OD_GDfT_1126_Practice
			{     
				PracticeName = gfunct_Practice.FirstOrDefault().PracticeName ,
				PracticeID = gfunct_Practice.FirstOrDefault().PracticeID ,
				CMN_BPT_BusinessParticipantID = gfunct_Practice.Key.CMN_BPT_BusinessParticipantID ,
				AssociatedParticipant_FunctionName = gfunct_Practice.FirstOrDefault().AssociatedParticipant_FunctionName ,
				Street_Name = gfunct_Practice.FirstOrDefault().Street_Name ,
				Street_Number = gfunct_Practice.FirstOrDefault().Street_Number ,
				ZIP = gfunct_Practice.FirstOrDefault().ZIP ,
				Town = gfunct_Practice.FirstOrDefault().Town ,
				Region_Name = gfunct_Practice.FirstOrDefault().Region_Name ,
				HealthAssociation_Name = gfunct_Practice.FirstOrDefault().HealthAssociation_Name ,

			}
		).FirstOrDefault(),
		SalesRepresentative = 
		(
			from el_SalesRepresentative in gfunct_L5OD_GDfT_1126.ToArray()
			select new L5OD_GDfT_1126_SalesRepresentative
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
	public class FR_L5OD_GDfT_1126_Array : FR_Base
	{
		public L5OD_GDfT_1126[] Result	{ get; set; } 
		public FR_L5OD_GDfT_1126_Array() : base() {}

		public FR_L5OD_GDfT_1126_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5OD_GDfT_1126 for attribute L5OD_GDfT_1126
		[DataContract]
		public class L5OD_GDfT_1126 
		{
			[DataMember]
			public L5OD_GDfT_1126_AccountInfo AccountInfo { get; set; }
			[DataMember]
			public L5OD_GDfT_1126_Practice Practice { get; set; }
			[DataMember]
			public L5OD_GDfT_1126_SalesRepresentative SalesRepresentative { get; set; }

			//Standard type parameters
			[DataMember]
			public L3MD_GDBIwPfT_1557 BaseInfo { get; set; } 
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
		#region SClass L5OD_GDfT_1126_AccountInfo for attribute AccountInfo
		[DataContract]
		public class L5OD_GDfT_1126_AccountInfo 
		{
			//Standard type parameters
			[DataMember]
			public String AccountCode_Value { get; set; } 

		}
		#endregion
		#region SClass L5OD_GDfT_1126_Practice for attribute Practice
		[DataContract]
		public class L5OD_GDfT_1126_Practice 
		{
			//Standard type parameters
			[DataMember]
			public String PracticeName { get; set; } 
			[DataMember]
			public Guid PracticeID { get; set; } 
			[DataMember]
			public Guid CMN_BPT_BusinessParticipantID { get; set; } 
			[DataMember]
			public String AssociatedParticipant_FunctionName { get; set; } 
			[DataMember]
			public String Street_Name { get; set; } 
			[DataMember]
			public String Street_Number { get; set; } 
			[DataMember]
			public String ZIP { get; set; } 
			[DataMember]
			public String Town { get; set; } 
			[DataMember]
			public String Region_Name { get; set; } 
			[DataMember]
			public String HealthAssociation_Name { get; set; } 

		}
		#endregion
		#region SClass L5OD_GDfT_1126_SalesRepresentative for attribute SalesRepresentative
		[DataContract]
		public class L5OD_GDfT_1126_SalesRepresentative 
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
FR_L5OD_GDfT_1126_Array cls_Get_OphthalDoctors_For_Tenant(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5OD_GDfT_1126_Array invocationResult = cls_Get_OphthalDoctors_For_Tenant.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

