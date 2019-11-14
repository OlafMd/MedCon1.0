/* 
 * Generated on 2/19/2015 03:08:57
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
using CL1_CMN_PRO;
using CL1_CMN;

namespace CL3_Dimension.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_DimensionTemplate.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_DimensionTemplate
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3D_SDT_1335 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
			
            var defaultLanguages = ORM_CMN_Language.Query.Search(Connection, Transaction, new ORM_CMN_Language.Query
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID
            });
            ORM_CMN_PRO_Dimension dimension = new ORM_CMN_PRO_Dimension();
            dimension.Load(Connection,Transaction,Parameter.CMN_PRO_DimensionID);

                if(dimension.CMN_PRO_DimensionID==null || dimension.CMN_PRO_DimensionID==Guid.Empty)
                    dimension.CMN_PRO_DimensionID=Parameter.CMN_PRO_DimensionID;

                dimension.DimensionName = new Dict(ORM_CMN_PRO_Dimension.TableName);
                dimension.IsDeleted = false;
                dimension.IsDimensionTemplate = true;
                dimension.Tenant_RefID = securityTicket.TenantID;
                dimension.Save(Connection, Transaction);
                foreach (var lang in defaultLanguages)
                {
                    dimension.DimensionName.AddEntry(lang.CMN_LanguageID, Parameter.DimensionName);
                   
                }

              var status=  dimension.Save(Connection, Transaction);
                foreach (var dimensionValue in Parameter.DimensionValue)
                {
                    ORM_CMN_PRO_Dimension_Value orm_dimensionValue = new ORM_CMN_PRO_Dimension_Value();
                    orm_dimensionValue.Load(Connection, Transaction, dimensionValue.CMN_PRO_Dimension_ValueID);

                    if (orm_dimensionValue == null || orm_dimensionValue.CMN_PRO_Dimension_ValueID == Guid.Empty)
                        orm_dimensionValue.CMN_PRO_Dimension_ValueID = dimensionValue.CMN_PRO_Dimension_ValueID;

                    orm_dimensionValue.Dimensions_RefID = dimension.CMN_PRO_DimensionID;
                    orm_dimensionValue.DimensionValue_Text = new Dict(ORM_CMN_PRO_Dimension.TableName);
                    orm_dimensionValue.OrderSequence = dimensionValue.OrderSequence;
                    orm_dimensionValue.IsDeleted = dimensionValue.IsDeleted;
                    orm_dimensionValue.Tenant_RefID = securityTicket.TenantID;
                    orm_dimensionValue.Save(Connection, Transaction);
                    foreach (var lang in defaultLanguages)
                    {
                        orm_dimensionValue.DimensionValue_Text.AddEntry(lang.CMN_LanguageID, dimensionValue.DimensionValue_Text);

                    }
                status= orm_dimensionValue.Save(Connection, Transaction);
                }
            if(status.Status==FR_Status.Success)
            { returnValue.Result = dimension.CMN_PRO_DimensionID; }
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L3D_SDT_1335 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3D_SDT_1335 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3D_SDT_1335 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3D_SDT_1335 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_DimensionTemplate",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3D_SDT_1335 for attribute P_L3D_SDT_1335
		[DataContract]
		public class P_L3D_SDT_1335 
		{
			[DataMember]
			public P_L3D_SDT_1335v[] DimensionValue { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_DimensionID { get; set; } 
			[DataMember]
			public string DimensionName { get; set; } 

		}
		#endregion
		#region SClass P_L3D_SDT_1335v for attribute DimensionValue
		[DataContract]
		public class P_L3D_SDT_1335v 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_Dimension_ValueID { get; set; } 
			[DataMember]
			public string DimensionValue_Text { get; set; } 
			[DataMember]
			public int OrderSequence { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_DimensionTemplate(,P_L3D_SDT_1335 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_DimensionTemplate.Invoke(connectionString,P_L3D_SDT_1335 Parameter,securityTicket);
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
var parameter = new CL3_Dimension.Atomic.Manipulation.P_L3D_SDT_1335();
parameter.DimensionValue = ...;

parameter.CMN_PRO_DimensionID = ...;
parameter.DimensionName = ...;

*/
