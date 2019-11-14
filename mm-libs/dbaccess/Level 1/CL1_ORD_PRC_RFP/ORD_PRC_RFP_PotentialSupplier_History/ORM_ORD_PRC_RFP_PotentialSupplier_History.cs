/* 
 * Generated on 8/5/2014 1:45:40 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_ORD_PRC_RFP
{
	[Serializable]
	public class ORM_ORD_PRC_RFP_PotentialSupplier_History
	{
		public static readonly string TableName = "ord_prc_rfp_potentialsupplier_history";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_ORD_PRC_RFP_PotentialSupplier_History()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_ORD_PRC_RFP_PotentialSupplier_HistoryID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _ORD_PRC_RFP_PotentialSupplier_HistoryID = default(Guid);
		private Guid _ORD_PRC_RFP_PotentialSupplier_RefID = default(Guid);
		private Boolean _IsEvent_ProposalRequest_Sent = default(Boolean);
		private Boolean _IsEvent_ProposalRequest_Revoked = default(Boolean);
		private Boolean _IsEvent_BySupplier_ProposalRequest_ReceptionAcknowledged = default(Boolean);
		private Boolean _IsEvent_BySupplier_ProposalRequest_Declined = default(Boolean);
		private Boolean _IsEvent_ProposalResponse_Received = default(Boolean);
		private Boolean _IsEvent_ProposalResponse_ReceptionAcknowledged = default(Boolean);
		private Boolean _IsEvent_BySupplier_ProposalResponse_Revoked = default(Boolean);
		private Boolean _IsEvent_ProposalResponse_ModificationRequired = default(Boolean);
		private Boolean _IsEvent_ProposalResponse_Declined = default(Boolean);
		private Boolean _IsEvent_ProposalResponse_Accepted = default(Boolean);
		private Guid _Proposal_Document_RefID = default(Guid);
		private String _Comment = default(String);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid ORD_PRC_RFP_PotentialSupplier_HistoryID { 
			get {
				return _ORD_PRC_RFP_PotentialSupplier_HistoryID;
			}
			set {
				if(_ORD_PRC_RFP_PotentialSupplier_HistoryID != value){
					_ORD_PRC_RFP_PotentialSupplier_HistoryID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid ORD_PRC_RFP_PotentialSupplier_RefID { 
			get {
				return _ORD_PRC_RFP_PotentialSupplier_RefID;
			}
			set {
				if(_ORD_PRC_RFP_PotentialSupplier_RefID != value){
					_ORD_PRC_RFP_PotentialSupplier_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsEvent_ProposalRequest_Sent { 
			get {
				return _IsEvent_ProposalRequest_Sent;
			}
			set {
				if(_IsEvent_ProposalRequest_Sent != value){
					_IsEvent_ProposalRequest_Sent = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsEvent_ProposalRequest_Revoked { 
			get {
				return _IsEvent_ProposalRequest_Revoked;
			}
			set {
				if(_IsEvent_ProposalRequest_Revoked != value){
					_IsEvent_ProposalRequest_Revoked = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsEvent_BySupplier_ProposalRequest_ReceptionAcknowledged { 
			get {
				return _IsEvent_BySupplier_ProposalRequest_ReceptionAcknowledged;
			}
			set {
				if(_IsEvent_BySupplier_ProposalRequest_ReceptionAcknowledged != value){
					_IsEvent_BySupplier_ProposalRequest_ReceptionAcknowledged = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsEvent_BySupplier_ProposalRequest_Declined { 
			get {
				return _IsEvent_BySupplier_ProposalRequest_Declined;
			}
			set {
				if(_IsEvent_BySupplier_ProposalRequest_Declined != value){
					_IsEvent_BySupplier_ProposalRequest_Declined = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsEvent_ProposalResponse_Received { 
			get {
				return _IsEvent_ProposalResponse_Received;
			}
			set {
				if(_IsEvent_ProposalResponse_Received != value){
					_IsEvent_ProposalResponse_Received = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsEvent_ProposalResponse_ReceptionAcknowledged { 
			get {
				return _IsEvent_ProposalResponse_ReceptionAcknowledged;
			}
			set {
				if(_IsEvent_ProposalResponse_ReceptionAcknowledged != value){
					_IsEvent_ProposalResponse_ReceptionAcknowledged = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsEvent_BySupplier_ProposalResponse_Revoked { 
			get {
				return _IsEvent_BySupplier_ProposalResponse_Revoked;
			}
			set {
				if(_IsEvent_BySupplier_ProposalResponse_Revoked != value){
					_IsEvent_BySupplier_ProposalResponse_Revoked = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsEvent_ProposalResponse_ModificationRequired { 
			get {
				return _IsEvent_ProposalResponse_ModificationRequired;
			}
			set {
				if(_IsEvent_ProposalResponse_ModificationRequired != value){
					_IsEvent_ProposalResponse_ModificationRequired = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsEvent_ProposalResponse_Declined { 
			get {
				return _IsEvent_ProposalResponse_Declined;
			}
			set {
				if(_IsEvent_ProposalResponse_Declined != value){
					_IsEvent_ProposalResponse_Declined = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsEvent_ProposalResponse_Accepted { 
			get {
				return _IsEvent_ProposalResponse_Accepted;
			}
			set {
				if(_IsEvent_ProposalResponse_Accepted != value){
					_IsEvent_ProposalResponse_Accepted = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Proposal_Document_RefID { 
			get {
				return _Proposal_Document_RefID;
			}
			set {
				if(_Proposal_Document_RefID != value){
					_Proposal_Document_RefID = value;
					Status_IsDirty = true;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_ORD_PRC_RFP.ORD_PRC_RFP_PotentialSupplier_History.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_ORD_PRC_RFP.ORD_PRC_RFP_PotentialSupplier_History.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ORD_PRC_RFP_PotentialSupplier_HistoryID", _ORD_PRC_RFP_PotentialSupplier_HistoryID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ORD_PRC_RFP_PotentialSupplier_RefID", _ORD_PRC_RFP_PotentialSupplier_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsEvent_ProposalRequest_Sent", _IsEvent_ProposalRequest_Sent);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsEvent_ProposalRequest_Revoked", _IsEvent_ProposalRequest_Revoked);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsEvent_BySupplier_ProposalRequest_ReceptionAcknowledged", _IsEvent_BySupplier_ProposalRequest_ReceptionAcknowledged);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsEvent_BySupplier_ProposalRequest_Declined", _IsEvent_BySupplier_ProposalRequest_Declined);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsEvent_ProposalResponse_Received", _IsEvent_ProposalResponse_Received);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsEvent_ProposalResponse_ReceptionAcknowledged", _IsEvent_ProposalResponse_ReceptionAcknowledged);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsEvent_BySupplier_ProposalResponse_Revoked", _IsEvent_BySupplier_ProposalResponse_Revoked);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsEvent_ProposalResponse_ModificationRequired", _IsEvent_ProposalResponse_ModificationRequired);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsEvent_ProposalResponse_Declined", _IsEvent_ProposalResponse_Declined);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsEvent_ProposalResponse_Accepted", _IsEvent_ProposalResponse_Accepted);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Proposal_Document_RefID", _Proposal_Document_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Comment", _Comment);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_ORD_PRC_RFP.ORD_PRC_RFP_PotentialSupplier_History.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_ORD_PRC_RFP_PotentialSupplier_HistoryID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ORD_PRC_RFP_PotentialSupplier_HistoryID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "ORD_PRC_RFP_PotentialSupplier_HistoryID","ORD_PRC_RFP_PotentialSupplier_RefID","IsEvent_ProposalRequest_Sent","IsEvent_ProposalRequest_Revoked","IsEvent_BySupplier_ProposalRequest_ReceptionAcknowledged","IsEvent_BySupplier_ProposalRequest_Declined","IsEvent_ProposalResponse_Received","IsEvent_ProposalResponse_ReceptionAcknowledged","IsEvent_BySupplier_ProposalResponse_Revoked","IsEvent_ProposalResponse_ModificationRequired","IsEvent_ProposalResponse_Declined","IsEvent_ProposalResponse_Accepted","Proposal_Document_RefID","Comment","Creation_Timestamp","Tenant_RefID","IsDeleted" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter ORD_PRC_RFP_PotentialSupplier_HistoryID of type Guid
						_ORD_PRC_RFP_PotentialSupplier_HistoryID = reader.GetGuid(0);
						//1:Parameter ORD_PRC_RFP_PotentialSupplier_RefID of type Guid
						_ORD_PRC_RFP_PotentialSupplier_RefID = reader.GetGuid(1);
						//2:Parameter IsEvent_ProposalRequest_Sent of type Boolean
						_IsEvent_ProposalRequest_Sent = reader.GetBoolean(2);
						//3:Parameter IsEvent_ProposalRequest_Revoked of type Boolean
						_IsEvent_ProposalRequest_Revoked = reader.GetBoolean(3);
						//4:Parameter IsEvent_BySupplier_ProposalRequest_ReceptionAcknowledged of type Boolean
						_IsEvent_BySupplier_ProposalRequest_ReceptionAcknowledged = reader.GetBoolean(4);
						//5:Parameter IsEvent_BySupplier_ProposalRequest_Declined of type Boolean
						_IsEvent_BySupplier_ProposalRequest_Declined = reader.GetBoolean(5);
						//6:Parameter IsEvent_ProposalResponse_Received of type Boolean
						_IsEvent_ProposalResponse_Received = reader.GetBoolean(6);
						//7:Parameter IsEvent_ProposalResponse_ReceptionAcknowledged of type Boolean
						_IsEvent_ProposalResponse_ReceptionAcknowledged = reader.GetBoolean(7);
						//8:Parameter IsEvent_BySupplier_ProposalResponse_Revoked of type Boolean
						_IsEvent_BySupplier_ProposalResponse_Revoked = reader.GetBoolean(8);
						//9:Parameter IsEvent_ProposalResponse_ModificationRequired of type Boolean
						_IsEvent_ProposalResponse_ModificationRequired = reader.GetBoolean(9);
						//10:Parameter IsEvent_ProposalResponse_Declined of type Boolean
						_IsEvent_ProposalResponse_Declined = reader.GetBoolean(10);
						//11:Parameter IsEvent_ProposalResponse_Accepted of type Boolean
						_IsEvent_ProposalResponse_Accepted = reader.GetBoolean(11);
						//12:Parameter Proposal_Document_RefID of type Guid
						_Proposal_Document_RefID = reader.GetGuid(12);
						//13:Parameter Comment of type String
						_Comment = reader.GetString(13);
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

					if(_ORD_PRC_RFP_PotentialSupplier_HistoryID != Guid.Empty){
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
			public Guid? ORD_PRC_RFP_PotentialSupplier_HistoryID {	get; set; }
			public Guid? ORD_PRC_RFP_PotentialSupplier_RefID {	get; set; }
			public Boolean? IsEvent_ProposalRequest_Sent {	get; set; }
			public Boolean? IsEvent_ProposalRequest_Revoked {	get; set; }
			public Boolean? IsEvent_BySupplier_ProposalRequest_ReceptionAcknowledged {	get; set; }
			public Boolean? IsEvent_BySupplier_ProposalRequest_Declined {	get; set; }
			public Boolean? IsEvent_ProposalResponse_Received {	get; set; }
			public Boolean? IsEvent_ProposalResponse_ReceptionAcknowledged {	get; set; }
			public Boolean? IsEvent_BySupplier_ProposalResponse_Revoked {	get; set; }
			public Boolean? IsEvent_ProposalResponse_ModificationRequired {	get; set; }
			public Boolean? IsEvent_ProposalResponse_Declined {	get; set; }
			public Boolean? IsEvent_ProposalResponse_Accepted {	get; set; }
			public Guid? Proposal_Document_RefID {	get; set; }
			public String Comment {	get; set; }
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
			public static List<ORM_ORD_PRC_RFP_PotentialSupplier_History> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_ORD_PRC_RFP_PotentialSupplier_History> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_ORD_PRC_RFP_PotentialSupplier_History> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_ORD_PRC_RFP_PotentialSupplier_History> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_ORD_PRC_RFP_PotentialSupplier_History> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_ORD_PRC_RFP_PotentialSupplier_History>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "ORD_PRC_RFP_PotentialSupplier_HistoryID","ORD_PRC_RFP_PotentialSupplier_RefID","IsEvent_ProposalRequest_Sent","IsEvent_ProposalRequest_Revoked","IsEvent_BySupplier_ProposalRequest_ReceptionAcknowledged","IsEvent_BySupplier_ProposalRequest_Declined","IsEvent_ProposalResponse_Received","IsEvent_ProposalResponse_ReceptionAcknowledged","IsEvent_BySupplier_ProposalResponse_Revoked","IsEvent_ProposalResponse_ModificationRequired","IsEvent_ProposalResponse_Declined","IsEvent_ProposalResponse_Accepted","Proposal_Document_RefID","Comment","Creation_Timestamp","Tenant_RefID","IsDeleted" });
			        while (reader.Read())
			        {
			            ORM_ORD_PRC_RFP_PotentialSupplier_History item = new ORM_ORD_PRC_RFP_PotentialSupplier_History();
						//0:Parameter ORD_PRC_RFP_PotentialSupplier_HistoryID of type Guid
						item.ORD_PRC_RFP_PotentialSupplier_HistoryID = reader.GetGuid(0);
						//1:Parameter ORD_PRC_RFP_PotentialSupplier_RefID of type Guid
						item.ORD_PRC_RFP_PotentialSupplier_RefID = reader.GetGuid(1);
						//2:Parameter IsEvent_ProposalRequest_Sent of type Boolean
						item.IsEvent_ProposalRequest_Sent = reader.GetBoolean(2);
						//3:Parameter IsEvent_ProposalRequest_Revoked of type Boolean
						item.IsEvent_ProposalRequest_Revoked = reader.GetBoolean(3);
						//4:Parameter IsEvent_BySupplier_ProposalRequest_ReceptionAcknowledged of type Boolean
						item.IsEvent_BySupplier_ProposalRequest_ReceptionAcknowledged = reader.GetBoolean(4);
						//5:Parameter IsEvent_BySupplier_ProposalRequest_Declined of type Boolean
						item.IsEvent_BySupplier_ProposalRequest_Declined = reader.GetBoolean(5);
						//6:Parameter IsEvent_ProposalResponse_Received of type Boolean
						item.IsEvent_ProposalResponse_Received = reader.GetBoolean(6);
						//7:Parameter IsEvent_ProposalResponse_ReceptionAcknowledged of type Boolean
						item.IsEvent_ProposalResponse_ReceptionAcknowledged = reader.GetBoolean(7);
						//8:Parameter IsEvent_BySupplier_ProposalResponse_Revoked of type Boolean
						item.IsEvent_BySupplier_ProposalResponse_Revoked = reader.GetBoolean(8);
						//9:Parameter IsEvent_ProposalResponse_ModificationRequired of type Boolean
						item.IsEvent_ProposalResponse_ModificationRequired = reader.GetBoolean(9);
						//10:Parameter IsEvent_ProposalResponse_Declined of type Boolean
						item.IsEvent_ProposalResponse_Declined = reader.GetBoolean(10);
						//11:Parameter IsEvent_ProposalResponse_Accepted of type Boolean
						item.IsEvent_ProposalResponse_Accepted = reader.GetBoolean(11);
						//12:Parameter Proposal_Document_RefID of type Guid
						item.Proposal_Document_RefID = reader.GetGuid(12);
						//13:Parameter Comment of type String
						item.Comment = reader.GetString(13);
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
