/* 
 * Generated on 2/10/2015 2:22:44 AM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_HEC_CMT_OPT
{
	[Serializable]
	public class ORM_HEC_CMT_OPT_UploadedProcedure
	{
		public static readonly string TableName = "hec_cmt_opt_uploadedprocedures";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_HEC_CMT_OPT_UploadedProcedure()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_HEC_CMT_OPT_UploadedProcedureID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _HEC_CMT_OPT_UploadedProcedureID = default(Guid);
		private Guid _UploadedBy_Member_RefID = default(Guid);
		private String _Uploaded_PotentialProcedureITL = default(String);
		private String _Uploaded_PotentialProcedureCatalogITL = default(String);
		private String _PotentialProcedure_DisplayName = default(String);
		private String _PotentialProcedureCatalog_DisplayName = default(String);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		private DateTime _Modification_Timestamp = default(DateTime);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid HEC_CMT_OPT_UploadedProcedureID { 
			get {
				return _HEC_CMT_OPT_UploadedProcedureID;
			}
			set {
				if(_HEC_CMT_OPT_UploadedProcedureID != value){
					_HEC_CMT_OPT_UploadedProcedureID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid UploadedBy_Member_RefID { 
			get {
				return _UploadedBy_Member_RefID;
			}
			set {
				if(_UploadedBy_Member_RefID != value){
					_UploadedBy_Member_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String Uploaded_PotentialProcedureITL { 
			get {
				return _Uploaded_PotentialProcedureITL;
			}
			set {
				if(_Uploaded_PotentialProcedureITL != value){
					_Uploaded_PotentialProcedureITL = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String Uploaded_PotentialProcedureCatalogITL { 
			get {
				return _Uploaded_PotentialProcedureCatalogITL;
			}
			set {
				if(_Uploaded_PotentialProcedureCatalogITL != value){
					_Uploaded_PotentialProcedureCatalogITL = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String PotentialProcedure_DisplayName { 
			get {
				return _PotentialProcedure_DisplayName;
			}
			set {
				if(_PotentialProcedure_DisplayName != value){
					_PotentialProcedure_DisplayName = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String PotentialProcedureCatalog_DisplayName { 
			get {
				return _PotentialProcedureCatalog_DisplayName;
			}
			set {
				if(_PotentialProcedureCatalog_DisplayName != value){
					_PotentialProcedureCatalog_DisplayName = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC_CMT_OPT.HEC_CMT_OPT_UploadedProcedure.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC_CMT_OPT.HEC_CMT_OPT_UploadedProcedure.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "HEC_CMT_OPT_UploadedProcedureID", _HEC_CMT_OPT_UploadedProcedureID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "UploadedBy_Member_RefID", _UploadedBy_Member_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Uploaded_PotentialProcedureITL", _Uploaded_PotentialProcedureITL);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Uploaded_PotentialProcedureCatalogITL", _Uploaded_PotentialProcedureCatalogITL);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "PotentialProcedure_DisplayName", _PotentialProcedure_DisplayName);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "PotentialProcedureCatalog_DisplayName", _PotentialProcedureCatalog_DisplayName);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC_CMT_OPT.HEC_CMT_OPT_UploadedProcedure.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_HEC_CMT_OPT_UploadedProcedureID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"HEC_CMT_OPT_UploadedProcedureID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "HEC_CMT_OPT_UploadedProcedureID","UploadedBy_Member_RefID","Uploaded_PotentialProcedureITL","Uploaded_PotentialProcedureCatalogITL","PotentialProcedure_DisplayName","PotentialProcedureCatalog_DisplayName","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter HEC_CMT_OPT_UploadedProcedureID of type Guid
						_HEC_CMT_OPT_UploadedProcedureID = reader.GetGuid(0);
						//1:Parameter UploadedBy_Member_RefID of type Guid
						_UploadedBy_Member_RefID = reader.GetGuid(1);
						//2:Parameter Uploaded_PotentialProcedureITL of type String
						_Uploaded_PotentialProcedureITL = reader.GetString(2);
						//3:Parameter Uploaded_PotentialProcedureCatalogITL of type String
						_Uploaded_PotentialProcedureCatalogITL = reader.GetString(3);
						//4:Parameter PotentialProcedure_DisplayName of type String
						_PotentialProcedure_DisplayName = reader.GetString(4);
						//5:Parameter PotentialProcedureCatalog_DisplayName of type String
						_PotentialProcedureCatalog_DisplayName = reader.GetString(5);
						//6:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(6);
						//7:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(7);
						//8:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(8);
						//9:Parameter Modification_Timestamp of type DateTime
						_Modification_Timestamp = reader.GetDate(9);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_HEC_CMT_OPT_UploadedProcedureID != Guid.Empty){
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
			public Guid? HEC_CMT_OPT_UploadedProcedureID {	get; set; }
			public Guid? UploadedBy_Member_RefID {	get; set; }
			public String Uploaded_PotentialProcedureITL {	get; set; }
			public String Uploaded_PotentialProcedureCatalogITL {	get; set; }
			public String PotentialProcedure_DisplayName {	get; set; }
			public String PotentialProcedureCatalog_DisplayName {	get; set; }
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
			public static List<ORM_HEC_CMT_OPT_UploadedProcedure> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_HEC_CMT_OPT_UploadedProcedure> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_HEC_CMT_OPT_UploadedProcedure> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_HEC_CMT_OPT_UploadedProcedure> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_HEC_CMT_OPT_UploadedProcedure> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_HEC_CMT_OPT_UploadedProcedure>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "HEC_CMT_OPT_UploadedProcedureID","UploadedBy_Member_RefID","Uploaded_PotentialProcedureITL","Uploaded_PotentialProcedureCatalogITL","PotentialProcedure_DisplayName","PotentialProcedureCatalog_DisplayName","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
			        while (reader.Read())
			        {
			            ORM_HEC_CMT_OPT_UploadedProcedure item = new ORM_HEC_CMT_OPT_UploadedProcedure();
						//0:Parameter HEC_CMT_OPT_UploadedProcedureID of type Guid
						item.HEC_CMT_OPT_UploadedProcedureID = reader.GetGuid(0);
						//1:Parameter UploadedBy_Member_RefID of type Guid
						item.UploadedBy_Member_RefID = reader.GetGuid(1);
						//2:Parameter Uploaded_PotentialProcedureITL of type String
						item.Uploaded_PotentialProcedureITL = reader.GetString(2);
						//3:Parameter Uploaded_PotentialProcedureCatalogITL of type String
						item.Uploaded_PotentialProcedureCatalogITL = reader.GetString(3);
						//4:Parameter PotentialProcedure_DisplayName of type String
						item.PotentialProcedure_DisplayName = reader.GetString(4);
						//5:Parameter PotentialProcedureCatalog_DisplayName of type String
						item.PotentialProcedureCatalog_DisplayName = reader.GetString(5);
						//6:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(6);
						//7:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(7);
						//8:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(8);
						//9:Parameter Modification_Timestamp of type DateTime
						item.Modification_Timestamp = reader.GetDate(9);


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
