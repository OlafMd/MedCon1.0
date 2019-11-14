/* 
 * Generated on 10/24/2014 6:55:53 PM
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

namespace CL3_ProjectMember.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_AssignedChargingLevels_Group_by_ProjectMemberType.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AssignedChargingLevels_Group_by_ProjectMemberType
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3PM_GACLgbPMT_1114_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3PM_GACLgbPMT_1114_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_ProjectMember.Atomic.Retrieval.SQL.cls_Get_AssignedChargingLevels_Group_by_ProjectMemberType.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L3PM_GACLgbPMT_1114_raw> results = new List<L3PM_GACLgbPMT_1114_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "TMP_PRO_ProjectMember_TypeID","ProjectMemberType_Name_DictID","CMN_BPT_InvestedWorkTime_ChargingLevelID","ChangingLevel_Name_DictID","IsDefault" });
				while(reader.Read())
				{
					L3PM_GACLgbPMT_1114_raw resultItem = new L3PM_GACLgbPMT_1114_raw();
					//0:Parameter TMP_PRO_ProjectMember_TypeID of type Guid
					resultItem.TMP_PRO_ProjectMember_TypeID = reader.GetGuid(0);
					//1:Parameter ProjectMemberType_Name of type Dict
					resultItem.ProjectMemberType_Name = reader.GetDictionary(1);
					resultItem.ProjectMemberType_Name.SourceTable = "tmp_pro_projectmember_types";
					loader.Append(resultItem.ProjectMemberType_Name);
					//2:Parameter CMN_BPT_InvestedWorkTime_ChargingLevelID of type Guid
					resultItem.CMN_BPT_InvestedWorkTime_ChargingLevelID = reader.GetGuid(2);
					//3:Parameter ChangingLevel_Name of type Dict
					resultItem.ChangingLevel_Name = reader.GetDictionary(3);
					resultItem.ChangingLevel_Name.SourceTable = "cmn_bpt_investedworktime_charginglevels";
					loader.Append(resultItem.ChangingLevel_Name);
					//4:Parameter IsDefault of type Boolean
					resultItem.IsDefault = reader.GetBoolean(4);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_AssignedChargingLevels_Group_by_ProjectMemberType",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L3PM_GACLgbPMT_1114_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3PM_GACLgbPMT_1114_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3PM_GACLgbPMT_1114_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3PM_GACLgbPMT_1114_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3PM_GACLgbPMT_1114_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3PM_GACLgbPMT_1114_Array functionReturn = new FR_L3PM_GACLgbPMT_1114_Array();
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

				throw new Exception("Exception occured in method cls_Get_AssignedChargingLevels_Group_by_ProjectMemberType",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L3PM_GACLgbPMT_1114_raw 
	{
		public Guid TMP_PRO_ProjectMember_TypeID; 
		public Dict ProjectMemberType_Name; 
		public Guid CMN_BPT_InvestedWorkTime_ChargingLevelID; 
		public Dict ChangingLevel_Name; 
		public Boolean IsDefault; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L3PM_GACLgbPMT_1114[] Convert(List<L3PM_GACLgbPMT_1114_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L3PM_GACLgbPMT_1114 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.TMP_PRO_ProjectMember_TypeID)).ToArray()
	group el_L3PM_GACLgbPMT_1114 by new 
	{ 
		el_L3PM_GACLgbPMT_1114.TMP_PRO_ProjectMember_TypeID,

	}
	into gfunct_L3PM_GACLgbPMT_1114
	select new L3PM_GACLgbPMT_1114
	{     
		TMP_PRO_ProjectMember_TypeID = gfunct_L3PM_GACLgbPMT_1114.Key.TMP_PRO_ProjectMember_TypeID ,
		ProjectMemberType_Name = gfunct_L3PM_GACLgbPMT_1114.FirstOrDefault().ProjectMemberType_Name ,

		AssignedChargingLevels = 
		(
			from el_AssignedChargingLevels in gfunct_L3PM_GACLgbPMT_1114.Where(element => !EqualsDefaultValue(element.CMN_BPT_InvestedWorkTime_ChargingLevelID)).ToArray()
			group el_AssignedChargingLevels by new 
			{ 
				el_AssignedChargingLevels.CMN_BPT_InvestedWorkTime_ChargingLevelID,

			}
			into gfunct_AssignedChargingLevels
			select new L3PM_GACLgbPMT_1114a
			{     
				CMN_BPT_InvestedWorkTime_ChargingLevelID = gfunct_AssignedChargingLevels.Key.CMN_BPT_InvestedWorkTime_ChargingLevelID ,
				ChangingLevel_Name = gfunct_AssignedChargingLevels.FirstOrDefault().ChangingLevel_Name ,
				IsDefault = gfunct_AssignedChargingLevels.FirstOrDefault().IsDefault ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L3PM_GACLgbPMT_1114_Array : FR_Base
	{
		public L3PM_GACLgbPMT_1114[] Result	{ get; set; } 
		public FR_L3PM_GACLgbPMT_1114_Array() : base() {}

		public FR_L3PM_GACLgbPMT_1114_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L3PM_GACLgbPMT_1114 for attribute L3PM_GACLgbPMT_1114
		[DataContract]
		public class L3PM_GACLgbPMT_1114 
		{
			[DataMember]
			public L3PM_GACLgbPMT_1114a[] AssignedChargingLevels { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid TMP_PRO_ProjectMember_TypeID { get; set; } 
			[DataMember]
			public Dict ProjectMemberType_Name { get; set; } 

		}
		#endregion
		#region SClass L3PM_GACLgbPMT_1114a for attribute AssignedChargingLevels
		[DataContract]
		public class L3PM_GACLgbPMT_1114a 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_BPT_InvestedWorkTime_ChargingLevelID { get; set; } 
			[DataMember]
			public Dict ChangingLevel_Name { get; set; } 
			[DataMember]
			public Boolean IsDefault { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3PM_GACLgbPMT_1114_Array cls_Get_AssignedChargingLevels_Group_by_ProjectMemberType(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3PM_GACLgbPMT_1114_Array invocationResult = cls_Get_AssignedChargingLevels_Group_by_ProjectMemberType.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

