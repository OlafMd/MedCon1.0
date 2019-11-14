/* 
 * Generated on 1/20/2014 4:23:21 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;

namespace CL1_CMN_BPT_CTM
{
	[Serializable]
	public class ORM_CMN_BPT_CTM_CatalogProductExtensionRequests
	{
		public static readonly string TableName = "cmn_bpt_ctm_catalogproductextensionrequests";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_CMN_BPT_CTM_CatalogProductExtensionRequests()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_CMN_BPT_CTM_CatalogProductExtensionRequestID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _CMN_BPT_CTM_CatalogProductExtensionRequestID = default(Guid);
		private String _CatalogProductExtensionRequestITL = default(String);
		private Guid _RequestedBy_Customer_BusinessParticipant_RefID = default(Guid);
		private Guid _RequestedBy_Person_BusinessParticipant_RefID = default(Guid);
		private Guid _RequestedFor_Catalog_RefID = default(Guid);
		private String _Request_Question = default(String);
		private String _Request_Answer = default(String);
		private String _RequestCaseIdentifier = default(String);
		private Boolean _IsAnswerSent = default(Boolean);
		private Guid _IfAnswerSent_By_BusinessParticipant_RefID = default(Guid);
		private DateTime _IfAnswerSent_Date = default(DateTime);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid CMN_BPT_CTM_CatalogProductExtensionRequestID { 
			get {
				return _CMN_BPT_CTM_CatalogProductExtensionRequestID;
			}
			set {
				if(_CMN_BPT_CTM_CatalogProductExtensionRequestID != value){
					_CMN_BPT_CTM_CatalogProductExtensionRequestID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String CatalogProductExtensionRequestITL { 
			get {
				return _CatalogProductExtensionRequestITL;
			}
			set {
				if(_CatalogProductExtensionRequestITL != value){
					_CatalogProductExtensionRequestITL = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid RequestedBy_Customer_BusinessParticipant_RefID { 
			get {
				return _RequestedBy_Customer_BusinessParticipant_RefID;
			}
			set {
				if(_RequestedBy_Customer_BusinessParticipant_RefID != value){
					_RequestedBy_Customer_BusinessParticipant_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid RequestedBy_Person_BusinessParticipant_RefID { 
			get {
				return _RequestedBy_Person_BusinessParticipant_RefID;
			}
			set {
				if(_RequestedBy_Person_BusinessParticipant_RefID != value){
					_RequestedBy_Person_BusinessParticipant_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid RequestedFor_Catalog_RefID { 
			get {
				return _RequestedFor_Catalog_RefID;
			}
			set {
				if(_RequestedFor_Catalog_RefID != value){
					_RequestedFor_Catalog_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String Request_Question { 
			get {
				return _Request_Question;
			}
			set {
				if(_Request_Question != value){
					_Request_Question = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String Request_Answer { 
			get {
				return _Request_Answer;
			}
			set {
				if(_Request_Answer != value){
					_Request_Answer = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String RequestCaseIdentifier { 
			get {
				return _RequestCaseIdentifier;
			}
			set {
				if(_RequestCaseIdentifier != value){
					_RequestCaseIdentifier = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsAnswerSent { 
			get {
				return _IsAnswerSent;
			}
			set {
				if(_IsAnswerSent != value){
					_IsAnswerSent = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid IfAnswerSent_By_BusinessParticipant_RefID { 
			get {
				return _IfAnswerSent_By_BusinessParticipant_RefID;
			}
			set {
				if(_IfAnswerSent_By_BusinessParticipant_RefID != value){
					_IfAnswerSent_By_BusinessParticipant_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime IfAnswerSent_Date { 
			get {
				return _IfAnswerSent_Date;
			}
			set {
				if(_IfAnswerSent_Date != value){
					_IfAnswerSent_Date = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_BPT_CTM.CMN_BPT_CTM_CatalogProductExtensionRequests.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_BPT_CTM.CMN_BPT_CTM_CatalogProductExtensionRequests.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_BPT_CTM_CatalogProductExtensionRequestID", _CMN_BPT_CTM_CatalogProductExtensionRequestID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CatalogProductExtensionRequestITL", _CatalogProductExtensionRequestITL);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "RequestedBy_Customer_BusinessParticipant_RefID", _RequestedBy_Customer_BusinessParticipant_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "RequestedBy_Person_BusinessParticipant_RefID", _RequestedBy_Person_BusinessParticipant_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "RequestedFor_Catalog_RefID", _RequestedFor_Catalog_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Request_Question", _Request_Question);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Request_Answer", _Request_Answer);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "RequestCaseIdentifier", _RequestCaseIdentifier);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsAnswerSent", _IsAnswerSent);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfAnswerSent_By_BusinessParticipant_RefID", _IfAnswerSent_By_BusinessParticipant_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfAnswerSent_Date", _IfAnswerSent_Date);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_BPT_CTM.CMN_BPT_CTM_CatalogProductExtensionRequests.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_CMN_BPT_CTM_CatalogProductExtensionRequestID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CMN_BPT_CTM_CatalogProductExtensionRequestID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_BPT_CTM_CatalogProductExtensionRequestID","CatalogProductExtensionRequestITL","RequestedBy_Customer_BusinessParticipant_RefID","RequestedBy_Person_BusinessParticipant_RefID","RequestedFor_Catalog_RefID","Request_Question","Request_Answer","RequestCaseIdentifier","IsAnswerSent","IfAnswerSent_By_BusinessParticipant_RefID","IfAnswerSent_Date","Creation_Timestamp","Tenant_RefID","IsDeleted" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter CMN_BPT_CTM_CatalogProductExtensionRequestID of type Guid
						_CMN_BPT_CTM_CatalogProductExtensionRequestID = reader.GetGuid(0);
						//1:Parameter CatalogProductExtensionRequestITL of type String
						_CatalogProductExtensionRequestITL = reader.GetString(1);
						//2:Parameter RequestedBy_Customer_BusinessParticipant_RefID of type Guid
						_RequestedBy_Customer_BusinessParticipant_RefID = reader.GetGuid(2);
						//3:Parameter RequestedBy_Person_BusinessParticipant_RefID of type Guid
						_RequestedBy_Person_BusinessParticipant_RefID = reader.GetGuid(3);
						//4:Parameter RequestedFor_Catalog_RefID of type Guid
						_RequestedFor_Catalog_RefID = reader.GetGuid(4);
						//5:Parameter Request_Question of type String
						_Request_Question = reader.GetString(5);
						//6:Parameter Request_Answer of type String
						_Request_Answer = reader.GetString(6);
						//7:Parameter RequestCaseIdentifier of type String
						_RequestCaseIdentifier = reader.GetString(7);
						//8:Parameter IsAnswerSent of type Boolean
						_IsAnswerSent = reader.GetBoolean(8);
						//9:Parameter IfAnswerSent_By_BusinessParticipant_RefID of type Guid
						_IfAnswerSent_By_BusinessParticipant_RefID = reader.GetGuid(9);
						//10:Parameter IfAnswerSent_Date of type DateTime
						_IfAnswerSent_Date = reader.GetDate(10);
						//11:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(11);
						//12:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(12);
						//13:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(13);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_CMN_BPT_CTM_CatalogProductExtensionRequestID != Guid.Empty){
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
			public Guid? CMN_BPT_CTM_CatalogProductExtensionRequestID {	get; set; }
			public String CatalogProductExtensionRequestITL {	get; set; }
			public Guid? RequestedBy_Customer_BusinessParticipant_RefID {	get; set; }
			public Guid? RequestedBy_Person_BusinessParticipant_RefID {	get; set; }
			public Guid? RequestedFor_Catalog_RefID {	get; set; }
			public String Request_Question {	get; set; }
			public String Request_Answer {	get; set; }
			public String RequestCaseIdentifier {	get; set; }
			public Boolean? IsAnswerSent {	get; set; }
			public Guid? IfAnswerSent_By_BusinessParticipant_RefID {	get; set; }
			public DateTime? IfAnswerSent_Date {	get; set; }
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
			public static List<ORM_CMN_BPT_CTM_CatalogProductExtensionRequests> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_CMN_BPT_CTM_CatalogProductExtensionRequests> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_CMN_BPT_CTM_CatalogProductExtensionRequests> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_CMN_BPT_CTM_CatalogProductExtensionRequests> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_CMN_BPT_CTM_CatalogProductExtensionRequests> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_CMN_BPT_CTM_CatalogProductExtensionRequests>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_BPT_CTM_CatalogProductExtensionRequestID","CatalogProductExtensionRequestITL","RequestedBy_Customer_BusinessParticipant_RefID","RequestedBy_Person_BusinessParticipant_RefID","RequestedFor_Catalog_RefID","Request_Question","Request_Answer","RequestCaseIdentifier","IsAnswerSent","IfAnswerSent_By_BusinessParticipant_RefID","IfAnswerSent_Date","Creation_Timestamp","Tenant_RefID","IsDeleted" });
			        while (reader.Read())
			        {
			            ORM_CMN_BPT_CTM_CatalogProductExtensionRequests item = new ORM_CMN_BPT_CTM_CatalogProductExtensionRequests();
						//0:Parameter CMN_BPT_CTM_CatalogProductExtensionRequestID of type Guid
						item.CMN_BPT_CTM_CatalogProductExtensionRequestID = reader.GetGuid(0);
						//1:Parameter CatalogProductExtensionRequestITL of type String
						item.CatalogProductExtensionRequestITL = reader.GetString(1);
						//2:Parameter RequestedBy_Customer_BusinessParticipant_RefID of type Guid
						item.RequestedBy_Customer_BusinessParticipant_RefID = reader.GetGuid(2);
						//3:Parameter RequestedBy_Person_BusinessParticipant_RefID of type Guid
						item.RequestedBy_Person_BusinessParticipant_RefID = reader.GetGuid(3);
						//4:Parameter RequestedFor_Catalog_RefID of type Guid
						item.RequestedFor_Catalog_RefID = reader.GetGuid(4);
						//5:Parameter Request_Question of type String
						item.Request_Question = reader.GetString(5);
						//6:Parameter Request_Answer of type String
						item.Request_Answer = reader.GetString(6);
						//7:Parameter RequestCaseIdentifier of type String
						item.RequestCaseIdentifier = reader.GetString(7);
						//8:Parameter IsAnswerSent of type Boolean
						item.IsAnswerSent = reader.GetBoolean(8);
						//9:Parameter IfAnswerSent_By_BusinessParticipant_RefID of type Guid
						item.IfAnswerSent_By_BusinessParticipant_RefID = reader.GetGuid(9);
						//10:Parameter IfAnswerSent_Date of type DateTime
						item.IfAnswerSent_Date = reader.GetDate(10);
						//11:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(11);
						//12:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(12);
						//13:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(13);


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
