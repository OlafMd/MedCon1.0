/* 
 * Generated on 2/19/2015 10:18:59 PM
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
using CL1_CMN_PRO_CUS;

namespace CL2_Customization.Complex.Retrieval
{
	/// <summary>
    /// Get_Customization_Template_with_Variants_for_ID
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Customization_Template_with_Variants_for_ID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Customization_Template_with_Variants_for_ID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2CT_GCTwVfID_1536 Execute(DbConnection Connection,DbTransaction Transaction,P_L2CT_GCTwVfID_1536 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
            //Put your code here

            var returnValue = new FR_L2CT_GCTwVfID_1536();
            returnValue.Result = new L2CT_GCTwVfID_1536();

            var customizationTemplateID = Parameter.CustomizationTemplateID;

            ORM_CMN_PRO_CUS_Customization_Template customizationTemplate = new ORM_CMN_PRO_CUS_Customization_Template();
            customizationTemplate.Load(Connection, Transaction, customizationTemplateID);

            ORM_CMN_PRO_CUS_Customization_Variant_Template.Query variantTemplates = new ORM_CMN_PRO_CUS_Customization_Variant_Template.Query();
            variantTemplates.Customization_Template_RefID = customizationTemplate.CMN_PRO_CUS_Customization_TemplateID;
            variantTemplates.Tenant_RefID = securityTicket.TenantID;
            variantTemplates.IsDeleted = false;

            var listOfTemplateVariants = ORM_CMN_PRO_CUS_Customization_Variant_Template.Query.Search(Connection, Transaction, variantTemplates);

            if (listOfTemplateVariants != null && listOfTemplateVariants.Count > 0)
            {
                listOfTemplateVariants.OrderBy(x => x.OrderSequence);
            }

            returnValue.Result.CustomizationTemplate = customizationTemplate;
            returnValue.Result.CustomizationVariants = listOfTemplateVariants.ToArray();

            return returnValue;

			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L2CT_GCTwVfID_1536 Invoke(string ConnectionString,P_L2CT_GCTwVfID_1536 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2CT_GCTwVfID_1536 Invoke(DbConnection Connection,P_L2CT_GCTwVfID_1536 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2CT_GCTwVfID_1536 Invoke(DbConnection Connection, DbTransaction Transaction,P_L2CT_GCTwVfID_1536 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2CT_GCTwVfID_1536 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2CT_GCTwVfID_1536 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2CT_GCTwVfID_1536 functionReturn = new FR_L2CT_GCTwVfID_1536();
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

				throw new Exception("Exception occured in method cls_Get_Customization_Template_with_Variants_for_ID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2CT_GCTwVfID_1536 : FR_Base
	{
		public L2CT_GCTwVfID_1536 Result	{ get; set; }

		public FR_L2CT_GCTwVfID_1536() : base() {}

		public FR_L2CT_GCTwVfID_1536(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L2CT_GCTwVfID_1536 for attribute P_L2CT_GCTwVfID_1536
		[DataContract]
		public class P_L2CT_GCTwVfID_1536 
		{
			//Standard type parameters
			[DataMember]
			public Guid CustomizationTemplateID { get; set; } 

		}
		#endregion
		#region SClass L2CT_GCTwVfID_1536 for attribute L2CT_GCTwVfID_1536
		[DataContract]
		public class L2CT_GCTwVfID_1536 
		{
			//Standard type parameters
			[DataMember]
			public ORM_CMN_PRO_CUS_Customization_Template CustomizationTemplate { get; set; } 
			[DataMember]
			public ORM_CMN_PRO_CUS_Customization_Variant_Template[] CustomizationVariants { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2CT_GCTwVfID_1536 cls_Get_Customization_Template_with_Variants_for_ID(,P_L2CT_GCTwVfID_1536 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2CT_GCTwVfID_1536 invocationResult = cls_Get_Customization_Template_with_Variants_for_ID.Invoke(connectionString,P_L2CT_GCTwVfID_1536 Parameter,securityTicket);
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
var parameter = new CL2_Customization.Complex.Retrieval.P_L2CT_GCTwVfID_1536();
parameter.CustomizationTemplateID = ...;

*/
