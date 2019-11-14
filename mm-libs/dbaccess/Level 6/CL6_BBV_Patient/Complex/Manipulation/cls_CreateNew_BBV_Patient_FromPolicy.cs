/* 
 * Generated on 7/2/2013 12:32:48 PM
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

namespace CL6_BBV_Patient.Complex.Manipulation
{
	[DataContract]
	public class cls_CreateNew_BBV_Patient_FromPolicy
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L6PA_CNBBVPfP_1059 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            if (Parameter == null || Parameter.Documents == null)
                return null;

            P_L6PA_SBBVP_1223 savePatientParam = new P_L6PA_SBBVP_1223();
            var patientID = cls_Save_BBV_Patient.Invoke(Connection, Transaction, savePatientParam, securityTicket).Result;
            if (patientID == Guid.Empty)
            {
                return null;
            }
            else
            {
                P_L6PA_SBBVPP_1434 savePolicyParam = new P_L6PA_SBBVPP_1434();
                savePolicyParam.HEC_PatientID = patientID;
                var docList = new List<P_L6PA_SBBVPP_1434_Document>();
                foreach (var item in Parameter.Documents)
                {
                    P_L6PA_SBBVPP_1434_Document P_L6PA_SBBVPP_1434_Document = new P_L6PA_SBBVPP_1434_Document();
                    P_L6PA_SBBVPP_1434_Document.File_Extension = item.File_Extension;
                    P_L6PA_SBBVPP_1434_Document.File_Name = item.File_Name;
                    P_L6PA_SBBVPP_1434_Document.File_ServerLocation = item.File_ServerLocation;
                    P_L6PA_SBBVPP_1434_Document.File_Size_Bytes = item.File_Size_Bytes;
                    P_L6PA_SBBVPP_1434_Document.DocSlot_GlobalPropertyMatching = item.DocSlot_GlobalPropertyMatching;
                    docList.Add(P_L6PA_SBBVPP_1434_Document);
                }
                savePolicyParam.Documents = docList.ToArray();

                var savePolicyRes = cls_Save_BBV_PatientPolicy.Invoke(Connection, Transaction, savePolicyParam, securityTicket).Result;

                returnValue.Result = patientID;
            }

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L6PA_CNBBVPfP_1059 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L6PA_CNBBVPfP_1059 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L6PA_CNBBVPfP_1059 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6PA_CNBBVPfP_1059 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Guid functionReturn = new FR_Guid();
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

	#region Support Classes
		#region SClass P_L6PA_CNBBVPfP_1059 for attribute P_L6PA_CNBBVPfP_1059
		[DataContract]
		public class P_L6PA_CNBBVPfP_1059 
		{
			[DataMember]
			public P_L6PA_CNBBVPfP_1059_Document[] Documents { get; set; }

			//Standard type parameters
		}
		#endregion
		#region SClass P_L6PA_CNBBVPfP_1059_Document for attribute Documents
		[DataContract]
		public class P_L6PA_CNBBVPfP_1059_Document 
		{
			//Standard type parameters
			[DataMember]
			public String File_Name { get; set; } 
			[DataMember]
			public String File_Extension { get; set; } 
			[DataMember]
			public int File_Size_Bytes { get; set; } 
			[DataMember]
			public String File_ServerLocation { get; set; } 
			[DataMember]
			public string DocSlot_GlobalPropertyMatching { get; set; } 

		}
		#endregion

	#endregion
}
