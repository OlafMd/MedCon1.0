/* 
 * Generated on 12/18/2013 4:14:32 PM
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
	public class ORM_CMN_PRO_SubscribedCatalog
	{
		public static readonly string TableName = "cmn_pro_subscribedcatalogs";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_CMN_PRO_SubscribedCatalog()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_CMN_PRO_SubscribedCatalogID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _CMN_PRO_SubscribedCatalogID = default(Guid);
		private String _CatalogCodeITL = default(String);
		private Guid _SubscribedCatalog_Language_RefID = default(Guid);
		private Guid _SubscribedCatalog_Currency_RefID = default(Guid);
		private String _SubscribedCatalog_Name = default(String);
		private String _SubscribedCatalog_Description = default(String);
		private int _SubscribedCatalog_CurrentRevision = default(int);
		private Guid _PublishingSupplier_RefID = default(Guid);
		private Guid _SubscribedBy_BusinessParticipant_RefID = default(Guid);
		private Guid _SubscribedCatalog_PricelistRelease_RefID = default(Guid);
		private DateTime _SubscribedCatalog_ValidFrom = default(DateTime);
		private DateTime _SubscribedCatalog_ValidThrough = default(DateTime);
		private Boolean _IsCatalogValid = default(Boolean);
		private Boolean _IsCatalogPublic = default(Boolean);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid CMN_PRO_SubscribedCatalogID { 
			get {
				return _CMN_PRO_SubscribedCatalogID;
			}
			set {
				if(_CMN_PRO_SubscribedCatalogID != value){
					_CMN_PRO_SubscribedCatalogID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String CatalogCodeITL { 
			get {
				return _CatalogCodeITL;
			}
			set {
				if(_CatalogCodeITL != value){
					_CatalogCodeITL = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid SubscribedCatalog_Language_RefID { 
			get {
				return _SubscribedCatalog_Language_RefID;
			}
			set {
				if(_SubscribedCatalog_Language_RefID != value){
					_SubscribedCatalog_Language_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid SubscribedCatalog_Currency_RefID { 
			get {
				return _SubscribedCatalog_Currency_RefID;
			}
			set {
				if(_SubscribedCatalog_Currency_RefID != value){
					_SubscribedCatalog_Currency_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String SubscribedCatalog_Name { 
			get {
				return _SubscribedCatalog_Name;
			}
			set {
				if(_SubscribedCatalog_Name != value){
					_SubscribedCatalog_Name = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String SubscribedCatalog_Description { 
			get {
				return _SubscribedCatalog_Description;
			}
			set {
				if(_SubscribedCatalog_Description != value){
					_SubscribedCatalog_Description = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int SubscribedCatalog_CurrentRevision { 
			get {
				return _SubscribedCatalog_CurrentRevision;
			}
			set {
				if(_SubscribedCatalog_CurrentRevision != value){
					_SubscribedCatalog_CurrentRevision = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid PublishingSupplier_RefID { 
			get {
				return _PublishingSupplier_RefID;
			}
			set {
				if(_PublishingSupplier_RefID != value){
					_PublishingSupplier_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid SubscribedBy_BusinessParticipant_RefID { 
			get {
				return _SubscribedBy_BusinessParticipant_RefID;
			}
			set {
				if(_SubscribedBy_BusinessParticipant_RefID != value){
					_SubscribedBy_BusinessParticipant_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid SubscribedCatalog_PricelistRelease_RefID { 
			get {
				return _SubscribedCatalog_PricelistRelease_RefID;
			}
			set {
				if(_SubscribedCatalog_PricelistRelease_RefID != value){
					_SubscribedCatalog_PricelistRelease_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime SubscribedCatalog_ValidFrom { 
			get {
				return _SubscribedCatalog_ValidFrom;
			}
			set {
				if(_SubscribedCatalog_ValidFrom != value){
					_SubscribedCatalog_ValidFrom = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime SubscribedCatalog_ValidThrough { 
			get {
				return _SubscribedCatalog_ValidThrough;
			}
			set {
				if(_SubscribedCatalog_ValidThrough != value){
					_SubscribedCatalog_ValidThrough = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsCatalogValid { 
			get {
				return _IsCatalogValid;
			}
			set {
				if(_IsCatalogValid != value){
					_IsCatalogValid = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsCatalogPublic { 
			get {
				return _IsCatalogPublic;
			}
			set {
				if(_IsCatalogPublic != value){
					_IsCatalogPublic = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_PRO.CMN_PRO_SubscribedCatalog.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_PRO.CMN_PRO_SubscribedCatalog.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_PRO_SubscribedCatalogID", _CMN_PRO_SubscribedCatalogID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CatalogCodeITL", _CatalogCodeITL);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "SubscribedCatalog_Language_RefID", _SubscribedCatalog_Language_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "SubscribedCatalog_Currency_RefID", _SubscribedCatalog_Currency_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "SubscribedCatalog_Name", _SubscribedCatalog_Name);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "SubscribedCatalog_Description", _SubscribedCatalog_Description);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "SubscribedCatalog_CurrentRevision", _SubscribedCatalog_CurrentRevision);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "PublishingSupplier_RefID", _PublishingSupplier_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "SubscribedBy_BusinessParticipant_RefID", _SubscribedBy_BusinessParticipant_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "SubscribedCatalog_PricelistRelease_RefID", _SubscribedCatalog_PricelistRelease_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "SubscribedCatalog_ValidFrom", _SubscribedCatalog_ValidFrom);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "SubscribedCatalog_ValidThrough", _SubscribedCatalog_ValidThrough);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsCatalogValid", _IsCatalogValid);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsCatalogPublic", _IsCatalogPublic);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_PRO.CMN_PRO_SubscribedCatalog.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_CMN_PRO_SubscribedCatalogID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CMN_PRO_SubscribedCatalogID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_PRO_SubscribedCatalogID","CatalogCodeITL","SubscribedCatalog_Language_RefID","SubscribedCatalog_Currency_RefID","SubscribedCatalog_Name","SubscribedCatalog_Description","SubscribedCatalog_CurrentRevision","PublishingSupplier_RefID","SubscribedBy_BusinessParticipant_RefID","SubscribedCatalog_PricelistRelease_RefID","SubscribedCatalog_ValidFrom","SubscribedCatalog_ValidThrough","IsCatalogValid","IsCatalogPublic","Creation_Timestamp","Tenant_RefID","IsDeleted" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter CMN_PRO_SubscribedCatalogID of type Guid
						_CMN_PRO_SubscribedCatalogID = reader.GetGuid(0);
						//1:Parameter CatalogCodeITL of type String
						_CatalogCodeITL = reader.GetString(1);
						//2:Parameter SubscribedCatalog_Language_RefID of type Guid
						_SubscribedCatalog_Language_RefID = reader.GetGuid(2);
						//3:Parameter SubscribedCatalog_Currency_RefID of type Guid
						_SubscribedCatalog_Currency_RefID = reader.GetGuid(3);
						//4:Parameter SubscribedCatalog_Name of type String
						_SubscribedCatalog_Name = reader.GetString(4);
						//5:Parameter SubscribedCatalog_Description of type String
						_SubscribedCatalog_Description = reader.GetString(5);
						//6:Parameter SubscribedCatalog_CurrentRevision of type int
						_SubscribedCatalog_CurrentRevision = reader.GetInteger(6);
						//7:Parameter PublishingSupplier_RefID of type Guid
						_PublishingSupplier_RefID = reader.GetGuid(7);
						//8:Parameter SubscribedBy_BusinessParticipant_RefID of type Guid
						_SubscribedBy_BusinessParticipant_RefID = reader.GetGuid(8);
						//9:Parameter SubscribedCatalog_PricelistRelease_RefID of type Guid
						_SubscribedCatalog_PricelistRelease_RefID = reader.GetGuid(9);
						//10:Parameter SubscribedCatalog_ValidFrom of type DateTime
						_SubscribedCatalog_ValidFrom = reader.GetDate(10);
						//11:Parameter SubscribedCatalog_ValidThrough of type DateTime
						_SubscribedCatalog_ValidThrough = reader.GetDate(11);
						//12:Parameter IsCatalogValid of type Boolean
						_IsCatalogValid = reader.GetBoolean(12);
						//13:Parameter IsCatalogPublic of type Boolean
						_IsCatalogPublic = reader.GetBoolean(13);
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

					if(_CMN_PRO_SubscribedCatalogID != Guid.Empty){
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
			public Guid? CMN_PRO_SubscribedCatalogID {	get; set; }
			public String CatalogCodeITL {	get; set; }
			public Guid? SubscribedCatalog_Language_RefID {	get; set; }
			public Guid? SubscribedCatalog_Currency_RefID {	get; set; }
			public String SubscribedCatalog_Name {	get; set; }
			public String SubscribedCatalog_Description {	get; set; }
			public int? SubscribedCatalog_CurrentRevision {	get; set; }
			public Guid? PublishingSupplier_RefID {	get; set; }
			public Guid? SubscribedBy_BusinessParticipant_RefID {	get; set; }
			public Guid? SubscribedCatalog_PricelistRelease_RefID {	get; set; }
			public DateTime? SubscribedCatalog_ValidFrom {	get; set; }
			public DateTime? SubscribedCatalog_ValidThrough {	get; set; }
			public Boolean? IsCatalogValid {	get; set; }
			public Boolean? IsCatalogPublic {	get; set; }
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
			public static List<ORM_CMN_PRO_SubscribedCatalog> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_CMN_PRO_SubscribedCatalog> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_CMN_PRO_SubscribedCatalog> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_CMN_PRO_SubscribedCatalog> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_CMN_PRO_SubscribedCatalog> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_CMN_PRO_SubscribedCatalog>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_PRO_SubscribedCatalogID","CatalogCodeITL","SubscribedCatalog_Language_RefID","SubscribedCatalog_Currency_RefID","SubscribedCatalog_Name","SubscribedCatalog_Description","SubscribedCatalog_CurrentRevision","PublishingSupplier_RefID","SubscribedBy_BusinessParticipant_RefID","SubscribedCatalog_PricelistRelease_RefID","SubscribedCatalog_ValidFrom","SubscribedCatalog_ValidThrough","IsCatalogValid","IsCatalogPublic","Creation_Timestamp","Tenant_RefID","IsDeleted" });
			        while (reader.Read())
			        {
			            ORM_CMN_PRO_SubscribedCatalog item = new ORM_CMN_PRO_SubscribedCatalog();
						//0:Parameter CMN_PRO_SubscribedCatalogID of type Guid
						item.CMN_PRO_SubscribedCatalogID = reader.GetGuid(0);
						//1:Parameter CatalogCodeITL of type String
						item.CatalogCodeITL = reader.GetString(1);
						//2:Parameter SubscribedCatalog_Language_RefID of type Guid
						item.SubscribedCatalog_Language_RefID = reader.GetGuid(2);
						//3:Parameter SubscribedCatalog_Currency_RefID of type Guid
						item.SubscribedCatalog_Currency_RefID = reader.GetGuid(3);
						//4:Parameter SubscribedCatalog_Name of type String
						item.SubscribedCatalog_Name = reader.GetString(4);
						//5:Parameter SubscribedCatalog_Description of type String
						item.SubscribedCatalog_Description = reader.GetString(5);
						//6:Parameter SubscribedCatalog_CurrentRevision of type int
						item.SubscribedCatalog_CurrentRevision = reader.GetInteger(6);
						//7:Parameter PublishingSupplier_RefID of type Guid
						item.PublishingSupplier_RefID = reader.GetGuid(7);
						//8:Parameter SubscribedBy_BusinessParticipant_RefID of type Guid
						item.SubscribedBy_BusinessParticipant_RefID = reader.GetGuid(8);
						//9:Parameter SubscribedCatalog_PricelistRelease_RefID of type Guid
						item.SubscribedCatalog_PricelistRelease_RefID = reader.GetGuid(9);
						//10:Parameter SubscribedCatalog_ValidFrom of type DateTime
						item.SubscribedCatalog_ValidFrom = reader.GetDate(10);
						//11:Parameter SubscribedCatalog_ValidThrough of type DateTime
						item.SubscribedCatalog_ValidThrough = reader.GetDate(11);
						//12:Parameter IsCatalogValid of type Boolean
						item.IsCatalogValid = reader.GetBoolean(12);
						//13:Parameter IsCatalogPublic of type Boolean
						item.IsCatalogPublic = reader.GetBoolean(13);
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
