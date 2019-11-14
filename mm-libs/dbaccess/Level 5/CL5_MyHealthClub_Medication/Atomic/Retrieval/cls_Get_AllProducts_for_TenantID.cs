/* 
 * Generated on 9/23/2014 4:16:43 PM
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
	public class cls_Get_AllProducts_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5ME_GAPfTID_1426_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5ME_GAPfTID_1426 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5ME_GAPfTID_1426_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_Medication.Atomic.Retrieval.SQL.cls_Get_AllProducts_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"OrderBy", Parameter.OrderBy);
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"OrderValue", Parameter.OrderValue);
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"StartIndex", Parameter.StartIndex);
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"NumberOfElements", Parameter.NumberOfElements);
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"SearchCriterium", Parameter.SearchCriterium);
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"LanguageID", Parameter.LanguageID);

            string newText = command.CommandText.Replace("@OrderValue", Parameter.OrderValue);
            command.CommandText = newText;

            /***For Search**/
            string newText2 = command.CommandText.Replace("@SearchCriterium", Parameter.SearchCriterium);
            command.CommandText = newText2;

			List<L5ME_GAPfTID_1426_raw> results = new List<L5ME_GAPfTID_1426_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "Product_Name_DictID","DosageForm_Name_DictID","Manufacturer","Strength_Name","Strength_Units","HEC_ProductID","HEC_SUB_SubstanceID","SubstanceName_Label_DictID" });
				while(reader.Read())
				{
					L5ME_GAPfTID_1426_raw resultItem = new L5ME_GAPfTID_1426_raw();
					//0:Parameter Product_Name of type Dict
					resultItem.Product_Name = reader.GetDictionary(0);
					resultItem.Product_Name.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Product_Name);
					//1:Parameter DosageForm_Name of type Dict
					resultItem.DosageForm_Name = reader.GetDictionary(1);
					resultItem.DosageForm_Name.SourceTable = "hec_product_dosageforms";
					loader.Append(resultItem.DosageForm_Name);
					//2:Parameter Manufacturer of type String
					resultItem.Manufacturer = reader.GetString(2);
					//3:Parameter Strength_Name of type String
					resultItem.Strength_Name = reader.GetString(3);
					//4:Parameter Strength_Units of type String
					resultItem.Strength_Units = reader.GetString(4);
					//5:Parameter HEC_ProductID of type Guid
					resultItem.HEC_ProductID = reader.GetGuid(5);
					//6:Parameter HEC_SUB_SubstanceID of type Guid
					resultItem.HEC_SUB_SubstanceID = reader.GetGuid(6);
					//7:Parameter SubstanceName_Label of type Dict
					resultItem.SubstanceName_Label = reader.GetDictionary(7);
					resultItem.SubstanceName_Label.SourceTable = "hec_sub_substance_names";
					loader.Append(resultItem.SubstanceName_Label);

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

			returnStatus.Result = L5ME_GAPfTID_1426_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5ME_GAPfTID_1426_Array Invoke(string ConnectionString,P_L5ME_GAPfTID_1426 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5ME_GAPfTID_1426_Array Invoke(DbConnection Connection,P_L5ME_GAPfTID_1426 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5ME_GAPfTID_1426_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5ME_GAPfTID_1426 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5ME_GAPfTID_1426_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5ME_GAPfTID_1426 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5ME_GAPfTID_1426_Array functionReturn = new FR_L5ME_GAPfTID_1426_Array();
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

	#region Raw Grouping Class
	[Serializable]
	public class L5ME_GAPfTID_1426_raw 
	{
		public Dict Product_Name; 
		public Dict DosageForm_Name; 
		public String Manufacturer; 
		public String Strength_Name; 
		public String Strength_Units; 
		public Guid HEC_ProductID; 
		public Guid HEC_SUB_SubstanceID; 
		public Dict SubstanceName_Label; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5ME_GAPfTID_1426[] Convert(List<L5ME_GAPfTID_1426_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5ME_GAPfTID_1426 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.HEC_ProductID)).ToArray()
	group el_L5ME_GAPfTID_1426 by new 
	{ 
		el_L5ME_GAPfTID_1426.HEC_ProductID,

	}
	into gfunct_L5ME_GAPfTID_1426
	select new L5ME_GAPfTID_1426
	{     
		Product_Name = gfunct_L5ME_GAPfTID_1426.FirstOrDefault().Product_Name ,
		DosageForm_Name = gfunct_L5ME_GAPfTID_1426.FirstOrDefault().DosageForm_Name ,
		Manufacturer = gfunct_L5ME_GAPfTID_1426.FirstOrDefault().Manufacturer ,
		Strength_Name = gfunct_L5ME_GAPfTID_1426.FirstOrDefault().Strength_Name ,
		Strength_Units = gfunct_L5ME_GAPfTID_1426.FirstOrDefault().Strength_Units ,
		HEC_ProductID = gfunct_L5ME_GAPfTID_1426.Key.HEC_ProductID ,

		Supstances = 
		(
			from el_Supstances in gfunct_L5ME_GAPfTID_1426.Where(element => !EqualsDefaultValue(element.HEC_SUB_SubstanceID)).ToArray()
			group el_Supstances by new 
			{ 
				el_Supstances.HEC_SUB_SubstanceID,

			}
			into gfunct_Supstances
			select new L5ME_GAPfTID_1426_Supstances
			{     
				HEC_SUB_SubstanceID = gfunct_Supstances.Key.HEC_SUB_SubstanceID ,
				SubstanceName_Label = gfunct_Supstances.FirstOrDefault().SubstanceName_Label ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5ME_GAPfTID_1426_Array : FR_Base
	{
		public L5ME_GAPfTID_1426[] Result	{ get; set; } 
		public FR_L5ME_GAPfTID_1426_Array() : base() {}

		public FR_L5ME_GAPfTID_1426_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5ME_GAPfTID_1426 for attribute P_L5ME_GAPfTID_1426
		[Serializable]
		public class P_L5ME_GAPfTID_1426 
		{
			//Standard type parameters
			public String OrderBy; 
			public String OrderValue; 
			public int StartIndex; 
			public int NumberOfElements; 
			public String SearchCriterium; 
			public Guid LanguageID; 

		}
		#endregion
		#region SClass L5ME_GAPfTID_1426 for attribute L5ME_GAPfTID_1426
		[Serializable]
		public class L5ME_GAPfTID_1426 
		{
			public L5ME_GAPfTID_1426_Supstances[] Supstances;  

			//Standard type parameters
			public Dict Product_Name; 
			public Dict DosageForm_Name; 
			public String Manufacturer; 
			public String Strength_Name; 
			public String Strength_Units; 
			public Guid HEC_ProductID; 

		}
		#endregion
		#region SClass L5ME_GAPfTID_1426_Supstances for attribute Supstances
		[Serializable]
		public class L5ME_GAPfTID_1426_Supstances 
		{
			//Standard type parameters
			public Guid HEC_SUB_SubstanceID; 
			public Dict SubstanceName_Label; 

		}
		#endregion

	#endregion
}
