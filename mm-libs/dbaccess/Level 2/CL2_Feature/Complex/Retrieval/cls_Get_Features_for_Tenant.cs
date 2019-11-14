/* 
 * Generated on 02-Dec-14 2:12:33 PM
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
using CL2_Feature.Atomic.Retrieval;
using CL2_Project.Atomic.Retrieval;
using CL2_BusinessTask.Atomic.Retrieval;
using CL3_Tags.Atomic.Retrieval;

namespace CL2_Feature.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Features_for_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Features_for_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2FE_GFfT_1409_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L2FE_GFfT_1409_Array();
            returnValue.Result = new L2FE_GFfT_1409[0];
			//Put your code here

            List<L2FE_GFfTID_1126> Features = cls_Get_Features_for_TenantID.Invoke(Connection, Transaction, securityTicket).Result.ToList();
            List<L2FE_GFfT_1409> FeaturesTableData = new List<L2FE_GFfT_1409>();

            foreach(var feature in Features)
            {
                L2FE_GFfT_1409 NewFeature = new L2FE_GFfT_1409();

                NewFeature.TMS_PRO_FeatureID = feature.TMS_PRO_FeatureID;
                NewFeature.Name = feature.Name;
                NewFeature.Description = feature.Description;
                NewFeature.IdentificationNumber = feature.IdentificationNumber;
                NewFeature.Feature_Deadline = feature.Feature_Deadline;

                NewFeature.Percentage = GetFeaturePercentage(Connection, Transaction, securityTicket, NewFeature.TMS_PRO_FeatureID);


                NewFeature.Tags = GetTagsForFeature(Connection, Transaction, securityTicket, NewFeature.TMS_PRO_FeatureID);



                if (feature.Project_RefID != null && feature.Project_RefID != Guid.Empty)
                    NewFeature.ParentProject = GetProjectNameForFeature(Connection, Transaction, securityTicket, feature.Project_RefID);
                

                if(NewFeature.ParentProject != null && NewFeature.ParentProject.Contents.Count != 0)
                {
                    String FeaturePath = GetFeaturePath_OLD(Connection, Transaction, securityTicket, feature.TMS_PRO_FeatureID);

                    if (FeaturePath.Equals(""))
                    {
                        FeaturePath = GetFeaturePath_NEW(Connection, Transaction, securityTicket, feature.Parent_RefID);
                    }

                    NewFeature.BTPath = FeaturePath;

                    FeaturesTableData.Add(NewFeature);

                }


            }




            if (FeaturesTableData.Count != 0 && FeaturesTableData != null)
            {
                returnValue.Result = FeaturesTableData.ToArray();
            }

			return returnValue;
			#endregion UserCode
		}

        #region Support Methods

        private static String GetFeaturePath_OLD(DbConnection Connection, DbTransaction Transaction, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket, Guid Feature_ID)
        {
            String ResultPath = "";

            P_L2BT_GBTPfFID_1512 parameter = new P_L2BT_GBTPfFID_1512();
            parameter.FeatureID = Feature_ID;

            L2BT_GBTPfFID_1512 FeatureParentBTPackage = cls_Get_BusinessTaskPackage_for_FeatureID.Invoke(Connection, Transaction, parameter, securityTicket).Result;

            if (FeatureParentBTPackage != null && !FeatureParentBTPackage.BTP_Name.Equals("") && FeatureParentBTPackage.TMS_PRO_BusinessTaskPackageID != Guid.Empty)
            {
                ResultPath = FeatureParentBTPackage.BTP_Name;

                if (FeatureParentBTPackage.Parent_RefID != null && FeatureParentBTPackage.Parent_RefID != Guid.Empty)
                {
                    P_L2BT_GBTPP_1544 param = new P_L2BT_GBTPP_1544();
                    param.BT_Parent_ID = FeatureParentBTPackage.Parent_RefID;

                    L2BT_GBTPP_1544 BusinessTaskPackageParent = new L2BT_GBTPP_1544();

                    do
                    {
                        BusinessTaskPackageParent = cls_Get_BusinessTaskPackage_Parent.Invoke(Connection, Transaction, param, securityTicket).Result;
                        param.BT_Parent_ID = BusinessTaskPackageParent.Parent_RefID;

                        ResultPath = BusinessTaskPackageParent.BTP_Name + "/" + ResultPath;

                    }
                    while (cls_Get_BusinessTaskPackage_Parent.Invoke(Connection, Transaction, param, securityTicket).Result != null && cls_Get_BusinessTaskPackage_Parent.Invoke(Connection, Transaction, param, securityTicket).Result.Parent_RefID != Guid.Empty);
                }

                return ResultPath;
            }

            else
            {
                return ResultPath;
            }
        }

        private static String GetFeaturePath_NEW(DbConnection Connection, DbTransaction Transaction, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket, Guid Feature_Parent_ID)
        {
            String ResultPath = "";

            P_L2BT_GBTPfFPID_1511 parameter = new P_L2BT_GBTPfFPID_1511();
            parameter.Feature_Parent_RefID = Feature_Parent_ID;

            L2BT_GBTPfFPID_1511 FeatureParentBTPackage = cls_Get_BusinessTaskPackage_for_FeatureParentID.Invoke(Connection, Transaction, parameter, securityTicket).Result;

            if (FeatureParentBTPackage != null && !FeatureParentBTPackage.BTP_Name.Equals("") && FeatureParentBTPackage.TMS_PRO_BusinessTaskPackageID != Guid.Empty)
            {
                ResultPath = FeatureParentBTPackage.BTP_Name;

                if (FeatureParentBTPackage.Parent_RefID != null && FeatureParentBTPackage.Parent_RefID != Guid.Empty)
                {
                    P_L2BT_GBTPP_1544 param = new P_L2BT_GBTPP_1544();
                    param.BT_Parent_ID = FeatureParentBTPackage.Parent_RefID;

                    L2BT_GBTPP_1544 BusinessTaskPackageParent = new L2BT_GBTPP_1544();

                    do
                    {
                        BusinessTaskPackageParent = cls_Get_BusinessTaskPackage_Parent.Invoke(Connection, Transaction, param, securityTicket).Result;
                        param.BT_Parent_ID = BusinessTaskPackageParent.Parent_RefID;

                        ResultPath = BusinessTaskPackageParent.BTP_Name + "/" + ResultPath;

                    }
                    while (cls_Get_BusinessTaskPackage_Parent.Invoke(Connection, Transaction, param, securityTicket).Result != null && cls_Get_BusinessTaskPackage_Parent.Invoke(Connection, Transaction, param, securityTicket).Result.Parent_RefID != Guid.Empty);
                }

                return ResultPath;
            }


            else
            {
                return ResultPath;
            }

        }


        private static Dict GetProjectNameForFeature(DbConnection Connection, DbTransaction Transaction, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket, Guid Feature_ProjectParent_RefID)
        {
            if (Feature_ProjectParent_RefID != null && Feature_ProjectParent_RefID != Guid.Empty)
            {
                P_L2PR_GPfFPID_1533 parameter = new P_L2PR_GPfFPID_1533();
                parameter.Feature_ProjectParent_RefID = Feature_ProjectParent_RefID;

                L2PR_GPfFPID_1533 FeatureProject = cls_Get_Project_for_Feature_ParentID.Invoke(Connection, Transaction, parameter, securityTicket).Result;

                if (FeatureProject != null && !FeatureProject.Name.Equals(""))
                {
                    return FeatureProject.Name;
                }
                else
                {
                    return new Dict("");
                }
            }
            else
            {
                return new Dict("");
            }
        }

        private static Double GetFeaturePercentage(DbConnection Connection, DbTransaction Transaction, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket, Guid featureID)
        {
            P_L2FE_GFPfF_1504 parameter = new P_L2FE_GFPfF_1504();
            parameter.FeatureID = featureID;

            List<L2FE_GFPfF_1504> FeatureProgresses = cls_Get_FeatureProgresses_for_Feature.Invoke(Connection, Transaction, parameter, securityTicket).Result.ToList();

            int counter = 0;
            Double percentageSum = 0;
            foreach (var progress in FeatureProgresses)
            {
                if (progress.TMS_PRO_FeatureID == featureID)
                {
                    percentageSum += progress.PercentageComplete;
                    counter += 1;
                }
            }

            if (percentageSum != 0 && !Double.IsNaN(percentageSum))
                return Math.Round(percentageSum / counter, 2);
            else
                return 0;
        }

        private static String[] GetTagsForFeature(DbConnection Connection, DbTransaction Transaction, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket, Guid featureID)
        {
            List<L3TA_GTfFID_1418> TagsForFeature = new List<L3TA_GTfFID_1418>();
            List<String> TagsToRetrieve = new List<String>();

            P_L3TA_GTfFID_1418 parameter = new P_L3TA_GTfFID_1418();
            parameter.FeatureID = featureID;

            TagsForFeature = cls_Get_Tags_for_FeatureID.Invoke(Connection, Transaction, parameter, securityTicket).Result.ToList();

            if (TagsForFeature != null && TagsForFeature.Count != 0)
            {
                foreach (var tag in TagsForFeature)
                {
                    TagsToRetrieve.Add(tag.TagValue);
                }

                return TagsToRetrieve.ToArray();
            }

            else
            {
                return new String[0];
            }

        }

        #endregion
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L2FE_GFfT_1409_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2FE_GFfT_1409_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2FE_GFfT_1409_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2FE_GFfT_1409_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2FE_GFfT_1409_Array functionReturn = new FR_L2FE_GFfT_1409_Array();
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

				throw new Exception("Exception occured in method cls_Get_Features_for_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2FE_GFfT_1409_Array : FR_Base
	{
		public L2FE_GFfT_1409[] Result	{ get; set; } 
		public FR_L2FE_GFfT_1409_Array() : base() {}

		public FR_L2FE_GFfT_1409_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L2FE_GFfT_1409 for attribute L2FE_GFfT_1409
		[DataContract]
		public class L2FE_GFfT_1409 
		{
			//Standard type parameters
			[DataMember]
			public Guid TMS_PRO_FeatureID { get; set; } 
			[DataMember]
			public Dict Name { get; set; } 
			[DataMember]
			public String IdentificationNumber { get; set; } 
			[DataMember]
			public Dict Description { get; set; } 
			[DataMember]
			public DateTime Feature_Deadline { get; set; } 
			[DataMember]
			public Double Percentage { get; set; } 
			[DataMember]
			public String[] Tags { get; set; } 
			[DataMember]
			public Dict ParentProject { get; set; } 
			[DataMember]
			public String BTPath { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2FE_GFfT_1409_Array cls_Get_Features_for_Tenant(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2FE_GFfT_1409_Array invocationResult = cls_Get_Features_for_Tenant.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

