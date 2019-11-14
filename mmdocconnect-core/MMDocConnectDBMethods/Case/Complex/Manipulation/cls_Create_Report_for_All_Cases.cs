/* 
 * Generated on 28.10.2019 13:47:30
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
using System.Threading;
using System.Globalization;
using MMDocConnectUtils;
using System.IO;
using MMDocConnectDBMethods.Archive.Complex.Manipulation;
using BOp.Providers;
using System.Web;
using MMDocConnectUtils.ExcelTemplates;

namespace MMDocConnectDBMethods.Case.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Create_Report_for_All_Cases.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Create_Report_for_All_Cases
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_CAS_CGR_1400 Execute(DbConnection connection, DbTransaction transaction, P_CAS_CGR_1400 parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			#region UserCode
            var returnValue = new FR_CAS_CGR_1400();
            returnValue.Result = new CAS_CGR_1400();
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("de-DE");
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("de-DE");
            string downloadURL = "";
            Guid prev_case_id = Guid.Empty;
            DateTime DateForElastic = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Local);
            var cases = cls_Generate_Report.Invoke(connection, transaction, new P_CAS_GR_1608() { }, securityTicket, parameter.ShowOnlyAok).Result.cases.ToList();

            List<Documents> documentList = new List<Documents>();
            if (cases.Count() > 0)
            {
                Documents documentExcel = new Documents();
                // documentExcel.documentName = "ExcelReport" + DateTime.Now.ToString("dd.MM.yyyy_HH.mm");

                if (parameter.ShowOnlyAok.HasValue )
                    if(parameter.ShowOnlyAok.Value == true)
                    {
                        documentExcel.documentName = "AokReport" + DateTime.Now.ToString("dd.MM.yyyy_HH.mm");
                    }
                    else
                    {
                        documentExcel.documentName = "!AokReport" + DateTime.Now.ToString("dd.MM.yyyy_HH.mm");
                    }
                else
                {
                    documentExcel.documentName = "ExcelReport" + DateTime.Now.ToString("dd.MM.yyyy_HH.mm");
                }

                documentExcel.documentOutputLocation = GenerateReportCases.CreateCaseXlsReport(cases, documentExcel.documentName);
                documentExcel.mimeType = UtilMethods.GetMimeType(documentExcel.documentOutputLocation);
                documentExcel.receiver = "MM";
                documentList.Add(documentExcel);
                foreach (var item in documentList)
                {
                    MemoryStream ms = new MemoryStream(File.ReadAllBytes(item.documentOutputLocation));
                    byte[] byteArrayFile = ms.ToArray();
                    var _providerFactory = ProviderFactory.Instance;
                    var documentProvider = _providerFactory.CreateDocumentServiceProvider();
                    var uploadedFrom = HttpContext.Current.Request.UserHostAddress;
                    Guid documentID = documentProvider.UploadDocument(byteArrayFile, item.documentOutputLocation, securityTicket.SessionTicket, uploadedFrom);
                    downloadURL = documentProvider.GenerateDownloadLink(documentID, securityTicket.SessionTicket, true, true);


                    P_ARCH_UD_1326 parameterDoc = new P_ARCH_UD_1326();
                    parameterDoc.DocumentID = documentID;
                    parameterDoc.Mime = UtilMethods.GetMimeType(item.documentName + ".xlsx");
                    parameterDoc.DocumentName = item.documentName;
                    parameterDoc.DocumentDate = DateForElastic;
                    parameterDoc.Receiver = "MM";
                    parameterDoc.Description = "Vollständiger Bericht";
                    cls_Upload_Report.Invoke(connection, transaction, parameterDoc, securityTicket);
                }
            }

            returnValue.Result.DownloadURL = downloadURL;
            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_CAS_CGR_1400 Invoke(string connectionString, P_CAS_CGR_1400 parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, connectionString, parameter, securityTicket);
		}
		///<summary>
		/// Invokes the method with the given connection, leaving it open if no exceptions occurred
		///<summary>
		public static FR_CAS_CGR_1400 Invoke(DbConnection connection, P_CAS_CGR_1400 parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(connection, null, null, parameter, securityTicket);
		}
		///<summary>
		/// Invokes the method for the given connection and transaction, leaving them open/not committed if no exceptions occurred
		///<summary>
		public static FR_CAS_CGR_1400 Invoke(DbConnection connection, DbTransaction transaction, P_CAS_CGR_1400 parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(connection, transaction, null, parameter, securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_CAS_CGR_1400 Invoke(DbConnection connection, DbTransaction transaction, string connectionString, P_CAS_CGR_1400 parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			var cleanupConnection = connection == null;
			var cleanupTransaction = transaction == null;

			var functionReturn = new FR_CAS_CGR_1400();
			try
			{
				if (cleanupConnection) 
				{
					connection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(connectionString);
					connection.Open();
				}
				if (cleanupTransaction)
				{
					transaction = connection.BeginTransaction();
				}

				functionReturn = Execute(connection, transaction, parameter, securityTicket);

				#region Cleanup Connection/Transaction
				//Commit the transaction 
				if (cleanupTransaction)
				{
					transaction.Commit();
				}
				//Close the connection
				if (cleanupConnection)
				{
					connection.Close();
				}
				#endregion
			}
			catch (Exception ex)
			{
				try
				{
					if (cleanupTransaction)
					{
						transaction?.Rollback();
					}
				}
				catch
				{
					// ignored
				}

				try
				{
					if (cleanupConnection)
					{
						connection?.Close();
					}
				}
				catch
				{
					// ignored
				}

				throw new Exception("Exception occurred in method cls_Create_Report_for_All_Cases", ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_CAS_CGR_1400 : FR_Base
	{
		public CAS_CGR_1400 Result	{ get; set; }

		public FR_CAS_CGR_1400() : base() {}

		public FR_CAS_CGR_1400(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_CAS_CGR_1400 for attribute P_CAS_CGR_1400
		[DataContract]
		public class P_CAS_CGR_1400 
		{
			//Standard type parameters
			[DataMember]
			public bool? ShowOnlyAok { get; set; } 

		}
		#endregion
		#region SClass CAS_CGR_1400 for attribute CAS_CGR_1400
		[DataContract]
		public class CAS_CGR_1400 
		{
			//Standard type parameters
			[DataMember]
			public String DownloadURL { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CAS_CGR_1400 cls_Create_Report_for_All_Cases(, P_CAS_CGR_1400 parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CAS_CGR_1400 invocationResult = cls_Create_Report_for_All_Cases.Invoke(connectionString, P_CAS_CGR_1400 parameter, securityTicket);
		return invocationResult.result;
	} 
	catch (Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

/* Support for Parameter Invocation (Copy&Paste)
var parameter = new MMDocConnectDBMethods.Case.Complex.Manipulation.P_CAS_CGR_1400();
parameter.ShowOnlyAok = ...;

*/
