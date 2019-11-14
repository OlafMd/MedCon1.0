/* 
 * Generated on 8/12/2014 11:35:20 AM
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
using CL1_PPS_TSK;
using CL1_CMN_CAL_AVA;
using DLCore_DBCommons.Utils;
using DLCore_DBCommons.MyHealthClub;

namespace CL5_MyHealthClub_TaskTemplate.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_TaskTemplate.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_TaskTemplate
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5TA_STT_1548 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_Guid();
            //Put your code here
            #region Save
            if (Parameter.PPS_TSK_Task_TemplateID == Guid.Empty)
            {
                //=====================New Task=====================
                ORM_PPS_TSK_Task_Template task = new ORM_PPS_TSK_Task_Template();
                task.PPS_TSK_Task_TemplateID = Guid.NewGuid();
                task.TaskTemplateName = Parameter.TaskTemplateName;
                task.Duration_EstimatedMax_in_sec = Parameter.Duration_EstimatedMax_in_sec;
                task.Duration_Recommended_in_sec = Parameter.Duration_Recommended_in_sec;
                task.IsDeleted = false;
                task.Tenant_RefID = securityTicket.TenantID;

                //=====================Excluded availability types=====================
                if (!Parameter.IsWebBooking)
                {
                    var availabilityType = ORM_CMN_CAL_AVA_Availability_Type.Query.Search(Connection, Transaction, new ORM_CMN_CAL_AVA_Availability_Type.Query
                    {
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID,
                        GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(AvailabilityType.WebBooking)
                    }).First();

                    ORM_PPS_TSK_Task_Template_ExcludedAvailabilityType excludedTypes = new ORM_PPS_TSK_Task_Template_ExcludedAvailabilityType();
                    excludedTypes.PPS_TSK_Task_Template_ExcludedAvailabilityTypeID = Guid.NewGuid();
                    excludedTypes.PPS_TSK_Task_Template_RefID = task.PPS_TSK_Task_TemplateID;
                    excludedTypes.Excluded_Availability_Type_RefID = availabilityType.CMN_CAL_AVA_Availability_TypeID;
                    excludedTypes.IsDeleted = false;
                    excludedTypes.Tenant_RefID = securityTicket.TenantID;
                    excludedTypes.Save(Connection, Transaction);
                }
                //=====================New Staff=====================
                if (Parameter.Staff != null && Parameter.Staff.Count() > 0)
                {
                    foreach (var staffParam in Parameter.Staff)
                    {
                        if (staffParam.IsDeleted == false)
                        {
                            ORM_PPS_TSK_Task_RequiredStaff staff = new ORM_PPS_TSK_Task_RequiredStaff();
                            staff.PPS_TSK_Task_RequiredStaffID = Guid.NewGuid();
                            staff.TaskTemplate_RefID = task.PPS_TSK_Task_TemplateID;
                            staff.StaffQuantity = staffParam.StaffQuantity;
                            staff.IsDeleted = false;
                            if (staffParam.Required_Employee_RefID != Guid.Empty) //required employee
                                staff.Required_Employee_RefID = staffParam.Required_Employee_RefID;
                            staff.Tenant_RefID = securityTicket.TenantID;
                            staff.Save(Connection, Transaction);
                            //=====================New Profession=====================
                            if (staffParam.CMN_STR_Profession_RefID != Guid.Empty)
                            {
                                ORM_PPS_TSK_Task_RequiredStaff_Profession profession = new ORM_PPS_TSK_Task_RequiredStaff_Profession();
                                profession.PPS_TSK_Task_RequiredStaff_ProfessionID = Guid.NewGuid();
                                profession.RequiredStaff_RefID = staff.PPS_TSK_Task_RequiredStaffID;
                                profession.CMN_STR_Profession_RefID = staffParam.CMN_STR_Profession_RefID;
                                profession.IsDeleted = false;
                                profession.Tenant_RefID = securityTicket.TenantID;
                                profession.Save(Connection, Transaction);
                            }
                            //=====================New Skill=====================
                            if (staffParam.StaffSkill != null && staffParam.StaffSkill.Count() > 0)
                            {
                                foreach (var skillParam in staffParam.StaffSkill)
                                {
                                    if (skillParam.IsDeleted == false)
                                    {
                                        ORM_PPS_TSK_Task_RequiredStaff_Skill skill = new ORM_PPS_TSK_Task_RequiredStaff_Skill();
                                        skill.PPS_TSK_Task_RequiredStaff_SkillID = Guid.NewGuid();
                                        skill.RequiredStaff_RefID = staff.PPS_TSK_Task_RequiredStaffID;
                                        skill.CMN_STR_Skill_RefID = skillParam.CMN_STR_Skill_RefID;
                                        skill.IsDeleted = false;
                                        skill.Tenant_RefID = securityTicket.TenantID;
                                        skill.Save(Connection, Transaction);
                                    }
                                }
                            }

                        }
                    }
                }
                //=====================New Devices=====================
                if (Parameter.Devices != null && Parameter.Devices.Count() > 0)
                {
                    foreach (var deviceParam in Parameter.Devices)
                    {
                        if (deviceParam.IsDeleted == false)
                        {
                            ORM_PPS_TSK_Task_Template_RequiredDevice device = new ORM_PPS_TSK_Task_Template_RequiredDevice();
                            device.PPS_TSK_Task_Template_RequiredDeviceID = Guid.NewGuid();
                            device.TaskTemplate_RefID = task.PPS_TSK_Task_TemplateID;
                            device.DEV_Device_RefID = deviceParam.DEV_Device_RefID;
                            device.RequiredQuantity = deviceParam.RequiredQuantity;
                            device.IsDeleted = false;
                            device.Tenant_RefID = securityTicket.TenantID;
                            device.Save(Connection, Transaction);
                        }
                    }
                }
                task.Save(Connection, Transaction);
                returnValue.Result = task.PPS_TSK_Task_TemplateID;
            }
            #endregion
            //=====================Edit or Delete=====================
            else
            {
                var task = ORM_PPS_TSK_Task_Template.Query.Search(Connection, Transaction, new ORM_PPS_TSK_Task_Template.Query
                {
                    PPS_TSK_Task_TemplateID = Parameter.PPS_TSK_Task_TemplateID,
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                }).Single();
                #region Edit
                if (Parameter.IsDeleted == false)
                {
                    task.TaskTemplateName = Parameter.TaskTemplateName;
                    task.Duration_EstimatedMax_in_sec = Parameter.Duration_EstimatedMax_in_sec;
                    task.Duration_Recommended_in_sec = Parameter.Duration_Recommended_in_sec;

                    //=====================Edit excluded availability types=====================
                    var existingAvailabilityType = ORM_PPS_TSK_Task_Template_ExcludedAvailabilityType.Query.Search(Connection, Transaction, new ORM_PPS_TSK_Task_Template_ExcludedAvailabilityType.Query
                    {
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID,
                        PPS_TSK_Task_Template_RefID = task.PPS_TSK_Task_TemplateID
                    }).FirstOrDefault();

                    if (!Parameter.IsWebBooking)
                    {
                        if (existingAvailabilityType == null)
                        {
                            var availabilityType = ORM_CMN_CAL_AVA_Availability_Type.Query.Search(Connection, Transaction, new ORM_CMN_CAL_AVA_Availability_Type.Query
                            {
                                IsDeleted = false,
                                Tenant_RefID = securityTicket.TenantID,
                                GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(AvailabilityType.WebBooking)
                            }).First();

                            ORM_PPS_TSK_Task_Template_ExcludedAvailabilityType excludedTypes = new ORM_PPS_TSK_Task_Template_ExcludedAvailabilityType();
                            excludedTypes.PPS_TSK_Task_Template_ExcludedAvailabilityTypeID = Guid.NewGuid();
                            excludedTypes.PPS_TSK_Task_Template_RefID = task.PPS_TSK_Task_TemplateID;
                            excludedTypes.Excluded_Availability_Type_RefID = availabilityType.CMN_CAL_AVA_Availability_TypeID;
                            excludedTypes.IsDeleted = false;
                            excludedTypes.Tenant_RefID = securityTicket.TenantID;
                            excludedTypes.Save(Connection, Transaction);
                        }
                    }
                    else
                    {
                        if (existingAvailabilityType != null)
                        {
                            existingAvailabilityType.IsDeleted = true;
                            existingAvailabilityType.Save(Connection, Transaction);
                        }
                    }
                    //=====================Edit Staff=====================
                    if (Parameter.Staff != null)
                    {
                        foreach (var staffParam in Parameter.Staff)
                        {
                            var existingStaff = ORM_PPS_TSK_Task_RequiredStaff.Query.Search(Connection, Transaction, new ORM_PPS_TSK_Task_RequiredStaff.Query
                            {
                                PPS_TSK_Task_RequiredStaffID = staffParam.PPS_TSK_Task_RequiredStaffID,
                                TaskTemplate_RefID = Parameter.PPS_TSK_Task_TemplateID,
                                IsDeleted = false,
                                Tenant_RefID = securityTicket.TenantID
                            }).SingleOrDefault();
                            //=====================New Staff=====================
                            if (existingStaff == null && !staffParam.IsDeleted)
                            {
                                ORM_PPS_TSK_Task_RequiredStaff staff = new ORM_PPS_TSK_Task_RequiredStaff();
                                staff.PPS_TSK_Task_RequiredStaffID = Guid.NewGuid();
                                staff.TaskTemplate_RefID = task.PPS_TSK_Task_TemplateID;
                                staff.StaffQuantity = staffParam.StaffQuantity;
                                staff.IsDeleted = false;
                                if (staffParam.Required_Employee_RefID != Guid.Empty) //required employee
                                    staff.Required_Employee_RefID = staffParam.Required_Employee_RefID;
                                staff.Tenant_RefID = securityTicket.TenantID;
                                staff.Save(Connection, Transaction);
                                //=====================New Profession=====================
                                if (staffParam.CMN_STR_Profession_RefID != Guid.Empty)
                                {
                                    ORM_PPS_TSK_Task_RequiredStaff_Profession profession = new ORM_PPS_TSK_Task_RequiredStaff_Profession();
                                    profession.PPS_TSK_Task_RequiredStaff_ProfessionID = Guid.NewGuid();
                                    profession.RequiredStaff_RefID = staff.PPS_TSK_Task_RequiredStaffID;
                                    profession.CMN_STR_Profession_RefID = staffParam.CMN_STR_Profession_RefID;
                                    profession.IsDeleted = false;
                                    profession.Tenant_RefID = securityTicket.TenantID;
                                    profession.Save(Connection, Transaction);
                                }
                                //=====================New Skill=====================
                                if (staffParam.StaffSkill != null && staffParam.StaffSkill.Count() > 0)
                                {
                                    foreach (var skillParam in staffParam.StaffSkill)
                                    {
                                        if (skillParam.IsDeleted == false)
                                        {
                                            ORM_PPS_TSK_Task_RequiredStaff_Skill skill = new ORM_PPS_TSK_Task_RequiredStaff_Skill();
                                            skill.PPS_TSK_Task_RequiredStaff_SkillID = Guid.NewGuid();
                                            skill.RequiredStaff_RefID = staff.PPS_TSK_Task_RequiredStaffID;
                                            skill.CMN_STR_Skill_RefID = skillParam.CMN_STR_Skill_RefID;
                                            skill.IsDeleted = false;
                                            skill.Tenant_RefID = securityTicket.TenantID;
                                            skill.Save(Connection, Transaction);
                                        }
                                    }
                                }
                            }
                            //=====================Delete Staff which exists in the database but not in the parameter=====================
                            else if (existingStaff != null && staffParam.IsDeleted)
                            {
                                ORM_PPS_TSK_Task_RequiredStaff_Skill.Query.SoftDelete(Connection, Transaction, new ORM_PPS_TSK_Task_RequiredStaff_Skill.Query
                                {
                                    RequiredStaff_RefID = existingStaff.PPS_TSK_Task_RequiredStaffID,
                                    IsDeleted = false,
                                    Tenant_RefID = securityTicket.TenantID
                                });
                                ORM_PPS_TSK_Task_RequiredStaff_Profession.Query.SoftDelete(Connection, Transaction, new ORM_PPS_TSK_Task_RequiredStaff_Profession.Query
                                {
                                    RequiredStaff_RefID = existingStaff.PPS_TSK_Task_RequiredStaffID,
                                    IsDeleted = false,
                                    Tenant_RefID = securityTicket.TenantID
                                });
                                existingStaff.IsDeleted = true;
                                existingStaff.Save(Connection, Transaction);
                            }
                            //=====================Edit Staff=====================
                            else if (existingStaff != null && existingStaff.Required_Employee_RefID == Guid.Empty) //if staff is not required employee
                            {
                                //=====================Edit profession=====================
                                var existingProfession = ORM_PPS_TSK_Task_RequiredStaff_Profession.Query.Search(Connection, Transaction, new ORM_PPS_TSK_Task_RequiredStaff_Profession.Query
                                {
                                    RequiredStaff_RefID = existingStaff.PPS_TSK_Task_RequiredStaffID,
                                    IsDeleted = false,
                                    Tenant_RefID = securityTicket.TenantID
                                }).SingleOrDefault();
                                if (existingProfession != null)
                                {
                                    existingProfession.CMN_STR_Profession_RefID = staffParam.CMN_STR_Profession_RefID;
                                    existingProfession.Save(Connection, Transaction);
                                }
                                else
                                {
                                    ORM_PPS_TSK_Task_RequiredStaff_Profession profession = new ORM_PPS_TSK_Task_RequiredStaff_Profession();
                                    profession.PPS_TSK_Task_RequiredStaff_ProfessionID = Guid.NewGuid();
                                    profession.RequiredStaff_RefID = existingStaff.PPS_TSK_Task_RequiredStaffID;
                                    profession.CMN_STR_Profession_RefID = staffParam.CMN_STR_Profession_RefID;
                                    profession.IsDeleted = false;
                                    profession.Tenant_RefID = securityTicket.TenantID;
                                    profession.Save(Connection, Transaction);
                                }
                                //=====================Edit skill=====================
                                foreach (var skillParam in staffParam.StaffSkill)
                                {
                                    var existingSkill = ORM_PPS_TSK_Task_RequiredStaff_Skill.Query.Search(Connection, Transaction, new ORM_PPS_TSK_Task_RequiredStaff_Skill.Query
                                    {
                                        RequiredStaff_RefID = existingStaff.PPS_TSK_Task_RequiredStaffID,
                                        CMN_STR_Skill_RefID = skillParam.CMN_STR_Skill_RefID,
                                        IsDeleted = false,
                                        Tenant_RefID = securityTicket.TenantID
                                    }).SingleOrDefault();
                                    //=====================New Skill=====================
                                    if (existingSkill == null && !skillParam.IsDeleted)
                                    {
                                        ORM_PPS_TSK_Task_RequiredStaff_Skill newSkill = new ORM_PPS_TSK_Task_RequiredStaff_Skill();
                                        newSkill.PPS_TSK_Task_RequiredStaff_SkillID = Guid.NewGuid();
                                        newSkill.CMN_STR_Skill_RefID = skillParam.CMN_STR_Skill_RefID;
                                        newSkill.RequiredStaff_RefID = staffParam.PPS_TSK_Task_RequiredStaffID;
                                        newSkill.IsDeleted = false;
                                        newSkill.Tenant_RefID = securityTicket.TenantID;
                                        newSkill.Save(Connection, Transaction);
                                    }
                                    //=====================Delete Skill=====================
                                    else if (existingSkill != null && skillParam.IsDeleted)
                                    {
                                        existingSkill.IsDeleted = true;
                                        existingSkill.Save(Connection, Transaction);
                                    }
                                }
                                //=====================Edit staff quantity=====================
                                existingStaff.StaffQuantity = staffParam.StaffQuantity;
                                existingStaff.Tenant_RefID = securityTicket.TenantID;
                                existingStaff.Save(Connection, Transaction);
                            }
                        }
                    }
                    //=====================Edit Device=====================
                    if (Parameter.Devices != null)
                    {
                        foreach (var deviceParam in Parameter.Devices)
                        {
                            var existingDevice = ORM_PPS_TSK_Task_Template_RequiredDevice.Query.Search(Connection, Transaction, new ORM_PPS_TSK_Task_Template_RequiredDevice.Query
                            {
                                PPS_TSK_Task_Template_RequiredDeviceID = deviceParam.PPS_TSK_Task_Template_RequiredDeviceID,
                                TaskTemplate_RefID = Parameter.PPS_TSK_Task_TemplateID,
                                IsDeleted = false,
                                Tenant_RefID = securityTicket.TenantID
                            }).SingleOrDefault();
                            //=====================New Devices=====================
                            if (existingDevice == null && !deviceParam.IsDeleted)
                            {
                                ORM_PPS_TSK_Task_Template_RequiredDevice device = new ORM_PPS_TSK_Task_Template_RequiredDevice();
                                device.PPS_TSK_Task_Template_RequiredDeviceID = Guid.NewGuid();
                                device.TaskTemplate_RefID = task.PPS_TSK_Task_TemplateID;
                                device.DEV_Device_RefID = deviceParam.DEV_Device_RefID;
                                device.RequiredQuantity = deviceParam.RequiredQuantity;
                                device.IsDeleted = false;
                                device.Tenant_RefID = securityTicket.TenantID;
                                device.Save(Connection, Transaction);
                            }
                            //=====================Edit Devices=====================
                            else if (existingDevice != null)
                            {
                                existingDevice.IsDeleted = deviceParam.IsDeleted;
                                existingDevice.RequiredQuantity = deviceParam.RequiredQuantity;
                                existingDevice.Tenant_RefID = securityTicket.TenantID;
                                existingDevice.Save(Connection, Transaction);
                            }
                        }
                    }
                }
                #endregion
                #region Delete
                else
                {
                    //=====================Delete ExcludedAvailabilityType=====================
                    var existingAvailabilityType = ORM_PPS_TSK_Task_Template_ExcludedAvailabilityType.Query.SoftDelete(Connection, Transaction, new ORM_PPS_TSK_Task_Template_ExcludedAvailabilityType.Query
                    {
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID,
                        PPS_TSK_Task_Template_RefID = task.PPS_TSK_Task_TemplateID
                    });
                    //=====================Delete Staff=====================
                    var staffForDelete = ORM_PPS_TSK_Task_RequiredStaff.Query.Search(Connection, Transaction, new ORM_PPS_TSK_Task_RequiredStaff.Query
                    {
                        TaskTemplate_RefID = Parameter.PPS_TSK_Task_TemplateID,
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID
                    }).ToList();
                    foreach (var staff in staffForDelete)
                    {
                        ORM_PPS_TSK_Task_RequiredStaff_Skill.Query.SoftDelete(Connection, Transaction, new ORM_PPS_TSK_Task_RequiredStaff_Skill.Query
                        {
                            RequiredStaff_RefID = staff.PPS_TSK_Task_RequiredStaffID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        });
                        ORM_PPS_TSK_Task_RequiredStaff_Profession.Query.SoftDelete(Connection, Transaction, new ORM_PPS_TSK_Task_RequiredStaff_Profession.Query
                        {
                            RequiredStaff_RefID = staff.PPS_TSK_Task_RequiredStaffID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        });
                    }
                    ORM_PPS_TSK_Task_RequiredStaff.Query.SoftDelete(Connection, Transaction, new ORM_PPS_TSK_Task_RequiredStaff.Query
                    {
                        TaskTemplate_RefID = Parameter.PPS_TSK_Task_TemplateID,
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID
                    });
                    //=====================Delete Devices=====================
                    var devicesForDelete = ORM_PPS_TSK_Task_Template_RequiredDevice.Query.SoftDelete(Connection, Transaction, new ORM_PPS_TSK_Task_Template_RequiredDevice.Query
                    {
                        TaskTemplate_RefID = Parameter.PPS_TSK_Task_TemplateID,
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID
                    });
                    task.IsDeleted = true;
                }
                #endregion
                task.Save(Connection, Transaction);
                returnValue.Result = task.PPS_TSK_Task_TemplateID;
            }

            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5TA_STT_1548 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5TA_STT_1548 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5TA_STT_1548 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5TA_STT_1548 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_TaskTemplate",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5TA_STT_1548 for attribute P_L5TA_STT_1548
		[DataContract]
		public class P_L5TA_STT_1548 
		{
			[DataMember]
			public P_L5TA_STT_1548_Device[] Devices { get; set; }
			[DataMember]
			public P_L5TA_STT_1548_Staff[] Staff { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid PPS_TSK_Task_TemplateID { get; set; } 
			[DataMember]
			public long Duration_EstimatedMax_in_sec { get; set; } 
			[DataMember]
			public Dict TaskTemplateName { get; set; } 
			[DataMember]
			public long Duration_Recommended_in_sec { get; set; } 
			[DataMember]
			public long Duration_EstimatedMin_in_sec { get; set; } 
			[DataMember]
			public String TaskTemplateNumber { get; set; } 
			[DataMember]
			public bool IsWebBooking { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 

		}
		#endregion
		#region SClass P_L5TA_STT_1548_Device for attribute Devices
		[DataContract]
		public class P_L5TA_STT_1548_Device 
		{
			//Standard type parameters
			[DataMember]
			public Guid PPS_TSK_Task_Template_RequiredDeviceID { get; set; } 
			[DataMember]
			public int RequiredQuantity { get; set; } 
			[DataMember]
			public Guid DEV_Device_RefID { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 

		}
		#endregion
		#region SClass P_L5TA_STT_1548_Staff for attribute Staff
		[DataContract]
		public class P_L5TA_STT_1548_Staff 
		{
			[DataMember]
			public P_L5TA_STT_1548_StaffSkill[] StaffSkill { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid PPS_TSK_Task_RequiredStaffID { get; set; } 
			[DataMember]
			public int StaffQuantity { get; set; } 
			[DataMember]
			public Guid Required_Employee_RefID { get; set; } 
			[DataMember]
			public Guid CMN_STR_Profession_RefID { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 

		}
		#endregion
		#region SClass P_L5TA_STT_1548_StaffSkill for attribute StaffSkill
		[DataContract]
		public class P_L5TA_STT_1548_StaffSkill 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_STR_Skill_RefID { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_TaskTemplate(,P_L5TA_STT_1548 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_TaskTemplate.Invoke(connectionString,P_L5TA_STT_1548 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_TaskTemplate.Atomic.Manipulation.P_L5TA_STT_1548();
parameter.Devices = ...;
parameter.Staff = ...;

parameter.PPS_TSK_Task_TemplateID = ...;
parameter.Duration_EstimatedMax_in_sec = ...;
parameter.TaskTemplateName = ...;
parameter.Duration_Recommended_in_sec = ...;
parameter.Duration_EstimatedMin_in_sec = ...;
parameter.TaskTemplateNumber = ...;
parameter.IsWebBooking = ...;
parameter.IsDeleted = ...;

*/
