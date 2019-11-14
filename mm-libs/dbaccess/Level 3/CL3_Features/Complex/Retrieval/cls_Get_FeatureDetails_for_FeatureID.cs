/* 
 * Generated on 11-Dec-14 8:39:25 AM
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
using CL3_Tags.Atomic.Retrieval;
using CL3_DeveloperTask.Atomic.Retrieval;
using CL2_Feature.Atomic.Retrieval;
using CL1_TMS_PRO;

namespace CL3_Features.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_FeatureDetails_for_FeatureID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_FeatureDetails_for_FeatureID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3FE_GFDfFID_1338 Execute(DbConnection Connection,DbTransaction Transaction,P_L3FE_GFDfFID_1338 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L3FE_GFDfFID_1338();
            returnValue.Result = new L3FE_GFDfFID_1338();

            ORM_TMS_PRO_Feature.Query searchQuery = new ORM_TMS_PRO_Feature.Query();
            searchQuery.IsArchived = false;
            searchQuery.IsDeleted = false;
            searchQuery.TMS_PRO_FeatureID = Parameter.FeatureID;

            ORM_TMS_PRO_Feature SelectedFeature = ORM_TMS_PRO_Feature.Query.Search(Connection, Transaction, searchQuery).FirstOrDefault();


            if(SelectedFeature != null)
            {
                returnValue.Result.TMS_PRO_FeatureID = SelectedFeature.TMS_PRO_FeatureID;
                returnValue.Result.IdentificationNumber = SelectedFeature.IdentificationNumber;
                returnValue.Result.Name = SelectedFeature.Name;
                returnValue.Result.Description = SelectedFeature.Description;
                returnValue.Result.Deadline = SelectedFeature.Feature_Deadline;
                returnValue.Result.Project_RefID = SelectedFeature.Project_RefID;
                returnValue.Result.Tags = GetTagsForFeature(Connection, Transaction, securityTicket, SelectedFeature.TMS_PRO_FeatureID);
                returnValue.Result.Feature_DeveloperTasks = GetDeveloperTasksForFeature(Connection, Transaction, securityTicket, SelectedFeature.TMS_PRO_FeatureID);
            }



            //Put your code here
			return returnValue;
			#endregion UserCode
		}
		#endregion


        #region My Support Methods

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

        private static L3DT_GDTfFID_1349[] GetDeveloperTasksForFeature(DbConnection Connection, DbTransaction Transaction, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket, Guid featureID)
        {
            P_L3DT_GDTfFID_1349 paramDevTasks = new P_L3DT_GDTfFID_1349();
            paramDevTasks.FeatureID = featureID;

            List<L3DT_GDTfFID_1349> DeveloperTasks = cls_Get_DeveloperTasks_for_FeatureID.Invoke(Connection, Transaction, paramDevTasks, securityTicket).Result.ToList();

            if (DeveloperTasks != null && DeveloperTasks.Count != 0)
            {
                return DeveloperTasks.ToArray();
            }

            else
            {
                return new List<L3DT_GDTfFID_1349>().ToArray();
            }
        }

        #endregion


		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3FE_GFDfFID_1338 Invoke(string ConnectionString,P_L3FE_GFDfFID_1338 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3FE_GFDfFID_1338 Invoke(DbConnection Connection,P_L3FE_GFDfFID_1338 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3FE_GFDfFID_1338 Invoke(DbConnection Connection, DbTransaction Transaction,P_L3FE_GFDfFID_1338 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3FE_GFDfFID_1338 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3FE_GFDfFID_1338 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3FE_GFDfFID_1338 functionReturn = new FR_L3FE_GFDfFID_1338();
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

				throw new Exception("Exception occured in method cls_Get_FeatureDetails_for_FeatureID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3FE_GFDfFID_1338 : FR_Base
	{
		public L3FE_GFDfFID_1338 Result	{ get; set; }

		public FR_L3FE_GFDfFID_1338() : base() {}

		public FR_L3FE_GFDfFID_1338(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3FE_GFDfFID_1338 for attribute P_L3FE_GFDfFID_1338
		[DataContract]
		public class P_L3FE_GFDfFID_1338 
		{
			//Standard type parameters
			[DataMember]
			public Guid FeatureID { get; set; } 

		}
		#endregion
		#region SClass L3FE_GFDfFID_1338 for attribute L3FE_GFDfFID_1338
		[DataContract]
		public class L3FE_GFDfFID_1338 
		{
			//Standard type parameters
			[DataMember]
			public Guid TMS_PRO_FeatureID { get; set; } 
			[DataMember]
			public String IdentificationNumber { get; set; } 
			[DataMember]
			public Guid Project_RefID { get; set; } 
			[DataMember]
			public Guid Parent_RefID { get; set; } 
			[DataMember]
			public Dict Name { get; set; } 
			[DataMember]
			public Dict Description { get; set; } 
			[DataMember]
			public DateTime Deadline { get; set; } 
			[DataMember]
			public Double PercentageComplete { get; set; } 
			[DataMember]
			public String[] Tags { get; set; } 
			[DataMember]
			public L3DT_GDTfFID_1349[] Feature_DeveloperTasks { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3FE_GFDfFID_1338 cls_Get_FeatureDetails_for_FeatureID(,P_L3FE_GFDfFID_1338 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3FE_GFDfFID_1338 invocationResult = cls_Get_FeatureDetails_for_FeatureID.Invoke(connectionString,P_L3FE_GFDfFID_1338 Parameter,securityTicket);
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
var parameter = new CL3_Features.Complex.Retrieval.P_L3FE_GFDfFID_1338();
parameter.FeatureID = ...;

*/
