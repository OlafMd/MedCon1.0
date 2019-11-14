/* 
 * Generated on 05/29/15 11:15:45
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
	public class ORM_ORD_PRC_ProcurementOrder_Position_History
	{
		public static readonly string TableName = "ord_prc_procurementorder_position_history";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_ORD_PRC_ProcurementOrder_Position_History()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_ORD_PRC_ProcurementOrder_Position_HistoryID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _ORD_PRC_ProcurementOrder_Position_HistoryID = default(Guid);
		private Guid _ProcurementOrder_Position_RefID = default(Guid);
		private Boolean _IsCreated = default(Boolean);
		private Boolean _IsModified = default(Boolean);
		private Boolean _IsRemoved = default(Boolean);
		private Guid _TriggeredBy_BusinessParticipant_RefID = default(Guid);
		private String _Comment = default(String);
		private Boolean _IsLivePriceRequestProcessTriggered = default(Boolean);
		private double _TriggeredFor_Quantity = default(double);
		private Boolean _IsLivePriceRequestProcessAnswered = default(Boolean);
		private Decimal _AnsweredWith_TotalPrice = default(Decimal);
		private Guid _AnsweredWith_Currency_RefID = default(Guid);
		private double _AnsweredWith_DeliverableQuantity = default(double);
		private DateTime _AnsweredWith_EarliestDeliveryDate = default(DateTime);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		private DateTime _Modification_Timestamp = default(DateTime);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid ORD_PRC_ProcurementOrder_Position_HistoryID { 
			get {
				return _ORD_PRC_ProcurementOrder_Position_HistoryID;
			}
			set {
				if(_ORD_PRC_ProcurementOrder_Position_HistoryID != value){
					_ORD_PRC_ProcurementOrder_Position_HistoryID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid ProcurementOrder_Position_RefID { 
			get {
				return _ProcurementOrder_Position_RefID;
			}
			set {
				if(_ProcurementOrder_Position_RefID != value){
					_ProcurementOrder_Position_RefID = value;
					Status_IsDirty = true;
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
					Status_IsDirty = true;
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
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsRemoved { 
			get {
				return _IsRemoved;
			}
			set {
				if(_IsRemoved != value){
					_IsRemoved = value;
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
		public Boolean IsLivePriceRequestProcessTriggered { 
			get {
				return _IsLivePriceRequestProcessTriggered;
			}
			set {
				if(_IsLivePriceRequestProcessTriggered != value){
					_IsLivePriceRequestProcessTriggered = value;
					Status_IsDirty = true;
				}
			}
		} 
		public double TriggeredFor_Quantity { 
			get {
				return _TriggeredFor_Quantity;
			}
			set {
				if(_TriggeredFor_Quantity != value){
					_TriggeredFor_Quantity = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsLivePriceRequestProcessAnswered { 
			get {
				return _IsLivePriceRequestProcessAnswered;
			}
			set {
				if(_IsLivePriceRequestProcessAnswered != value){
					_IsLivePriceRequestProcessAnswered = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Decimal AnsweredWith_TotalPrice { 
			get {
				return _AnsweredWith_TotalPrice;
			}
			set {
				if(_AnsweredWith_TotalPrice != value){
					_AnsweredWith_TotalPrice = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid AnsweredWith_Currency_RefID { 
			get {
				return _AnsweredWith_Currency_RefID;
			}
			set {
				if(_AnsweredWith_Currency_RefID != value){
					_AnsweredWith_Currency_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public double AnsweredWith_DeliverableQuantity { 
			get {
				return _AnsweredWith_DeliverableQuantity;
			}
			set {
				if(_AnsweredWith_DeliverableQuantity != value){
					_AnsweredWith_DeliverableQuantity = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime AnsweredWith_EarliestDeliveryDate { 
			get {
				return _AnsweredWith_EarliestDeliveryDate;
			}
			set {
				if(_AnsweredWith_EarliestDeliveryDate != value){
					_AnsweredWith_EarliestDeliveryDate = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_ORD_PRC.ORD_PRC_ProcurementOrder_Position_History.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_ORD_PRC.ORD_PRC_ProcurementOrder_Position_History.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ORD_PRC_ProcurementOrder_Position_HistoryID", _ORD_PRC_ProcurementOrder_Position_HistoryID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ProcurementOrder_Position_RefID", _ProcurementOrder_Position_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsCreated", _IsCreated);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsModified", _IsModified);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsRemoved", _IsRemoved);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "TriggeredBy_BusinessParticipant_RefID", _TriggeredBy_BusinessParticipant_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Comment", _Comment);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsLivePriceRequestProcessTriggered", _IsLivePriceRequestProcessTriggered);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "TriggeredFor_Quantity", _TriggeredFor_Quantity);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsLivePriceRequestProcessAnswered", _IsLivePriceRequestProcessAnswered);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "AnsweredWith_TotalPrice", _AnsweredWith_TotalPrice);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "AnsweredWith_Currency_RefID", _AnsweredWith_Currency_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "AnsweredWith_DeliverableQuantity", _AnsweredWith_DeliverableQuantity);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "AnsweredWith_EarliestDeliveryDate", _AnsweredWith_EarliestDeliveryDate);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_ORD_PRC.ORD_PRC_ProcurementOrder_Position_History.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_ORD_PRC_ProcurementOrder_Position_HistoryID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ORD_PRC_ProcurementOrder_Position_HistoryID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "ORD_PRC_ProcurementOrder_Position_HistoryID","ProcurementOrder_Position_RefID","IsCreated","IsModified","IsRemoved","TriggeredBy_BusinessParticipant_RefID","Comment","IsLivePriceRequestProcessTriggered","TriggeredFor_Quantity","IsLivePriceRequestProcessAnswered","AnsweredWith_TotalPrice","AnsweredWith_Currency_RefID","AnsweredWith_DeliverableQuantity","AnsweredWith_EarliestDeliveryDate","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter ORD_PRC_ProcurementOrder_Position_HistoryID of type Guid
						_ORD_PRC_ProcurementOrder_Position_HistoryID = reader.GetGuid(0);
						//1:Parameter ProcurementOrder_Position_RefID of type Guid
						_ProcurementOrder_Position_RefID = reader.GetGuid(1);
						//2:Parameter IsCreated of type Boolean
						_IsCreated = reader.GetBoolean(2);
						//3:Parameter IsModified of type Boolean
						_IsModified = reader.GetBoolean(3);
						//4:Parameter IsRemoved of type Boolean
						_IsRemoved = reader.GetBoolean(4);
						//5:Parameter TriggeredBy_BusinessParticipant_RefID of type Guid
						_TriggeredBy_BusinessParticipant_RefID = reader.GetGuid(5);
						//6:Parameter Comment of type String
						_Comment = reader.GetString(6);
						//7:Parameter IsLivePriceRequestProcessTriggered of type Boolean
						_IsLivePriceRequestProcessTriggered = reader.GetBoolean(7);
						//8:Parameter TriggeredFor_Quantity of type double
						_TriggeredFor_Quantity = reader.GetDouble(8);
						//9:Parameter IsLivePriceRequestProcessAnswered of type Boolean
						_IsLivePriceRequestProcessAnswered = reader.GetBoolean(9);
						//10:Parameter AnsweredWith_TotalPrice of type Decimal
						_AnsweredWith_TotalPrice = reader.GetDecimal(10);
						//11:Parameter AnsweredWith_Currency_RefID of type Guid
						_AnsweredWith_Currency_RefID = reader.GetGuid(11);
						//12:Parameter AnsweredWith_DeliverableQuantity of type double
						_AnsweredWith_DeliverableQuantity = reader.GetDouble(12);
						//13:Parameter AnsweredWith_EarliestDeliveryDate of type DateTime
						_AnsweredWith_EarliestDeliveryDate = reader.GetDate(13);
						//14:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(14);
						//15:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(15);
						//16:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(16);
						//17:Parameter Modification_Timestamp of type DateTime
						_Modification_Timestamp = reader.GetDate(17);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_ORD_PRC_ProcurementOrder_Position_HistoryID != Guid.Empty){
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
			public Guid? ORD_PRC_ProcurementOrder_Position_HistoryID {	get; set; }
			public Guid? ProcurementOrder_Position_RefID {	get; set; }
			public Boolean? IsCreated {	get; set; }
			public Boolean? IsModified {	get; set; }
			public Boolean? IsRemoved {	get; set; }
			public Guid? TriggeredBy_BusinessParticipant_RefID {	get; set; }
			public String Comment {	get; set; }
			public Boolean? IsLivePriceRequestProcessTriggered {	get; set; }
			public double? TriggeredFor_Quantity {	get; set; }
			public Boolean? IsLivePriceRequestProcessAnswered {	get; set; }
			public Decimal? AnsweredWith_TotalPrice {	get; set; }
			public Guid? AnsweredWith_Currency_RefID {	get; set; }
			public double? AnsweredWith_DeliverableQuantity {	get; set; }
			public DateTime? AnsweredWith_EarliestDeliveryDate {	get; set; }
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
			public static List<ORM_ORD_PRC_ProcurementOrder_Position_History> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_ORD_PRC_ProcurementOrder_Position_History> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_ORD_PRC_ProcurementOrder_Position_History> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_ORD_PRC_ProcurementOrder_Position_History> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_ORD_PRC_ProcurementOrder_Position_History> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_ORD_PRC_ProcurementOrder_Position_History>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "ORD_PRC_ProcurementOrder_Position_HistoryID","ProcurementOrder_Position_RefID","IsCreated","IsModified","IsRemoved","TriggeredBy_BusinessParticipant_RefID","Comment","IsLivePriceRequestProcessTriggered","TriggeredFor_Quantity","IsLivePriceRequestProcessAnswered","AnsweredWith_TotalPrice","AnsweredWith_Currency_RefID","AnsweredWith_DeliverableQuantity","AnsweredWith_EarliestDeliveryDate","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
			        while (reader.Read())
			        {
			            ORM_ORD_PRC_ProcurementOrder_Position_History item = new ORM_ORD_PRC_ProcurementOrder_Position_History();
						//0:Parameter ORD_PRC_ProcurementOrder_Position_HistoryID of type Guid
						item.ORD_PRC_ProcurementOrder_Position_HistoryID = reader.GetGuid(0);
						//1:Parameter ProcurementOrder_Position_RefID of type Guid
						item.ProcurementOrder_Position_RefID = reader.GetGuid(1);
						//2:Parameter IsCreated of type Boolean
						item.IsCreated = reader.GetBoolean(2);
						//3:Parameter IsModified of type Boolean
						item.IsModified = reader.GetBoolean(3);
						//4:Parameter IsRemoved of type Boolean
						item.IsRemoved = reader.GetBoolean(4);
						//5:Parameter TriggeredBy_BusinessParticipant_RefID of type Guid
						item.TriggeredBy_BusinessParticipant_RefID = reader.GetGuid(5);
						//6:Parameter Comment of type String
						item.Comment = reader.GetString(6);
						//7:Parameter IsLivePriceRequestProcessTriggered of type Boolean
						item.IsLivePriceRequestProcessTriggered = reader.GetBoolean(7);
						//8:Parameter TriggeredFor_Quantity of type double
						item.TriggeredFor_Quantity = reader.GetDouble(8);
						//9:Parameter IsLivePriceRequestProcessAnswered of type Boolean
						item.IsLivePriceRequestProcessAnswered = reader.GetBoolean(9);
						//10:Parameter AnsweredWith_TotalPrice of type Decimal
						item.AnsweredWith_TotalPrice = reader.GetDecimal(10);
						//11:Parameter AnsweredWith_Currency_RefID of type Guid
						item.AnsweredWith_Currency_RefID = reader.GetGuid(11);
						//12:Parameter AnsweredWith_DeliverableQuantity of type double
						item.AnsweredWith_DeliverableQuantity = reader.GetDouble(12);
						//13:Parameter AnsweredWith_EarliestDeliveryDate of type DateTime
						item.AnsweredWith_EarliestDeliveryDate = reader.GetDate(13);
						//14:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(14);
						//15:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(15);
						//16:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(16);
						//17:Parameter Modification_Timestamp of type DateTime
						item.Modification_Timestamp = reader.GetDate(17);


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
