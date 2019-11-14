/* 
 * Generated on 12/13/2013 2:25:55 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;

namespace CL1_CMN_PRO
{
	[Serializable]
	public class ORM_CMN_PRO_Catalog_Revision
	{
		public static readonly string TableName = "cmn_pro_catalog_revisions";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_CMN_PRO_Catalog_Revision()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_CMN_PRO_Catalog_RevisionID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _CMN_PRO_Catalog_RevisionID = default(Guid);
		private Guid _CMN_PRO_Catalog_RefID = default(Guid);
		private String _CatalogRevision_Name = default(String);
		private String _CatalogRevision_Description = default(String);
		private int _RevisionNumber = default(int);
		private DateTime _Valid_From = default(DateTime);
		private DateTime _Valid_Through = default(DateTime);
		private Guid _PublishedBy_BusinessParticipant_RefID = default(Guid);
		private Guid _Default_PricelistRelease_RefID = default(Guid);
		private DateTime _PublishedOn_Date = default(DateTime);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid CMN_PRO_Catalog_RevisionID { 
			get {
				return _CMN_PRO_Catalog_RevisionID;
			}
			set {
				if(_CMN_PRO_Catalog_RevisionID != value){
					_CMN_PRO_Catalog_RevisionID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid CMN_PRO_Catalog_RefID { 
			get {
				return _CMN_PRO_Catalog_RefID;
			}
			set {
				if(_CMN_PRO_Catalog_RefID != value){
					_CMN_PRO_Catalog_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String CatalogRevision_Name { 
			get {
				return _CatalogRevision_Name;
			}
			set {
				if(_CatalogRevision_Name != value){
					_CatalogRevision_Name = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String CatalogRevision_Description { 
			get {
				return _CatalogRevision_Description;
			}
			set {
				if(_CatalogRevision_Description != value){
					_CatalogRevision_Description = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int RevisionNumber { 
			get {
				return _RevisionNumber;
			}
			set {
				if(_RevisionNumber != value){
					_RevisionNumber = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime Valid_From { 
			get {
				return _Valid_From;
			}
			set {
				if(_Valid_From != value){
					_Valid_From = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime Valid_Through { 
			get {
				return _Valid_Through;
			}
			set {
				if(_Valid_Through != value){
					_Valid_Through = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid PublishedBy_BusinessParticipant_RefID { 
			get {
				return _PublishedBy_BusinessParticipant_RefID;
			}
			set {
				if(_PublishedBy_BusinessParticipant_RefID != value){
					_PublishedBy_BusinessParticipant_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Default_PricelistRelease_RefID { 
			get {
				return _Default_PricelistRelease_RefID;
			}
			set {
				if(_Default_PricelistRelease_RefID != value){
					_Default_PricelistRelease_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime PublishedOn_Date { 
			get {
				return _PublishedOn_Date;
			}
			set {
				if(_PublishedOn_Date != value){
					_PublishedOn_Date = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_PRO.CMN_PRO_Catalog_Revision.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_PRO.CMN_PRO_Catalog_Revision.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_PRO_Catalog_RevisionID", _CMN_PRO_Catalog_RevisionID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_PRO_Catalog_RefID", _CMN_PRO_Catalog_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CatalogRevision_Name", _CatalogRevision_Name);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CatalogRevision_Description", _CatalogRevision_Description);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "RevisionNumber", _RevisionNumber);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Valid_From", _Valid_From);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Valid_Through", _Valid_Through);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "PublishedBy_BusinessParticipant_RefID", _PublishedBy_BusinessParticipant_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Default_PricelistRelease_RefID", _Default_PricelistRelease_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "PublishedOn_Date", _PublishedOn_Date);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_PRO.CMN_PRO_Catalog_Revision.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_CMN_PRO_Catalog_RevisionID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CMN_PRO_Catalog_RevisionID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_PRO_Catalog_RevisionID","CMN_PRO_Catalog_RefID","CatalogRevision_Name","CatalogRevision_Description","RevisionNumber","Valid_From","Valid_Through","PublishedBy_BusinessParticipant_RefID","Default_PricelistRelease_RefID","PublishedOn_Date","Creation_Timestamp","Tenant_RefID","IsDeleted" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter CMN_PRO_Catalog_RevisionID of type Guid
						_CMN_PRO_Catalog_RevisionID = reader.GetGuid(0);
						//1:Parameter CMN_PRO_Catalog_RefID of type Guid
						_CMN_PRO_Catalog_RefID = reader.GetGuid(1);
						//2:Parameter CatalogRevision_Name of type String
						_CatalogRevision_Name = reader.GetString(2);
						//3:Parameter CatalogRevision_Description of type String
						_CatalogRevision_Description = reader.GetString(3);
						//4:Parameter RevisionNumber of type int
						_RevisionNumber = reader.GetInteger(4);
						//5:Parameter Valid_From of type DateTime
						_Valid_From = reader.GetDate(5);
						//6:Parameter Valid_Through of type DateTime
						_Valid_Through = reader.GetDate(6);
						//7:Parameter PublishedBy_BusinessParticipant_RefID of type Guid
						_PublishedBy_BusinessParticipant_RefID = reader.GetGuid(7);
						//8:Parameter Default_PricelistRelease_RefID of type Guid
						_Default_PricelistRelease_RefID = reader.GetGuid(8);
						//9:Parameter PublishedOn_Date of type DateTime
						_PublishedOn_Date = reader.GetDate(9);
						//10:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(10);
						//11:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(11);
						//12:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(12);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_CMN_PRO_Catalog_RevisionID != Guid.Empty){
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
			public Guid? CMN_PRO_Catalog_RevisionID {	get; set; }
			public Guid? CMN_PRO_Catalog_RefID {	get; set; }
			public String CatalogRevision_Name {	get; set; }
			public String CatalogRevision_Description {	get; set; }
			public int? RevisionNumber {	get; set; }
			public DateTime? Valid_From {	get; set; }
			public DateTime? Valid_Through {	get; set; }
			public Guid? PublishedBy_BusinessParticipant_RefID {	get; set; }
			public Guid? Default_PricelistRelease_RefID {	get; set; }
			public DateTime? PublishedOn_Date {	get; set; }
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
			public static List<ORM_CMN_PRO_Catalog_Revision> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_CMN_PRO_Catalog_Revision> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_CMN_PRO_Catalog_Revision> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_CMN_PRO_Catalog_Revision> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_CMN_PRO_Catalog_Revision> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_CMN_PRO_Catalog_Revision>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_PRO_Catalog_RevisionID","CMN_PRO_Catalog_RefID","CatalogRevision_Name","CatalogRevision_Description","RevisionNumber","Valid_From","Valid_Through","PublishedBy_BusinessParticipant_RefID","Default_PricelistRelease_RefID","PublishedOn_Date","Creation_Timestamp","Tenant_RefID","IsDeleted" });
			        while (reader.Read())
			        {
			            ORM_CMN_PRO_Catalog_Revision item = new ORM_CMN_PRO_Catalog_Revision();
						//0:Parameter CMN_PRO_Catalog_RevisionID of type Guid
						item.CMN_PRO_Catalog_RevisionID = reader.GetGuid(0);
						//1:Parameter CMN_PRO_Catalog_RefID of type Guid
						item.CMN_PRO_Catalog_RefID = reader.GetGuid(1);
						//2:Parameter CatalogRevision_Name of type String
						item.CatalogRevision_Name = reader.GetString(2);
						//3:Parameter CatalogRevision_Description of type String
						item.CatalogRevision_Description = reader.GetString(3);
						//4:Parameter RevisionNumber of type int
						item.RevisionNumber = reader.GetInteger(4);
						//5:Parameter Valid_From of type DateTime
						item.Valid_From = reader.GetDate(5);
						//6:Parameter Valid_Through of type DateTime
						item.Valid_Through = reader.GetDate(6);
						//7:Parameter PublishedBy_BusinessParticipant_RefID of type Guid
						item.PublishedBy_BusinessParticipant_RefID = reader.GetGuid(7);
						//8:Parameter Default_PricelistRelease_RefID of type Guid
						item.Default_PricelistRelease_RefID = reader.GetGuid(8);
						//9:Parameter PublishedOn_Date of type DateTime
						item.PublishedOn_Date = reader.GetDate(9);
						//10:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(10);
						//11:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(11);
						//12:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(12);


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
