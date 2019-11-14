/* 
 * Generated on 2.6.2015 9:56:01
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_ORD_PRC
{
	[Serializable]
	public class ORM_ORD_PRC_ProcurementOrder_StatusHistory
	{
		public static readonly string TableName = "ord_prc_procurementorder_statushistory";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_ORD_PRC_ProcurementOrder_StatusHistory()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_ORD_PRC_ProcurementOrder_StatusHistoryID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _ORD_PRC_ProcurementOrder_StatusHistoryID = default(Guid);
		private Guid _ProcurementOrder_Header_RefID = default(Guid);
		private Guid _ProcurementOrder_Status_RefID = default(Guid);
		private DateTime _TriggeredAt_Date = default(DateTime);
		private Guid _TriggeredBy_BusinessParticipant_RefID = default(Guid);
		private String _StatusHistoryComment = default(String);
		private Boolean _IsStatus_Custom = default(Boolean);
		private Boolean _IsStatus_Created = default(Boolean);
		private Boolean _IsStatus_Approved = default(Boolean);
		private Boolean _IsStatus_Sent = default(Boolean);
		private Boolean _IsStatus_AcceptedBySupplier = default(Boolean);
		private Boolean _IsStatus_Canceled = default(Boolean);
		private Boolean _IsStatus_RejectedBySupplier = default(Boolean);
		private Boolean _IsStatus_ShipmentNotificationReceived = default(Boolean);
		private Boolean _IsStatus_PartiallyReceived = default(Boolean);
		private Boolean _IsStatus_Received = default(Boolean);
		private Boolean _IsStatus_ClearedForPayment = default(Boolean);
		private Boolean _IsStatus_PayedPartially = default(Boolean);
		private Boolean _IsStatus_Payed = default(Boolean);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		private DateTime _Modification_Timestamp = default(DateTime);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid ORD_PRC_ProcurementOrder_StatusHistoryID { 
			get {
				return _ORD_PRC_ProcurementOrder_StatusHistoryID;
			}
			set {
				if(_ORD_PRC_ProcurementOrder_StatusHistoryID != value){
					_ORD_PRC_ProcurementOrder_StatusHistoryID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid ProcurementOrder_Header_RefID { 
			get {
				return _ProcurementOrder_Header_RefID;
			}
			set {
				if(_ProcurementOrder_Header_RefID != value){
					_ProcurementOrder_Header_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid ProcurementOrder_Status_RefID { 
			get {
				return _ProcurementOrder_Status_RefID;
			}
			set {
				if(_ProcurementOrder_Status_RefID != value){
					_ProcurementOrder_Status_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime TriggeredAt_Date { 
			get {
				return _TriggeredAt_Date;
			}
			set {
				if(_TriggeredAt_Date != value){
					_TriggeredAt_Date = value;
					Status_IsDirty = true;
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
					Status_IsDirty = true;
				}
			}
		} 
		public String StatusHistoryComment { 
			get {
				return _StatusHistoryComment;
			}
			set {
				if(_StatusHistoryComment != value){
					_StatusHistoryComment = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsStatus_Custom { 
			get {
				return _IsStatus_Custom;
			}
			set {
				if(_IsStatus_Custom != value){
					_IsStatus_Custom = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsStatus_Created { 
			get {
				return _IsStatus_Created;
			}
			set {
				if(_IsStatus_Created != value){
					_IsStatus_Created = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsStatus_Approved { 
			get {
				return _IsStatus_Approved;
			}
			set {
				if(_IsStatus_Approved != value){
					_IsStatus_Approved = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsStatus_Sent { 
			get {
				return _IsStatus_Sent;
			}
			set {
				if(_IsStatus_Sent != value){
					_IsStatus_Sent = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsStatus_AcceptedBySupplier { 
			get {
				return _IsStatus_AcceptedBySupplier;
			}
			set {
				if(_IsStatus_AcceptedBySupplier != value){
					_IsStatus_AcceptedBySupplier = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsStatus_Canceled { 
			get {
				return _IsStatus_Canceled;
			}
			set {
				if(_IsStatus_Canceled != value){
					_IsStatus_Canceled = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsStatus_RejectedBySupplier { 
			get {
				return _IsStatus_RejectedBySupplier;
			}
			set {
				if(_IsStatus_RejectedBySupplier != value){
					_IsStatus_RejectedBySupplier = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsStatus_ShipmentNotificationReceived { 
			get {
				return _IsStatus_ShipmentNotificationReceived;
			}
			set {
				if(_IsStatus_ShipmentNotificationReceived != value){
					_IsStatus_ShipmentNotificationReceived = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsStatus_PartiallyReceived { 
			get {
				return _IsStatus_PartiallyReceived;
			}
			set {
				if(_IsStatus_PartiallyReceived != value){
					_IsStatus_PartiallyReceived = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsStatus_Received { 
			get {
				return _IsStatus_Received;
			}
			set {
				if(_IsStatus_Received != value){
					_IsStatus_Received = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsStatus_ClearedForPayment { 
			get {
				return _IsStatus_ClearedForPayment;
			}
			set {
				if(_IsStatus_ClearedForPayment != value){
					_IsStatus_ClearedForPayment = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsStatus_PayedPartially { 
			get {
				return _IsStatus_PayedPartially;
			}
			set {
				if(_IsStatus_PayedPartially != value){
					_IsStatus_PayedPartially = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsStatus_Payed { 
			get {
				return _IsStatus_Payed;
			}
			set {
				if(_IsStatus_Payed != value){
					_IsStatus_Payed = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_ORD_PRC.ORD_PRC_ProcurementOrder_StatusHistory.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_ORD_PRC.ORD_PRC_ProcurementOrder_StatusHistory.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ORD_PRC_ProcurementOrder_StatusHistoryID", _ORD_PRC_ProcurementOrder_StatusHistoryID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ProcurementOrder_Header_RefID", _ProcurementOrder_Header_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ProcurementOrder_Status_RefID", _ProcurementOrder_Status_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "TriggeredAt_Date", _TriggeredAt_Date);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "TriggeredBy_BusinessParticipant_RefID", _TriggeredBy_BusinessParticipant_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "StatusHistoryComment", _StatusHistoryComment);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsStatus_Custom", _IsStatus_Custom);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsStatus_Created", _IsStatus_Created);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsStatus_Approved", _IsStatus_Approved);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsStatus_Sent", _IsStatus_Sent);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsStatus_AcceptedBySupplier", _IsStatus_AcceptedBySupplier);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsStatus_Canceled", _IsStatus_Canceled);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsStatus_RejectedBySupplier", _IsStatus_RejectedBySupplier);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsStatus_ShipmentNotificationReceived", _IsStatus_ShipmentNotificationReceived);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsStatus_PartiallyReceived", _IsStatus_PartiallyReceived);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsStatus_Received", _IsStatus_Received);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsStatus_ClearedForPayment", _IsStatus_ClearedForPayment);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsStatus_PayedPartially", _IsStatus_PayedPartially);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsStatus_Payed", _IsStatus_Payed);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_ORD_PRC.ORD_PRC_ProcurementOrder_StatusHistory.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_ORD_PRC_ProcurementOrder_StatusHistoryID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ORD_PRC_ProcurementOrder_StatusHistoryID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "ORD_PRC_ProcurementOrder_StatusHistoryID","ProcurementOrder_Header_RefID","ProcurementOrder_Status_RefID","TriggeredAt_Date","TriggeredBy_BusinessParticipant_RefID","StatusHistoryComment","IsStatus_Custom","IsStatus_Created","IsStatus_Approved","IsStatus_Sent","IsStatus_AcceptedBySupplier","IsStatus_Canceled","IsStatus_RejectedBySupplier","IsStatus_ShipmentNotificationReceived","IsStatus_PartiallyReceived","IsStatus_Received","IsStatus_ClearedForPayment","IsStatus_PayedPartially","IsStatus_Payed","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter ORD_PRC_ProcurementOrder_StatusHistoryID of type Guid
						_ORD_PRC_ProcurementOrder_StatusHistoryID = reader.GetGuid(0);
						//1:Parameter ProcurementOrder_Header_RefID of type Guid
						_ProcurementOrder_Header_RefID = reader.GetGuid(1);
						//2:Parameter ProcurementOrder_Status_RefID of type Guid
						_ProcurementOrder_Status_RefID = reader.GetGuid(2);
						//3:Parameter TriggeredAt_Date of type DateTime
						_TriggeredAt_Date = reader.GetDate(3);
						//4:Parameter TriggeredBy_BusinessParticipant_RefID of type Guid
						_TriggeredBy_BusinessParticipant_RefID = reader.GetGuid(4);
						//5:Parameter StatusHistoryComment of type String
						_StatusHistoryComment = reader.GetString(5);
						//6:Parameter IsStatus_Custom of type Boolean
						_IsStatus_Custom = reader.GetBoolean(6);
						//7:Parameter IsStatus_Created of type Boolean
						_IsStatus_Created = reader.GetBoolean(7);
						//8:Parameter IsStatus_Approved of type Boolean
						_IsStatus_Approved = reader.GetBoolean(8);
						//9:Parameter IsStatus_Sent of type Boolean
						_IsStatus_Sent = reader.GetBoolean(9);
						//10:Parameter IsStatus_AcceptedBySupplier of type Boolean
						_IsStatus_AcceptedBySupplier = reader.GetBoolean(10);
						//11:Parameter IsStatus_Canceled of type Boolean
						_IsStatus_Canceled = reader.GetBoolean(11);
						//12:Parameter IsStatus_RejectedBySupplier of type Boolean
						_IsStatus_RejectedBySupplier = reader.GetBoolean(12);
						//13:Parameter IsStatus_ShipmentNotificationReceived of type Boolean
						_IsStatus_ShipmentNotificationReceived = reader.GetBoolean(13);
						//14:Parameter IsStatus_PartiallyReceived of type Boolean
						_IsStatus_PartiallyReceived = reader.GetBoolean(14);
						//15:Parameter IsStatus_Received of type Boolean
						_IsStatus_Received = reader.GetBoolean(15);
						//16:Parameter IsStatus_ClearedForPayment of type Boolean
						_IsStatus_ClearedForPayment = reader.GetBoolean(16);
						//17:Parameter IsStatus_PayedPartially of type Boolean
						_IsStatus_PayedPartially = reader.GetBoolean(17);
						//18:Parameter IsStatus_Payed of type Boolean
						_IsStatus_Payed = reader.GetBoolean(18);
						//19:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(19);
						//20:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(20);
						//21:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(21);
						//22:Parameter Modification_Timestamp of type DateTime
						_Modification_Timestamp = reader.GetDate(22);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_ORD_PRC_ProcurementOrder_StatusHistoryID != Guid.Empty){
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
			public Guid? ORD_PRC_ProcurementOrder_StatusHistoryID {	get; set; }
			public Guid? ProcurementOrder_Header_RefID {	get; set; }
			public Guid? ProcurementOrder_Status_RefID {	get; set; }
			public DateTime? TriggeredAt_Date {	get; set; }
			public Guid? TriggeredBy_BusinessParticipant_RefID {	get; set; }
			public String StatusHistoryComment {	get; set; }
			public Boolean? IsStatus_Custom {	get; set; }
			public Boolean? IsStatus_Created {	get; set; }
			public Boolean? IsStatus_Approved {	get; set; }
			public Boolean? IsStatus_Sent {	get; set; }
			public Boolean? IsStatus_AcceptedBySupplier {	get; set; }
			public Boolean? IsStatus_Canceled {	get; set; }
			public Boolean? IsStatus_RejectedBySupplier {	get; set; }
			public Boolean? IsStatus_ShipmentNotificationReceived {	get; set; }
			public Boolean? IsStatus_PartiallyReceived {	get; set; }
			public Boolean? IsStatus_Received {	get; set; }
			public Boolean? IsStatus_ClearedForPayment {	get; set; }
			public Boolean? IsStatus_PayedPartially {	get; set; }
			public Boolean? IsStatus_Payed {	get; set; }
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
			public static List<ORM_ORD_PRC_ProcurementOrder_StatusHistory> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_ORD_PRC_ProcurementOrder_StatusHistory> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_ORD_PRC_ProcurementOrder_StatusHistory> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_ORD_PRC_ProcurementOrder_StatusHistory> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_ORD_PRC_ProcurementOrder_StatusHistory> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_ORD_PRC_ProcurementOrder_StatusHistory>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "ORD_PRC_ProcurementOrder_StatusHistoryID","ProcurementOrder_Header_RefID","ProcurementOrder_Status_RefID","TriggeredAt_Date","TriggeredBy_BusinessParticipant_RefID","StatusHistoryComment","IsStatus_Custom","IsStatus_Created","IsStatus_Approved","IsStatus_Sent","IsStatus_AcceptedBySupplier","IsStatus_Canceled","IsStatus_RejectedBySupplier","IsStatus_ShipmentNotificationReceived","IsStatus_PartiallyReceived","IsStatus_Received","IsStatus_ClearedForPayment","IsStatus_PayedPartially","IsStatus_Payed","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
			        while (reader.Read())
			        {
			            ORM_ORD_PRC_ProcurementOrder_StatusHistory item = new ORM_ORD_PRC_ProcurementOrder_StatusHistory();
						//0:Parameter ORD_PRC_ProcurementOrder_StatusHistoryID of type Guid
						item.ORD_PRC_ProcurementOrder_StatusHistoryID = reader.GetGuid(0);
						//1:Parameter ProcurementOrder_Header_RefID of type Guid
						item.ProcurementOrder_Header_RefID = reader.GetGuid(1);
						//2:Parameter ProcurementOrder_Status_RefID of type Guid
						item.ProcurementOrder_Status_RefID = reader.GetGuid(2);
						//3:Parameter TriggeredAt_Date of type DateTime
						item.TriggeredAt_Date = reader.GetDate(3);
						//4:Parameter TriggeredBy_BusinessParticipant_RefID of type Guid
						item.TriggeredBy_BusinessParticipant_RefID = reader.GetGuid(4);
						//5:Parameter StatusHistoryComment of type String
						item.StatusHistoryComment = reader.GetString(5);
						//6:Parameter IsStatus_Custom of type Boolean
						item.IsStatus_Custom = reader.GetBoolean(6);
						//7:Parameter IsStatus_Created of type Boolean
						item.IsStatus_Created = reader.GetBoolean(7);
						//8:Parameter IsStatus_Approved of type Boolean
						item.IsStatus_Approved = reader.GetBoolean(8);
						//9:Parameter IsStatus_Sent of type Boolean
						item.IsStatus_Sent = reader.GetBoolean(9);
						//10:Parameter IsStatus_AcceptedBySupplier of type Boolean
						item.IsStatus_AcceptedBySupplier = reader.GetBoolean(10);
						//11:Parameter IsStatus_Canceled of type Boolean
						item.IsStatus_Canceled = reader.GetBoolean(11);
						//12:Parameter IsStatus_RejectedBySupplier of type Boolean
						item.IsStatus_RejectedBySupplier = reader.GetBoolean(12);
						//13:Parameter IsStatus_ShipmentNotificationReceived of type Boolean
						item.IsStatus_ShipmentNotificationReceived = reader.GetBoolean(13);
						//14:Parameter IsStatus_PartiallyReceived of type Boolean
						item.IsStatus_PartiallyReceived = reader.GetBoolean(14);
						//15:Parameter IsStatus_Received of type Boolean
						item.IsStatus_Received = reader.GetBoolean(15);
						//16:Parameter IsStatus_ClearedForPayment of type Boolean
						item.IsStatus_ClearedForPayment = reader.GetBoolean(16);
						//17:Parameter IsStatus_PayedPartially of type Boolean
						item.IsStatus_PayedPartially = reader.GetBoolean(17);
						//18:Parameter IsStatus_Payed of type Boolean
						item.IsStatus_Payed = reader.GetBoolean(18);
						//19:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(19);
						//20:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(20);
						//21:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(21);
						//22:Parameter Modification_Timestamp of type DateTime
						item.Modification_Timestamp = reader.GetDate(22);


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
