/* 
 * Generated on 27.11.2014 18:07:07
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

namespace CL5_MyHealthClub_BookableTimeSlot.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Slot_Combiantions_for_SlotID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Slot_Combiantions_for_SlotID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5BTS_GSCfSID_1319_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5BTS_GSCfSID_1319 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5BTS_GSCfSID_1319_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_BookableTimeSlot.Atomic.Retrieval.SQL.cls_Get_Slot_Combiantions_for_SlotID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"SlotID", Parameter.SlotID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CombinationID", Parameter.CombinationID);



			List<L5BTS_GSCfSID_1319_raw> results = new List<L5BTS_GSCfSID_1319_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "PPS_TSK_BOK_AvailableResourceCombinationID","PPS_TSK_BOK_DeviceResourceID","PPS_DEV_Device_Instance_RefID","PPS_TSK_BOK_StaffResourceID","CMN_BPT_EMP_Employee_RefID","CreatedFor_TaskTemplateRequiredStaff_RefID" });
				while(reader.Read())
				{
					L5BTS_GSCfSID_1319_raw resultItem = new L5BTS_GSCfSID_1319_raw();
					//0:Parameter PPS_TSK_BOK_AvailableResourceCombinationID of type Guid
					resultItem.PPS_TSK_BOK_AvailableResourceCombinationID = reader.GetGuid(0);
					//1:Parameter PPS_TSK_BOK_DeviceResourceID of type Guid
					resultItem.PPS_TSK_BOK_DeviceResourceID = reader.GetGuid(1);
					//2:Parameter PPS_DEV_Device_Instance_RefID of type Guid
					resultItem.PPS_DEV_Device_Instance_RefID = reader.GetGuid(2);
					//3:Parameter PPS_TSK_BOK_StaffResourceID of type Guid
					resultItem.PPS_TSK_BOK_StaffResourceID = reader.GetGuid(3);
					//4:Parameter CMN_BPT_EMP_Employee_RefID of type Guid
					resultItem.CMN_BPT_EMP_Employee_RefID = reader.GetGuid(4);
					//5:Parameter CreatedFor_TaskTemplateRequiredStaff_RefID of type Guid
					resultItem.CreatedFor_TaskTemplateRequiredStaff_RefID = reader.GetGuid(5);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Slot_Combiantions_for_SlotID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5BTS_GSCfSID_1319_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5BTS_GSCfSID_1319_Array Invoke(string ConnectionString,P_L5BTS_GSCfSID_1319 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5BTS_GSCfSID_1319_Array Invoke(DbConnection Connection,P_L5BTS_GSCfSID_1319 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5BTS_GSCfSID_1319_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5BTS_GSCfSID_1319 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5BTS_GSCfSID_1319_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5BTS_GSCfSID_1319 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5BTS_GSCfSID_1319_Array functionReturn = new FR_L5BTS_GSCfSID_1319_Array();
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

				throw new Exception("Exception occured in method cls_Get_Slot_Combiantions_for_SlotID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5BTS_GSCfSID_1319_raw 
	{
		public Guid PPS_TSK_BOK_AvailableResourceCombinationID; 
		public Guid PPS_TSK_BOK_DeviceResourceID; 
		public Guid PPS_DEV_Device_Instance_RefID; 
		public Guid PPS_TSK_BOK_StaffResourceID; 
		public Guid CMN_BPT_EMP_Employee_RefID; 
		public Guid CreatedFor_TaskTemplateRequiredStaff_RefID; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5BTS_GSCfSID_1319[] Convert(List<L5BTS_GSCfSID_1319_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5BTS_GSCfSID_1319 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.PPS_TSK_BOK_AvailableResourceCombinationID)).ToArray()
	group el_L5BTS_GSCfSID_1319 by new 
	{ 
		el_L5BTS_GSCfSID_1319.PPS_TSK_BOK_AvailableResourceCombinationID,

	}
	into gfunct_L5BTS_GSCfSID_1319
	select new L5BTS_GSCfSID_1319
	{     
		PPS_TSK_BOK_AvailableResourceCombinationID = gfunct_L5BTS_GSCfSID_1319.Key.PPS_TSK_BOK_AvailableResourceCombinationID ,

		Devices = 
		(
			from el_Devices in gfunct_L5BTS_GSCfSID_1319.Where(element => !EqualsDefaultValue(element.PPS_TSK_BOK_DeviceResourceID)).ToArray()
			group el_Devices by new 
			{ 
				el_Devices.PPS_TSK_BOK_DeviceResourceID,

			}
			into gfunct_Devices
			select new L5BTS_GSCfSID_1319_Device
			{     
				PPS_TSK_BOK_DeviceResourceID = gfunct_Devices.Key.PPS_TSK_BOK_DeviceResourceID ,
				PPS_DEV_Device_Instance_RefID = gfunct_Devices.FirstOrDefault().PPS_DEV_Device_Instance_RefID ,

			}
		).ToArray(),
		Staff = 
		(
			from el_Staff in gfunct_L5BTS_GSCfSID_1319.Where(element => !EqualsDefaultValue(element.PPS_TSK_BOK_StaffResourceID)).ToArray()
			group el_Staff by new 
			{ 
				el_Staff.PPS_TSK_BOK_StaffResourceID,

			}
			into gfunct_Staff
			select new L5BTS_GSCfSID_1319_Staff
			{     
				PPS_TSK_BOK_StaffResourceID = gfunct_Staff.Key.PPS_TSK_BOK_StaffResourceID ,
				CMN_BPT_EMP_Employee_RefID = gfunct_Staff.FirstOrDefault().CMN_BPT_EMP_Employee_RefID ,
				CreatedFor_TaskTemplateRequiredStaff_RefID = gfunct_Staff.FirstOrDefault().CreatedFor_TaskTemplateRequiredStaff_RefID ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5BTS_GSCfSID_1319_Array : FR_Base
	{
		public L5BTS_GSCfSID_1319[] Result	{ get; set; } 
		public FR_L5BTS_GSCfSID_1319_Array() : base() {}

		public FR_L5BTS_GSCfSID_1319_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5BTS_GSCfSID_1319 for attribute P_L5BTS_GSCfSID_1319
		[DataContract]
		public class P_L5BTS_GSCfSID_1319 
		{
			//Standard type parameters
			[DataMember]
			public Guid SlotID { get; set; } 
			[DataMember]
			public Guid CombinationID { get; set; } 

		}
		#endregion
		#region SClass L5BTS_GSCfSID_1319 for attribute L5BTS_GSCfSID_1319
		[DataContract]
		public class L5BTS_GSCfSID_1319 
		{
			[DataMember]
			public L5BTS_GSCfSID_1319_Device[] Devices { get; set; }
			[DataMember]
			public L5BTS_GSCfSID_1319_Staff[] Staff { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid PPS_TSK_BOK_AvailableResourceCombinationID { get; set; } 

		}
		#endregion
		#region SClass L5BTS_GSCfSID_1319_Device for attribute Devices
		[DataContract]
		public class L5BTS_GSCfSID_1319_Device 
		{
			//Standard type parameters
			[DataMember]
			public Guid PPS_TSK_BOK_DeviceResourceID { get; set; } 
			[DataMember]
			public Guid PPS_DEV_Device_Instance_RefID { get; set; } 

		}
		#endregion
		#region SClass L5BTS_GSCfSID_1319_Staff for attribute Staff
		[DataContract]
		public class L5BTS_GSCfSID_1319_Staff 
		{
			//Standard type parameters
			[DataMember]
			public Guid PPS_TSK_BOK_StaffResourceID { get; set; } 
			[DataMember]
			public Guid CMN_BPT_EMP_Employee_RefID { get; set; } 
			[DataMember]
			public Guid CreatedFor_TaskTemplateRequiredStaff_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5BTS_GSCfSID_1319_Array cls_Get_Slot_Combiantions_for_SlotID(,P_L5BTS_GSCfSID_1319 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5BTS_GSCfSID_1319_Array invocationResult = cls_Get_Slot_Combiantions_for_SlotID.Invoke(connectionString,P_L5BTS_GSCfSID_1319 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_BookableTimeSlot.Atomic.Retrieval.P_L5BTS_GSCfSID_1319();
parameter.SlotID = ...;
parameter.CombinationID = ...;

*/
