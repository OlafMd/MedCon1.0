/* 
 * Generated on 4/24/2014 6:18:32 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;

namespace CL1_LOG_SHP
{
	[Serializable]
	public class ORM_LOG_SHP_Shipment_Header
	{
		public static readonly string TableName = "log_shp_shipment_headers";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_LOG_SHP_Shipment_Header()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_LOG_SHP_Shipment_HeaderID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _LOG_SHP_Shipment_HeaderID = default(Guid);
		private Guid _RecipientBusinessParticipant_RefID = default(Guid);
		private Guid _Source_Warehouse_RefID = default(Guid);
		private Guid _ShipmentType_RefID = default(Guid);
		private String _ShipmentHeaderITL = default(String);
		private String _ShipmentHeader_Number = default(String);
		private Guid _Shippipng_AddressUCD_RefID = default(Guid);
		private Boolean _IsPartiallyReadyForPicking = default(Boolean);
		private Boolean _IsReadyForPicking = default(Boolean);
		private Boolean _HasPickingStarted = default(Boolean);
		private Boolean _HasPickingFinished = default(Boolean);
		private Boolean _IsShipped = default(Boolean);
		private Boolean _IsBilled = default(Boolean);
		private DateTime _DemandDate = default(DateTime);
		private int _ShipmentPriority = default(int);
		private Boolean _IsPartialShippingAllowed = default(Boolean);
		private Boolean _IsManuallyCleared_ForPicking = default(Boolean);
		private Decimal _ShipmentHeader_ValueWithoutTax = default(Decimal);
		private Guid _ShipmentHeader_Currency_RefID = default(Guid);
		private Boolean _IsCustomerReturnShipment = default(Boolean);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid LOG_SHP_Shipment_HeaderID { 
			get {
				return _LOG_SHP_Shipment_HeaderID;
			}
			set {
				if(_LOG_SHP_Shipment_HeaderID != value){
					_LOG_SHP_Shipment_HeaderID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid RecipientBusinessParticipant_RefID { 
			get {
				return _RecipientBusinessParticipant_RefID;
			}
			set {
				if(_RecipientBusinessParticipant_RefID != value){
					_RecipientBusinessParticipant_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Source_Warehouse_RefID { 
			get {
				return _Source_Warehouse_RefID;
			}
			set {
				if(_Source_Warehouse_RefID != value){
					_Source_Warehouse_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid ShipmentType_RefID { 
			get {
				return _ShipmentType_RefID;
			}
			set {
				if(_ShipmentType_RefID != value){
					_ShipmentType_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String ShipmentHeaderITL { 
			get {
				return _ShipmentHeaderITL;
			}
			set {
				if(_ShipmentHeaderITL != value){
					_ShipmentHeaderITL = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String ShipmentHeader_Number { 
			get {
				return _ShipmentHeader_Number;
			}
			set {
				if(_ShipmentHeader_Number != value){
					_ShipmentHeader_Number = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Shippipng_AddressUCD_RefID { 
			get {
				return _Shippipng_AddressUCD_RefID;
			}
			set {
				if(_Shippipng_AddressUCD_RefID != value){
					_Shippipng_AddressUCD_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsPartiallyReadyForPicking { 
			get {
				return _IsPartiallyReadyForPicking;
			}
			set {
				if(_IsPartiallyReadyForPicking != value){
					_IsPartiallyReadyForPicking = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsReadyForPicking { 
			get {
				return _IsReadyForPicking;
			}
			set {
				if(_IsReadyForPicking != value){
					_IsReadyForPicking = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean HasPickingStarted { 
			get {
				return _HasPickingStarted;
			}
			set {
				if(_HasPickingStarted != value){
					_HasPickingStarted = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean HasPickingFinished { 
			get {
				return _HasPickingFinished;
			}
			set {
				if(_HasPickingFinished != value){
					_HasPickingFinished = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsShipped { 
			get {
				return _IsShipped;
			}
			set {
				if(_IsShipped != value){
					_IsShipped = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsBilled { 
			get {
				return _IsBilled;
			}
			set {
				if(_IsBilled != value){
					_IsBilled = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime DemandDate { 
			get {
				return _DemandDate;
			}
			set {
				if(_DemandDate != value){
					_DemandDate = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int ShipmentPriority { 
			get {
				return _ShipmentPriority;
			}
			set {
				if(_ShipmentPriority != value){
					_ShipmentPriority = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsPartialShippingAllowed { 
			get {
				return _IsPartialShippingAllowed;
			}
			set {
				if(_IsPartialShippingAllowed != value){
					_IsPartialShippingAllowed = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsManuallyCleared_ForPicking { 
			get {
				return _IsManuallyCleared_ForPicking;
			}
			set {
				if(_IsManuallyCleared_ForPicking != value){
					_IsManuallyCleared_ForPicking = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Decimal ShipmentHeader_ValueWithoutTax { 
			get {
				return _ShipmentHeader_ValueWithoutTax;
			}
			set {
				if(_ShipmentHeader_ValueWithoutTax != value){
					_ShipmentHeader_ValueWithoutTax = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid ShipmentHeader_Currency_RefID { 
			get {
				return _ShipmentHeader_Currency_RefID;
			}
			set {
				if(_ShipmentHeader_Currency_RefID != value){
					_ShipmentHeader_Currency_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsCustomerReturnShipment { 
			get {
				return _IsCustomerReturnShipment;
			}
			set {
				if(_IsCustomerReturnShipment != value){
					_IsCustomerReturnShipment = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_LOG_SHP.LOG_SHP_Shipment_Header.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_LOG_SHP.LOG_SHP_Shipment_Header.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "LOG_SHP_Shipment_HeaderID", _LOG_SHP_Shipment_HeaderID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "RecipientBusinessParticipant_RefID", _RecipientBusinessParticipant_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Source_Warehouse_RefID", _Source_Warehouse_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ShipmentType_RefID", _ShipmentType_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ShipmentHeaderITL", _ShipmentHeaderITL);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ShipmentHeader_Number", _ShipmentHeader_Number);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Shippipng_AddressUCD_RefID", _Shippipng_AddressUCD_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsPartiallyReadyForPicking", _IsPartiallyReadyForPicking);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsReadyForPicking", _IsReadyForPicking);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "HasPickingStarted", _HasPickingStarted);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "HasPickingFinished", _HasPickingFinished);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsShipped", _IsShipped);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsBilled", _IsBilled);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "DemandDate", _DemandDate);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ShipmentPriority", _ShipmentPriority);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsPartialShippingAllowed", _IsPartialShippingAllowed);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsManuallyCleared_ForPicking", _IsManuallyCleared_ForPicking);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ShipmentHeader_ValueWithoutTax", _ShipmentHeader_ValueWithoutTax);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ShipmentHeader_Currency_RefID", _ShipmentHeader_Currency_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsCustomerReturnShipment", _IsCustomerReturnShipment);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_LOG_SHP.LOG_SHP_Shipment_Header.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_LOG_SHP_Shipment_HeaderID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"LOG_SHP_Shipment_HeaderID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "LOG_SHP_Shipment_HeaderID","RecipientBusinessParticipant_RefID","Source_Warehouse_RefID","ShipmentType_RefID","ShipmentHeaderITL","ShipmentHeader_Number","Shippipng_AddressUCD_RefID","IsPartiallyReadyForPicking","IsReadyForPicking","HasPickingStarted","HasPickingFinished","IsShipped","IsBilled","DemandDate","ShipmentPriority","IsPartialShippingAllowed","IsManuallyCleared_ForPicking","ShipmentHeader_ValueWithoutTax","ShipmentHeader_Currency_RefID","IsCustomerReturnShipment","Creation_Timestamp","Tenant_RefID","IsDeleted" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter LOG_SHP_Shipment_HeaderID of type Guid
						_LOG_SHP_Shipment_HeaderID = reader.GetGuid(0);
						//1:Parameter RecipientBusinessParticipant_RefID of type Guid
						_RecipientBusinessParticipant_RefID = reader.GetGuid(1);
						//2:Parameter Source_Warehouse_RefID of type Guid
						_Source_Warehouse_RefID = reader.GetGuid(2);
						//3:Parameter ShipmentType_RefID of type Guid
						_ShipmentType_RefID = reader.GetGuid(3);
						//4:Parameter ShipmentHeaderITL of type String
						_ShipmentHeaderITL = reader.GetString(4);
						//5:Parameter ShipmentHeader_Number of type String
						_ShipmentHeader_Number = reader.GetString(5);
						//6:Parameter Shippipng_AddressUCD_RefID of type Guid
						_Shippipng_AddressUCD_RefID = reader.GetGuid(6);
						//7:Parameter IsPartiallyReadyForPicking of type Boolean
						_IsPartiallyReadyForPicking = reader.GetBoolean(7);
						//8:Parameter IsReadyForPicking of type Boolean
						_IsReadyForPicking = reader.GetBoolean(8);
						//9:Parameter HasPickingStarted of type Boolean
						_HasPickingStarted = reader.GetBoolean(9);
						//10:Parameter HasPickingFinished of type Boolean
						_HasPickingFinished = reader.GetBoolean(10);
						//11:Parameter IsShipped of type Boolean
						_IsShipped = reader.GetBoolean(11);
						//12:Parameter IsBilled of type Boolean
						_IsBilled = reader.GetBoolean(12);
						//13:Parameter DemandDate of type DateTime
						_DemandDate = reader.GetDate(13);
						//14:Parameter ShipmentPriority of type int
						_ShipmentPriority = reader.GetInteger(14);
						//15:Parameter IsPartialShippingAllowed of type Boolean
						_IsPartialShippingAllowed = reader.GetBoolean(15);
						//16:Parameter IsManuallyCleared_ForPicking of type Boolean
						_IsManuallyCleared_ForPicking = reader.GetBoolean(16);
						//17:Parameter ShipmentHeader_ValueWithoutTax of type Decimal
						_ShipmentHeader_ValueWithoutTax = reader.GetDecimal(17);
						//18:Parameter ShipmentHeader_Currency_RefID of type Guid
						_ShipmentHeader_Currency_RefID = reader.GetGuid(18);
						//19:Parameter IsCustomerReturnShipment of type Boolean
						_IsCustomerReturnShipment = reader.GetBoolean(19);
						//20:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(20);
						//21:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(21);
						//22:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(22);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_LOG_SHP_Shipment_HeaderID != Guid.Empty){
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
			public Guid? LOG_SHP_Shipment_HeaderID {	get; set; }
			public Guid? RecipientBusinessParticipant_RefID {	get; set; }
			public Guid? Source_Warehouse_RefID {	get; set; }
			public Guid? ShipmentType_RefID {	get; set; }
			public String ShipmentHeaderITL {	get; set; }
			public String ShipmentHeader_Number {	get; set; }
			public Guid? Shippipng_AddressUCD_RefID {	get; set; }
			public Boolean? IsPartiallyReadyForPicking {	get; set; }
			public Boolean? IsReadyForPicking {	get; set; }
			public Boolean? HasPickingStarted {	get; set; }
			public Boolean? HasPickingFinished {	get; set; }
			public Boolean? IsShipped {	get; set; }
			public Boolean? IsBilled {	get; set; }
			public DateTime? DemandDate {	get; set; }
			public int? ShipmentPriority {	get; set; }
			public Boolean? IsPartialShippingAllowed {	get; set; }
			public Boolean? IsManuallyCleared_ForPicking {	get; set; }
			public Decimal? ShipmentHeader_ValueWithoutTax {	get; set; }
			public Guid? ShipmentHeader_Currency_RefID {	get; set; }
			public Boolean? IsCustomerReturnShipment {	get; set; }
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
			public static List<ORM_LOG_SHP_Shipment_Header> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_LOG_SHP_Shipment_Header> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_LOG_SHP_Shipment_Header> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_LOG_SHP_Shipment_Header> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_LOG_SHP_Shipment_Header> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_LOG_SHP_Shipment_Header>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "LOG_SHP_Shipment_HeaderID","RecipientBusinessParticipant_RefID","Source_Warehouse_RefID","ShipmentType_RefID","ShipmentHeaderITL","ShipmentHeader_Number","Shippipng_AddressUCD_RefID","IsPartiallyReadyForPicking","IsReadyForPicking","HasPickingStarted","HasPickingFinished","IsShipped","IsBilled","DemandDate","ShipmentPriority","IsPartialShippingAllowed","IsManuallyCleared_ForPicking","ShipmentHeader_ValueWithoutTax","ShipmentHeader_Currency_RefID","IsCustomerReturnShipment","Creation_Timestamp","Tenant_RefID","IsDeleted" });
			        while (reader.Read())
			        {
			            ORM_LOG_SHP_Shipment_Header item = new ORM_LOG_SHP_Shipment_Header();
						//0:Parameter LOG_SHP_Shipment_HeaderID of type Guid
						item.LOG_SHP_Shipment_HeaderID = reader.GetGuid(0);
						//1:Parameter RecipientBusinessParticipant_RefID of type Guid
						item.RecipientBusinessParticipant_RefID = reader.GetGuid(1);
						//2:Parameter Source_Warehouse_RefID of type Guid
						item.Source_Warehouse_RefID = reader.GetGuid(2);
						//3:Parameter ShipmentType_RefID of type Guid
						item.ShipmentType_RefID = reader.GetGuid(3);
						//4:Parameter ShipmentHeaderITL of type String
						item.ShipmentHeaderITL = reader.GetString(4);
						//5:Parameter ShipmentHeader_Number of type String
						item.ShipmentHeader_Number = reader.GetString(5);
						//6:Parameter Shippipng_AddressUCD_RefID of type Guid
						item.Shippipng_AddressUCD_RefID = reader.GetGuid(6);
						//7:Parameter IsPartiallyReadyForPicking of type Boolean
						item.IsPartiallyReadyForPicking = reader.GetBoolean(7);
						//8:Parameter IsReadyForPicking of type Boolean
						item.IsReadyForPicking = reader.GetBoolean(8);
						//9:Parameter HasPickingStarted of type Boolean
						item.HasPickingStarted = reader.GetBoolean(9);
						//10:Parameter HasPickingFinished of type Boolean
						item.HasPickingFinished = reader.GetBoolean(10);
						//11:Parameter IsShipped of type Boolean
						item.IsShipped = reader.GetBoolean(11);
						//12:Parameter IsBilled of type Boolean
						item.IsBilled = reader.GetBoolean(12);
						//13:Parameter DemandDate of type DateTime
						item.DemandDate = reader.GetDate(13);
						//14:Parameter ShipmentPriority of type int
						item.ShipmentPriority = reader.GetInteger(14);
						//15:Parameter IsPartialShippingAllowed of type Boolean
						item.IsPartialShippingAllowed = reader.GetBoolean(15);
						//16:Parameter IsManuallyCleared_ForPicking of type Boolean
						item.IsManuallyCleared_ForPicking = reader.GetBoolean(16);
						//17:Parameter ShipmentHeader_ValueWithoutTax of type Decimal
						item.ShipmentHeader_ValueWithoutTax = reader.GetDecimal(17);
						//18:Parameter ShipmentHeader_Currency_RefID of type Guid
						item.ShipmentHeader_Currency_RefID = reader.GetGuid(18);
						//19:Parameter IsCustomerReturnShipment of type Boolean
						item.IsCustomerReturnShipment = reader.GetBoolean(19);
						//20:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(20);
						//21:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(21);
						//22:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(22);


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
