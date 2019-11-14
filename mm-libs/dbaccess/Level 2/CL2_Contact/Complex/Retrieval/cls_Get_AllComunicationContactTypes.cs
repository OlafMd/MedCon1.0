/* 
 * Generated on 11/5/2013 4:13:48 PM
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
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Runtime.Serialization;
using CL2_Contact.DomainManagement;
using System.Reflection;
using DLCore_DBCommons;
using CL2_Language.Atomic.Retrieval;
using System.Xml;
using CL1_CMN_PER;

namespace CL2_Contact.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_AllComunicationContactTypes.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AllComunicationContactTypes
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2CN_GACCT_1519_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L2CN_GACCT_1519_Array();

            #region Get Languages

            P_L2LN_GALFTID_1530 param = new P_L2LN_GALFTID_1530();
            param.Tenant_RefID = securityTicket.TenantID;
            var DBLanguages = cls_Get_All_Languages_ForTenantID.Invoke(Connection, Transaction, param, securityTicket).Result;

            var languages = DBLanguages.Select(i => new ISOLanguage() { ISO = i.ISO_639_1, LanguageID = i.CMN_LanguageID }).ToList();

            #endregion

            Assembly asm = Assembly.GetExecutingAssembly();
            XmlDocument resource = new XmlDocument();
            XmlTextReader reader = new XmlTextReader(asm.GetManifestResourceStream(DMComunactionContactTypes.ResourceFilePath));
            resource.Load(reader);

            var predefinedContactTypes = DMComunactionContactTypes.Get_PredefinedComunactionContactTypes(Connection, Transaction, securityTicket);

            var globalPropertyMatchingIDs = predefinedContactTypes.Select(i=>i.GlobalPropertyMatchingID).ToList();

            var globalMatching2Dict = DBCommonsReader.Instance.GetDictObjectsFromResourceFile(globalPropertyMatchingIDs, resource,
                ORM_CMN_PER_CommunicationContact_Type.TableName, languages);

            returnValue.Result = predefinedContactTypes.Select(item => 
                new L2CN_GACCT_1519 { EnumType = item.Type,Type = item.GlobalPropertyMatchingID, Name = globalMatching2Dict[item.GlobalPropertyMatchingID] }).ToArray();

            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L2CN_GACCT_1519_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2CN_GACCT_1519_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2CN_GACCT_1519_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2CN_GACCT_1519_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2CN_GACCT_1519_Array functionReturn = new FR_L2CN_GACCT_1519_Array();
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

				throw new Exception("Exception occured in method cls_Get_AllComunicationContactTypes",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2CN_GACCT_1519_Array : FR_Base
	{
		public L2CN_GACCT_1519[] Result	{ get; set; } 
		public FR_L2CN_GACCT_1519_Array() : base() {}

		public FR_L2CN_GACCT_1519_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L2CN_GACCT_1519 for attribute L2CN_GACCT_1519
		[DataContract]
		public class L2CN_GACCT_1519 
		{
			//Standard type parameters
			[DataMember]
			public EComunactionContactType EnumType { get; set; } 
			[DataMember]
			public String Type { get; set; } 
			[DataMember]
			public Dict Name { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2CN_GACCT_1519_Array cls_Get_AllComunicationContactTypes(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2CN_GACCT_1519_Array invocationResult = cls_Get_AllComunicationContactTypes.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

