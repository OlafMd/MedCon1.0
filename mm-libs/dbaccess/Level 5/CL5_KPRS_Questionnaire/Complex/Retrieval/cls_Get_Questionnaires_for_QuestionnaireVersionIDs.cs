/* 
 * Generated on 11/5/2013 2:53:26 PM
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
using CL1_RES_ACT;
using CL1_RES_STR;
using CL1_RES;
using CL1_CMN;
using CL1_RES_BLD;
using CL5_KPRS_StaticProperties.Complex.Retrieval;

namespace CL5_KPRS_Questionnaire.Complex.Retrieval
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Questionnaires_for_QuestionnaireVersionIDs.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Questionnaires_for_QuestionnaireVersionIDs
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5QT_GQfQVIs_1718 Execute(DbConnection Connection,DbTransaction Transaction,P_L5QT_GQfQVIs_1718 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5QT_GQfQVIs_1718();
			//Put your code here
            returnValue.Result = new L5QT_GQfQVIs_1718();
            returnValue.Result.ActionVersions = new ORM_RES_ACT_Action_Version[] { };
            returnValue.Result.QuestionnaireVersions = new L5QT_GQIfVI_1048[] { };
            returnValue.Result.Ratings = new ORM_RES_STR_Rating[] { };
            returnValue.Result.Timeframes = new ORM_RES_Timeframe[] { };
            returnValue.Result.Prices = new ORM_CMN_Price_Value[] { };
            returnValue.Result.GarbageContainerTypes = new ORM_RES_BLD_GarbageContainerType[] { };
            returnValue.Result.BuildingTypes = new ORM_RES_BLD_Building_Type[] { };
            returnValue.Result.BuildingPartTypes = new L5SP_GABPTFT_1244();

            var priceIDList = new List<Guid>();
            var questionnaireVersions = new List<L5QT_GQIfVI_1048>();
            foreach (var qVersionID in Parameter.RevisionGroupIDs)
            {

                var questionnareVersionInfo = cls_Get_QuestionnaireInfo_for_VersionID.Invoke(Connection, Transaction, new P_L5QT_GQIfVI_1048()
                {
                    QuestionnaireVersionID = qVersionID
                }, securityTicket).Result;
                if (questionnareVersionInfo == null)
                {
                    continue;
                }
                questionnaireVersions.Add(questionnareVersionInfo);
            }
            returnValue.Result.QuestionnaireVersions = questionnaireVersions.ToArray();


            var ratingList = new List<ORM_RES_STR_Rating>();
            var actionVersionList = new List<ORM_RES_ACT_Action_Version>();
            var timeframeList = new List<ORM_RES_Timeframe>();
            var priceList = new List<ORM_CMN_Price_Value>();
            returnValue.Result.Timeframes = ORM_RES_Timeframe.Query.Search(Connection, Transaction, new ORM_RES_Timeframe.Query()
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID
            }).ToArray();
            returnValue.Result.Ratings = ORM_RES_STR_Rating.Query.Search(Connection, Transaction, new ORM_RES_STR_Rating.Query()
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID
            }).ToArray();
            returnValue.Result.ActionVersions = ORM_RES_ACT_Action_Version.Query.Search(Connection, Transaction, new ORM_RES_ACT_Action_Version.Query()
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID
            }).ToArray();
            priceIDList.AddRange(returnValue.Result.ActionVersions.Select(x => x.Default_PricePerUnit_RefID));

            returnValue.Result.Units = ORM_CMN_Unit.Query.Search(Connection, Transaction, new ORM_CMN_Unit.Query()
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID
            }).ToArray();


            returnValue.Result.GarbageContainerTypes = ORM_RES_BLD_GarbageContainerType.Query.Search(Connection, Transaction, new ORM_RES_BLD_GarbageContainerType.Query()
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID
            }).ToArray();


            returnValue.Result.BuildingTypes = ORM_RES_BLD_Building_Type.Query.Search(Connection, Transaction, new ORM_RES_BLD_Building_Type.Query()
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID
            }).ToArray();

            returnValue.Result.BuildingPartTypes = cls_Get_All_BuildingPartTypes_For_Tenant.Invoke(Connection, Transaction, securityTicket).Result;

            foreach (var priceID in priceIDList)
            {

                var priceValueORM = ORM_CMN_Price_Value.Query.Search(Connection, Transaction, new ORM_CMN_Price_Value.Query()
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    Price_RefID = priceID
                });

                if (priceValueORM != null)
                    priceList.AddRange(priceValueORM);
            }

            returnValue.Result.Prices = priceList.ToArray();

            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5QT_GQfQVIs_1718 Invoke(string ConnectionString,P_L5QT_GQfQVIs_1718 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5QT_GQfQVIs_1718 Invoke(DbConnection Connection,P_L5QT_GQfQVIs_1718 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5QT_GQfQVIs_1718 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5QT_GQfQVIs_1718 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5QT_GQfQVIs_1718 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5QT_GQfQVIs_1718 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5QT_GQfQVIs_1718 functionReturn = new FR_L5QT_GQfQVIs_1718();
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

				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5QT_GQfQVIs_1718 : FR_Base
	{
		public L5QT_GQfQVIs_1718 Result	{ get; set; }

		public FR_L5QT_GQfQVIs_1718() : base() {}

		public FR_L5QT_GQfQVIs_1718(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5QT_GQfQVIs_1718 for attribute P_L5QT_GQfQVIs_1718
		[DataContract]
		public class P_L5QT_GQfQVIs_1718 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] RevisionGroupIDs { get; set; } 

		}
		#endregion
		#region SClass L5QT_GQfQVIs_1718 for attribute L5QT_GQfQVIs_1718
		[DataContract]
		public class L5QT_GQfQVIs_1718 
		{
			//Standard type parameters
			[DataMember]
			public L5QT_GQIfVI_1048[] QuestionnaireVersions { get; set; } 
			[DataMember]
			public ORM_RES_Timeframe[] Timeframes { get; set; } 
			[DataMember]
			public ORM_RES_ACT_Action_Version[] ActionVersions { get; set; } 
			[DataMember]
			public ORM_RES_STR_Rating[] Ratings { get; set; } 
			[DataMember]
			public ORM_CMN_Price_Value[] Prices { get; set; } 
			[DataMember]
			public ORM_CMN_Unit[] Units { get; set; } 
			[DataMember]
			public ORM_RES_BLD_Building_Type[] BuildingTypes { get; set; } 
			[DataMember]
			public L5SP_GABPTFT_1244 BuildingPartTypes { get; set; } 
			[DataMember]
			public ORM_RES_BLD_GarbageContainerType[] GarbageContainerTypes { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5QT_GQfQVIs_1718 cls_Get_Questionnaires_for_QuestionnaireVersionIDs(P_L5QT_GQfQVIs_1718 Parameter,string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_L5QT_GQfQVIs_1718 result = cls_Get_Questionnaires_for_QuestionnaireVersionIDs.Invoke(connectionString,P_L5QT_GQfQVIs_1718 Parameter,securityTicket);
	 return result;
}
*/