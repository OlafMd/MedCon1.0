/* 
 * Generated on 3/13/2014 1:26:21 PM
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
using CL1_HEC_PRO;
using CL2_Language.Atomic.Retrieval;
using CL1_HEC_SUB;

namespace CL3_Components.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Componets_for_ImportedProductFromCatalog.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Componets_for_ImportedProductFromCatalog
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3CO_SCfIPFC_1324 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();

            #region All tenant's languages

            var allTenantLanguages = cls_Get_All_Languages.Invoke(Connection, Transaction, securityTicket).Result.ToList();

            #endregion

            #region Delete Previous Components

            ORM_HEC_PRO_Product_Component.Query.SoftDelete(Connection, Transaction, new ORM_HEC_PRO_Product_Component.Query()
            {
                HEC_PRO_Product_RefID = Parameter.HEC_ProductID,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            });

            #endregion

            foreach (var componentFromCatalog in Parameter.ActiveComponents)
            {
                var component = new ORM_HEC_PRO_Component();
                component.HEC_PRO_ComponentID = Guid.NewGuid();
                component.Component_SimpleName = componentFromCatalog.ComponentName;
                component.Component_Name = new Dict(ORM_HEC_PRO_Component.TableName);
                foreach (var item in allTenantLanguages) {
                    component.Component_Name.AddEntry(item.CMN_LanguageID, componentFromCatalog.ComponentName);
                }
                component.Creation_Timestamp = DateTime.Now;
                component.Tenant_RefID = securityTicket.TenantID;
                component.Save(Connection, Transaction);

                var productComponents = new ORM_HEC_PRO_Product_Component();
                productComponents.HEC_PRO_Product_ComponentID = Guid.NewGuid();
                productComponents.HEC_PRO_Component_RefID = component.HEC_PRO_ComponentID;
                productComponents.HEC_PRO_Product_RefID = Parameter.HEC_ProductID;
                productComponents.Creation_Timestamp = DateTime.Now;
                productComponents.Tenant_RefID = securityTicket.TenantID;
                productComponents.Save(Connection, Transaction);


                foreach (var substanceFromCatalog in componentFromCatalog.Substances)
                {
                    var substance = ORM_HEC_SUB_Substance.Query.Search(Connection, Transaction,
                        new ORM_HEC_SUB_Substance.Query()
                        {
                            GlobalPropertyMatchingID = substanceFromCatalog.Name,
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false
                        }).SingleOrDefault();

                    if (substance == default(ORM_HEC_SUB_Substance)) {

                        substance = new ORM_HEC_SUB_Substance();
                        substance.HEC_SUB_SubstanceID = Guid.NewGuid();
                        substance.GlobalPropertyMatchingID = substanceFromCatalog.Name;
                        substance.IsActiveComponent = substanceFromCatalog.IsActive;
                        substance.Creation_Timestamp = DateTime.Now;
                        substance.Tenant_RefID = securityTicket.TenantID;
                        substance.Save(Connection, Transaction);

                        var substanceName = new ORM_HEC_SUB_Substance_Name();
                        substanceName.HEC_SUB_Substance_NameID = Guid.NewGuid();
                        substanceName.HEC_SUB_Substance_RefID = substance.HEC_SUB_SubstanceID;
                        substanceName.SubstanceName_Label = new Dict(ORM_HEC_PRO_Component.TableName);
                        foreach (var item in allTenantLanguages)
                        {
                            substanceName.SubstanceName_Label.AddEntry(item.CMN_LanguageID, substanceFromCatalog.Name);
                        }
                        substanceName.SubstanceName_Origin = new Dict(ORM_HEC_PRO_Component.TableName);
                        substanceName.Creation_Timestamp = DateTime.Now;
                        substanceName.Tenant_RefID = securityTicket.TenantID;
                        substanceName.Save(Connection, Transaction);
                    }

                    var substanceIngredient = new ORM_HEC_PRO_Component_SubstanceIngredient();
                    substanceIngredient.HEC_PRO_Component_SubstanceIngredientID = Guid.NewGuid();
                    substanceIngredient.Component_RefID = component.HEC_PRO_ComponentID;
                    substanceIngredient.Substance_RefID = substance.HEC_SUB_SubstanceID;
                    substanceIngredient.Creation_Timestamp = DateTime.Now;
                    substanceIngredient.Tenant_RefID = securityTicket.TenantID;
                    substanceIngredient.Save(Connection, Transaction);

                }

            
            }
            
            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L3CO_SCfIPFC_1324 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3CO_SCfIPFC_1324 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3CO_SCfIPFC_1324 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3CO_SCfIPFC_1324 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Componets_for_ImportedProductFromCatalog",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3CO_SCfIPFC_1324 for attribute P_L3CO_SCfIPFC_1324
		[DataContract]
		public class P_L3CO_SCfIPFC_1324 
		{
			[DataMember]
			public P_L3CO_SCfIPFC_1324_Component[] ActiveComponents { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid HEC_ProductID { get; set; } 

		}
		#endregion
		#region SClass P_L3CO_SCfIPFC_1324_Component for attribute ActiveComponents
		[DataContract]
		public class P_L3CO_SCfIPFC_1324_Component 
		{
			[DataMember]
			public P_L3CO_SCfIPFC_1324_Substance[] Substances { get; set; }

			//Standard type parameters
			[DataMember]
			public String ComponentName { get; set; } 

		}
		#endregion
		#region SClass P_L3CO_SCfIPFC_1324_Substance for attribute Substances
		[DataContract]
		public class P_L3CO_SCfIPFC_1324_Substance 
		{
			//Standard type parameters
			[DataMember]
			public Boolean IsActive { get; set; } 
			[DataMember]
			public String Name { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Componets_for_ImportedProductFromCatalog(,P_L3CO_SCfIPFC_1324 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Componets_for_ImportedProductFromCatalog.Invoke(connectionString,P_L3CO_SCfIPFC_1324 Parameter,securityTicket);
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
var parameter = new CL3_Components.Complex.Manipulation.P_L3CO_SCfIPFC_1324();
parameter.ActiveComponents = ...;

parameter.HEC_ProductID = ...;

*/
