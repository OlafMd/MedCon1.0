/* 
 * Generated on 11/15/2013 5:02:51 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;

namespace CL1_LOG_WRH
{
	[Serializable]
	public class ORM_LOG_WRH_Rack
	{
		public static readonly string TableName = "log_wrh_racks";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_LOG_WRH_Rack()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_LOG_WRH_RackID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _LOG_WRH_RackID = default(Guid);
		private String _GlobalPropertyMatchingID = default(String);
		private Guid _Area_RefID = default(Guid);
		private String _Rack_Name = default(String);
		private String _Shelf_NamePrefix = default(String);
		private String _CoordinateCode = default(String);
		private Boolean _Shelves_Use_XCoordinate = default(Boolean);
		private Boolean _Shelves_Use_YCoordinate = default(Boolean);
		private Boolean _Shelves_Use_ZCoordinate = default(Boolean);
		private String _Shelves_XLabel = default(String);
		private String _Shelves_YLabel = default(String);
		private String _Shelves_ZLabel = default(String);
		private Boolean _IsStructureHidden = default(Boolean);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid LOG_WRH_RackID { 
			get {
				return _LOG_WRH_RackID;
			}
			set {
				if(_LOG_WRH_RackID != value){
					_LOG_WRH_RackID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String GlobalPropertyMatchingID { 
			get {
				return _GlobalPropertyMatchingID;
			}
			set {
				if(_GlobalPropertyMatchingID != value){
					_GlobalPropertyMatchingID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Area_RefID { 
			get {
				return _Area_RefID;
			}
			set {
				if(_Area_RefID != value){
					_Area_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String Rack_Name { 
			get {
				return _Rack_Name;
			}
			set {
				if(_Rack_Name != value){
					_Rack_Name = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String Shelf_NamePrefix { 
			get {
				return _Shelf_NamePrefix;
			}
			set {
				if(_Shelf_NamePrefix != value){
					_Shelf_NamePrefix = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String CoordinateCode { 
			get {
				return _CoordinateCode;
			}
			set {
				if(_CoordinateCode != value){
					_CoordinateCode = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean Shelves_Use_XCoordinate { 
			get {
				return _Shelves_Use_XCoordinate;
			}
			set {
				if(_Shelves_Use_XCoordinate != value){
					_Shelves_Use_XCoordinate = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean Shelves_Use_YCoordinate { 
			get {
				return _Shelves_Use_YCoordinate;
			}
			set {
				if(_Shelves_Use_YCoordinate != value){
					_Shelves_Use_YCoordinate = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean Shelves_Use_ZCoordinate { 
			get {
				return _Shelves_Use_ZCoordinate;
			}
			set {
				if(_Shelves_Use_ZCoordinate != value){
					_Shelves_Use_ZCoordinate = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String Shelves_XLabel { 
			get {
				return _Shelves_XLabel;
			}
			set {
				if(_Shelves_XLabel != value){
					_Shelves_XLabel = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String Shelves_YLabel { 
			get {
				return _Shelves_YLabel;
			}
			set {
				if(_Shelves_YLabel != value){
					_Shelves_YLabel = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String Shelves_ZLabel { 
			get {
				return _Shelves_ZLabel;
			}
			set {
				if(_Shelves_ZLabel != value){
					_Shelves_ZLabel = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsStructureHidden { 
			get {
				return _IsStructureHidden;
			}
			set {
				if(_IsStructureHidden != value){
					_IsStructureHidden = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_LOG_WRH.LOG_WRH_Rack.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_LOG_WRH.LOG_WRH_Rack.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "LOG_WRH_RackID", _LOG_WRH_RackID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "GlobalPropertyMatchingID", _GlobalPropertyMatchingID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Area_RefID", _Area_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Rack_Name", _Rack_Name);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Shelf_NamePrefix", _Shelf_NamePrefix);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CoordinateCode", _CoordinateCode);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Shelves_Use_XCoordinate", _Shelves_Use_XCoordinate);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Shelves_Use_YCoordinate", _Shelves_Use_YCoordinate);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Shelves_Use_ZCoordinate", _Shelves_Use_ZCoordinate);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Shelves_XLabel", _Shelves_XLabel);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Shelves_YLabel", _Shelves_YLabel);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Shelves_ZLabel", _Shelves_ZLabel);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsStructureHidden", _IsStructureHidden);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_LOG_WRH.LOG_WRH_Rack.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_LOG_WRH_RackID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"LOG_WRH_RackID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "LOG_WRH_RackID","GlobalPropertyMatchingID","Area_RefID","Rack_Name","Shelf_NamePrefix","CoordinateCode","Shelves_Use_XCoordinate","Shelves_Use_YCoordinate","Shelves_Use_ZCoordinate","Shelves_XLabel","Shelves_YLabel","Shelves_ZLabel","IsStructureHidden","Creation_Timestamp","Tenant_RefID","IsDeleted" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter LOG_WRH_RackID of type Guid
						_LOG_WRH_RackID = reader.GetGuid(0);
						//1:Parameter GlobalPropertyMatchingID of type String
						_GlobalPropertyMatchingID = reader.GetString(1);
						//2:Parameter Area_RefID of type Guid
						_Area_RefID = reader.GetGuid(2);
						//3:Parameter Rack_Name of type String
						_Rack_Name = reader.GetString(3);
						//4:Parameter Shelf_NamePrefix of type String
						_Shelf_NamePrefix = reader.GetString(4);
						//5:Parameter CoordinateCode of type String
						_CoordinateCode = reader.GetString(5);
						//6:Parameter Shelves_Use_XCoordinate of type Boolean
						_Shelves_Use_XCoordinate = reader.GetBoolean(6);
						//7:Parameter Shelves_Use_YCoordinate of type Boolean
						_Shelves_Use_YCoordinate = reader.GetBoolean(7);
						//8:Parameter Shelves_Use_ZCoordinate of type Boolean
						_Shelves_Use_ZCoordinate = reader.GetBoolean(8);
						//9:Parameter Shelves_XLabel of type String
						_Shelves_XLabel = reader.GetString(9);
						//10:Parameter Shelves_YLabel of type String
						_Shelves_YLabel = reader.GetString(10);
						//11:Parameter Shelves_ZLabel of type String
						_Shelves_ZLabel = reader.GetString(11);
						//12:Parameter IsStructureHidden of type Boolean
						_IsStructureHidden = reader.GetBoolean(12);
						//13:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(13);
						//14:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(14);
						//15:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(15);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_LOG_WRH_RackID != Guid.Empty){
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
			public Guid? LOG_WRH_RackID {	get; set; }
			public String GlobalPropertyMatchingID {	get; set; }
			public Guid? Area_RefID {	get; set; }
			public String Rack_Name {	get; set; }
			public String Shelf_NamePrefix {	get; set; }
			public String CoordinateCode {	get; set; }
			public Boolean? Shelves_Use_XCoordinate {	get; set; }
			public Boolean? Shelves_Use_YCoordinate {	get; set; }
			public Boolean? Shelves_Use_ZCoordinate {	get; set; }
			public String Shelves_XLabel {	get; set; }
			public String Shelves_YLabel {	get; set; }
			public String Shelves_ZLabel {	get; set; }
			public Boolean? IsStructureHidden {	get; set; }
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
			public static List<ORM_LOG_WRH_Rack> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_LOG_WRH_Rack> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_LOG_WRH_Rack> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_LOG_WRH_Rack> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_LOG_WRH_Rack> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_LOG_WRH_Rack>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "LOG_WRH_RackID","GlobalPropertyMatchingID","Area_RefID","Rack_Name","Shelf_NamePrefix","CoordinateCode","Shelves_Use_XCoordinate","Shelves_Use_YCoordinate","Shelves_Use_ZCoordinate","Shelves_XLabel","Shelves_YLabel","Shelves_ZLabel","IsStructureHidden","Creation_Timestamp","Tenant_RefID","IsDeleted" });
			        while (reader.Read())
			        {
			            ORM_LOG_WRH_Rack item = new ORM_LOG_WRH_Rack();
						//0:Parameter LOG_WRH_RackID of type Guid
						item.LOG_WRH_RackID = reader.GetGuid(0);
						//1:Parameter GlobalPropertyMatchingID of type String
						item.GlobalPropertyMatchingID = reader.GetString(1);
						//2:Parameter Area_RefID of type Guid
						item.Area_RefID = reader.GetGuid(2);
						//3:Parameter Rack_Name of type String
						item.Rack_Name = reader.GetString(3);
						//4:Parameter Shelf_NamePrefix of type String
						item.Shelf_NamePrefix = reader.GetString(4);
						//5:Parameter CoordinateCode of type String
						item.CoordinateCode = reader.GetString(5);
						//6:Parameter Shelves_Use_XCoordinate of type Boolean
						item.Shelves_Use_XCoordinate = reader.GetBoolean(6);
						//7:Parameter Shelves_Use_YCoordinate of type Boolean
						item.Shelves_Use_YCoordinate = reader.GetBoolean(7);
						//8:Parameter Shelves_Use_ZCoordinate of type Boolean
						item.Shelves_Use_ZCoordinate = reader.GetBoolean(8);
						//9:Parameter Shelves_XLabel of type String
						item.Shelves_XLabel = reader.GetString(9);
						//10:Parameter Shelves_YLabel of type String
						item.Shelves_YLabel = reader.GetString(10);
						//11:Parameter Shelves_ZLabel of type String
						item.Shelves_ZLabel = reader.GetString(11);
						//12:Parameter IsStructureHidden of type Boolean
						item.IsStructureHidden = reader.GetBoolean(12);
						//13:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(13);
						//14:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(14);
						//15:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(15);


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
