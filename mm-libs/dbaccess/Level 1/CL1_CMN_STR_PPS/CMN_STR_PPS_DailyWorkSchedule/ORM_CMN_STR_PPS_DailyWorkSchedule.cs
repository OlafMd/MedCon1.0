/* 
 * Generated on 25-Feb-15 3:13:12 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_CMN_STR_PPS
{
	[Serializable]
	public class ORM_CMN_STR_PPS_DailyWorkSchedule
	{
		public static readonly string TableName = "cmn_str_pps_dailyworkschedules";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_CMN_STR_PPS_DailyWorkSchedule()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_CMN_STR_PPS_DailyWorkScheduleID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _CMN_STR_PPS_DailyWorkScheduleID = default(Guid);
		private Guid _Employee_RefID = default(Guid);
		private DateTime _WorkSheduleDate = default(DateTime);
		private Guid _SheduleBreakTemplate_RefID = default(Guid);
		private int _R_WorkDay_Start_in_sec = default(int);
		private int _R_WorkDay_End_in_sec = default(int);
		private int _R_WorkDay_Duration_in_sec = default(int);
		private Boolean _IsBreakTimeManualySpecified = default(Boolean);
		private int _BreakDurationTime_in_sec = default(int);
		private int _R_ContractSpecified_WorkingTime_in_sec = default(int);
		private String _WorkingSheduleComment = default(String);
		private String _ContractWorkerText = default(String);
		private Boolean _IsWorkShedule_Confirmed = default(Boolean);
		private Guid _WorkShedule_ConfirmedBy_Account_RefID = default(Guid);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid CMN_STR_PPS_DailyWorkScheduleID { 
			get {
				return _CMN_STR_PPS_DailyWorkScheduleID;
			}
			set {
				if(_CMN_STR_PPS_DailyWorkScheduleID != value){
					_CMN_STR_PPS_DailyWorkScheduleID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Employee_RefID { 
			get {
				return _Employee_RefID;
			}
			set {
				if(_Employee_RefID != value){
					_Employee_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime WorkSheduleDate { 
			get {
				return _WorkSheduleDate;
			}
			set {
				if(_WorkSheduleDate != value){
					_WorkSheduleDate = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid SheduleBreakTemplate_RefID { 
			get {
				return _SheduleBreakTemplate_RefID;
			}
			set {
				if(_SheduleBreakTemplate_RefID != value){
					_SheduleBreakTemplate_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int R_WorkDay_Start_in_sec { 
			get {
				return _R_WorkDay_Start_in_sec;
			}
			set {
				if(_R_WorkDay_Start_in_sec != value){
					_R_WorkDay_Start_in_sec = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int R_WorkDay_End_in_sec { 
			get {
				return _R_WorkDay_End_in_sec;
			}
			set {
				if(_R_WorkDay_End_in_sec != value){
					_R_WorkDay_End_in_sec = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int R_WorkDay_Duration_in_sec { 
			get {
				return _R_WorkDay_Duration_in_sec;
			}
			set {
				if(_R_WorkDay_Duration_in_sec != value){
					_R_WorkDay_Duration_in_sec = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsBreakTimeManualySpecified { 
			get {
				return _IsBreakTimeManualySpecified;
			}
			set {
				if(_IsBreakTimeManualySpecified != value){
					_IsBreakTimeManualySpecified = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int BreakDurationTime_in_sec { 
			get {
				return _BreakDurationTime_in_sec;
			}
			set {
				if(_BreakDurationTime_in_sec != value){
					_BreakDurationTime_in_sec = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int R_ContractSpecified_WorkingTime_in_sec { 
			get {
				return _R_ContractSpecified_WorkingTime_in_sec;
			}
			set {
				if(_R_ContractSpecified_WorkingTime_in_sec != value){
					_R_ContractSpecified_WorkingTime_in_sec = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String WorkingSheduleComment { 
			get {
				return _WorkingSheduleComment;
			}
			set {
				if(_WorkingSheduleComment != value){
					_WorkingSheduleComment = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String ContractWorkerText { 
			get {
				return _ContractWorkerText;
			}
			set {
				if(_ContractWorkerText != value){
					_ContractWorkerText = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsWorkShedule_Confirmed { 
			get {
				return _IsWorkShedule_Confirmed;
			}
			set {
				if(_IsWorkShedule_Confirmed != value){
					_IsWorkShedule_Confirmed = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid WorkShedule_ConfirmedBy_Account_RefID { 
			get {
				return _WorkShedule_ConfirmedBy_Account_RefID;
			}
			set {
				if(_WorkShedule_ConfirmedBy_Account_RefID != value){
					_WorkShedule_ConfirmedBy_Account_RefID = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_STR_PPS.CMN_STR_PPS_DailyWorkSchedule.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_STR_PPS.CMN_STR_PPS_DailyWorkSchedule.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_STR_PPS_DailyWorkScheduleID", _CMN_STR_PPS_DailyWorkScheduleID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Employee_RefID", _Employee_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "WorkSheduleDate", _WorkSheduleDate);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "SheduleBreakTemplate_RefID", _SheduleBreakTemplate_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "R_WorkDay_Start_in_sec", _R_WorkDay_Start_in_sec);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "R_WorkDay_End_in_sec", _R_WorkDay_End_in_sec);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "R_WorkDay_Duration_in_sec", _R_WorkDay_Duration_in_sec);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsBreakTimeManualySpecified", _IsBreakTimeManualySpecified);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "BreakDurationTime_in_sec", _BreakDurationTime_in_sec);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "R_ContractSpecified_WorkingTime_in_sec", _R_ContractSpecified_WorkingTime_in_sec);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "WorkingSheduleComment", _WorkingSheduleComment);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ContractWorkerText", _ContractWorkerText);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsWorkShedule_Confirmed", _IsWorkShedule_Confirmed);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "WorkShedule_ConfirmedBy_Account_RefID", _WorkShedule_ConfirmedBy_Account_RefID);
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
						throw;
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

				throw;
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_STR_PPS.CMN_STR_PPS_DailyWorkSchedule.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_CMN_STR_PPS_DailyWorkScheduleID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CMN_STR_PPS_DailyWorkScheduleID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_STR_PPS_DailyWorkScheduleID","Employee_RefID","WorkSheduleDate","SheduleBreakTemplate_RefID","R_WorkDay_Start_in_sec","R_WorkDay_End_in_sec","R_WorkDay_Duration_in_sec","IsBreakTimeManualySpecified","BreakDurationTime_in_sec","R_ContractSpecified_WorkingTime_in_sec","WorkingSheduleComment","ContractWorkerText","IsWorkShedule_Confirmed","WorkShedule_ConfirmedBy_Account_RefID","Creation_Timestamp","Tenant_RefID","IsDeleted" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter CMN_STR_PPS_DailyWorkScheduleID of type Guid
						_CMN_STR_PPS_DailyWorkScheduleID = reader.GetGuid(0);
						//1:Parameter Employee_RefID of type Guid
						_Employee_RefID = reader.GetGuid(1);
						//2:Parameter WorkSheduleDate of type DateTime
						_WorkSheduleDate = reader.GetDate(2);
						//3:Parameter SheduleBreakTemplate_RefID of type Guid
						_SheduleBreakTemplate_RefID = reader.GetGuid(3);
						//4:Parameter R_WorkDay_Start_in_sec of type int
						_R_WorkDay_Start_in_sec = reader.GetInteger(4);
						//5:Parameter R_WorkDay_End_in_sec of type int
						_R_WorkDay_End_in_sec = reader.GetInteger(5);
						//6:Parameter R_WorkDay_Duration_in_sec of type int
						_R_WorkDay_Duration_in_sec = reader.GetInteger(6);
						//7:Parameter IsBreakTimeManualySpecified of type Boolean
						_IsBreakTimeManualySpecified = reader.GetBoolean(7);
						//8:Parameter BreakDurationTime_in_sec of type int
						_BreakDurationTime_in_sec = reader.GetInteger(8);
						//9:Parameter R_ContractSpecified_WorkingTime_in_sec of type int
						_R_ContractSpecified_WorkingTime_in_sec = reader.GetInteger(9);
						//10:Parameter WorkingSheduleComment of type String
						_WorkingSheduleComment = reader.GetString(10);
						//11:Parameter ContractWorkerText of type String
						_ContractWorkerText = reader.GetString(11);
						//12:Parameter IsWorkShedule_Confirmed of type Boolean
						_IsWorkShedule_Confirmed = reader.GetBoolean(12);
						//13:Parameter WorkShedule_ConfirmedBy_Account_RefID of type Guid
						_WorkShedule_ConfirmedBy_Account_RefID = reader.GetGuid(13);
						//14:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(14);
						//15:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(15);
						//16:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(16);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_CMN_STR_PPS_DailyWorkScheduleID != Guid.Empty){
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
					throw;
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

				throw;
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
			public Guid? CMN_STR_PPS_DailyWorkScheduleID {	get; set; }
			public Guid? Employee_RefID {	get; set; }
			public DateTime? WorkSheduleDate {	get; set; }
			public Guid? SheduleBreakTemplate_RefID {	get; set; }
			public int? R_WorkDay_Start_in_sec {	get; set; }
			public int? R_WorkDay_End_in_sec {	get; set; }
			public int? R_WorkDay_Duration_in_sec {	get; set; }
			public Boolean? IsBreakTimeManualySpecified {	get; set; }
			public int? BreakDurationTime_in_sec {	get; set; }
			public int? R_ContractSpecified_WorkingTime_in_sec {	get; set; }
			public String WorkingSheduleComment {	get; set; }
			public String ContractWorkerText {	get; set; }
			public Boolean? IsWorkShedule_Confirmed {	get; set; }
			public Guid? WorkShedule_ConfirmedBy_Account_RefID {	get; set; }
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
					throw;
				}
			}
			#endregion

			#region Search
			public static List<ORM_CMN_STR_PPS_DailyWorkSchedule> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_CMN_STR_PPS_DailyWorkSchedule> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_CMN_STR_PPS_DailyWorkSchedule> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_CMN_STR_PPS_DailyWorkSchedule> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_CMN_STR_PPS_DailyWorkSchedule> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_CMN_STR_PPS_DailyWorkSchedule>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_STR_PPS_DailyWorkScheduleID","Employee_RefID","WorkSheduleDate","SheduleBreakTemplate_RefID","R_WorkDay_Start_in_sec","R_WorkDay_End_in_sec","R_WorkDay_Duration_in_sec","IsBreakTimeManualySpecified","BreakDurationTime_in_sec","R_ContractSpecified_WorkingTime_in_sec","WorkingSheduleComment","ContractWorkerText","IsWorkShedule_Confirmed","WorkShedule_ConfirmedBy_Account_RefID","Creation_Timestamp","Tenant_RefID","IsDeleted" });
			        while (reader.Read())
			        {
			            ORM_CMN_STR_PPS_DailyWorkSchedule item = new ORM_CMN_STR_PPS_DailyWorkSchedule();
						//0:Parameter CMN_STR_PPS_DailyWorkScheduleID of type Guid
						item.CMN_STR_PPS_DailyWorkScheduleID = reader.GetGuid(0);
						//1:Parameter Employee_RefID of type Guid
						item.Employee_RefID = reader.GetGuid(1);
						//2:Parameter WorkSheduleDate of type DateTime
						item.WorkSheduleDate = reader.GetDate(2);
						//3:Parameter SheduleBreakTemplate_RefID of type Guid
						item.SheduleBreakTemplate_RefID = reader.GetGuid(3);
						//4:Parameter R_WorkDay_Start_in_sec of type int
						item.R_WorkDay_Start_in_sec = reader.GetInteger(4);
						//5:Parameter R_WorkDay_End_in_sec of type int
						item.R_WorkDay_End_in_sec = reader.GetInteger(5);
						//6:Parameter R_WorkDay_Duration_in_sec of type int
						item.R_WorkDay_Duration_in_sec = reader.GetInteger(6);
						//7:Parameter IsBreakTimeManualySpecified of type Boolean
						item.IsBreakTimeManualySpecified = reader.GetBoolean(7);
						//8:Parameter BreakDurationTime_in_sec of type int
						item.BreakDurationTime_in_sec = reader.GetInteger(8);
						//9:Parameter R_ContractSpecified_WorkingTime_in_sec of type int
						item.R_ContractSpecified_WorkingTime_in_sec = reader.GetInteger(9);
						//10:Parameter WorkingSheduleComment of type String
						item.WorkingSheduleComment = reader.GetString(10);
						//11:Parameter ContractWorkerText of type String
						item.ContractWorkerText = reader.GetString(11);
						//12:Parameter IsWorkShedule_Confirmed of type Boolean
						item.IsWorkShedule_Confirmed = reader.GetBoolean(12);
						//13:Parameter WorkShedule_ConfirmedBy_Account_RefID of type Guid
						item.WorkShedule_ConfirmedBy_Account_RefID = reader.GetGuid(13);
						//14:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(14);
						//15:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(15);
						//16:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(16);


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
			        throw;
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
					throw;
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
					throw;
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
					throw;
				}
			}
			#endregion			
		}
		#endregion
	}	
}
