/* 
 * Generated on 10/15/2014 7:29:47 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Linq;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL5_MyHealthClub_Medication.Atomic.Retrieval
{
	[Serializable]
	public class cls_Get_Products_for_Import
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_LME_GPFI_1902_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_LME_GPFI_1902_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_Medication.Atomic.Retrieval.SQL.cls_Get_Products_for_Import.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;
			List<LME_GPFI_1902> results = new List<LME_GPFI_1902>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "Product_Name_DictID","HEC_ProductID","DosageForm_Name_DictID","Manufacturer","Strength_Name","Strength_Units","PackageContent_DisplayLabel","SubstanceName_Label_DictID","HEC_SUB_SubstanceID" });
				while(reader.Read())
				{
					LME_GPFI_1902 resultItem = new LME_GPFI_1902();
					//0:Parameter Product_Name of type Dict
					resultItem.Product_Name = reader.GetDictionary(0);
					resultItem.Product_Name.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Product_Name);
					//1:Parameter HEC_ProductID of type Guid
					resultItem.HEC_ProductID = reader.GetGuid(1);
					//2:Parameter DosageForm_Name of type Dict
					resultItem.DosageForm_Name = reader.GetDictionary(2);
					resultItem.DosageForm_Name.SourceTable = "hec_product_dosageforms";
					loader.Append(resultItem.DosageForm_Name);
					//3:Parameter Manufacturer of type String
					resultItem.Manufacturer = reader.GetString(3);
					//4:Parameter Strength_Name of type String
					resultItem.Strength_Name = reader.GetString(4);
					//5:Parameter Strength_Units of type String
					resultItem.Strength_Units = reader.GetString(5);
					//6:Parameter PackageContent_DisplayLabel of type String
					resultItem.PackageContent_DisplayLabel = reader.GetString(6);
					//7:Parameter SubstanceName_Label of type Dict
					resultItem.SubstanceName_Label = reader.GetDictionary(7);
					resultItem.SubstanceName_Label.SourceTable = "hec_sub_substance_names";
					loader.Append(resultItem.SubstanceName_Label);
					//8:Parameter HEC_SUB_SubstanceID of type Guid
					resultItem.HEC_SUB_SubstanceID = reader.GetGuid(8);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw ex;
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = results.ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_LME_GPFI_1902_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_LME_GPFI_1902_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_LME_GPFI_1902_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_LME_GPFI_1902_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_LME_GPFI_1902_Array functionReturn = new FR_LME_GPFI_1902_Array();
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

				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_LME_GPFI_1902_Array : FR_Base
	{
		public LME_GPFI_1902[] Result	{ get; set; } 
		public FR_LME_GPFI_1902_Array() : base() {}

		public FR_LME_GPFI_1902_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass LME_GPFI_1902 for attribute LME_GPFI_1902
		[Serializable]
		public class LME_GPFI_1902 
		{
			//Standard type parameters
			public Dict Product_Name; 
			public Guid HEC_ProductID; 
			public Dict DosageForm_Name; 
			public String Manufacturer; 
			public String Strength_Name; 
			public String Strength_Units; 
			public String PackageContent_DisplayLabel; 
			public Dict SubstanceName_Label; 
			public Guid HEC_SUB_SubstanceID; 

		}
		#endregion

	#endregion
}
