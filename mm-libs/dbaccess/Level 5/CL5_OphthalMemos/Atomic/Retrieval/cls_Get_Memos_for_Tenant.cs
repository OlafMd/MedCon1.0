/* 
 * Generated on 8/30/2013 11:15:29 AM
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

namespace CL5_OphthalMemos.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Memos_for_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Memos_for_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5OM_GMFT_1018_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5OM_GMFT_1018_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_OphthalMemos.Atomic.Retrieval.SQL.cls_Get_Memos_for_Tenant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L5OM_GMFT_1018_raw> results = new List<L5OM_GMFT_1018_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_BPT_MemoID","CreatedBy_Account_RefID","Memo_Title","Memo_Abbreviation","Memo_Text","UpdatedOn","UpdatedBy_Account_RefID","Creation_Timestamp","DocumentStructureHeader_RefID","DOC_StructureID","Practice_BusinessParticipantID","Practice_CMN_BPT_Memo_RelatedParticipantID","Doctor_CMN_BPT_BusinessParticipantID","Doctor_CMN_BPT_Memo_RelatedParticipantID","Field_Key","CMN_BPT_Memo_AdditionalFieldID","Field_Value" });
				while(reader.Read())
				{
					L5OM_GMFT_1018_raw resultItem = new L5OM_GMFT_1018_raw();
					//0:Parameter CMN_BPT_MemoID of type Guid
					resultItem.CMN_BPT_MemoID = reader.GetGuid(0);
					//1:Parameter CreatedBy_Account_RefID of type Guid
					resultItem.CreatedBy_Account_RefID = reader.GetGuid(1);
					//2:Parameter Memo_Title of type String
					resultItem.Memo_Title = reader.GetString(2);
					//3:Parameter Memo_Abbreviation of type String
					resultItem.Memo_Abbreviation = reader.GetString(3);
					//4:Parameter Memo_Text of type String
					resultItem.Memo_Text = reader.GetString(4);
					//5:Parameter UpdatedOn of type DateTime
					resultItem.UpdatedOn = reader.GetDate(5);
					//6:Parameter UpdatedBy_Account_RefID of type Guid
					resultItem.UpdatedBy_Account_RefID = reader.GetGuid(6);
					//7:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(7);
					//8:Parameter DocumentStructureHeader_RefID of type Guid
					resultItem.DocumentStructureHeader_RefID = reader.GetGuid(8);
					//9:Parameter DOC_StructureID of type Guid
					resultItem.DOC_StructureID = reader.GetGuid(9);
					//10:Parameter Practice_BusinessParticipantID of type Guid
					resultItem.Practice_BusinessParticipantID = reader.GetGuid(10);
					//11:Parameter Practice_CMN_BPT_Memo_RelatedParticipantID of type Guid
					resultItem.Practice_CMN_BPT_Memo_RelatedParticipantID = reader.GetGuid(11);
					//12:Parameter Doctor_CMN_BPT_BusinessParticipantID of type Guid
					resultItem.Doctor_CMN_BPT_BusinessParticipantID = reader.GetGuid(12);
					//13:Parameter Doctor_CMN_BPT_Memo_RelatedParticipantID of type Guid
					resultItem.Doctor_CMN_BPT_Memo_RelatedParticipantID = reader.GetGuid(13);
					//14:Parameter Field_Key of type String
					resultItem.Field_Key = reader.GetString(14);
					//15:Parameter CMN_BPT_Memo_AdditionalFieldID of type Guid
					resultItem.CMN_BPT_Memo_AdditionalFieldID = reader.GetGuid(15);
					//16:Parameter Field_Value of type String
					resultItem.Field_Value = reader.GetString(16);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Memos_for_Tenant",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5OM_GMFT_1018_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5OM_GMFT_1018_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5OM_GMFT_1018_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5OM_GMFT_1018_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5OM_GMFT_1018_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5OM_GMFT_1018_Array functionReturn = new FR_L5OM_GMFT_1018_Array();
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

				throw new Exception("Exception occured in method cls_Get_Memos_for_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5OM_GMFT_1018_raw 
	{
		public Guid CMN_BPT_MemoID; 
		public Guid CreatedBy_Account_RefID; 
		public String Memo_Title; 
		public String Memo_Abbreviation; 
		public String Memo_Text; 
		public DateTime UpdatedOn; 
		public Guid UpdatedBy_Account_RefID; 
		public DateTime Creation_Timestamp; 
		public Guid DocumentStructureHeader_RefID; 
		public Guid DOC_StructureID; 
		public Guid Practice_BusinessParticipantID; 
		public Guid Practice_CMN_BPT_Memo_RelatedParticipantID; 
		public Guid Doctor_CMN_BPT_BusinessParticipantID; 
		public Guid Doctor_CMN_BPT_Memo_RelatedParticipantID; 
		public String Field_Key; 
		public Guid CMN_BPT_Memo_AdditionalFieldID; 
		public String Field_Value; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5OM_GMFT_1018[] Convert(List<L5OM_GMFT_1018_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5OM_GMFT_1018 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.CMN_BPT_MemoID)).ToArray()
	group el_L5OM_GMFT_1018 by new 
	{ 
		el_L5OM_GMFT_1018.CMN_BPT_MemoID,

	}
	into gfunct_L5OM_GMFT_1018
	select new L5OM_GMFT_1018
	{     
		CMN_BPT_MemoID = gfunct_L5OM_GMFT_1018.Key.CMN_BPT_MemoID ,
		CreatedBy_Account_RefID = gfunct_L5OM_GMFT_1018.FirstOrDefault().CreatedBy_Account_RefID ,
		Memo_Title = gfunct_L5OM_GMFT_1018.FirstOrDefault().Memo_Title ,
		Memo_Abbreviation = gfunct_L5OM_GMFT_1018.FirstOrDefault().Memo_Abbreviation ,
		Memo_Text = gfunct_L5OM_GMFT_1018.FirstOrDefault().Memo_Text ,
		UpdatedOn = gfunct_L5OM_GMFT_1018.FirstOrDefault().UpdatedOn ,
		UpdatedBy_Account_RefID = gfunct_L5OM_GMFT_1018.FirstOrDefault().UpdatedBy_Account_RefID ,
		Creation_Timestamp = gfunct_L5OM_GMFT_1018.FirstOrDefault().Creation_Timestamp ,
		DocumentStructureHeader_RefID = gfunct_L5OM_GMFT_1018.FirstOrDefault().DocumentStructureHeader_RefID ,
		DOC_StructureID = gfunct_L5OM_GMFT_1018.FirstOrDefault().DOC_StructureID ,
		Practice_BusinessParticipantID = gfunct_L5OM_GMFT_1018.FirstOrDefault().Practice_BusinessParticipantID ,
		Practice_CMN_BPT_Memo_RelatedParticipantID = gfunct_L5OM_GMFT_1018.FirstOrDefault().Practice_CMN_BPT_Memo_RelatedParticipantID ,
		Doctor_CMN_BPT_BusinessParticipantID = gfunct_L5OM_GMFT_1018.FirstOrDefault().Doctor_CMN_BPT_BusinessParticipantID ,
		Doctor_CMN_BPT_Memo_RelatedParticipantID = gfunct_L5OM_GMFT_1018.FirstOrDefault().Doctor_CMN_BPT_Memo_RelatedParticipantID ,

		AdditionalFields = 
		(
			from el_AdditionalFields in gfunct_L5OM_GMFT_1018.Where(element => !EqualsDefaultValue(element.CMN_BPT_Memo_AdditionalFieldID)).ToArray()
			group el_AdditionalFields by new 
			{ 
				el_AdditionalFields.CMN_BPT_Memo_AdditionalFieldID,

			}
			into gfunct_AdditionalFields
			select new L5OM_GMFT_1018_AdditionalField
			{     
				Field_Key = gfunct_AdditionalFields.FirstOrDefault().Field_Key ,
				CMN_BPT_Memo_AdditionalFieldID = gfunct_AdditionalFields.Key.CMN_BPT_Memo_AdditionalFieldID ,
				Field_Value = gfunct_AdditionalFields.FirstOrDefault().Field_Value ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5OM_GMFT_1018_Array : FR_Base
	{
		public L5OM_GMFT_1018[] Result	{ get; set; } 
		public FR_L5OM_GMFT_1018_Array() : base() {}

		public FR_L5OM_GMFT_1018_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5OM_GMFT_1018 for attribute L5OM_GMFT_1018
		[DataContract]
		public class L5OM_GMFT_1018 
		{
			[DataMember]
			public L5OM_GMFT_1018_AdditionalField[] AdditionalFields { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid CMN_BPT_MemoID { get; set; } 
			[DataMember]
			public Guid CreatedBy_Account_RefID { get; set; } 
			[DataMember]
			public String Memo_Title { get; set; } 
			[DataMember]
			public String Memo_Abbreviation { get; set; } 
			[DataMember]
			public String Memo_Text { get; set; } 
			[DataMember]
			public DateTime UpdatedOn { get; set; } 
			[DataMember]
			public Guid UpdatedBy_Account_RefID { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public Guid DocumentStructureHeader_RefID { get; set; } 
			[DataMember]
			public Guid DOC_StructureID { get; set; } 
			[DataMember]
			public Guid Practice_BusinessParticipantID { get; set; } 
			[DataMember]
			public Guid Practice_CMN_BPT_Memo_RelatedParticipantID { get; set; } 
			[DataMember]
			public Guid Doctor_CMN_BPT_BusinessParticipantID { get; set; } 
			[DataMember]
			public Guid Doctor_CMN_BPT_Memo_RelatedParticipantID { get; set; } 

		}
		#endregion
		#region SClass L5OM_GMFT_1018_AdditionalField for attribute AdditionalFields
		[DataContract]
		public class L5OM_GMFT_1018_AdditionalField 
		{
			//Standard type parameters
			[DataMember]
			public String Field_Key { get; set; } 
			[DataMember]
			public Guid CMN_BPT_Memo_AdditionalFieldID { get; set; } 
			[DataMember]
			public String Field_Value { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5OM_GMFT_1018_Array cls_Get_Memos_for_Tenant(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5OM_GMFT_1018_Array invocationResult = cls_Get_Memos_for_Tenant.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

