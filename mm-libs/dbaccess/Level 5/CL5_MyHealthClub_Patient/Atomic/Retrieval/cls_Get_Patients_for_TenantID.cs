/* 
 * Generated on 29.01.2015 11:18:13
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

namespace CL5_MyHealthClub_Patient.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Patients_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Patients_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5PA_GPfTID_0952_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5PA_GPfTID_0952_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_Patient.Atomic.Retrieval.SQL.cls_Get_Patients_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L5PA_GPfTID_0952_raw> results = new List<L5PA_GPfTID_0952_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ID","FirstName","LastName","Title","PrimaryEmail","HICompanyName","Country_ISOCode","Street_Name","Street_Number","City_Name","BirthDate","Content","CMN_PER_CommunicationContactID","Type","CMN_PER_CommunicationContact_TypeID" });
				while(reader.Read())
				{
					L5PA_GPfTID_0952_raw resultItem = new L5PA_GPfTID_0952_raw();
					//0:Parameter ID of type Guid
					resultItem.ID = reader.GetGuid(0);
					//1:Parameter FirstName of type String
					resultItem.FirstName = reader.GetString(1);
					//2:Parameter LastName of type String
					resultItem.LastName = reader.GetString(2);
					//3:Parameter Title of type String
					resultItem.Title = reader.GetString(3);
					//4:Parameter PrimaryEmail of type String
					resultItem.PrimaryEmail = reader.GetString(4);
					//5:Parameter HICompanyName of type String
					resultItem.HICompanyName = reader.GetString(5);
					//6:Parameter Country_ISOCode of type String
					resultItem.Country_ISOCode = reader.GetString(6);
					//7:Parameter Street_Name of type String
					resultItem.Street_Name = reader.GetString(7);
					//8:Parameter Street_Number of type String
					resultItem.Street_Number = reader.GetString(8);
					//9:Parameter City_Name of type String
					resultItem.City_Name = reader.GetString(9);
					//10:Parameter BirthDate of type DateTime
					resultItem.BirthDate = reader.GetDate(10);
					//11:Parameter Content of type String
					resultItem.Content = reader.GetString(11);
					//12:Parameter CMN_PER_CommunicationContactID of type Guid
					resultItem.CMN_PER_CommunicationContactID = reader.GetGuid(12);
					//13:Parameter Type of type String
					resultItem.Type = reader.GetString(13);
					//14:Parameter CMN_PER_CommunicationContact_TypeID of type Guid
					resultItem.CMN_PER_CommunicationContact_TypeID = reader.GetGuid(14);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Patients_for_TenantID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5PA_GPfTID_0952_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5PA_GPfTID_0952_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5PA_GPfTID_0952_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5PA_GPfTID_0952_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5PA_GPfTID_0952_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5PA_GPfTID_0952_Array functionReturn = new FR_L5PA_GPfTID_0952_Array();
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

				throw new Exception("Exception occured in method cls_Get_Patients_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5PA_GPfTID_0952_raw 
	{
		public Guid ID; 
		public String FirstName; 
		public String LastName; 
		public String Title; 
		public String PrimaryEmail; 
		public String HICompanyName; 
		public String Country_ISOCode; 
		public String Street_Name; 
		public String Street_Number; 
		public String City_Name; 
		public DateTime BirthDate; 
		public String Content; 
		public Guid CMN_PER_CommunicationContactID; 
		public String Type; 
		public Guid CMN_PER_CommunicationContact_TypeID; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5PA_GPfTID_0952[] Convert(List<L5PA_GPfTID_0952_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5PA_GPfTID_0952 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.ID)).ToArray()
	group el_L5PA_GPfTID_0952 by new 
	{ 
		el_L5PA_GPfTID_0952.ID,

	}
	into gfunct_L5PA_GPfTID_0952
	select new L5PA_GPfTID_0952
	{     
		ID = gfunct_L5PA_GPfTID_0952.Key.ID ,
		FirstName = gfunct_L5PA_GPfTID_0952.FirstOrDefault().FirstName ,
		LastName = gfunct_L5PA_GPfTID_0952.FirstOrDefault().LastName ,
		Title = gfunct_L5PA_GPfTID_0952.FirstOrDefault().Title ,
		PrimaryEmail = gfunct_L5PA_GPfTID_0952.FirstOrDefault().PrimaryEmail ,
		HICompanyName = gfunct_L5PA_GPfTID_0952.FirstOrDefault().HICompanyName ,
		Country_ISOCode = gfunct_L5PA_GPfTID_0952.FirstOrDefault().Country_ISOCode ,
		Street_Name = gfunct_L5PA_GPfTID_0952.FirstOrDefault().Street_Name ,
		Street_Number = gfunct_L5PA_GPfTID_0952.FirstOrDefault().Street_Number ,
		City_Name = gfunct_L5PA_GPfTID_0952.FirstOrDefault().City_Name ,
		BirthDate = gfunct_L5PA_GPfTID_0952.FirstOrDefault().BirthDate ,

		Contact = 
		(
			from el_Contact in gfunct_L5PA_GPfTID_0952.ToArray()
			group el_Contact by new 
			{ 
			}
			into gfunct_Contact
			select new L5PA_GPfTID_0952_Contact
			{     
				Content = gfunct_Contact.FirstOrDefault().Content ,
				CMN_PER_CommunicationContactID = gfunct_Contact.FirstOrDefault().CMN_PER_CommunicationContactID ,
				Type = gfunct_Contact.FirstOrDefault().Type ,
				CMN_PER_CommunicationContact_TypeID = gfunct_Contact.FirstOrDefault().CMN_PER_CommunicationContact_TypeID ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5PA_GPfTID_0952_Array : FR_Base
	{
		public L5PA_GPfTID_0952[] Result	{ get; set; } 
		public FR_L5PA_GPfTID_0952_Array() : base() {}

		public FR_L5PA_GPfTID_0952_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5PA_GPfTID_0952 for attribute L5PA_GPfTID_0952
		[DataContract]
		public class L5PA_GPfTID_0952 
		{
			[DataMember]
			public L5PA_GPfTID_0952_Contact[] Contact { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid ID { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public String Title { get; set; } 
			[DataMember]
			public String PrimaryEmail { get; set; } 
			[DataMember]
			public String HICompanyName { get; set; } 
			[DataMember]
			public String Country_ISOCode { get; set; } 
			[DataMember]
			public String Street_Name { get; set; } 
			[DataMember]
			public String Street_Number { get; set; } 
			[DataMember]
			public String City_Name { get; set; } 
			[DataMember]
			public DateTime BirthDate { get; set; } 

		}
		#endregion
		#region SClass L5PA_GPfTID_0952_Contact for attribute Contact
		[DataContract]
		public class L5PA_GPfTID_0952_Contact 
		{
			//Standard type parameters
			[DataMember]
			public String Content { get; set; } 
			[DataMember]
			public Guid CMN_PER_CommunicationContactID { get; set; } 
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
FR_L5PA_GPfTID_0952_Array cls_Get_Patients_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5PA_GPfTID_0952_Array invocationResult = cls_Get_Patients_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

