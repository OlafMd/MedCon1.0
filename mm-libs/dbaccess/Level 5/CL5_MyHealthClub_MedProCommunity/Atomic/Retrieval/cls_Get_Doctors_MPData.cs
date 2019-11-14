/* 
 * Generated on 12.02.2015 19:28:23
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

namespace CL5_MyHealthClub_MedProCommunity.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Doctors_MPData.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Doctors_MPData
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5MPC_GDMPDfT_1922_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5MPC_GDMPDfT_1922_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_MedProCommunity.Atomic.Retrieval.SQL.cls_Get_Doctors_MPData.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L5MPC_GDMPDfT_1922_raw> results = new List<L5MPC_GDMPDfT_1922_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_BPT_BusinessParticipantID","CMN_BPT_EMP_EmployeeID","DisplayName","FirstName","LastName","Gender","IsTreatingChildren","PrimaryEmail","Initials","Title","DoctorIDNumber","Staff_Number","DisplayImage_RefID","Account_RefID","CMN_STR_ProfessionID","IsPrimary","ProfessionName_DictID","HEC_CMT_MembershipID","HEC_CMT_GroupSubscriptionID","HEC_CMT_CommunityGroupID","CommunityGroupCode" });
				while(reader.Read())
				{
					L5MPC_GDMPDfT_1922_raw resultItem = new L5MPC_GDMPDfT_1922_raw();
					//0:Parameter CMN_BPT_BusinessParticipantID of type Guid
					resultItem.CMN_BPT_BusinessParticipantID = reader.GetGuid(0);
					//1:Parameter CMN_BPT_EMP_EmployeeID of type Guid
					resultItem.CMN_BPT_EMP_EmployeeID = reader.GetGuid(1);
					//2:Parameter DisplayName of type String
					resultItem.DisplayName = reader.GetString(2);
					//3:Parameter FirstName of type String
					resultItem.FirstName = reader.GetString(3);
					//4:Parameter LastName of type String
					resultItem.LastName = reader.GetString(4);
					//5:Parameter Gender of type int
					resultItem.Gender = reader.GetInteger(5);
					//6:Parameter IsTreatingChildren of type Boolean
					resultItem.IsTreatingChildren = reader.GetBoolean(6);
					//7:Parameter PrimaryEmail of type String
					resultItem.PrimaryEmail = reader.GetString(7);
					//8:Parameter Initials of type String
					resultItem.Initials = reader.GetString(8);
					//9:Parameter Title of type String
					resultItem.Title = reader.GetString(9);
					//10:Parameter DoctorIDNumber of type String
					resultItem.DoctorIDNumber = reader.GetString(10);
					//11:Parameter Staff_Number of type String
					resultItem.Staff_Number = reader.GetString(11);
					//12:Parameter DisplayImage_RefID of type Guid
					resultItem.DisplayImage_RefID = reader.GetGuid(12);
					//13:Parameter Account_RefID of type Guid
					resultItem.Account_RefID = reader.GetGuid(13);
					//14:Parameter CMN_STR_ProfessionID of type Guid
					resultItem.CMN_STR_ProfessionID = reader.GetGuid(14);
					//15:Parameter IsPrimary of type bool
					resultItem.IsPrimary = reader.GetBoolean(15);
					//16:Parameter ProfessionName of type Dict
					resultItem.ProfessionName = reader.GetDictionary(16);
					resultItem.ProfessionName.SourceTable = "cmn_str_professions";
					loader.Append(resultItem.ProfessionName);
					//17:Parameter HEC_CMT_MembershipID of type Guid
					resultItem.HEC_CMT_MembershipID = reader.GetGuid(17);
					//18:Parameter HEC_CMT_GroupSubscriptionID of type Guid
					resultItem.HEC_CMT_GroupSubscriptionID = reader.GetGuid(18);
					//19:Parameter HEC_CMT_CommunityGroupID of type Guid
					resultItem.HEC_CMT_CommunityGroupID = reader.GetGuid(19);
					//20:Parameter CommunityGroupCode of type String
					resultItem.CommunityGroupCode = reader.GetString(20);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Doctors_MPData",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5MPC_GDMPDfT_1922_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5MPC_GDMPDfT_1922_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5MPC_GDMPDfT_1922_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5MPC_GDMPDfT_1922_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5MPC_GDMPDfT_1922_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5MPC_GDMPDfT_1922_Array functionReturn = new FR_L5MPC_GDMPDfT_1922_Array();
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

				throw new Exception("Exception occured in method cls_Get_Doctors_MPData",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5MPC_GDMPDfT_1922_raw 
	{
		public Guid CMN_BPT_BusinessParticipantID; 
		public Guid CMN_BPT_EMP_EmployeeID; 
		public String DisplayName; 
		public String FirstName; 
		public String LastName; 
		public int Gender; 
		public Boolean IsTreatingChildren; 
		public String PrimaryEmail; 
		public String Initials; 
		public String Title; 
		public String DoctorIDNumber; 
		public String Staff_Number; 
		public Guid DisplayImage_RefID; 
		public Guid Account_RefID; 
		public Guid CMN_STR_ProfessionID; 
		public bool IsPrimary; 
		public Dict ProfessionName; 
		public Guid HEC_CMT_MembershipID; 
		public Guid HEC_CMT_GroupSubscriptionID; 
		public Guid HEC_CMT_CommunityGroupID; 
		public String CommunityGroupCode; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5MPC_GDMPDfT_1922[] Convert(List<L5MPC_GDMPDfT_1922_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5MPC_GDMPDfT_1922 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.CMN_BPT_BusinessParticipantID)).ToArray()
	group el_L5MPC_GDMPDfT_1922 by new 
	{ 
		el_L5MPC_GDMPDfT_1922.CMN_BPT_BusinessParticipantID,

	}
	into gfunct_L5MPC_GDMPDfT_1922
	select new L5MPC_GDMPDfT_1922
	{     
		CMN_BPT_BusinessParticipantID = gfunct_L5MPC_GDMPDfT_1922.Key.CMN_BPT_BusinessParticipantID ,
		CMN_BPT_EMP_EmployeeID = gfunct_L5MPC_GDMPDfT_1922.FirstOrDefault().CMN_BPT_EMP_EmployeeID ,
		DisplayName = gfunct_L5MPC_GDMPDfT_1922.FirstOrDefault().DisplayName ,
		FirstName = gfunct_L5MPC_GDMPDfT_1922.FirstOrDefault().FirstName ,
		LastName = gfunct_L5MPC_GDMPDfT_1922.FirstOrDefault().LastName ,
		Gender = gfunct_L5MPC_GDMPDfT_1922.FirstOrDefault().Gender ,
		IsTreatingChildren = gfunct_L5MPC_GDMPDfT_1922.FirstOrDefault().IsTreatingChildren ,
		PrimaryEmail = gfunct_L5MPC_GDMPDfT_1922.FirstOrDefault().PrimaryEmail ,
		Initials = gfunct_L5MPC_GDMPDfT_1922.FirstOrDefault().Initials ,
		Title = gfunct_L5MPC_GDMPDfT_1922.FirstOrDefault().Title ,
		DoctorIDNumber = gfunct_L5MPC_GDMPDfT_1922.FirstOrDefault().DoctorIDNumber ,
		Staff_Number = gfunct_L5MPC_GDMPDfT_1922.FirstOrDefault().Staff_Number ,
		DisplayImage_RefID = gfunct_L5MPC_GDMPDfT_1922.FirstOrDefault().DisplayImage_RefID ,
		Account_RefID = gfunct_L5MPC_GDMPDfT_1922.FirstOrDefault().Account_RefID ,

		StaffProfesions = 
		(
			from el_StaffProfesions in gfunct_L5MPC_GDMPDfT_1922.Where(element => !EqualsDefaultValue(element.CMN_STR_ProfessionID)).ToArray()
			group el_StaffProfesions by new 
			{ 
				el_StaffProfesions.CMN_STR_ProfessionID,

			}
			into gfunct_StaffProfesions
			select new L5MPC_GDMPDfT_1922_StaffProfesions
			{     
				CMN_STR_ProfessionID = gfunct_StaffProfesions.Key.CMN_STR_ProfessionID ,
				IsPrimary = gfunct_StaffProfesions.FirstOrDefault().IsPrimary ,
				ProfessionName = gfunct_StaffProfesions.FirstOrDefault().ProfessionName ,

			}
		).ToArray(),
		Membership = 
		(
			from el_Membership in gfunct_L5MPC_GDMPDfT_1922.Where(element => !EqualsDefaultValue(element.HEC_CMT_MembershipID)).ToArray()
			group el_Membership by new 
			{ 
				el_Membership.HEC_CMT_MembershipID,

			}
			into gfunct_Membership
			select new L5MPC_GDMPDfT_1922_Membership
			{     
				HEC_CMT_MembershipID = gfunct_Membership.Key.HEC_CMT_MembershipID ,

				Groups = 
				(
					from el_Groups in gfunct_Membership.Where(element => !EqualsDefaultValue(element.HEC_CMT_GroupSubscriptionID)).ToArray()
					group el_Groups by new 
					{ 
						el_Groups.HEC_CMT_GroupSubscriptionID,

					}
					into gfunct_Groups
					select new L5MPC_GDMPDfT_1922_Membership_Group
					{     
						HEC_CMT_GroupSubscriptionID = gfunct_Groups.Key.HEC_CMT_GroupSubscriptionID ,
						HEC_CMT_CommunityGroupID = gfunct_Groups.FirstOrDefault().HEC_CMT_CommunityGroupID ,
						CommunityGroupCode = gfunct_Groups.FirstOrDefault().CommunityGroupCode ,

					}
				).ToArray(),

			}
		).FirstOrDefault(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5MPC_GDMPDfT_1922_Array : FR_Base
	{
		public L5MPC_GDMPDfT_1922[] Result	{ get; set; } 
		public FR_L5MPC_GDMPDfT_1922_Array() : base() {}

		public FR_L5MPC_GDMPDfT_1922_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5MPC_GDMPDfT_1922 for attribute L5MPC_GDMPDfT_1922
		[DataContract]
		public class L5MPC_GDMPDfT_1922 
		{
			[DataMember]
			public L5MPC_GDMPDfT_1922_StaffProfesions[] StaffProfesions { get; set; }
			[DataMember]
			public L5MPC_GDMPDfT_1922_Membership Membership { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid CMN_BPT_BusinessParticipantID { get; set; } 
			[DataMember]
			public Guid CMN_BPT_EMP_EmployeeID { get; set; } 
			[DataMember]
			public String DisplayName { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public int Gender { get; set; } 
			[DataMember]
			public Boolean IsTreatingChildren { get; set; } 
			[DataMember]
			public String PrimaryEmail { get; set; } 
			[DataMember]
			public String Initials { get; set; } 
			[DataMember]
			public String Title { get; set; } 
			[DataMember]
			public String DoctorIDNumber { get; set; } 
			[DataMember]
			public String Staff_Number { get; set; } 
			[DataMember]
			public Guid DisplayImage_RefID { get; set; } 
			[DataMember]
			public Guid Account_RefID { get; set; } 

		}
		#endregion
		#region SClass L5MPC_GDMPDfT_1922_StaffProfesions for attribute StaffProfesions
		[DataContract]
		public class L5MPC_GDMPDfT_1922_StaffProfesions 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_STR_ProfessionID { get; set; } 
			[DataMember]
			public bool IsPrimary { get; set; } 
			[DataMember]
			public Dict ProfessionName { get; set; } 

		}
		#endregion
		#region SClass L5MPC_GDMPDfT_1922_Membership for attribute Membership
		[DataContract]
		public class L5MPC_GDMPDfT_1922_Membership 
		{
			[DataMember]
			public L5MPC_GDMPDfT_1922_Membership_Group[] Groups { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid HEC_CMT_MembershipID { get; set; } 

		}
		#endregion
		#region SClass L5MPC_GDMPDfT_1922_Membership_Group for attribute Groups
		[DataContract]
		public class L5MPC_GDMPDfT_1922_Membership_Group 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_CMT_GroupSubscriptionID { get; set; } 
			[DataMember]
			public Guid HEC_CMT_CommunityGroupID { get; set; } 
			[DataMember]
			public String CommunityGroupCode { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5MPC_GDMPDfT_1922_Array cls_Get_Doctors_MPData(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5MPC_GDMPDfT_1922_Array invocationResult = cls_Get_Doctors_MPData.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

