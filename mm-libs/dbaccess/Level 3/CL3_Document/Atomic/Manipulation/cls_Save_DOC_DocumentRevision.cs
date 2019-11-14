/* 
 * Generated on 7/8/2013 11:02:35 AM
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
using CL1_DOC;
using CSV2Core_MySQL.Support;

namespace CL3_Document.Atomic.Manipulation
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_DOC_DocumentRevision.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_DOC_DocumentRevision
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3DO_SDR_1401 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			
            var returnValue = new FR_Guid();

            var item = new ORM_DOC_DocumentRevision();
            if (Parameter.DOC_DocumentRevisionID != Guid.Empty)
            {
                var result = item.Load(Connection, Transaction, Parameter.DOC_DocumentRevisionID);
                if (result.Status != FR_Status.Success || item.DOC_DocumentRevisionID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }

            if (Parameter.IsDeleted == true)
            {
                item.IsDeleted = true;
                return new FR_Guid(item.Save(Connection, Transaction), item.DOC_DocumentRevisionID);
            }

            //Creation specific parameters (Tenant, Account ... )
            if (Parameter.DOC_DocumentRevisionID == Guid.Empty)
            {
                #region Set IsLastRevision

                ORM_DOC_DocumentRevision instance = CSV2Core_MySQL.Support.SQLClassFilter.GetDefaultInstance<ORM_DOC_DocumentRevision>();
                instance.IsLastRevision = false;
                InstanceFilterWrapper instanceWrap = InstanceFilterWrapper.Wrap(instance, new string[] { "IsLastRevision" });

                ORM_DOC_DocumentRevision comparator = CSV2Core_MySQL.Support.SQLClassFilter.GetDefaultInstance<ORM_DOC_DocumentRevision>();
                comparator.Document_RefID = Parameter.Document_RefID;
                InstanceFilterWrapper comparatorWrap = InstanceFilterWrapper.Wrap(comparator, new string[] { "Document_RefID" });

                CSV2Core_MySQL.Support.SQLClassFilter.UpdateValue(Connection, Transaction, instanceWrap, comparatorWrap);

                #endregion setLastRevision

                ORM_DOC_DocumentRevision instance2 = CSV2Core_MySQL.Support.SQLClassFilter.GetDefaultInstance<ORM_DOC_DocumentRevision>();
                instance2.Document_RefID = Parameter.Document_RefID;
                InstanceFilterWrapper wrapper = InstanceFilterWrapper.Wrap(instance2);
                int count = CSV2Core_MySQL.Support.SQLClassFilter.Count(Connection, Transaction, wrapper);

                item.IsLastRevision = true;
                item.Revision = count + 1;
                item.Tenant_RefID = securityTicket.TenantID;
            }

            item.Document_RefID = Parameter.Document_RefID;
            //item.Revision = Parameter.Revision;
            item.IsLocked = Parameter.IsLocked;
            //item.IsLastRevision = Parameter.IsLastRevision;
            item.UploadedByAccount = securityTicket.AccountID;
            item.File_Name = Parameter.File_Name;
            item.File_Description = Parameter.File_Description;
            item.File_SourceLocation = Parameter.File_SourceLocation;
            item.File_ServerLocation = Parameter.File_ServerLocation;
            item.File_MIMEType = Parameter.File_MIMEType;
            item.File_Extension = Parameter.File_Extension;
            item.File_Size_Bytes = Parameter.File_Size_Bytes;


            return new FR_Guid(item.Save(Connection, Transaction), item.DOC_DocumentRevisionID);
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L3DO_SDR_1401 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3DO_SDR_1401 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3DO_SDR_1401 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3DO_SDR_1401 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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
		#region SClass P_L3DO_SDR_1401 for attribute P_L3DO_SDR_1401
		[DataContract]
		public class P_L3DO_SDR_1401 
		{
			//Standard type parameters
			[DataMember]
			public Guid DOC_DocumentRevisionID { get; set; } 
			[DataMember]
			public Guid Document_RefID { get; set; } 
			[DataMember]
			public int Revision { get; set; } 
			[DataMember]
			public Boolean IsLocked { get; set; } 
			[DataMember]
			public Boolean IsLastRevision { get; set; } 
			[DataMember]
			public Guid UploadedByAccount { get; set; } 
			[DataMember]
			public String File_Name { get; set; } 
			[DataMember]
			public String File_Description { get; set; } 
			[DataMember]
			public String File_SourceLocation { get; set; } 
			[DataMember]
			public String File_ServerLocation { get; set; } 
			[DataMember]
			public String File_MIMEType { get; set; } 
			[DataMember]
			public String File_Extension { get; set; } 
			[DataMember]
			public long File_Size_Bytes { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}
