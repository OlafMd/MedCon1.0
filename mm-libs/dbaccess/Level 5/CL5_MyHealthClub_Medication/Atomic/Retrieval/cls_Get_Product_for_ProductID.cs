/* 
 * Generated on 9/24/2014 4:14:07 PM
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
	public class cls_Get_Product_for_ProductID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5ME_GPfPID_1602 Execute(DbConnection Connection,DbTransaction Transaction,P_L5ME_GPfPID_1602 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5ME_GPfPID_1602();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_Medication.Atomic.Retrieval.SQL.cls_Get_Product_for_ProductID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ProductID", Parameter.ProductID);


			List<L5ME_GPfPID_1602_raw> results = new List<L5ME_GPfPID_1602_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "Product_Name_DictID","HEC_ProductID","DosageForm_Name_DictID","Manufacturer","Strength_Name","Strength_Units","HEC_SUB_SubstanceID","SubstanceName_Label_DictID" });
				while(reader.Read())
				{
					L5ME_GPfPID_1602_raw resultItem = new L5ME_GPfPID_1602_raw();
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

			returnStatus.Result = L5ME_GPfPID_1602_raw.Convert(results).FirstOrDefault();

			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5ME_GPfPID_1602 Invoke(string ConnectionString,P_L5ME_GPfPID_1602 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5ME_GPfPID_1602 Invoke(DbConnection Connection,P_L5ME_GPfPID_1602 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5ME_GPfPID_1602 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5ME_GPfPID_1602 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5ME_GPfPID_1602 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5ME_GPfPID_1602 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5ME_GPfPID_1602 functionReturn = new FR_L5ME_GPfPID_1602();
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
	public class L5ME_GPfPID_1602_raw 
	{
		public Dict Product_Name; 
		public Guid HEC_ProductID; 
		public Dict DosageForm_Name; 
		public String Manufacturer; 
		public String Strength_Name; 
		public String Strength_Units; 
		public Guid HEC_SUB_SubstanceID; 
		public Dict SubstanceName_Label; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5ME_GPfPID_1602[] Convert(List<L5ME_GPfPID_1602_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5ME_GPfPID_1602 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.HEC_ProductID)).ToArray()
	group el_L5ME_GPfPID_1602 by new 
	{ 
		el_L5ME_GPfPID_1602.HEC_ProductID,

	}
	into gfunct_L5ME_GPfPID_1602
	select new L5ME_GPfPID_1602
	{     
		Product_Name = gfunct_L5ME_GPfPID_1602.FirstOrDefault().Product_Name ,
		HEC_ProductID = gfunct_L5ME_GPfPID_1602.Key.HEC_ProductID ,
		DosageForm_Name = gfunct_L5ME_GPfPID_1602.FirstOrDefault().DosageForm_Name ,
		Manufacturer = gfunct_L5ME_GPfPID_1602.FirstOrDefault().Manufacturer ,
		Strength_Name = gfunct_L5ME_GPfPID_1602.FirstOrDefault().Strength_Name ,
		Strength_Units = gfunct_L5ME_GPfPID_1602.FirstOrDefault().Strength_Units ,

		Supstances = 
		(
			from el_Supstances in gfunct_L5ME_GPfPID_1602.Where(element => !EqualsDefaultValue(element.HEC_SUB_SubstanceID)).ToArray()
			group el_Supstances by new 
			{ 
				el_Supstances.HEC_SUB_SubstanceID,

			}
			into gfunct_Supstances
			select new L5ME_GAPaASfLID_1205_Supstances
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
	public class FR_L5ME_GPfPID_1602 : FR_Base
	{
		public L5ME_GPfPID_1602 Result	{ get; set; }

		public FR_L5ME_GPfPID_1602() : base() {}

		public FR_L5ME_GPfPID_1602(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5ME_GPfPID_1602 for attribute P_L5ME_GPfPID_1602
		[Serializable]
		public class P_L5ME_GPfPID_1602 
		{
			//Standard type parameters
			public Guid ProductID; 

		}
		#endregion
		#region SClass L5ME_GPfPID_1602 for attribute L5ME_GPfPID_1602
		[Serializable]
		public class L5ME_GPfPID_1602 
		{
			public L5ME_GAPaASfLID_1205_Supstances[] Supstances;  

			//Standard type parameters
			public Dict Product_Name; 
			public Guid HEC_ProductID; 
			public Dict DosageForm_Name; 
			public String Manufacturer; 
			public String Strength_Name; 
			public String Strength_Units; 

		}
		#endregion
		#region SClass L5ME_GAPaASfLID_1205_Supstances for attribute Supstances
		[Serializable]
		public class L5ME_GAPaASfLID_1205_Supstances 
		{
			//Standard type parameters
			public Guid HEC_SUB_SubstanceID; 
			public Dict SubstanceName_Label; 

		}
		#endregion

	#endregion
}
