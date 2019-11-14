/* 
 * Generated on 10/25/2013 11:47:38 AM
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
using PlannicoModel.Models;

namespace CL5_VacationPlanner_Office.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_get_Offices_For_Shortname.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_get_Offices_For_Shortname
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5OF_GOFSH_1323 Execute(DbConnection Connection,DbTransaction Transaction,P_L5OF_GOFSH_1323 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5OF_GOFSH_1323();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_VacationPlanner_Office.Atomic.Retrieval.SQL.cls_get_Offices_For_Shortname.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ShortName", Parameter.ShortName);



			List<L5OF_GOFSH_1323_raw> results = new List<L5OF_GOFSH_1323_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_STR_OfficeID","Region_RefID","BillingAddress_CMN_AddressID","BillingAddress_Street_Name","BillingAddress_Street_Number","BillingAddress_City_AdministrativeDistrict","BillingAddress_City_Region","BillingAddress_City_Name","BillingAddress_City_PostalCode","BillingAddress_Province_Name","BillingAddress_Country_Name","BillingAddress_Country_ISOCode","ShippingAddress_CMN_AddressID","ShippingAddress_Street_Name","ShippingAddress_City_AdministrativeDistrict","ShippingAddress_Street_Number","ShippingAddress_City_Region","ShippingAddress_City_Name","ShippingAddress_Province_Name","ShippingAddress_City_PostalCode","ShippingAddress_Country_Name","ShippingAddress_Country_ISOCode","Default_PhoneNumber","Default_FaxNumber","Office_Name_DictID","Office_Description_DictID","Office_ShortName","CMN_CAL_CalendarInstance_RefID","CMN_BPT_BusinessParticipantID","CMN_BPT_EMP_EmployeeID","LastName","CMN_STR_Office_ResponsiblePersonID","FirstName","AssignmentID","CMN_STR_CostCenterID","InternalID","Name_DictID" });
				while(reader.Read())
				{
					L5OF_GOFSH_1323_raw resultItem = new L5OF_GOFSH_1323_raw();
					//0:Parameter CMN_STR_OfficeID of type Guid
					resultItem.CMN_STR_OfficeID = reader.GetGuid(0);
					//1:Parameter Region_RefID of type Guid
					resultItem.Region_RefID = reader.GetGuid(1);
					//2:Parameter BillingAddress_CMN_AddressID of type Guid
					resultItem.BillingAddress_CMN_AddressID = reader.GetGuid(2);
					//3:Parameter BillingAddress_Street_Name of type String
					resultItem.BillingAddress_Street_Name = reader.GetString(3);
					//4:Parameter BillingAddress_Street_Number of type String
					resultItem.BillingAddress_Street_Number = reader.GetString(4);
					//5:Parameter BillingAddress_City_AdministrativeDistrict of type String
					resultItem.BillingAddress_City_AdministrativeDistrict = reader.GetString(5);
					//6:Parameter BillingAddress_City_Region of type String
					resultItem.BillingAddress_City_Region = reader.GetString(6);
					//7:Parameter BillingAddress_City_Name of type String
					resultItem.BillingAddress_City_Name = reader.GetString(7);
					//8:Parameter BillingAddress_City_PostalCode of type String
					resultItem.BillingAddress_City_PostalCode = reader.GetString(8);
					//9:Parameter BillingAddress_Province_Name of type String
					resultItem.BillingAddress_Province_Name = reader.GetString(9);
					//10:Parameter BillingAddress_Country_Name of type String
					resultItem.BillingAddress_Country_Name = reader.GetString(10);
					//11:Parameter BillingAddress_Country_ISOCode of type String
					resultItem.BillingAddress_Country_ISOCode = reader.GetString(11);
					//12:Parameter ShippingAddress_CMN_AddressID of type Guid
					resultItem.ShippingAddress_CMN_AddressID = reader.GetGuid(12);
					//13:Parameter ShippingAddress_Street_Name of type String
					resultItem.ShippingAddress_Street_Name = reader.GetString(13);
					//14:Parameter ShippingAddress_City_AdministrativeDistrict of type String
					resultItem.ShippingAddress_City_AdministrativeDistrict = reader.GetString(14);
					//15:Parameter ShippingAddress_Street_Number of type String
					resultItem.ShippingAddress_Street_Number = reader.GetString(15);
					//16:Parameter ShippingAddress_City_Region of type String
					resultItem.ShippingAddress_City_Region = reader.GetString(16);
					//17:Parameter ShippingAddress_City_Name of type String
					resultItem.ShippingAddress_City_Name = reader.GetString(17);
					//18:Parameter ShippingAddress_Province_Name of type String
					resultItem.ShippingAddress_Province_Name = reader.GetString(18);
					//19:Parameter ShippingAddress_City_PostalCode of type String
					resultItem.ShippingAddress_City_PostalCode = reader.GetString(19);
					//20:Parameter ShippingAddress_Country_Name of type String
					resultItem.ShippingAddress_Country_Name = reader.GetString(20);
					//21:Parameter ShippingAddress_Country_ISOCode of type String
					resultItem.ShippingAddress_Country_ISOCode = reader.GetString(21);
					//22:Parameter Default_PhoneNumber of type String
					resultItem.Default_PhoneNumber = reader.GetString(22);
					//23:Parameter Default_FaxNumber of type String
					resultItem.Default_FaxNumber = reader.GetString(23);
					//24:Parameter OfficeName of type Dict
					resultItem.OfficeName = reader.GetDictionary(24);
					resultItem.OfficeName.SourceTable = "cmn_str_offices";
					loader.Append(resultItem.OfficeName);
					//25:Parameter OfficeDescription of type Dict
					resultItem.OfficeDescription = reader.GetDictionary(25);
					resultItem.OfficeDescription.SourceTable = "cmn_str_offices";
					loader.Append(resultItem.OfficeDescription);
					//26:Parameter Office_ShortName of type String
					resultItem.Office_ShortName = reader.GetString(26);
					//27:Parameter CMN_CAL_CalendarInstance_RefID of type Guid
					resultItem.CMN_CAL_CalendarInstance_RefID = reader.GetGuid(27);
					//28:Parameter CMN_BPT_BusinessParticipantID of type Guid
					resultItem.CMN_BPT_BusinessParticipantID = reader.GetGuid(28);
					//29:Parameter CMN_BPT_EMP_EmployeeID of type Guid
					resultItem.CMN_BPT_EMP_EmployeeID = reader.GetGuid(29);
					//30:Parameter LastName of type String
					resultItem.LastName = reader.GetString(30);
					//31:Parameter CMN_STR_Office_ResponsiblePersonID of type Guid
					resultItem.CMN_STR_Office_ResponsiblePersonID = reader.GetGuid(31);
					//32:Parameter FirstName of type String
					resultItem.FirstName = reader.GetString(32);
					//33:Parameter AssignmentID of type Guid
					resultItem.AssignmentID = reader.GetGuid(33);
					//34:Parameter CMN_STR_CostCenterID of type Guid
					resultItem.CMN_STR_CostCenterID = reader.GetGuid(34);
					//35:Parameter InternalID of type String
					resultItem.InternalID = reader.GetString(35);
					//36:Parameter CostcenterName of type Dict
					resultItem.CostcenterName = reader.GetDictionary(36);
					resultItem.CostcenterName.SourceTable = "cmn_str_costcenters";
					loader.Append(resultItem.CostcenterName);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_get_Offices_For_Shortname",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5OF_GOFSH_1323_raw.Convert(results).FirstOrDefault();

			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5OF_GOFSH_1323 Invoke(string ConnectionString,P_L5OF_GOFSH_1323 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5OF_GOFSH_1323 Invoke(DbConnection Connection,P_L5OF_GOFSH_1323 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5OF_GOFSH_1323 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5OF_GOFSH_1323 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5OF_GOFSH_1323 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5OF_GOFSH_1323 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5OF_GOFSH_1323 functionReturn = new FR_L5OF_GOFSH_1323();
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

				throw new Exception("Exception occured in method cls_get_Offices_For_Shortname",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5OF_GOFSH_1323_raw 
	{
		public Guid CMN_STR_OfficeID; 
		public Guid Region_RefID; 
		public Guid BillingAddress_CMN_AddressID; 
		public String BillingAddress_Street_Name; 
		public String BillingAddress_Street_Number; 
		public String BillingAddress_City_AdministrativeDistrict; 
		public String BillingAddress_City_Region; 
		public String BillingAddress_City_Name; 
		public String BillingAddress_City_PostalCode; 
		public String BillingAddress_Province_Name; 
		public String BillingAddress_Country_Name; 
		public String BillingAddress_Country_ISOCode; 
		public Guid ShippingAddress_CMN_AddressID; 
		public String ShippingAddress_Street_Name; 
		public String ShippingAddress_City_AdministrativeDistrict; 
		public String ShippingAddress_Street_Number; 
		public String ShippingAddress_City_Region; 
		public String ShippingAddress_City_Name; 
		public String ShippingAddress_Province_Name; 
		public String ShippingAddress_City_PostalCode; 
		public String ShippingAddress_Country_Name; 
		public String ShippingAddress_Country_ISOCode; 
		public String Default_PhoneNumber; 
		public String Default_FaxNumber; 
		public Dict OfficeName; 
		public Dict OfficeDescription; 
		public String Office_ShortName; 
		public Guid CMN_CAL_CalendarInstance_RefID; 
		public Guid CMN_BPT_BusinessParticipantID; 
		public Guid CMN_BPT_EMP_EmployeeID; 
		public String LastName; 
		public Guid CMN_STR_Office_ResponsiblePersonID; 
		public String FirstName; 
		public Guid AssignmentID; 
		public Guid CMN_STR_CostCenterID; 
		public String InternalID; 
		public Dict CostcenterName; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5OF_GOFSH_1323[] Convert(List<L5OF_GOFSH_1323_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5OF_GOFSH_1323 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.CMN_STR_OfficeID)).ToArray()
	group el_L5OF_GOFSH_1323 by new 
	{ 
		el_L5OF_GOFSH_1323.CMN_STR_OfficeID,

	}
	into gfunct_L5OF_GOFSH_1323
	select new L5OF_GOFSH_1323
	{     
		CMN_STR_OfficeID = gfunct_L5OF_GOFSH_1323.Key.CMN_STR_OfficeID ,
		Region_RefID = gfunct_L5OF_GOFSH_1323.FirstOrDefault().Region_RefID ,
		BillingAddress_CMN_AddressID = gfunct_L5OF_GOFSH_1323.FirstOrDefault().BillingAddress_CMN_AddressID ,
		BillingAddress_Street_Name = gfunct_L5OF_GOFSH_1323.FirstOrDefault().BillingAddress_Street_Name ,
		BillingAddress_Street_Number = gfunct_L5OF_GOFSH_1323.FirstOrDefault().BillingAddress_Street_Number ,
		BillingAddress_City_AdministrativeDistrict = gfunct_L5OF_GOFSH_1323.FirstOrDefault().BillingAddress_City_AdministrativeDistrict ,
		BillingAddress_City_Region = gfunct_L5OF_GOFSH_1323.FirstOrDefault().BillingAddress_City_Region ,
		BillingAddress_City_Name = gfunct_L5OF_GOFSH_1323.FirstOrDefault().BillingAddress_City_Name ,
		BillingAddress_City_PostalCode = gfunct_L5OF_GOFSH_1323.FirstOrDefault().BillingAddress_City_PostalCode ,
		BillingAddress_Province_Name = gfunct_L5OF_GOFSH_1323.FirstOrDefault().BillingAddress_Province_Name ,
		BillingAddress_Country_Name = gfunct_L5OF_GOFSH_1323.FirstOrDefault().BillingAddress_Country_Name ,
		BillingAddress_Country_ISOCode = gfunct_L5OF_GOFSH_1323.FirstOrDefault().BillingAddress_Country_ISOCode ,
		ShippingAddress_CMN_AddressID = gfunct_L5OF_GOFSH_1323.FirstOrDefault().ShippingAddress_CMN_AddressID ,
		ShippingAddress_Street_Name = gfunct_L5OF_GOFSH_1323.FirstOrDefault().ShippingAddress_Street_Name ,
		ShippingAddress_City_AdministrativeDistrict = gfunct_L5OF_GOFSH_1323.FirstOrDefault().ShippingAddress_City_AdministrativeDistrict ,
		ShippingAddress_Street_Number = gfunct_L5OF_GOFSH_1323.FirstOrDefault().ShippingAddress_Street_Number ,
		ShippingAddress_City_Region = gfunct_L5OF_GOFSH_1323.FirstOrDefault().ShippingAddress_City_Region ,
		ShippingAddress_City_Name = gfunct_L5OF_GOFSH_1323.FirstOrDefault().ShippingAddress_City_Name ,
		ShippingAddress_Province_Name = gfunct_L5OF_GOFSH_1323.FirstOrDefault().ShippingAddress_Province_Name ,
		ShippingAddress_City_PostalCode = gfunct_L5OF_GOFSH_1323.FirstOrDefault().ShippingAddress_City_PostalCode ,
		ShippingAddress_Country_Name = gfunct_L5OF_GOFSH_1323.FirstOrDefault().ShippingAddress_Country_Name ,
		ShippingAddress_Country_ISOCode = gfunct_L5OF_GOFSH_1323.FirstOrDefault().ShippingAddress_Country_ISOCode ,
		Default_PhoneNumber = gfunct_L5OF_GOFSH_1323.FirstOrDefault().Default_PhoneNumber ,
		Default_FaxNumber = gfunct_L5OF_GOFSH_1323.FirstOrDefault().Default_FaxNumber ,
		OfficeName = gfunct_L5OF_GOFSH_1323.FirstOrDefault().OfficeName ,
		OfficeDescription = gfunct_L5OF_GOFSH_1323.FirstOrDefault().OfficeDescription ,
		Office_ShortName = gfunct_L5OF_GOFSH_1323.FirstOrDefault().Office_ShortName ,
		CMN_CAL_CalendarInstance_RefID = gfunct_L5OF_GOFSH_1323.FirstOrDefault().CMN_CAL_CalendarInstance_RefID ,

		Managers = 
		(
			from el_Managers in gfunct_L5OF_GOFSH_1323.Where(element => !EqualsDefaultValue(element.CMN_BPT_EMP_EmployeeID)).ToArray()
			group el_Managers by new 
			{ 
				el_Managers.CMN_BPT_EMP_EmployeeID,

			}
			into gfunct_Managers
			select new L5OF_GOFSH_1323_ResponsiblePersons
			{     
				CMN_BPT_BusinessParticipantID = gfunct_Managers.FirstOrDefault().CMN_BPT_BusinessParticipantID ,
				CMN_BPT_EMP_EmployeeID = gfunct_Managers.Key.CMN_BPT_EMP_EmployeeID ,
				LastName = gfunct_Managers.FirstOrDefault().LastName ,
				CMN_STR_Office_ResponsiblePersonID = gfunct_Managers.FirstOrDefault().CMN_STR_Office_ResponsiblePersonID ,
				FirstName = gfunct_Managers.FirstOrDefault().FirstName ,

			}
		).ToArray(),
		Costcenter = 
		(
			from el_Costcenter in gfunct_L5OF_GOFSH_1323.Where(element => !EqualsDefaultValue(element.AssignmentID)).ToArray()
			group el_Costcenter by new 
			{ 
				el_Costcenter.AssignmentID,

			}
			into gfunct_Costcenter
			select new L5OF_GOFSH_1323_Costcenter
			{     
				AssignmentID = gfunct_Costcenter.Key.AssignmentID ,
				CMN_STR_CostCenterID = gfunct_Costcenter.FirstOrDefault().CMN_STR_CostCenterID ,
				InternalID = gfunct_Costcenter.FirstOrDefault().InternalID ,
				CostcenterName = gfunct_Costcenter.FirstOrDefault().CostcenterName ,

			}
		).FirstOrDefault(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5OF_GOFSH_1323 : FR_Base
	{
		public L5OF_GOFSH_1323 Result	{ get; set; }

		public FR_L5OF_GOFSH_1323() : base() {}

		public FR_L5OF_GOFSH_1323(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5OF_GOFSH_1323 cls_get_Offices_For_Shortname(,P_L5OF_GOFSH_1323 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5OF_GOFSH_1323 invocationResult = cls_get_Offices_For_Shortname.Invoke(connectionString,P_L5OF_GOFSH_1323 Parameter,securityTicket);
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
var parameter = new CL5_VacationPlanner_Office.Atomic.Retrieval.P_L5OF_GOFSH_1323();
parameter.ShortName = ...;

*/