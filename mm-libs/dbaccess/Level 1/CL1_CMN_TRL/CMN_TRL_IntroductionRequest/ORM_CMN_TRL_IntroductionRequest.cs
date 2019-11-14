/* 
 * Generated on 21.02.2014 16:59:17
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_CMN_TRL
{
	[Serializable]
	public class ORM_CMN_TRL_IntroductionRequest
	{
		public static readonly string TableName = "cmn_trl_introductionrequests";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_CMN_TRL_IntroductionRequest()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_CMN_TRL_IntroductionRequestID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _CMN_TRL_IntroductionRequestID = default(Guid);
		private String _IntroductionRequestITL = default(String);
		private String _RequestingTenantCode = default(String);
		private String _RequestedForTenantCode = default(String);
		private Boolean _IsApproved = default(Boolean);
		private Boolean _IsRejected = default(Boolean);
		private Boolean _IsPermanentlyRejected = default(Boolean);
		private Guid _PerformedBy_Account_RefID = default(Guid);
		private DateTime _PerformedDate = default(DateTime);
		private String _RejectedReason = default(String);
		private String _RequestTitle = default(String);
		private String _RequestComment = default(String);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid CMN_TRL_IntroductionRequestID { 
			get {
				return _CMN_TRL_IntroductionRequestID;
			}
			set {
				if(_CMN_TRL_IntroductionRequestID != value){
					_CMN_TRL_IntroductionRequestID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String IntroductionRequestITL { 
			get {
				return _IntroductionRequestITL;
			}
			set {
				if(_IntroductionRequestITL != value){
					_IntroductionRequestITL = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String RequestingTenantCode { 
			get {
				return _RequestingTenantCode;
			}
			set {
				if(_RequestingTenantCode != value){
					_RequestingTenantCode = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String RequestedForTenantCode { 
			get {
				return _RequestedForTenantCode;
			}
			set {
				if(_RequestedForTenantCode != value){
					_RequestedForTenantCode = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsApproved { 
			get {
				return _IsApproved;
			}
			set {
				if(_IsApproved != value){
					_IsApproved = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsRejected { 
			get {
				return _IsRejected;
			}
			set {
				if(_IsRejected != value){
					_IsRejected = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsPermanentlyRejected { 
			get {
				return _IsPermanentlyRejected;
			}
			set {
				if(_IsPermanentlyRejected != value){
					_IsPermanentlyRejected = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid PerformedBy_Account_RefID { 
			get {
				return _PerformedBy_Account_RefID;
			}
			set {
				if(_PerformedBy_Account_RefID != value){
					_PerformedBy_Account_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime PerformedDate { 
			get {
				return _PerformedDate;
			}
			set {
				if(_PerformedDate != value){
					_PerformedDate = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String RejectedReason { 
			get {
				return _RejectedReason;
			}
			set {
				if(_RejectedReason != value){
					_RejectedReason = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String RequestTitle { 
			get {
				return _RequestTitle;
			}
			set {
				if(_RequestTitle != value){
					_RequestTitle = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String RequestComment { 
			get {
				return _RequestComment;
			}
			set {
				if(_RequestComment != value){
					_RequestComment = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_TRL.CMN_TRL_IntroductionRequest.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_TRL.CMN_TRL_IntroductionRequest.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_TRL_IntroductionRequestID", _CMN_TRL_IntroductionRequestID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IntroductionRequestITL", _IntroductionRequestITL);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "RequestingTenantCode", _RequestingTenantCode);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "RequestedForTenantCode", _RequestedForTenantCode);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsApproved", _IsApproved);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsRejected", _IsRejected);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsPermanentlyRejected", _IsPermanentlyRejected);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "PerformedBy_Account_RefID", _PerformedBy_Account_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "PerformedDate", _PerformedDate);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "RejectedReason", _RejectedReason);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "RequestTitle", _RequestTitle);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "RequestComment", _RequestComment);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_TRL.CMN_TRL_IntroductionRequest.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_CMN_TRL_IntroductionRequestID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CMN_TRL_IntroductionRequestID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_TRL_IntroductionRequestID","IntroductionRequestITL","RequestingTenantCode","RequestedForTenantCode","IsApproved","IsRejected","IsPermanentlyRejected","PerformedBy_Account_RefID","PerformedDate","RejectedReason","RequestTitle","RequestComment","Creation_Timestamp","Tenant_RefID","IsDeleted" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter CMN_TRL_IntroductionRequestID of type Guid
						_CMN_TRL_IntroductionRequestID = reader.GetGuid(0);
						//1:Parameter IntroductionRequestITL of type String
						_IntroductionRequestITL = reader.GetString(1);
						//2:Parameter RequestingTenantCode of type String
						_RequestingTenantCode = reader.GetString(2);
						//3:Parameter RequestedForTenantCode of type String
						_RequestedForTenantCode = reader.GetString(3);
						//4:Parameter IsApproved of type Boolean
						_IsApproved = reader.GetBoolean(4);
						//5:Parameter IsRejected of type Boolean
						_IsRejected = reader.GetBoolean(5);
						//6:Parameter IsPermanentlyRejected of type Boolean
						_IsPermanentlyRejected = reader.GetBoolean(6);
						//7:Parameter PerformedBy_Account_RefID of type Guid
						_PerformedBy_Account_RefID = reader.GetGuid(7);
						//8:Parameter PerformedDate of type DateTime
						_PerformedDate = reader.GetDate(8);
						//9:Parameter RejectedReason of type String
						_RejectedReason = reader.GetString(9);
						//10:Parameter RequestTitle of type String
						_RequestTitle = reader.GetString(10);
						//11:Parameter RequestComment of type String
						_RequestComment = reader.GetString(11);
						//12:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(12);
						//13:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(13);
						//14:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(14);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_CMN_TRL_IntroductionRequestID != Guid.Empty){
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
			public Guid? CMN_TRL_IntroductionRequestID {	get; set; }
			public String IntroductionRequestITL {	get; set; }
			public String RequestingTenantCode {	get; set; }
			public String RequestedForTenantCode {	get; set; }
			public Boolean? IsApproved {	get; set; }
			public Boolean? IsRejected {	get; set; }
			public Boolean? IsPermanentlyRejected {	get; set; }
			public Guid? PerformedBy_Account_RefID {	get; set; }
			public DateTime? PerformedDate {	get; set; }
			public String RejectedReason {	get; set; }
			public String RequestTitle {	get; set; }
			public String RequestComment {	get; set; }
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
			public static List<ORM_CMN_TRL_IntroductionRequest> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_CMN_TRL_IntroductionRequest> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_CMN_TRL_IntroductionRequest> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_CMN_TRL_IntroductionRequest> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_CMN_TRL_IntroductionRequest> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_CMN_TRL_IntroductionRequest>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_TRL_IntroductionRequestID","IntroductionRequestITL","RequestingTenantCode","RequestedForTenantCode","IsApproved","IsRejected","IsPermanentlyRejected","PerformedBy_Account_RefID","PerformedDate","RejectedReason","RequestTitle","RequestComment","Creation_Timestamp","Tenant_RefID","IsDeleted" });
			        while (reader.Read())
			        {
			            ORM_CMN_TRL_IntroductionRequest item = new ORM_CMN_TRL_IntroductionRequest();
						//0:Parameter CMN_TRL_IntroductionRequestID of type Guid
						item.CMN_TRL_IntroductionRequestID = reader.GetGuid(0);
						//1:Parameter IntroductionRequestITL of type String
						item.IntroductionRequestITL = reader.GetString(1);
						//2:Parameter RequestingTenantCode of type String
						item.RequestingTenantCode = reader.GetString(2);
						//3:Parameter RequestedForTenantCode of type String
						item.RequestedForTenantCode = reader.GetString(3);
						//4:Parameter IsApproved of type Boolean
						item.IsApproved = reader.GetBoolean(4);
						//5:Parameter IsRejected of type Boolean
						item.IsRejected = reader.GetBoolean(5);
						//6:Parameter IsPermanentlyRejected of type Boolean
						item.IsPermanentlyRejected = reader.GetBoolean(6);
						//7:Parameter PerformedBy_Account_RefID of type Guid
						item.PerformedBy_Account_RefID = reader.GetGuid(7);
						//8:Parameter PerformedDate of type DateTime
						item.PerformedDate = reader.GetDate(8);
						//9:Parameter RejectedReason of type String
						item.RejectedReason = reader.GetString(9);
						//10:Parameter RequestTitle of type String
						item.RequestTitle = reader.GetString(10);
						//11:Parameter RequestComment of type String
						item.RequestComment = reader.GetString(11);
						//12:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(12);
						//13:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(13);
						//14:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(14);


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
