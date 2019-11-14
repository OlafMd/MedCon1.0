/* 
 * Generated on 11/7/2013 2:15:11 PM
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
    /// var result = cls_Get_OutdoorFascilitySubmisionInfo_For_RevisionID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_OutdoorFascilitySubmisionInfo_For_RevisionID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5DD_GOFSIfRID_1454_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5DD_GOFSIfRID_1454 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5DD_GOFSIfRID_1454_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_KPRS_DueDiligences.Atomic.Retrieval.SQL.cls_Get_OutdoorFascilitySubmisionInfo_For_RevisionID.sql";
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

			List<L5DD_GOFSIfRID_1454_raw> results = new List<L5DD_GOFSIfRID_1454_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "RES_BLD_OutdoorFacility_RefID","RES_STR_OutdoorFacilityID","OutdoorF_DocumentHeader_RefID","OutdoorF_Comment","AverageRating_RefID","NumberOfGaragePlaces","NumberOfRentedGaragePlaces","TypeOfAccessRoad_RefID","TypeOfFence_RefID","RES_STR_OutdoorFacility_PropertyAssessmentID","GlobalPropertyMatchingID","RES_STR_OutdoorFacility_PropertyID","Rating_RefID","PropertyAssessment_Comment","DocumentHeader_RefID","RES_STR_OutdoorFacility_RequiredActionID","Action_Timeframe_RefID","IfCustom_Description","IfCustom_Name","IsCustom","Action_UnitAmount","Action_Unit_RefID","Action_PricePerUnit_RefID","SelectedActionVersion_RefID","RequiredAction_Comment","EffectivePrice_RefID","Action_Name_DictID","PriceValue_Amount" });
				while(reader.Read())
				{
					L5DD_GOFSIfRID_1454_raw resultItem = new L5DD_GOFSIfRID_1454_raw();
					//0:Parameter RES_BLD_OutdoorFacility_RefID of type Guid
					resultItem.RES_BLD_OutdoorFacility_RefID = reader.GetGuid(0);
					//1:Parameter RES_STR_OutdoorFacilityID of type Guid
					resultItem.RES_STR_OutdoorFacilityID = reader.GetGuid(1);
					//2:Parameter OutdoorF_DocumentHeader_RefID of type Guid
					resultItem.OutdoorF_DocumentHeader_RefID = reader.GetGuid(2);
					//3:Parameter OutdoorF_Comment of type String
					resultItem.OutdoorF_Comment = reader.GetString(3);
					//4:Parameter AverageRating_RefID of type Guid
					resultItem.AverageRating_RefID = reader.GetGuid(4);
					//5:Parameter NumberOfGaragePlaces of type int
					resultItem.NumberOfGaragePlaces = reader.GetInteger(5);
					//6:Parameter NumberOfRentedGaragePlaces of type int
					resultItem.NumberOfRentedGaragePlaces = reader.GetInteger(6);
					//7:Parameter TypeOfAccessRoad_RefID of type Guid
					resultItem.TypeOfAccessRoad_RefID = reader.GetGuid(7);
					//8:Parameter TypeOfFence_RefID of type Guid
					resultItem.TypeOfFence_RefID = reader.GetGuid(8);
					//9:Parameter RES_STR_OutdoorFacility_PropertyAssessmentID of type Guid
					resultItem.RES_STR_OutdoorFacility_PropertyAssessmentID = reader.GetGuid(9);
					//10:Parameter GlobalPropertyMatchingID of type String
					resultItem.GlobalPropertyMatchingID = reader.GetString(10);
					//11:Parameter RES_STR_OutdoorFacility_PropertyID of type Guid
					resultItem.RES_STR_OutdoorFacility_PropertyID = reader.GetGuid(11);
					//12:Parameter Rating_RefID of type Guid
					resultItem.Rating_RefID = reader.GetGuid(12);
					//13:Parameter PropertyAssessment_Comment of type String
					resultItem.PropertyAssessment_Comment = reader.GetString(13);
					//14:Parameter DocumentHeader_RefID of type Guid
					resultItem.DocumentHeader_RefID = reader.GetGuid(14);
					//15:Parameter RES_STR_OutdoorFacility_RequiredActionID of type Guid
					resultItem.RES_STR_OutdoorFacility_RequiredActionID = reader.GetGuid(15);
					//16:Parameter Action_Timeframe_RefID of type Guid
					resultItem.Action_Timeframe_RefID = reader.GetGuid(16);
					//17:Parameter IfCustom_Description of type String
					resultItem.IfCustom_Description = reader.GetString(17);
					//18:Parameter IfCustom_Name of type String
					resultItem.IfCustom_Name = reader.GetString(18);
					//19:Parameter IsCustom of type bool
					resultItem.IsCustom = reader.GetBoolean(19);
					//20:Parameter Action_UnitAmount of type double
					resultItem.Action_UnitAmount = reader.GetDouble(20);
					//21:Parameter Action_Unit_RefID of type Guid
					resultItem.Action_Unit_RefID = reader.GetGuid(21);
					//22:Parameter Action_PricePerUnit_RefID of type Guid
					resultItem.Action_PricePerUnit_RefID = reader.GetGuid(22);
					//23:Parameter SelectedActionVersion_RefID of type Guid
					resultItem.SelectedActionVersion_RefID = reader.GetGuid(23);
					//24:Parameter RequiredAction_Comment of type String
					resultItem.RequiredAction_Comment = reader.GetString(24);
					//25:Parameter EffectivePrice_RefID of type Guid
					resultItem.EffectivePrice_RefID = reader.GetGuid(25);
					//26:Parameter Action_Name of type Dict
					resultItem.Action_Name = reader.GetDictionary(26);
					resultItem.Action_Name.SourceTable = "res_act_action_version";
					loader.Append(resultItem.Action_Name);
					//27:Parameter PriceValue_Amount of type double
					resultItem.PriceValue_Amount = reader.GetDouble(27);

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

			returnStatus.Result = L5DD_GOFSIfRID_1454_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5DD_GOFSIfRID_1454_Array Invoke(string ConnectionString,P_L5DD_GOFSIfRID_1454 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5DD_GOFSIfRID_1454_Array Invoke(DbConnection Connection,P_L5DD_GOFSIfRID_1454 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5DD_GOFSIfRID_1454_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5DD_GOFSIfRID_1454 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5DD_GOFSIfRID_1454_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5DD_GOFSIfRID_1454 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5DD_GOFSIfRID_1454_Array functionReturn = new FR_L5DD_GOFSIfRID_1454_Array();
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
	public class L5DD_GOFSIfRID_1454_raw 
	{
		public Guid RES_BLD_OutdoorFacility_RefID; 
		public Guid RES_STR_OutdoorFacilityID; 
		public Guid OutdoorF_DocumentHeader_RefID; 
		public String OutdoorF_Comment; 
		public Guid AverageRating_RefID; 
		public int NumberOfGaragePlaces; 
		public int NumberOfRentedGaragePlaces; 
		public Guid TypeOfAccessRoad_RefID; 
		public Guid TypeOfFence_RefID; 
		public Guid RES_STR_OutdoorFacility_PropertyAssessmentID; 
		public String GlobalPropertyMatchingID; 
		public Guid RES_STR_OutdoorFacility_PropertyID; 
		public Guid Rating_RefID; 
		public String PropertyAssessment_Comment; 
		public Guid DocumentHeader_RefID; 
		public Guid RES_STR_OutdoorFacility_RequiredActionID; 
		public Guid Action_Timeframe_RefID; 
		public String IfCustom_Description; 
		public String IfCustom_Name; 
		public bool IsCustom; 
		public double Action_UnitAmount; 
		public Guid Action_Unit_RefID; 
		public Guid Action_PricePerUnit_RefID; 
		public Guid SelectedActionVersion_RefID; 
		public String RequiredAction_Comment; 
		public Guid EffectivePrice_RefID; 
		public Dict Action_Name; 
		public double PriceValue_Amount; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5DD_GOFSIfRID_1454[] Convert(List<L5DD_GOFSIfRID_1454_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5DD_GOFSIfRID_1454 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.RES_STR_OutdoorFacilityID)).ToArray()
	group el_L5DD_GOFSIfRID_1454 by new 
	{ 
		el_L5DD_GOFSIfRID_1454.RES_STR_OutdoorFacilityID,

	}
	into gfunct_L5DD_GOFSIfRID_1454
	select new L5DD_GOFSIfRID_1454
	{     
		RES_BLD_OutdoorFacility_RefID = gfunct_L5DD_GOFSIfRID_1454.FirstOrDefault().RES_BLD_OutdoorFacility_RefID ,
		RES_STR_OutdoorFacilityID = gfunct_L5DD_GOFSIfRID_1454.Key.RES_STR_OutdoorFacilityID ,
		OutdoorF_DocumentHeader_RefID = gfunct_L5DD_GOFSIfRID_1454.FirstOrDefault().OutdoorF_DocumentHeader_RefID ,
		OutdoorF_Comment = gfunct_L5DD_GOFSIfRID_1454.FirstOrDefault().OutdoorF_Comment ,
		AverageRating_RefID = gfunct_L5DD_GOFSIfRID_1454.FirstOrDefault().AverageRating_RefID ,
		NumberOfGaragePlaces = gfunct_L5DD_GOFSIfRID_1454.FirstOrDefault().NumberOfGaragePlaces ,
		NumberOfRentedGaragePlaces = gfunct_L5DD_GOFSIfRID_1454.FirstOrDefault().NumberOfRentedGaragePlaces ,
		TypeOfAccessRoad_RefID = gfunct_L5DD_GOFSIfRID_1454.FirstOrDefault().TypeOfAccessRoad_RefID ,
		TypeOfFence_RefID = gfunct_L5DD_GOFSIfRID_1454.FirstOrDefault().TypeOfFence_RefID ,

		OutdoorFacilityAsessments = 
		(
			from el_OutdoorFacilityAsessments in gfunct_L5DD_GOFSIfRID_1454.Where(element => !EqualsDefaultValue(element.RES_STR_OutdoorFacility_PropertyAssessmentID)).ToArray()
			group el_OutdoorFacilityAsessments by new 
			{ 
				el_OutdoorFacilityAsessments.RES_STR_OutdoorFacility_PropertyAssessmentID,

			}
			into gfunct_OutdoorFacilityAsessments
			select new L5DD_GOFSIfRID_1454_OutdoorFacilityPropertyAsessment
			{     
				RES_STR_OutdoorFacility_PropertyAssessmentID = gfunct_OutdoorFacilityAsessments.Key.RES_STR_OutdoorFacility_PropertyAssessmentID ,
				GlobalPropertyMatchingID = gfunct_OutdoorFacilityAsessments.FirstOrDefault().GlobalPropertyMatchingID ,
				RES_STR_OutdoorFacility_PropertyID = gfunct_OutdoorFacilityAsessments.FirstOrDefault().RES_STR_OutdoorFacility_PropertyID ,
				Rating_RefID = gfunct_OutdoorFacilityAsessments.FirstOrDefault().Rating_RefID ,
				PropertyAssessment_Comment = gfunct_OutdoorFacilityAsessments.FirstOrDefault().PropertyAssessment_Comment ,
				DocumentHeader_RefID = gfunct_OutdoorFacilityAsessments.FirstOrDefault().DocumentHeader_RefID ,

				OutdoorFacilityReqActions = 
				(
					from el_OutdoorFacilityReqActions in gfunct_OutdoorFacilityAsessments.Where(element => !EqualsDefaultValue(element.RES_STR_OutdoorFacility_RequiredActionID)).ToArray()
					group el_OutdoorFacilityReqActions by new 
					{ 
						el_OutdoorFacilityReqActions.RES_STR_OutdoorFacility_RequiredActionID,

					}
					into gfunct_OutdoorFacilityReqActions
					select new L5DD_GOFSIfRID_1454_OutdoorFacilityReqAction
					{     
						RES_STR_OutdoorFacility_RequiredActionID = gfunct_OutdoorFacilityReqActions.Key.RES_STR_OutdoorFacility_RequiredActionID ,
						Action_Timeframe_RefID = gfunct_OutdoorFacilityReqActions.FirstOrDefault().Action_Timeframe_RefID ,
						IfCustom_Description = gfunct_OutdoorFacilityReqActions.FirstOrDefault().IfCustom_Description ,
						IfCustom_Name = gfunct_OutdoorFacilityReqActions.FirstOrDefault().IfCustom_Name ,
						IsCustom = gfunct_OutdoorFacilityReqActions.FirstOrDefault().IsCustom ,
						Action_UnitAmount = gfunct_OutdoorFacilityReqActions.FirstOrDefault().Action_UnitAmount ,
						Action_Unit_RefID = gfunct_OutdoorFacilityReqActions.FirstOrDefault().Action_Unit_RefID ,
						Action_PricePerUnit_RefID = gfunct_OutdoorFacilityReqActions.FirstOrDefault().Action_PricePerUnit_RefID ,
						SelectedActionVersion_RefID = gfunct_OutdoorFacilityReqActions.FirstOrDefault().SelectedActionVersion_RefID ,
						RequiredAction_Comment = gfunct_OutdoorFacilityReqActions.FirstOrDefault().RequiredAction_Comment ,
						EffectivePrice_RefID = gfunct_OutdoorFacilityReqActions.FirstOrDefault().EffectivePrice_RefID ,
						Action_Name = gfunct_OutdoorFacilityReqActions.FirstOrDefault().Action_Name ,
						PriceValue_Amount = gfunct_OutdoorFacilityReqActions.FirstOrDefault().PriceValue_Amount ,

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
	public class FR_L5DD_GOFSIfRID_1454_Array : FR_Base
	{
		public L5DD_GOFSIfRID_1454[] Result	{ get; set; } 
		public FR_L5DD_GOFSIfRID_1454_Array() : base() {}

		public FR_L5DD_GOFSIfRID_1454_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5DD_GOFSIfRID_1454 for attribute P_L5DD_GOFSIfRID_1454
		[DataContract]
		public class P_L5DD_GOFSIfRID_1454 
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
		#region SClass L5DD_GOFSIfRID_1454 for attribute L5DD_GOFSIfRID_1454
		[DataContract]
		public class L5DD_GOFSIfRID_1454 
		{
			[DataMember]
			public L5DD_GOFSIfRID_1454_OutdoorFacilityPropertyAsessment[] OutdoorFacilityAsessments { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid RES_BLD_OutdoorFacility_RefID { get; set; } 
			[DataMember]
			public Guid RES_STR_OutdoorFacilityID { get; set; } 
			[DataMember]
			public Guid OutdoorF_DocumentHeader_RefID { get; set; } 
			[DataMember]
			public String OutdoorF_Comment { get; set; } 
			[DataMember]
			public Guid AverageRating_RefID { get; set; } 
			[DataMember]
			public int NumberOfGaragePlaces { get; set; } 
			[DataMember]
			public int NumberOfRentedGaragePlaces { get; set; } 
			[DataMember]
			public Guid TypeOfAccessRoad_RefID { get; set; } 
			[DataMember]
			public Guid TypeOfFence_RefID { get; set; } 

		}
		#endregion
		#region SClass L5DD_GOFSIfRID_1454_OutdoorFacilityPropertyAsessment for attribute OutdoorFacilityAsessments
		[DataContract]
		public class L5DD_GOFSIfRID_1454_OutdoorFacilityPropertyAsessment 
		{
			[DataMember]
			public L5DD_GOFSIfRID_1454_OutdoorFacilityReqAction[] OutdoorFacilityReqActions { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid RES_STR_OutdoorFacility_PropertyAssessmentID { get; set; } 
			[DataMember]
			public String GlobalPropertyMatchingID { get; set; } 
			[DataMember]
			public Guid RES_STR_OutdoorFacility_PropertyID { get; set; } 
			[DataMember]
			public Guid Rating_RefID { get; set; } 
			[DataMember]
			public String PropertyAssessment_Comment { get; set; } 
			[DataMember]
			public Guid DocumentHeader_RefID { get; set; } 

		}
		#endregion
		#region SClass L5DD_GOFSIfRID_1454_OutdoorFacilityReqAction for attribute OutdoorFacilityReqActions
		[DataContract]
		public class L5DD_GOFSIfRID_1454_OutdoorFacilityReqAction 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_STR_OutdoorFacility_RequiredActionID { get; set; } 
			[DataMember]
			public Guid Action_Timeframe_RefID { get; set; } 
			[DataMember]
			public String IfCustom_Description { get; set; } 
			[DataMember]
			public String IfCustom_Name { get; set; } 
			[DataMember]
			public bool IsCustom { get; set; } 
			[DataMember]
			public double Action_UnitAmount { get; set; } 
			[DataMember]
			public Guid Action_Unit_RefID { get; set; } 
			[DataMember]
			public Guid Action_PricePerUnit_RefID { get; set; } 
			[DataMember]
			public Guid SelectedActionVersion_RefID { get; set; } 
			[DataMember]
			public String RequiredAction_Comment { get; set; } 
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
FR_L5DD_GOFSIfRID_1454_Array cls_Get_OutdoorFascilitySubmisionInfo_For_RevisionID(P_L5DD_GOFSIfRID_1454 Parameter,string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_L5DD_GOFSIfRID_1454_Array result = cls_Get_OutdoorFascilitySubmisionInfo_For_RevisionID.Invoke(connectionString,P_L5DD_GOFSIfRID_1454 Parameter,securityTicket);
	 return result;
}
*/