/* 
 * Generated on 03.03.2015 17:46:43
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

namespace CL5_MPC_Account.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_AcctionInfo_for_ID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AcctionInfo_for_ID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5AC_GAIfID_1621 Execute(DbConnection Connection,DbTransaction Transaction,P_L5AC_GAIfID_1621 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5AC_GAIfID_1621();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MPC_Account.Atomic.Retrieval.SQL.cls_Get_AcctionInfo_for_ID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CMN_BPT_USR_UserID", Parameter.CMN_BPT_USR_UserID);



			List<L5AC_GAIfID_1621_raw> results = new List<L5AC_GAIfID_1621_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_BPT_USR_UserID","CMN_PER_PersonInfoID","FirstName","LastName","PrimaryEmail","Title","CMN_AddressID","Street_Name","Street_Number","City_Name","City_PostalCode","Country_Name","HEC_CMT_MembershipID","IsAvailableFor_Tenants","IsAvailableFor_Doctors","CMN_BPT_BusinessParticipantID" });
				while(reader.Read())
				{
					L5AC_GAIfID_1621_raw resultItem = new L5AC_GAIfID_1621_raw();
					//0:Parameter CMN_BPT_USR_UserID of type Guid
					resultItem.CMN_BPT_USR_UserID = reader.GetGuid(0);
					//1:Parameter CMN_PER_PersonInfoID of type Guid
					resultItem.CMN_PER_PersonInfoID = reader.GetGuid(1);
					//2:Parameter FirstName of type string
					resultItem.FirstName = reader.GetString(2);
					//3:Parameter LastName of type string
					resultItem.LastName = reader.GetString(3);
					//4:Parameter PrimaryEmail of type string
					resultItem.PrimaryEmail = reader.GetString(4);
					//5:Parameter Title of type string
					resultItem.Title = reader.GetString(5);
					//6:Parameter CMN_AddressID of type Guid
					resultItem.CMN_AddressID = reader.GetGuid(6);
					//7:Parameter Street_Name of type string
					resultItem.Street_Name = reader.GetString(7);
					//8:Parameter Street_Number of type string
					resultItem.Street_Number = reader.GetString(8);
					//9:Parameter City_Name of type string
					resultItem.City_Name = reader.GetString(9);
					//10:Parameter City_PostalCode of type string
					resultItem.City_PostalCode = reader.GetString(10);
					//11:Parameter Country_Name of type string
					resultItem.Country_Name = reader.GetString(11);
					//12:Parameter HEC_CMT_MembershipID of type Guid
					resultItem.HEC_CMT_MembershipID = reader.GetGuid(12);
					//13:Parameter IsAvailableFor_Tenants of type bool
					resultItem.IsAvailableFor_Tenants = reader.GetBoolean(13);
					//14:Parameter IsAvailableFor_Doctors of type bool
					resultItem.IsAvailableFor_Doctors = reader.GetBoolean(14);
					//15:Parameter CMN_BPT_BusinessParticipantID of type Guid
					resultItem.CMN_BPT_BusinessParticipantID = reader.GetGuid(15);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_AcctionInfo_for_ID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5AC_GAIfID_1621_raw.Convert(results).FirstOrDefault();

			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5AC_GAIfID_1621 Invoke(string ConnectionString,P_L5AC_GAIfID_1621 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5AC_GAIfID_1621 Invoke(DbConnection Connection,P_L5AC_GAIfID_1621 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5AC_GAIfID_1621 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AC_GAIfID_1621 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5AC_GAIfID_1621 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AC_GAIfID_1621 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5AC_GAIfID_1621 functionReturn = new FR_L5AC_GAIfID_1621();
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

				throw new Exception("Exception occured in method cls_Get_AcctionInfo_for_ID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5AC_GAIfID_1621_raw 
	{
		public Guid CMN_BPT_USR_UserID; 
		public Guid CMN_PER_PersonInfoID; 
		public string FirstName; 
		public string LastName; 
		public string PrimaryEmail; 
		public string Title; 
		public Guid CMN_AddressID; 
		public string Street_Name; 
		public string Street_Number; 
		public string City_Name; 
		public string City_PostalCode; 
		public string Country_Name; 
		public Guid HEC_CMT_MembershipID; 
		public bool IsAvailableFor_Tenants; 
		public bool IsAvailableFor_Doctors; 
		public Guid CMN_BPT_BusinessParticipantID; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5AC_GAIfID_1621[] Convert(List<L5AC_GAIfID_1621_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5AC_GAIfID_1621 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.CMN_PER_PersonInfoID)).ToArray()
	group el_L5AC_GAIfID_1621 by new 
	{ 
		el_L5AC_GAIfID_1621.CMN_PER_PersonInfoID,

	}
	into gfunct_L5AC_GAIfID_1621
	select new L5AC_GAIfID_1621
	{     
		CMN_BPT_USR_UserID = gfunct_L5AC_GAIfID_1621.FirstOrDefault().CMN_BPT_USR_UserID ,
		CMN_PER_PersonInfoID = gfunct_L5AC_GAIfID_1621.Key.CMN_PER_PersonInfoID ,
		FirstName = gfunct_L5AC_GAIfID_1621.FirstOrDefault().FirstName ,
		LastName = gfunct_L5AC_GAIfID_1621.FirstOrDefault().LastName ,
		PrimaryEmail = gfunct_L5AC_GAIfID_1621.FirstOrDefault().PrimaryEmail ,
		Title = gfunct_L5AC_GAIfID_1621.FirstOrDefault().Title ,
		CMN_AddressID = gfunct_L5AC_GAIfID_1621.FirstOrDefault().CMN_AddressID ,
		Street_Name = gfunct_L5AC_GAIfID_1621.FirstOrDefault().Street_Name ,
		Street_Number = gfunct_L5AC_GAIfID_1621.FirstOrDefault().Street_Number ,
		City_Name = gfunct_L5AC_GAIfID_1621.FirstOrDefault().City_Name ,
		City_PostalCode = gfunct_L5AC_GAIfID_1621.FirstOrDefault().City_PostalCode ,
		Country_Name = gfunct_L5AC_GAIfID_1621.FirstOrDefault().Country_Name ,
		HEC_CMT_MembershipID = gfunct_L5AC_GAIfID_1621.FirstOrDefault().HEC_CMT_MembershipID ,
		IsAvailableFor_Tenants = gfunct_L5AC_GAIfID_1621.FirstOrDefault().IsAvailableFor_Tenants ,
		IsAvailableFor_Doctors = gfunct_L5AC_GAIfID_1621.FirstOrDefault().IsAvailableFor_Doctors ,
		CMN_BPT_BusinessParticipantID = gfunct_L5AC_GAIfID_1621.FirstOrDefault().CMN_BPT_BusinessParticipantID ,

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5AC_GAIfID_1621 : FR_Base
	{
		public L5AC_GAIfID_1621 Result	{ get; set; }

		public FR_L5AC_GAIfID_1621() : base() {}

		public FR_L5AC_GAIfID_1621(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5AC_GAIfID_1621 for attribute P_L5AC_GAIfID_1621
		[DataContract]
		public class P_L5AC_GAIfID_1621 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_BPT_USR_UserID { get; set; } 

		}
		#endregion
		#region SClass L5AC_GAIfID_1621 for attribute L5AC_GAIfID_1621
		[DataContract]
		public class L5AC_GAIfID_1621 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_BPT_USR_UserID { get; set; } 
			[DataMember]
			public Guid CMN_PER_PersonInfoID { get; set; } 
			[DataMember]
			public string FirstName { get; set; } 
			[DataMember]
			public string LastName { get; set; } 
			[DataMember]
			public string PrimaryEmail { get; set; } 
			[DataMember]
			public string Title { get; set; } 
			[DataMember]
			public Guid CMN_AddressID { get; set; } 
			[DataMember]
			public string Street_Name { get; set; } 
			[DataMember]
			public string Street_Number { get; set; } 
			[DataMember]
			public string City_Name { get; set; } 
			[DataMember]
			public string City_PostalCode { get; set; } 
			[DataMember]
			public string Country_Name { get; set; } 
			[DataMember]
			public Guid HEC_CMT_MembershipID { get; set; } 
			[DataMember]
			public bool IsAvailableFor_Tenants { get; set; } 
			[DataMember]
			public bool IsAvailableFor_Doctors { get; set; } 
			[DataMember]
			public Guid CMN_BPT_BusinessParticipantID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5AC_GAIfID_1621 cls_Get_AcctionInfo_for_ID(,P_L5AC_GAIfID_1621 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5AC_GAIfID_1621 invocationResult = cls_Get_AcctionInfo_for_ID.Invoke(connectionString,P_L5AC_GAIfID_1621 Parameter,securityTicket);
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
var parameter = new CL5_MPC_Account.Atomic.Retrieval.P_L5AC_GAIfID_1621();
parameter.CMN_BPT_USR_UserID = ...;

*/
