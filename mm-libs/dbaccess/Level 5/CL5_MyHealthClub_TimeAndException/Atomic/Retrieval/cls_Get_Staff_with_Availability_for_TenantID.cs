/* 
 * Generated on 21.11.2014 14:57:04
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

namespace CL5_MyHealthClub_TimeAndException.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Staff_with_Availability_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Staff_with_Availability_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5TE_GSAfT_1645_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5TE_GSAfT_1645_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_TimeAndException.Atomic.Retrieval.SQL.cls_Get_Staff_with_Availability_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L5TE_GSAfT_1645_raw> results = new List<L5TE_GSAfT_1645_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_BPT_EMP_EmployeeID","BusinessParticipantID","OfficeID","CMN_BPT_BusinessParticipant_ExcludedAvailabilityTypeID","SkillID","Profession_RefID","IsPrimary","CMN_BPT_BusinessParticipant_AvailabilityID","OfficeID_WhereHeIsAvailable","GlobalPropertyMatchingID","StartTime","EndTime","HasRepeatingOn_Mondays","HasRepeatingOn_Tuesdays","HasRepeatingOn_Wednesdays","HasRepeatingOn_Thursdays","HasRepeatingOn_Fridays" });
				while(reader.Read())
				{
					L5TE_GSAfT_1645_raw resultItem = new L5TE_GSAfT_1645_raw();
					//0:Parameter CMN_BPT_EMP_EmployeeID of type Guid
					resultItem.CMN_BPT_EMP_EmployeeID = reader.GetGuid(0);
					//1:Parameter BusinessParticipantID of type Guid
					resultItem.BusinessParticipantID = reader.GetGuid(1);
					//2:Parameter OfficeID of type Guid
					resultItem.OfficeID = reader.GetGuid(2);
					//3:Parameter CMN_BPT_BusinessParticipant_ExcludedAvailabilityTypeID of type Guid
					resultItem.CMN_BPT_BusinessParticipant_ExcludedAvailabilityTypeID = reader.GetGuid(3);
					//4:Parameter SkillID of type Guid
					resultItem.SkillID = reader.GetGuid(4);
					//5:Parameter Profession_RefID of type Guid
					resultItem.Profession_RefID = reader.GetGuid(5);
					//6:Parameter IsPrimary of type bool
					resultItem.IsPrimary = reader.GetBoolean(6);
					//7:Parameter CMN_BPT_BusinessParticipant_AvailabilityID of type Guid
					resultItem.CMN_BPT_BusinessParticipant_AvailabilityID = reader.GetGuid(7);
					//8:Parameter OfficeID_WhereHeIsAvailable of type Guid
					resultItem.OfficeID_WhereHeIsAvailable = reader.GetGuid(8);
					//9:Parameter GlobalPropertyMatchingID of type string
					resultItem.GlobalPropertyMatchingID = reader.GetString(9);
					//10:Parameter StartTime of type DateTime
					resultItem.StartTime = reader.GetDate(10);
					//11:Parameter EndTime of type DateTime
					resultItem.EndTime = reader.GetDate(11);
					//12:Parameter HasRepeatingOn_Mondays of type bool
					resultItem.HasRepeatingOn_Mondays = reader.GetBoolean(12);
					//13:Parameter HasRepeatingOn_Tuesdays of type bool
					resultItem.HasRepeatingOn_Tuesdays = reader.GetBoolean(13);
					//14:Parameter HasRepeatingOn_Wednesdays of type bool
					resultItem.HasRepeatingOn_Wednesdays = reader.GetBoolean(14);
					//15:Parameter HasRepeatingOn_Thursdays of type bool
					resultItem.HasRepeatingOn_Thursdays = reader.GetBoolean(15);
					//16:Parameter HasRepeatingOn_Fridays of type bool
					resultItem.HasRepeatingOn_Fridays = reader.GetBoolean(16);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Staff_with_Availability_for_TenantID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5TE_GSAfT_1645_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5TE_GSAfT_1645_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5TE_GSAfT_1645_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5TE_GSAfT_1645_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5TE_GSAfT_1645_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5TE_GSAfT_1645_Array functionReturn = new FR_L5TE_GSAfT_1645_Array();
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

				throw new Exception("Exception occured in method cls_Get_Staff_with_Availability_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5TE_GSAfT_1645_raw 
	{
		public Guid CMN_BPT_EMP_EmployeeID; 
		public Guid BusinessParticipantID; 
		public Guid OfficeID; 
		public Guid CMN_BPT_BusinessParticipant_ExcludedAvailabilityTypeID; 
		public Guid SkillID; 
		public Guid Profession_RefID; 
		public bool IsPrimary; 
		public Guid CMN_BPT_BusinessParticipant_AvailabilityID; 
		public Guid OfficeID_WhereHeIsAvailable; 
		public string GlobalPropertyMatchingID; 
		public DateTime StartTime; 
		public DateTime EndTime; 
		public bool HasRepeatingOn_Mondays; 
		public bool HasRepeatingOn_Tuesdays; 
		public bool HasRepeatingOn_Wednesdays; 
		public bool HasRepeatingOn_Thursdays; 
		public bool HasRepeatingOn_Fridays; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5TE_GSAfT_1645[] Convert(List<L5TE_GSAfT_1645_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5TE_GSAfT_1645 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.CMN_BPT_EMP_EmployeeID)).ToArray()
	group el_L5TE_GSAfT_1645 by new 
	{ 
		el_L5TE_GSAfT_1645.CMN_BPT_EMP_EmployeeID,

	}
	into gfunct_L5TE_GSAfT_1645
	select new L5TE_GSAfT_1645
	{     
		CMN_BPT_EMP_EmployeeID = gfunct_L5TE_GSAfT_1645.Key.CMN_BPT_EMP_EmployeeID ,
		BusinessParticipantID = gfunct_L5TE_GSAfT_1645.FirstOrDefault().BusinessParticipantID ,

		Offices = 
		(
			from el_Offices in gfunct_L5TE_GSAfT_1645.Where(element => !EqualsDefaultValue(element.OfficeID)).ToArray()
			group el_Offices by new 
			{ 
				el_Offices.OfficeID,

			}
			into gfunct_Offices
			select new L5TE_GSAfT_1645_Office
			{     
				OfficeID = gfunct_Offices.Key.OfficeID ,

			}
		).ToArray(),
		IsWebExcluded = 
		(
			from el_IsWebExcluded in gfunct_L5TE_GSAfT_1645.Where(element => !EqualsDefaultValue(element.CMN_BPT_BusinessParticipant_ExcludedAvailabilityTypeID)).ToArray()
			group el_IsWebExcluded by new 
			{ 
				el_IsWebExcluded.CMN_BPT_BusinessParticipant_ExcludedAvailabilityTypeID,

			}
			into gfunct_IsWebExcluded
			select new L5TE_GSAfT_1645_IsWebExcluded
			{     
				CMN_BPT_BusinessParticipant_ExcludedAvailabilityTypeID = gfunct_IsWebExcluded.Key.CMN_BPT_BusinessParticipant_ExcludedAvailabilityTypeID ,

			}
		).FirstOrDefault(),
		Skills = 
		(
			from el_Skills in gfunct_L5TE_GSAfT_1645.Where(element => !EqualsDefaultValue(element.SkillID)).ToArray()
			group el_Skills by new 
			{ 
				el_Skills.SkillID,

			}
			into gfunct_Skills
			select new L5TE_GSAfT_1645_Skill
			{     
				SkillID = gfunct_Skills.Key.SkillID ,

			}
		).ToArray(),
		Professions = 
		(
			from el_Professions in gfunct_L5TE_GSAfT_1645.Where(element => !EqualsDefaultValue(element.Profession_RefID)).ToArray()
			group el_Professions by new 
			{ 
				el_Professions.Profession_RefID,

			}
			into gfunct_Professions
			select new L5TE_GSAfT_1645_Profession
			{     
				Profession_RefID = gfunct_Professions.Key.Profession_RefID ,
				IsPrimary = gfunct_Professions.FirstOrDefault().IsPrimary ,

			}
		).ToArray(),
		Availability = 
		(
			from el_Availability in gfunct_L5TE_GSAfT_1645.Where(element => !EqualsDefaultValue(element.CMN_BPT_BusinessParticipant_AvailabilityID)).ToArray()
			group el_Availability by new 
			{ 
				el_Availability.CMN_BPT_BusinessParticipant_AvailabilityID,

			}
			into gfunct_Availability
			select new L5TE_GSAfT_1645_Availability
			{     
				CMN_BPT_BusinessParticipant_AvailabilityID = gfunct_Availability.Key.CMN_BPT_BusinessParticipant_AvailabilityID ,
				OfficeID_WhereHeIsAvailable = gfunct_Availability.FirstOrDefault().OfficeID_WhereHeIsAvailable ,
				GlobalPropertyMatchingID = gfunct_Availability.FirstOrDefault().GlobalPropertyMatchingID ,
				StartTime = gfunct_Availability.FirstOrDefault().StartTime ,
				EndTime = gfunct_Availability.FirstOrDefault().EndTime ,
				HasRepeatingOn_Mondays = gfunct_Availability.FirstOrDefault().HasRepeatingOn_Mondays ,
				HasRepeatingOn_Tuesdays = gfunct_Availability.FirstOrDefault().HasRepeatingOn_Tuesdays ,
				HasRepeatingOn_Wednesdays = gfunct_Availability.FirstOrDefault().HasRepeatingOn_Wednesdays ,
				HasRepeatingOn_Thursdays = gfunct_Availability.FirstOrDefault().HasRepeatingOn_Thursdays ,
				HasRepeatingOn_Fridays = gfunct_Availability.FirstOrDefault().HasRepeatingOn_Fridays ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5TE_GSAfT_1645_Array : FR_Base
	{
		public L5TE_GSAfT_1645[] Result	{ get; set; } 
		public FR_L5TE_GSAfT_1645_Array() : base() {}

		public FR_L5TE_GSAfT_1645_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5TE_GSAfT_1645 for attribute L5TE_GSAfT_1645
		[DataContract]
		public class L5TE_GSAfT_1645 
		{
			[DataMember]
			public L5TE_GSAfT_1645_Office[] Offices { get; set; }
			[DataMember]
			public L5TE_GSAfT_1645_IsWebExcluded IsWebExcluded { get; set; }
			[DataMember]
			public L5TE_GSAfT_1645_Skill[] Skills { get; set; }
			[DataMember]
			public L5TE_GSAfT_1645_Profession[] Professions { get; set; }
			[DataMember]
			public L5TE_GSAfT_1645_Availability[] Availability { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid CMN_BPT_EMP_EmployeeID { get; set; } 
			[DataMember]
			public Guid BusinessParticipantID { get; set; } 

		}
		#endregion
		#region SClass L5TE_GSAfT_1645_Office for attribute Offices
		[DataContract]
		public class L5TE_GSAfT_1645_Office 
		{
			//Standard type parameters
			[DataMember]
			public Guid OfficeID { get; set; } 

		}
		#endregion
		#region SClass L5TE_GSAfT_1645_IsWebExcluded for attribute IsWebExcluded
		[DataContract]
		public class L5TE_GSAfT_1645_IsWebExcluded 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_BPT_BusinessParticipant_ExcludedAvailabilityTypeID { get; set; } 

		}
		#endregion
		#region SClass L5TE_GSAfT_1645_Skill for attribute Skills
		[DataContract]
		public class L5TE_GSAfT_1645_Skill 
		{
			//Standard type parameters
			[DataMember]
			public Guid SkillID { get; set; } 

		}
		#endregion
		#region SClass L5TE_GSAfT_1645_Profession for attribute Professions
		[DataContract]
		public class L5TE_GSAfT_1645_Profession 
		{
			//Standard type parameters
			[DataMember]
			public Guid Profession_RefID { get; set; } 
			[DataMember]
			public bool IsPrimary { get; set; } 

		}
		#endregion
		#region SClass L5TE_GSAfT_1645_Availability for attribute Availability
		[DataContract]
		public class L5TE_GSAfT_1645_Availability 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_BPT_BusinessParticipant_AvailabilityID { get; set; } 
			[DataMember]
			public Guid OfficeID_WhereHeIsAvailable { get; set; } 
			[DataMember]
			public string GlobalPropertyMatchingID { get; set; } 
			[DataMember]
			public DateTime StartTime { get; set; } 
			[DataMember]
			public DateTime EndTime { get; set; } 
			[DataMember]
			public bool HasRepeatingOn_Mondays { get; set; } 
			[DataMember]
			public bool HasRepeatingOn_Tuesdays { get; set; } 
			[DataMember]
			public bool HasRepeatingOn_Wednesdays { get; set; } 
			[DataMember]
			public bool HasRepeatingOn_Thursdays { get; set; } 
			[DataMember]
			public bool HasRepeatingOn_Fridays { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5TE_GSAfT_1645_Array cls_Get_Staff_with_Availability_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5TE_GSAfT_1645_Array invocationResult = cls_Get_Staff_with_Availability_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

