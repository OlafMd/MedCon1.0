/* 
 * Generated on 8/29/2014 2:33:16 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;

namespace CL1_LOG_WRH
{
	[Serializable]
	public class ORM_LOG_WRH_Shelf_ContentAdjustment
	{
		public static readonly string TableName = "log_wrh_shelf_contentadjustments";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_LOG_WRH_Shelf_ContentAdjustment()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_LOG_WRH_Shelf_ContentAdjustmentID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _LOG_WRH_Shelf_ContentAdjustmentID = default(Guid);
		private Guid _ShelfContent_RefID = default(Guid);
		private double _QuantityChangedAmount = default(double);
		private DateTime _QuantityChangedDate = default(DateTime);
		private Boolean _IsInitialReceipt = default(Boolean);
		private Guid _IfInitialReceipt_ReceiptPosition_QualityControlItem_RefID = default(Guid);
		private Boolean _IsInventoryJobCorrection = default(Boolean);
		private Guid _IfInventoryJobCorrection_InvenoryJobProcess_RefID = default(Guid);
		private Boolean _IsShipmentWithdrawal = default(Boolean);
		private Guid _IfShipmentWithdrawal_ShipmentPosition_RefID = default(Guid);
		private Boolean _IsManualCorrection = default(Boolean);
		private Guid _IfManualCorrection_InventoryChangeReason_RefID = default(Guid);
		private Guid _PerformedBy_Account_RefID = default(Guid);
		private DateTime _PerformedAt_Date = default(DateTime);
		private String _ContentAdjustmentComment = default(String);
		private Boolean _IsBatchNumberOrSerialKeyUpdate = default(Boolean);
		private Guid _IfBatchNumberOrSerialKeyUpdate_CorrespondingAdjustment_RefID = default(Guid);
		private Boolean _IsRelocation = default(Boolean);
		private Guid _IfRelocation_CorrespondingAdjustment_RefID = default(Guid);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid LOG_WRH_Shelf_ContentAdjustmentID { 
			get {
				return _LOG_WRH_Shelf_ContentAdjustmentID;
			}
			set {
				if(_LOG_WRH_Shelf_ContentAdjustmentID != value){
					_LOG_WRH_Shelf_ContentAdjustmentID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid ShelfContent_RefID { 
			get {
				return _ShelfContent_RefID;
			}
			set {
				if(_ShelfContent_RefID != value){
					_ShelfContent_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public double QuantityChangedAmount { 
			get {
				return _QuantityChangedAmount;
			}
			set {
				if(_QuantityChangedAmount != value){
					_QuantityChangedAmount = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime QuantityChangedDate { 
			get {
				return _QuantityChangedDate;
			}
			set {
				if(_QuantityChangedDate != value){
					_QuantityChangedDate = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsInitialReceipt { 
			get {
				return _IsInitialReceipt;
			}
			set {
				if(_IsInitialReceipt != value){
					_IsInitialReceipt = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid IfInitialReceipt_ReceiptPosition_QualityControlItem_RefID { 
			get {
				return _IfInitialReceipt_ReceiptPosition_QualityControlItem_RefID;
			}
			set {
				if(_IfInitialReceipt_ReceiptPosition_QualityControlItem_RefID != value){
					_IfInitialReceipt_ReceiptPosition_QualityControlItem_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsInventoryJobCorrection { 
			get {
				return _IsInventoryJobCorrection;
			}
			set {
				if(_IsInventoryJobCorrection != value){
					_IsInventoryJobCorrection = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid IfInventoryJobCorrection_InvenoryJobProcess_RefID { 
			get {
				return _IfInventoryJobCorrection_InvenoryJobProcess_RefID;
			}
			set {
				if(_IfInventoryJobCorrection_InvenoryJobProcess_RefID != value){
					_IfInventoryJobCorrection_InvenoryJobProcess_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsShipmentWithdrawal { 
			get {
				return _IsShipmentWithdrawal;
			}
			set {
				if(_IsShipmentWithdrawal != value){
					_IsShipmentWithdrawal = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid IfShipmentWithdrawal_ShipmentPosition_RefID { 
			get {
				return _IfShipmentWithdrawal_ShipmentPosition_RefID;
			}
			set {
				if(_IfShipmentWithdrawal_ShipmentPosition_RefID != value){
					_IfShipmentWithdrawal_ShipmentPosition_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsManualCorrection { 
			get {
				return _IsManualCorrection;
			}
			set {
				if(_IsManualCorrection != value){
					_IsManualCorrection = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid IfManualCorrection_InventoryChangeReason_RefID { 
			get {
				return _IfManualCorrection_InventoryChangeReason_RefID;
			}
			set {
				if(_IfManualCorrection_InventoryChangeReason_RefID != value){
					_IfManualCorrection_InventoryChangeReason_RefID = value;
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
		public DateTime PerformedAt_Date { 
			get {
				return _PerformedAt_Date;
			}
			set {
				if(_PerformedAt_Date != value){
					_PerformedAt_Date = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String ContentAdjustmentComment { 
			get {
				return _ContentAdjustmentComment;
			}
			set {
				if(_ContentAdjustmentComment != value){
					_ContentAdjustmentComment = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsBatchNumberOrSerialKeyUpdate { 
			get {
				return _IsBatchNumberOrSerialKeyUpdate;
			}
			set {
				if(_IsBatchNumberOrSerialKeyUpdate != value){
					_IsBatchNumberOrSerialKeyUpdate = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid IfBatchNumberOrSerialKeyUpdate_CorrespondingAdjustment_RefID { 
			get {
				return _IfBatchNumberOrSerialKeyUpdate_CorrespondingAdjustment_RefID;
			}
			set {
				if(_IfBatchNumberOrSerialKeyUpdate_CorrespondingAdjustment_RefID != value){
					_IfBatchNumberOrSerialKeyUpdate_CorrespondingAdjustment_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsRelocation { 
			get {
				return _IsRelocation;
			}
			set {
				if(_IsRelocation != value){
					_IsRelocation = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid IfRelocation_CorrespondingAdjustment_RefID { 
			get {
				return _IfRelocation_CorrespondingAdjustment_RefID;
			}
			set {
				if(_IfRelocation_CorrespondingAdjustment_RefID != value){
					_IfRelocation_CorrespondingAdjustment_RefID = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_LOG_WRH.LOG_WRH_Shelf_ContentAdjustment.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_LOG_WRH.LOG_WRH_Shelf_ContentAdjustment.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "LOG_WRH_Shelf_ContentAdjustmentID", _LOG_WRH_Shelf_ContentAdjustmentID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ShelfContent_RefID", _ShelfContent_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "QuantityChangedAmount", _QuantityChangedAmount);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "QuantityChangedDate", _QuantityChangedDate);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsInitialReceipt", _IsInitialReceipt);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfInitialReceipt_ReceiptPosition_QualityControlItem_RefID", _IfInitialReceipt_ReceiptPosition_QualityControlItem_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsInventoryJobCorrection", _IsInventoryJobCorrection);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfInventoryJobCorrection_InvenoryJobProcess_RefID", _IfInventoryJobCorrection_InvenoryJobProcess_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsShipmentWithdrawal", _IsShipmentWithdrawal);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfShipmentWithdrawal_ShipmentPosition_RefID", _IfShipmentWithdrawal_ShipmentPosition_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsManualCorrection", _IsManualCorrection);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfManualCorrection_InventoryChangeReason_RefID", _IfManualCorrection_InventoryChangeReason_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "PerformedBy_Account_RefID", _PerformedBy_Account_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "PerformedAt_Date", _PerformedAt_Date);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ContentAdjustmentComment", _ContentAdjustmentComment);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsBatchNumberOrSerialKeyUpdate", _IsBatchNumberOrSerialKeyUpdate);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfBatchNumberOrSerialKeyUpdate_CorrespondingAdjustment_RefID", _IfBatchNumberOrSerialKeyUpdate_CorrespondingAdjustment_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsRelocation", _IsRelocation);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfRelocation_CorrespondingAdjustment_RefID", _IfRelocation_CorrespondingAdjustment_RefID);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_LOG_WRH.LOG_WRH_Shelf_ContentAdjustment.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_LOG_WRH_Shelf_ContentAdjustmentID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"LOG_WRH_Shelf_ContentAdjustmentID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "LOG_WRH_Shelf_ContentAdjustmentID","ShelfContent_RefID","QuantityChangedAmount","QuantityChangedDate","IsInitialReceipt","IfInitialReceipt_ReceiptPosition_QualityControlItem_RefID","IsInventoryJobCorrection","IfInventoryJobCorrection_InvenoryJobProcess_RefID","IsShipmentWithdrawal","IfShipmentWithdrawal_ShipmentPosition_RefID","IsManualCorrection","IfManualCorrection_InventoryChangeReason_RefID","PerformedBy_Account_RefID","PerformedAt_Date","ContentAdjustmentComment","IsBatchNumberOrSerialKeyUpdate","IfBatchNumberOrSerialKeyUpdate_CorrespondingAdjustment_RefID","IsRelocation","IfRelocation_CorrespondingAdjustment_RefID","Creation_Timestamp","Tenant_RefID","IsDeleted" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter LOG_WRH_Shelf_ContentAdjustmentID of type Guid
						_LOG_WRH_Shelf_ContentAdjustmentID = reader.GetGuid(0);
						//1:Parameter ShelfContent_RefID of type Guid
						_ShelfContent_RefID = reader.GetGuid(1);
						//2:Parameter QuantityChangedAmount of type double
						_QuantityChangedAmount = reader.GetDouble(2);
						//3:Parameter QuantityChangedDate of type DateTime
						_QuantityChangedDate = reader.GetDate(3);
						//4:Parameter IsInitialReceipt of type Boolean
						_IsInitialReceipt = reader.GetBoolean(4);
						//5:Parameter IfInitialReceipt_ReceiptPosition_QualityControlItem_RefID of type Guid
						_IfInitialReceipt_ReceiptPosition_QualityControlItem_RefID = reader.GetGuid(5);
						//6:Parameter IsInventoryJobCorrection of type Boolean
						_IsInventoryJobCorrection = reader.GetBoolean(6);
						//7:Parameter IfInventoryJobCorrection_InvenoryJobProcess_RefID of type Guid
						_IfInventoryJobCorrection_InvenoryJobProcess_RefID = reader.GetGuid(7);
						//8:Parameter IsShipmentWithdrawal of type Boolean
						_IsShipmentWithdrawal = reader.GetBoolean(8);
						//9:Parameter IfShipmentWithdrawal_ShipmentPosition_RefID of type Guid
						_IfShipmentWithdrawal_ShipmentPosition_RefID = reader.GetGuid(9);
						//10:Parameter IsManualCorrection of type Boolean
						_IsManualCorrection = reader.GetBoolean(10);
						//11:Parameter IfManualCorrection_InventoryChangeReason_RefID of type Guid
						_IfManualCorrection_InventoryChangeReason_RefID = reader.GetGuid(11);
						//12:Parameter PerformedBy_Account_RefID of type Guid
						_PerformedBy_Account_RefID = reader.GetGuid(12);
						//13:Parameter PerformedAt_Date of type DateTime
						_PerformedAt_Date = reader.GetDate(13);
						//14:Parameter ContentAdjustmentComment of type String
						_ContentAdjustmentComment = reader.GetString(14);
						//15:Parameter IsBatchNumberOrSerialKeyUpdate of type Boolean
						_IsBatchNumberOrSerialKeyUpdate = reader.GetBoolean(15);
						//16:Parameter IfBatchNumberOrSerialKeyUpdate_CorrespondingAdjustment_RefID of type Guid
						_IfBatchNumberOrSerialKeyUpdate_CorrespondingAdjustment_RefID = reader.GetGuid(16);
						//17:Parameter IsRelocation of type Boolean
						_IsRelocation = reader.GetBoolean(17);
						//18:Parameter IfRelocation_CorrespondingAdjustment_RefID of type Guid
						_IfRelocation_CorrespondingAdjustment_RefID = reader.GetGuid(18);
						//19:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(19);
						//20:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(20);
						//21:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(21);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_LOG_WRH_Shelf_ContentAdjustmentID != Guid.Empty){
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
			public Guid? LOG_WRH_Shelf_ContentAdjustmentID {	get; set; }
			public Guid? ShelfContent_RefID {	get; set; }
			public double? QuantityChangedAmount {	get; set; }
			public DateTime? QuantityChangedDate {	get; set; }
			public Boolean? IsInitialReceipt {	get; set; }
			public Guid? IfInitialReceipt_ReceiptPosition_QualityControlItem_RefID {	get; set; }
			public Boolean? IsInventoryJobCorrection {	get; set; }
			public Guid? IfInventoryJobCorrection_InvenoryJobProcess_RefID {	get; set; }
			public Boolean? IsShipmentWithdrawal {	get; set; }
			public Guid? IfShipmentWithdrawal_ShipmentPosition_RefID {	get; set; }
			public Boolean? IsManualCorrection {	get; set; }
			public Guid? IfManualCorrection_InventoryChangeReason_RefID {	get; set; }
			public Guid? PerformedBy_Account_RefID {	get; set; }
			public DateTime? PerformedAt_Date {	get; set; }
			public String ContentAdjustmentComment {	get; set; }
			public Boolean? IsBatchNumberOrSerialKeyUpdate {	get; set; }
			public Guid? IfBatchNumberOrSerialKeyUpdate_CorrespondingAdjustment_RefID {	get; set; }
			public Boolean? IsRelocation {	get; set; }
			public Guid? IfRelocation_CorrespondingAdjustment_RefID {	get; set; }
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
			public static List<ORM_LOG_WRH_Shelf_ContentAdjustment> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_LOG_WRH_Shelf_ContentAdjustment> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_LOG_WRH_Shelf_ContentAdjustment> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_LOG_WRH_Shelf_ContentAdjustment> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_LOG_WRH_Shelf_ContentAdjustment> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_LOG_WRH_Shelf_ContentAdjustment>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "LOG_WRH_Shelf_ContentAdjustmentID","ShelfContent_RefID","QuantityChangedAmount","QuantityChangedDate","IsInitialReceipt","IfInitialReceipt_ReceiptPosition_QualityControlItem_RefID","IsInventoryJobCorrection","IfInventoryJobCorrection_InvenoryJobProcess_RefID","IsShipmentWithdrawal","IfShipmentWithdrawal_ShipmentPosition_RefID","IsManualCorrection","IfManualCorrection_InventoryChangeReason_RefID","PerformedBy_Account_RefID","PerformedAt_Date","ContentAdjustmentComment","IsBatchNumberOrSerialKeyUpdate","IfBatchNumberOrSerialKeyUpdate_CorrespondingAdjustment_RefID","IsRelocation","IfRelocation_CorrespondingAdjustment_RefID","Creation_Timestamp","Tenant_RefID","IsDeleted" });
			        while (reader.Read())
			        {
			            ORM_LOG_WRH_Shelf_ContentAdjustment item = new ORM_LOG_WRH_Shelf_ContentAdjustment();
						//0:Parameter LOG_WRH_Shelf_ContentAdjustmentID of type Guid
						item.LOG_WRH_Shelf_ContentAdjustmentID = reader.GetGuid(0);
						//1:Parameter ShelfContent_RefID of type Guid
						item.ShelfContent_RefID = reader.GetGuid(1);
						//2:Parameter QuantityChangedAmount of type double
						item.QuantityChangedAmount = reader.GetDouble(2);
						//3:Parameter QuantityChangedDate of type DateTime
						item.QuantityChangedDate = reader.GetDate(3);
						//4:Parameter IsInitialReceipt of type Boolean
						item.IsInitialReceipt = reader.GetBoolean(4);
						//5:Parameter IfInitialReceipt_ReceiptPosition_QualityControlItem_RefID of type Guid
						item.IfInitialReceipt_ReceiptPosition_QualityControlItem_RefID = reader.GetGuid(5);
						//6:Parameter IsInventoryJobCorrection of type Boolean
						item.IsInventoryJobCorrection = reader.GetBoolean(6);
						//7:Parameter IfInventoryJobCorrection_InvenoryJobProcess_RefID of type Guid
						item.IfInventoryJobCorrection_InvenoryJobProcess_RefID = reader.GetGuid(7);
						//8:Parameter IsShipmentWithdrawal of type Boolean
						item.IsShipmentWithdrawal = reader.GetBoolean(8);
						//9:Parameter IfShipmentWithdrawal_ShipmentPosition_RefID of type Guid
						item.IfShipmentWithdrawal_ShipmentPosition_RefID = reader.GetGuid(9);
						//10:Parameter IsManualCorrection of type Boolean
						item.IsManualCorrection = reader.GetBoolean(10);
						//11:Parameter IfManualCorrection_InventoryChangeReason_RefID of type Guid
						item.IfManualCorrection_InventoryChangeReason_RefID = reader.GetGuid(11);
						//12:Parameter PerformedBy_Account_RefID of type Guid
						item.PerformedBy_Account_RefID = reader.GetGuid(12);
						//13:Parameter PerformedAt_Date of type DateTime
						item.PerformedAt_Date = reader.GetDate(13);
						//14:Parameter ContentAdjustmentComment of type String
						item.ContentAdjustmentComment = reader.GetString(14);
						//15:Parameter IsBatchNumberOrSerialKeyUpdate of type Boolean
						item.IsBatchNumberOrSerialKeyUpdate = reader.GetBoolean(15);
						//16:Parameter IfBatchNumberOrSerialKeyUpdate_CorrespondingAdjustment_RefID of type Guid
						item.IfBatchNumberOrSerialKeyUpdate_CorrespondingAdjustment_RefID = reader.GetGuid(16);
						//17:Parameter IsRelocation of type Boolean
						item.IsRelocation = reader.GetBoolean(17);
						//18:Parameter IfRelocation_CorrespondingAdjustment_RefID of type Guid
						item.IfRelocation_CorrespondingAdjustment_RefID = reader.GetGuid(18);
						//19:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(19);
						//20:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(20);
						//21:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(21);


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
