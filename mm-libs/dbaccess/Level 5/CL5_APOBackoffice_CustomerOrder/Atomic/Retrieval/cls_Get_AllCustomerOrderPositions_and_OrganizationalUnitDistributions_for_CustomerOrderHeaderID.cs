/* 
 * Generated on 4/14/2014 6:28:24 PM
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

namespace CL5_APOBackoffice_CustomerOrder.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_AllCustomerOrderPositions_and_OrganizationalUnitDistributions_for_CustomerOrderHeaderID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AllCustomerOrderPositions_and_OrganizationalUnitDistributions_for_CustomerOrderHeaderID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5CO_GACOPaOUDfCH_1623_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5CO_GACOPaOUDfCH_1623 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5CO_GACOPaOUDfCH_1623_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOBackoffice_CustomerOrder.Atomic.Retrieval.SQL.cls_Get_AllCustomerOrderPositions_and_OrganizationalUnitDistributions_for_CustomerOrderHeaderID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CustomerOrderHeaderID", Parameter.CustomerOrderHeaderID);



			List<L5CO_GACOPaOUDfCH_1623_raw> results = new List<L5CO_GACOPaOUDfCH_1623_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ORD_CUO_CustomerOrder_PositionID","CMN_PRO_Product_RefID","Position_Quantity","Position_ValuePerUnit","ORD_CUO_Position_CustomerOrganizationalUnitDistributionID","CMN_BPT_CTM_OrganizationalUnit_RefID","Quantity" });
				while(reader.Read())
				{
					L5CO_GACOPaOUDfCH_1623_raw resultItem = new L5CO_GACOPaOUDfCH_1623_raw();
					//0:Parameter ORD_CUO_CustomerOrder_PositionID of type Guid
					resultItem.ORD_CUO_CustomerOrder_PositionID = reader.GetGuid(0);
					//1:Parameter CMN_PRO_Product_RefID of type Guid
					resultItem.CMN_PRO_Product_RefID = reader.GetGuid(1);
					//2:Parameter Position_Quantity of type Double
					resultItem.Position_Quantity = reader.GetDouble(2);
					//3:Parameter Position_ValuePerUnit of type Decimal
					resultItem.Position_ValuePerUnit = reader.GetDecimal(3);
					//4:Parameter ORD_CUO_Position_CustomerOrganizationalUnitDistributionID of type Guid
					resultItem.ORD_CUO_Position_CustomerOrganizationalUnitDistributionID = reader.GetGuid(4);
					//5:Parameter CMN_BPT_CTM_OrganizationalUnit_RefID of type Guid
					resultItem.CMN_BPT_CTM_OrganizationalUnit_RefID = reader.GetGuid(5);
					//6:Parameter Quantity of type Double
					resultItem.Quantity = reader.GetDouble(6);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_AllCustomerOrderPositions_and_OrganizationalUnitDistributions_for_CustomerOrderHeaderID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5CO_GACOPaOUDfCH_1623_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5CO_GACOPaOUDfCH_1623_Array Invoke(string ConnectionString,P_L5CO_GACOPaOUDfCH_1623 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5CO_GACOPaOUDfCH_1623_Array Invoke(DbConnection Connection,P_L5CO_GACOPaOUDfCH_1623 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5CO_GACOPaOUDfCH_1623_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5CO_GACOPaOUDfCH_1623 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5CO_GACOPaOUDfCH_1623_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5CO_GACOPaOUDfCH_1623 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5CO_GACOPaOUDfCH_1623_Array functionReturn = new FR_L5CO_GACOPaOUDfCH_1623_Array();
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

				throw new Exception("Exception occured in method cls_Get_AllCustomerOrderPositions_and_OrganizationalUnitDistributions_for_CustomerOrderHeaderID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5CO_GACOPaOUDfCH_1623_raw 
	{
		public Guid ORD_CUO_CustomerOrder_PositionID; 
		public Guid CMN_PRO_Product_RefID; 
		public Double Position_Quantity; 
		public Decimal Position_ValuePerUnit; 
		public Guid ORD_CUO_Position_CustomerOrganizationalUnitDistributionID; 
		public Guid CMN_BPT_CTM_OrganizationalUnit_RefID; 
		public Double Quantity; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5CO_GACOPaOUDfCH_1623[] Convert(List<L5CO_GACOPaOUDfCH_1623_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5CO_GACOPaOUDfCH_1623 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.ORD_CUO_CustomerOrder_PositionID)).ToArray()
	group el_L5CO_GACOPaOUDfCH_1623 by new 
	{ 
		el_L5CO_GACOPaOUDfCH_1623.ORD_CUO_CustomerOrder_PositionID,

	}
	into gfunct_L5CO_GACOPaOUDfCH_1623
	select new L5CO_GACOPaOUDfCH_1623
	{     
		ORD_CUO_CustomerOrder_PositionID = gfunct_L5CO_GACOPaOUDfCH_1623.Key.ORD_CUO_CustomerOrder_PositionID ,
		CMN_PRO_Product_RefID = gfunct_L5CO_GACOPaOUDfCH_1623.FirstOrDefault().CMN_PRO_Product_RefID ,
		Position_Quantity = gfunct_L5CO_GACOPaOUDfCH_1623.FirstOrDefault().Position_Quantity ,
		Position_ValuePerUnit = gfunct_L5CO_GACOPaOUDfCH_1623.FirstOrDefault().Position_ValuePerUnit ,

		OrgUnitAssigments = 
		(
			from el_OrgUnitAssigments in gfunct_L5CO_GACOPaOUDfCH_1623.Where(element => !EqualsDefaultValue(element.ORD_CUO_Position_CustomerOrganizationalUnitDistributionID)).ToArray()
			group el_OrgUnitAssigments by new 
			{ 
				el_OrgUnitAssigments.ORD_CUO_Position_CustomerOrganizationalUnitDistributionID,

			}
			into gfunct_OrgUnitAssigments
			select new L5CO_GACOPaOUDfCH_1623a
			{     
				ORD_CUO_Position_CustomerOrganizationalUnitDistributionID = gfunct_OrgUnitAssigments.Key.ORD_CUO_Position_CustomerOrganizationalUnitDistributionID ,
				CMN_BPT_CTM_OrganizationalUnit_RefID = gfunct_OrgUnitAssigments.FirstOrDefault().CMN_BPT_CTM_OrganizationalUnit_RefID ,
				Quantity = gfunct_OrgUnitAssigments.FirstOrDefault().Quantity ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5CO_GACOPaOUDfCH_1623_Array : FR_Base
	{
		public L5CO_GACOPaOUDfCH_1623[] Result	{ get; set; } 
		public FR_L5CO_GACOPaOUDfCH_1623_Array() : base() {}

		public FR_L5CO_GACOPaOUDfCH_1623_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5CO_GACOPaOUDfCH_1623 for attribute P_L5CO_GACOPaOUDfCH_1623
		[DataContract]
		public class P_L5CO_GACOPaOUDfCH_1623 
		{
			//Standard type parameters
			[DataMember]
			public Guid CustomerOrderHeaderID { get; set; } 

		}
		#endregion
		#region SClass L5CO_GACOPaOUDfCH_1623 for attribute L5CO_GACOPaOUDfCH_1623
		[DataContract]
		public class L5CO_GACOPaOUDfCH_1623 
		{
			[DataMember]
			public L5CO_GACOPaOUDfCH_1623a[] OrgUnitAssigments { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid ORD_CUO_CustomerOrder_PositionID { get; set; } 
			[DataMember]
			public Guid CMN_PRO_Product_RefID { get; set; } 
			[DataMember]
			public Double Position_Quantity { get; set; } 
			[DataMember]
			public Decimal Position_ValuePerUnit { get; set; } 

		}
		#endregion
		#region SClass L5CO_GACOPaOUDfCH_1623a for attribute OrgUnitAssigments
		[DataContract]
		public class L5CO_GACOPaOUDfCH_1623a 
		{
			//Standard type parameters
			[DataMember]
			public Guid ORD_CUO_Position_CustomerOrganizationalUnitDistributionID { get; set; } 
			[DataMember]
			public Guid CMN_BPT_CTM_OrganizationalUnit_RefID { get; set; } 
			[DataMember]
			public Double Quantity { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5CO_GACOPaOUDfCH_1623_Array cls_Get_AllCustomerOrderPositions_and_OrganizationalUnitDistributions_for_CustomerOrderHeaderID(,P_L5CO_GACOPaOUDfCH_1623 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5CO_GACOPaOUDfCH_1623_Array invocationResult = cls_Get_AllCustomerOrderPositions_and_OrganizationalUnitDistributions_for_CustomerOrderHeaderID.Invoke(connectionString,P_L5CO_GACOPaOUDfCH_1623 Parameter,securityTicket);
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
var parameter = new CL5_APOBackoffice_CustomerOrder.Atomic.Retrieval.P_L5CO_GACOPaOUDfCH_1623();
parameter.CustomerOrderHeaderID = ...;

*/
