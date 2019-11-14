/* 
 * Generated on 11/7/2013 2:17:11 PM
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

namespace CL5_KPRS_DueDiligences.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_StaircaseSubmisionInfo_For_RevisionID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_StaircaseSubmisionInfo_For_RevisionID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5DD_GASIfRID_1507_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5DD_GASIfRID_1507 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5DD_GASIfRID_1507_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_KPRS_DueDiligences.Atomic.Retrieval.SQL.cls_Get_StaircaseSubmisionInfo_For_RevisionID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"RevisionID", Parameter.RevisionID);
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"BuildingPartID", Parameter.BuildingPartID);

            if (Parameter.BuildingPartID_IsSpecified == false)
            {
                var regex = new System.Text.RegularExpressions.Regex(@"((and|or)\s*)?(\w*\.)?\w*\s*(=|like|<|>)\s*@BuildingPartID(\s*collate\s+\w+)?", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                command.CommandText = regex.Replace(command.CommandText, "");
            }

			List<L5DD_GASIfRID_1507_raw> results = new List<L5DD_GASIfRID_1507_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "Staircase_DocumentHeader_RefID","Staircase_Comment","AverageRating_RefID","RES_STR_StaircaseID","RES_BLD_Staircase_RefID","StaircaseSize_Unit_RefID","StaircaseSize_Value","GlobalPropertyMatchingID","RES_STR_Staircase_PropertyID","RES_STR_Staircase_PropertyAssessmentID","Rating_RefID","DocumentHeader_RefID","PropertyAssessment_Comment","RES_STR_Staircase_RequiredActionID","SelectedActionVersion_RefID","RequiredAction_Comment","Action_PricePerUnit_RefID","Action_Unit_RefID","Action_UnitAmount","IsCustom","IfCustom_Name","IfCustom_Description","Action_Timeframe_RefID","EffectivePrice_RefID","Action_Name_DictID","PriceValue_Amount" });
				while(reader.Read())
				{
					L5DD_GASIfRID_1507_raw resultItem = new L5DD_GASIfRID_1507_raw();
					//0:Parameter Staircase_DocumentHeader_RefID of type Guid
					resultItem.Staircase_DocumentHeader_RefID = reader.GetGuid(0);
					//1:Parameter Staircase_Comment of type String
					resultItem.Staircase_Comment = reader.GetString(1);
					//2:Parameter AverageRating_RefID of type Guid
					resultItem.AverageRating_RefID = reader.GetGuid(2);
					//3:Parameter RES_STR_StaircaseID of type Guid
					resultItem.RES_STR_StaircaseID = reader.GetGuid(3);
					//4:Parameter RES_BLD_Staircase_RefID of type Guid
					resultItem.RES_BLD_Staircase_RefID = reader.GetGuid(4);
					//5:Parameter StaircaseSize_Unit_RefID of type Guid
					resultItem.StaircaseSize_Unit_RefID = reader.GetGuid(5);
					//6:Parameter StaircaseSize_Value of type Double
					resultItem.StaircaseSize_Value = reader.GetDouble(6);
					//7:Parameter GlobalPropertyMatchingID of type String
					resultItem.GlobalPropertyMatchingID = reader.GetString(7);
					//8:Parameter RES_STR_Staircase_PropertyID of type Guid
					resultItem.RES_STR_Staircase_PropertyID = reader.GetGuid(8);
					//9:Parameter RES_STR_Staircase_PropertyAssessmentID of type Guid
					resultItem.RES_STR_Staircase_PropertyAssessmentID = reader.GetGuid(9);
					//10:Parameter Rating_RefID of type Guid
					resultItem.Rating_RefID = reader.GetGuid(10);
					//11:Parameter DocumentHeader_RefID of type Guid
					resultItem.DocumentHeader_RefID = reader.GetGuid(11);
					//12:Parameter PropertyAssessment_Comment of type String
					resultItem.PropertyAssessment_Comment = reader.GetString(12);
					//13:Parameter RES_STR_Staircase_RequiredActionID of type Guid
					resultItem.RES_STR_Staircase_RequiredActionID = reader.GetGuid(13);
					//14:Parameter SelectedActionVersion_RefID of type Guid
					resultItem.SelectedActionVersion_RefID = reader.GetGuid(14);
					//15:Parameter RequiredAction_Comment of type String
					resultItem.RequiredAction_Comment = reader.GetString(15);
					//16:Parameter Action_PricePerUnit_RefID of type Guid
					resultItem.Action_PricePerUnit_RefID = reader.GetGuid(16);
					//17:Parameter Action_Unit_RefID of type Guid
					resultItem.Action_Unit_RefID = reader.GetGuid(17);
					//18:Parameter Action_UnitAmount of type double
					resultItem.Action_UnitAmount = reader.GetDouble(18);
					//19:Parameter IsCustom of type bool
					resultItem.IsCustom = reader.GetBoolean(19);
					//20:Parameter IfCustom_Name of type String
					resultItem.IfCustom_Name = reader.GetString(20);
					//21:Parameter IfCustom_Description of type String
					resultItem.IfCustom_Description = reader.GetString(21);
					//22:Parameter Action_Timeframe_RefID of type Guid
					resultItem.Action_Timeframe_RefID = reader.GetGuid(22);
					//23:Parameter EffectivePrice_RefID of type Guid
					resultItem.EffectivePrice_RefID = reader.GetGuid(23);
					//24:Parameter Action_Name of type Dict
					resultItem.Action_Name = reader.GetDictionary(24);
					resultItem.Action_Name.SourceTable = "res_act_action_version";
					loader.Append(resultItem.Action_Name);
					//25:Parameter PriceValue_Amount of type double
					resultItem.PriceValue_Amount = reader.GetDouble(25);

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

			returnStatus.Result = L5DD_GASIfRID_1507_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5DD_GASIfRID_1507_Array Invoke(string ConnectionString,P_L5DD_GASIfRID_1507 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5DD_GASIfRID_1507_Array Invoke(DbConnection Connection,P_L5DD_GASIfRID_1507 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5DD_GASIfRID_1507_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5DD_GASIfRID_1507 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5DD_GASIfRID_1507_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5DD_GASIfRID_1507 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5DD_GASIfRID_1507_Array functionReturn = new FR_L5DD_GASIfRID_1507_Array();
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
	public class L5DD_GASIfRID_1507_raw 
	{
		public Guid Staircase_DocumentHeader_RefID; 
		public String Staircase_Comment; 
		public Guid AverageRating_RefID; 
		public Guid RES_STR_StaircaseID; 
		public Guid RES_BLD_Staircase_RefID; 
		public Guid StaircaseSize_Unit_RefID; 
		public Double StaircaseSize_Value; 
		public String GlobalPropertyMatchingID; 
		public Guid RES_STR_Staircase_PropertyID; 
		public Guid RES_STR_Staircase_PropertyAssessmentID; 
		public Guid Rating_RefID; 
		public Guid DocumentHeader_RefID; 
		public String PropertyAssessment_Comment; 
		public Guid RES_STR_Staircase_RequiredActionID; 
		public Guid SelectedActionVersion_RefID; 
		public String RequiredAction_Comment; 
		public Guid Action_PricePerUnit_RefID; 
		public Guid Action_Unit_RefID; 
		public double Action_UnitAmount; 
		public bool IsCustom; 
		public String IfCustom_Name; 
		public String IfCustom_Description; 
		public Guid Action_Timeframe_RefID; 
		public Guid EffectivePrice_RefID; 
		public Dict Action_Name; 
		public double PriceValue_Amount; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5DD_GASIfRID_1507[] Convert(List<L5DD_GASIfRID_1507_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5DD_GASIfRID_1507 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.RES_STR_StaircaseID)).ToArray()
	group el_L5DD_GASIfRID_1507 by new 
	{ 
		el_L5DD_GASIfRID_1507.RES_STR_StaircaseID,

	}
	into gfunct_L5DD_GASIfRID_1507
	select new L5DD_GASIfRID_1507
	{     
		Staircase_DocumentHeader_RefID = gfunct_L5DD_GASIfRID_1507.FirstOrDefault().Staircase_DocumentHeader_RefID ,
		Staircase_Comment = gfunct_L5DD_GASIfRID_1507.FirstOrDefault().Staircase_Comment ,
		AverageRating_RefID = gfunct_L5DD_GASIfRID_1507.FirstOrDefault().AverageRating_RefID ,
		RES_STR_StaircaseID = gfunct_L5DD_GASIfRID_1507.Key.RES_STR_StaircaseID ,
		RES_BLD_Staircase_RefID = gfunct_L5DD_GASIfRID_1507.FirstOrDefault().RES_BLD_Staircase_RefID ,
		StaircaseSize_Unit_RefID = gfunct_L5DD_GASIfRID_1507.FirstOrDefault().StaircaseSize_Unit_RefID ,
		StaircaseSize_Value = gfunct_L5DD_GASIfRID_1507.FirstOrDefault().StaircaseSize_Value ,

		StaircasePropertyAsessments = 
		(
			from el_StaircasePropertyAsessments in gfunct_L5DD_GASIfRID_1507.Where(element => !EqualsDefaultValue(element.RES_STR_Staircase_PropertyAssessmentID)).ToArray()
			group el_StaircasePropertyAsessments by new 
			{ 
				el_StaircasePropertyAsessments.RES_STR_Staircase_PropertyAssessmentID,

			}
			into gfunct_StaircasePropertyAsessments
			select new L5DD_GASIfRID_1507_StaircasePropertyAsessment
			{     
				GlobalPropertyMatchingID = gfunct_StaircasePropertyAsessments.FirstOrDefault().GlobalPropertyMatchingID ,
				RES_STR_Staircase_PropertyID = gfunct_StaircasePropertyAsessments.FirstOrDefault().RES_STR_Staircase_PropertyID ,
				RES_STR_Staircase_PropertyAssessmentID = gfunct_StaircasePropertyAsessments.Key.RES_STR_Staircase_PropertyAssessmentID ,
				Rating_RefID = gfunct_StaircasePropertyAsessments.FirstOrDefault().Rating_RefID ,
				DocumentHeader_RefID = gfunct_StaircasePropertyAsessments.FirstOrDefault().DocumentHeader_RefID ,
				PropertyAssessment_Comment = gfunct_StaircasePropertyAsessments.FirstOrDefault().PropertyAssessment_Comment ,

				StaircaseReqActions = 
				(
					from el_StaircaseReqActions in gfunct_StaircasePropertyAsessments.Where(element => !EqualsDefaultValue(element.RES_STR_Staircase_RequiredActionID)).ToArray()
					group el_StaircaseReqActions by new 
					{ 
						el_StaircaseReqActions.RES_STR_Staircase_RequiredActionID,

					}
					into gfunct_StaircaseReqActions
					select new L5DD_GASIfRID_1507_StaircaseReqAction
					{     
						RES_STR_Staircase_RequiredActionID = gfunct_StaircaseReqActions.Key.RES_STR_Staircase_RequiredActionID ,
						SelectedActionVersion_RefID = gfunct_StaircaseReqActions.FirstOrDefault().SelectedActionVersion_RefID ,
						RequiredAction_Comment = gfunct_StaircaseReqActions.FirstOrDefault().RequiredAction_Comment ,
						Action_PricePerUnit_RefID = gfunct_StaircaseReqActions.FirstOrDefault().Action_PricePerUnit_RefID ,
						Action_Unit_RefID = gfunct_StaircaseReqActions.FirstOrDefault().Action_Unit_RefID ,
						Action_UnitAmount = gfunct_StaircaseReqActions.FirstOrDefault().Action_UnitAmount ,
						IsCustom = gfunct_StaircaseReqActions.FirstOrDefault().IsCustom ,
						IfCustom_Name = gfunct_StaircaseReqActions.FirstOrDefault().IfCustom_Name ,
						IfCustom_Description = gfunct_StaircaseReqActions.FirstOrDefault().IfCustom_Description ,
						Action_Timeframe_RefID = gfunct_StaircaseReqActions.FirstOrDefault().Action_Timeframe_RefID ,
						EffectivePrice_RefID = gfunct_StaircaseReqActions.FirstOrDefault().EffectivePrice_RefID ,
						Action_Name = gfunct_StaircaseReqActions.FirstOrDefault().Action_Name ,
						PriceValue_Amount = gfunct_StaircaseReqActions.FirstOrDefault().PriceValue_Amount ,

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
	public class FR_L5DD_GASIfRID_1507_Array : FR_Base
	{
		public L5DD_GASIfRID_1507[] Result	{ get; set; } 
		public FR_L5DD_GASIfRID_1507_Array() : base() {}

		public FR_L5DD_GASIfRID_1507_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5DD_GASIfRID_1507 for attribute P_L5DD_GASIfRID_1507
		[DataContract]
		public class P_L5DD_GASIfRID_1507 
		{
			//Standard type parameters
			[DataMember]
			public Guid RevisionID { get; set; } 
			[DataMember]
			public Guid? BuildingPartID { get; set; }
            [DataMember] //Special parameter for query parsing
            public bool BuildingPartID_IsSpecified { get; set; }
		}
		#endregion
		#region SClass L5DD_GASIfRID_1507 for attribute L5DD_GASIfRID_1507
		[DataContract]
		public class L5DD_GASIfRID_1507 
		{
			[DataMember]
			public L5DD_GASIfRID_1507_StaircasePropertyAsessment[] StaircasePropertyAsessments { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid Staircase_DocumentHeader_RefID { get; set; } 
			[DataMember]
			public String Staircase_Comment { get; set; } 
			[DataMember]
			public Guid AverageRating_RefID { get; set; } 
			[DataMember]
			public Guid RES_STR_StaircaseID { get; set; } 
			[DataMember]
			public Guid RES_BLD_Staircase_RefID { get; set; } 
			[DataMember]
			public Guid StaircaseSize_Unit_RefID { get; set; } 
			[DataMember]
			public Double StaircaseSize_Value { get; set; } 

		}
		#endregion
		#region SClass L5DD_GASIfRID_1507_StaircasePropertyAsessment for attribute StaircasePropertyAsessments
		[DataContract]
		public class L5DD_GASIfRID_1507_StaircasePropertyAsessment 
		{
			[DataMember]
			public L5DD_GASIfRID_1507_StaircaseReqAction[] StaircaseReqActions { get; set; }

			//Standard type parameters
			[DataMember]
			public String GlobalPropertyMatchingID { get; set; } 
			[DataMember]
			public Guid RES_STR_Staircase_PropertyID { get; set; } 
			[DataMember]
			public Guid RES_STR_Staircase_PropertyAssessmentID { get; set; } 
			[DataMember]
			public Guid Rating_RefID { get; set; } 
			[DataMember]
			public Guid DocumentHeader_RefID { get; set; } 
			[DataMember]
			public String PropertyAssessment_Comment { get; set; } 

		}
		#endregion
		#region SClass L5DD_GASIfRID_1507_StaircaseReqAction for attribute StaircaseReqActions
		[DataContract]
		public class L5DD_GASIfRID_1507_StaircaseReqAction 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_STR_Staircase_RequiredActionID { get; set; } 
			[DataMember]
			public Guid SelectedActionVersion_RefID { get; set; } 
			[DataMember]
			public String RequiredAction_Comment { get; set; } 
			[DataMember]
			public Guid Action_PricePerUnit_RefID { get; set; } 
			[DataMember]
			public Guid Action_Unit_RefID { get; set; } 
			[DataMember]
			public double Action_UnitAmount { get; set; } 
			[DataMember]
			public bool IsCustom { get; set; } 
			[DataMember]
			public String IfCustom_Name { get; set; } 
			[DataMember]
			public String IfCustom_Description { get; set; } 
			[DataMember]
			public Guid Action_Timeframe_RefID { get; set; } 
			[DataMember]
			public Guid EffectivePrice_RefID { get; set; } 
			[DataMember]
			public Dict Action_Name { get; set; } 
			[DataMember]
			public double PriceValue_Amount { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5DD_GASIfRID_1507_Array cls_Get_StaircaseSubmisionInfo_For_RevisionID(P_L5DD_GASIfRID_1507 Parameter,string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_L5DD_GASIfRID_1507_Array result = cls_Get_StaircaseSubmisionInfo_For_RevisionID.Invoke(connectionString,P_L5DD_GASIfRID_1507 Parameter,securityTicket);
	 return result;
}
*/