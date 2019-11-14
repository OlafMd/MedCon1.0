/* 
 * Generated on 16.10.2019 16:56:06
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_BIL
{
	[Serializable]	
	#pragma warning disable CA1707 // Identifiers should not contain underscores
	public class ORM_BIL_BillHeader_History	
	#pragma warning restore CA1707 // Identifiers should not contain underscores
	{
		public static readonly string TableName = "bil_billheader_history";
		public bool StatusIsAlreadySaved { get; set; }
		public bool StatusIsDirty { get; set; }
		public static readonly int QueryTimeout = 600;

		#region Class Constructor
		public ORM_BIL_BillHeader_History()
		{
			StatusIsAlreadySaved = false;
			StatusIsDirty = false;
			//When creating a new class, generate a new UUID
			_BIL_BillHeader_HistoryID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		#pragma warning disable CA1707 // Identifiers should not contain underscores
		private Guid _BIL_BillHeader_HistoryID = default(Guid);
		private Guid _BillHeader_RefID = default(Guid);
		private Boolean _IsCreated = default(Boolean);
		private Boolean _IsModified = default(Boolean);
		private Boolean _IsSentToCustomer = default(Boolean);
		private Guid _TriggeredBy_BusinessParticipant_RefID = default(Guid);
		private String _Comment = default(String);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		private DateTime _Modification_Timestamp = default(DateTime);
		 
		#pragma warning restore CA1707 // Identifiers should not contain underscores
		#endregion

		#region Class Fields - Public Get/Set
		#pragma warning disable CA1707 // Identifiers should not contain underscores
		public Guid BIL_BillHeader_HistoryID { 
			get {
				return _BIL_BillHeader_HistoryID;
			}
			set {
				if(_BIL_BillHeader_HistoryID != value){
					_BIL_BillHeader_HistoryID = value;
					StatusIsDirty = true;
				}
			}
		} 
		public Guid BillHeader_RefID { 
			get {
				return _BillHeader_RefID;
			}
			set {
				if(_BillHeader_RefID != value){
					_BillHeader_RefID = value;
					StatusIsDirty = true;
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
					StatusIsDirty = true;
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
					StatusIsDirty = true;
				}
			}
		} 
		public Boolean IsSentToCustomer { 
			get {
				return _IsSentToCustomer;
			}
			set {
				if(_IsSentToCustomer != value){
					_IsSentToCustomer = value;
					StatusIsDirty = true;
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
					StatusIsDirty = true;
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
					StatusIsDirty = true;
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
					StatusIsDirty = true;
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
					StatusIsDirty = true;
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
					StatusIsDirty = true;
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
					StatusIsDirty = true;
				}
			}
		} 

		#pragma warning restore CA1707 // Identifiers should not contain underscores
		#endregion


		#region Save (Create/Update) Functions	
		public FR_Base Save(string dbConnectionString)
		{
			return Save(null, null, dbConnectionString);
		}

		public FR_Base Save(DbConnection connection)
		{
			return Save(connection, null, null);
		}

		public FR_Base Save(DbConnection connection, DbTransaction transaction)
		{
			return Save(connection, transaction, null);
		}

		protected FR_Base Save(DbConnection connection, DbTransaction transaction, string connectionString)
		{
			//Standard return type
			var retStatus = new FR_Base();

			var cleanupConnection = false;
			var cleanupTransaction = false;
			try
			{
				var saveDictionary = false;
			    var saveOrmClass = !StatusIsAlreadySaved || StatusIsDirty;

				//If Status Is Dirty (Meaning the data has been changed) or StatusIsAlreadySaved (Meaning the data is in the database, when loaded) just return
				if (!saveOrmClass && !saveDictionary)
			    {
			        return FR_Base.Status_OK;
			    }

				#region Verify/Create Connections
				//Create Connection if Connection is null
				if (connection == null)
				{
					cleanupConnection = true;		
					#pragma warning disable CA2000 // Dispose objects before losing scope
					connection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(connectionString);
					#pragma warning restore CA2000 // Dispose objects before losing scope
					connection.Open();
				}

				//Create Transaction if null
				if (transaction == null)
				{
					cleanupTransaction = true;
					transaction = connection.BeginTransaction();
				}
				#endregion

				#region Dictionary Management
				//Save dictionary management
				if (saveDictionary)
				{ 
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(connection, transaction);
					//Save the dictionary or update based on if it has already been saved to the database
					if (StatusIsAlreadySaved)
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
				if (saveOrmClass) {
					//Retrieve query
					string query;

					if (StatusIsAlreadySaved)
					{
						#pragma warning disable CA2000 // Dispose objects before losing scope
						query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_BIL.BIL_BillHeader_History.SQL.Update.sql")).ReadToEnd();
						#pragma warning restore CA2000 // Dispose objects before losing scope
					}
					else
					{
						#pragma warning disable CA2000 // Dispose objects before losing scope
						query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_BIL.BIL_BillHeader_History.SQL.Insert.sql")).ReadToEnd();
						#pragma warning restore CA2000 // Dispose objects before losing scope
					}

					var command = connection.CreateCommand();
					command.Connection = connection;
					command.Transaction = transaction;
					command.CommandText = query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "BIL_BillHeader_HistoryID", _BIL_BillHeader_HistoryID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "BillHeader_RefID", _BillHeader_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsCreated", _IsCreated);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsModified", _IsModified);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsSentToCustomer", _IsSentToCustomer);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "TriggeredBy_BusinessParticipant_RefID", _TriggeredBy_BusinessParticipant_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Comment", _Comment);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Creation_Timestamp", _Creation_Timestamp);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Tenant_RefID", _Tenant_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsDeleted", _IsDeleted);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Modification_Timestamp", _Modification_Timestamp);

					command.ExecuteNonQuery();
					StatusIsAlreadySaved = true;
					StatusIsDirty = false;

					#region Cleanup Transaction/Connection
					//If we started the transaction, we will commit it
					if (cleanupTransaction)
						transaction.Commit();

					//If we opened the connection we will close it
					if (cleanupConnection)
						connection.Close();
					#endregion
				}
				#endregion
			}
			catch (Exception)
			{
				try
				{
					if (cleanupTransaction)
						transaction?.Rollback();
				}
				catch
				{
					// ignored
				}

				try
				{
					if (cleanupConnection)
						connection?.Close();
				}
				catch
				{
					// ignored
				}

				throw;
			}

			return retStatus;
		}
		#endregion

		#region Load Functions
		public FR_Base Load(string dbConnectionString, Guid objectId)
		{
			return Load(null, null, objectId, dbConnectionString);
		}

		public FR_Base Load(DbConnection connection, Guid objectId)
		{
			return Load(connection, null, objectId, null);
		}

		public FR_Base Load(DbConnection connection, DbTransaction transaction, Guid objectId)
		{
			return Load(connection, transaction, objectId, null);
		}

		private FR_Base Load(DbConnection connection, DbTransaction transaction, Guid objectId, string connectionString)
		{
			//Standard return type
			var retStatus = new FR_Base();

			var cleanupConnection = false;
			var cleanupTransaction = false;
			try
			{
				#region Verify/Create Connections
				//Create connection if Connection is null
				if(connection == null)
				{
					cleanupConnection = true;
					connection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(connectionString);
					connection.Open();
				}
				//If transaction is not open/not valid
				if(transaction == null)
				{
					cleanupTransaction = true;
					transaction = connection.BeginTransaction();
				}
				#endregion

				//Get the Select query
				#pragma warning disable CA2000 // Dispose objects before losing scope
				var selectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_BIL.BIL_BillHeader_History.SQL.Select.sql")).ReadToEnd();
				#pragma warning restore CA2000 // Dispose objects before losing scope

				var command = connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = connection;
				command.Transaction = transaction;
				//Set Query/Timeout
				command.CommandText = selectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_BIL_BillHeader_HistoryID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "BIL_BillHeader_HistoryID", objectId );

				#region Command Execution
				var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(connection, transaction);
				var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
				reader.SetOrdinals(new[] { "BIL_BillHeader_HistoryID","BillHeader_RefID","IsCreated","IsModified","IsSentToCustomer","TriggeredBy_BusinessParticipant_RefID","Comment","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
				if (reader.HasRows)
				{
					reader.Read(); //Single result only
					//0:Parameter BIL_BillHeader_HistoryID of type Guid
					_BIL_BillHeader_HistoryID = reader.GetGuid(0);
					//1:Parameter BillHeader_RefID of type Guid
					_BillHeader_RefID = reader.GetGuid(1);
					//2:Parameter IsCreated of type Boolean
					_IsCreated = reader.GetBoolean(2);
					//3:Parameter IsModified of type Boolean
					_IsModified = reader.GetBoolean(3);
					//4:Parameter IsSentToCustomer of type Boolean
					_IsSentToCustomer = reader.GetBoolean(4);
					//5:Parameter TriggeredBy_BusinessParticipant_RefID of type Guid
					_TriggeredBy_BusinessParticipant_RefID = reader.GetGuid(5);
					//6:Parameter Comment of type String
					_Comment = reader.GetString(6);
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

				if(_BIL_BillHeader_HistoryID != Guid.Empty){
					//Successfully loaded
					StatusIsAlreadySaved = true;
					StatusIsDirty = false;
				} else {
					//Fault in loading due to invalid UUID (Guid)
					StatusIsAlreadySaved = false;
					StatusIsDirty = false;
				}
				#endregion

				#region Cleanup Transaction/Connection
				//If we started the transaction, we will commit it
				if (cleanupTransaction)
					transaction.Commit();

				//If we opened the connection we will close it
				if (cleanupConnection)
					connection.Close();
				#endregion

			}
			catch (Exception)
			{
				try
				{
					if (cleanupTransaction)
						transaction?.Rollback();
				}
				catch
				{
					// ignored
				}

				try
				{
					if (cleanupConnection)
						connection?.Close();
				}
				catch
				{
					// ignored
				}

				throw;
			}

			return retStatus;
		}
		#endregion

		#region Remove Functions
		public FR_Base Remove(string dbConnectionString)
		{
			return Remove(null, null, dbConnectionString);
		}

		public FR_Base Remove(DbConnection connection)
		{
			return Remove(connection, null, null);
		}

		public FR_Base Remove(DbConnection connection, DbTransaction transaction)
		{
			return Remove(connection, transaction, null);
		}

		public FR_Base Remove(DbConnection connection, DbTransaction transaction, string connectionString)
		{
			IsDeleted = true;
			return Save(connection, transaction, connectionString);

		}
		#endregion


		#region Custom Queries
		#pragma warning disable CA1034 // Nested types should not be visible
		public class Query : CSV2Core_MySQL.BaseFilterQuery<Query>		
		#pragma warning restore CA1034 // Nested types should not be visible
        {
			#pragma warning disable CA1707 // Identifiers should not contain underscores
			public Guid? BIL_BillHeader_HistoryID {	get; set; }
			public Guid? BillHeader_RefID {	get; set; }
			public Boolean? IsCreated {	get; set; }
			public Boolean? IsModified {	get; set; }
			public Boolean? IsSentToCustomer {	get; set; }
			public Guid? TriggeredBy_BusinessParticipant_RefID {	get; set; }
			public String Comment {	get; set; }
			public DateTime? Creation_Timestamp {	get; set; }
			public Guid? Tenant_RefID {	get; set; }
			public Boolean? IsDeleted {	get; set; }
			public DateTime? Modification_Timestamp {	get; set; }
			 

			#pragma warning restore CA1707 // Identifiers should not contain underscores

			#region Exists
			public static bool Exists(string connectionString, Query query)
			{
				#pragma warning disable CA1062 // Validate arguments of public methods
			    return Exists(query, connectionString, null, null);	
				#pragma warning restore CA1062 // Validate arguments of public methods
			}

			public static bool Exists(DbConnection connection, Query query)
			{
				#pragma warning disable CA1062 // Validate arguments of public methods
			    return Exists(query, null, connection, null);
				#pragma warning restore CA1062 // Validate arguments of public methods
			}

			public static bool Exists(DbConnection connection, DbTransaction transaction, Query query)
			{
				#pragma warning disable CA1062 // Validate arguments of public methods
			    return Exists(query, null, connection, transaction);
				#pragma warning restore CA1062 // Validate arguments of public methods
			}

			private static bool Exists(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
				try
				{
					managedConnection.set(connectionString, connection, transaction);
					var command = managedConnection.manage(query.CreateExistsQuery(TableName));
					command.CommandTimeout = QueryTimeout;
					query.SetParameters(command);

					var reader = command.ExecuteReader();
					reader.Read();
					int resultCount = reader.GetInt32(0);
					reader.Close();
					managedConnection.commit();
					return resultCount == 1;
				} 
				catch (Exception)
				{
					managedConnection.rollback();
					throw;
				}
			}
			#endregion

			#region Search
			public static List<ORM_BIL_BillHeader_History> Search(string connectionString, Query query)
			{
				#pragma warning disable CA1062 // Validate arguments of public methods
			    return Search(query, connectionString, null, null);
				#pragma warning restore CA1062 // Validate arguments of public methods
			}

			public static List<ORM_BIL_BillHeader_History> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
				#pragma warning disable CA1062 // Validate arguments of public methods
			    return Search(query, null, connection, transaction);
				#pragma warning restore CA1062 // Validate arguments of public methods
			}

			private static List<ORM_BIL_BillHeader_History> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_BIL_BillHeader_History> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);

			        var command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        items = new List<ORM_BIL_BillHeader_History>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new[] { "BIL_BillHeader_HistoryID","BillHeader_RefID","IsCreated","IsModified","IsSentToCustomer","TriggeredBy_BusinessParticipant_RefID","Comment","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
			        while (reader.Read())
			        {
			            var item = new ORM_BIL_BillHeader_History();
						//0:Parameter BIL_BillHeader_HistoryID of type Guid
						item.BIL_BillHeader_HistoryID = reader.GetGuid(0);
						//1:Parameter BillHeader_RefID of type Guid
						item.BillHeader_RefID = reader.GetGuid(1);
						//2:Parameter IsCreated of type Boolean
						item.IsCreated = reader.GetBoolean(2);
						//3:Parameter IsModified of type Boolean
						item.IsModified = reader.GetBoolean(3);
						//4:Parameter IsSentToCustomer of type Boolean
						item.IsSentToCustomer = reader.GetBoolean(4);
						//5:Parameter TriggeredBy_BusinessParticipant_RefID of type Guid
						item.TriggeredBy_BusinessParticipant_RefID = reader.GetGuid(5);
						//6:Parameter Comment of type String
						item.Comment = reader.GetString(6);
						//7:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(7);
						//8:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(8);
						//9:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(9);
						//10:Parameter Modification_Timestamp of type DateTime
						item.Modification_Timestamp = reader.GetDate(10);


						item.StatusIsAlreadySaved = true;
			            item.StatusIsDirty = false;
			            items.Add(item);
			        }
			        reader.Close();
			        loader.Load();
			        managedConnection.commit();
			    }
			    catch (Exception)
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
				#pragma warning disable CA1062 // Validate arguments of public methods
			    return Update(query, values, connectionString, null, null);
				#pragma warning restore CA1062 // Validate arguments of public methods
			}

			public static int Update(DbConnection connection, Query query, Query values)
			{
				#pragma warning disable CA1062 // Validate arguments of public methods
			    return Update(query, values, null, connection, null);
				#pragma warning restore CA1062 // Validate arguments of public methods
			}

			public static int Update(DbConnection connection, DbTransaction transaction, Query query, Query values)
			{
				#pragma warning disable CA1062 // Validate arguments of public methods
			    return Update(query, values, null, connection, transaction);
				#pragma warning restore CA1062 // Validate arguments of public methods
			}

			private static int Update(Query query, Query values, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
				try
				{
					managedConnection.set(connectionString, connection, transaction);
					var command = managedConnection.manage(query.CreateUpdateQuery(TableName,values.CreateSetStatement()));
					command.CommandTimeout = QueryTimeout;
					query.SetParameters(command);
					values.SetUpdateValues(command);
					int result = command.ExecuteNonQuery();
					managedConnection.commit();
					return result;
				} 
				catch (Exception)
				{
					managedConnection.rollback();
					throw;
				}
			}
			#endregion

			#region Soft Recover
			public static int SoftRecover(string connectionString, Query query)
			{
				#pragma warning disable CA1062 // Validate arguments of public methods
				return SoftRecover(query, connectionString, null, null);
				#pragma warning restore CA1062 // Validate arguments of public methods
			}

			public static int SoftRecover(DbConnection connection, Query query)
			{
				#pragma warning disable CA1062 // Validate arguments of public methods
			    return SoftRecover(query, null, connection, null);
				#pragma warning restore CA1062 // Validate arguments of public methods
			}

			public static int SoftRecover(DbConnection connection, DbTransaction transaction, Query query)
			{
				#pragma warning disable CA1062 // Validate arguments of public methods
			    return SoftRecover(query, null, connection, transaction);
				#pragma warning restore CA1062 // Validate arguments of public methods
			}

			private static int SoftRecover(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
				try
				{
					managedConnection.set(connectionString, connection, transaction);
					var command = managedConnection.manage(query.CreateSoftDeleteQuery(TableName,false));
					command.CommandTimeout = QueryTimeout;
					query.SetParameters(command);
					int result = command.ExecuteNonQuery();
					managedConnection.commit();
					return result;
				} 
				catch (Exception)
				{
					managedConnection.rollback();
					throw;
				}
			}
			#endregion

			#region Soft Delete
			public static int SoftDelete(string connectionString, Query query)
			{
				#pragma warning disable CA1062 // Validate arguments of public methods
			    return SoftDelete(query, connectionString, null, null);
				#pragma warning restore CA1062 // Validate arguments of public methods
			}

			public static int SoftDelete(DbConnection connection, Query query)
			{
				#pragma warning disable CA1062 // Validate arguments of public methods
			    return SoftDelete(query, null, connection, null);
				#pragma warning restore CA1062 // Validate arguments of public methods
			}

			public static int SoftDelete(DbConnection connection, DbTransaction transaction, Query query)
			{
				#pragma warning disable CA1062 // Validate arguments of public methods
			    return SoftDelete(query, null, connection, transaction);
				#pragma warning restore CA1062 // Validate arguments of public methods
			}

			private static int SoftDelete(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
				try
				{
					managedConnection.set(connectionString, connection, transaction);
					var command = managedConnection.manage(query.CreateSoftDeleteQuery(TableName,true));
					command.CommandTimeout = QueryTimeout;
					query.SetParameters(command);
					int result = command.ExecuteNonQuery();
					managedConnection.commit();
					return result;
				} 
				catch (Exception)
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
