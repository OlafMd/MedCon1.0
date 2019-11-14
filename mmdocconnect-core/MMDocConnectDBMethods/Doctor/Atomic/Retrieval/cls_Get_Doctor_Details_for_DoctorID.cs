/* 
 * Generated on 09/02/16 09:31:15
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

namespace MMDocConnectDBMethods.Doctor.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Doctor_Details_for_DoctorID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Doctor_Details_for_DoctorID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_DO_GDDfDID_0823_Array Execute(DbConnection Connection,DbTransaction Transaction,P_DO_GDDfDID_0823 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_DO_GDDfDID_0823_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.Doctor.Atomic.Retrieval.SQL.cls_Get_Doctor_Details_for_DoctorID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"DoctorID", Parameter.DoctorID);



			List<DO_GDDfDID_0823_raw> results = new List<DO_GDDfDID_0823_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "doctor_account_id","id","doctor_bpt_id","fax","town","address","lanr","name","first_name","last_name","title","IBAN","BankName","BICCode","OwnerText","practice_id","practice","BSNR","sign_in_email","ZIP","city","salutation","Content","Type","CMN_PER_CommunicationContact_TypeID" });
				while(reader.Read())
				{
					DO_GDDfDID_0823_raw resultItem = new DO_GDDfDID_0823_raw();
					//0:Parameter doctor_account_id of type Guid
					resultItem.doctor_account_id = reader.GetGuid(0);
					//1:Parameter id of type Guid
					resultItem.id = reader.GetGuid(1);
					//2:Parameter doctor_bpt_id of type Guid
					resultItem.doctor_bpt_id = reader.GetGuid(2);
					//3:Parameter fax of type String
					resultItem.fax = reader.GetString(3);
					//4:Parameter town of type String
					resultItem.town = reader.GetString(4);
					//5:Parameter address of type String
					resultItem.address = reader.GetString(5);
					//6:Parameter lanr of type String
					resultItem.lanr = reader.GetString(6);
					//7:Parameter name of type String
					resultItem.name = reader.GetString(7);
					//8:Parameter first_name of type String
					resultItem.first_name = reader.GetString(8);
					//9:Parameter last_name of type String
					resultItem.last_name = reader.GetString(9);
					//10:Parameter title of type String
					resultItem.title = reader.GetString(10);
					//11:Parameter IBAN of type String
					resultItem.IBAN = reader.GetString(11);
					//12:Parameter BankName of type String
					resultItem.BankName = reader.GetString(12);
					//13:Parameter BICCode of type String
					resultItem.BICCode = reader.GetString(13);
					//14:Parameter OwnerText of type String
					resultItem.OwnerText = reader.GetString(14);
					//15:Parameter practice_id of type Guid
					resultItem.practice_id = reader.GetGuid(15);
					//16:Parameter practice of type String
					resultItem.practice = reader.GetString(16);
					//17:Parameter BSNR of type String
					resultItem.BSNR = reader.GetString(17);
					//18:Parameter sign_in_email of type String
					resultItem.sign_in_email = reader.GetString(18);
					//19:Parameter ZIP of type String
					resultItem.ZIP = reader.GetString(19);
					//20:Parameter city of type String
					resultItem.city = reader.GetString(20);
					//21:Parameter salutation of type String
					resultItem.salutation = reader.GetString(21);
					//22:Parameter Content of type String
					resultItem.Content = reader.GetString(22);
					//23:Parameter Type of type String
					resultItem.Type = reader.GetString(23);
					//24:Parameter CMN_PER_CommunicationContact_TypeID of type Guid
					resultItem.CMN_PER_CommunicationContact_TypeID = reader.GetGuid(24);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Doctor_Details_for_DoctorID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = DO_GDDfDID_0823_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_DO_GDDfDID_0823_Array Invoke(string ConnectionString,P_DO_GDDfDID_0823 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_DO_GDDfDID_0823_Array Invoke(DbConnection Connection,P_DO_GDDfDID_0823 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_DO_GDDfDID_0823_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_DO_GDDfDID_0823 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_DO_GDDfDID_0823_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_DO_GDDfDID_0823 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_DO_GDDfDID_0823_Array functionReturn = new FR_DO_GDDfDID_0823_Array();
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

				throw new Exception("Exception occured in method cls_Get_Doctor_Details_for_DoctorID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class DO_GDDfDID_0823_raw 
	{
		public Guid doctor_account_id; 
		public Guid id; 
		public Guid doctor_bpt_id; 
		public String fax; 
		public String town; 
		public String address; 
		public String lanr; 
		public String name; 
		public String first_name; 
		public String last_name; 
		public String title; 
		public String IBAN; 
		public String BankName; 
		public String BICCode; 
		public String OwnerText; 
		public Guid practice_id; 
		public String practice; 
		public String BSNR; 
		public String sign_in_email; 
		public String ZIP; 
		public String city; 
		public String salutation; 
		public String Content; 
		public String Type; 
		public Guid CMN_PER_CommunicationContact_TypeID; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static DO_GDDfDID_0823[] Convert(List<DO_GDDfDID_0823_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_DO_GDDfDID_0823 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.id)).ToArray()
	group el_DO_GDDfDID_0823 by new 
	{ 
		el_DO_GDDfDID_0823.id,

	}
	into gfunct_DO_GDDfDID_0823
	select new DO_GDDfDID_0823
	{     
		doctor_account_id = gfunct_DO_GDDfDID_0823.FirstOrDefault().doctor_account_id ,
		id = gfunct_DO_GDDfDID_0823.Key.id ,
		doctor_bpt_id = gfunct_DO_GDDfDID_0823.FirstOrDefault().doctor_bpt_id ,
		fax = gfunct_DO_GDDfDID_0823.FirstOrDefault().fax ,
		town = gfunct_DO_GDDfDID_0823.FirstOrDefault().town ,
		address = gfunct_DO_GDDfDID_0823.FirstOrDefault().address ,
		lanr = gfunct_DO_GDDfDID_0823.FirstOrDefault().lanr ,
		name = gfunct_DO_GDDfDID_0823.FirstOrDefault().name ,
		first_name = gfunct_DO_GDDfDID_0823.FirstOrDefault().first_name ,
		last_name = gfunct_DO_GDDfDID_0823.FirstOrDefault().last_name ,
		title = gfunct_DO_GDDfDID_0823.FirstOrDefault().title ,
		IBAN = gfunct_DO_GDDfDID_0823.FirstOrDefault().IBAN ,
		BankName = gfunct_DO_GDDfDID_0823.FirstOrDefault().BankName ,
		BICCode = gfunct_DO_GDDfDID_0823.FirstOrDefault().BICCode ,
		OwnerText = gfunct_DO_GDDfDID_0823.FirstOrDefault().OwnerText ,
		practice_id = gfunct_DO_GDDfDID_0823.FirstOrDefault().practice_id ,
		practice = gfunct_DO_GDDfDID_0823.FirstOrDefault().practice ,
		BSNR = gfunct_DO_GDDfDID_0823.FirstOrDefault().BSNR ,
		sign_in_email = gfunct_DO_GDDfDID_0823.FirstOrDefault().sign_in_email ,
		ZIP = gfunct_DO_GDDfDID_0823.FirstOrDefault().ZIP ,
		city = gfunct_DO_GDDfDID_0823.FirstOrDefault().city ,
		salutation = gfunct_DO_GDDfDID_0823.FirstOrDefault().salutation ,

		DoctorComunication = 
		(
			from el_DoctorComunication in gfunct_DO_GDDfDID_0823.Where(element => !EqualsDefaultValue(element.CMN_PER_CommunicationContact_TypeID)).ToArray()
			group el_DoctorComunication by new 
			{ 
				el_DoctorComunication.CMN_PER_CommunicationContact_TypeID,

			}
			into gfunct_DoctorComunication
			select new DO_GDDfDID_0823_DoctorComunication
			{     
				Content = gfunct_DoctorComunication.FirstOrDefault().Content ,
				Type = gfunct_DoctorComunication.FirstOrDefault().Type ,
				CMN_PER_CommunicationContact_TypeID = gfunct_DoctorComunication.Key.CMN_PER_CommunicationContact_TypeID ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_DO_GDDfDID_0823_Array : FR_Base
	{
		public DO_GDDfDID_0823[] Result	{ get; set; } 
		public FR_DO_GDDfDID_0823_Array() : base() {}

		public FR_DO_GDDfDID_0823_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_DO_GDDfDID_0823 for attribute P_DO_GDDfDID_0823
		[DataContract]
		public class P_DO_GDDfDID_0823 
		{
			//Standard type parameters
			[DataMember]
			public Guid DoctorID { get; set; } 

		}
		#endregion
		#region SClass DO_GDDfDID_0823 for attribute DO_GDDfDID_0823
		[DataContract]
		public class DO_GDDfDID_0823 
		{
			[DataMember]
			public DO_GDDfDID_0823_DoctorComunication[] DoctorComunication { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid doctor_account_id { get; set; } 
			[DataMember]
			public Guid id { get; set; } 
			[DataMember]
			public Guid doctor_bpt_id { get; set; } 
			[DataMember]
			public String fax { get; set; } 
			[DataMember]
			public String town { get; set; } 
			[DataMember]
			public String address { get; set; } 
			[DataMember]
			public String lanr { get; set; } 
			[DataMember]
			public String name { get; set; } 
			[DataMember]
			public String first_name { get; set; } 
			[DataMember]
			public String last_name { get; set; } 
			[DataMember]
			public String title { get; set; } 
			[DataMember]
			public String IBAN { get; set; } 
			[DataMember]
			public String BankName { get; set; } 
			[DataMember]
			public String BICCode { get; set; } 
			[DataMember]
			public String OwnerText { get; set; } 
			[DataMember]
			public Guid practice_id { get; set; } 
			[DataMember]
			public String practice { get; set; } 
			[DataMember]
			public String BSNR { get; set; } 
			[DataMember]
			public String sign_in_email { get; set; } 
			[DataMember]
			public String ZIP { get; set; } 
			[DataMember]
			public String city { get; set; } 
			[DataMember]
			public String salutation { get; set; } 

		}
		#endregion
		#region SClass DO_GDDfDID_0823_DoctorComunication for attribute DoctorComunication
		[DataContract]
		public class DO_GDDfDID_0823_DoctorComunication 
		{
			//Standard type parameters
			[DataMember]
			public String Content { get; set; } 
			[DataMember]
			public String Type { get; set; } 
			[DataMember]
			public Guid CMN_PER_CommunicationContact_TypeID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_DO_GDDfDID_0823_Array cls_Get_Doctor_Details_for_DoctorID(,P_DO_GDDfDID_0823 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_DO_GDDfDID_0823_Array invocationResult = cls_Get_Doctor_Details_for_DoctorID.Invoke(connectionString,P_DO_GDDfDID_0823 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Doctor.Atomic.Retrieval.P_DO_GDDfDID_0823();
parameter.DoctorID = ...;

*/
