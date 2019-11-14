/* 
 * Generated on 9/9/2013 12:58:13 PM
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
using CL1_CMN_BPT;
using CL1_DOC;
using CL1_HEC;
using CL1_CMN_COM;

namespace CL5_OphthalMemos.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_CMN_BPT_Memo.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_CMN_BPT_Memo
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5OM_SM_0951 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            var doctorQuery = new ORM_HEC_Doctor.Query();
            doctorQuery.HEC_DoctorID = Parameter.Doctor_ID;
            var doctor = ORM_HEC_Doctor.Query.Search(Connection, Transaction, doctorQuery).First();

            var practicesQuery = new ORM_HEC_MedicalPractis.Query();
            practicesQuery.HEC_MedicalPractiseID = Parameter.Practice_ID;
            var practices = ORM_HEC_MedicalPractis.Query.Search(Connection, Transaction, practicesQuery).First();

            var companyInfoQuery = new ORM_CMN_COM_CompanyInfo.Query();
            companyInfoQuery.CMN_COM_CompanyInfoID = practices.Ext_CompanyInfo_RefID;
            var companyInfo = ORM_CMN_COM_CompanyInfo.Query.Search(Connection, Transaction, companyInfoQuery).First();

            var bParticipantQuery = new ORM_CMN_BPT_BusinessParticipant.Query();
            bParticipantQuery.IfCompany_CMN_COM_CompanyInfo_RefID = companyInfo.CMN_COM_CompanyInfoID;
            var practice_bParticipant = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, bParticipantQuery).FirstOrDefault();

            ORM_CMN_BPT_Memo memo = new ORM_CMN_BPT_Memo();
            if (Parameter.CMN_BPT_MemoID != Guid.Empty)
            {
                var result = memo.Load(Connection, Transaction, Parameter.CMN_BPT_MemoID);
                if (result.Status != FR_Status.Success || memo.CMN_BPT_MemoID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
                memo.UpdatedBy_Account_RefID = securityTicket.AccountID;
                memo.UpdatedOn = Parameter.Creation_Timestamp;
            }
            else
            {
                ORM_DOC_Structure_Header docHeader = new ORM_DOC_Structure_Header();
                docHeader.Label = Parameter.Memo_Abbreviation + "_Header_Label";
                docHeader.Tenant_RefID = securityTicket.TenantID;
                docHeader.Save(Connection, Transaction);

                ORM_DOC_Structure docStructure = new ORM_DOC_Structure();
                docStructure.Label = Parameter.Memo_Abbreviation + "_Structure";
                docStructure.Tenant_RefID = securityTicket.TenantID;
                docStructure.Structure_Header_RefID = docHeader.DOC_Structure_HeaderID;
                docStructure.Save(Connection, Transaction);

                memo.DocumentStructureHeader_RefID = docHeader.DOC_Structure_HeaderID;
                memo.CreatedBy_Account_RefID = securityTicket.AccountID;
                memo.Creation_Timestamp = Parameter.Creation_Timestamp;
                memo.UpdatedOn = memo.Creation_Timestamp;
            }

            memo.Memo_Text = Parameter.Memo_Text;
            memo.Memo_Title = Parameter.Memo_Title;
            memo.Memo_Abbreviation = Parameter.Memo_Abbreviation;
            memo.Tenant_RefID = securityTicket.TenantID;
            memo.Save(Connection, Transaction);

            if (Parameter.AdditionalFields != null)
            {
                foreach (var AdditionalField in Parameter.AdditionalFields)
                {
                    ORM_CMN_BPT_Memo_AdditionalField addFieldItem = new ORM_CMN_BPT_Memo_AdditionalField();
                    if (AdditionalField.CMN_BPT_Memo_AdditionalFieldID != Guid.Empty)
                    {
                        var result = addFieldItem.Load(Connection, Transaction, AdditionalField.CMN_BPT_Memo_AdditionalFieldID);
                        if (result.Status != FR_Status.Success || addFieldItem.CMN_BPT_Memo_AdditionalFieldID == Guid.Empty)
                        {
                            var error = new FR_Guid();
                            error.ErrorMessage = "No Such ID";
                            error.Status = FR_Status.Error_Internal;
                            return error;
                        }
                    }
                    addFieldItem.Memo_RefID = memo.CMN_BPT_MemoID;
                    addFieldItem.Field_Key = AdditionalField.Field_Key;
                    addFieldItem.Field_Value = AdditionalField.Field_Value;
                    addFieldItem.Tenant_RefID = securityTicket.TenantID;
                    addFieldItem.Save(Connection, Transaction);
                }
            }
            var memo2DocQuery = new ORM_CMN_BPT_Memo_RelatedParticipant.Query();
            memo2DocQuery.CMN_BPT_Memo_RefID = memo.CMN_BPT_MemoID;
            memo2DocQuery.CMN_BPT_Memo_RelatedParticipantID = doctor.BusinessParticipant_RefID;
            var memo2DocQueryRes = ORM_CMN_BPT_Memo_RelatedParticipant.Query.Search(Connection, Transaction, memo2DocQuery).FirstOrDefault();
            ORM_CMN_BPT_Memo_RelatedParticipant memo2Doc;
            if(memo2DocQueryRes != null)
            {
                memo2Doc = memo2DocQueryRes;
            }
            else
            {
                memo2Doc = new ORM_CMN_BPT_Memo_RelatedParticipant();
                memo2Doc.CMN_BPT_Memo_RelatedParticipantID = Guid.NewGuid();
            }
            memo2Doc.Tenant_RefID = securityTicket.TenantID;
            memo2Doc.CMN_BPT_Memo_RefID = memo.CMN_BPT_MemoID;
            memo2Doc.CMN_BPT_BusinessParticipant_RefID = doctor.BusinessParticipant_RefID;
            memo2Doc.Save(Connection, Transaction);


 
            var memo2PracticeQuery = new ORM_CMN_BPT_Memo_RelatedParticipant.Query();
            memo2DocQuery.CMN_BPT_Memo_RefID = memo.CMN_BPT_MemoID;
            memo2DocQuery.CMN_BPT_Memo_RelatedParticipantID = practice_bParticipant.CMN_BPT_BusinessParticipantID;
            var memo2PracticeQueryRes = ORM_CMN_BPT_Memo_RelatedParticipant.Query.Search(Connection, Transaction, memo2DocQuery).FirstOrDefault();
            ORM_CMN_BPT_Memo_RelatedParticipant memo2Practice;
            if (memo2DocQueryRes != null)
            {
                memo2Practice = memo2DocQueryRes;
            }
            else
            {
                memo2Practice = new ORM_CMN_BPT_Memo_RelatedParticipant();
                memo2Practice.CMN_BPT_Memo_RelatedParticipantID = Guid.NewGuid();
            }
            memo2Practice.Tenant_RefID = securityTicket.TenantID;
            memo2Practice.CMN_BPT_Memo_RefID = memo.CMN_BPT_MemoID;
            memo2Practice.CMN_BPT_BusinessParticipant_RefID = practice_bParticipant.CMN_BPT_BusinessParticipantID;
            memo2Practice.Save(Connection, Transaction);


            returnValue.Result = memo.CMN_BPT_MemoID;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5OM_SM_0951 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5OM_SM_0951 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5OM_SM_0951 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5OM_SM_0951 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_CMN_BPT_Memo",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5OM_SM_0951 for attribute P_L5OM_SM_0951
		[DataContract]
		public class P_L5OM_SM_0951 
		{
			[DataMember]
			public P_L5OM_SM_0951_AdditionalField[] AdditionalFields { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid CMN_BPT_MemoID { get; set; } 
			[DataMember]
			public String Memo_Title { get; set; } 
			[DataMember]
			public String Memo_Abbreviation { get; set; } 
			[DataMember]
			public String Memo_Text { get; set; } 
			[DataMember]
			public DateTime UpdatedOn { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public Guid Practice_ID { get; set; } 
			[DataMember]
			public Guid Doctor_ID { get; set; } 

		}
		#endregion
		#region SClass P_L5OM_SM_0951_AdditionalField for attribute AdditionalFields
		[DataContract]
		public class P_L5OM_SM_0951_AdditionalField 
		{
			//Standard type parameters
			[DataMember]
			public String Field_Key { get; set; } 
			[DataMember]
			public Guid CMN_BPT_Memo_AdditionalFieldID { get; set; } 
			[DataMember]
			public String Field_Value { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_CMN_BPT_Memo(,P_L5OM_SM_0951 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_CMN_BPT_Memo.Invoke(connectionString,P_L5OM_SM_0951 Parameter,securityTicket);
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
var parameter = new CL5_OphthalMemos.Atomic.Manipulation.P_L5OM_SM_0951();
parameter.AdditionalFields = ...;

parameter.CMN_BPT_MemoID = ...;
parameter.Memo_Title = ...;
parameter.Memo_Abbreviation = ...;
parameter.Memo_Text = ...;
parameter.UpdatedOn = ...;
parameter.Creation_Timestamp = ...;
parameter.Practice_ID = ...;
parameter.Doctor_ID = ...;

*/
