/* 
 * Generated on 30.01.2015 17:13:46
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_APP
{
	[Serializable]
	public class ORM_APP_Initialization
	{
		public static readonly string TableName = "app_initializations";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_APP_Initialization()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_APP_InitializationID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _APP_InitializationID = default(Guid);
		private Guid _Application_RefID = default(Guid);
		private Guid _Module_RefID = default(Guid);
		private String _Version = default(String);
		private DateTime _Initialization_StartedAtDate = default(DateTime);
		private DateTime _Initialiaztion_CompletedAtDate = default(DateTime);
		private Boolean _IsInitializationComplete = default(Boolean);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		private DateTime _Modification_Timestamp = default(DateTime);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid APP_InitializationID { 
			get {
				return _APP_InitializationID;
			}
			set {
				if(_APP_InitializationID != value){
					_APP_InitializationID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Application_RefID { 
			get {
				return _Application_RefID;
			}
			set {
				if(_Application_RefID != value){
					_Application_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Module_RefID { 
			get {
				return _Module_RefID;
			}
			set {
				if(_Module_RefID != value){
					_Module_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String Version { 
			get {
				return _Version;
			}
			set {
				if(_Version != value){
					_Version = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime Initialization_StartedAtDate { 
			get {
				return _Initialization_StartedAtDate;
			}
			set {
				if(_Initialization_StartedAtDate != value){
					_Initialization_StartedAtDate = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime Initialiaztion_CompletedAtDate { 
			get {
				return _Initialiaztion_CompletedAtDate;
			}
			set {
				if(_Initialiaztion_CompletedAtDate != value){
					_Initialiaztion_CompletedAtDate = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsInitializationComplete { 
			get {
				return _IsInitializationComplete;
			}
			set {
				if(_IsInitializationComplete != value){
					_IsInitializationComplete = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_APP.APP_Initialization.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_APP.APP_Initialization.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "APP_InitializationID", _APP_InitializationID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Application_RefID", _Application_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Module_RefID", _Module_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Version", _Version);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Initialization_StartedAtDate", _Initialization_StartedAtDate);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Initialiaztion_CompletedAtDate", _Initialiaztion_CompletedAtDate);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsInitializationComplete", _IsInitializationComplete);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Creation_Timestamp", _Creation_Timestamp);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Tenant_RefID", _Tenant_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsDeleted", _IsDeleted);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_APP.APP_Initialization.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_APP_InitializationID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"APP_InitializationID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "APP_InitializationID","Application_RefID","Module_RefID","Version","Initialization_StartedAtDate","Initialiaztion_CompletedAtDate","IsInitializationComplete","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter APP_InitializationID of type Guid
						_APP_InitializationID = reader.GetGuid(0);
						//1:Parameter Application_RefID of type Guid
						_Application_RefID = reader.GetGuid(1);
						//2:Parameter Module_RefID of type Guid
						_Module_RefID = reader.GetGuid(2);
						//3:Parameter Version of type String
						_Version = reader.GetString(3);
						//4:Parameter Initialization_StartedAtDate of type DateTime
						_Initialization_StartedAtDate = reader.GetDate(4);
						//5:Parameter Initialiaztion_CompletedAtDate of type DateTime
						_Initialiaztion_CompletedAtDate = reader.GetDate(5);
						//6:Parameter IsInitializationComplete of type Boolean
						_IsInitializationComplete = reader.GetBoolean(6);
						//7:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(7);
						//8:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(8);
						//9:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(9);
						//10:Parameter Modification_Timestamp of type DateTime
						_Modification_Timestamp = reader.GetDate(10);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_APP_InitializationID != Guid.Empty){
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
			public Guid? APP_InitializationID {	get; set; }
			public Guid? Application_RefID {	get; set; }
			public Guid? Module_RefID {	get; set; }
			public String Version {	get; set; }
			public DateTime? Initialization_StartedAtDate {	get; set; }
			public DateTime? Initialiaztion_CompletedAtDate {	get; set; }
			public Boolean? IsInitializationComplete {	get; set; }
			public DateTime? Creation_Timestamp {	get; set; }
			public Guid? Tenant_RefID {	get; set; }
			public Boolean? IsDeleted {	get; set; }
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
			public static List<ORM_APP_Initialization> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_APP_Initialization> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_APP_Initialization> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_APP_Initialization> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_APP_Initialization> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_APP_Initialization>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "APP_InitializationID","Application_RefID","Module_RefID","Version","Initialization_StartedAtDate","Initialiaztion_CompletedAtDate","IsInitializationComplete","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
			        while (reader.Read())
			        {
			            ORM_APP_Initialization item = new ORM_APP_Initialization();
						//0:Parameter APP_InitializationID of type Guid
						item.APP_InitializationID = reader.GetGuid(0);
						//1:Parameter Application_RefID of type Guid
						item.Application_RefID = reader.GetGuid(1);
						//2:Parameter Module_RefID of type Guid
						item.Module_RefID = reader.GetGuid(2);
						//3:Parameter Version of type String
						item.Version = reader.GetString(3);
						//4:Parameter Initialization_StartedAtDate of type DateTime
						item.Initialization_StartedAtDate = reader.GetDate(4);
						//5:Parameter Initialiaztion_CompletedAtDate of type DateTime
						item.Initialiaztion_CompletedAtDate = reader.GetDate(5);
						//6:Parameter IsInitializationComplete of type Boolean
						item.IsInitializationComplete = reader.GetBoolean(6);
						//7:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(7);
						//8:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(8);
						//9:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(9);
						//10:Parameter Modification_Timestamp of type DateTime
						item.Modification_Timestamp = reader.GetDate(10);


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
