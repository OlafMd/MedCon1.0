/* 
 * Generated on 11/7/2013 2:16:23 PM
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
    /// var result = cls_Get_RoofSubmisionInfo_For_RevisionID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_RoofSubmisionInfo_For_RevisionID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5DD_GRSIfRID_1213_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5DD_GRSIfRID_1213 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5DD_GRSIfRID_1213_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_KPRS_DueDiligences.Atomic.Retrieval.SQL.cls_Get_RoofSubmisionInfo_For_RevisionID.sql";
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

			List<L5DD_GRSIfRID_1213_raw> results = new List<L5DD_GRSIfRID_1213_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "RES_STR_RoofID","RES_BLD_Roof_Type_RefID","RES_BLD_Roof_RefID","Roof_DocumentHeader_RefID","Roof_Comment","AverageRating_RefID","STR_Roof_RefID","RES_STR_Roof_PropertyAssessmentID","PropertyAssessment_Comment","Rating_RefID","RES_STR_Roof_PropertyID","GlobalPropertyMatchingID","DocumentHeader_RefID","RequiredAction_Comment","SelectedActionVersion_RefID","RES_STR_Roof_RequiredActionID","Action_PricePerUnit_RefID","Action_Unit_RefID","Action_UnitAmount","Action_Timeframe_RefID","IsCustom","IfCustom_Name","IfCustom_Description","EffectivePrice_RefID","Action_Name_DictID","PriceValue_Amount" });
				while(reader.Read())
				{
					L5DD_GRSIfRID_1213_raw resultItem = new L5DD_GRSIfRID_1213_raw();
					//0:Parameter RES_STR_RoofID of type Guid
					resultItem.RES_STR_RoofID = reader.GetGuid(0);
					//1:Parameter RES_BLD_Roof_Type_RefID of type Guid
					resultItem.RES_BLD_Roof_Type_RefID = reader.GetGuid(1);
					//2:Parameter RES_BLD_Roof_RefID of type Guid
					resultItem.RES_BLD_Roof_RefID = reader.GetGuid(2);
					//3:Parameter Roof_DocumentHeader_RefID of type Guid
					resultItem.Roof_DocumentHeader_RefID = reader.GetGuid(3);
					//4:Parameter Roof_Comment of type String
					resultItem.Roof_Comment = reader.GetString(4);
					//5:Parameter AverageRating_RefID of type Guid
					resultItem.AverageRating_RefID = reader.GetGuid(5);
					//6:Parameter STR_Roof_RefID of type Guid
					resultItem.STR_Roof_RefID = reader.GetGuid(6);
					//7:Parameter RES_STR_Roof_PropertyAssessmentID of type Guid
					resultItem.RES_STR_Roof_PropertyAssessmentID = reader.GetGuid(7);
					//8:Parameter PropertyAssessment_Comment of type String
					resultItem.PropertyAssessment_Comment = reader.GetString(8);
					//9:Parameter Rating_RefID of type Guid
					resultItem.Rating_RefID = reader.GetGuid(9);
					//10:Parameter RES_STR_Roof_PropertyID of type Guid
					resultItem.RES_STR_Roof_PropertyID = reader.GetGuid(10);
					//11:Parameter GlobalPropertyMatchingID of type String
					resultItem.GlobalPropertyMatchingID = reader.GetString(11);
					//12:Parameter DocumentHeader_RefID of type Guid
					resultItem.DocumentHeader_RefID = reader.GetGuid(12);
					//13:Parameter RequiredAction_Comment of type String
					resultItem.RequiredAction_Comment = reader.GetString(13);
					//14:Parameter SelectedActionVersion_RefID of type Guid
					resultItem.SelectedActionVersion_RefID = reader.GetGuid(14);
					//15:Parameter RES_STR_Roof_RequiredActionID of type Guid
					resultItem.RES_STR_Roof_RequiredActionID = reader.GetGuid(15);
					//16:Parameter Action_PricePerUnit_RefID of type Guid
					resultItem.Action_PricePerUnit_RefID = reader.GetGuid(16);
					//17:Parameter Action_Unit_RefID of type Guid
					resultItem.Action_Unit_RefID = reader.GetGuid(17);
					//18:Parameter Action_UnitAmount of type double
					resultItem.Action_UnitAmount = reader.GetDouble(18);
					//19:Parameter Action_Timeframe_RefID of type Guid
					resultItem.Action_Timeframe_RefID = reader.GetGuid(19);
					//20:Parameter IsCustom of type bool
					resultItem.IsCustom = reader.GetBoolean(20);
					//21:Parameter IfCustom_Name of type String
					resultItem.IfCustom_Name = reader.GetString(21);
					//22:Parameter IfCustom_Description of type String
					resultItem.IfCustom_Description = reader.GetString(22);
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

			returnStatus.Result = L5DD_GRSIfRID_1213_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5DD_GRSIfRID_1213_Array Invoke(string ConnectionString,P_L5DD_GRSIfRID_1213 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5DD_GRSIfRID_1213_Array Invoke(DbConnection Connection,P_L5DD_GRSIfRID_1213 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5DD_GRSIfRID_1213_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5DD_GRSIfRID_1213 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5DD_GRSIfRID_1213_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5DD_GRSIfRID_1213 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5DD_GRSIfRID_1213_Array functionReturn = new FR_L5DD_GRSIfRID_1213_Array();
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
	public class L5DD_GRSIfRID_1213_raw 
	{
		public Guid RES_STR_RoofID; 
		public Guid RES_BLD_Roof_Type_RefID; 
		public Guid RES_BLD_Roof_RefID; 
		public Guid Roof_DocumentHeader_RefID; 
		public String Roof_Comment; 
		public Guid AverageRating_RefID; 
		public Guid STR_Roof_RefID; 
		public Guid RES_STR_Roof_PropertyAssessmentID; 
		public String PropertyAssessment_Comment; 
		public Guid Rating_RefID; 
		public Guid RES_STR_Roof_PropertyID; 
		public String GlobalPropertyMatchingID; 
		public Guid DocumentHeader_RefID; 
		public String RequiredAction_Comment; 
		public Guid SelectedActionVersion_RefID; 
		public Guid RES_STR_Roof_RequiredActionID; 
		public Guid Action_PricePerUnit_RefID; 
		public Guid Action_Unit_RefID; 
		public double Action_UnitAmount; 
		public Guid Action_Timeframe_RefID; 
		public bool IsCustom; 
		public String IfCustom_Name; 
		public String IfCustom_Description; 
		public Guid EffectivePrice_RefID; 
		public Dict Action_Name; 
		public double PriceValue_Amount; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5DD_GRSIfRID_1213[] Convert(List<L5DD_GRSIfRID_1213_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5DD_GRSIfRID_1213 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.RES_STR_RoofID)).ToArray()
	group el_L5DD_GRSIfRID_1213 by new 
	{ 
		el_L5DD_GRSIfRID_1213.RES_STR_RoofID,

	}
	into gfunct_L5DD_GRSIfRID_1213
	select new L5DD_GRSIfRID_1213
	{     
		RES_STR_RoofID = gfunct_L5DD_GRSIfRID_1213.Key.RES_STR_RoofID ,
		RES_BLD_Roof_Type_RefID = gfunct_L5DD_GRSIfRID_1213.FirstOrDefault().RES_BLD_Roof_Type_RefID ,
		RES_BLD_Roof_RefID = gfunct_L5DD_GRSIfRID_1213.FirstOrDefault().RES_BLD_Roof_RefID ,
		Roof_DocumentHeader_RefID = gfunct_L5DD_GRSIfRID_1213.FirstOrDefault().Roof_DocumentHeader_RefID ,
		Roof_Comment = gfunct_L5DD_GRSIfRID_1213.FirstOrDefault().Roof_Comment ,
		AverageRating_RefID = gfunct_L5DD_GRSIfRID_1213.FirstOrDefault().AverageRating_RefID ,
		STR_Roof_RefID = gfunct_L5DD_GRSIfRID_1213.FirstOrDefault().STR_Roof_RefID ,

		RoofPropertyAsessments = 
		(
			from el_RoofPropertyAsessments in gfunct_L5DD_GRSIfRID_1213.Where(element => !EqualsDefaultValue(element.RES_STR_Roof_PropertyAssessmentID)).ToArray()
			group el_RoofPropertyAsessments by new 
			{ 
				el_RoofPropertyAsessments.RES_STR_Roof_PropertyAssessmentID,

			}
			into gfunct_RoofPropertyAsessments
			select new L5DD_GRSIfRID_1213_RoofPropertyAsessment
			{     
				RES_STR_Roof_PropertyAssessmentID = gfunct_RoofPropertyAsessments.Key.RES_STR_Roof_PropertyAssessmentID ,
				PropertyAssessment_Comment = gfunct_RoofPropertyAsessments.FirstOrDefault().PropertyAssessment_Comment ,
				Rating_RefID = gfunct_RoofPropertyAsessments.FirstOrDefault().Rating_RefID ,
				RES_STR_Roof_PropertyID = gfunct_RoofPropertyAsessments.FirstOrDefault().RES_STR_Roof_PropertyID ,
				GlobalPropertyMatchingID = gfunct_RoofPropertyAsessments.FirstOrDefault().GlobalPropertyMatchingID ,
				DocumentHeader_RefID = gfunct_RoofPropertyAsessments.FirstOrDefault().DocumentHeader_RefID ,

				RoofReqActions = 
				(
					from el_RoofReqActions in gfunct_RoofPropertyAsessments.Where(element => !EqualsDefaultValue(element.RES_STR_Roof_RequiredActionID)).ToArray()
					group el_RoofReqActions by new 
					{ 
						el_RoofReqActions.RES_STR_Roof_RequiredActionID,

					}
					into gfunct_RoofReqActions
					select new L5DD_GRSIfRID_1213_RoofReqAction
					{     
						RequiredAction_Comment = gfunct_RoofReqActions.FirstOrDefault().RequiredAction_Comment ,
						SelectedActionVersion_RefID = gfunct_RoofReqActions.FirstOrDefault().SelectedActionVersion_RefID ,
						RES_STR_Roof_RequiredActionID = gfunct_RoofReqActions.Key.RES_STR_Roof_RequiredActionID ,
						Action_PricePerUnit_RefID = gfunct_RoofReqActions.FirstOrDefault().Action_PricePerUnit_RefID ,
						Action_Unit_RefID = gfunct_RoofReqActions.FirstOrDefault().Action_Unit_RefID ,
						Action_UnitAmount = gfunct_RoofReqActions.FirstOrDefault().Action_UnitAmount ,
						Action_Timeframe_RefID = gfunct_RoofReqActions.FirstOrDefault().Action_Timeframe_RefID ,
						IsCustom = gfunct_RoofReqActions.FirstOrDefault().IsCustom ,
						IfCustom_Name = gfunct_RoofReqActions.FirstOrDefault().IfCustom_Name ,
						IfCustom_Description = gfunct_RoofReqActions.FirstOrDefault().IfCustom_Description ,
						EffectivePrice_RefID = gfunct_RoofReqActions.FirstOrDefault().EffectivePrice_RefID ,
						Action_Name = gfunct_RoofReqActions.FirstOrDefault().Action_Name ,
						PriceValue_Amount = gfunct_RoofReqActions.FirstOrDefault().PriceValue_Amount ,

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
	public class FR_L5DD_GRSIfRID_1213_Array : FR_Base
	{
		public L5DD_GRSIfRID_1213[] Result	{ get; set; } 
		public FR_L5DD_GRSIfRID_1213_Array() : base() {}

		public FR_L5DD_GRSIfRID_1213_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5DD_GRSIfRID_1213 for attribute P_L5DD_GRSIfRID_1213
		[DataContract]
		public class P_L5DD_GRSIfRID_1213 
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
		#region SClass L5DD_GRSIfRID_1213 for attribute L5DD_GRSIfRID_1213
		[DataContract]
		public class L5DD_GRSIfRID_1213 
		{
			[DataMember]
			public L5DD_GRSIfRID_1213_RoofPropertyAsessment[] RoofPropertyAsessments { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid RES_STR_RoofID { get; set; } 
			[DataMember]
			public Guid RES_BLD_Roof_Type_RefID { get; set; } 
			[DataMember]
			public Guid RES_BLD_Roof_RefID { get; set; } 
			[DataMember]
			public Guid Roof_DocumentHeader_RefID { get; set; } 
			[DataMember]
			public String Roof_Comment { get; set; } 
			[DataMember]
			public Guid AverageRating_RefID { get; set; } 
			[DataMember]
			public Guid STR_Roof_RefID { get; set; } 

		}
		#endregion
		#region SClass L5DD_GRSIfRID_1213_RoofPropertyAsessment for attribute RoofPropertyAsessments
		[DataContract]
		public class L5DD_GRSIfRID_1213_RoofPropertyAsessment 
		{
			[DataMember]
			public L5DD_GRSIfRID_1213_RoofReqAction[] RoofReqActions { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid RES_STR_Roof_PropertyAssessmentID { get; set; } 
			[DataMember]
			public String PropertyAssessment_Comment { get; set; } 
			[DataMember]
			public Guid Rating_RefID { get; set; } 
			[DataMember]
			public Guid RES_STR_Roof_PropertyID { get; set; } 
			[DataMember]
			public String GlobalPropertyMatchingID { get; set; } 
			[DataMember]
			public Guid DocumentHeader_RefID { get; set; } 

		}
		#endregion
		#region SClass L5DD_GRSIfRID_1213_RoofReqAction for attribute RoofReqActions
		[DataContract]
		public class L5DD_GRSIfRID_1213_RoofReqAction 
		{
			//Standard type parameters
			[DataMember]
			public String RequiredAction_Comment { get; set; } 
			[DataMember]
			public Guid SelectedActionVersion_RefID { get; set; } 
			[DataMember]
			public Guid RES_STR_Roof_RequiredActionID { get; set; } 
			[DataMember]
			public Guid Action_PricePerUnit_RefID { get; set; } 
			[DataMember]
			public Guid Action_Unit_RefID { get; set; } 
			[DataMember]
			public double Action_UnitAmount { get; set; } 
			[DataMember]
			public Guid Action_Timeframe_RefID { get; set; } 
			[DataMember]
			public bool IsCustom { get; set; } 
			[DataMember]
			public String IfCustom_Name { get; set; } 
			[DataMember]
			public String IfCustom_Description { get; set; } 
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
FR_L5DD_GRSIfRID_1213_Array cls_Get_RoofSubmisionInfo_For_RevisionID(P_L5DD_GRSIfRID_1213 Parameter,string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_L5DD_GRSIfRID_1213_Array result = cls_Get_RoofSubmisionInfo_For_RevisionID.Invoke(connectionString,P_L5DD_GRSIfRID_1213 Parameter,securityTicket);
	 return result;
}
*/