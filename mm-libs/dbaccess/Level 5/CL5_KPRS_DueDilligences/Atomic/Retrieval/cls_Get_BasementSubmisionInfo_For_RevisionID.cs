/* 
 * Generated on 11/6/2013 1:28:32 PM
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
    /// var result = cls_Get_BasementSubmisionInfo_For_RevisionID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_BasementSubmisionInfo_For_RevisionID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5DD_GBSIfRID_1431_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5DD_GBSIfRID_1431 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5DD_GBSIfRID_1431_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_KPRS_DueDiligences.Atomic.Retrieval.SQL.cls_Get_BasementSubmisionInfo_For_RevisionID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"RevisionID", Parameter.RevisionID);
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"BuildingPartID", Parameter.BuildingPartID);

            if (Parameter.BuildingPartID_IsSpecified == false)
            {
                var regex = new System.Text.RegularExpressions.Regex(@"((and|or)\s*)?(\w*\.)?\w*\s*(=|like|<|>)\s*@BuildingPartID", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                command.CommandText = regex.Replace(command.CommandText, "");
            } 

			List<L5DD_GBSIfRID_1431_raw> results = new List<L5DD_GBSIfRID_1431_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "RES_STR_BasementID","RES_BLD_Basement_RefID","TypeOfFloor_RefID","Basement_DocumentHeader_RefID","AverageRating_RefID","Basement_Comment","RES_STR_Basement_PropertyAssessmentID","RES_STR_Basement_PropertyID","GlobalPropertyMatchingID","DocumentHeader_RefID","PropertyAssessment_Comment","Rating_RefID","RES_STR_Basement_RequiredActionID","SelectedActionVersion_RefID","EffectivePrice_RefID","Action_PricePerUnit_RefID","Action_Unit_RefID","Action_UnitAmount","IsCustom","IfCustom_Name","IfCustom_Description","Action_Timeframe_RefID","RequiredAction_Comment","Action_Name_DictID","PriceValue_Amount" });
				while(reader.Read())
				{
					L5DD_GBSIfRID_1431_raw resultItem = new L5DD_GBSIfRID_1431_raw();
					//0:Parameter RES_STR_BasementID of type Guid
					resultItem.RES_STR_BasementID = reader.GetGuid(0);
					//1:Parameter RES_BLD_Basement_RefID of type Guid
					resultItem.RES_BLD_Basement_RefID = reader.GetGuid(1);
					//2:Parameter TypeOfFloor_RefID of type Guid
					resultItem.TypeOfFloor_RefID = reader.GetGuid(2);
					//3:Parameter Basement_DocumentHeader_RefID of type Guid
					resultItem.Basement_DocumentHeader_RefID = reader.GetGuid(3);
					//4:Parameter AverageRating_RefID of type Guid
					resultItem.AverageRating_RefID = reader.GetGuid(4);
					//5:Parameter Basement_Comment of type String
					resultItem.Basement_Comment = reader.GetString(5);
					//6:Parameter RES_STR_Basement_PropertyAssessmentID of type Guid
					resultItem.RES_STR_Basement_PropertyAssessmentID = reader.GetGuid(6);
					//7:Parameter RES_STR_Basement_PropertyID of type Guid
					resultItem.RES_STR_Basement_PropertyID = reader.GetGuid(7);
					//8:Parameter GlobalPropertyMatchingID of type String
					resultItem.GlobalPropertyMatchingID = reader.GetString(8);
					//9:Parameter DocumentHeader_RefID of type Guid
					resultItem.DocumentHeader_RefID = reader.GetGuid(9);
					//10:Parameter PropertyAssessment_Comment of type String
					resultItem.PropertyAssessment_Comment = reader.GetString(10);
					//11:Parameter Rating_RefID of type Guid
					resultItem.Rating_RefID = reader.GetGuid(11);
					//12:Parameter RES_STR_Basement_RequiredActionID of type Guid
					resultItem.RES_STR_Basement_RequiredActionID = reader.GetGuid(12);
					//13:Parameter SelectedActionVersion_RefID of type Guid
					resultItem.SelectedActionVersion_RefID = reader.GetGuid(13);
					//14:Parameter EffectivePrice_RefID of type Guid
					resultItem.EffectivePrice_RefID = reader.GetGuid(14);
					//15:Parameter Action_PricePerUnit_RefID of type Guid
					resultItem.Action_PricePerUnit_RefID = reader.GetGuid(15);
					//16:Parameter Action_Unit_RefID of type Guid
					resultItem.Action_Unit_RefID = reader.GetGuid(16);
					//17:Parameter Action_UnitAmount of type double
					resultItem.Action_UnitAmount = reader.GetDouble(17);
					//18:Parameter IsCustom of type bool
					resultItem.IsCustom = reader.GetBoolean(18);
					//19:Parameter IfCustom_Name of type String
					resultItem.IfCustom_Name = reader.GetString(19);
					//20:Parameter IfCustom_Description of type String
					resultItem.IfCustom_Description = reader.GetString(20);
					//21:Parameter Action_Timeframe_RefID of type Guid
					resultItem.Action_Timeframe_RefID = reader.GetGuid(21);
					//22:Parameter RequiredAction_Comment of type String
					resultItem.RequiredAction_Comment = reader.GetString(22);
					//23:Parameter Action_Name of type Dict
					resultItem.Action_Name = reader.GetDictionary(23);
					resultItem.Action_Name.SourceTable = "res_act_action_version";
					loader.Append(resultItem.Action_Name);
					//24:Parameter PriceValue_Amount of type double
					resultItem.PriceValue_Amount = reader.GetDouble(24);

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

			returnStatus.Result = L5DD_GBSIfRID_1431_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5DD_GBSIfRID_1431_Array Invoke(string ConnectionString,P_L5DD_GBSIfRID_1431 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5DD_GBSIfRID_1431_Array Invoke(DbConnection Connection,P_L5DD_GBSIfRID_1431 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5DD_GBSIfRID_1431_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5DD_GBSIfRID_1431 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5DD_GBSIfRID_1431_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5DD_GBSIfRID_1431 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5DD_GBSIfRID_1431_Array functionReturn = new FR_L5DD_GBSIfRID_1431_Array();
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
	public class L5DD_GBSIfRID_1431_raw 
	{
		public Guid RES_STR_BasementID; 
		public Guid RES_BLD_Basement_RefID; 
		public Guid TypeOfFloor_RefID; 
		public Guid Basement_DocumentHeader_RefID; 
		public Guid AverageRating_RefID; 
		public String Basement_Comment; 
		public Guid RES_STR_Basement_PropertyAssessmentID; 
		public Guid RES_STR_Basement_PropertyID; 
		public String GlobalPropertyMatchingID; 
		public Guid DocumentHeader_RefID; 
		public String PropertyAssessment_Comment; 
		public Guid Rating_RefID; 
		public Guid RES_STR_Basement_RequiredActionID; 
		public Guid SelectedActionVersion_RefID; 
		public Guid EffectivePrice_RefID; 
		public Guid Action_PricePerUnit_RefID; 
		public Guid Action_Unit_RefID; 
		public double Action_UnitAmount; 
		public bool IsCustom; 
		public String IfCustom_Name; 
		public String IfCustom_Description; 
		public Guid Action_Timeframe_RefID; 
		public String RequiredAction_Comment; 
		public Dict Action_Name; 
		public double PriceValue_Amount; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5DD_GBSIfRID_1431[] Convert(List<L5DD_GBSIfRID_1431_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5DD_GBSIfRID_1431 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.RES_STR_BasementID)).ToArray()
	group el_L5DD_GBSIfRID_1431 by new 
	{ 
		el_L5DD_GBSIfRID_1431.RES_STR_BasementID,

	}
	into gfunct_L5DD_GBSIfRID_1431
	select new L5DD_GBSIfRID_1431
	{     
		RES_STR_BasementID = gfunct_L5DD_GBSIfRID_1431.Key.RES_STR_BasementID ,
		RES_BLD_Basement_RefID = gfunct_L5DD_GBSIfRID_1431.FirstOrDefault().RES_BLD_Basement_RefID ,
		TypeOfFloor_RefID = gfunct_L5DD_GBSIfRID_1431.FirstOrDefault().TypeOfFloor_RefID ,
		Basement_DocumentHeader_RefID = gfunct_L5DD_GBSIfRID_1431.FirstOrDefault().Basement_DocumentHeader_RefID ,
		AverageRating_RefID = gfunct_L5DD_GBSIfRID_1431.FirstOrDefault().AverageRating_RefID ,
		Basement_Comment = gfunct_L5DD_GBSIfRID_1431.FirstOrDefault().Basement_Comment ,

		BasementPropertyAsessments = 
		(
			from el_BasementPropertyAsessments in gfunct_L5DD_GBSIfRID_1431.Where(element => !EqualsDefaultValue(element.RES_STR_Basement_PropertyAssessmentID)).ToArray()
			group el_BasementPropertyAsessments by new 
			{ 
				el_BasementPropertyAsessments.RES_STR_Basement_PropertyAssessmentID,

			}
			into gfunct_BasementPropertyAsessments
			select new L5DD_GBSIfRID_1431_BasementPropertyAsessment
			{     
				RES_STR_Basement_PropertyAssessmentID = gfunct_BasementPropertyAsessments.Key.RES_STR_Basement_PropertyAssessmentID ,
				RES_STR_Basement_PropertyID = gfunct_BasementPropertyAsessments.FirstOrDefault().RES_STR_Basement_PropertyID ,
				GlobalPropertyMatchingID = gfunct_BasementPropertyAsessments.FirstOrDefault().GlobalPropertyMatchingID ,
				DocumentHeader_RefID = gfunct_BasementPropertyAsessments.FirstOrDefault().DocumentHeader_RefID ,
				PropertyAssessment_Comment = gfunct_BasementPropertyAsessments.FirstOrDefault().PropertyAssessment_Comment ,
				Rating_RefID = gfunct_BasementPropertyAsessments.FirstOrDefault().Rating_RefID ,

				BasementReqActions = 
				(
					from el_BasementReqActions in gfunct_BasementPropertyAsessments.Where(element => !EqualsDefaultValue(element.RES_STR_Basement_RequiredActionID)).ToArray()
					group el_BasementReqActions by new 
					{ 
						el_BasementReqActions.RES_STR_Basement_RequiredActionID,

					}
					into gfunct_BasementReqActions
					select new L5DD_GBSIfRID_1431_BasementReqAction
					{     
						RES_STR_Basement_RequiredActionID = gfunct_BasementReqActions.Key.RES_STR_Basement_RequiredActionID ,
						SelectedActionVersion_RefID = gfunct_BasementReqActions.FirstOrDefault().SelectedActionVersion_RefID ,
						EffectivePrice_RefID = gfunct_BasementReqActions.FirstOrDefault().EffectivePrice_RefID ,
						Action_PricePerUnit_RefID = gfunct_BasementReqActions.FirstOrDefault().Action_PricePerUnit_RefID ,
						Action_Unit_RefID = gfunct_BasementReqActions.FirstOrDefault().Action_Unit_RefID ,
						Action_UnitAmount = gfunct_BasementReqActions.FirstOrDefault().Action_UnitAmount ,
						IsCustom = gfunct_BasementReqActions.FirstOrDefault().IsCustom ,
						IfCustom_Name = gfunct_BasementReqActions.FirstOrDefault().IfCustom_Name ,
						IfCustom_Description = gfunct_BasementReqActions.FirstOrDefault().IfCustom_Description ,
						Action_Timeframe_RefID = gfunct_BasementReqActions.FirstOrDefault().Action_Timeframe_RefID ,
						RequiredAction_Comment = gfunct_BasementReqActions.FirstOrDefault().RequiredAction_Comment ,
						Action_Name = gfunct_BasementReqActions.FirstOrDefault().Action_Name ,
						PriceValue_Amount = gfunct_BasementReqActions.FirstOrDefault().PriceValue_Amount ,

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
	public class FR_L5DD_GBSIfRID_1431_Array : FR_Base
	{
		public L5DD_GBSIfRID_1431[] Result	{ get; set; } 
		public FR_L5DD_GBSIfRID_1431_Array() : base() {}

		public FR_L5DD_GBSIfRID_1431_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5DD_GBSIfRID_1431 for attribute P_L5DD_GBSIfRID_1431
		[DataContract]
		public class P_L5DD_GBSIfRID_1431 
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
		#region SClass L5DD_GBSIfRID_1431 for attribute L5DD_GBSIfRID_1431
		[DataContract]
		public class L5DD_GBSIfRID_1431 
		{
			[DataMember]
			public L5DD_GBSIfRID_1431_BasementPropertyAsessment[] BasementPropertyAsessments { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid RES_STR_BasementID { get; set; } 
			[DataMember]
			public Guid RES_BLD_Basement_RefID { get; set; } 
			[DataMember]
			public Guid TypeOfFloor_RefID { get; set; } 
			[DataMember]
			public Guid Basement_DocumentHeader_RefID { get; set; } 
			[DataMember]
			public Guid AverageRating_RefID { get; set; } 
			[DataMember]
			public String Basement_Comment { get; set; } 

		}
		#endregion
		#region SClass L5DD_GBSIfRID_1431_BasementPropertyAsessment for attribute BasementPropertyAsessments
		[DataContract]
		public class L5DD_GBSIfRID_1431_BasementPropertyAsessment 
		{
			[DataMember]
			public L5DD_GBSIfRID_1431_BasementReqAction[] BasementReqActions { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid RES_STR_Basement_PropertyAssessmentID { get; set; } 
			[DataMember]
			public Guid RES_STR_Basement_PropertyID { get; set; } 
			[DataMember]
			public String GlobalPropertyMatchingID { get; set; } 
			[DataMember]
			public Guid DocumentHeader_RefID { get; set; } 
			[DataMember]
			public String PropertyAssessment_Comment { get; set; } 
			[DataMember]
			public Guid Rating_RefID { get; set; } 

		}
		#endregion
		#region SClass L5DD_GBSIfRID_1431_BasementReqAction for attribute BasementReqActions
		[DataContract]
		public class L5DD_GBSIfRID_1431_BasementReqAction 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_STR_Basement_RequiredActionID { get; set; } 
			[DataMember]
			public Guid SelectedActionVersion_RefID { get; set; } 
			[DataMember]
			public Guid EffectivePrice_RefID { get; set; } 
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
			public String RequiredAction_Comment { get; set; } 
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
FR_L5DD_GBSIfRID_1431_Array cls_Get_BasementSubmisionInfo_For_RevisionID(P_L5DD_GBSIfRID_1431 Parameter,string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_L5DD_GBSIfRID_1431_Array result = cls_Get_BasementSubmisionInfo_For_RevisionID.Invoke(connectionString,P_L5DD_GBSIfRID_1431 Parameter,securityTicket);
	 return result;
}
*/