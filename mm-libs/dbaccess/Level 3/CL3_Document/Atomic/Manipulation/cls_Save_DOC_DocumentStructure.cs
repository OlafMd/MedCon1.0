/* 
 * Generated on 7/8/2013 11:02:39 AM
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

namespace CL3_Document.Atomic.Manipulation
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_DOC_DocumentStructure.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_DOC_DocumentStructure
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3DO_SDS_1103 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 

            var returnValue = new FR_Guid();

            var item = new ORM_DOC_Structure();
            item.Load(Connection, Transaction, Parameter.DOC_StructureID);

            if (Parameter.IsDeleted == true)
            {
                #region ORM_DOC_Structure_Query

                var ORM_DOC_Structure_Query = new ORM_DOC_Structure.Query();
                ORM_DOC_Structure_Query.Parent_RefID = Parameter.DOC_StructureID;

                var structureChildren =  ORM_DOC_Structure.Query.Search(Connection, Transaction, ORM_DOC_Structure_Query);

                foreach (var structChild in structureChildren)
                {

                    P_L3DO_SDS_1103 structParam = new P_L3DO_SDS_1103();
                    structParam.DOC_StructureID = structChild.DOC_StructureID;
                    structChild.IsDeleted = true;

                    cls_Save_DOC_DocumentStructure.Invoke(Connection, Transaction, structParam, securityTicket);
                }

                #endregion

                #region ORM_DOC_Document_2_Structure_Query

                var ORM_DOC_Document_2_Structure_Query = new ORM_DOC_Document_2_Structure.Query();
                ORM_DOC_Document_2_Structure_Query.Structure_RefID = Parameter.DOC_StructureID;

                var documentChildren = ORM_DOC_Document_2_Structure.Query.Search(Connection, Transaction, ORM_DOC_Document_2_Structure_Query);

                foreach (var documentChild in documentChildren)
                {

                    P_L3DO_SD_1409 documentParam = new P_L3DO_SD_1409();
                    documentParam.DOC_DocumentID = documentChild.Document_RefID;
                    documentChild.IsDeleted = true;

                    cls_Save_DOC_Document.Invoke(Connection, Transaction, documentParam, securityTicket);
                }


                #endregion

                item.IsDeleted = true;
                return new FR_Guid(item.Save(Connection, Transaction), item.DOC_StructureID);
            }

            if (Parameter.DOC_StructureID == Guid.Empty)
            {
                item.DOC_StructureID = Guid.NewGuid();
                item.Tenant_RefID = securityTicket.TenantID;
            }

            item.Label = Parameter.Label;
            item.Structure_Header_RefID = Parameter.Structure_Header_RefID;
            item.Parent_RefID = Parameter.Parent_RefID;


            return new FR_Guid(item.Save(Connection, Transaction), item.DOC_StructureID);

			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L3DO_SDS_1103 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3DO_SDS_1103 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3DO_SDS_1103 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3DO_SDS_1103 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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
		#region SClass P_L3DO_SDS_1103 for attribute P_L3DO_SDS_1103
		[DataContract]
		public class P_L3DO_SDS_1103 
		{
			//Standard type parameters
			[DataMember]
			public Guid DOC_StructureID { get; set; } 
			[DataMember]
			public String Label { get; set; } 
			[DataMember]
			public Guid Structure_Header_RefID { get; set; } 
			[DataMember]
			public Guid Parent_RefID { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}
