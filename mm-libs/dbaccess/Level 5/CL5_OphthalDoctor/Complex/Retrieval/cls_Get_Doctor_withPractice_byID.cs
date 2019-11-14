/* 
 * Generated on 9/11/2013 2:36:31 PM
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
using CL1_CMN_BPT;
using CL1_CMN_COM;
using CL1_HEC;
using CL3_MedicalPractices.Complex.Retrieval;

namespace CL5_Lucentis_Doctors.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Doctor_withPractice_byID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Doctor_withPractice_byID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5MD_GDwPfID_1414 Execute(DbConnection Connection,DbTransaction Transaction,P_L5MD_GDwPfID_1414 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L5MD_GDwPfID_1414();

            P_L3MD_GDBIfID_1150 biParam = new P_L3MD_GDBIfID_1150();
            biParam.DoctorID = Parameter.DoctorID;
            var baseInfo = cls_Get_Doctor_BaseInfo_byID.Invoke(Connection, Transaction, biParam, securityTicket).Result;
            returnValue.Result = new L5MD_GDwPfID_1414();
            returnValue.Result.BaseInfo = baseInfo;
            P_L3DAC_RACDbBPID_1056 aiParam = new P_L3DAC_RACDbBPID_1056();
            aiParam.BPrticipantID = baseInfo.Doctor_CMN_BPT_BusinessParticipantID;
            var accInfo = cls_Retrive_Account_Code_Details_byBParticipantID.Invoke(Connection, Transaction, aiParam, securityTicket).Result;
            if (accInfo != null)
            {
                var AccountInfo = new L5MD_GDwPfID_1414_AccountInfo();
                AccountInfo.AccountCode_ValidFrom = accInfo.AccountCode_ValidFrom;
                AccountInfo.AccountCode_Value = accInfo.AccountCode_Value;
                AccountInfo.USR_AccountID = baseInfo.Account_RefID;
                AccountInfo.USR_Device_AccountCodeID = accInfo.USR_Device_AccountCodeID;
                returnValue.Result.AccountInfo = AccountInfo;
            }

            var customerQuery = new ORM_CMN_BPT_CTM_Customer.Query();
            customerQuery.Ext_BusinessParticipant_RefID = baseInfo.Doctor_CMN_BPT_BusinessParticipantID;
            customerQuery.IsDeleted = false;
            var customerRes = ORM_CMN_BPT_CTM_Customer.Query.Search(Connection, Transaction, customerQuery);
            if (customerRes.Count > 0)
            {
                var ORM_CMN_BPT_CTM_Customer_2_SalesRepresentativeQuery = new ORM_CMN_BPT_CTM_Customer_2_SalesRepresentative.Query();
                ORM_CMN_BPT_CTM_Customer_2_SalesRepresentativeQuery.Customer_RefID = customerRes.First().CMN_BPT_CTM_CustomerID;
                ORM_CMN_BPT_CTM_Customer_2_SalesRepresentativeQuery.IsDeleted = false;
                var ORM_CMN_BPT_CTM_Customer_2_SalesRepresentative1 = ORM_CMN_BPT_CTM_Customer_2_SalesRepresentative.Query.Search(Connection, Transaction, ORM_CMN_BPT_CTM_Customer_2_SalesRepresentativeQuery).First();
                returnValue.Result.SalesRepresentative = new L5MD_GDwPfID_1414_SalesRepresentative();
                returnValue.Result.SalesRepresentative.SalesRepresentative_RefID = ORM_CMN_BPT_CTM_Customer_2_SalesRepresentative1.SalesRepresentative_RefID;
            }
            var assocBPQuery = new ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant.Query();
            assocBPQuery.BusinessParticipant_RefID = baseInfo.Doctor_CMN_BPT_BusinessParticipantID;
            assocBPQuery.IsDeleted = false;
            var assocBPQs = ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant.Query.Search(Connection, Transaction, assocBPQuery).ToArray();
            if (assocBPQs.Length > 0)
            {
                assocBPQs = assocBPQs.OrderBy(a => a.Creation_Timestamp).ToArray();
                var assocBPQ = assocBPQs.First();
                var practiceBPQuery = new ORM_CMN_BPT_BusinessParticipant.Query();
                practiceBPQuery.CMN_BPT_BusinessParticipantID = assocBPQ.AssociatedBusinessParticipant_RefID;
                var practiceBP = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, practiceBPQuery).First();
                var companInfoQuery = new ORM_CMN_COM_CompanyInfo.Query();
                companInfoQuery.CMN_COM_CompanyInfoID = practiceBP.IfCompany_CMN_COM_CompanyInfo_RefID;
                var companInfo = ORM_CMN_COM_CompanyInfo.Query.Search(Connection, Transaction, companInfoQuery).First();
                var practiceQuery = new ORM_HEC_MedicalPractis.Query();
                practiceQuery.Ext_CompanyInfo_RefID = companInfo.CMN_COM_CompanyInfoID;
                var prac = ORM_HEC_MedicalPractis.Query.Search(Connection, Transaction, practiceQuery).First();

                P_L3MP_GPfID_1222 pbiParam = new P_L3MP_GPfID_1222();
                pbiParam.HEC_MedicalPractiseID = prac.HEC_MedicalPractiseID;
                var practiceBasInfo = cls_Get_Practice_For_ID.Invoke(Connection, Transaction, pbiParam, securityTicket).Result;
                if (practiceBasInfo != null)
                {
                    L5MD_GDwPfID_1414_Practice practice = new L5MD_GDwPfID_1414_Practice();
                    practice.AssociatedParticipant_FunctionName = assocBPQ.AssociatedParticipant_FunctionName;
                    practice.CMN_BPT_BusinessParticipantID = practiceBasInfo.BaseInfo.CMN_BPT_BusinessParticipantID;
                    if (practiceBasInfo.OtherOphthal_PracticeData != null) practice.HealthAssociation_Name = practiceBasInfo.OtherOphthal_PracticeData.HealthAssociation_Name;
                    practice.PracticeID = practiceBasInfo.BaseInfo.HEC_MedicalPractiseID;
                    practice.PracticeName = practiceBasInfo.BaseInfo.PracticeName;
                    practice.Region_Name = practiceBasInfo.BaseInfo.Region_Name;
                    practice.Street_Name = practiceBasInfo.BaseInfo.Street_Name;
                    practice.Street_Number = practiceBasInfo.BaseInfo.Street_Number;
                    practice.Town = practiceBasInfo.BaseInfo.Town;
                    practice.ZIP = practiceBasInfo.BaseInfo.ZIP;

                    returnValue.Result.Practice = practice;
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
		public static FR_L5MD_GDwPfID_1414 Invoke(string ConnectionString,P_L5MD_GDwPfID_1414 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5MD_GDwPfID_1414 Invoke(DbConnection Connection,P_L5MD_GDwPfID_1414 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5MD_GDwPfID_1414 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5MD_GDwPfID_1414 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5MD_GDwPfID_1414 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5MD_GDwPfID_1414 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5MD_GDwPfID_1414 functionReturn = new FR_L5MD_GDwPfID_1414();
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

				throw new Exception("Exception occured in method cls_Get_Doctor_withPractice_byID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5MD_GDwPfID_1414_raw 
	{
		public L3MD_GDBIfID_1150 BaseInfo; 
		public String AccountCode_Value; 
		public DateTime AccountCode_ValidFrom; 
		public Guid USR_AccountID; 
		public Guid USR_Device_AccountCodeID; 
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

		public static L5MD_GDwPfID_1414[] Convert(List<L5MD_GDwPfID_1414_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5MD_GDwPfID_1414 in gfunct_rawResult.ToArray()
	group el_L5MD_GDwPfID_1414 by new 
	{ 
	}
	into gfunct_L5MD_GDwPfID_1414
	select new L5MD_GDwPfID_1414
	{     
		BaseInfo = gfunct_L5MD_GDwPfID_1414.FirstOrDefault().BaseInfo ,

		AccountInfo = 
		(
			from el_AccountInfo in gfunct_L5MD_GDwPfID_1414.Where(element => !EqualsDefaultValue(element.USR_Device_AccountCodeID)).ToArray()
			group el_AccountInfo by new 
			{ 
				el_AccountInfo.USR_Device_AccountCodeID,

			}
			into gfunct_AccountInfo
			select new L5MD_GDwPfID_1414_AccountInfo
			{     
				AccountCode_Value = gfunct_AccountInfo.FirstOrDefault().AccountCode_Value ,
				AccountCode_ValidFrom = gfunct_AccountInfo.FirstOrDefault().AccountCode_ValidFrom ,
				USR_AccountID = gfunct_AccountInfo.FirstOrDefault().USR_AccountID ,
				USR_Device_AccountCodeID = gfunct_AccountInfo.Key.USR_Device_AccountCodeID ,

			}
		).FirstOrDefault(),
		Practice = 
		(
			from el_Practice in gfunct_L5MD_GDwPfID_1414.Where(element => !EqualsDefaultValue(element.CMN_BPT_BusinessParticipantID)).ToArray()
			group el_Practice by new 
			{ 
				el_Practice.CMN_BPT_BusinessParticipantID,

			}
			into gfunct_Practice
			select new L5MD_GDwPfID_1414_Practice
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
			from el_SalesRepresentative in gfunct_L5MD_GDwPfID_1414.ToArray()
			group el_SalesRepresentative by new 
			{ 
			}
			into gfunct_SalesRepresentative
			select new L5MD_GDwPfID_1414_SalesRepresentative
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
	public class FR_L5MD_GDwPfID_1414 : FR_Base
	{
		public L5MD_GDwPfID_1414 Result	{ get; set; }

		public FR_L5MD_GDwPfID_1414() : base() {}

		public FR_L5MD_GDwPfID_1414(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5MD_GDwPfID_1414 for attribute P_L5MD_GDwPfID_1414
		[DataContract]
		public class P_L5MD_GDwPfID_1414 
		{
			//Standard type parameters
			[DataMember]
			public Guid DoctorID { get; set; } 

		}
		#endregion
		#region SClass L5MD_GDwPfID_1414 for attribute L5MD_GDwPfID_1414
		[DataContract]
		public class L5MD_GDwPfID_1414 
		{
			[DataMember]
			public L5MD_GDwPfID_1414_AccountInfo AccountInfo { get; set; }
			[DataMember]
			public L5MD_GDwPfID_1414_Practice Practice { get; set; }
			[DataMember]
			public L5MD_GDwPfID_1414_SalesRepresentative SalesRepresentative { get; set; }

			//Standard type parameters
			[DataMember]
			public L3MD_GDBIfID_1150 BaseInfo { get; set; } 

		}
		#endregion
		#region SClass L5MD_GDwPfID_1414_AccountInfo for attribute AccountInfo
		[DataContract]
		public class L5MD_GDwPfID_1414_AccountInfo 
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
		#region SClass L5MD_GDwPfID_1414_Practice for attribute Practice
		[DataContract]
		public class L5MD_GDwPfID_1414_Practice 
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
		#region SClass L5MD_GDwPfID_1414_SalesRepresentative for attribute SalesRepresentative
		[DataContract]
		public class L5MD_GDwPfID_1414_SalesRepresentative 
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
FR_L5MD_GDwPfID_1414 cls_Get_Doctor_withPractice_byID(,P_L5MD_GDwPfID_1414 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5MD_GDwPfID_1414 invocationResult = cls_Get_Doctor_withPractice_byID.Invoke(connectionString,P_L5MD_GDwPfID_1414 Parameter,securityTicket);
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
var parameter = new CL5_Lucentis_Doctors.Complex.Retrieval.P_L5MD_GDwPfID_1414();
parameter.DoctorID = ...;

*/
