/* 
 * Generated on 13-Nov-13 17:16:14
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_CMN_BPT_STR
{
	[Serializable]
	public class ORM_CMN_BPT_STR_Office_SettingsProfile
	{
		public static readonly string TableName = "cmn_bpt_str_office_settingsprofile";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_CMN_BPT_STR_Office_SettingsProfile()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_CMN_BPT_STR_Office_SettingsProfileID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _CMN_BPT_STR_Office_SettingsProfileID = default(Guid);
		private Guid _Office_RefID = default(Guid);
		private int _AdulthoodAge = default(int);
		private int _RestWarningThreshold_Adults_in_mins = default(int);
		private int _RestWarningThreshold_NonAdults_in_mins = default(int);
		private int _RestMinimumThresholdl_Adults_in_mins = default(int);
		private int _RestMinimumThresholdl_NonAdults_in_mins = default(int);
		private int _WorkTimeWarningTreshold_Adults_in_mins = default(int);
		private int _WorkTimeWarningTreshold_NonAdults_in_mins = default(int);
		private int _WorkTimeMaximumTreshold_Adults_in_mins = default(int);
		private int _WorkTimeMaximumTreshold_NonAdults_in_mins = default(int);
		private int _WorkStartTimeWarning_NonAdults_in_mins = default(int);
		private int _WorkStartTimeMinimum_NonAdults_in_mins = default(int);
		private int _WorkEndTimeWarning_NonAdults_in_mins = default(int);
		private int _WorkEndTimeMaximum_NonAdults_in_mins = default(int);
		private int _WorktimeBalancePeriod_in_months = default(int);
		private int _WorkdayStart_in_mins = default(int);
		private int _RoosterGridMinimumPlanningUnit_in_mins = default(int);
		private int _MaximumPreWork_Period_in_mins = default(int);
		private int _MaximumPostWork_Period_in_mins = default(int);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid CMN_BPT_STR_Office_SettingsProfileID { 
			get {
				return _CMN_BPT_STR_Office_SettingsProfileID;
			}
			set {
				if(_CMN_BPT_STR_Office_SettingsProfileID != value){
					_CMN_BPT_STR_Office_SettingsProfileID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Office_RefID { 
			get {
				return _Office_RefID;
			}
			set {
				if(_Office_RefID != value){
					_Office_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int AdulthoodAge { 
			get {
				return _AdulthoodAge;
			}
			set {
				if(_AdulthoodAge != value){
					_AdulthoodAge = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int RestWarningThreshold_Adults_in_mins { 
			get {
				return _RestWarningThreshold_Adults_in_mins;
			}
			set {
				if(_RestWarningThreshold_Adults_in_mins != value){
					_RestWarningThreshold_Adults_in_mins = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int RestWarningThreshold_NonAdults_in_mins { 
			get {
				return _RestWarningThreshold_NonAdults_in_mins;
			}
			set {
				if(_RestWarningThreshold_NonAdults_in_mins != value){
					_RestWarningThreshold_NonAdults_in_mins = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int RestMinimumThresholdl_Adults_in_mins { 
			get {
				return _RestMinimumThresholdl_Adults_in_mins;
			}
			set {
				if(_RestMinimumThresholdl_Adults_in_mins != value){
					_RestMinimumThresholdl_Adults_in_mins = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int RestMinimumThresholdl_NonAdults_in_mins { 
			get {
				return _RestMinimumThresholdl_NonAdults_in_mins;
			}
			set {
				if(_RestMinimumThresholdl_NonAdults_in_mins != value){
					_RestMinimumThresholdl_NonAdults_in_mins = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int WorkTimeWarningTreshold_Adults_in_mins { 
			get {
				return _WorkTimeWarningTreshold_Adults_in_mins;
			}
			set {
				if(_WorkTimeWarningTreshold_Adults_in_mins != value){
					_WorkTimeWarningTreshold_Adults_in_mins = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int WorkTimeWarningTreshold_NonAdults_in_mins { 
			get {
				return _WorkTimeWarningTreshold_NonAdults_in_mins;
			}
			set {
				if(_WorkTimeWarningTreshold_NonAdults_in_mins != value){
					_WorkTimeWarningTreshold_NonAdults_in_mins = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int WorkTimeMaximumTreshold_Adults_in_mins { 
			get {
				return _WorkTimeMaximumTreshold_Adults_in_mins;
			}
			set {
				if(_WorkTimeMaximumTreshold_Adults_in_mins != value){
					_WorkTimeMaximumTreshold_Adults_in_mins = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int WorkTimeMaximumTreshold_NonAdults_in_mins { 
			get {
				return _WorkTimeMaximumTreshold_NonAdults_in_mins;
			}
			set {
				if(_WorkTimeMaximumTreshold_NonAdults_in_mins != value){
					_WorkTimeMaximumTreshold_NonAdults_in_mins = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int WorkStartTimeWarning_NonAdults_in_mins { 
			get {
				return _WorkStartTimeWarning_NonAdults_in_mins;
			}
			set {
				if(_WorkStartTimeWarning_NonAdults_in_mins != value){
					_WorkStartTimeWarning_NonAdults_in_mins = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int WorkStartTimeMinimum_NonAdults_in_mins { 
			get {
				return _WorkStartTimeMinimum_NonAdults_in_mins;
			}
			set {
				if(_WorkStartTimeMinimum_NonAdults_in_mins != value){
					_WorkStartTimeMinimum_NonAdults_in_mins = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int WorkEndTimeWarning_NonAdults_in_mins { 
			get {
				return _WorkEndTimeWarning_NonAdults_in_mins;
			}
			set {
				if(_WorkEndTimeWarning_NonAdults_in_mins != value){
					_WorkEndTimeWarning_NonAdults_in_mins = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int WorkEndTimeMaximum_NonAdults_in_mins { 
			get {
				return _WorkEndTimeMaximum_NonAdults_in_mins;
			}
			set {
				if(_WorkEndTimeMaximum_NonAdults_in_mins != value){
					_WorkEndTimeMaximum_NonAdults_in_mins = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int WorktimeBalancePeriod_in_months { 
			get {
				return _WorktimeBalancePeriod_in_months;
			}
			set {
				if(_WorktimeBalancePeriod_in_months != value){
					_WorktimeBalancePeriod_in_months = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int WorkdayStart_in_mins { 
			get {
				return _WorkdayStart_in_mins;
			}
			set {
				if(_WorkdayStart_in_mins != value){
					_WorkdayStart_in_mins = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int RoosterGridMinimumPlanningUnit_in_mins { 
			get {
				return _RoosterGridMinimumPlanningUnit_in_mins;
			}
			set {
				if(_RoosterGridMinimumPlanningUnit_in_mins != value){
					_RoosterGridMinimumPlanningUnit_in_mins = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int MaximumPreWork_Period_in_mins { 
			get {
				return _MaximumPreWork_Period_in_mins;
			}
			set {
				if(_MaximumPreWork_Period_in_mins != value){
					_MaximumPreWork_Period_in_mins = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int MaximumPostWork_Period_in_mins { 
			get {
				return _MaximumPostWork_Period_in_mins;
			}
			set {
				if(_MaximumPostWork_Period_in_mins != value){
					_MaximumPostWork_Period_in_mins = value;
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

				bool saveDictionary = false;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_BPT_STR.CMN_BPT_STR_Office_SettingsProfile.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_BPT_STR.CMN_BPT_STR_Office_SettingsProfile.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_BPT_STR_Office_SettingsProfileID", _CMN_BPT_STR_Office_SettingsProfileID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Office_RefID", _Office_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "AdulthoodAge", _AdulthoodAge);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "RestWarningThreshold_Adults_in_mins", _RestWarningThreshold_Adults_in_mins);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "RestWarningThreshold_NonAdults_in_mins", _RestWarningThreshold_NonAdults_in_mins);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "RestMinimumThresholdl_Adults_in_mins", _RestMinimumThresholdl_Adults_in_mins);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "RestMinimumThresholdl_NonAdults_in_mins", _RestMinimumThresholdl_NonAdults_in_mins);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "WorkTimeWarningTreshold_Adults_in_mins", _WorkTimeWarningTreshold_Adults_in_mins);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "WorkTimeWarningTreshold_NonAdults_in_mins", _WorkTimeWarningTreshold_NonAdults_in_mins);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "WorkTimeMaximumTreshold_Adults_in_mins", _WorkTimeMaximumTreshold_Adults_in_mins);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "WorkTimeMaximumTreshold_NonAdults_in_mins", _WorkTimeMaximumTreshold_NonAdults_in_mins);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "WorkStartTimeWarning_NonAdults_in_mins", _WorkStartTimeWarning_NonAdults_in_mins);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "WorkStartTimeMinimum_NonAdults_in_mins", _WorkStartTimeMinimum_NonAdults_in_mins);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "WorkEndTimeWarning_NonAdults_in_mins", _WorkEndTimeWarning_NonAdults_in_mins);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "WorkEndTimeMaximum_NonAdults_in_mins", _WorkEndTimeMaximum_NonAdults_in_mins);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "WorktimeBalancePeriod_in_months", _WorktimeBalancePeriod_in_months);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "WorkdayStart_in_mins", _WorkdayStart_in_mins);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "RoosterGridMinimumPlanningUnit_in_mins", _RoosterGridMinimumPlanningUnit_in_mins);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "MaximumPreWork_Period_in_mins", _MaximumPreWork_Period_in_mins);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "MaximumPostWork_Period_in_mins", _MaximumPostWork_Period_in_mins);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Creation_Timestamp", _Creation_Timestamp);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Tenant_RefID", _Tenant_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsDeleted", _IsDeleted);


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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_BPT_STR.CMN_BPT_STR_Office_SettingsProfile.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_CMN_BPT_STR_Office_SettingsProfileID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CMN_BPT_STR_Office_SettingsProfileID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_BPT_STR_Office_SettingsProfileID","Office_RefID","AdulthoodAge","RestWarningThreshold_Adults_in_mins","RestWarningThreshold_NonAdults_in_mins","RestMinimumThresholdl_Adults_in_mins","RestMinimumThresholdl_NonAdults_in_mins","WorkTimeWarningTreshold_Adults_in_mins","WorkTimeWarningTreshold_NonAdults_in_mins","WorkTimeMaximumTreshold_Adults_in_mins","WorkTimeMaximumTreshold_NonAdults_in_mins","WorkStartTimeWarning_NonAdults_in_mins","WorkStartTimeMinimum_NonAdults_in_mins","WorkEndTimeWarning_NonAdults_in_mins","WorkEndTimeMaximum_NonAdults_in_mins","WorktimeBalancePeriod_in_months","WorkdayStart_in_mins","RoosterGridMinimumPlanningUnit_in_mins","MaximumPreWork_Period_in_mins","MaximumPostWork_Period_in_mins","Creation_Timestamp","Tenant_RefID","IsDeleted" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter CMN_BPT_STR_Office_SettingsProfileID of type Guid
						_CMN_BPT_STR_Office_SettingsProfileID = reader.GetGuid(0);
						//1:Parameter Office_RefID of type Guid
						_Office_RefID = reader.GetGuid(1);
						//2:Parameter AdulthoodAge of type int
						_AdulthoodAge = reader.GetInteger(2);
						//3:Parameter RestWarningThreshold_Adults_in_mins of type int
						_RestWarningThreshold_Adults_in_mins = reader.GetInteger(3);
						//4:Parameter RestWarningThreshold_NonAdults_in_mins of type int
						_RestWarningThreshold_NonAdults_in_mins = reader.GetInteger(4);
						//5:Parameter RestMinimumThresholdl_Adults_in_mins of type int
						_RestMinimumThresholdl_Adults_in_mins = reader.GetInteger(5);
						//6:Parameter RestMinimumThresholdl_NonAdults_in_mins of type int
						_RestMinimumThresholdl_NonAdults_in_mins = reader.GetInteger(6);
						//7:Parameter WorkTimeWarningTreshold_Adults_in_mins of type int
						_WorkTimeWarningTreshold_Adults_in_mins = reader.GetInteger(7);
						//8:Parameter WorkTimeWarningTreshold_NonAdults_in_mins of type int
						_WorkTimeWarningTreshold_NonAdults_in_mins = reader.GetInteger(8);
						//9:Parameter WorkTimeMaximumTreshold_Adults_in_mins of type int
						_WorkTimeMaximumTreshold_Adults_in_mins = reader.GetInteger(9);
						//10:Parameter WorkTimeMaximumTreshold_NonAdults_in_mins of type int
						_WorkTimeMaximumTreshold_NonAdults_in_mins = reader.GetInteger(10);
						//11:Parameter WorkStartTimeWarning_NonAdults_in_mins of type int
						_WorkStartTimeWarning_NonAdults_in_mins = reader.GetInteger(11);
						//12:Parameter WorkStartTimeMinimum_NonAdults_in_mins of type int
						_WorkStartTimeMinimum_NonAdults_in_mins = reader.GetInteger(12);
						//13:Parameter WorkEndTimeWarning_NonAdults_in_mins of type int
						_WorkEndTimeWarning_NonAdults_in_mins = reader.GetInteger(13);
						//14:Parameter WorkEndTimeMaximum_NonAdults_in_mins of type int
						_WorkEndTimeMaximum_NonAdults_in_mins = reader.GetInteger(14);
						//15:Parameter WorktimeBalancePeriod_in_months of type int
						_WorktimeBalancePeriod_in_months = reader.GetInteger(15);
						//16:Parameter WorkdayStart_in_mins of type int
						_WorkdayStart_in_mins = reader.GetInteger(16);
						//17:Parameter RoosterGridMinimumPlanningUnit_in_mins of type int
						_RoosterGridMinimumPlanningUnit_in_mins = reader.GetInteger(17);
						//18:Parameter MaximumPreWork_Period_in_mins of type int
						_MaximumPreWork_Period_in_mins = reader.GetInteger(18);
						//19:Parameter MaximumPostWork_Period_in_mins of type int
						_MaximumPostWork_Period_in_mins = reader.GetInteger(19);
						//20:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(20);
						//21:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(21);
						//22:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(22);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_CMN_BPT_STR_Office_SettingsProfileID != Guid.Empty){
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
			public Guid? CMN_BPT_STR_Office_SettingsProfileID {	get; set; }
			public Guid? Office_RefID {	get; set; }
			public int? AdulthoodAge {	get; set; }
			public int? RestWarningThreshold_Adults_in_mins {	get; set; }
			public int? RestWarningThreshold_NonAdults_in_mins {	get; set; }
			public int? RestMinimumThresholdl_Adults_in_mins {	get; set; }
			public int? RestMinimumThresholdl_NonAdults_in_mins {	get; set; }
			public int? WorkTimeWarningTreshold_Adults_in_mins {	get; set; }
			public int? WorkTimeWarningTreshold_NonAdults_in_mins {	get; set; }
			public int? WorkTimeMaximumTreshold_Adults_in_mins {	get; set; }
			public int? WorkTimeMaximumTreshold_NonAdults_in_mins {	get; set; }
			public int? WorkStartTimeWarning_NonAdults_in_mins {	get; set; }
			public int? WorkStartTimeMinimum_NonAdults_in_mins {	get; set; }
			public int? WorkEndTimeWarning_NonAdults_in_mins {	get; set; }
			public int? WorkEndTimeMaximum_NonAdults_in_mins {	get; set; }
			public int? WorktimeBalancePeriod_in_months {	get; set; }
			public int? WorkdayStart_in_mins {	get; set; }
			public int? RoosterGridMinimumPlanningUnit_in_mins {	get; set; }
			public int? MaximumPreWork_Period_in_mins {	get; set; }
			public int? MaximumPostWork_Period_in_mins {	get; set; }
			public DateTime? Creation_Timestamp {	get; set; }
			public Guid? Tenant_RefID {	get; set; }
			public Boolean? IsDeleted {	get; set; }
			 

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
			public static List<ORM_CMN_BPT_STR_Office_SettingsProfile> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_CMN_BPT_STR_Office_SettingsProfile> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_CMN_BPT_STR_Office_SettingsProfile> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_CMN_BPT_STR_Office_SettingsProfile> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_CMN_BPT_STR_Office_SettingsProfile> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_CMN_BPT_STR_Office_SettingsProfile>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_BPT_STR_Office_SettingsProfileID","Office_RefID","AdulthoodAge","RestWarningThreshold_Adults_in_mins","RestWarningThreshold_NonAdults_in_mins","RestMinimumThresholdl_Adults_in_mins","RestMinimumThresholdl_NonAdults_in_mins","WorkTimeWarningTreshold_Adults_in_mins","WorkTimeWarningTreshold_NonAdults_in_mins","WorkTimeMaximumTreshold_Adults_in_mins","WorkTimeMaximumTreshold_NonAdults_in_mins","WorkStartTimeWarning_NonAdults_in_mins","WorkStartTimeMinimum_NonAdults_in_mins","WorkEndTimeWarning_NonAdults_in_mins","WorkEndTimeMaximum_NonAdults_in_mins","WorktimeBalancePeriod_in_months","WorkdayStart_in_mins","RoosterGridMinimumPlanningUnit_in_mins","MaximumPreWork_Period_in_mins","MaximumPostWork_Period_in_mins","Creation_Timestamp","Tenant_RefID","IsDeleted" });
			        while (reader.Read())
			        {
			            ORM_CMN_BPT_STR_Office_SettingsProfile item = new ORM_CMN_BPT_STR_Office_SettingsProfile();
						//0:Parameter CMN_BPT_STR_Office_SettingsProfileID of type Guid
						item.CMN_BPT_STR_Office_SettingsProfileID = reader.GetGuid(0);
						//1:Parameter Office_RefID of type Guid
						item.Office_RefID = reader.GetGuid(1);
						//2:Parameter AdulthoodAge of type int
						item.AdulthoodAge = reader.GetInteger(2);
						//3:Parameter RestWarningThreshold_Adults_in_mins of type int
						item.RestWarningThreshold_Adults_in_mins = reader.GetInteger(3);
						//4:Parameter RestWarningThreshold_NonAdults_in_mins of type int
						item.RestWarningThreshold_NonAdults_in_mins = reader.GetInteger(4);
						//5:Parameter RestMinimumThresholdl_Adults_in_mins of type int
						item.RestMinimumThresholdl_Adults_in_mins = reader.GetInteger(5);
						//6:Parameter RestMinimumThresholdl_NonAdults_in_mins of type int
						item.RestMinimumThresholdl_NonAdults_in_mins = reader.GetInteger(6);
						//7:Parameter WorkTimeWarningTreshold_Adults_in_mins of type int
						item.WorkTimeWarningTreshold_Adults_in_mins = reader.GetInteger(7);
						//8:Parameter WorkTimeWarningTreshold_NonAdults_in_mins of type int
						item.WorkTimeWarningTreshold_NonAdults_in_mins = reader.GetInteger(8);
						//9:Parameter WorkTimeMaximumTreshold_Adults_in_mins of type int
						item.WorkTimeMaximumTreshold_Adults_in_mins = reader.GetInteger(9);
						//10:Parameter WorkTimeMaximumTreshold_NonAdults_in_mins of type int
						item.WorkTimeMaximumTreshold_NonAdults_in_mins = reader.GetInteger(10);
						//11:Parameter WorkStartTimeWarning_NonAdults_in_mins of type int
						item.WorkStartTimeWarning_NonAdults_in_mins = reader.GetInteger(11);
						//12:Parameter WorkStartTimeMinimum_NonAdults_in_mins of type int
						item.WorkStartTimeMinimum_NonAdults_in_mins = reader.GetInteger(12);
						//13:Parameter WorkEndTimeWarning_NonAdults_in_mins of type int
						item.WorkEndTimeWarning_NonAdults_in_mins = reader.GetInteger(13);
						//14:Parameter WorkEndTimeMaximum_NonAdults_in_mins of type int
						item.WorkEndTimeMaximum_NonAdults_in_mins = reader.GetInteger(14);
						//15:Parameter WorktimeBalancePeriod_in_months of type int
						item.WorktimeBalancePeriod_in_months = reader.GetInteger(15);
						//16:Parameter WorkdayStart_in_mins of type int
						item.WorkdayStart_in_mins = reader.GetInteger(16);
						//17:Parameter RoosterGridMinimumPlanningUnit_in_mins of type int
						item.RoosterGridMinimumPlanningUnit_in_mins = reader.GetInteger(17);
						//18:Parameter MaximumPreWork_Period_in_mins of type int
						item.MaximumPreWork_Period_in_mins = reader.GetInteger(18);
						//19:Parameter MaximumPostWork_Period_in_mins of type int
						item.MaximumPostWork_Period_in_mins = reader.GetInteger(19);
						//20:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(20);
						//21:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(21);
						//22:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(22);


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
