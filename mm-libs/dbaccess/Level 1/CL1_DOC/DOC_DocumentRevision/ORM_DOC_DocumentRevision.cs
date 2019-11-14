/* 
 * Generated on 1/21/2015 3:48:06 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_DOC
{
	[Serializable]
	public class ORM_DOC_DocumentRevision
	{
		public static readonly string TableName = "doc_documentrevisions";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_DOC_DocumentRevision()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_DOC_DocumentRevisionID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _DOC_DocumentRevisionID = default(Guid);
		private Guid _Document_RefID = default(Guid);
		private int _Revision = default(int);
		private Boolean _IsLocked = default(Boolean);
		private Boolean _IsLastRevision = default(Boolean);
		private Guid _UploadedByAccount = default(Guid);
		private String _File_Name = default(String);
		private String _File_Description = default(String);
		private String _File_SourceLocation = default(String);
		private String _File_ServerLocation = default(String);
		private String _File_MIMEType = default(String);
		private String _File_Extension = default(String);
		private long _File_Size_Bytes = default(long);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		private DateTime _Modification_Timestamp = default(DateTime);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid DOC_DocumentRevisionID { 
			get {
				return _DOC_DocumentRevisionID;
			}
			set {
				if(_DOC_DocumentRevisionID != value){
					_DOC_DocumentRevisionID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Document_RefID { 
			get {
				return _Document_RefID;
			}
			set {
				if(_Document_RefID != value){
					_Document_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int Revision { 
			get {
				return _Revision;
			}
			set {
				if(_Revision != value){
					_Revision = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsLocked { 
			get {
				return _IsLocked;
			}
			set {
				if(_IsLocked != value){
					_IsLocked = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsLastRevision { 
			get {
				return _IsLastRevision;
			}
			set {
				if(_IsLastRevision != value){
					_IsLastRevision = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid UploadedByAccount { 
			get {
				return _UploadedByAccount;
			}
			set {
				if(_UploadedByAccount != value){
					_UploadedByAccount = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String File_Name { 
			get {
				return _File_Name;
			}
			set {
				if(_File_Name != value){
					_File_Name = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String File_Description { 
			get {
				return _File_Description;
			}
			set {
				if(_File_Description != value){
					_File_Description = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String File_SourceLocation { 
			get {
				return _File_SourceLocation;
			}
			set {
				if(_File_SourceLocation != value){
					_File_SourceLocation = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String File_ServerLocation { 
			get {
				return _File_ServerLocation;
			}
			set {
				if(_File_ServerLocation != value){
					_File_ServerLocation = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String File_MIMEType { 
			get {
				return _File_MIMEType;
			}
			set {
				if(_File_MIMEType != value){
					_File_MIMEType = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String File_Extension { 
			get {
				return _File_Extension;
			}
			set {
				if(_File_Extension != value){
					_File_Extension = value;
					Status_IsDirty = true;
				}
			}
		} 
		public long File_Size_Bytes { 
			get {
				return _File_Size_Bytes;
			}
			set {
				if(_File_Size_Bytes != value){
					_File_Size_Bytes = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_DOC.DOC_DocumentRevision.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_DOC.DOC_DocumentRevision.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "DOC_DocumentRevisionID", _DOC_DocumentRevisionID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Document_RefID", _Document_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Revision", _Revision);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsLocked", _IsLocked);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsLastRevision", _IsLastRevision);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "UploadedByAccount", _UploadedByAccount);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "File_Name", _File_Name);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "File_Description", _File_Description);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "File_SourceLocation", _File_SourceLocation);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "File_ServerLocation", _File_ServerLocation);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "File_MIMEType", _File_MIMEType);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "File_Extension", _File_Extension);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "File_Size_Bytes", _File_Size_Bytes);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_DOC.DOC_DocumentRevision.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_DOC_DocumentRevisionID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"DOC_DocumentRevisionID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "DOC_DocumentRevisionID","Document_RefID","Revision","IsLocked","IsLastRevision","UploadedByAccount","File_Name","File_Description","File_SourceLocation","File_ServerLocation","File_MIMEType","File_Extension","File_Size_Bytes","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter DOC_DocumentRevisionID of type Guid
						_DOC_DocumentRevisionID = reader.GetGuid(0);
						//1:Parameter Document_RefID of type Guid
						_Document_RefID = reader.GetGuid(1);
						//2:Parameter Revision of type int
						_Revision = reader.GetInteger(2);
						//3:Parameter IsLocked of type Boolean
						_IsLocked = reader.GetBoolean(3);
						//4:Parameter IsLastRevision of type Boolean
						_IsLastRevision = reader.GetBoolean(4);
						//5:Parameter UploadedByAccount of type Guid
						_UploadedByAccount = reader.GetGuid(5);
						//6:Parameter File_Name of type String
						_File_Name = reader.GetString(6);
						//7:Parameter File_Description of type String
						_File_Description = reader.GetString(7);
						//8:Parameter File_SourceLocation of type String
						_File_SourceLocation = reader.GetString(8);
						//9:Parameter File_ServerLocation of type String
						_File_ServerLocation = reader.GetString(9);
						//10:Parameter File_MIMEType of type String
						_File_MIMEType = reader.GetString(10);
						//11:Parameter File_Extension of type String
						_File_Extension = reader.GetString(11);
						//12:Parameter File_Size_Bytes of type long
						_File_Size_Bytes = reader.GetLong(12);
						//13:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(13);
						//14:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(14);
						//15:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(15);
						//16:Parameter Modification_Timestamp of type DateTime
						_Modification_Timestamp = reader.GetDate(16);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_DOC_DocumentRevisionID != Guid.Empty){
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
			public Guid? DOC_DocumentRevisionID {	get; set; }
			public Guid? Document_RefID {	get; set; }
			public int? Revision {	get; set; }
			public Boolean? IsLocked {	get; set; }
			public Boolean? IsLastRevision {	get; set; }
			public Guid? UploadedByAccount {	get; set; }
			public String File_Name {	get; set; }
			public String File_Description {	get; set; }
			public String File_SourceLocation {	get; set; }
			public String File_ServerLocation {	get; set; }
			public String File_MIMEType {	get; set; }
			public String File_Extension {	get; set; }
			public long? File_Size_Bytes {	get; set; }
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
			public static List<ORM_DOC_DocumentRevision> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_DOC_DocumentRevision> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_DOC_DocumentRevision> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_DOC_DocumentRevision> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_DOC_DocumentRevision> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_DOC_DocumentRevision>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "DOC_DocumentRevisionID","Document_RefID","Revision","IsLocked","IsLastRevision","UploadedByAccount","File_Name","File_Description","File_SourceLocation","File_ServerLocation","File_MIMEType","File_Extension","File_Size_Bytes","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
			        while (reader.Read())
			        {
			            ORM_DOC_DocumentRevision item = new ORM_DOC_DocumentRevision();
						//0:Parameter DOC_DocumentRevisionID of type Guid
						item.DOC_DocumentRevisionID = reader.GetGuid(0);
						//1:Parameter Document_RefID of type Guid
						item.Document_RefID = reader.GetGuid(1);
						//2:Parameter Revision of type int
						item.Revision = reader.GetInteger(2);
						//3:Parameter IsLocked of type Boolean
						item.IsLocked = reader.GetBoolean(3);
						//4:Parameter IsLastRevision of type Boolean
						item.IsLastRevision = reader.GetBoolean(4);
						//5:Parameter UploadedByAccount of type Guid
						item.UploadedByAccount = reader.GetGuid(5);
						//6:Parameter File_Name of type String
						item.File_Name = reader.GetString(6);
						//7:Parameter File_Description of type String
						item.File_Description = reader.GetString(7);
						//8:Parameter File_SourceLocation of type String
						item.File_SourceLocation = reader.GetString(8);
						//9:Parameter File_ServerLocation of type String
						item.File_ServerLocation = reader.GetString(9);
						//10:Parameter File_MIMEType of type String
						item.File_MIMEType = reader.GetString(10);
						//11:Parameter File_Extension of type String
						item.File_Extension = reader.GetString(11);
						//12:Parameter File_Size_Bytes of type long
						item.File_Size_Bytes = reader.GetLong(12);
						//13:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(13);
						//14:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(14);
						//15:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(15);
						//16:Parameter Modification_Timestamp of type DateTime
						item.Modification_Timestamp = reader.GetDate(16);


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
