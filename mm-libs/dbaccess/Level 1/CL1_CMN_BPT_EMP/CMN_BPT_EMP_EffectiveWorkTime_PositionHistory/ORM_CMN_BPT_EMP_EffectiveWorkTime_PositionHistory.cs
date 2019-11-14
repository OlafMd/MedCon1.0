/* 
 * Generated on 3/9/2015 2:54:03 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_CMN_BPT_EMP
{
	[Serializable]
	public class ORM_CMN_BPT_EMP_EffectiveWorkTime_PositionHistory
	{
		public static readonly string TableName = "cmn_bpt_emp_effectiveworktime_positionhistory";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_CMN_BPT_EMP_EffectiveWorkTime_PositionHistory()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_CMN_BPT_EMP_EffectiveWorkTime_PositionHistoryID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _CMN_BPT_EMP_EffectiveWorkTime_PositionHistoryID = default(Guid);
		private Guid _EffectiveWorkTime_Header_RefID = default(Guid);
		private Guid _EffectiveWorkTime_Position_RefID = default(Guid);
		private DateTime _TriggeredAt_Date = default(DateTime);
		private Guid _TriggeredBy_BusinessParticipant_RefID = default(Guid);
		private int _TriggeredBy_SourceOfEntry = default(int);
		private String _Comment = default(String);
		private Guid _Activity_RefID = default(Guid);
		private Guid _Workplace_RefID = default(Guid);
		private Guid _CMN_BPT_EMP_Employee_LeaveRequest_RefID = default(Guid);
		private DateTime _WorkTime_StartTime = default(DateTime);
		private int _WorkTime_Duration_in_sec = default(int);
		private int _SourceOfEntry = default(int);
		private Boolean _IsCreated = default(Boolean);
		private Boolean _IsModified = default(Boolean);
		private Boolean _IsDeleted = default(Boolean);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private DateTime _Modification_Timestamp = default(DateTime);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid CMN_BPT_EMP_EffectiveWorkTime_PositionHistoryID { 
			get {
				return _CMN_BPT_EMP_EffectiveWorkTime_PositionHistoryID;
			}
			set {
				if(_CMN_BPT_EMP_EffectiveWorkTime_PositionHistoryID != value){
					_CMN_BPT_EMP_EffectiveWorkTime_PositionHistoryID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid EffectiveWorkTime_Header_RefID { 
			get {
				return _EffectiveWorkTime_Header_RefID;
			}
			set {
				if(_EffectiveWorkTime_Header_RefID != value){
					_EffectiveWorkTime_Header_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid EffectiveWorkTime_Position_RefID { 
			get {
				return _EffectiveWorkTime_Position_RefID;
			}
			set {
				if(_EffectiveWorkTime_Position_RefID != value){
					_EffectiveWorkTime_Position_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime TriggeredAt_Date { 
			get {
				return _TriggeredAt_Date;
			}
			set {
				if(_TriggeredAt_Date != value){
					_TriggeredAt_Date = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid TriggeredBy_BusinessParticipant_RefID { 
			get {
				return _TriggeredBy_BusinessParticipant_RefID;
			}
			set {
				if(_TriggeredBy_BusinessParticipant_RefID != value){
					_TriggeredBy_BusinessParticipant_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int TriggeredBy_SourceOfEntry { 
			get {
				return _TriggeredBy_SourceOfEntry;
			}
			set {
				if(_TriggeredBy_SourceOfEntry != value){
					_TriggeredBy_SourceOfEntry = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String Comment { 
			get {
				return _Comment;
			}
			set {
				if(_Comment != value){
					_Comment = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Activity_RefID { 
			get {
				return _Activity_RefID;
			}
			set {
				if(_Activity_RefID != value){
					_Activity_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Workplace_RefID { 
			get {
				return _Workplace_RefID;
			}
			set {
				if(_Workplace_RefID != value){
					_Workplace_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid CMN_BPT_EMP_Employee_LeaveRequest_RefID { 
			get {
				return _CMN_BPT_EMP_Employee_LeaveRequest_RefID;
			}
			set {
				if(_CMN_BPT_EMP_Employee_LeaveRequest_RefID != value){
					_CMN_BPT_EMP_Employee_LeaveRequest_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime WorkTime_StartTime { 
			get {
				return _WorkTime_StartTime;
			}
			set {
				if(_WorkTime_StartTime != value){
					_WorkTime_StartTime = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int WorkTime_Duration_in_sec { 
			get {
				return _WorkTime_Duration_in_sec;
			}
			set {
				if(_WorkTime_Duration_in_sec != value){
					_WorkTime_Duration_in_sec = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int SourceOfEntry { 
			get {
				return _SourceOfEntry;
			}
			set {
				if(_SourceOfEntry != value){
					_SourceOfEntry = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsCreated { 
			get {
				return _IsCreated;
			}
			set {
				if(_IsCreated != value){
					_IsCreated = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsModified { 
			get {
				return _IsModified;
			}
			set {
				if(_IsModified != value){
					_IsModified = value;
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
		public DateTime Modification_Timestamp { 
			get {
				return _Modification_Timestamp;
			}
			set {
				if(_Modification_Timestamp != value){
					_Modification_Timestamp = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_BPT_EMP.CMN_BPT_EMP_EffectiveWorkTime_PositionHistory.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_BPT_EMP.CMN_BPT_EMP_EffectiveWorkTime_PositionHistory.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_BPT_EMP_EffectiveWorkTime_PositionHistoryID", _CMN_BPT_EMP_EffectiveWorkTime_PositionHistoryID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "EffectiveWorkTime_Header_RefID", _EffectiveWorkTime_Header_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "EffectiveWorkTime_Position_RefID", _EffectiveWorkTime_Position_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "TriggeredAt_Date", _TriggeredAt_Date);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "TriggeredBy_BusinessParticipant_RefID", _TriggeredBy_BusinessParticipant_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "TriggeredBy_SourceOfEntry", _TriggeredBy_SourceOfEntry);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Comment", _Comment);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Activity_RefID", _Activity_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Workplace_RefID", _Workplace_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_BPT_EMP_Employee_LeaveRequest_RefID", _CMN_BPT_EMP_Employee_LeaveRequest_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "WorkTime_StartTime", _WorkTime_StartTime);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "WorkTime_Duration_in_sec", _WorkTime_Duration_in_sec);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "SourceOfEntry", _SourceOfEntry);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsCreated", _IsCreated);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsModified", _IsModified);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsDeleted", _IsDeleted);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Creation_Timestamp", _Creation_Timestamp);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Tenant_RefID", _Tenant_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Modification_Timestamp", _Modification_Timestamp);


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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_BPT_EMP.CMN_BPT_EMP_EffectiveWorkTime_PositionHistory.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_CMN_BPT_EMP_EffectiveWorkTime_PositionHistoryID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CMN_BPT_EMP_EffectiveWorkTime_PositionHistoryID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_BPT_EMP_EffectiveWorkTime_PositionHistoryID","EffectiveWorkTime_Header_RefID","EffectiveWorkTime_Position_RefID","TriggeredAt_Date","TriggeredBy_BusinessParticipant_RefID","TriggeredBy_SourceOfEntry","Comment","Activity_RefID","Workplace_RefID","CMN_BPT_EMP_Employee_LeaveRequest_RefID","WorkTime_StartTime","WorkTime_Duration_in_sec","SourceOfEntry","IsCreated","IsModified","IsDeleted","Creation_Timestamp","Tenant_RefID","Modification_Timestamp" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter CMN_BPT_EMP_EffectiveWorkTime_PositionHistoryID of type Guid
						_CMN_BPT_EMP_EffectiveWorkTime_PositionHistoryID = reader.GetGuid(0);
						//1:Parameter EffectiveWorkTime_Header_RefID of type Guid
						_EffectiveWorkTime_Header_RefID = reader.GetGuid(1);
						//2:Parameter EffectiveWorkTime_Position_RefID of type Guid
						_EffectiveWorkTime_Position_RefID = reader.GetGuid(2);
						//3:Parameter TriggeredAt_Date of type DateTime
						_TriggeredAt_Date = reader.GetDate(3);
						//4:Parameter TriggeredBy_BusinessParticipant_RefID of type Guid
						_TriggeredBy_BusinessParticipant_RefID = reader.GetGuid(4);
						//5:Parameter TriggeredBy_SourceOfEntry of type int
						_TriggeredBy_SourceOfEntry = reader.GetInteger(5);
						//6:Parameter Comment of type String
						_Comment = reader.GetString(6);
						//7:Parameter Activity_RefID of type Guid
						_Activity_RefID = reader.GetGuid(7);
						//8:Parameter Workplace_RefID of type Guid
						_Workplace_RefID = reader.GetGuid(8);
						//9:Parameter CMN_BPT_EMP_Employee_LeaveRequest_RefID of type Guid
						_CMN_BPT_EMP_Employee_LeaveRequest_RefID = reader.GetGuid(9);
						//10:Parameter WorkTime_StartTime of type DateTime
						_WorkTime_StartTime = reader.GetDate(10);
						//11:Parameter WorkTime_Duration_in_sec of type int
						_WorkTime_Duration_in_sec = reader.GetInteger(11);
						//12:Parameter SourceOfEntry of type int
						_SourceOfEntry = reader.GetInteger(12);
						//13:Parameter IsCreated of type Boolean
						_IsCreated = reader.GetBoolean(13);
						//14:Parameter IsModified of type Boolean
						_IsModified = reader.GetBoolean(14);
						//15:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(15);
						//16:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(16);
						//17:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(17);
						//18:Parameter Modification_Timestamp of type DateTime
						_Modification_Timestamp = reader.GetDate(18);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_CMN_BPT_EMP_EffectiveWorkTime_PositionHistoryID != Guid.Empty){
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
			public Guid? CMN_BPT_EMP_EffectiveWorkTime_PositionHistoryID {	get; set; }
			public Guid? EffectiveWorkTime_Header_RefID {	get; set; }
			public Guid? EffectiveWorkTime_Position_RefID {	get; set; }
			public DateTime? TriggeredAt_Date {	get; set; }
			public Guid? TriggeredBy_BusinessParticipant_RefID {	get; set; }
			public int? TriggeredBy_SourceOfEntry {	get; set; }
			public String Comment {	get; set; }
			public Guid? Activity_RefID {	get; set; }
			public Guid? Workplace_RefID {	get; set; }
			public Guid? CMN_BPT_EMP_Employee_LeaveRequest_RefID {	get; set; }
			public DateTime? WorkTime_StartTime {	get; set; }
			public int? WorkTime_Duration_in_sec {	get; set; }
			public int? SourceOfEntry {	get; set; }
			public Boolean? IsCreated {	get; set; }
			public Boolean? IsModified {	get; set; }
			public Boolean? IsDeleted {	get; set; }
			public DateTime? Creation_Timestamp {	get; set; }
			public Guid? Tenant_RefID {	get; set; }
			public DateTime? Modification_Timestamp {	get; set; }
			 

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
			public static List<ORM_CMN_BPT_EMP_EffectiveWorkTime_PositionHistory> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_CMN_BPT_EMP_EffectiveWorkTime_PositionHistory> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_CMN_BPT_EMP_EffectiveWorkTime_PositionHistory> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_CMN_BPT_EMP_EffectiveWorkTime_PositionHistory> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_CMN_BPT_EMP_EffectiveWorkTime_PositionHistory> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_CMN_BPT_EMP_EffectiveWorkTime_PositionHistory>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_BPT_EMP_EffectiveWorkTime_PositionHistoryID","EffectiveWorkTime_Header_RefID","EffectiveWorkTime_Position_RefID","TriggeredAt_Date","TriggeredBy_BusinessParticipant_RefID","TriggeredBy_SourceOfEntry","Comment","Activity_RefID","Workplace_RefID","CMN_BPT_EMP_Employee_LeaveRequest_RefID","WorkTime_StartTime","WorkTime_Duration_in_sec","SourceOfEntry","IsCreated","IsModified","IsDeleted","Creation_Timestamp","Tenant_RefID","Modification_Timestamp" });
			        while (reader.Read())
			        {
			            ORM_CMN_BPT_EMP_EffectiveWorkTime_PositionHistory item = new ORM_CMN_BPT_EMP_EffectiveWorkTime_PositionHistory();
						//0:Parameter CMN_BPT_EMP_EffectiveWorkTime_PositionHistoryID of type Guid
						item.CMN_BPT_EMP_EffectiveWorkTime_PositionHistoryID = reader.GetGuid(0);
						//1:Parameter EffectiveWorkTime_Header_RefID of type Guid
						item.EffectiveWorkTime_Header_RefID = reader.GetGuid(1);
						//2:Parameter EffectiveWorkTime_Position_RefID of type Guid
						item.EffectiveWorkTime_Position_RefID = reader.GetGuid(2);
						//3:Parameter TriggeredAt_Date of type DateTime
						item.TriggeredAt_Date = reader.GetDate(3);
						//4:Parameter TriggeredBy_BusinessParticipant_RefID of type Guid
						item.TriggeredBy_BusinessParticipant_RefID = reader.GetGuid(4);
						//5:Parameter TriggeredBy_SourceOfEntry of type int
						item.TriggeredBy_SourceOfEntry = reader.GetInteger(5);
						//6:Parameter Comment of type String
						item.Comment = reader.GetString(6);
						//7:Parameter Activity_RefID of type Guid
						item.Activity_RefID = reader.GetGuid(7);
						//8:Parameter Workplace_RefID of type Guid
						item.Workplace_RefID = reader.GetGuid(8);
						//9:Parameter CMN_BPT_EMP_Employee_LeaveRequest_RefID of type Guid
						item.CMN_BPT_EMP_Employee_LeaveRequest_RefID = reader.GetGuid(9);
						//10:Parameter WorkTime_StartTime of type DateTime
						item.WorkTime_StartTime = reader.GetDate(10);
						//11:Parameter WorkTime_Duration_in_sec of type int
						item.WorkTime_Duration_in_sec = reader.GetInteger(11);
						//12:Parameter SourceOfEntry of type int
						item.SourceOfEntry = reader.GetInteger(12);
						//13:Parameter IsCreated of type Boolean
						item.IsCreated = reader.GetBoolean(13);
						//14:Parameter IsModified of type Boolean
						item.IsModified = reader.GetBoolean(14);
						//15:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(15);
						//16:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(16);
						//17:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(17);
						//18:Parameter Modification_Timestamp of type DateTime
						item.Modification_Timestamp = reader.GetDate(18);


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
