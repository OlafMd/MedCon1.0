/* 
 * Generated on 2/22/2015 22:57:38
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

namespace CL3_ProductCustomization.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_CustomizationTemplates_with_Variants.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_CustomizationTemplates_with_Variants
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3PC_GCTwV_1212_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3PC_GCTwV_1212_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_ProductCustomization.Atomic.Retrieval.SQL.cls_Get_CustomizationTemplates_with_Variants.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L3PC_GCTwV_1212_raw> results = new List<L3PC_GCTwV_1212_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_PRO_CUS_Customization_TemplateID","CustomizationTemplate_Name_DictID","CustomizationTemplate_Description_DictID","CMN_PRO_CUS_Customization_Variant_TemplateID","CustomizationVariantTemplate_Name_DictID","OrderSequence" });
				while(reader.Read())
				{
					L3PC_GCTwV_1212_raw resultItem = new L3PC_GCTwV_1212_raw();
					//0:Parameter CMN_PRO_CUS_Customization_TemplateID of type Guid
					resultItem.CMN_PRO_CUS_Customization_TemplateID = reader.GetGuid(0);
					//1:Parameter CustomizationTemplate_Name of type Dict
					resultItem.CustomizationTemplate_Name = reader.GetDictionary(1);
					resultItem.CustomizationTemplate_Name.SourceTable = "cmn_pro_cus_customization_templates";
					loader.Append(resultItem.CustomizationTemplate_Name);
					//2:Parameter CustomizationTemplate_Description of type Dict
					resultItem.CustomizationTemplate_Description = reader.GetDictionary(2);
					resultItem.CustomizationTemplate_Description.SourceTable = "cmn_pro_cus_customization_templates";
					loader.Append(resultItem.CustomizationTemplate_Description);
					//3:Parameter CMN_PRO_CUS_Customization_Variant_TemplateID of type Guid
					resultItem.CMN_PRO_CUS_Customization_Variant_TemplateID = reader.GetGuid(3);
					//4:Parameter CustomizationVariantTemplate_Name of type Dict
					resultItem.CustomizationVariantTemplate_Name = reader.GetDictionary(4);
					resultItem.CustomizationVariantTemplate_Name.SourceTable = "cmn_pro_cus_customization_variant_templates";
					loader.Append(resultItem.CustomizationVariantTemplate_Name);
					//5:Parameter OrderSequence of type int
					resultItem.OrderSequence = reader.GetInteger(5);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_CustomizationTemplates_with_Variants",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L3PC_GCTwV_1212_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3PC_GCTwV_1212_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3PC_GCTwV_1212_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3PC_GCTwV_1212_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3PC_GCTwV_1212_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3PC_GCTwV_1212_Array functionReturn = new FR_L3PC_GCTwV_1212_Array();
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

				throw new Exception("Exception occured in method cls_Get_CustomizationTemplates_with_Variants",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L3PC_GCTwV_1212_raw 
	{
		public Guid CMN_PRO_CUS_Customization_TemplateID; 
		public Dict CustomizationTemplate_Name; 
		public Dict CustomizationTemplate_Description; 
		public Guid CMN_PRO_CUS_Customization_Variant_TemplateID; 
		public Dict CustomizationVariantTemplate_Name; 
		public int OrderSequence; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L3PC_GCTwV_1212[] Convert(List<L3PC_GCTwV_1212_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L3PC_GCTwV_1212 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.CMN_PRO_CUS_Customization_TemplateID)).ToArray()
	group el_L3PC_GCTwV_1212 by new 
	{ 
		el_L3PC_GCTwV_1212.CMN_PRO_CUS_Customization_TemplateID,

	}
	into gfunct_L3PC_GCTwV_1212
	select new L3PC_GCTwV_1212
	{     
		CMN_PRO_CUS_Customization_TemplateID = gfunct_L3PC_GCTwV_1212.Key.CMN_PRO_CUS_Customization_TemplateID ,
		CustomizationTemplate_Name = gfunct_L3PC_GCTwV_1212.FirstOrDefault().CustomizationTemplate_Name ,
		CustomizationTemplate_Description = gfunct_L3PC_GCTwV_1212.FirstOrDefault().CustomizationTemplate_Description ,

		TemplateVariants = 
		(
			from el_TemplateVariants in gfunct_L3PC_GCTwV_1212.Where(element => !EqualsDefaultValue(element.CMN_PRO_CUS_Customization_Variant_TemplateID)).ToArray()
			group el_TemplateVariants by new 
			{ 
				el_TemplateVariants.CMN_PRO_CUS_Customization_Variant_TemplateID,

			}
			into gfunct_TemplateVariants
			select new L3PC_GCTwV_1212a
			{     
				CMN_PRO_CUS_Customization_Variant_TemplateID = gfunct_TemplateVariants.Key.CMN_PRO_CUS_Customization_Variant_TemplateID ,
				CustomizationVariantTemplate_Name = gfunct_TemplateVariants.FirstOrDefault().CustomizationVariantTemplate_Name ,
				OrderSequence = gfunct_TemplateVariants.FirstOrDefault().OrderSequence ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L3PC_GCTwV_1212_Array : FR_Base
	{
		public L3PC_GCTwV_1212[] Result	{ get; set; } 
		public FR_L3PC_GCTwV_1212_Array() : base() {}

		public FR_L3PC_GCTwV_1212_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L3PC_GCTwV_1212 for attribute L3PC_GCTwV_1212
		[DataContract]
		public class L3PC_GCTwV_1212 
		{
			[DataMember]
			public L3PC_GCTwV_1212a[] TemplateVariants { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_CUS_Customization_TemplateID { get; set; } 
			[DataMember]
			public Dict CustomizationTemplate_Name { get; set; } 
			[DataMember]
			public Dict CustomizationTemplate_Description { get; set; } 

		}
		#endregion
		#region SClass L3PC_GCTwV_1212a for attribute TemplateVariants
		[DataContract]
		public class L3PC_GCTwV_1212a 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_CUS_Customization_Variant_TemplateID { get; set; } 
			[DataMember]
			public Dict CustomizationVariantTemplate_Name { get; set; } 
			[DataMember]
			public int OrderSequence { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3PC_GCTwV_1212_Array cls_Get_CustomizationTemplates_with_Variants(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3PC_GCTwV_1212_Array invocationResult = cls_Get_CustomizationTemplates_with_Variants.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

