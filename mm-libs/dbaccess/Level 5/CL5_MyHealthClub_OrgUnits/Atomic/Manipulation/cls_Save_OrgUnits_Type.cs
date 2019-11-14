/* 
 * Generated on 8.9.2014 9:52:05
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
using CL3_Offices.Atomic.Manipulation;
using CL1_CMN_STR;
using CL1_HEC;

namespace CL5_MyHealthClub_OrgUnits.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_OrgUnits_Type.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_OrgUnits_Type
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5OU_SOUT_0934 Execute(DbConnection Connection,DbTransaction Transaction,P_L5OU_SOUT_0934 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5OU_SOUT_0934();
			//Put your code here

            returnValue.Result = new L5OU_SOUT_0934();

            Guid orgUnitTypeId = Guid.Empty;
            if (!Parameter.BaseData.IsDeleted)
            {
                orgUnitTypeId = cls_Save_MedicalPracticeType.Invoke(Connection, Transaction, Parameter.BaseData, securityTicket).Result;
            }
            else
            {
                List<ORM_HEC_MedicalPractice_2_PracticeType> existingOffice = ORM_HEC_MedicalPractice_2_PracticeType.Query.Search(Connection, Transaction, new ORM_HEC_MedicalPractice_2_PracticeType.Query
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    HEC_MedicalPractice_Type_RefID = Parameter.BaseData.HEC_MedicalPractice_TypeID
                }).ToList();

                if (existingOffice.Count > 0) //cannot delete
                {

                    List<ORM_HEC_MedicalPractis> medicalPracticesList = new List<ORM_HEC_MedicalPractis>();
                    foreach (var item in existingOffice)
                    {
                        ORM_HEC_MedicalPractis medPractice = ORM_HEC_MedicalPractis.Query.Search(Connection, Transaction, new ORM_HEC_MedicalPractis.Query
                        {
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID,
                            HEC_MedicalPractiseID = item.HEC_MedicalPractice_RefID
                        }).Single();

                        medicalPracticesList.Add(new ORM_HEC_MedicalPractis { HEC_MedicalPractiseID = item.HEC_MedicalPractice_RefID });
                    };

                    if (medicalPracticesList.Count > 0) //cannot delete
                    {
                        List<L5OU_SOUT_0934_UsedInOrgUnit> usedOrgUnitList = new List<L5OU_SOUT_0934_UsedInOrgUnit>();

                        foreach (var item in medicalPracticesList)
                        {
                            ORM_CMN_STR_Office officeName = ORM_CMN_STR_Office.Query.Search(Connection, Transaction, new ORM_CMN_STR_Office.Query
                            {
                                IsDeleted = false,
                                Tenant_RefID = securityTicket.TenantID,
                                IfMedicalPractise_HEC_MedicalPractice_RefID = item.HEC_MedicalPractiseID
                            }).Single();

                            usedOrgUnitList.Add(new L5OU_SOUT_0934_UsedInOrgUnit { OrgUnitName = officeName.Office_Name });
                        }
                        returnValue.Result.UsedInOrgUnit = usedOrgUnitList.ToArray();
                    }
                }
                if (existingOffice.Count == 0)
                {
                    orgUnitTypeId = cls_Save_MedicalPracticeType.Invoke(Connection, Transaction, Parameter.BaseData, securityTicket).Result;
                }
            }
            returnValue.Result.ID = orgUnitTypeId;

			return returnValue;
          }

		#endregion UserCode
		
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5OU_SOUT_0934 Invoke(string ConnectionString,P_L5OU_SOUT_0934 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5OU_SOUT_0934 Invoke(DbConnection Connection,P_L5OU_SOUT_0934 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5OU_SOUT_0934 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5OU_SOUT_0934 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5OU_SOUT_0934 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5OU_SOUT_0934 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5OU_SOUT_0934 functionReturn = new FR_L5OU_SOUT_0934();
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

				throw new Exception("Exception occured in method cls_Save_OrgUnits_Type",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5OU_SOUT_0934 : FR_Base
	{
		public L5OU_SOUT_0934 Result	{ get; set; }

		public FR_L5OU_SOUT_0934() : base() {}

		public FR_L5OU_SOUT_0934(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5OU_SOUT_0934 for attribute P_L5OU_SOUT_0934
		[DataContract]
		public class P_L5OU_SOUT_0934 
		{
			//Standard type parameters
			[DataMember]
			public P_L3O_SMPT_1719 BaseData { get; set; } 

		}
		#endregion
		#region SClass L5OU_SOUT_0934 for attribute L5OU_SOUT_0934
		[DataContract]
		public class L5OU_SOUT_0934 
		{
			[DataMember]
			public L5OU_SOUT_0934_UsedInOrgUnit[] UsedInOrgUnit { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid ID { get; set; } 

		}
		#endregion
		#region SClass L5OU_SOUT_0934_UsedInOrgUnit for attribute UsedInOrgUnit
		[DataContract]
		public class L5OU_SOUT_0934_UsedInOrgUnit 
		{
			//Standard type parameters
			[DataMember]
			public Dict OrgUnitName { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5OU_SOUT_0934 cls_Save_OrgUnits_Type(,P_L5OU_SOUT_0934 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5OU_SOUT_0934 invocationResult = cls_Save_OrgUnits_Type.Invoke(connectionString,P_L5OU_SOUT_0934 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_OrgUnits.Atomic.Manipulation.P_L5OU_SOUT_0934();
parameter.BaseData = ...;

*/
