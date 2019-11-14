/* 
 * Generated on 7/23/2013 11:54:05 AM
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
using CL1_RES_DUD;
using CL1_CMN_PER;

namespace CL5_KPRS_DueDiligences.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_DueDiligence_For_DueDiligenceID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_DueDiligence_For_DueDiligenceID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5DD_GDDFDD_1402 Execute(DbConnection Connection,DbTransaction Transaction,P_L5DD_GDDFDD_1402 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5DD_GDDFDD_1402();

            L5DD_GDDFDD_1402 result = new L5DD_GDDFDD_1402();
            ORM_RES_DUD_RevisionGroup revisionGroup = new ORM_RES_DUD_RevisionGroup();
            revisionGroup.Load(Connection, Transaction, Parameter.RevisionGroupID);

            ORM_CMN_PER_PersonInfo_2_Account.Query infoToAccountQuery=new ORM_CMN_PER_PersonInfo_2_Account.Query();
            infoToAccountQuery.IsDeleted=false;
            infoToAccountQuery.Tenant_RefID=securityTicket.TenantID;
            infoToAccountQuery.USR_Account_RefID=revisionGroup.RevisionGroup_SubmittedBy_Account_RefID;
            List<ORM_CMN_PER_PersonInfo_2_Account> infoToAccountList=ORM_CMN_PER_PersonInfo_2_Account.Query.Search(Connection,Transaction,infoToAccountQuery);


            ORM_CMN_PER_PersonInfo.Query personInfoQuery=new ORM_CMN_PER_PersonInfo.Query();
            personInfoQuery.IsDeleted=false;
            personInfoQuery.Tenant_RefID=securityTicket.TenantID;
            personInfoQuery.CMN_PER_PersonInfoID=infoToAccountList[0].CMN_PER_PersonInfo_RefID;
            List<ORM_CMN_PER_PersonInfo> personInfo=ORM_CMN_PER_PersonInfo.Query.Search(Connection,Transaction,personInfoQuery);

            result.Creation_Timestamp = revisionGroup.Creation_Timestamp;
            result.FirstName = personInfo[0].FirstName;
            result.LastName = personInfo[0].LastName;
            result.RealestateProperty_RefID = revisionGroup.RealestateProperty_RefID;
            result.RES_DUD_Revision_GroupID = revisionGroup.RES_DUD_Revision_GroupID;
            result.RevisionGroup_Comment = revisionGroup.RevisionGroup_Comment;
            result.RevisionGroup_Name = revisionGroup.RevisionGroup_Name;
            result.RevisionGroup_SubmittedBy_Account_RefID = revisionGroup.RevisionGroup_SubmittedBy_Account_RefID;
            result.Tenant_RefID = securityTicket.TenantID;
            returnValue.Result = result;
			//Put your code here
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5DD_GDDFDD_1402 Invoke(string ConnectionString,P_L5DD_GDDFDD_1402 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5DD_GDDFDD_1402 Invoke(DbConnection Connection,P_L5DD_GDDFDD_1402 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5DD_GDDFDD_1402 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5DD_GDDFDD_1402 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5DD_GDDFDD_1402 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5DD_GDDFDD_1402 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5DD_GDDFDD_1402 functionReturn = new FR_L5DD_GDDFDD_1402();
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

				throw new Exception("Exception occured in method cls_Get_DueDiligence_For_DueDiligenceID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5DD_GDDFDD_1402_raw 
	{
		public Guid RES_DUD_Revision_GroupID; 
		public String RevisionGroup_Name; 
		public Guid RevisionGroup_SubmittedBy_Account_RefID; 
		public DateTime Creation_Timestamp; 
		public Guid Tenant_RefID; 
		public bool IsDeleted; 
		public Guid RealestateProperty_RefID; 
		public String FirstName; 
		public String LastName; 
		public String RevisionGroup_Comment; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5DD_GDDFDD_1402[] Convert(List<L5DD_GDDFDD_1402_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5DD_GDDFDD_1402 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.RES_DUD_Revision_GroupID)).ToArray()
	group el_L5DD_GDDFDD_1402 by new 
	{ 
		el_L5DD_GDDFDD_1402.RES_DUD_Revision_GroupID,

	}
	into gfunct_L5DD_GDDFDD_1402
	select new L5DD_GDDFDD_1402
	{     
		RES_DUD_Revision_GroupID = gfunct_L5DD_GDDFDD_1402.Key.RES_DUD_Revision_GroupID ,
		RevisionGroup_Name = gfunct_L5DD_GDDFDD_1402.FirstOrDefault().RevisionGroup_Name ,
		RevisionGroup_SubmittedBy_Account_RefID = gfunct_L5DD_GDDFDD_1402.FirstOrDefault().RevisionGroup_SubmittedBy_Account_RefID ,
		Creation_Timestamp = gfunct_L5DD_GDDFDD_1402.FirstOrDefault().Creation_Timestamp ,
		Tenant_RefID = gfunct_L5DD_GDDFDD_1402.FirstOrDefault().Tenant_RefID ,
		IsDeleted = gfunct_L5DD_GDDFDD_1402.FirstOrDefault().IsDeleted ,
		RealestateProperty_RefID = gfunct_L5DD_GDDFDD_1402.FirstOrDefault().RealestateProperty_RefID ,
		FirstName = gfunct_L5DD_GDDFDD_1402.FirstOrDefault().FirstName ,
		LastName = gfunct_L5DD_GDDFDD_1402.FirstOrDefault().LastName ,
		RevisionGroup_Comment = gfunct_L5DD_GDDFDD_1402.FirstOrDefault().RevisionGroup_Comment ,

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5DD_GDDFDD_1402 : FR_Base
	{
		public L5DD_GDDFDD_1402 Result	{ get; set; }

		public FR_L5DD_GDDFDD_1402() : base() {}

		public FR_L5DD_GDDFDD_1402(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5DD_GDDFDD_1402 for attribute P_L5DD_GDDFDD_1402
		[DataContract]
		public class P_L5DD_GDDFDD_1402 
		{
			//Standard type parameters
			[DataMember]
			public Guid RevisionGroupID { get; set; } 

		}
		#endregion
		#region SClass L5DD_GDDFDD_1402 for attribute L5DD_GDDFDD_1402
		[DataContract]
		public class L5DD_GDDFDD_1402 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_DUD_Revision_GroupID { get; set; } 
			[DataMember]
			public String RevisionGroup_Name { get; set; } 
			[DataMember]
			public Guid RevisionGroup_SubmittedBy_Account_RefID { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public Guid Tenant_RefID { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 
			[DataMember]
			public Guid RealestateProperty_RefID { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public String RevisionGroup_Comment { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5DD_GDDFDD_1402 cls_Get_DueDiligence_For_DueDiligenceID(,P_L5DD_GDDFDD_1402 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5DD_GDDFDD_1402 invocationResult = cls_Get_DueDiligence_For_DueDiligenceID.Invoke(connectionString,P_L5DD_GDDFDD_1402 Parameter,securityTicket);
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
var parameter = new CL5_KPRS_DueDiligences.Complex.Retrieval.P_L5DD_GDDFDD_1402();
parameter.RevisionGroupID = ...;

*/