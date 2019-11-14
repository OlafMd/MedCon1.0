/* 
 * Generated on 15.9.2014 18:20:29
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

namespace CL5_MyHealthClub_OrgUnits.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_OrgUnitData_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_OrgUnitData_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5OU_GOUDTID_1254_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5OU_GOUDTID_1254_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_OrgUnits.Atomic.Retrieval.SQL.cls_Get_OrgUnitData_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L5OU_GOUDTID_1254_raw> results = new List<L5OU_GOUDTID_1254_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "OfficeID","Parent_Office_Name_DictID","Office_Name_DictID","Street_Name","Street_Number","City_Name","Country_ISOCode","PracticeIDString","ContactPersonFirstName","ContactPersonLastName","ContactPersonTitle","hasOpeningTime","PPS_TSK_Task_TemplateID","TaskTemplateName_DictID","HEC_MedicalPractice_TypeID","MedicalPracticeType_Name_DictID" });
				while(reader.Read())
				{
					L5OU_GOUDTID_1254_raw resultItem = new L5OU_GOUDTID_1254_raw();
					//0:Parameter OfficeID of type Guid
					resultItem.OfficeID = reader.GetGuid(0);
					//1:Parameter Parent_Office_Name_DictID of type Dict
					resultItem.Parent_Office_Name_DictID = reader.GetDictionary(1);
					resultItem.Parent_Office_Name_DictID.SourceTable = "cmn_str_offices";
					loader.Append(resultItem.Parent_Office_Name_DictID);
					//2:Parameter Office_Name of type Dict
					resultItem.Office_Name = reader.GetDictionary(2);
					resultItem.Office_Name.SourceTable = "cmn_str_offices";
					loader.Append(resultItem.Office_Name);
					//3:Parameter Street_Name of type String
					resultItem.Street_Name = reader.GetString(3);
					//4:Parameter Street_Number of type String
					resultItem.Street_Number = reader.GetString(4);
					//5:Parameter City_Name of type String
					resultItem.City_Name = reader.GetString(5);
					//6:Parameter Country_ISOCode of type String
					resultItem.Country_ISOCode = reader.GetString(6);
					//7:Parameter PracticeIDString of type String
					resultItem.PracticeIDString = reader.GetString(7);
					//8:Parameter ContactPersonFirstName of type String
					resultItem.ContactPersonFirstName = reader.GetString(8);
					//9:Parameter ContactPersonLastName of type String
					resultItem.ContactPersonLastName = reader.GetString(9);
					//10:Parameter ContactPersonTitle of type String
					resultItem.ContactPersonTitle = reader.GetString(10);
					//11:Parameter hasOpeningTime of type bool
					resultItem.hasOpeningTime = reader.GetBoolean(11);
					//12:Parameter PPS_TSK_Task_TemplateID of type Guid
					resultItem.PPS_TSK_Task_TemplateID = reader.GetGuid(12);
					//13:Parameter TaskTemplateName of type Dict
					resultItem.TaskTemplateName = reader.GetDictionary(13);
					resultItem.TaskTemplateName.SourceTable = "pps_tsk_task_templates";
					loader.Append(resultItem.TaskTemplateName);
					//14:Parameter HEC_MedicalPractice_TypeID of type Guid
					resultItem.HEC_MedicalPractice_TypeID = reader.GetGuid(14);
					//15:Parameter MedicalPracticeTypeName of type Dict
					resultItem.MedicalPracticeTypeName = reader.GetDictionary(15);
					resultItem.MedicalPracticeTypeName.SourceTable = "hec_medicalpractice_types";
					loader.Append(resultItem.MedicalPracticeTypeName);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_OrgUnitData_for_TenantID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5OU_GOUDTID_1254_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5OU_GOUDTID_1254_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5OU_GOUDTID_1254_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5OU_GOUDTID_1254_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5OU_GOUDTID_1254_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5OU_GOUDTID_1254_Array functionReturn = new FR_L5OU_GOUDTID_1254_Array();
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

				throw new Exception("Exception occured in method cls_Get_OrgUnitData_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5OU_GOUDTID_1254_raw 
	{
		public Guid OfficeID; 
		public Dict Parent_Office_Name_DictID; 
		public Dict Office_Name; 
		public String Street_Name; 
		public String Street_Number; 
		public String City_Name; 
		public String Country_ISOCode; 
		public String PracticeIDString; 
		public String ContactPersonFirstName; 
		public String ContactPersonLastName; 
		public String ContactPersonTitle; 
		public bool hasOpeningTime; 
		public Guid PPS_TSK_Task_TemplateID; 
		public Dict TaskTemplateName; 
		public Guid HEC_MedicalPractice_TypeID; 
		public Dict MedicalPracticeTypeName; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5OU_GOUDTID_1254[] Convert(List<L5OU_GOUDTID_1254_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5OU_GOUDTID_1254 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.OfficeID)).ToArray()
	group el_L5OU_GOUDTID_1254 by new 
	{ 
		el_L5OU_GOUDTID_1254.OfficeID,

	}
	into gfunct_L5OU_GOUDTID_1254
	select new L5OU_GOUDTID_1254
	{     
		OfficeID = gfunct_L5OU_GOUDTID_1254.Key.OfficeID ,
		Parent_Office_Name_DictID = gfunct_L5OU_GOUDTID_1254.FirstOrDefault().Parent_Office_Name_DictID ,
		Office_Name = gfunct_L5OU_GOUDTID_1254.FirstOrDefault().Office_Name ,
		Street_Name = gfunct_L5OU_GOUDTID_1254.FirstOrDefault().Street_Name ,
		Street_Number = gfunct_L5OU_GOUDTID_1254.FirstOrDefault().Street_Number ,
		City_Name = gfunct_L5OU_GOUDTID_1254.FirstOrDefault().City_Name ,
		Country_ISOCode = gfunct_L5OU_GOUDTID_1254.FirstOrDefault().Country_ISOCode ,
		PracticeIDString = gfunct_L5OU_GOUDTID_1254.FirstOrDefault().PracticeIDString ,
		ContactPersonFirstName = gfunct_L5OU_GOUDTID_1254.FirstOrDefault().ContactPersonFirstName ,
		ContactPersonLastName = gfunct_L5OU_GOUDTID_1254.FirstOrDefault().ContactPersonLastName ,
		ContactPersonTitle = gfunct_L5OU_GOUDTID_1254.FirstOrDefault().ContactPersonTitle ,
		hasOpeningTime = gfunct_L5OU_GOUDTID_1254.FirstOrDefault().hasOpeningTime ,

		AppointmentTypeList = 
		(
			from el_AppointmentTypeList in gfunct_L5OU_GOUDTID_1254.Where(element => !EqualsDefaultValue(element.PPS_TSK_Task_TemplateID)).ToArray()
			group el_AppointmentTypeList by new 
			{ 
				el_AppointmentTypeList.PPS_TSK_Task_TemplateID,

			}
			into gfunct_AppointmentTypeList
			select new L5OU_GOUDTID_1254_ATIDL
			{     
				PPS_TSK_Task_TemplateID = gfunct_AppointmentTypeList.Key.PPS_TSK_Task_TemplateID ,
				TaskTemplateName = gfunct_AppointmentTypeList.FirstOrDefault().TaskTemplateName ,

			}
		).ToArray(),
		MedicalPracticeTypeList = 
		(
			from el_MedicalPracticeTypeList in gfunct_L5OU_GOUDTID_1254.Where(element => !EqualsDefaultValue(element.HEC_MedicalPractice_TypeID)).ToArray()
			group el_MedicalPracticeTypeList by new 
			{ 
				el_MedicalPracticeTypeList.HEC_MedicalPractice_TypeID,

			}
			into gfunct_MedicalPracticeTypeList
			select new L5OU_GOUDTID_1254_MPT
			{     
				HEC_MedicalPractice_TypeID = gfunct_MedicalPracticeTypeList.Key.HEC_MedicalPractice_TypeID ,
				MedicalPracticeTypeName = gfunct_MedicalPracticeTypeList.FirstOrDefault().MedicalPracticeTypeName ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5OU_GOUDTID_1254_Array : FR_Base
	{
		public L5OU_GOUDTID_1254[] Result	{ get; set; } 
		public FR_L5OU_GOUDTID_1254_Array() : base() {}

		public FR_L5OU_GOUDTID_1254_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5OU_GOUDTID_1254 for attribute L5OU_GOUDTID_1254
		[DataContract]
		public class L5OU_GOUDTID_1254 
		{
			[DataMember]
			public L5OU_GOUDTID_1254_ATIDL[] AppointmentTypeList { get; set; }
			[DataMember]
			public L5OU_GOUDTID_1254_MPT[] MedicalPracticeTypeList { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid OfficeID { get; set; } 
			[DataMember]
			public Dict Parent_Office_Name_DictID { get; set; } 
			[DataMember]
			public Dict Office_Name { get; set; } 
			[DataMember]
			public String Street_Name { get; set; } 
			[DataMember]
			public String Street_Number { get; set; } 
			[DataMember]
			public String City_Name { get; set; } 
			[DataMember]
			public String Country_ISOCode { get; set; } 
			[DataMember]
			public String PracticeIDString { get; set; } 
			[DataMember]
			public String ContactPersonFirstName { get; set; } 
			[DataMember]
			public String ContactPersonLastName { get; set; } 
			[DataMember]
			public String ContactPersonTitle { get; set; } 
			[DataMember]
			public bool hasOpeningTime { get; set; } 

		}
		#endregion
		#region SClass L5OU_GOUDTID_1254_ATIDL for attribute AppointmentTypeList
		[DataContract]
		public class L5OU_GOUDTID_1254_ATIDL 
		{
			//Standard type parameters
			[DataMember]
			public Guid PPS_TSK_Task_TemplateID { get; set; } 
			[DataMember]
			public Dict TaskTemplateName { get; set; } 

		}
		#endregion
		#region SClass L5OU_GOUDTID_1254_MPT for attribute MedicalPracticeTypeList
		[DataContract]
		public class L5OU_GOUDTID_1254_MPT 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_MedicalPractice_TypeID { get; set; } 
			[DataMember]
			public Dict MedicalPracticeTypeName { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5OU_GOUDTID_1254_Array cls_Get_OrgUnitData_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5OU_GOUDTID_1254_Array invocationResult = cls_Get_OrgUnitData_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

