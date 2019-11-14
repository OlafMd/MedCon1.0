/* 
 * Generated on 7/24/2013 1:31:54 PM
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
using CL1_RES_BLD;
using CL1_RES;
using CL1_CMN_LOC;
using CL1_CMN;
using CL2_AccountInformation.Atomic.Retrieval;

namespace CL5_KPRS_DueDiligences.Complex.Retrieval
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_RevisionGroupInformation_for_RealestatePropertyID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_RevisionGroupInformation_for_RealestatePropertyID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6DD_GRGIfRPI_1752_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L6DD_GRGIfRPI_1752 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L6DD_GRGIfRPI_1752_Array();
			//Put your code here
            
			var revisionGroupList = new List<L6DD_GRGIfRPI_1752>();

			var ormRevisionGroups = ORM_RES_DUD_RevisionGroup.Query.Search(Connection, Transaction, new ORM_RES_DUD_RevisionGroup.Query()
			{
				IsDeleted = false,
				RealestateProperty_RefID = Parameter.RealestatePropertyID,
				Tenant_RefID = securityTicket.TenantID
			});

			foreach (var revGroup in ormRevisionGroups)
			{
				var revisionGroup = new L6DD_GRGIfRPI_1752();

				revisionGroup.Comment = revGroup.RevisionGroup_Comment;
				revisionGroup.CreationTimestamp = revGroup.Creation_Timestamp;
				revisionGroup.Name = revGroup.RevisionGroup_Name;
				revisionGroup.SubmittedByAccount = revisionGroup.SubmittedByAccount;
                revisionGroup.RealestatePropertyID = Parameter.RealestatePropertyID;
                revisionGroup.RevisionGroupID = revGroup.RES_DUD_Revision_GroupID;

                //Find address information

                ORM_RES_RealestateProperty ormRealestateProperty = new ORM_RES_RealestateProperty();
                ormRealestateProperty.Load(Connection, Transaction, revGroup.RealestateProperty_RefID);
                ORM_CMN_LOC_Location ormLocation = new ORM_CMN_LOC_Location();
                ormLocation.Load(Connection, Transaction, ormRealestateProperty.RealestateProperty_Location_RefID);
                ORM_CMN_Address ormAddress = new ORM_CMN_Address();
                ormAddress.Load(Connection, Transaction, ormLocation.Address_RefID);

                revisionGroup.Street_Name = ormAddress.Street_Name;
                revisionGroup.Street_Number = ormAddress.Street_Number;
                revisionGroup.Country_Name = ormAddress.Country_Name;
                revisionGroup.City_Name = ormAddress.City_Name;
                revisionGroup.City_PostalCode = ormAddress.City_PostalCode;
                revisionGroup.City_Region = ormAddress.City_Region;


                var accountInformation = cls_Get_Account_PersonalInformation_for_AccountID.Invoke(Connection, Transaction, new P_L2AI_GAPIfAI_1627()
                {
                    AccountRefID = revGroup.RevisionGroup_SubmittedBy_Account_RefID
                }, securityTicket).Result;
                revisionGroup.SubmittedByAccount_LastName = accountInformation.LastName;
                revisionGroup.SubmittedByAccount_FirstName = accountInformation.FirstName;


                var revisionList = new List<L6DD_GRGIfRPI_1752_Revision>();

				var omrRevisions = ORM_RES_DUD_Revision.Query.Search(Connection, Transaction, new ORM_RES_DUD_Revision.Query()
				{
					IsDeleted = false,
					RevisionGroup_RefID = revGroup.RES_DUD_Revision_GroupID,
					Tenant_RefID = securityTicket.TenantID
				});

  
				foreach (var rev in omrRevisions)
				{

                    var ormBuildings = ORM_RES_BLD_Building.Query.Search(Connection, Transaction, new ORM_RES_BLD_Building.Query()
                    {
                        IsDeleted = false,
                        RES_BLD_BuildingID = rev.RES_BLD_Building_RefID,
                        Tenant_RefID = securityTicket.TenantID
                    });

                    var revision = new L6DD_GRGIfRPI_1752_Revision();
                    revision.BuildingID = rev.RES_BLD_Building_RefID;
                    revision.RevisionID = rev.RES_DUD_RevisionID;
                    revision.RevisionTitle = rev.Revision_Title;
                    revision.BuildingName = ormBuildings[0].Building_Name;

                    revisionList.Add(revision);
				}
                revisionGroup.Revisions = revisionList.ToArray();
                revisionGroupList.Add(revisionGroup);
			}

            returnValue.Result = revisionGroupList.ToArray();

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6DD_GRGIfRPI_1752_Array Invoke(string ConnectionString,P_L6DD_GRGIfRPI_1752 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6DD_GRGIfRPI_1752_Array Invoke(DbConnection Connection,P_L6DD_GRGIfRPI_1752 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6DD_GRGIfRPI_1752_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L6DD_GRGIfRPI_1752 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6DD_GRGIfRPI_1752_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6DD_GRGIfRPI_1752 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6DD_GRGIfRPI_1752_Array functionReturn = new FR_L6DD_GRGIfRPI_1752_Array();
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

				throw new Exception("Exception occured in method cls_Get_RevisionGroupInformation_for_RealestatePropertyID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L6DD_GRGIfRPI_1752_raw 
	{
		public Guid RevisionGroupID; 
		public String Name; 
		public String Comment; 
		public Guid SubmittedByAccount; 
		public String SubmittedByAccount_FirstName; 
		public String SubmittedByAccount_LastName; 
		public String Currency; 
		public DateTime CreationTimestamp; 
		public Guid RealestatePropertyID; 
		public String Country_Name; 
		public String City_Region; 
		public String City_PostalCode; 
		public String City_Name; 
		public String Street_Number; 
		public String Street_Name; 
		public Guid RevisionID; 
		public String RevisionTitle; 
		public Guid BuildingID; 
		public String BuildingName; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L6DD_GRGIfRPI_1752[] Convert(List<L6DD_GRGIfRPI_1752_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L6DD_GRGIfRPI_1752 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.RevisionGroupID)).ToArray()
	group el_L6DD_GRGIfRPI_1752 by new 
	{ 
		el_L6DD_GRGIfRPI_1752.RevisionGroupID,

	}
	into gfunct_L6DD_GRGIfRPI_1752
	select new L6DD_GRGIfRPI_1752
	{     
		RevisionGroupID = gfunct_L6DD_GRGIfRPI_1752.Key.RevisionGroupID ,
		Name = gfunct_L6DD_GRGIfRPI_1752.FirstOrDefault().Name ,
		Comment = gfunct_L6DD_GRGIfRPI_1752.FirstOrDefault().Comment ,
		SubmittedByAccount = gfunct_L6DD_GRGIfRPI_1752.FirstOrDefault().SubmittedByAccount ,
		SubmittedByAccount_FirstName = gfunct_L6DD_GRGIfRPI_1752.FirstOrDefault().SubmittedByAccount_FirstName ,
		SubmittedByAccount_LastName = gfunct_L6DD_GRGIfRPI_1752.FirstOrDefault().SubmittedByAccount_LastName ,
		Currency = gfunct_L6DD_GRGIfRPI_1752.FirstOrDefault().Currency ,
		CreationTimestamp = gfunct_L6DD_GRGIfRPI_1752.FirstOrDefault().CreationTimestamp ,
		RealestatePropertyID = gfunct_L6DD_GRGIfRPI_1752.FirstOrDefault().RealestatePropertyID ,
		Country_Name = gfunct_L6DD_GRGIfRPI_1752.FirstOrDefault().Country_Name ,
		City_Region = gfunct_L6DD_GRGIfRPI_1752.FirstOrDefault().City_Region ,
		City_PostalCode = gfunct_L6DD_GRGIfRPI_1752.FirstOrDefault().City_PostalCode ,
		City_Name = gfunct_L6DD_GRGIfRPI_1752.FirstOrDefault().City_Name ,
		Street_Number = gfunct_L6DD_GRGIfRPI_1752.FirstOrDefault().Street_Number ,
		Street_Name = gfunct_L6DD_GRGIfRPI_1752.FirstOrDefault().Street_Name ,

		Revisions = 
		(
			from el_Revisions in gfunct_L6DD_GRGIfRPI_1752.Where(element => !EqualsDefaultValue(element.RevisionID)).ToArray()
			group el_Revisions by new 
			{ 
				el_Revisions.RevisionID,

			}
			into gfunct_Revisions
			select new L6DD_GRGIfRPI_1752_Revision
			{     
				RevisionID = gfunct_Revisions.Key.RevisionID ,
				RevisionTitle = gfunct_Revisions.FirstOrDefault().RevisionTitle ,
				BuildingID = gfunct_Revisions.FirstOrDefault().BuildingID ,
				BuildingName = gfunct_Revisions.FirstOrDefault().BuildingName ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L6DD_GRGIfRPI_1752_Array : FR_Base
	{
		public L6DD_GRGIfRPI_1752[] Result	{ get; set; } 
		public FR_L6DD_GRGIfRPI_1752_Array() : base() {}

		public FR_L6DD_GRGIfRPI_1752_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6DD_GRGIfRPI_1752 for attribute P_L6DD_GRGIfRPI_1752
		[DataContract]
		public class P_L6DD_GRGIfRPI_1752 
		{
			//Standard type parameters
			[DataMember]
			public Guid RealestatePropertyID { get; set; } 

		}
		#endregion
		#region SClass L6DD_GRGIfRPI_1752 for attribute L6DD_GRGIfRPI_1752
		[DataContract]
		public class L6DD_GRGIfRPI_1752 
		{
			[DataMember]
			public L6DD_GRGIfRPI_1752_Revision[] Revisions { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid RevisionGroupID { get; set; } 
			[DataMember]
			public String Name { get; set; } 
			[DataMember]
			public String Comment { get; set; } 
			[DataMember]
			public Guid SubmittedByAccount { get; set; } 
			[DataMember]
			public String SubmittedByAccount_FirstName { get; set; } 
			[DataMember]
			public String SubmittedByAccount_LastName { get; set; } 
			[DataMember]
			public String Currency { get; set; } 
			[DataMember]
			public DateTime CreationTimestamp { get; set; } 
			[DataMember]
			public Guid RealestatePropertyID { get; set; } 
			[DataMember]
			public String Country_Name { get; set; } 
			[DataMember]
			public String City_Region { get; set; } 
			[DataMember]
			public String City_PostalCode { get; set; } 
			[DataMember]
			public String City_Name { get; set; } 
			[DataMember]
			public String Street_Number { get; set; } 
			[DataMember]
			public String Street_Name { get; set; } 

		}
		#endregion
		#region SClass L6DD_GRGIfRPI_1752_Revision for attribute Revisions
		[DataContract]
		public class L6DD_GRGIfRPI_1752_Revision 
		{
			//Standard type parameters
			[DataMember]
			public Guid RevisionID { get; set; } 
			[DataMember]
			public String RevisionTitle { get; set; } 
			[DataMember]
			public Guid BuildingID { get; set; } 
			[DataMember]
			public String BuildingName { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6DD_GRGIfRPI_1752_Array cls_Get_RevisionGroupInformation_for_RealestatePropertyID(,P_L6DD_GRGIfRPI_1752 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6DD_GRGIfRPI_1752_Array invocationResult = cls_Get_RevisionGroupInformation_for_RealestatePropertyID.Invoke(connectionString,P_L6DD_GRGIfRPI_1752 Parameter,securityTicket);
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
var parameter = new CL5_KPRS_DueDiligences.Complex.Retrieval.P_L6DD_GRGIfRPI_1752();
parameter.RealestatePropertyID = ...;

*/