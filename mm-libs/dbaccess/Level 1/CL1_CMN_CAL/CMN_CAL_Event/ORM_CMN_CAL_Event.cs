/* 
 * Generated on 7/8/2013 11:37:27 AM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_CMN_CAL
{
	[Serializable]
	public class ORM_CMN_CAL_Event
	{
		public static readonly string TableName = "cmn_cal_events";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_CMN_CAL_Event()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_CMN_CAL_EventID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _CMN_CAL_EventID = default(Guid);
		private Guid _CalendarInstance_RefID = default(Guid);
		private Guid _Repetition_RefID = default(Guid);
		private Boolean _IsRepetitive = default(Boolean);
		private Boolean _IsWholeDayEvent = default(Boolean);
		private DateTime _StartTime = default(DateTime);
		private DateTime _EndTime = default(DateTime);
		private long _R_EventDuration_sec = default(long);
		private Boolean _IsCalendarEvent_Editable = default(Boolean);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Boolean _IsDeleted = default(Boolean);
		private Guid _Tenant_RefID = default(Guid);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid CMN_CAL_EventID { 
			get {
				return _CMN_CAL_EventID;
			}
			set {
				if(_CMN_CAL_EventID != value){
					_CMN_CAL_EventID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid CalendarInstance_RefID { 
			get {
				return _CalendarInstance_RefID;
			}
			set {
				if(_CalendarInstance_RefID != value){
					_CalendarInstance_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Repetition_RefID { 
			get {
				return _Repetition_RefID;
			}
			set {
				if(_Repetition_RefID != value){
					_Repetition_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsRepetitive { 
			get {
				return _IsRepetitive;
			}
			set {
				if(_IsRepetitive != value){
					_IsRepetitive = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsWholeDayEvent { 
			get {
				return _IsWholeDayEvent;
			}
			set {
				if(_IsWholeDayEvent != value){
					_IsWholeDayEvent = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime StartTime { 
			get {
				return _StartTime;
			}
			set {
				if(_StartTime != value){
					_StartTime = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime EndTime { 
			get {
				return _EndTime;
			}
			set {
				if(_EndTime != value){
					_EndTime = value;
					Status_IsDirty = true;
				}
			}
		} 
		public long R_EventDuration_sec { 
			get {
				return _R_EventDuration_sec;
			}
			set {
				if(_R_EventDuration_sec != value){
					_R_EventDuration_sec = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsCalendarEvent_Editable { 
			get {
				return _IsCalendarEvent_Editable;
			}
			set {
				if(_IsCalendarEvent_Editable != value){
					_IsCalendarEvent_Editable = value;
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

				bool saveDictionary = false;
			    bool saveORMClass =   !Status_IsAlreadySaved || Status_IsDirty;


				//If Status Is Dirty (Meaning the data has been changed) or Status_IsAlreadySaved (Meaning the data is in the database, when loaded) just return
				if (saveORMClass == false && saveDictionary == false)
			    {
			        return FR_Base.Status_OK;
			    }


				#region VerifySessionToken/Create Connections
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_CAL.CMN_CAL_Event.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_CAL.CMN_CAL_Event.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_CAL_EventID", _CMN_CAL_EventID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CalendarInstance_RefID", _CalendarInstance_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Repetition_RefID", _Repetition_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsRepetitive", _IsRepetitive);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsWholeDayEvent", _IsWholeDayEvent);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "StartTime", _StartTime);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "EndTime", _EndTime);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "R_EventDuration_sec", _R_EventDuration_sec);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsCalendarEvent_Editable", _IsCalendarEvent_Editable);
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
				#region VerifySessionToken/Create Connections
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_CAL.CMN_CAL_Event.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_CMN_CAL_EventID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CMN_CAL_EventID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_CAL_EventID","CalendarInstance_RefID","Repetition_RefID","IsRepetitive","IsWholeDayEvent","StartTime","EndTime","R_EventDuration_sec","IsCalendarEvent_Editable","Creation_Timestamp","IsDeleted","Tenant_RefID" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter CMN_CAL_EventID of type Guid
						_CMN_CAL_EventID = reader.GetGuid(0);
						//1:Parameter CalendarInstance_RefID of type Guid
						_CalendarInstance_RefID = reader.GetGuid(1);
						//2:Parameter Repetition_RefID of type Guid
						_Repetition_RefID = reader.GetGuid(2);
						//3:Parameter IsRepetitive of type Boolean
						_IsRepetitive = reader.GetBoolean(3);
						//4:Parameter IsWholeDayEvent of type Boolean
						_IsWholeDayEvent = reader.GetBoolean(4);
						//5:Parameter StartTime of type DateTime
						_StartTime = reader.GetDate(5);
						//6:Parameter EndTime of type DateTime
						_EndTime = reader.GetDate(6);
						//7:Parameter R_EventDuration_sec of type long
						_R_EventDuration_sec = reader.GetLong(7);
						//8:Parameter IsCalendarEvent_Editable of type Boolean
						_IsCalendarEvent_Editable = reader.GetBoolean(8);
						//9:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(9);
						//10:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(10);
						//11:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(11);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_CMN_CAL_EventID != Guid.Empty){
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
			public Guid? CMN_CAL_EventID {	get; set; }
			public Guid? CalendarInstance_RefID {	get; set; }
			public Guid? Repetition_RefID {	get; set; }
			public Boolean? IsRepetitive {	get; set; }
			public Boolean? IsWholeDayEvent {	get; set; }
			public DateTime? StartTime {	get; set; }
			public DateTime? EndTime {	get; set; }
			public long? R_EventDuration_sec {	get; set; }
			public Boolean? IsCalendarEvent_Editable {	get; set; }
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
			public static List<ORM_CMN_CAL_Event> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_CMN_CAL_Event> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_CMN_CAL_Event> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_CMN_CAL_Event> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_CMN_CAL_Event> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_CMN_CAL_Event>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_CAL_EventID","CalendarInstance_RefID","Repetition_RefID","IsRepetitive","IsWholeDayEvent","StartTime","EndTime","R_EventDuration_sec","IsCalendarEvent_Editable","Creation_Timestamp","IsDeleted","Tenant_RefID" });
			        while (reader.Read())
			        {
			            ORM_CMN_CAL_Event item = new ORM_CMN_CAL_Event();
						//0:Parameter CMN_CAL_EventID of type Guid
						item.CMN_CAL_EventID = reader.GetGuid(0);
						//1:Parameter CalendarInstance_RefID of type Guid
						item.CalendarInstance_RefID = reader.GetGuid(1);
						//2:Parameter Repetition_RefID of type Guid
						item.Repetition_RefID = reader.GetGuid(2);
						//3:Parameter IsRepetitive of type Boolean
						item.IsRepetitive = reader.GetBoolean(3);
						//4:Parameter IsWholeDayEvent of type Boolean
						item.IsWholeDayEvent = reader.GetBoolean(4);
						//5:Parameter StartTime of type DateTime
						item.StartTime = reader.GetDate(5);
						//6:Parameter EndTime of type DateTime
						item.EndTime = reader.GetDate(6);
						//7:Parameter R_EventDuration_sec of type long
						item.R_EventDuration_sec = reader.GetLong(7);
						//8:Parameter IsCalendarEvent_Editable of type Boolean
						item.IsCalendarEvent_Editable = reader.GetBoolean(8);
						//9:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(9);
						//10:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(10);
						//11:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(11);


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
