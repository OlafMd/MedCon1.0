/* 
 * Generated on 11.12.2012 11:54:16
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Linq;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using CL3_Document.Atomic.Retrieval;


namespace CLE_L6_DOC_Document.Complex.Retrieval
{
	[Serializable]
	public class cls_Get_Documents_and_DocumentStructures_for_DHeaderID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6DO_GDaDSfDG_1146 Execute(DbConnection Connection,DbTransaction Transaction,P_L6DO_GDaDSfDG_1146 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L6DO_GDaDSfDG_1146();

            P_L3DO_GDfDH_1108 param1 = new P_L3DO_GDfDH_1108();
            param1.DHeaderID = Parameter.DHeaderID;

            L3DO_GDfDH_1108[] docStructures = cls_Get_DocumentStructures_for_DHeaderID.Invoke(Connection, Transaction, param1, securityTicket).Result;

            P_L3DO_GDfDH_1133 param2 = new P_L3DO_GDfDH_1133();
            param2.DHeaderID = Parameter.DHeaderID;

            L3DO_GDfDH_1133[] document = cls_Get_Documents_for_DHeaderID.Invoke(Connection, Transaction, param2, securityTicket).Result;

            returnValue.Result = new L6DO_GDaDSfDG_1146();
            returnValue.Result.DocumentStructures = docStructures;
            returnValue.Result.Documents = document;


			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6DO_GDaDSfDG_1146 Invoke(string ConnectionString,P_L6DO_GDaDSfDG_1146 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6DO_GDaDSfDG_1146 Invoke(DbConnection Connection,P_L6DO_GDaDSfDG_1146 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6DO_GDaDSfDG_1146 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6DO_GDaDSfDG_1146 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6DO_GDaDSfDG_1146 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6DO_GDaDSfDG_1146 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6DO_GDaDSfDG_1146 functionReturn = new FR_L6DO_GDaDSfDG_1146();
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

				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6DO_GDaDSfDG_1146 : FR_Base
	{
		public L6DO_GDaDSfDG_1146 Result	{ get; set; }

		public FR_L6DO_GDaDSfDG_1146() : base() {}

		public FR_L6DO_GDaDSfDG_1146(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6DO_GDaDSfDG_1146 for attribute P_L6DO_GDaDSfDG_1146
		[Serializable]
		public class P_L6DO_GDaDSfDG_1146 
		{
			//Standard type parameters
			public Guid DHeaderID; 

		}
		#endregion
		#region SClass L6DO_GDaDSfDG_1146 for attribute L6DO_GDaDSfDG_1146
		[Serializable]
		public class L6DO_GDaDSfDG_1146 
		{
			//Standard type parameters
			public L3DO_GDfDH_1108[] DocumentStructures; 
			public L3DO_GDfDH_1133[] Documents; 

		}
		#endregion

	#endregion
}
