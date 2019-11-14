/* 
 * Generated on 9/2/2014 2:34:11 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;

namespace CL1_ORD_CUO
{
	[Serializable]
	public class ORM_ORD_CUO_CustomerOrder_Header
	{
		public static readonly string TableName = "ord_cuo_customerorder_headers";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_ORD_CUO_CustomerOrder_Header()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_ORD_CUO_CustomerOrder_HeaderID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _ORD_CUO_CustomerOrder_HeaderID = default(Guid);
		private String _ProcurementOrderITL = default(String);
		private Guid _Current_CustomerOrderStatus_RefID = default(Guid);
		private String _CustomerOrder_Number = default(String);
		private DateTime _CustomerOrder_Date = default(DateTime);
		private Guid _OrderingCustomer_BusinessParticipant_RefID = default(Guid);
		private Guid _CreatedBy_BusinessParticipant_RefID = default(Guid);
		private Guid _CanceledBy_BusinessParticipant_RefID = default(Guid);
		private Guid _CustomerOrder_Currency_RefID = default(Guid);
		private Decimal _TotalValue_BeforeTax = default(Decimal);
		private Boolean _IsCustomerOrderFinalized = default(Boolean);
		private DateTime _DeliveryDeadline = default(DateTime);
		private Boolean _IsPartialShippingAllowed = default(Boolean);
		private Guid _BillingAddressUCD_RefID = default(Guid);
		private Guid _ShippingAddressUCD_RefID = default(Guid);
		private Guid _DeliveryRequestedFrom_Warehouse_RefID = default(Guid);
		private Guid _CreatedAt_PointOfSale_RefID = default(Guid);
		private Boolean _WasAutoApprovedUponReceipt = default(Boolean);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid ORD_CUO_CustomerOrder_HeaderID { 
			get {
				return _ORD_CUO_CustomerOrder_HeaderID;
			}
			set {
				if(_ORD_CUO_CustomerOrder_HeaderID != value){
					_ORD_CUO_CustomerOrder_HeaderID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String ProcurementOrderITL { 
			get {
				return _ProcurementOrderITL;
			}
			set {
				if(_ProcurementOrderITL != value){
					_ProcurementOrderITL = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Current_CustomerOrderStatus_RefID { 
			get {
				return _Current_CustomerOrderStatus_RefID;
			}
			set {
				if(_Current_CustomerOrderStatus_RefID != value){
					_Current_CustomerOrderStatus_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String CustomerOrder_Number { 
			get {
				return _CustomerOrder_Number;
			}
			set {
				if(_CustomerOrder_Number != value){
					_CustomerOrder_Number = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime CustomerOrder_Date { 
			get {
				return _CustomerOrder_Date;
			}
			set {
				if(_CustomerOrder_Date != value){
					_CustomerOrder_Date = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid OrderingCustomer_BusinessParticipant_RefID { 
			get {
				return _OrderingCustomer_BusinessParticipant_RefID;
			}
			set {
				if(_OrderingCustomer_BusinessParticipant_RefID != value){
					_OrderingCustomer_BusinessParticipant_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid CreatedBy_BusinessParticipant_RefID { 
			get {
				return _CreatedBy_BusinessParticipant_RefID;
			}
			set {
				if(_CreatedBy_BusinessParticipant_RefID != value){
					_CreatedBy_BusinessParticipant_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid CanceledBy_BusinessParticipant_RefID { 
			get {
				return _CanceledBy_BusinessParticipant_RefID;
			}
			set {
				if(_CanceledBy_BusinessParticipant_RefID != value){
					_CanceledBy_BusinessParticipant_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid CustomerOrder_Currency_RefID { 
			get {
				return _CustomerOrder_Currency_RefID;
			}
			set {
				if(_CustomerOrder_Currency_RefID != value){
					_CustomerOrder_Currency_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Decimal TotalValue_BeforeTax { 
			get {
				return _TotalValue_BeforeTax;
			}
			set {
				if(_TotalValue_BeforeTax != value){
					_TotalValue_BeforeTax = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsCustomerOrderFinalized { 
			get {
				return _IsCustomerOrderFinalized;
			}
			set {
				if(_IsCustomerOrderFinalized != value){
					_IsCustomerOrderFinalized = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime DeliveryDeadline { 
			get {
				return _DeliveryDeadline;
			}
			set {
				if(_DeliveryDeadline != value){
					_DeliveryDeadline = value;
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
		public Guid BillingAddressUCD_RefID { 
			get {
				return _BillingAddressUCD_RefID;
			}
			set {
				if(_BillingAddressUCD_RefID != value){
					_BillingAddressUCD_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid ShippingAddressUCD_RefID { 
			get {
				return _ShippingAddressUCD_RefID;
			}
			set {
				if(_ShippingAddressUCD_RefID != value){
					_ShippingAddressUCD_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid DeliveryRequestedFrom_Warehouse_RefID { 
			get {
				return _DeliveryRequestedFrom_Warehouse_RefID;
			}
			set {
				if(_DeliveryRequestedFrom_Warehouse_RefID != value){
					_DeliveryRequestedFrom_Warehouse_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid CreatedAt_PointOfSale_RefID { 
			get {
				return _CreatedAt_PointOfSale_RefID;
			}
			set {
				if(_CreatedAt_PointOfSale_RefID != value){
					_CreatedAt_PointOfSale_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean WasAutoApprovedUponReceipt { 
			get {
				return _WasAutoApprovedUponReceipt;
			}
			set {
				if(_WasAutoApprovedUponReceipt != value){
					_WasAutoApprovedUponReceipt = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_ORD_CUO.ORD_CUO_CustomerOrder_Header.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_ORD_CUO.ORD_CUO_CustomerOrder_Header.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ORD_CUO_CustomerOrder_HeaderID", _ORD_CUO_CustomerOrder_HeaderID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ProcurementOrderITL", _ProcurementOrderITL);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Current_CustomerOrderStatus_RefID", _Current_CustomerOrderStatus_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CustomerOrder_Number", _CustomerOrder_Number);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CustomerOrder_Date", _CustomerOrder_Date);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "OrderingCustomer_BusinessParticipant_RefID", _OrderingCustomer_BusinessParticipant_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CreatedBy_BusinessParticipant_RefID", _CreatedBy_BusinessParticipant_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CanceledBy_BusinessParticipant_RefID", _CanceledBy_BusinessParticipant_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CustomerOrder_Currency_RefID", _CustomerOrder_Currency_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "TotalValue_BeforeTax", _TotalValue_BeforeTax);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsCustomerOrderFinalized", _IsCustomerOrderFinalized);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "DeliveryDeadline", _DeliveryDeadline);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsPartialShippingAllowed", _IsPartialShippingAllowed);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "BillingAddressUCD_RefID", _BillingAddressUCD_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ShippingAddressUCD_RefID", _ShippingAddressUCD_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "DeliveryRequestedFrom_Warehouse_RefID", _DeliveryRequestedFrom_Warehouse_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CreatedAt_PointOfSale_RefID", _CreatedAt_PointOfSale_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "WasAutoApprovedUponReceipt", _WasAutoApprovedUponReceipt);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_ORD_CUO.ORD_CUO_CustomerOrder_Header.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_ORD_CUO_CustomerOrder_HeaderID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ORD_CUO_CustomerOrder_HeaderID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "ORD_CUO_CustomerOrder_HeaderID","ProcurementOrderITL","Current_CustomerOrderStatus_RefID","CustomerOrder_Number","CustomerOrder_Date","OrderingCustomer_BusinessParticipant_RefID","CreatedBy_BusinessParticipant_RefID","CanceledBy_BusinessParticipant_RefID","CustomerOrder_Currency_RefID","TotalValue_BeforeTax","IsCustomerOrderFinalized","DeliveryDeadline","IsPartialShippingAllowed","BillingAddressUCD_RefID","ShippingAddressUCD_RefID","DeliveryRequestedFrom_Warehouse_RefID","CreatedAt_PointOfSale_RefID","WasAutoApprovedUponReceipt","Creation_Timestamp","Tenant_RefID","IsDeleted" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter ORD_CUO_CustomerOrder_HeaderID of type Guid
						_ORD_CUO_CustomerOrder_HeaderID = reader.GetGuid(0);
						//1:Parameter ProcurementOrderITL of type String
						_ProcurementOrderITL = reader.GetString(1);
						//2:Parameter Current_CustomerOrderStatus_RefID of type Guid
						_Current_CustomerOrderStatus_RefID = reader.GetGuid(2);
						//3:Parameter CustomerOrder_Number of type String
						_CustomerOrder_Number = reader.GetString(3);
						//4:Parameter CustomerOrder_Date of type DateTime
						_CustomerOrder_Date = reader.GetDate(4);
						//5:Parameter OrderingCustomer_BusinessParticipant_RefID of type Guid
						_OrderingCustomer_BusinessParticipant_RefID = reader.GetGuid(5);
						//6:Parameter CreatedBy_BusinessParticipant_RefID of type Guid
						_CreatedBy_BusinessParticipant_RefID = reader.GetGuid(6);
						//7:Parameter CanceledBy_BusinessParticipant_RefID of type Guid
						_CanceledBy_BusinessParticipant_RefID = reader.GetGuid(7);
						//8:Parameter CustomerOrder_Currency_RefID of type Guid
						_CustomerOrder_Currency_RefID = reader.GetGuid(8);
						//9:Parameter TotalValue_BeforeTax of type Decimal
						_TotalValue_BeforeTax = reader.GetDecimal(9);
						//10:Parameter IsCustomerOrderFinalized of type Boolean
						_IsCustomerOrderFinalized = reader.GetBoolean(10);
						//11:Parameter DeliveryDeadline of type DateTime
						_DeliveryDeadline = reader.GetDate(11);
						//12:Parameter IsPartialShippingAllowed of type Boolean
						_IsPartialShippingAllowed = reader.GetBoolean(12);
						//13:Parameter BillingAddressUCD_RefID of type Guid
						_BillingAddressUCD_RefID = reader.GetGuid(13);
						//14:Parameter ShippingAddressUCD_RefID of type Guid
						_ShippingAddressUCD_RefID = reader.GetGuid(14);
						//15:Parameter DeliveryRequestedFrom_Warehouse_RefID of type Guid
						_DeliveryRequestedFrom_Warehouse_RefID = reader.GetGuid(15);
						//16:Parameter CreatedAt_PointOfSale_RefID of type Guid
						_CreatedAt_PointOfSale_RefID = reader.GetGuid(16);
						//17:Parameter WasAutoApprovedUponReceipt of type Boolean
						_WasAutoApprovedUponReceipt = reader.GetBoolean(17);
						//18:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(18);
						//19:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(19);
						//20:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(20);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_ORD_CUO_CustomerOrder_HeaderID != Guid.Empty){
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
			public Guid? ORD_CUO_CustomerOrder_HeaderID {	get; set; }
			public String ProcurementOrderITL {	get; set; }
			public Guid? Current_CustomerOrderStatus_RefID {	get; set; }
			public String CustomerOrder_Number {	get; set; }
			public DateTime? CustomerOrder_Date {	get; set; }
			public Guid? OrderingCustomer_BusinessParticipant_RefID {	get; set; }
			public Guid? CreatedBy_BusinessParticipant_RefID {	get; set; }
			public Guid? CanceledBy_BusinessParticipant_RefID {	get; set; }
			public Guid? CustomerOrder_Currency_RefID {	get; set; }
			public Decimal? TotalValue_BeforeTax {	get; set; }
			public Boolean? IsCustomerOrderFinalized {	get; set; }
			public DateTime? DeliveryDeadline {	get; set; }
			public Boolean? IsPartialShippingAllowed {	get; set; }
			public Guid? BillingAddressUCD_RefID {	get; set; }
			public Guid? ShippingAddressUCD_RefID {	get; set; }
			public Guid? DeliveryRequestedFrom_Warehouse_RefID {	get; set; }
			public Guid? CreatedAt_PointOfSale_RefID {	get; set; }
			public Boolean? WasAutoApprovedUponReceipt {	get; set; }
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
			public static List<ORM_ORD_CUO_CustomerOrder_Header> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_ORD_CUO_CustomerOrder_Header> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_ORD_CUO_CustomerOrder_Header> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_ORD_CUO_CustomerOrder_Header> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_ORD_CUO_CustomerOrder_Header> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_ORD_CUO_CustomerOrder_Header>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "ORD_CUO_CustomerOrder_HeaderID","ProcurementOrderITL","Current_CustomerOrderStatus_RefID","CustomerOrder_Number","CustomerOrder_Date","OrderingCustomer_BusinessParticipant_RefID","CreatedBy_BusinessParticipant_RefID","CanceledBy_BusinessParticipant_RefID","CustomerOrder_Currency_RefID","TotalValue_BeforeTax","IsCustomerOrderFinalized","DeliveryDeadline","IsPartialShippingAllowed","BillingAddressUCD_RefID","ShippingAddressUCD_RefID","DeliveryRequestedFrom_Warehouse_RefID","CreatedAt_PointOfSale_RefID","WasAutoApprovedUponReceipt","Creation_Timestamp","Tenant_RefID","IsDeleted" });
			        while (reader.Read())
			        {
			            ORM_ORD_CUO_CustomerOrder_Header item = new ORM_ORD_CUO_CustomerOrder_Header();
						//0:Parameter ORD_CUO_CustomerOrder_HeaderID of type Guid
						item.ORD_CUO_CustomerOrder_HeaderID = reader.GetGuid(0);
						//1:Parameter ProcurementOrderITL of type String
						item.ProcurementOrderITL = reader.GetString(1);
						//2:Parameter Current_CustomerOrderStatus_RefID of type Guid
						item.Current_CustomerOrderStatus_RefID = reader.GetGuid(2);
						//3:Parameter CustomerOrder_Number of type String
						item.CustomerOrder_Number = reader.GetString(3);
						//4:Parameter CustomerOrder_Date of type DateTime
						item.CustomerOrder_Date = reader.GetDate(4);
						//5:Parameter OrderingCustomer_BusinessParticipant_RefID of type Guid
						item.OrderingCustomer_BusinessParticipant_RefID = reader.GetGuid(5);
						//6:Parameter CreatedBy_BusinessParticipant_RefID of type Guid
						item.CreatedBy_BusinessParticipant_RefID = reader.GetGuid(6);
						//7:Parameter CanceledBy_BusinessParticipant_RefID of type Guid
						item.CanceledBy_BusinessParticipant_RefID = reader.GetGuid(7);
						//8:Parameter CustomerOrder_Currency_RefID of type Guid
						item.CustomerOrder_Currency_RefID = reader.GetGuid(8);
						//9:Parameter TotalValue_BeforeTax of type Decimal
						item.TotalValue_BeforeTax = reader.GetDecimal(9);
						//10:Parameter IsCustomerOrderFinalized of type Boolean
						item.IsCustomerOrderFinalized = reader.GetBoolean(10);
						//11:Parameter DeliveryDeadline of type DateTime
						item.DeliveryDeadline = reader.GetDate(11);
						//12:Parameter IsPartialShippingAllowed of type Boolean
						item.IsPartialShippingAllowed = reader.GetBoolean(12);
						//13:Parameter BillingAddressUCD_RefID of type Guid
						item.BillingAddressUCD_RefID = reader.GetGuid(13);
						//14:Parameter ShippingAddressUCD_RefID of type Guid
						item.ShippingAddressUCD_RefID = reader.GetGuid(14);
						//15:Parameter DeliveryRequestedFrom_Warehouse_RefID of type Guid
						item.DeliveryRequestedFrom_Warehouse_RefID = reader.GetGuid(15);
						//16:Parameter CreatedAt_PointOfSale_RefID of type Guid
						item.CreatedAt_PointOfSale_RefID = reader.GetGuid(16);
						//17:Parameter WasAutoApprovedUponReceipt of type Boolean
						item.WasAutoApprovedUponReceipt = reader.GetBoolean(17);
						//18:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(18);
						//19:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(19);
						//20:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(20);


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
