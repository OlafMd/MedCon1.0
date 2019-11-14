/* 
 * Generated on 27.01.2015 12:18:12
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

namespace CL5_MyHealthClub_EMR.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_DoctorsBaseData_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_DoctorsBaseData_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5ME_GDBDfT_1644_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5ME_GDBDfT_1644_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_EMR.Atomic.Retrieval.SQL.cls_Get_DoctorsBaseData_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L5ME_GDBDfT_1644_raw> results = new List<L5ME_GDBDfT_1644_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_DoctorID","FirstName","LastName","Title","DoctorIDNumber","CMN_BPT_BusinessParticipantID","CMN_PER_PersonInfoID","BusinessParticipantITL","CMN_AddressID","Street_Name","Street_Number","City_Name","CMN_BPT_BusinessParticipant_AssociatedBusinessParticipantID","CMN_BPT_BusinessParticipantID1","PracticeName" });
				while(reader.Read())
				{
					L5ME_GDBDfT_1644_raw resultItem = new L5ME_GDBDfT_1644_raw();
					//0:Parameter HEC_DoctorID of type Guid
					resultItem.HEC_DoctorID = reader.GetGuid(0);
					//1:Parameter FirstName of type String
					resultItem.FirstName = reader.GetString(1);
					//2:Parameter LastName of type String
					resultItem.LastName = reader.GetString(2);
					//3:Parameter Title of type String
					resultItem.Title = reader.GetString(3);
					//4:Parameter DoctorIDNumber of type String
					resultItem.DoctorIDNumber = reader.GetString(4);
					//5:Parameter CMN_BPT_BusinessParticipantID of type Guid
					resultItem.CMN_BPT_BusinessParticipantID = reader.GetGuid(5);
					//6:Parameter CMN_PER_PersonInfoID of type Guid
					resultItem.CMN_PER_PersonInfoID = reader.GetGuid(6);
					//7:Parameter BusinessParticipantITL of type String
					resultItem.BusinessParticipantITL = reader.GetString(7);
					//8:Parameter CMN_AddressID of type Guid
					resultItem.CMN_AddressID = reader.GetGuid(8);
					//9:Parameter Street_Name of type String
					resultItem.Street_Name = reader.GetString(9);
					//10:Parameter Street_Number of type String
					resultItem.Street_Number = reader.GetString(10);
					//11:Parameter City_Name of type String
					resultItem.City_Name = reader.GetString(11);
					//12:Parameter CMN_BPT_BusinessParticipant_AssociatedBusinessParticipantID of type Guid
					resultItem.CMN_BPT_BusinessParticipant_AssociatedBusinessParticipantID = reader.GetGuid(12);
					//13:Parameter CMN_BPT_BusinessParticipantID1 of type Guid
					resultItem.CMN_BPT_BusinessParticipantID1 = reader.GetGuid(13);
					//14:Parameter PracticeName of type String
					resultItem.PracticeName = reader.GetString(14);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_DoctorsBaseData_for_TenantID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5ME_GDBDfT_1644_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5ME_GDBDfT_1644_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5ME_GDBDfT_1644_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5ME_GDBDfT_1644_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5ME_GDBDfT_1644_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5ME_GDBDfT_1644_Array functionReturn = new FR_L5ME_GDBDfT_1644_Array();
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

				throw new Exception("Exception occured in method cls_Get_DoctorsBaseData_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5ME_GDBDfT_1644_raw 
	{
		public Guid HEC_DoctorID; 
		public String FirstName; 
		public String LastName; 
		public String Title; 
		public String DoctorIDNumber; 
		public Guid CMN_BPT_BusinessParticipantID; 
		public Guid CMN_PER_PersonInfoID; 
		public String BusinessParticipantITL; 
		public Guid CMN_AddressID; 
		public String Street_Name; 
		public String Street_Number; 
		public String City_Name; 
		public Guid CMN_BPT_BusinessParticipant_AssociatedBusinessParticipantID; 
		public Guid CMN_BPT_BusinessParticipantID1; 
		public String PracticeName; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5ME_GDBDfT_1644[] Convert(List<L5ME_GDBDfT_1644_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5ME_GDBDfT_1644 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.HEC_DoctorID)).ToArray()
	group el_L5ME_GDBDfT_1644 by new 
	{ 
		el_L5ME_GDBDfT_1644.HEC_DoctorID,

	}
	into gfunct_L5ME_GDBDfT_1644
	select new L5ME_GDBDfT_1644
	{     
		HEC_DoctorID = gfunct_L5ME_GDBDfT_1644.Key.HEC_DoctorID ,
		FirstName = gfunct_L5ME_GDBDfT_1644.FirstOrDefault().FirstName ,
		LastName = gfunct_L5ME_GDBDfT_1644.FirstOrDefault().LastName ,
		Title = gfunct_L5ME_GDBDfT_1644.FirstOrDefault().Title ,
		DoctorIDNumber = gfunct_L5ME_GDBDfT_1644.FirstOrDefault().DoctorIDNumber ,
		CMN_BPT_BusinessParticipantID = gfunct_L5ME_GDBDfT_1644.FirstOrDefault().CMN_BPT_BusinessParticipantID ,
		CMN_PER_PersonInfoID = gfunct_L5ME_GDBDfT_1644.FirstOrDefault().CMN_PER_PersonInfoID ,
		BusinessParticipantITL = gfunct_L5ME_GDBDfT_1644.FirstOrDefault().BusinessParticipantITL ,

		Address = 
		(
			from el_Address in gfunct_L5ME_GDBDfT_1644.Where(element => !EqualsDefaultValue(element.CMN_AddressID)).ToArray()
			group el_Address by new 
			{ 
				el_Address.CMN_AddressID,

			}
			into gfunct_Address
			select new L5ME_GDBDfT_1644_Address
			{     
				CMN_AddressID = gfunct_Address.Key.CMN_AddressID ,
				Street_Name = gfunct_Address.FirstOrDefault().Street_Name ,
				Street_Number = gfunct_Address.FirstOrDefault().Street_Number ,
				City_Name = gfunct_Address.FirstOrDefault().City_Name ,

			}
		).FirstOrDefault(),
		Practice = 
		(
			from el_Practice in gfunct_L5ME_GDBDfT_1644.Where(element => !EqualsDefaultValue(element.CMN_BPT_BusinessParticipantID1)).ToArray()
			group el_Practice by new 
			{ 
				el_Practice.CMN_BPT_BusinessParticipantID1,

			}
			into gfunct_Practice
			select new L5ME_GDBDfT_1644_Practice
			{     
				CMN_BPT_BusinessParticipant_AssociatedBusinessParticipantID = gfunct_Practice.FirstOrDefault().CMN_BPT_BusinessParticipant_AssociatedBusinessParticipantID ,
				CMN_BPT_BusinessParticipantID1 = gfunct_Practice.Key.CMN_BPT_BusinessParticipantID1 ,
				PracticeName = gfunct_Practice.FirstOrDefault().PracticeName ,

			}
		).FirstOrDefault(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5ME_GDBDfT_1644_Array : FR_Base
	{
		public L5ME_GDBDfT_1644[] Result	{ get; set; } 
		public FR_L5ME_GDBDfT_1644_Array() : base() {}

		public FR_L5ME_GDBDfT_1644_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5ME_GDBDfT_1644 for attribute L5ME_GDBDfT_1644
		[DataContract]
		public class L5ME_GDBDfT_1644 
		{
			[DataMember]
			public L5ME_GDBDfT_1644_Address Address { get; set; }
			[DataMember]
			public L5ME_GDBDfT_1644_Practice Practice { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid HEC_DoctorID { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public String Title { get; set; } 
			[DataMember]
			public String DoctorIDNumber { get; set; } 
			[DataMember]
			public Guid CMN_BPT_BusinessParticipantID { get; set; } 
			[DataMember]
			public Guid CMN_PER_PersonInfoID { get; set; } 
			[DataMember]
			public String BusinessParticipantITL { get; set; } 

		}
		#endregion
		#region SClass L5ME_GDBDfT_1644_Address for attribute Address
		[DataContract]
		public class L5ME_GDBDfT_1644_Address 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_AddressID { get; set; } 
			[DataMember]
			public String Street_Name { get; set; } 
			[DataMember]
			public String Street_Number { get; set; } 
			[DataMember]
			public String City_Name { get; set; } 

		}
		#endregion
		#region SClass L5ME_GDBDfT_1644_Practice for attribute Practice
		[DataContract]
		public class L5ME_GDBDfT_1644_Practice 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_BPT_BusinessParticipant_AssociatedBusinessParticipantID { get; set; } 
			[DataMember]
			public Guid CMN_BPT_BusinessParticipantID1 { get; set; } 
			[DataMember]
			public String PracticeName { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5ME_GDBDfT_1644_Array cls_Get_DoctorsBaseData_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5ME_GDBDfT_1644_Array invocationResult = cls_Get_DoctorsBaseData_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

