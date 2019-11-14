/* 
 * Generated on 2/4/2015 11:54:06 AM
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

namespace CL3_Dimension.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Dimension_Template_For_DimensionTemplateID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Dimension_Template_For_DimensionTemplateID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3DM_GDTFID_1607 Execute(DbConnection Connection,DbTransaction Transaction,P_L3DM_GDTFID_1607 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3DM_GDTFID_1607();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_Dimension.Atomic.Retrieval.SQL.cls_Get_Dimension_Template_For_DimensionTemplateID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"DimensionID", Parameter.DimensionID);



			List<L3DM_GDTFID_1607_raw> results = new List<L3DM_GDTFID_1607_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_PRO_DimensionID","Abbreviation","DimensionName_DictID","IsDimensionTemplate","CMN_PRO_Dimension_ValueID","Dimensions_RefID","DimensionValue_Text_DictID","OrderSequence" });
				while(reader.Read())
				{
					L3DM_GDTFID_1607_raw resultItem = new L3DM_GDTFID_1607_raw();
					//0:Parameter CMN_PRO_DimensionID of type Guid
					resultItem.CMN_PRO_DimensionID = reader.GetGuid(0);
					//1:Parameter Abbreviation of type string
					resultItem.Abbreviation = reader.GetString(1);
					//2:Parameter DimensionName of type Dict
					resultItem.DimensionName = reader.GetDictionary(2);
					resultItem.DimensionName.SourceTable = "cmn_pro_dimensions";
					loader.Append(resultItem.DimensionName);
					//3:Parameter IsDimensionTemplate of type bool
					resultItem.IsDimensionTemplate = reader.GetBoolean(3);
					//4:Parameter CMN_PRO_Dimension_ValueID of type Guid
					resultItem.CMN_PRO_Dimension_ValueID = reader.GetGuid(4);
					//5:Parameter Dimensions_RefID of type Guid
					resultItem.Dimensions_RefID = reader.GetGuid(5);
					//6:Parameter DimensionValue_Text of type Dict
					resultItem.DimensionValue_Text = reader.GetDictionary(6);
					resultItem.DimensionValue_Text.SourceTable = "cmn_pro_dimension_values";
					loader.Append(resultItem.DimensionValue_Text);
					//7:Parameter OrderSequence of type int
					resultItem.OrderSequence = reader.GetInteger(7);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Dimension_Template_For_DimensionTemplateID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L3DM_GDTFID_1607_raw.Convert(results).FirstOrDefault();

			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3DM_GDTFID_1607 Invoke(string ConnectionString,P_L3DM_GDTFID_1607 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3DM_GDTFID_1607 Invoke(DbConnection Connection,P_L3DM_GDTFID_1607 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3DM_GDTFID_1607 Invoke(DbConnection Connection, DbTransaction Transaction,P_L3DM_GDTFID_1607 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3DM_GDTFID_1607 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3DM_GDTFID_1607 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3DM_GDTFID_1607 functionReturn = new FR_L3DM_GDTFID_1607();
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

				throw new Exception("Exception occured in method cls_Get_Dimension_Template_For_DimensionTemplateID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L3DM_GDTFID_1607_raw 
	{
		public Guid CMN_PRO_DimensionID; 
		public string Abbreviation; 
		public Dict DimensionName; 
		public bool IsDimensionTemplate; 
		public Guid CMN_PRO_Dimension_ValueID; 
		public Guid Dimensions_RefID; 
		public Dict DimensionValue_Text; 
		public int OrderSequence; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L3DM_GDTFID_1607[] Convert(List<L3DM_GDTFID_1607_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L3DM_GDTFID_1607 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.CMN_PRO_DimensionID)).ToArray()
	group el_L3DM_GDTFID_1607 by new 
	{ 
		el_L3DM_GDTFID_1607.CMN_PRO_DimensionID,

	}
	into gfunct_L3DM_GDTFID_1607
	select new L3DM_GDTFID_1607
	{     
		CMN_PRO_DimensionID = gfunct_L3DM_GDTFID_1607.Key.CMN_PRO_DimensionID ,
		Abbreviation = gfunct_L3DM_GDTFID_1607.FirstOrDefault().Abbreviation ,
		DimensionName = gfunct_L3DM_GDTFID_1607.FirstOrDefault().DimensionName ,
		IsDimensionTemplate = gfunct_L3DM_GDTFID_1607.FirstOrDefault().IsDimensionTemplate ,

		DimensionValue = 
		(
			from el_DimensionValue in gfunct_L3DM_GDTFID_1607.Where(element => !EqualsDefaultValue(element.CMN_PRO_Dimension_ValueID)).ToArray()
			group el_DimensionValue by new 
			{ 
				el_DimensionValue.CMN_PRO_Dimension_ValueID,

			}
			into gfunct_DimensionValue
			select new L3DM_GDTFID_1607a
			{     
				CMN_PRO_Dimension_ValueID = gfunct_DimensionValue.Key.CMN_PRO_Dimension_ValueID ,
				Dimensions_RefID = gfunct_DimensionValue.FirstOrDefault().Dimensions_RefID ,
				DimensionValue_Text = gfunct_DimensionValue.FirstOrDefault().DimensionValue_Text ,
				OrderSequence = gfunct_DimensionValue.FirstOrDefault().OrderSequence ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L3DM_GDTFID_1607 : FR_Base
	{
		public L3DM_GDTFID_1607 Result	{ get; set; }

		public FR_L3DM_GDTFID_1607() : base() {}

		public FR_L3DM_GDTFID_1607(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3DM_GDTFID_1607 for attribute P_L3DM_GDTFID_1607
		[DataContract]
		public class P_L3DM_GDTFID_1607 
		{
			//Standard type parameters
			[DataMember]
			public Guid DimensionID { get; set; } 

		}
		#endregion
		#region SClass L3DM_GDTFID_1607 for attribute L3DM_GDTFID_1607
		[DataContract]
		public class L3DM_GDTFID_1607 
		{
			[DataMember]
			public L3DM_GDTFID_1607a[] DimensionValue { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_DimensionID { get; set; } 
			[DataMember]
			public string Abbreviation { get; set; } 
			[DataMember]
			public Dict DimensionName { get; set; } 
			[DataMember]
			public bool IsDimensionTemplate { get; set; } 

		}
		#endregion
		#region SClass L3DM_GDTFID_1607a for attribute DimensionValue
		[DataContract]
		public class L3DM_GDTFID_1607a 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_Dimension_ValueID { get; set; } 
			[DataMember]
			public Guid Dimensions_RefID { get; set; } 
			[DataMember]
			public Dict DimensionValue_Text { get; set; } 
			[DataMember]
			public int OrderSequence { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3DM_GDTFID_1607 cls_Get_Dimension_Template_For_DimensionTemplateID(,P_L3DM_GDTFID_1607 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3DM_GDTFID_1607 invocationResult = cls_Get_Dimension_Template_For_DimensionTemplateID.Invoke(connectionString,P_L3DM_GDTFID_1607 Parameter,securityTicket);
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
var parameter = new CL3_Dimension.Atomic.Retrieval.P_L3DM_GDTFID_1607();
parameter.DimensionID = ...;

*/
