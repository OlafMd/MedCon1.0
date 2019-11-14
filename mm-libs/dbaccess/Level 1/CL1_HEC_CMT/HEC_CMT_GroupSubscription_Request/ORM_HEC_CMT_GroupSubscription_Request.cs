/* 
 * Generated on 20.03.2015 11:08:37
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_HEC_CMT
{
	[Serializable]
	public class ORM_HEC_CMT_GroupSubscription_Request
	{
		public static readonly string TableName = "hec_cmt_groupsubscription_requests";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_HEC_CMT_GroupSubscription_Request()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_HEC_CMT_GroupSubscription_RequestID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _HEC_CMT_GroupSubscription_RequestID = default(Guid);
		private Guid _Membership_RefID = default(Guid);
		private Guid _CommunityGroup_RefID = default(Guid);
		private String _RequestComment = default(String);
		private Boolean _IsRequested = default(Boolean);
		private Boolean _IsRejected = default(Boolean);
		private Guid _IfRejected_ByMember_RefID = default(Guid);
		private String _IfRejected_Reason = default(String);
		private Boolean _IsApproved = default(Boolean);
		private Guid _IfApproved_GroupSubscription_RefID = default(Guid);
		private Guid _IfApproved_ByMember_RefID = default(Guid);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		private DateTime _Modification_Timestamp = default(DateTime);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid HEC_CMT_GroupSubscription_RequestID { 
			get {
				return _HEC_CMT_GroupSubscription_RequestID;
			}
			set {
				if(_HEC_CMT_GroupSubscription_RequestID != value){
					_HEC_CMT_GroupSubscription_RequestID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Membership_RefID { 
			get {
				return _Membership_RefID;
			}
			set {
				if(_Membership_RefID != value){
					_Membership_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid CommunityGroup_RefID { 
			get {
				return _CommunityGroup_RefID;
			}
			set {
				if(_CommunityGroup_RefID != value){
					_CommunityGroup_RefID = value;
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
		public Boolean IsRequested { 
			get {
				return _IsRequested;
			}
			set {
				if(_IsRequested != value){
					_IsRequested = value;
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
		public Guid IfRejected_ByMember_RefID { 
			get {
				return _IfRejected_ByMember_RefID;
			}
			set {
				if(_IfRejected_ByMember_RefID != value){
					_IfRejected_ByMember_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String IfRejected_Reason { 
			get {
				return _IfRejected_Reason;
			}
			set {
				if(_IfRejected_Reason != value){
					_IfRejected_Reason = value;
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
		public Guid IfApproved_GroupSubscription_RefID { 
			get {
				return _IfApproved_GroupSubscription_RefID;
			}
			set {
				if(_IfApproved_GroupSubscription_RefID != value){
					_IfApproved_GroupSubscription_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid IfApproved_ByMember_RefID { 
			get {
				return _IfApproved_ByMember_RefID;
			}
			set {
				if(_IfApproved_ByMember_RefID != value){
					_IfApproved_ByMember_RefID = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC_CMT.HEC_CMT_GroupSubscription_Request.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC_CMT.HEC_CMT_GroupSubscription_Request.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "HEC_CMT_GroupSubscription_RequestID", _HEC_CMT_GroupSubscription_RequestID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Membership_RefID", _Membership_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CommunityGroup_RefID", _CommunityGroup_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "RequestComment", _RequestComment);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsRequested", _IsRequested);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsRejected", _IsRejected);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfRejected_ByMember_RefID", _IfRejected_ByMember_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfRejected_Reason", _IfRejected_Reason);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsApproved", _IsApproved);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfApproved_GroupSubscription_RefID", _IfApproved_GroupSubscription_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfApproved_ByMember_RefID", _IfApproved_ByMember_RefID);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC_CMT.HEC_CMT_GroupSubscription_Request.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_HEC_CMT_GroupSubscription_RequestID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"HEC_CMT_GroupSubscription_RequestID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "HEC_CMT_GroupSubscription_RequestID","Membership_RefID","CommunityGroup_RefID","RequestComment","IsRequested","IsRejected","IfRejected_ByMember_RefID","IfRejected_Reason","IsApproved","IfApproved_GroupSubscription_RefID","IfApproved_ByMember_RefID","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter HEC_CMT_GroupSubscription_RequestID of type Guid
						_HEC_CMT_GroupSubscription_RequestID = reader.GetGuid(0);
						//1:Parameter Membership_RefID of type Guid
						_Membership_RefID = reader.GetGuid(1);
						//2:Parameter CommunityGroup_RefID of type Guid
						_CommunityGroup_RefID = reader.GetGuid(2);
						//3:Parameter RequestComment of type String
						_RequestComment = reader.GetString(3);
						//4:Parameter IsRequested of type Boolean
						_IsRequested = reader.GetBoolean(4);
						//5:Parameter IsRejected of type Boolean
						_IsRejected = reader.GetBoolean(5);
						//6:Parameter IfRejected_ByMember_RefID of type Guid
						_IfRejected_ByMember_RefID = reader.GetGuid(6);
						//7:Parameter IfRejected_Reason of type String
						_IfRejected_Reason = reader.GetString(7);
						//8:Parameter IsApproved of type Boolean
						_IsApproved = reader.GetBoolean(8);
						//9:Parameter IfApproved_GroupSubscription_RefID of type Guid
						_IfApproved_GroupSubscription_RefID = reader.GetGuid(9);
						//10:Parameter IfApproved_ByMember_RefID of type Guid
						_IfApproved_ByMember_RefID = reader.GetGuid(10);
						//11:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(11);
						//12:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(12);
						//13:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(13);
						//14:Parameter Modification_Timestamp of type DateTime
						_Modification_Timestamp = reader.GetDate(14);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_HEC_CMT_GroupSubscription_RequestID != Guid.Empty){
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
			public Guid? HEC_CMT_GroupSubscription_RequestID {	get; set; }
			public Guid? Membership_RefID {	get; set; }
			public Guid? CommunityGroup_RefID {	get; set; }
			public String RequestComment {	get; set; }
			public Boolean? IsRequested {	get; set; }
			public Boolean? IsRejected {	get; set; }
			public Guid? IfRejected_ByMember_RefID {	get; set; }
			public String IfRejected_Reason {	get; set; }
			public Boolean? IsApproved {	get; set; }
			public Guid? IfApproved_GroupSubscription_RefID {	get; set; }
			public Guid? IfApproved_ByMember_RefID {	get; set; }
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
			public static List<ORM_HEC_CMT_GroupSubscription_Request> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_HEC_CMT_GroupSubscription_Request> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_HEC_CMT_GroupSubscription_Request> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_HEC_CMT_GroupSubscription_Request> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_HEC_CMT_GroupSubscription_Request> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_HEC_CMT_GroupSubscription_Request>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "HEC_CMT_GroupSubscription_RequestID","Membership_RefID","CommunityGroup_RefID","RequestComment","IsRequested","IsRejected","IfRejected_ByMember_RefID","IfRejected_Reason","IsApproved","IfApproved_GroupSubscription_RefID","IfApproved_ByMember_RefID","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
			        while (reader.Read())
			        {
			            ORM_HEC_CMT_GroupSubscription_Request item = new ORM_HEC_CMT_GroupSubscription_Request();
						//0:Parameter HEC_CMT_GroupSubscription_RequestID of type Guid
						item.HEC_CMT_GroupSubscription_RequestID = reader.GetGuid(0);
						//1:Parameter Membership_RefID of type Guid
						item.Membership_RefID = reader.GetGuid(1);
						//2:Parameter CommunityGroup_RefID of type Guid
						item.CommunityGroup_RefID = reader.GetGuid(2);
						//3:Parameter RequestComment of type String
						item.RequestComment = reader.GetString(3);
						//4:Parameter IsRequested of type Boolean
						item.IsRequested = reader.GetBoolean(4);
						//5:Parameter IsRejected of type Boolean
						item.IsRejected = reader.GetBoolean(5);
						//6:Parameter IfRejected_ByMember_RefID of type Guid
						item.IfRejected_ByMember_RefID = reader.GetGuid(6);
						//7:Parameter IfRejected_Reason of type String
						item.IfRejected_Reason = reader.GetString(7);
						//8:Parameter IsApproved of type Boolean
						item.IsApproved = reader.GetBoolean(8);
						//9:Parameter IfApproved_GroupSubscription_RefID of type Guid
						item.IfApproved_GroupSubscription_RefID = reader.GetGuid(9);
						//10:Parameter IfApproved_ByMember_RefID of type Guid
						item.IfApproved_ByMember_RefID = reader.GetGuid(10);
						//11:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(11);
						//12:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(12);
						//13:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(13);
						//14:Parameter Modification_Timestamp of type DateTime
						item.Modification_Timestamp = reader.GetDate(14);


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
