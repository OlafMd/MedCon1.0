/* 
 * Generated on 11/11/2014 4:31:18 PM
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
    /// var result = cls_Get_OrgUnitDataEdit_for_UnitID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_OrgUnitDataEdit_for_UnitID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5OU_GOUDEUID_1330 Execute(DbConnection Connection,DbTransaction Transaction,P_L5OU_GOUDEUID_1330 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5OU_GOUDEUID_1330();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_OrgUnits.Atomic.Retrieval.SQL.cls_Get_OrgUnitDataEdit_for_UnitID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"OfficeID", Parameter.OfficeID);



			List<L5OU_GOUDEUID_1330_raw> results = new List<L5OU_GOUDEUID_1330_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_STR_OfficeID","Parent_RefID","DisplayImage_Document_RefID","Office_Name_DictID","PhoneNumber","Default_Email","Default_Website","Comment","Office_Type_RefID","ContactPersonFirstName","ContactPersonLastName","ContactPersonTitle","ParentNameDict","CMN_AddressID","IsDefaultAddress","IsSpecialAddress","IsBillingAddress","IsShippingAddress","Street_Name","Street_Number","City_Name","ZIP","Longitude","Lattitude","Country_ISOCode","Country_Name","PPS_TSK_Task_Template_RefID" });
				while(reader.Read())
				{
					L5OU_GOUDEUID_1330_raw resultItem = new L5OU_GOUDEUID_1330_raw();
					//0:Parameter CMN_STR_OfficeID of type Guid
					resultItem.CMN_STR_OfficeID = reader.GetGuid(0);
					//1:Parameter Parent_RefID of type Guid
					resultItem.Parent_RefID = reader.GetGuid(1);
					//2:Parameter DisplayImage_Document_RefID of type Guid
					resultItem.DisplayImage_Document_RefID = reader.GetGuid(2);
					//3:Parameter Office_Name of type Dict
					resultItem.Office_Name = reader.GetDictionary(3);
					resultItem.Office_Name.SourceTable = "cmn_str_offices";
					loader.Append(resultItem.Office_Name);
					//4:Parameter PhoneNumber of type String
					resultItem.PhoneNumber = reader.GetString(4);
					//5:Parameter Default_Email of type String
					resultItem.Default_Email = reader.GetString(5);
					//6:Parameter Default_Website of type String
					resultItem.Default_Website = reader.GetString(6);
					//7:Parameter Comment of type String
					resultItem.Comment = reader.GetString(7);
					//8:Parameter Office_Type_RefID of type Guid
					resultItem.Office_Type_RefID = reader.GetGuid(8);
					//9:Parameter ContactPersonFirstName of type String
					resultItem.ContactPersonFirstName = reader.GetString(9);
					//10:Parameter ContactPersonLastName of type String
					resultItem.ContactPersonLastName = reader.GetString(10);
					//11:Parameter ContactPersonTitle of type String
					resultItem.ContactPersonTitle = reader.GetString(11);
					//12:Parameter ParentNameDict of type Dict
					resultItem.ParentNameDict = reader.GetDictionary(12);
					resultItem.ParentNameDict.SourceTable = "cmn_str_offices";
					loader.Append(resultItem.ParentNameDict);
					//13:Parameter CMN_AddressID of type Guid
					resultItem.CMN_AddressID = reader.GetGuid(13);
					//14:Parameter IsDefaultAddress of type bool
					resultItem.IsDefaultAddress = reader.GetBoolean(14);
					//15:Parameter IsSpecialAddress of type bool
					resultItem.IsSpecialAddress = reader.GetBoolean(15);
					//16:Parameter IsBillingAddress of type bool
					resultItem.IsBillingAddress = reader.GetBoolean(16);
					//17:Parameter IsShippingAddress of type bool
					resultItem.IsShippingAddress = reader.GetBoolean(17);
					//18:Parameter Street_Name of type String
					resultItem.Street_Name = reader.GetString(18);
					//19:Parameter Street_Number of type String
					resultItem.Street_Number = reader.GetString(19);
					//20:Parameter City_Name of type String
					resultItem.City_Name = reader.GetString(20);
					//21:Parameter ZIP of type String
					resultItem.ZIP = reader.GetString(21);
					//22:Parameter Longitude of type double
					resultItem.Longitude = reader.GetDouble(22);
					//23:Parameter Lattitude of type double
					resultItem.Lattitude = reader.GetDouble(23);
					//24:Parameter Country_ISOCode of type String
					resultItem.Country_ISOCode = reader.GetString(24);
					//25:Parameter Country_Name of type String
					resultItem.Country_Name = reader.GetString(25);
					//26:Parameter PPS_TSK_Task_Template_RefID of type Guid
					resultItem.PPS_TSK_Task_Template_RefID = reader.GetGuid(26);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_OrgUnitDataEdit_for_UnitID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5OU_GOUDEUID_1330_raw.Convert(results).FirstOrDefault();

			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5OU_GOUDEUID_1330 Invoke(string ConnectionString,P_L5OU_GOUDEUID_1330 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5OU_GOUDEUID_1330 Invoke(DbConnection Connection,P_L5OU_GOUDEUID_1330 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5OU_GOUDEUID_1330 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5OU_GOUDEUID_1330 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5OU_GOUDEUID_1330 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5OU_GOUDEUID_1330 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5OU_GOUDEUID_1330 functionReturn = new FR_L5OU_GOUDEUID_1330();
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

				throw new Exception("Exception occured in method cls_Get_OrgUnitDataEdit_for_UnitID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5OU_GOUDEUID_1330_raw 
	{
		public Guid CMN_STR_OfficeID; 
		public Guid Parent_RefID; 
		public Guid DisplayImage_Document_RefID; 
		public Dict Office_Name; 
		public String PhoneNumber; 
		public String Default_Email; 
		public String Default_Website; 
		public String Comment; 
		public Guid Office_Type_RefID; 
		public String ContactPersonFirstName; 
		public String ContactPersonLastName; 
		public String ContactPersonTitle; 
		public Dict ParentNameDict; 
		public Guid CMN_AddressID; 
		public bool IsDefaultAddress; 
		public bool IsSpecialAddress; 
		public bool IsBillingAddress; 
		public bool IsShippingAddress; 
		public String Street_Name; 
		public String Street_Number; 
		public String City_Name; 
		public String ZIP; 
		public double Longitude; 
		public double Lattitude; 
		public String Country_ISOCode; 
		public String Country_Name; 
		public Guid PPS_TSK_Task_Template_RefID; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5OU_GOUDEUID_1330[] Convert(List<L5OU_GOUDEUID_1330_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5OU_GOUDEUID_1330 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.CMN_STR_OfficeID)).ToArray()
	group el_L5OU_GOUDEUID_1330 by new 
	{ 
		el_L5OU_GOUDEUID_1330.CMN_STR_OfficeID,

	}
	into gfunct_L5OU_GOUDEUID_1330
	select new L5OU_GOUDEUID_1330
	{     
		CMN_STR_OfficeID = gfunct_L5OU_GOUDEUID_1330.Key.CMN_STR_OfficeID ,
		Parent_RefID = gfunct_L5OU_GOUDEUID_1330.FirstOrDefault().Parent_RefID ,
		DisplayImage_Document_RefID = gfunct_L5OU_GOUDEUID_1330.FirstOrDefault().DisplayImage_Document_RefID ,
		Office_Name = gfunct_L5OU_GOUDEUID_1330.FirstOrDefault().Office_Name ,
		PhoneNumber = gfunct_L5OU_GOUDEUID_1330.FirstOrDefault().PhoneNumber ,
		Default_Email = gfunct_L5OU_GOUDEUID_1330.FirstOrDefault().Default_Email ,
		Default_Website = gfunct_L5OU_GOUDEUID_1330.FirstOrDefault().Default_Website ,
		Comment = gfunct_L5OU_GOUDEUID_1330.FirstOrDefault().Comment ,
		Office_Type_RefID = gfunct_L5OU_GOUDEUID_1330.FirstOrDefault().Office_Type_RefID ,
		ContactPersonFirstName = gfunct_L5OU_GOUDEUID_1330.FirstOrDefault().ContactPersonFirstName ,
		ContactPersonLastName = gfunct_L5OU_GOUDEUID_1330.FirstOrDefault().ContactPersonLastName ,
		ContactPersonTitle = gfunct_L5OU_GOUDEUID_1330.FirstOrDefault().ContactPersonTitle ,
		ParentNameDict = gfunct_L5OU_GOUDEUID_1330.FirstOrDefault().ParentNameDict ,

		Addresses = 
		(
			from el_Addresses in gfunct_L5OU_GOUDEUID_1330.Where(element => !EqualsDefaultValue(element.CMN_AddressID)).ToArray()
			group el_Addresses by new 
			{ 
				el_Addresses.CMN_AddressID,

			}
			into gfunct_Addresses
			select new L5OU_GOUDEUID_1330_Addresses
			{     
				CMN_AddressID = gfunct_Addresses.Key.CMN_AddressID ,
				IsDefaultAddress = gfunct_Addresses.FirstOrDefault().IsDefaultAddress ,
				IsSpecialAddress = gfunct_Addresses.FirstOrDefault().IsSpecialAddress ,
				IsBillingAddress = gfunct_Addresses.FirstOrDefault().IsBillingAddress ,
				IsShippingAddress = gfunct_Addresses.FirstOrDefault().IsShippingAddress ,
				Street_Name = gfunct_Addresses.FirstOrDefault().Street_Name ,
				Street_Number = gfunct_Addresses.FirstOrDefault().Street_Number ,
				City_Name = gfunct_Addresses.FirstOrDefault().City_Name ,
				ZIP = gfunct_Addresses.FirstOrDefault().ZIP ,
				Longitude = gfunct_Addresses.FirstOrDefault().Longitude ,
				Lattitude = gfunct_Addresses.FirstOrDefault().Lattitude ,
				Country_ISOCode = gfunct_Addresses.FirstOrDefault().Country_ISOCode ,
				Country_Name = gfunct_Addresses.FirstOrDefault().Country_Name ,

			}
		).ToArray(),
		AppointmentType = 
		(
			from el_AppointmentType in gfunct_L5OU_GOUDEUID_1330.Where(element => !EqualsDefaultValue(element.PPS_TSK_Task_Template_RefID)).ToArray()
			group el_AppointmentType by new 
			{ 
				el_AppointmentType.PPS_TSK_Task_Template_RefID,

			}
			into gfunct_AppointmentType
			select new L5OU_GOUDEUID_1330_AppointmentTypee
			{     
				PPS_TSK_Task_Template_RefID = gfunct_AppointmentType.Key.PPS_TSK_Task_Template_RefID ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5OU_GOUDEUID_1330 : FR_Base
	{
		public L5OU_GOUDEUID_1330 Result	{ get; set; }

		public FR_L5OU_GOUDEUID_1330() : base() {}

		public FR_L5OU_GOUDEUID_1330(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5OU_GOUDEUID_1330 for attribute P_L5OU_GOUDEUID_1330
		[DataContract]
		public class P_L5OU_GOUDEUID_1330 
		{
			//Standard type parameters
			[DataMember]
			public Guid OfficeID { get; set; } 

		}
		#endregion
		#region SClass L5OU_GOUDEUID_1330 for attribute L5OU_GOUDEUID_1330
		[DataContract]
		public class L5OU_GOUDEUID_1330 
		{
			[DataMember]
			public L5OU_GOUDEUID_1330_Addresses[] Addresses { get; set; }
			[DataMember]
			public L5OU_GOUDEUID_1330_AppointmentTypee[] AppointmentType { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid CMN_STR_OfficeID { get; set; } 
			[DataMember]
			public Guid Parent_RefID { get; set; } 
			[DataMember]
			public Guid DisplayImage_Document_RefID { get; set; } 
			[DataMember]
			public Dict Office_Name { get; set; } 
			[DataMember]
			public String PhoneNumber { get; set; } 
			[DataMember]
			public String Default_Email { get; set; } 
			[DataMember]
			public String Default_Website { get; set; } 
			[DataMember]
			public String Comment { get; set; } 
			[DataMember]
			public Guid Office_Type_RefID { get; set; } 
			[DataMember]
			public String ContactPersonFirstName { get; set; } 
			[DataMember]
			public String ContactPersonLastName { get; set; } 
			[DataMember]
			public String ContactPersonTitle { get; set; } 
			[DataMember]
			public Dict ParentNameDict { get; set; } 

		}
		#endregion
		#region SClass L5OU_GOUDEUID_1330_Addresses for attribute Addresses
		[DataContract]
		public class L5OU_GOUDEUID_1330_Addresses 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_AddressID { get; set; } 
			[DataMember]
			public bool IsDefaultAddress { get; set; } 
			[DataMember]
			public bool IsSpecialAddress { get; set; } 
			[DataMember]
			public bool IsBillingAddress { get; set; } 
			[DataMember]
			public bool IsShippingAddress { get; set; } 
			[DataMember]
			public String Street_Name { get; set; } 
			[DataMember]
			public String Street_Number { get; set; } 
			[DataMember]
			public String City_Name { get; set; } 
			[DataMember]
			public String ZIP { get; set; } 
			[DataMember]
			public double Longitude { get; set; } 
			[DataMember]
			public double Lattitude { get; set; } 
			[DataMember]
			public String Country_ISOCode { get; set; } 
			[DataMember]
			public String Country_Name { get; set; } 

		}
		#endregion
		#region SClass L5OU_GOUDEUID_1330_AppointmentTypee for attribute AppointmentType
		[DataContract]
		public class L5OU_GOUDEUID_1330_AppointmentTypee 
		{
			//Standard type parameters
			[DataMember]
			public Guid PPS_TSK_Task_Template_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5OU_GOUDEUID_1330 cls_Get_OrgUnitDataEdit_for_UnitID(,P_L5OU_GOUDEUID_1330 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5OU_GOUDEUID_1330 invocationResult = cls_Get_OrgUnitDataEdit_for_UnitID.Invoke(connectionString,P_L5OU_GOUDEUID_1330 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_OrgUnits.Atomic.Retrieval.P_L5OU_GOUDEUID_1330();
parameter.OfficeID = ...;

*/
