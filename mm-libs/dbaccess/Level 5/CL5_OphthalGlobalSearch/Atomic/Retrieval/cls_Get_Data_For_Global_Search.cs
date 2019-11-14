/* 
 * Generated on 9/10/2013 10:36:30 AM
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
using CL3_MedicalPractices.Atomic.Retrieval;
using CL3_MedicalProducts.Complex.Retrieval;
using CL5_OphthalMemos.Atomic.Retrieval;
using CL5_OphthalDoctors.Complex.Retrieval;
using CL5_OphthalDoctors.Atomic.Retrieval;
using CL5_OphthalPractices.Atomic.Retrieval;
using CL3_MedicalPractices.Complex.Retrieval;
using Core_ClassLibrarySupport.Utils;
using Core_ClassLibrarySupport.Inscpecific;

namespace CL5_OphthalGlobalSearch.Atomic.Retrieval
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
		protected static FR_L5OGL_GDFGS_1429 Execute(DbConnection Connection,DbTransaction Transaction,P_L5OGL_GDFGS_1429 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5OGL_GDFGS_1429();
            //P_L5OD_GSDOCFT_1718 param = new P_L5OD_GSDOCFT_1718();
            //param.ContactTypeID = STLD_ContactTypes.Email;
            var allDoctors = cls_Get_OphthalDoctors_For_Tenant.Invoke(Connection, Transaction, securityTicket).Result.ToList();
            var allMemos = cls_Get_Memos_for_Tenant.Invoke(Connection, Transaction, securityTicket).Result.ToList();
            var allPractices = cls_Get_Practice_For_Tenant.Invoke(Connection, Transaction, securityTicket).Result.ToList();
            var allProducts = cls_Get_Products_for_TenantID.Invoke(Connection, Transaction, securityTicket).Result.ToList();
            var filteredPractices = allPractices.Where(p => p.BaseInfo.PracticeName.ContainsIgnoreCase(Parameter.Term) ||
                                                       (p.ContactPerson != null && p.ContactPerson.Ophthal_ContactPerson.ContainsIgnoreCase(Parameter.Term)) ||
                                                       p.BaseInfo.Street_Name.ContainsIgnoreCase(Parameter.Term) ||
                                                       p.BaseInfo.Street_Number.ContainsIgnoreCase(Parameter.Term) ||
                                                       p.BaseInfo.Town.ContainsIgnoreCase(Parameter.Term) ||
                                                       p.BaseInfo.ZIP.ContainsIgnoreCase(Parameter.Term) ||
                                                       p.BaseInfo.Region_Name.ContainsIgnoreCase(Parameter.Term) ||
                                                       (p.ShippingAddress != null && p.ShippingAddress.Street_Name.ContainsIgnoreCase(Parameter.Term)) ||
                                                       (p.ShippingAddress != null && p.ShippingAddress.Street_Number.ContainsIgnoreCase(Parameter.Term)) ||
                                                       (p.ShippingAddress != null && p.ShippingAddress.Town.ContainsIgnoreCase(Parameter.Term)) ||
                                                       (p.ShippingAddress != null && p.ShippingAddress.ZIP.ContainsIgnoreCase(Parameter.Term)) ||
                                                       (p.ShippingAddress != null && p.ShippingAddress.Region_Name.ContainsIgnoreCase(Parameter.Term)) ||
                                                       (p.BaseInfo != null && p.BaseInfo.PracticeEmail.ContainsIgnoreCase(Parameter.Term)));
            var filteredDoctors = allDoctors.Where(d => d.FirstName.ContainsIgnoreCase(Parameter.Term) ||
                                                        d.LastName.ContainsIgnoreCase(Parameter.Term) ||
                                                        d.BaseInfo.LoginEmail.ContainsIgnoreCase(Parameter.Term) ||
                                                        (d.BaseInfo.ContactTypes.Where(c => c.Contact_Type == STLD_ContactTypes.Email).Count() > 0 && d.BaseInfo.ContactTypes.Where(c => c.Contact_Type == STLD_ContactTypes.Email).First().Content.ContainsIgnoreCase(Parameter.Term)) ||
                                                        d.Title.ContainsIgnoreCase(Parameter.Term) ||
                                                        (d.Practice != null && d.Practice.AssociatedParticipant_FunctionName.ContainsIgnoreCase(Parameter.Term)));
            var filteredProducts = allProducts.Where(p => p.Product_Name_DictID.GetContent(Parameter.LanguageID).ContainsIgnoreCase(Parameter.Term));
            List<L5OM_GMFT_1018> filteredMemos = new List<L5OM_GMFT_1018>();
            foreach (var memo in allMemos)
            {
                if (memo.Memo_Title.ContainsIgnoreCase(Parameter.Term))
                {
                    filteredMemos.Add(memo);
                    break;
                }
                else if (memo.UpdatedOn.ToString().ContainsIgnoreCase(Parameter.Term))
                {
                    filteredMemos.Add(memo);
                    break;
                }
                else if (memo.Memo_Abbreviation.ContainsIgnoreCase(Parameter.Term))
                {
                    filteredMemos.Add(memo);
                    break;
                }
                else if (memo.AdditionalFields[0] != null)
                {
                    if (memo.AdditionalFields[0].Field_Value.ContainsIgnoreCase(Parameter.Term))
                    {
                        filteredMemos.Add(memo);
                        break;
                    }
                }

                var doctorsMemo = allDoctors.FirstOrDefault(d => d.BaseInfo.Doctor_CMN_BPT_BusinessParticipantID == memo.Doctor_CMN_BPT_BusinessParticipantID);
                if (doctorsMemo != null)
                {
                    if ((doctorsMemo.FirstName + " " + doctorsMemo.LastName).ContainsIgnoreCase(Parameter.Term))
                    {
                        filteredMemos.Add(memo);
                        break;
                    }
                }

                var memosPractice = allPractices.FirstOrDefault(p => p.BaseInfo.CMN_BPT_BusinessParticipantID == memo.Doctor_CMN_BPT_BusinessParticipantID);
                if (memosPractice != null)
                {
                    if (memosPractice.BaseInfo.PracticeName.ContainsIgnoreCase(Parameter.Term))
                    {
                        filteredMemos.Add(memo);
                        break;
                    }
                }

            }

            returnValue.Result = new L5OGL_GDFGS_1429();
            returnValue.Result.Doctors = filteredDoctors.ToArray();
            returnValue.Result.Practices = filteredPractices.ToArray();
            returnValue.Result.Products = filteredProducts.ToArray();
            returnValue.Result.Memos = filteredMemos.ToArray();
            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5OGL_GDFGS_1429 Invoke(string ConnectionString,P_L5OGL_GDFGS_1429 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5OGL_GDFGS_1429 Invoke(DbConnection Connection,P_L5OGL_GDFGS_1429 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5OGL_GDFGS_1429 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5OGL_GDFGS_1429 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5OGL_GDFGS_1429 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5OGL_GDFGS_1429 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5OGL_GDFGS_1429 functionReturn = new FR_L5OGL_GDFGS_1429();
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
	public class FR_L5OGL_GDFGS_1429 : FR_Base
	{
		public L5OGL_GDFGS_1429 Result	{ get; set; }

		public FR_L5OGL_GDFGS_1429() : base() {}

		public FR_L5OGL_GDFGS_1429(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5OGL_GDFGS_1429 for attribute P_L5OGL_GDFGS_1429
		[DataContract]
		public class P_L5OGL_GDFGS_1429 
		{
			//Standard type parameters
			[DataMember]
			public Guid LanguageID { get; set; } 
			[DataMember]
			public String Term { get; set; } 

		}
		#endregion
		#region SClass L5OGL_GDFGS_1429 for attribute L5OGL_GDFGS_1429
		[DataContract]
		public class L5OGL_GDFGS_1429 
		{
			//Standard type parameters
			[DataMember]
            public L5OD_GDfT_1126[] Doctors { get; set; } 
			[DataMember]
            public L3MP_GPfT_1209[] Practices { get; set; } 
			[DataMember]
			public L3MP_GPfTID_1602[] Products { get; set; } 
			[DataMember]
			public L5OM_GMFT_1018[] Memos { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5OGL_GDFGS_1429 cls_Get_Data_For_Global_Search(,P_L5OGL_GDFGS_1429 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5OGL_GDFGS_1429 invocationResult = cls_Get_Data_For_Global_Search.Invoke(connectionString,P_L5OGL_GDFGS_1429 Parameter,securityTicket);
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
var parameter = new CL5_OphthalGlobalSearch.Atomic.Retrieval.P_L5OGL_GDFGS_1429();
parameter.LanguageID = ...;
parameter.Term = ...;

*/
