/* 
 * Generated on 01-Dec-14 4:54:25 PM
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
using CL2_Project.Atomic.Retrieval;
using CL2_BusinessTask.Atomic.Retrieval;

namespace CL3_Features.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Features_DropDownMenuItems.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Features_DropDownMenuItems
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3FE_GFDDMI_1652_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_L3FE_GFDDMI_1652_Array();
            returnValue.Result = new L3FE_GFDDMI_1652[0];
            //Put your code here

            List<L3FE_GFDDMI_1652> DropDownList = new List<L3FE_GFDDMI_1652>();

            List<L2PR_GAPfTID_1700> Projects = cls_Get_AllProjects_for_TenantID.Invoke(Connection, Transaction, securityTicket).Result.ToList();
            List<L2BT_GBTPfT_1127> AllBusinessTaskPackages = cls_Get_BusinessTaskPackages_for_Tenant.Invoke(Connection, Transaction, securityTicket).Result.ToList();


            foreach(var project in Projects)
            {
                if(project.IsArchived == false)
                {
                    DropDownList.Add(new L3FE_GFDDMI_1652(project.Name, "", project.TMS_PRO_ProjectID));
                }
            }

            foreach (var package in AllBusinessTaskPackages)
            {
                String Path = package.BTP_Name;

                P_L2PR_GPfPID_0857 parameter = new P_L2PR_GPfPID_0857();
                parameter.ProjectID = package.Project_RefID;

                L2PR_GPfPID_0857 packageProject = cls_Get_Project_for_ProjectID.Invoke(Connection, Transaction, parameter, securityTicket).Result;

                if (packageProject != null && packageProject.TMS_PRO_ProjectID != Guid.Empty && packageProject.Name != null)
                {

                    if(package.Parent_RefID == null || package.Parent_RefID == Guid.Empty)
                    {
                        DropDownList.Add(new L3FE_GFDDMI_1652(packageProject.Name, Path, package.TMS_PRO_BusinessTaskPackageID));
                    }

                    if (package.Parent_RefID != null && package.Parent_RefID != Guid.Empty)
                    {
                        P_L2BT_GBTPP_1544 parentPackageParam = new P_L2BT_GBTPP_1544();


                        do
                        {
                            parentPackageParam.BT_Parent_ID = package.Parent_RefID;

                            L2BT_GBTPP_1544 currentPackageParent = cls_Get_BusinessTaskPackage_Parent.Invoke(Connection, Transaction, parentPackageParam, securityTicket).Result;

                            Path = currentPackageParent.BTP_Name + "/" + Path;

                            DropDownList.Add(new L3FE_GFDDMI_1652(packageProject.Name, Path, package.TMS_PRO_BusinessTaskPackageID));

                            if (currentPackageParent.Parent_RefID != null && currentPackageParent.Parent_RefID != Guid.Empty)
                            {
                                parentPackageParam.BT_Parent_ID = currentPackageParent.Parent_RefID;
                            }

                            else
                            {
                                parentPackageParam.BT_Parent_ID = Guid.Empty;
                            }

                        }

                        while (cls_Get_BusinessTaskPackage_Parent.Invoke(Connection, Transaction, parentPackageParam, securityTicket).Result != null && cls_Get_BusinessTaskPackage_Parent.Invoke(Connection, Transaction, parentPackageParam, securityTicket).Result.Parent_RefID != Guid.Empty);



                    }



                }


            }

            




            
            if(DropDownList.Count != 0 && DropDownList != null)
            {
                returnValue.Result = DropDownList.ToArray();
            }

			return returnValue;
			#endregion UserCode
		}




        #endregion

        #region Method Invocation Wrappers
        ///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3FE_GFDDMI_1652_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3FE_GFDDMI_1652_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3FE_GFDDMI_1652_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3FE_GFDDMI_1652_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3FE_GFDDMI_1652_Array functionReturn = new FR_L3FE_GFDDMI_1652_Array();
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

				throw new Exception("Exception occured in method cls_Get_Features_DropDownMenuItems",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3FE_GFDDMI_1652_Array : FR_Base
	{
		public L3FE_GFDDMI_1652[] Result	{ get; set; } 
		public FR_L3FE_GFDDMI_1652_Array() : base() {}

		public FR_L3FE_GFDDMI_1652_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L3FE_GFDDMI_1652 for attribute L3FE_GFDDMI_1652
		[DataContract]
		public class L3FE_GFDDMI_1652 
		{
			//Standard type parameters
			[DataMember]
			public Dict ProjectName_Dict { get; set; } 
			[DataMember]
			public String BusinessTaskPackage_Path { get; set; } 
			[DataMember]
			public Guid Feature_Parent_ID { get; set; }

            public L3FE_GFDDMI_1652(Dict ProjectName, String Path, Guid ParentID) : base()
            {
                this.ProjectName_Dict = ProjectName;
                this.BusinessTaskPackage_Path = Path;
                this.Feature_Parent_ID = ParentID;
            }

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3FE_GFDDMI_1652_Array cls_Get_Features_DropDownMenuItems(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3FE_GFDDMI_1652_Array invocationResult = cls_Get_Features_DropDownMenuItems.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

