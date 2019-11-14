/* 
 * Generated on 15.9.2015 10:09:24
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

namespace MMDocConnectDBMethods.MainData.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Account_Information_for_AccountID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Account_Information_for_AccountID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_MD_GAIfAID_1436 Execute(DbConnection Connection,DbTransaction Transaction,P_MD_GAIfAID_1436 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_MD_GAIfAID_1436();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.MainData.Atomic.Retrieval.SQL.cls_Get_Account_Information_for_AccountID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"UserAccountID", Parameter.UserAccountID);



			List<MD_GAIfAID_1436_raw> results = new List<MD_GAIfAID_1436_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "AccountID","FirstName","LastName","LoginMail","Title","Salutation","Rights","IsDeactivated","ReceiveNotification","Content","Type","CMN_PER_CommunicationContact_TypeID" });
				while(reader.Read())
				{
					MD_GAIfAID_1436_raw resultItem = new MD_GAIfAID_1436_raw();
					//0:Parameter AccountID of type Guid
					resultItem.AccountID = reader.GetGuid(0);
					//1:Parameter FirstName of type String
					resultItem.FirstName = reader.GetString(1);
					//2:Parameter LastName of type String
					resultItem.LastName = reader.GetString(2);
					//3:Parameter LoginMail of type String
					resultItem.LoginMail = reader.GetString(3);
					//4:Parameter Title of type String
					resultItem.Title = reader.GetString(4);
					//5:Parameter Salutation of type String
					resultItem.Salutation = reader.GetString(5);
					//6:Parameter Rights of type string
					resultItem.Rights = reader.GetString(6);
					//7:Parameter IsDeactivated of type bool
					resultItem.IsDeactivated = reader.GetBoolean(7);
					//8:Parameter ReceiveNotification of type string
					resultItem.ReceiveNotification = reader.GetString(8);
					//9:Parameter Content of type String
					resultItem.Content = reader.GetString(9);
					//10:Parameter Type of type String
					resultItem.Type = reader.GetString(10);
					//11:Parameter CMN_PER_CommunicationContact_TypeID of type Guid
					resultItem.CMN_PER_CommunicationContact_TypeID = reader.GetGuid(11);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Account_Information_for_AccountID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = MD_GAIfAID_1436_raw.Convert(results).FirstOrDefault();

			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_MD_GAIfAID_1436 Invoke(string ConnectionString,P_MD_GAIfAID_1436 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_MD_GAIfAID_1436 Invoke(DbConnection Connection,P_MD_GAIfAID_1436 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_MD_GAIfAID_1436 Invoke(DbConnection Connection, DbTransaction Transaction,P_MD_GAIfAID_1436 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_MD_GAIfAID_1436 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_MD_GAIfAID_1436 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_MD_GAIfAID_1436 functionReturn = new FR_MD_GAIfAID_1436();
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

				throw new Exception("Exception occured in method cls_Get_Account_Information_for_AccountID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class MD_GAIfAID_1436_raw 
	{
		public Guid AccountID; 
		public String FirstName; 
		public String LastName; 
		public String LoginMail; 
		public String Title; 
		public String Salutation; 
		public string Rights; 
		public bool IsDeactivated; 
		public string ReceiveNotification; 
		public String Content; 
		public String Type; 
		public Guid CMN_PER_CommunicationContact_TypeID; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static MD_GAIfAID_1436[] Convert(List<MD_GAIfAID_1436_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_MD_GAIfAID_1436 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.AccountID)).ToArray()
	group el_MD_GAIfAID_1436 by new 
	{ 
		el_MD_GAIfAID_1436.AccountID,

	}
	into gfunct_MD_GAIfAID_1436
	select new MD_GAIfAID_1436
	{     
		AccountID = gfunct_MD_GAIfAID_1436.Key.AccountID ,
		FirstName = gfunct_MD_GAIfAID_1436.FirstOrDefault().FirstName ,
		LastName = gfunct_MD_GAIfAID_1436.FirstOrDefault().LastName ,
		LoginMail = gfunct_MD_GAIfAID_1436.FirstOrDefault().LoginMail ,
		Title = gfunct_MD_GAIfAID_1436.FirstOrDefault().Title ,
		Salutation = gfunct_MD_GAIfAID_1436.FirstOrDefault().Salutation ,
		Rights = gfunct_MD_GAIfAID_1436.FirstOrDefault().Rights ,
		IsDeactivated = gfunct_MD_GAIfAID_1436.FirstOrDefault().IsDeactivated ,
		ReceiveNotification = gfunct_MD_GAIfAID_1436.FirstOrDefault().ReceiveNotification ,

		Contact = 
		(
			from el_Contact in gfunct_MD_GAIfAID_1436.Where(element => !EqualsDefaultValue(element.CMN_PER_CommunicationContact_TypeID)).ToArray()
			group el_Contact by new 
			{ 
				el_Contact.CMN_PER_CommunicationContact_TypeID,

			}
			into gfunct_Contact
			select new MD_GAIfAID_1436a
			{     
				Content = gfunct_Contact.FirstOrDefault().Content ,
				Type = gfunct_Contact.FirstOrDefault().Type ,
				CMN_PER_CommunicationContact_TypeID = gfunct_Contact.Key.CMN_PER_CommunicationContact_TypeID ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_MD_GAIfAID_1436 : FR_Base
	{
		public MD_GAIfAID_1436 Result	{ get; set; }

		public FR_MD_GAIfAID_1436() : base() {}

		public FR_MD_GAIfAID_1436(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_MD_GAIfAID_1436 for attribute P_MD_GAIfAID_1436
		[DataContract]
		public class P_MD_GAIfAID_1436 
		{
			//Standard type parameters
			[DataMember]
			public Guid UserAccountID { get; set; } 

		}
		#endregion
		#region SClass MD_GAIfAID_1436 for attribute MD_GAIfAID_1436
		[DataContract]
		public class MD_GAIfAID_1436 
		{
			[DataMember]
			public MD_GAIfAID_1436a[] Contact { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid AccountID { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public String LoginMail { get; set; } 
			[DataMember]
			public String Title { get; set; } 
			[DataMember]
			public String Salutation { get; set; } 
			[DataMember]
			public string Rights { get; set; } 
			[DataMember]
			public bool IsDeactivated { get; set; } 
			[DataMember]
			public string ReceiveNotification { get; set; } 

		}
		#endregion
		#region SClass MD_GAIfAID_1436a for attribute Contact
		[DataContract]
		public class MD_GAIfAID_1436a 
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
FR_MD_GAIfAID_1436 cls_Get_Account_Information_for_AccountID(,P_MD_GAIfAID_1436 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_MD_GAIfAID_1436 invocationResult = cls_Get_Account_Information_for_AccountID.Invoke(connectionString,P_MD_GAIfAID_1436 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.MainData.Atomic.Retrieval.P_MD_GAIfAID_1436();
parameter.UserAccountID = ...;

*/
