/* 
 * Generated on 2/21/2014 11:19:56 AM
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
	public class ORM_LOG_WRH_Shelf_Content
	{
		public static readonly string TableName = "log_wrh_shelf_contents";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_LOG_WRH_Shelf_Content()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_LOG_WRH_Shelf_ContentID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _LOG_WRH_Shelf_ContentID = default(Guid);
		private String _GlobalPropertyMatchingID = default(String);
		private Guid _Shelf_RefID = default(Guid);
		private double _Quantity_Current = default(double);
		private double _Quantity_Initial = default(double);
		private double _UsedShelfCapacityAmount = default(double);
		private DateTime _PlacedIntoStock_Date = default(DateTime);
		private Guid _ReceivedAsFulfillmentOf_ProcurementOrderHeader_RefID = default(Guid);
		private Guid _ReceivedAsFulfillmentOf_ProcurementOrderPosition_RefID = default(Guid);
		private Decimal _R_ProcurementValue = default(Decimal);
		private Guid _R_ProcurementValue_Currency_RefID = default(Guid);
		private Guid _Product_RefID = default(Guid);
		private Guid _Product_Variant_RefID = default(Guid);
		private Guid _Product_Release_RefID = default(Guid);
		private DateTime _ReceptionDate = default(DateTime);
		private DateTime _IntakeIntoInventoryDate = default(DateTime);
		private Boolean _IsLocked = default(Boolean);
		private double _R_ReservedQuantity = default(double);
		private double _R_FreeQuantity = default(double);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid LOG_WRH_Shelf_ContentID { 
			get {
				return _LOG_WRH_Shelf_ContentID;
			}
			set {
				if(_LOG_WRH_Shelf_ContentID != value){
					_LOG_WRH_Shelf_ContentID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String GlobalPropertyMatchingID { 
			get {
				return _GlobalPropertyMatchingID;
			}
			set {
				if(_GlobalPropertyMatchingID != value){
					_GlobalPropertyMatchingID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Shelf_RefID { 
			get {
				return _Shelf_RefID;
			}
			set {
				if(_Shelf_RefID != value){
					_Shelf_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public double Quantity_Current { 
			get {
				return _Quantity_Current;
			}
			set {
				if(_Quantity_Current != value){
					_Quantity_Current = value;
					Status_IsDirty = true;
				}
			}
		} 
		public double Quantity_Initial { 
			get {
				return _Quantity_Initial;
			}
			set {
				if(_Quantity_Initial != value){
					_Quantity_Initial = value;
					Status_IsDirty = true;
				}
			}
		} 
		public double UsedShelfCapacityAmount { 
			get {
				return _UsedShelfCapacityAmount;
			}
			set {
				if(_UsedShelfCapacityAmount != value){
					_UsedShelfCapacityAmount = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime PlacedIntoStock_Date { 
			get {
				return _PlacedIntoStock_Date;
			}
			set {
				if(_PlacedIntoStock_Date != value){
					_PlacedIntoStock_Date = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid ReceivedAsFulfillmentOf_ProcurementOrderHeader_RefID { 
			get {
				return _ReceivedAsFulfillmentOf_ProcurementOrderHeader_RefID;
			}
			set {
				if(_ReceivedAsFulfillmentOf_ProcurementOrderHeader_RefID != value){
					_ReceivedAsFulfillmentOf_ProcurementOrderHeader_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid ReceivedAsFulfillmentOf_ProcurementOrderPosition_RefID { 
			get {
				return _ReceivedAsFulfillmentOf_ProcurementOrderPosition_RefID;
			}
			set {
				if(_ReceivedAsFulfillmentOf_ProcurementOrderPosition_RefID != value){
					_ReceivedAsFulfillmentOf_ProcurementOrderPosition_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Decimal R_ProcurementValue { 
			get {
				return _R_ProcurementValue;
			}
			set {
				if(_R_ProcurementValue != value){
					_R_ProcurementValue = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid R_ProcurementValue_Currency_RefID { 
			get {
				return _R_ProcurementValue_Currency_RefID;
			}
			set {
				if(_R_ProcurementValue_Currency_RefID != value){
					_R_ProcurementValue_Currency_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Product_RefID { 
			get {
				return _Product_RefID;
			}
			set {
				if(_Product_RefID != value){
					_Product_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Product_Variant_RefID { 
			get {
				return _Product_Variant_RefID;
			}
			set {
				if(_Product_Variant_RefID != value){
					_Product_Variant_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Product_Release_RefID { 
			get {
				return _Product_Release_RefID;
			}
			set {
				if(_Product_Release_RefID != value){
					_Product_Release_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime ReceptionDate { 
			get {
				return _ReceptionDate;
			}
			set {
				if(_ReceptionDate != value){
					_ReceptionDate = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime IntakeIntoInventoryDate { 
			get {
				return _IntakeIntoInventoryDate;
			}
			set {
				if(_IntakeIntoInventoryDate != value){
					_IntakeIntoInventoryDate = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsLocked { 
			get {
				return _IsLocked;
			}
			set {
				if(_IsLocked != value){
					_IsLocked = value;
					Status_IsDirty = true;
				}
			}
		} 
		public double R_ReservedQuantity { 
			get {
				return _R_ReservedQuantity;
			}
			set {
				if(_R_ReservedQuantity != value){
					_R_ReservedQuantity = value;
					Status_IsDirty = true;
				}
			}
		} 
		public double R_FreeQuantity { 
			get {
				return _R_FreeQuantity;
			}
			set {
				if(_R_FreeQuantity != value){
					_R_FreeQuantity = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_LOG_WRH.LOG_WRH_Shelf_Content.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_LOG_WRH.LOG_WRH_Shelf_Content.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "LOG_WRH_Shelf_ContentID", _LOG_WRH_Shelf_ContentID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "GlobalPropertyMatchingID", _GlobalPropertyMatchingID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Shelf_RefID", _Shelf_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Quantity_Current", _Quantity_Current);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Quantity_Initial", _Quantity_Initial);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "UsedShelfCapacityAmount", _UsedShelfCapacityAmount);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "PlacedIntoStock_Date", _PlacedIntoStock_Date);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ReceivedAsFulfillmentOf_ProcurementOrderHeader_RefID", _ReceivedAsFulfillmentOf_ProcurementOrderHeader_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ReceivedAsFulfillmentOf_ProcurementOrderPosition_RefID", _ReceivedAsFulfillmentOf_ProcurementOrderPosition_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "R_ProcurementValue", _R_ProcurementValue);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "R_ProcurementValue_Currency_RefID", _R_ProcurementValue_Currency_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Product_RefID", _Product_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Product_Variant_RefID", _Product_Variant_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Product_Release_RefID", _Product_Release_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ReceptionDate", _ReceptionDate);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IntakeIntoInventoryDate", _IntakeIntoInventoryDate);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsLocked", _IsLocked);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "R_ReservedQuantity", _R_ReservedQuantity);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "R_FreeQuantity", _R_FreeQuantity);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_LOG_WRH.LOG_WRH_Shelf_Content.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_LOG_WRH_Shelf_ContentID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"LOG_WRH_Shelf_ContentID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "LOG_WRH_Shelf_ContentID","GlobalPropertyMatchingID","Shelf_RefID","Quantity_Current","Quantity_Initial","UsedShelfCapacityAmount","PlacedIntoStock_Date","ReceivedAsFulfillmentOf_ProcurementOrderHeader_RefID","ReceivedAsFulfillmentOf_ProcurementOrderPosition_RefID","R_ProcurementValue","R_ProcurementValue_Currency_RefID","Product_RefID","Product_Variant_RefID","Product_Release_RefID","ReceptionDate","IntakeIntoInventoryDate","IsLocked","R_ReservedQuantity","R_FreeQuantity","Creation_Timestamp","Tenant_RefID","IsDeleted" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter LOG_WRH_Shelf_ContentID of type Guid
						_LOG_WRH_Shelf_ContentID = reader.GetGuid(0);
						//1:Parameter GlobalPropertyMatchingID of type String
						_GlobalPropertyMatchingID = reader.GetString(1);
						//2:Parameter Shelf_RefID of type Guid
						_Shelf_RefID = reader.GetGuid(2);
						//3:Parameter Quantity_Current of type double
						_Quantity_Current = reader.GetDouble(3);
						//4:Parameter Quantity_Initial of type double
						_Quantity_Initial = reader.GetDouble(4);
						//5:Parameter UsedShelfCapacityAmount of type double
						_UsedShelfCapacityAmount = reader.GetDouble(5);
						//6:Parameter PlacedIntoStock_Date of type DateTime
						_PlacedIntoStock_Date = reader.GetDate(6);
						//7:Parameter ReceivedAsFulfillmentOf_ProcurementOrderHeader_RefID of type Guid
						_ReceivedAsFulfillmentOf_ProcurementOrderHeader_RefID = reader.GetGuid(7);
						//8:Parameter ReceivedAsFulfillmentOf_ProcurementOrderPosition_RefID of type Guid
						_ReceivedAsFulfillmentOf_ProcurementOrderPosition_RefID = reader.GetGuid(8);
						//9:Parameter R_ProcurementValue of type Decimal
						_R_ProcurementValue = reader.GetDecimal(9);
						//10:Parameter R_ProcurementValue_Currency_RefID of type Guid
						_R_ProcurementValue_Currency_RefID = reader.GetGuid(10);
						//11:Parameter Product_RefID of type Guid
						_Product_RefID = reader.GetGuid(11);
						//12:Parameter Product_Variant_RefID of type Guid
						_Product_Variant_RefID = reader.GetGuid(12);
						//13:Parameter Product_Release_RefID of type Guid
						_Product_Release_RefID = reader.GetGuid(13);
						//14:Parameter ReceptionDate of type DateTime
						_ReceptionDate = reader.GetDate(14);
						//15:Parameter IntakeIntoInventoryDate of type DateTime
						_IntakeIntoInventoryDate = reader.GetDate(15);
						//16:Parameter IsLocked of type Boolean
						_IsLocked = reader.GetBoolean(16);
						//17:Parameter R_ReservedQuantity of type double
						_R_ReservedQuantity = reader.GetDouble(17);
						//18:Parameter R_FreeQuantity of type double
						_R_FreeQuantity = reader.GetDouble(18);
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

					if(_LOG_WRH_Shelf_ContentID != Guid.Empty){
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
			public Guid? LOG_WRH_Shelf_ContentID {	get; set; }
			public String GlobalPropertyMatchingID {	get; set; }
			public Guid? Shelf_RefID {	get; set; }
			public double? Quantity_Current {	get; set; }
			public double? Quantity_Initial {	get; set; }
			public double? UsedShelfCapacityAmount {	get; set; }
			public DateTime? PlacedIntoStock_Date {	get; set; }
			public Guid? ReceivedAsFulfillmentOf_ProcurementOrderHeader_RefID {	get; set; }
			public Guid? ReceivedAsFulfillmentOf_ProcurementOrderPosition_RefID {	get; set; }
			public Decimal? R_ProcurementValue {	get; set; }
			public Guid? R_ProcurementValue_Currency_RefID {	get; set; }
			public Guid? Product_RefID {	get; set; }
			public Guid? Product_Variant_RefID {	get; set; }
			public Guid? Product_Release_RefID {	get; set; }
			public DateTime? ReceptionDate {	get; set; }
			public DateTime? IntakeIntoInventoryDate {	get; set; }
			public Boolean? IsLocked {	get; set; }
			public double? R_ReservedQuantity {	get; set; }
			public double? R_FreeQuantity {	get; set; }
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
			public static List<ORM_LOG_WRH_Shelf_Content> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_LOG_WRH_Shelf_Content> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_LOG_WRH_Shelf_Content> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_LOG_WRH_Shelf_Content> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_LOG_WRH_Shelf_Content> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_LOG_WRH_Shelf_Content>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "LOG_WRH_Shelf_ContentID","GlobalPropertyMatchingID","Shelf_RefID","Quantity_Current","Quantity_Initial","UsedShelfCapacityAmount","PlacedIntoStock_Date","ReceivedAsFulfillmentOf_ProcurementOrderHeader_RefID","ReceivedAsFulfillmentOf_ProcurementOrderPosition_RefID","R_ProcurementValue","R_ProcurementValue_Currency_RefID","Product_RefID","Product_Variant_RefID","Product_Release_RefID","ReceptionDate","IntakeIntoInventoryDate","IsLocked","R_ReservedQuantity","R_FreeQuantity","Creation_Timestamp","Tenant_RefID","IsDeleted" });
			        while (reader.Read())
			        {
			            ORM_LOG_WRH_Shelf_Content item = new ORM_LOG_WRH_Shelf_Content();
						//0:Parameter LOG_WRH_Shelf_ContentID of type Guid
						item.LOG_WRH_Shelf_ContentID = reader.GetGuid(0);
						//1:Parameter GlobalPropertyMatchingID of type String
						item.GlobalPropertyMatchingID = reader.GetString(1);
						//2:Parameter Shelf_RefID of type Guid
						item.Shelf_RefID = reader.GetGuid(2);
						//3:Parameter Quantity_Current of type double
						item.Quantity_Current = reader.GetDouble(3);
						//4:Parameter Quantity_Initial of type double
						item.Quantity_Initial = reader.GetDouble(4);
						//5:Parameter UsedShelfCapacityAmount of type double
						item.UsedShelfCapacityAmount = reader.GetDouble(5);
						//6:Parameter PlacedIntoStock_Date of type DateTime
						item.PlacedIntoStock_Date = reader.GetDate(6);
						//7:Parameter ReceivedAsFulfillmentOf_ProcurementOrderHeader_RefID of type Guid
						item.ReceivedAsFulfillmentOf_ProcurementOrderHeader_RefID = reader.GetGuid(7);
						//8:Parameter ReceivedAsFulfillmentOf_ProcurementOrderPosition_RefID of type Guid
						item.ReceivedAsFulfillmentOf_ProcurementOrderPosition_RefID = reader.GetGuid(8);
						//9:Parameter R_ProcurementValue of type Decimal
						item.R_ProcurementValue = reader.GetDecimal(9);
						//10:Parameter R_ProcurementValue_Currency_RefID of type Guid
						item.R_ProcurementValue_Currency_RefID = reader.GetGuid(10);
						//11:Parameter Product_RefID of type Guid
						item.Product_RefID = reader.GetGuid(11);
						//12:Parameter Product_Variant_RefID of type Guid
						item.Product_Variant_RefID = reader.GetGuid(12);
						//13:Parameter Product_Release_RefID of type Guid
						item.Product_Release_RefID = reader.GetGuid(13);
						//14:Parameter ReceptionDate of type DateTime
						item.ReceptionDate = reader.GetDate(14);
						//15:Parameter IntakeIntoInventoryDate of type DateTime
						item.IntakeIntoInventoryDate = reader.GetDate(15);
						//16:Parameter IsLocked of type Boolean
						item.IsLocked = reader.GetBoolean(16);
						//17:Parameter R_ReservedQuantity of type double
						item.R_ReservedQuantity = reader.GetDouble(17);
						//18:Parameter R_FreeQuantity of type double
						item.R_FreeQuantity = reader.GetDouble(18);
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
