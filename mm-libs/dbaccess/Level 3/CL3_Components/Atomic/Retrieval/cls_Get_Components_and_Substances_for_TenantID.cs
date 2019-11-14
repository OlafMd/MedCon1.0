/* 
 * Generated on 3/14/2014 11:08:05 AM
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
using System.Runtime.Serialization;

namespace CL3_Components.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Components_and_Substances_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Components_and_Substances_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3CO_GCaSfT_1100_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3CO_GCaSfT_1100_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_Components.Atomic.Retrieval.SQL.cls_Get_Components_and_Substances_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L3CO_GCaSfT_1100_raw> results = new List<L3CO_GCaSfT_1100_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_PRO_Product_RefID","HEC_PRO_ComponentID","Component_SimpleName","HEC_SUB_SubstanceID","SubstanceName","IsActiveComponent" });
				while(reader.Read())
				{
					L3CO_GCaSfT_1100_raw resultItem = new L3CO_GCaSfT_1100_raw();
					//0:Parameter HEC_PRO_Product_RefID of type Guid
					resultItem.HEC_PRO_Product_RefID = reader.GetGuid(0);
					//1:Parameter HEC_PRO_ComponentID of type Guid
					resultItem.HEC_PRO_ComponentID = reader.GetGuid(1);
					//2:Parameter Component_SimpleName of type String
					resultItem.Component_SimpleName = reader.GetString(2);
					//3:Parameter HEC_SUB_SubstanceID of type Guid
					resultItem.HEC_SUB_SubstanceID = reader.GetGuid(3);
					//4:Parameter SubstanceName of type String
					resultItem.SubstanceName = reader.GetString(4);
					//5:Parameter IsActiveComponent of type bool
					resultItem.IsActiveComponent = reader.GetBoolean(5);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Components_and_Substances_for_TenantID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L3CO_GCaSfT_1100_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3CO_GCaSfT_1100_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3CO_GCaSfT_1100_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3CO_GCaSfT_1100_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3CO_GCaSfT_1100_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3CO_GCaSfT_1100_Array functionReturn = new FR_L3CO_GCaSfT_1100_Array();
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

				throw new Exception("Exception occured in method cls_Get_Components_and_Substances_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L3CO_GCaSfT_1100_raw 
	{
		public Guid HEC_PRO_Product_RefID; 
		public Guid HEC_PRO_ComponentID; 
		public String Component_SimpleName; 
		public Guid HEC_SUB_SubstanceID; 
		public String SubstanceName; 
		public bool IsActiveComponent; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L3CO_GCaSfT_1100[] Convert(List<L3CO_GCaSfT_1100_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L3CO_GCaSfT_1100 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.HEC_PRO_Product_RefID)).ToArray()
	group el_L3CO_GCaSfT_1100 by new 
	{ 
		el_L3CO_GCaSfT_1100.HEC_PRO_Product_RefID,

	}
	into gfunct_L3CO_GCaSfT_1100
	select new L3CO_GCaSfT_1100
	{     
		HEC_PRO_Product_RefID = gfunct_L3CO_GCaSfT_1100.Key.HEC_PRO_Product_RefID ,

		Components = 
		(
			from el_Components in gfunct_L3CO_GCaSfT_1100.Where(element => !EqualsDefaultValue(element.HEC_PRO_ComponentID)).ToArray()
			group el_Components by new 
			{ 
				el_Components.HEC_PRO_ComponentID,

			}
			into gfunct_Components
			select new L3CO_GCaSfT_1100_Component
			{     
				HEC_PRO_ComponentID = gfunct_Components.Key.HEC_PRO_ComponentID ,
				Component_SimpleName = gfunct_Components.FirstOrDefault().Component_SimpleName ,

				Substances = 
				(
					from el_Substances in gfunct_Components.Where(element => !EqualsDefaultValue(element.HEC_SUB_SubstanceID)).ToArray()
					group el_Substances by new 
					{ 
						el_Substances.HEC_SUB_SubstanceID,

					}
					into gfunct_Substances
					select new L3CO_GCaSfT_1100_Substance
					{     
						HEC_SUB_SubstanceID = gfunct_Substances.Key.HEC_SUB_SubstanceID ,
						SubstanceName = gfunct_Substances.FirstOrDefault().SubstanceName ,
						IsActiveComponent = gfunct_Substances.FirstOrDefault().IsActiveComponent ,

					}
				).ToArray(),

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L3CO_GCaSfT_1100_Array : FR_Base
	{
		public L3CO_GCaSfT_1100[] Result	{ get; set; } 
		public FR_L3CO_GCaSfT_1100_Array() : base() {}

		public FR_L3CO_GCaSfT_1100_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L3CO_GCaSfT_1100 for attribute L3CO_GCaSfT_1100
		[DataContract]
		public class L3CO_GCaSfT_1100 
		{
			[DataMember]
			public L3CO_GCaSfT_1100_Component[] Components { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid HEC_PRO_Product_RefID { get; set; } 

		}
		#endregion
		#region SClass L3CO_GCaSfT_1100_Component for attribute Components
		[DataContract]
		public class L3CO_GCaSfT_1100_Component 
		{
			[DataMember]
			public L3CO_GCaSfT_1100_Substance[] Substances { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid HEC_PRO_ComponentID { get; set; } 
			[DataMember]
			public String Component_SimpleName { get; set; } 

		}
		#endregion
		#region SClass L3CO_GCaSfT_1100_Substance for attribute Substances
		[DataContract]
		public class L3CO_GCaSfT_1100_Substance 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_SUB_SubstanceID { get; set; } 
			[DataMember]
			public String SubstanceName { get; set; } 
			[DataMember]
			public bool IsActiveComponent { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3CO_GCaSfT_1100_Array cls_Get_Components_and_Substances_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3CO_GCaSfT_1100_Array invocationResult = cls_Get_Components_and_Substances_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

