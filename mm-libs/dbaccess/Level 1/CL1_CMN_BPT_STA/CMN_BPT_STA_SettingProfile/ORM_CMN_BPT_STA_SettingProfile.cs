/* 
 * Generated on 05-Nov-13 10:06:07
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_CMN_BPT_STA
{
	[Serializable]
	public class ORM_CMN_BPT_STA_SettingProfile
	{
		public static readonly string TableName = "cmn_bpt_sta_settingprofiles";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_CMN_BPT_STA_SettingProfile()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_CMN_BPT_STA_SettingProfileID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _CMN_BPT_STA_SettingProfileID = default(Guid);
		private Dict _StafMember_Caption = new Dict(TableName);
		private Boolean _IsLeaveTimeCalculated_InDays = default(Boolean);
		private Boolean _IsLeaveTimeCalculated_InHours = default(Boolean);
		private Boolean _IsUsingWorkflow_ForLeaveRequests = default(Boolean);
		private int _Default_AdulthoodAge = default(int);
		private Boolean _Default_SurchargeCalculation_UseMaximum = default(Boolean);
		private Boolean _Default_SurchargeCalculation_UseAccumulated = default(Boolean);
		private int _Default_RestWarningThreshold_Adults_in_mins = default(int);
		private int _Default_RestWarningThreshold_NonAdults_in_mins = default(int);
		private int _Default_RestMinimumThresholdl_Adults_in_mins = default(int);
		private int _Default_RestMinimumThresholdl_NonAdults_in_mins = default(int);
		private int _Default_WorkTimeWarningTreshold_Adults_in_mins = default(int);
		private int _Default_WorkTimeWarningTreshold_NonAdults_in_mins = default(int);
		private int _Default_WorkTimeMaximumTreshold_Adults_in_mins = default(int);
		private int _Default_WorkTimeMaximumTreshold_NonAdults_in_mins = default(int);
		private int _Default_WorkStartTimeWarning_NonAdults_in_mins = default(int);
		private int _Default_WorkStartTimeMinimum_NonAdults_in_mins = default(int);
		private int _Default_WorkEndTimeWarning_NonAdults_in_mins = default(int);
		private int _Default_WorkEndTimeMaximum_NonAdults_in_mins = default(int);
		private int _Default_WorktimeBalancePeriod_in_months = default(int);
		private int _Default_WorkdayStart_in_mins = default(int);
		private int _Default_RoosterGridMinimumPlanningUnit_in_mins = default(int);
		private int _Default_MaximumPreWork_Period_in_mins = default(int);
		private int _Default_MaximumPostWork_Period_in_mins = default(int);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Boolean _IsDeleted = default(Boolean);
		private Guid _Tenant_RefID = default(Guid);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid CMN_BPT_STA_SettingProfileID { 
			get {
				return _CMN_BPT_STA_SettingProfileID;
			}
			set {
				if(_CMN_BPT_STA_SettingProfileID != value){
					_CMN_BPT_STA_SettingProfileID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Dict StafMember_Caption { 
			get {
				return _StafMember_Caption;
			}
			set {
				if(_StafMember_Caption != value){
					_StafMember_Caption = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsLeaveTimeCalculated_InDays { 
			get {
				return _IsLeaveTimeCalculated_InDays;
			}
			set {
				if(_IsLeaveTimeCalculated_InDays != value){
					_IsLeaveTimeCalculated_InDays = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsLeaveTimeCalculated_InHours { 
			get {
				return _IsLeaveTimeCalculated_InHours;
			}
			set {
				if(_IsLeaveTimeCalculated_InHours != value){
					_IsLeaveTimeCalculated_InHours = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsUsingWorkflow_ForLeaveRequests { 
			get {
				return _IsUsingWorkflow_ForLeaveRequests;
			}
			set {
				if(_IsUsingWorkflow_ForLeaveRequests != value){
					_IsUsingWorkflow_ForLeaveRequests = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int Default_AdulthoodAge { 
			get {
				return _Default_AdulthoodAge;
			}
			set {
				if(_Default_AdulthoodAge != value){
					_Default_AdulthoodAge = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean Default_SurchargeCalculation_UseMaximum { 
			get {
				return _Default_SurchargeCalculation_UseMaximum;
			}
			set {
				if(_Default_SurchargeCalculation_UseMaximum != value){
					_Default_SurchargeCalculation_UseMaximum = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean Default_SurchargeCalculation_UseAccumulated { 
			get {
				return _Default_SurchargeCalculation_UseAccumulated;
			}
			set {
				if(_Default_SurchargeCalculation_UseAccumulated != value){
					_Default_SurchargeCalculation_UseAccumulated = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int Default_RestWarningThreshold_Adults_in_mins { 
			get {
				return _Default_RestWarningThreshold_Adults_in_mins;
			}
			set {
				if(_Default_RestWarningThreshold_Adults_in_mins != value){
					_Default_RestWarningThreshold_Adults_in_mins = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int Default_RestWarningThreshold_NonAdults_in_mins { 
			get {
				return _Default_RestWarningThreshold_NonAdults_in_mins;
			}
			set {
				if(_Default_RestWarningThreshold_NonAdults_in_mins != value){
					_Default_RestWarningThreshold_NonAdults_in_mins = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int Default_RestMinimumThresholdl_Adults_in_mins { 
			get {
				return _Default_RestMinimumThresholdl_Adults_in_mins;
			}
			set {
				if(_Default_RestMinimumThresholdl_Adults_in_mins != value){
					_Default_RestMinimumThresholdl_Adults_in_mins = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int Default_RestMinimumThresholdl_NonAdults_in_mins { 
			get {
				return _Default_RestMinimumThresholdl_NonAdults_in_mins;
			}
			set {
				if(_Default_RestMinimumThresholdl_NonAdults_in_mins != value){
					_Default_RestMinimumThresholdl_NonAdults_in_mins = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int Default_WorkTimeWarningTreshold_Adults_in_mins { 
			get {
				return _Default_WorkTimeWarningTreshold_Adults_in_mins;
			}
			set {
				if(_Default_WorkTimeWarningTreshold_Adults_in_mins != value){
					_Default_WorkTimeWarningTreshold_Adults_in_mins = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int Default_WorkTimeWarningTreshold_NonAdults_in_mins { 
			get {
				return _Default_WorkTimeWarningTreshold_NonAdults_in_mins;
			}
			set {
				if(_Default_WorkTimeWarningTreshold_NonAdults_in_mins != value){
					_Default_WorkTimeWarningTreshold_NonAdults_in_mins = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int Default_WorkTimeMaximumTreshold_Adults_in_mins { 
			get {
				return _Default_WorkTimeMaximumTreshold_Adults_in_mins;
			}
			set {
				if(_Default_WorkTimeMaximumTreshold_Adults_in_mins != value){
					_Default_WorkTimeMaximumTreshold_Adults_in_mins = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int Default_WorkTimeMaximumTreshold_NonAdults_in_mins { 
			get {
				return _Default_WorkTimeMaximumTreshold_NonAdults_in_mins;
			}
			set {
				if(_Default_WorkTimeMaximumTreshold_NonAdults_in_mins != value){
					_Default_WorkTimeMaximumTreshold_NonAdults_in_mins = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int Default_WorkStartTimeWarning_NonAdults_in_mins { 
			get {
				return _Default_WorkStartTimeWarning_NonAdults_in_mins;
			}
			set {
				if(_Default_WorkStartTimeWarning_NonAdults_in_mins != value){
					_Default_WorkStartTimeWarning_NonAdults_in_mins = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int Default_WorkStartTimeMinimum_NonAdults_in_mins { 
			get {
				return _Default_WorkStartTimeMinimum_NonAdults_in_mins;
			}
			set {
				if(_Default_WorkStartTimeMinimum_NonAdults_in_mins != value){
					_Default_WorkStartTimeMinimum_NonAdults_in_mins = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int Default_WorkEndTimeWarning_NonAdults_in_mins { 
			get {
				return _Default_WorkEndTimeWarning_NonAdults_in_mins;
			}
			set {
				if(_Default_WorkEndTimeWarning_NonAdults_in_mins != value){
					_Default_WorkEndTimeWarning_NonAdults_in_mins = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int Default_WorkEndTimeMaximum_NonAdults_in_mins { 
			get {
				return _Default_WorkEndTimeMaximum_NonAdults_in_mins;
			}
			set {
				if(_Default_WorkEndTimeMaximum_NonAdults_in_mins != value){
					_Default_WorkEndTimeMaximum_NonAdults_in_mins = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int Default_WorktimeBalancePeriod_in_months { 
			get {
				return _Default_WorktimeBalancePeriod_in_months;
			}
			set {
				if(_Default_WorktimeBalancePeriod_in_months != value){
					_Default_WorktimeBalancePeriod_in_months = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int Default_WorkdayStart_in_mins { 
			get {
				return _Default_WorkdayStart_in_mins;
			}
			set {
				if(_Default_WorkdayStart_in_mins != value){
					_Default_WorkdayStart_in_mins = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int Default_RoosterGridMinimumPlanningUnit_in_mins { 
			get {
				return _Default_RoosterGridMinimumPlanningUnit_in_mins;
			}
			set {
				if(_Default_RoosterGridMinimumPlanningUnit_in_mins != value){
					_Default_RoosterGridMinimumPlanningUnit_in_mins = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int Default_MaximumPreWork_Period_in_mins { 
			get {
				return _Default_MaximumPreWork_Period_in_mins;
			}
			set {
				if(_Default_MaximumPreWork_Period_in_mins != value){
					_Default_MaximumPreWork_Period_in_mins = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int Default_MaximumPostWork_Period_in_mins { 
			get {
				return _Default_MaximumPostWork_Period_in_mins;
			}
			set {
				if(_Default_MaximumPostWork_Period_in_mins != value){
					_Default_MaximumPostWork_Period_in_mins = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime Creation_Timestamp { 
			get {
				return _Creation_Timestamp;
			}
			set {
				if(_Creation_Timestamp != value){
					_Creation_Timestamp = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsDeleted { 
			get {
				return _IsDeleted;
			}
			set {
				if(_IsDeleted != value){
					_IsDeleted = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Tenant_RefID { 
			get {
				return _Tenant_RefID;
			}
			set {
				if(_Tenant_RefID != value){
					_Tenant_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		 
		#endregion


		#region Save (Create/Update) Functions	
		public FR_Base Save(string DbConnectionString)
		{
			return Save(null, null, DbConnectionString);
		}

		public FR_Base Save(DbConnection Connection)
		{
			return Save(Connection, null, null);
		}

		public FR_Base Save(DbConnection Connection, DbTransaction Transaction)
		{
			return Save(Connection, Transaction, null);
		}

		protected FR_Base Save(DbConnection Connection, DbTransaction Transaction, string ConnectionString)
		{
			//Standard return type
			FR_Base retStatus = new FR_Base();

			bool cleanupConnection = false;
			bool cleanupTransaction = false;
			try
			{

				bool saveDictionary = !Status_IsAlreadySaved || StafMember_Caption.IsDirty ;
			    bool saveORMClass =   !Status_IsAlreadySaved || Status_IsDirty;


				//If Status Is Dirty (Meaning the data has been changed) or Status_IsAlreadySaved (Meaning the data is in the database, when loaded) just return
				if (saveORMClass == false && saveDictionary == false)
			    {
			        return FR_Base.Status_OK;
			    }


				#region Verify/Create Connections
				//Create Connection if Connection is null
				if (Connection == null)
				{
					cleanupConnection = true;
					Connection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(ConnectionString);
					Connection.Open();
				}

				//Create Transaction if null
				if (Transaction == null)
				{
					cleanupTransaction = true;
					Transaction = Connection.BeginTransaction();
				}

				#endregion

				#region Dictionary Management

				//Save dictionary management
				 if (saveDictionary == true)
				{ 
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
								loader.Append(StafMember_Caption,TableName);

					//Save the dictionary or update based on if it has already been saved to the database
					if (Status_IsAlreadySaved)
			        {
			            loader.Update();
			        }
			        else
			        {
			            loader.Save();
			        }
				}
				#endregion

				#region Command Execution
				if (saveORMClass == true) { 
					//Retrieve Querry
					string Query = "";

					if (Status_IsAlreadySaved == true)
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_BPT_STA.CMN_BPT_STA_SettingProfile.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_BPT_STA.CMN_BPT_STA_SettingProfile.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_BPT_STA_SettingProfileID", _CMN_BPT_STA_SettingProfileID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "StafMember_Caption", _StafMember_Caption.DictionaryID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsLeaveTimeCalculated_InDays", _IsLeaveTimeCalculated_InDays);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsLeaveTimeCalculated_InHours", _IsLeaveTimeCalculated_InHours);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsUsingWorkflow_ForLeaveRequests", _IsUsingWorkflow_ForLeaveRequests);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Default_AdulthoodAge", _Default_AdulthoodAge);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Default_SurchargeCalculation_UseMaximum", _Default_SurchargeCalculation_UseMaximum);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Default_SurchargeCalculation_UseAccumulated", _Default_SurchargeCalculation_UseAccumulated);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Default_RestWarningThreshold_Adults_in_mins", _Default_RestWarningThreshold_Adults_in_mins);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Default_RestWarningThreshold_NonAdults_in_mins", _Default_RestWarningThreshold_NonAdults_in_mins);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Default_RestMinimumThresholdl_Adults_in_mins", _Default_RestMinimumThresholdl_Adults_in_mins);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Default_RestMinimumThresholdl_NonAdults_in_mins", _Default_RestMinimumThresholdl_NonAdults_in_mins);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Default_WorkTimeWarningTreshold_Adults_in_mins", _Default_WorkTimeWarningTreshold_Adults_in_mins);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Default_WorkTimeWarningTreshold_NonAdults_in_mins", _Default_WorkTimeWarningTreshold_NonAdults_in_mins);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Default_WorkTimeMaximumTreshold_Adults_in_mins", _Default_WorkTimeMaximumTreshold_Adults_in_mins);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Default_WorkTimeMaximumTreshold_NonAdults_in_mins", _Default_WorkTimeMaximumTreshold_NonAdults_in_mins);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Default_WorkStartTimeWarning_NonAdults_in_mins", _Default_WorkStartTimeWarning_NonAdults_in_mins);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Default_WorkStartTimeMinimum_NonAdults_in_mins", _Default_WorkStartTimeMinimum_NonAdults_in_mins);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Default_WorkEndTimeWarning_NonAdults_in_mins", _Default_WorkEndTimeWarning_NonAdults_in_mins);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Default_WorkEndTimeMaximum_NonAdults_in_mins", _Default_WorkEndTimeMaximum_NonAdults_in_mins);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Default_WorktimeBalancePeriod_in_months", _Default_WorktimeBalancePeriod_in_months);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Default_WorkdayStart_in_mins", _Default_WorkdayStart_in_mins);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Default_RoosterGridMinimumPlanningUnit_in_mins", _Default_RoosterGridMinimumPlanningUnit_in_mins);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Default_MaximumPreWork_Period_in_mins", _Default_MaximumPreWork_Period_in_mins);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Default_MaximumPostWork_Period_in_mins", _Default_MaximumPostWork_Period_in_mins);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Creation_Timestamp", _Creation_Timestamp);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsDeleted", _IsDeleted);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Tenant_RefID", _Tenant_RefID);


					try
					{
						var dbChangeCount = command.ExecuteNonQuery();
						Status_IsAlreadySaved = true;
						Status_IsDirty = false;
					}
					catch (Exception ex)
					{
						throw ex;
					}
					#endregion

					#region Cleanup Transaction/Connection
					//If we started the transaction, we will commit it
					if (cleanupTransaction && Transaction!= null)
						Transaction.Commit();

					//If we opened the connection we will close it
					if (cleanupConnection && Connection != null)
						Connection.Close();
				}
				#endregion

			}
			catch (Exception ex)
			{
				try
				{
					if (cleanupTransaction == true && Transaction != null)
						Transaction.Rollback();
				}
				catch { }

				try
				{
					if (cleanupConnection == true && Connection != null)
						Connection.Close();
				}
				catch { }

				throw ex;
			}

			return retStatus;
		}
		#endregion

		#region Load Functions
		public FR_Base Load(string DbConnectionString, Guid ObjectID)
		{
			return Load(null, null, ObjectID, DbConnectionString);
		}

		public FR_Base Load(DbConnection Connection, Guid ObjectID)
		{
			return Load(Connection, null, ObjectID, null);
		}

		public FR_Base Load(DbConnection Connection, DbTransaction Transaction, Guid ObjectID)
		{
			return Load(Connection, Transaction, ObjectID, null);
		}

		private FR_Base Load(DbConnection Connection, DbTransaction Transaction, Guid ObjectID, string ConnectionString)
		{
			//Standard return type
			FR_Base retStatus = new FR_Base();

			bool cleanupConnection = false;
			bool cleanupTransaction = false;
			try
			{
				#region Verify/Create Connections
				//Create connection if Connection is null
				if(Connection == null)
				{
					cleanupConnection = true;
					Connection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(ConnectionString);
					Connection.Open();
				}
				//If transaction is not open/not valid
				if(Transaction == null)
				{
					cleanupTransaction = true;
					Transaction = Connection.BeginTransaction();
				}
				#endregion
				//Get the SelectQuerry
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_BPT_STA.CMN_BPT_STA_SettingProfile.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_CMN_BPT_STA_SettingProfileID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CMN_BPT_STA_SettingProfileID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_BPT_STA_SettingProfileID","StafMember_Caption_DictID","IsLeaveTimeCalculated_InDays","IsLeaveTimeCalculated_InHours","IsUsingWorkflow_ForLeaveRequests","Default_AdulthoodAge","Default_SurchargeCalculation_UseMaximum","Default_SurchargeCalculation_UseAccumulated","Default_RestWarningThreshold_Adults_in_mins","Default_RestWarningThreshold_NonAdults_in_mins","Default_RestMinimumThresholdl_Adults_in_mins","Default_RestMinimumThresholdl_NonAdults_in_mins","Default_WorkTimeWarningTreshold_Adults_in_mins","Default_WorkTimeWarningTreshold_NonAdults_in_mins","Default_WorkTimeMaximumTreshold_Adults_in_mins","Default_WorkTimeMaximumTreshold_NonAdults_in_mins","Default_WorkStartTimeWarning_NonAdults_in_mins","Default_WorkStartTimeMinimum_NonAdults_in_mins","Default_WorkEndTimeWarning_NonAdults_in_mins","Default_WorkEndTimeMaximum_NonAdults_in_mins","Default_WorktimeBalancePeriod_in_months","Default_WorkdayStart_in_mins","Default_RoosterGridMinimumPlanningUnit_in_mins","Default_MaximumPreWork_Period_in_mins","Default_MaximumPostWork_Period_in_mins","Creation_Timestamp","IsDeleted","Tenant_RefID" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter CMN_BPT_STA_SettingProfileID of type Guid
						_CMN_BPT_STA_SettingProfileID = reader.GetGuid(0);
						//1:Parameter StafMember_Caption of type Dict
						_StafMember_Caption = reader.GetDictionary(1);
						loader.Append(_StafMember_Caption,TableName);
						//2:Parameter IsLeaveTimeCalculated_InDays of type Boolean
						_IsLeaveTimeCalculated_InDays = reader.GetBoolean(2);
						//3:Parameter IsLeaveTimeCalculated_InHours of type Boolean
						_IsLeaveTimeCalculated_InHours = reader.GetBoolean(3);
						//4:Parameter IsUsingWorkflow_ForLeaveRequests of type Boolean
						_IsUsingWorkflow_ForLeaveRequests = reader.GetBoolean(4);
						//5:Parameter Default_AdulthoodAge of type int
						_Default_AdulthoodAge = reader.GetInteger(5);
						//6:Parameter Default_SurchargeCalculation_UseMaximum of type Boolean
						_Default_SurchargeCalculation_UseMaximum = reader.GetBoolean(6);
						//7:Parameter Default_SurchargeCalculation_UseAccumulated of type Boolean
						_Default_SurchargeCalculation_UseAccumulated = reader.GetBoolean(7);
						//8:Parameter Default_RestWarningThreshold_Adults_in_mins of type int
						_Default_RestWarningThreshold_Adults_in_mins = reader.GetInteger(8);
						//9:Parameter Default_RestWarningThreshold_NonAdults_in_mins of type int
						_Default_RestWarningThreshold_NonAdults_in_mins = reader.GetInteger(9);
						//10:Parameter Default_RestMinimumThresholdl_Adults_in_mins of type int
						_Default_RestMinimumThresholdl_Adults_in_mins = reader.GetInteger(10);
						//11:Parameter Default_RestMinimumThresholdl_NonAdults_in_mins of type int
						_Default_RestMinimumThresholdl_NonAdults_in_mins = reader.GetInteger(11);
						//12:Parameter Default_WorkTimeWarningTreshold_Adults_in_mins of type int
						_Default_WorkTimeWarningTreshold_Adults_in_mins = reader.GetInteger(12);
						//13:Parameter Default_WorkTimeWarningTreshold_NonAdults_in_mins of type int
						_Default_WorkTimeWarningTreshold_NonAdults_in_mins = reader.GetInteger(13);
						//14:Parameter Default_WorkTimeMaximumTreshold_Adults_in_mins of type int
						_Default_WorkTimeMaximumTreshold_Adults_in_mins = reader.GetInteger(14);
						//15:Parameter Default_WorkTimeMaximumTreshold_NonAdults_in_mins of type int
						_Default_WorkTimeMaximumTreshold_NonAdults_in_mins = reader.GetInteger(15);
						//16:Parameter Default_WorkStartTimeWarning_NonAdults_in_mins of type int
						_Default_WorkStartTimeWarning_NonAdults_in_mins = reader.GetInteger(16);
						//17:Parameter Default_WorkStartTimeMinimum_NonAdults_in_mins of type int
						_Default_WorkStartTimeMinimum_NonAdults_in_mins = reader.GetInteger(17);
						//18:Parameter Default_WorkEndTimeWarning_NonAdults_in_mins of type int
						_Default_WorkEndTimeWarning_NonAdults_in_mins = reader.GetInteger(18);
						//19:Parameter Default_WorkEndTimeMaximum_NonAdults_in_mins of type int
						_Default_WorkEndTimeMaximum_NonAdults_in_mins = reader.GetInteger(19);
						//20:Parameter Default_WorktimeBalancePeriod_in_months of type int
						_Default_WorktimeBalancePeriod_in_months = reader.GetInteger(20);
						//21:Parameter Default_WorkdayStart_in_mins of type int
						_Default_WorkdayStart_in_mins = reader.GetInteger(21);
						//22:Parameter Default_RoosterGridMinimumPlanningUnit_in_mins of type int
						_Default_RoosterGridMinimumPlanningUnit_in_mins = reader.GetInteger(22);
						//23:Parameter Default_MaximumPreWork_Period_in_mins of type int
						_Default_MaximumPreWork_Period_in_mins = reader.GetInteger(23);
						//24:Parameter Default_MaximumPostWork_Period_in_mins of type int
						_Default_MaximumPostWork_Period_in_mins = reader.GetInteger(24);
						//25:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(25);
						//26:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(26);
						//27:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(27);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_CMN_BPT_STA_SettingProfileID != Guid.Empty){
						//Successfully loaded
						Status_IsAlreadySaved = true;
						Status_IsDirty = false;
					} else {
						//Fault in loading due to invalid UUID (Guid)
						Status_IsAlreadySaved = false;
						Status_IsDirty = false;
					}
				}
				catch (Exception ex)
				{
					throw ex;
				}
				#endregion

				#region Cleanup Transaction/Connection
				//If we started the transaction, we will commit it
				if (cleanupTransaction && Transaction!= null)
					Transaction.Commit();

				//If we opened the connection we will close it
				if (cleanupConnection && Connection != null)
					Connection.Close();

				#endregion

			} catch (Exception ex) {
				try
				{
					if (cleanupTransaction == true && Transaction != null)
						Transaction.Rollback();
				}
				catch { }

				try
				{
					if (cleanupConnection == true && Connection != null)
						Connection.Close();
				}
				catch { }

				throw ex;
			}

			return retStatus;
		}
		#endregion

		#region Remove Functions
		public FR_Base Remove(string DbConnectionString)
		{
			return Remove(null, null, DbConnectionString);
		}

		public FR_Base Remove(DbConnection Connection)
		{
			return Remove(Connection, null, null);
		}

		public FR_Base Remove(DbConnection Connection, DbTransaction Transaction)
		{
			return Remove(Connection, Transaction, null);
		}

		public FR_Base Remove(DbConnection Connection, DbTransaction Transaction, string ConnectionString)
		{
			this.IsDeleted = true;
			return this.Save(Connection, Transaction, ConnectionString);

		}
		#endregion


		#region Custom Queries
		public class Query : CSV2Core_MySQL.BaseFilterQuery<Query>
        {
			public Guid? CMN_BPT_STA_SettingProfileID {	get; set; }
			public Dict StafMember_Caption {	get; set; }
			public Boolean? IsLeaveTimeCalculated_InDays {	get; set; }
			public Boolean? IsLeaveTimeCalculated_InHours {	get; set; }
			public Boolean? IsUsingWorkflow_ForLeaveRequests {	get; set; }
			public int? Default_AdulthoodAge {	get; set; }
			public Boolean? Default_SurchargeCalculation_UseMaximum {	get; set; }
			public Boolean? Default_SurchargeCalculation_UseAccumulated {	get; set; }
			public int? Default_RestWarningThreshold_Adults_in_mins {	get; set; }
			public int? Default_RestWarningThreshold_NonAdults_in_mins {	get; set; }
			public int? Default_RestMinimumThresholdl_Adults_in_mins {	get; set; }
			public int? Default_RestMinimumThresholdl_NonAdults_in_mins {	get; set; }
			public int? Default_WorkTimeWarningTreshold_Adults_in_mins {	get; set; }
			public int? Default_WorkTimeWarningTreshold_NonAdults_in_mins {	get; set; }
			public int? Default_WorkTimeMaximumTreshold_Adults_in_mins {	get; set; }
			public int? Default_WorkTimeMaximumTreshold_NonAdults_in_mins {	get; set; }
			public int? Default_WorkStartTimeWarning_NonAdults_in_mins {	get; set; }
			public int? Default_WorkStartTimeMinimum_NonAdults_in_mins {	get; set; }
			public int? Default_WorkEndTimeWarning_NonAdults_in_mins {	get; set; }
			public int? Default_WorkEndTimeMaximum_NonAdults_in_mins {	get; set; }
			public int? Default_WorktimeBalancePeriod_in_months {	get; set; }
			public int? Default_WorkdayStart_in_mins {	get; set; }
			public int? Default_RoosterGridMinimumPlanningUnit_in_mins {	get; set; }
			public int? Default_MaximumPreWork_Period_in_mins {	get; set; }
			public int? Default_MaximumPostWork_Period_in_mins {	get; set; }
			public DateTime? Creation_Timestamp {	get; set; }
			public Boolean? IsDeleted {	get; set; }
			public Guid? Tenant_RefID {	get; set; }
			 

			#region Exists
			public static bool Exists(string connectionString, Query query)
			{
			    return Query.Exists(query, connectionString, null, null);
			}

			public static bool Exists(DbConnection connection, Query query)
			{
			    return Query.Exists(query, null, connection, null);
			}

			public static bool Exists(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Exists(query, null, connection, transaction);
			}

			private static bool Exists(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
				try
				{
					managedConnection.set(connectionString, connection, transaction);
					DbCommand command = managedConnection.manage(query.CreateExistsQuery(TableName));
					query.SetParameters(command);

					var reader = command.ExecuteReader();
					reader.Read();
					int resultCount = reader.GetInt32(0);
					reader.Close();
					managedConnection.commit();
					return resultCount == 1;
				} 
				catch(Exception ex)
				{
					managedConnection.rollback();
					throw ex;
				}
			}
			#endregion

			#region Search
			public static List<ORM_CMN_BPT_STA_SettingProfile> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_CMN_BPT_STA_SettingProfile> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_CMN_BPT_STA_SettingProfile> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_CMN_BPT_STA_SettingProfile> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_CMN_BPT_STA_SettingProfile> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_CMN_BPT_STA_SettingProfile>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_BPT_STA_SettingProfileID","StafMember_Caption_DictID","IsLeaveTimeCalculated_InDays","IsLeaveTimeCalculated_InHours","IsUsingWorkflow_ForLeaveRequests","Default_AdulthoodAge","Default_SurchargeCalculation_UseMaximum","Default_SurchargeCalculation_UseAccumulated","Default_RestWarningThreshold_Adults_in_mins","Default_RestWarningThreshold_NonAdults_in_mins","Default_RestMinimumThresholdl_Adults_in_mins","Default_RestMinimumThresholdl_NonAdults_in_mins","Default_WorkTimeWarningTreshold_Adults_in_mins","Default_WorkTimeWarningTreshold_NonAdults_in_mins","Default_WorkTimeMaximumTreshold_Adults_in_mins","Default_WorkTimeMaximumTreshold_NonAdults_in_mins","Default_WorkStartTimeWarning_NonAdults_in_mins","Default_WorkStartTimeMinimum_NonAdults_in_mins","Default_WorkEndTimeWarning_NonAdults_in_mins","Default_WorkEndTimeMaximum_NonAdults_in_mins","Default_WorktimeBalancePeriod_in_months","Default_WorkdayStart_in_mins","Default_RoosterGridMinimumPlanningUnit_in_mins","Default_MaximumPreWork_Period_in_mins","Default_MaximumPostWork_Period_in_mins","Creation_Timestamp","IsDeleted","Tenant_RefID" });
			        while (reader.Read())
			        {
			            ORM_CMN_BPT_STA_SettingProfile item = new ORM_CMN_BPT_STA_SettingProfile();
						//0:Parameter CMN_BPT_STA_SettingProfileID of type Guid
						item.CMN_BPT_STA_SettingProfileID = reader.GetGuid(0);
						//1:Parameter StafMember_Caption of type Dict
						item.StafMember_Caption = reader.GetDictionary(1);
						loader.Append(item.StafMember_Caption,TableName);
						//2:Parameter IsLeaveTimeCalculated_InDays of type Boolean
						item.IsLeaveTimeCalculated_InDays = reader.GetBoolean(2);
						//3:Parameter IsLeaveTimeCalculated_InHours of type Boolean
						item.IsLeaveTimeCalculated_InHours = reader.GetBoolean(3);
						//4:Parameter IsUsingWorkflow_ForLeaveRequests of type Boolean
						item.IsUsingWorkflow_ForLeaveRequests = reader.GetBoolean(4);
						//5:Parameter Default_AdulthoodAge of type int
						item.Default_AdulthoodAge = reader.GetInteger(5);
						//6:Parameter Default_SurchargeCalculation_UseMaximum of type Boolean
						item.Default_SurchargeCalculation_UseMaximum = reader.GetBoolean(6);
						//7:Parameter Default_SurchargeCalculation_UseAccumulated of type Boolean
						item.Default_SurchargeCalculation_UseAccumulated = reader.GetBoolean(7);
						//8:Parameter Default_RestWarningThreshold_Adults_in_mins of type int
						item.Default_RestWarningThreshold_Adults_in_mins = reader.GetInteger(8);
						//9:Parameter Default_RestWarningThreshold_NonAdults_in_mins of type int
						item.Default_RestWarningThreshold_NonAdults_in_mins = reader.GetInteger(9);
						//10:Parameter Default_RestMinimumThresholdl_Adults_in_mins of type int
						item.Default_RestMinimumThresholdl_Adults_in_mins = reader.GetInteger(10);
						//11:Parameter Default_RestMinimumThresholdl_NonAdults_in_mins of type int
						item.Default_RestMinimumThresholdl_NonAdults_in_mins = reader.GetInteger(11);
						//12:Parameter Default_WorkTimeWarningTreshold_Adults_in_mins of type int
						item.Default_WorkTimeWarningTreshold_Adults_in_mins = reader.GetInteger(12);
						//13:Parameter Default_WorkTimeWarningTreshold_NonAdults_in_mins of type int
						item.Default_WorkTimeWarningTreshold_NonAdults_in_mins = reader.GetInteger(13);
						//14:Parameter Default_WorkTimeMaximumTreshold_Adults_in_mins of type int
						item.Default_WorkTimeMaximumTreshold_Adults_in_mins = reader.GetInteger(14);
						//15:Parameter Default_WorkTimeMaximumTreshold_NonAdults_in_mins of type int
						item.Default_WorkTimeMaximumTreshold_NonAdults_in_mins = reader.GetInteger(15);
						//16:Parameter Default_WorkStartTimeWarning_NonAdults_in_mins of type int
						item.Default_WorkStartTimeWarning_NonAdults_in_mins = reader.GetInteger(16);
						//17:Parameter Default_WorkStartTimeMinimum_NonAdults_in_mins of type int
						item.Default_WorkStartTimeMinimum_NonAdults_in_mins = reader.GetInteger(17);
						//18:Parameter Default_WorkEndTimeWarning_NonAdults_in_mins of type int
						item.Default_WorkEndTimeWarning_NonAdults_in_mins = reader.GetInteger(18);
						//19:Parameter Default_WorkEndTimeMaximum_NonAdults_in_mins of type int
						item.Default_WorkEndTimeMaximum_NonAdults_in_mins = reader.GetInteger(19);
						//20:Parameter Default_WorktimeBalancePeriod_in_months of type int
						item.Default_WorktimeBalancePeriod_in_months = reader.GetInteger(20);
						//21:Parameter Default_WorkdayStart_in_mins of type int
						item.Default_WorkdayStart_in_mins = reader.GetInteger(21);
						//22:Parameter Default_RoosterGridMinimumPlanningUnit_in_mins of type int
						item.Default_RoosterGridMinimumPlanningUnit_in_mins = reader.GetInteger(22);
						//23:Parameter Default_MaximumPreWork_Period_in_mins of type int
						item.Default_MaximumPreWork_Period_in_mins = reader.GetInteger(23);
						//24:Parameter Default_MaximumPostWork_Period_in_mins of type int
						item.Default_MaximumPostWork_Period_in_mins = reader.GetInteger(24);
						//25:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(25);
						//26:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(26);
						//27:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(27);


						item.Status_IsAlreadySaved = true;
			            item.Status_IsDirty = false;
			            items.Add(item);
			        }
			        reader.Close();
			        loader.Load();
			        managedConnection.commit();
			    }
			    catch (Exception ex)
			    {
			        managedConnection.rollback();
			        throw ex;
			    }
			    return items;
			}
			#endregion

			#region Update
			public static int Update(string connectionString, Query query, Query values)
			{
			    return Query.Update(query, values, connectionString, null, null);
			}

			public static int Update(DbConnection connection, Query query, Query values)
			{
			    return Query.Update(query, values, null, connection, null);
			}

			public static int Update(DbConnection connection, DbTransaction transaction, Query query, Query values)
			{
			    return Query.Update(query, values, null, connection, transaction);
			}

			private static int Update(Query query, Query values, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
				try
				{
					managedConnection.set(connectionString, connection, transaction);
					DbCommand command = managedConnection.manage(query.CreateUpdateQuery(TableName,values.CreateSetStatement()));
					query.SetParameters(command);
					values.SetUpdateValues(command);
					int result = command.ExecuteNonQuery();
					managedConnection.commit();
					return result;
				} 
				catch(Exception ex)
				{
					managedConnection.rollback();
					throw ex;
				}
			}
			#endregion

			#region Soft Recover
			public static int SoftRecover(string connectionString, Query query)
			{
			    return Query.SoftRecover(query, connectionString, null, null);
			}

			public static int SoftRecover(DbConnection connection, Query query)
			{
			    return Query.SoftRecover(query, null, connection, null);
			}

			public static int SoftRecover(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.SoftRecover(query, null, connection, transaction);
			}

			private static int SoftRecover(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
				try
				{
					managedConnection.set(connectionString, connection, transaction);
					DbCommand command = managedConnection.manage(query.CreateSoftDeleteQuery(TableName,false));
					query.SetParameters(command);
					int result = command.ExecuteNonQuery();
					managedConnection.commit();
					return result;
				} 
				catch(Exception ex)
				{
					managedConnection.rollback();
					throw ex;
				}
			}
			#endregion

			#region Soft Delete
			public static int SoftDelete(string connectionString, Query query)
			{
			    return Query.SoftDelete(query, connectionString, null, null);
			}

			public static int SoftDelete(DbConnection connection, Query query)
			{
			    return Query.SoftDelete(query, null, connection, null);
			}

			public static int SoftDelete(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.SoftDelete(query, null, connection, transaction);
			}

			private static int SoftDelete(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
				try
				{
					managedConnection.set(connectionString, connection, transaction);
					DbCommand command = managedConnection.manage(query.CreateSoftDeleteQuery(TableName,true));
					query.SetParameters(command);
					int result = command.ExecuteNonQuery();
					managedConnection.commit();
					return result;
				} 
				catch(Exception ex)
				{
					managedConnection.rollback();
					throw ex;
				}
			}
			#endregion			
		}
		#endregion
	}	
}
