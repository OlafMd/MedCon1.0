/* 
 * Generated on 09.03.2015 14:35:01
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

namespace CL5_MyHealthClub_Diagnosis.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Vitals.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Vitals
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5DI_SV_1333 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here

            var groupType = ORM_HEC_Patient_ParameterType_Group.Query.Search(Connection, Transaction, new ORM_HEC_Patient_ParameterType_Group.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                GlobalPropertyMatchingID = "myhealtclub.gpapp.group.custom" // promeniti
            }).SingleOrDefault();
            if (groupType == null)
            {
                groupType = new ORM_HEC_Patient_ParameterType_Group()
                {
                    GlobalPropertyMatchingID = "myhealtclub.gpapp.group.custom",
                    HEC_Patient_ParameterType_GroupID = Guid.NewGuid(),
                    Tenant_RefID = securityTicket.TenantID
                };
                groupType.Save(Connection, Transaction);
            }


            ORM_HEC_Patient_Parameter vital;

            if (Parameter.HEC_Patient_ParameterID != Guid.Empty)
            {
                vital = ORM_HEC_Patient_Parameter.Query.Search(Connection, Transaction, new ORM_HEC_Patient_Parameter.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    HEC_Patient_ParameterID = Parameter.HEC_Patient_ParameterID
                }).Single();

                returnValue.Result = vital.HEC_Patient_ParameterID;

                if (Parameter.IsDeleted)
                {
                    vital.IsDeleted = true;
                    vital.Save(Connection, Transaction);

                    var avaUnitDel = ORM_HEC_Patient_ParameterType_AvailableUnit.Query.SoftDelete(Connection, Transaction, new ORM_HEC_Patient_ParameterType_AvailableUnit.Query()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false,
                        Patient_ParameterType_RefID = vital.ParameterType_RefID
                    });

                    var typeDel = ORM_HEC_Patient_ParameterType.Query.SoftDelete(Connection, Transaction, new ORM_HEC_Patient_ParameterType.Query()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false,
                        HEC_Patient_ParameterTypeID = vital.ParameterType_RefID
                    });

                    var t2gtDel = ORM_HEC_Patient_ParameterType_2_ParameterTypeGroup.Query.SoftDelete(Connection, Transaction, new ORM_HEC_Patient_ParameterType_2_ParameterTypeGroup.Query()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false,
                        HEC_Patient_ParameterType_RefID = vital.ParameterType_RefID,
                        HEC_Patient_ParameterType_Group_RefID = groupType.HEC_Patient_ParameterType_GroupID
                    });

                }
                else
                {
                    var AvaUnit = ORM_HEC_Patient_ParameterType_AvailableUnit.Query.Search(Connection, Transaction, new ORM_HEC_Patient_ParameterType_AvailableUnit.Query()
                        {
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false,
                            Patient_ParameterType_RefID = vital.ParameterType_RefID
                        }).Single();

                    AvaUnit.Unit_RefID = Parameter.Unit_RefID;
                    AvaUnit.Save(Connection, Transaction);

                    vital.Parameter_Name = Parameter.Parameter_Name;
                    vital.IfFloat_MaxValue = Parameter.MaxValue;
                    vital.IfFloat_MinValue = Parameter.MinValue;
                    vital.Save(Connection, Transaction);
                }
            }
            else
            {
                vital = new ORM_HEC_Patient_Parameter()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsVitalParameter = true,
                    Parameter_Name = Parameter.Parameter_Name,
                    HEC_Patient_ParameterID = Guid.NewGuid(),
                    PatientParameterITL = Guid.NewGuid().ToString(),
                    IsFloat = true
                };

                returnValue.Result = vital.HEC_Patient_ParameterID;

                var type = new ORM_HEC_Patient_ParameterType()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    HEC_Patient_ParameterTypeID = Guid.NewGuid(),
                };
                type.Save(Connection, Transaction);

                vital.Parameter_Name = Parameter.Parameter_Name;
                vital.IfFloat_MaxValue = Parameter.MaxValue;
                vital.IfFloat_MinValue = Parameter.MinValue;
                vital.ParameterType_RefID = type.HEC_Patient_ParameterTypeID;
                vital.Save(Connection, Transaction);

                var t2gt = new ORM_HEC_Patient_ParameterType_2_ParameterTypeGroup()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    AssignmentID = Guid.NewGuid(),
                    HEC_Patient_ParameterType_Group_RefID = groupType.HEC_Patient_ParameterType_GroupID,
                    HEC_Patient_ParameterType_RefID = type.HEC_Patient_ParameterTypeID
                };
                t2gt.Save(Connection, Transaction);

                var AvaUnit = new ORM_HEC_Patient_ParameterType_AvailableUnit()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDefaultUnit = true,
                    Patient_ParameterType_RefID = type.HEC_Patient_ParameterTypeID,
                    HEC_Patient_ParameterType_AvailableUnitID = Guid.NewGuid(),
                    Unit_RefID = Parameter.Unit_RefID
                };
                AvaUnit.Save(Connection, Transaction);
            }


			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5DI_SV_1333 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5DI_SV_1333 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5DI_SV_1333 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5DI_SV_1333 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Vitals",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5DI_SV_1333 for attribute P_L5DI_SV_1333
		[DataContract]
		public class P_L5DI_SV_1333 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_Patient_ParameterID { get; set; } 
			[DataMember]
			public Guid Unit_RefID { get; set; } 
			[DataMember]
			public Dict Parameter_Name { get; set; } 
			[DataMember]
			public double MinValue { get; set; } 
			[DataMember]
			public double MaxValue { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Vitals(,P_L5DI_SV_1333 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Vitals.Invoke(connectionString,P_L5DI_SV_1333 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_Diagnosis.Atomic.Manipulation.P_L5DI_SV_1333();
parameter.HEC_Patient_ParameterID = ...;
parameter.Unit_RefID = ...;
parameter.Parameter_Name = ...;
parameter.MinValue = ...;
parameter.MaxValue = ...;
parameter.IsDeleted = ...;

*/
