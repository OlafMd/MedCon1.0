/* 
 * Generated on 12/20/2014 6:31:00 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_ORD_DIS
{
	[Serializable]
	public class ORM_ORD_DIS_DistributionOrder_Header
	{
		public static readonly string TableName = "ord_dis_distributionorder_headers";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_ORD_DIS_DistributionOrder_Header()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_ORD_DIS_DistributionOrder_HeaderID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _ORD_DIS_DistributionOrder_HeaderID = default(Guid);
		private DateTime _DistributionOrderDate = default(DateTime);
		private String _DistributionOrderNumber = default(String);
		private Guid _Charged_CostCenter_RefID = default(Guid);
		private Boolean _IsCostCenterOrder = default(Boolean);
		private Boolean _IsEmployeeOrder = default(Boolean);
		private Guid _Recipient_Employee_RefID = default(Guid);
		private Boolean _IsOfficeOrder = default(Boolean);
		private Guid _Recipient_Office_RefID = default(Guid);
		private Boolean _IsWarehouseOrder = default(Boolean);
		private Guid _Recipient_Warehouse_RefID = default(Guid);
		private Decimal _InternallyCharged_TotalNetPriceValue = default(Decimal);
		private double _InternallyCharged_TotalPointValue = default(double);
		private Guid _InternallyCharged_Currency_RefID = default(Guid);
		private Guid _DistributeTo_UCDAddress_RefID = default(Guid);
		private Boolean _IsCanceled = default(Boolean);
		private Boolean _IsForPickup = default(Boolean);
		private Guid _IfForPickup_PointOfSale_RefID = default(Guid);
		private DateTime _IfForPickup_DesiredPickupDate = default(DateTime);
		private Boolean _IsForDelivery = default(Boolean);
		private DateTime _IfForDelivery_RequestedDeliveryDate = default(DateTime);
		private Guid _IfForDelivery_ShipmentType_RefID = default(Guid);
		private String _IfForDelivery_LogisticsProvider_RefID = default(String);
		private Boolean _IsPartiallyFullfilled = default(Boolean);
		private Boolean _IsFullyFullfilled = default(Boolean);
		private Boolean _IsGTCAccepted = default(Boolean);
		private Guid _IfGTCAccepted_ByAccount_RefID = default(Guid);
		private DateTime _IfGTCAccepted_DateOfAcceptance = default(DateTime);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		private DateTime _Modification_Timestamp = default(DateTime);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid ORD_DIS_DistributionOrder_HeaderID { 
			get {
				return _ORD_DIS_DistributionOrder_HeaderID;
			}
			set {
				if(_ORD_DIS_DistributionOrder_HeaderID != value){
					_ORD_DIS_DistributionOrder_HeaderID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime DistributionOrderDate { 
			get {
				return _DistributionOrderDate;
			}
			set {
				if(_DistributionOrderDate != value){
					_DistributionOrderDate = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String DistributionOrderNumber { 
			get {
				return _DistributionOrderNumber;
			}
			set {
				if(_DistributionOrderNumber != value){
					_DistributionOrderNumber = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Charged_CostCenter_RefID { 
			get {
				return _Charged_CostCenter_RefID;
			}
			set {
				if(_Charged_CostCenter_RefID != value){
					_Charged_CostCenter_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsCostCenterOrder { 
			get {
				return _IsCostCenterOrder;
			}
			set {
				if(_IsCostCenterOrder != value){
					_IsCostCenterOrder = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsEmployeeOrder { 
			get {
				return _IsEmployeeOrder;
			}
			set {
				if(_IsEmployeeOrder != value){
					_IsEmployeeOrder = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Recipient_Employee_RefID { 
			get {
				return _Recipient_Employee_RefID;
			}
			set {
				if(_Recipient_Employee_RefID != value){
					_Recipient_Employee_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsOfficeOrder { 
			get {
				return _IsOfficeOrder;
			}
			set {
				if(_IsOfficeOrder != value){
					_IsOfficeOrder = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Recipient_Office_RefID { 
			get {
				return _Recipient_Office_RefID;
			}
			set {
				if(_Recipient_Office_RefID != value){
					_Recipient_Office_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsWarehouseOrder { 
			get {
				return _IsWarehouseOrder;
			}
			set {
				if(_IsWarehouseOrder != value){
					_IsWarehouseOrder = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Recipient_Warehouse_RefID { 
			get {
				return _Recipient_Warehouse_RefID;
			}
			set {
				if(_Recipient_Warehouse_RefID != value){
					_Recipient_Warehouse_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Decimal InternallyCharged_TotalNetPriceValue { 
			get {
				return _InternallyCharged_TotalNetPriceValue;
			}
			set {
				if(_InternallyCharged_TotalNetPriceValue != value){
					_InternallyCharged_TotalNetPriceValue = value;
					Status_IsDirty = true;
				}
			}
		} 
		public double InternallyCharged_TotalPointValue { 
			get {
				return _InternallyCharged_TotalPointValue;
			}
			set {
				if(_InternallyCharged_TotalPointValue != value){
					_InternallyCharged_TotalPointValue = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid InternallyCharged_Currency_RefID { 
			get {
				return _InternallyCharged_Currency_RefID;
			}
			set {
				if(_InternallyCharged_Currency_RefID != value){
					_InternallyCharged_Currency_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid DistributeTo_UCDAddress_RefID { 
			get {
				return _DistributeTo_UCDAddress_RefID;
			}
			set {
				if(_DistributeTo_UCDAddress_RefID != value){
					_DistributeTo_UCDAddress_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsCanceled { 
			get {
				return _IsCanceled;
			}
			set {
				if(_IsCanceled != value){
					_IsCanceled = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsForPickup { 
			get {
				return _IsForPickup;
			}
			set {
				if(_IsForPickup != value){
					_IsForPickup = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid IfForPickup_PointOfSale_RefID { 
			get {
				return _IfForPickup_PointOfSale_RefID;
			}
			set {
				if(_IfForPickup_PointOfSale_RefID != value){
					_IfForPickup_PointOfSale_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime IfForPickup_DesiredPickupDate { 
			get {
				return _IfForPickup_DesiredPickupDate;
			}
			set {
				if(_IfForPickup_DesiredPickupDate != value){
					_IfForPickup_DesiredPickupDate = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsForDelivery { 
			get {
				return _IsForDelivery;
			}
			set {
				if(_IsForDelivery != value){
					_IsForDelivery = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime IfForDelivery_RequestedDeliveryDate { 
			get {
				return _IfForDelivery_RequestedDeliveryDate;
			}
			set {
				if(_IfForDelivery_RequestedDeliveryDate != value){
					_IfForDelivery_RequestedDeliveryDate = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid IfForDelivery_ShipmentType_RefID { 
			get {
				return _IfForDelivery_ShipmentType_RefID;
			}
			set {
				if(_IfForDelivery_ShipmentType_RefID != value){
					_IfForDelivery_ShipmentType_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String IfForDelivery_LogisticsProvider_RefID { 
			get {
				return _IfForDelivery_LogisticsProvider_RefID;
			}
			set {
				if(_IfForDelivery_LogisticsProvider_RefID != value){
					_IfForDelivery_LogisticsProvider_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsPartiallyFullfilled { 
			get {
				return _IsPartiallyFullfilled;
			}
			set {
				if(_IsPartiallyFullfilled != value){
					_IsPartiallyFullfilled = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsFullyFullfilled { 
			get {
				return _IsFullyFullfilled;
			}
			set {
				if(_IsFullyFullfilled != value){
					_IsFullyFullfilled = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsGTCAccepted { 
			get {
				return _IsGTCAccepted;
			}
			set {
				if(_IsGTCAccepted != value){
					_IsGTCAccepted = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid IfGTCAccepted_ByAccount_RefID { 
			get {
				return _IfGTCAccepted_ByAccount_RefID;
			}
			set {
				if(_IfGTCAccepted_ByAccount_RefID != value){
					_IfGTCAccepted_ByAccount_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime IfGTCAccepted_DateOfAcceptance { 
			get {
				return _IfGTCAccepted_DateOfAcceptance;
			}
			set {
				if(_IfGTCAccepted_DateOfAcceptance != value){
					_IfGTCAccepted_DateOfAcceptance = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_ORD_DIS.ORD_DIS_DistributionOrder_Header.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_ORD_DIS.ORD_DIS_DistributionOrder_Header.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ORD_DIS_DistributionOrder_HeaderID", _ORD_DIS_DistributionOrder_HeaderID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "DistributionOrderDate", _DistributionOrderDate);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "DistributionOrderNumber", _DistributionOrderNumber);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Charged_CostCenter_RefID", _Charged_CostCenter_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsCostCenterOrder", _IsCostCenterOrder);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsEmployeeOrder", _IsEmployeeOrder);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Recipient_Employee_RefID", _Recipient_Employee_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsOfficeOrder", _IsOfficeOrder);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Recipient_Office_RefID", _Recipient_Office_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsWarehouseOrder", _IsWarehouseOrder);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Recipient_Warehouse_RefID", _Recipient_Warehouse_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "InternallyCharged_TotalNetPriceValue", _InternallyCharged_TotalNetPriceValue);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "InternallyCharged_TotalPointValue", _InternallyCharged_TotalPointValue);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "InternallyCharged_Currency_RefID", _InternallyCharged_Currency_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "DistributeTo_UCDAddress_RefID", _DistributeTo_UCDAddress_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsCanceled", _IsCanceled);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsForPickup", _IsForPickup);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfForPickup_PointOfSale_RefID", _IfForPickup_PointOfSale_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfForPickup_DesiredPickupDate", _IfForPickup_DesiredPickupDate);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsForDelivery", _IsForDelivery);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfForDelivery_RequestedDeliveryDate", _IfForDelivery_RequestedDeliveryDate);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfForDelivery_ShipmentType_RefID", _IfForDelivery_ShipmentType_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfForDelivery_LogisticsProvider_RefID", _IfForDelivery_LogisticsProvider_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsPartiallyFullfilled", _IsPartiallyFullfilled);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsFullyFullfilled", _IsFullyFullfilled);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsGTCAccepted", _IsGTCAccepted);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfGTCAccepted_ByAccount_RefID", _IfGTCAccepted_ByAccount_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfGTCAccepted_DateOfAcceptance", _IfGTCAccepted_DateOfAcceptance);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_ORD_DIS.ORD_DIS_DistributionOrder_Header.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_ORD_DIS_DistributionOrder_HeaderID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ORD_DIS_DistributionOrder_HeaderID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "ORD_DIS_DistributionOrder_HeaderID","DistributionOrderDate","DistributionOrderNumber","Charged_CostCenter_RefID","IsCostCenterOrder","IsEmployeeOrder","Recipient_Employee_RefID","IsOfficeOrder","Recipient_Office_RefID","IsWarehouseOrder","Recipient_Warehouse_RefID","InternallyCharged_TotalNetPriceValue","InternallyCharged_TotalPointValue","InternallyCharged_Currency_RefID","DistributeTo_UCDAddress_RefID","IsCanceled","IsForPickup","IfForPickup_PointOfSale_RefID","IfForPickup_DesiredPickupDate","IsForDelivery","IfForDelivery_RequestedDeliveryDate","IfForDelivery_ShipmentType_RefID","IfForDelivery_LogisticsProvider_RefID","IsPartiallyFullfilled","IsFullyFullfilled","IsGTCAccepted","IfGTCAccepted_ByAccount_RefID","IfGTCAccepted_DateOfAcceptance","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter ORD_DIS_DistributionOrder_HeaderID of type Guid
						_ORD_DIS_DistributionOrder_HeaderID = reader.GetGuid(0);
						//1:Parameter DistributionOrderDate of type DateTime
						_DistributionOrderDate = reader.GetDate(1);
						//2:Parameter DistributionOrderNumber of type String
						_DistributionOrderNumber = reader.GetString(2);
						//3:Parameter Charged_CostCenter_RefID of type Guid
						_Charged_CostCenter_RefID = reader.GetGuid(3);
						//4:Parameter IsCostCenterOrder of type Boolean
						_IsCostCenterOrder = reader.GetBoolean(4);
						//5:Parameter IsEmployeeOrder of type Boolean
						_IsEmployeeOrder = reader.GetBoolean(5);
						//6:Parameter Recipient_Employee_RefID of type Guid
						_Recipient_Employee_RefID = reader.GetGuid(6);
						//7:Parameter IsOfficeOrder of type Boolean
						_IsOfficeOrder = reader.GetBoolean(7);
						//8:Parameter Recipient_Office_RefID of type Guid
						_Recipient_Office_RefID = reader.GetGuid(8);
						//9:Parameter IsWarehouseOrder of type Boolean
						_IsWarehouseOrder = reader.GetBoolean(9);
						//10:Parameter Recipient_Warehouse_RefID of type Guid
						_Recipient_Warehouse_RefID = reader.GetGuid(10);
						//11:Parameter InternallyCharged_TotalNetPriceValue of type Decimal
						_InternallyCharged_TotalNetPriceValue = reader.GetDecimal(11);
						//12:Parameter InternallyCharged_TotalPointValue of type double
						_InternallyCharged_TotalPointValue = reader.GetDouble(12);
						//13:Parameter InternallyCharged_Currency_RefID of type Guid
						_InternallyCharged_Currency_RefID = reader.GetGuid(13);
						//14:Parameter DistributeTo_UCDAddress_RefID of type Guid
						_DistributeTo_UCDAddress_RefID = reader.GetGuid(14);
						//15:Parameter IsCanceled of type Boolean
						_IsCanceled = reader.GetBoolean(15);
						//16:Parameter IsForPickup of type Boolean
						_IsForPickup = reader.GetBoolean(16);
						//17:Parameter IfForPickup_PointOfSale_RefID of type Guid
						_IfForPickup_PointOfSale_RefID = reader.GetGuid(17);
						//18:Parameter IfForPickup_DesiredPickupDate of type DateTime
						_IfForPickup_DesiredPickupDate = reader.GetDate(18);
						//19:Parameter IsForDelivery of type Boolean
						_IsForDelivery = reader.GetBoolean(19);
						//20:Parameter IfForDelivery_RequestedDeliveryDate of type DateTime
						_IfForDelivery_RequestedDeliveryDate = reader.GetDate(20);
						//21:Parameter IfForDelivery_ShipmentType_RefID of type Guid
						_IfForDelivery_ShipmentType_RefID = reader.GetGuid(21);
						//22:Parameter IfForDelivery_LogisticsProvider_RefID of type String
						_IfForDelivery_LogisticsProvider_RefID = reader.GetString(22);
						//23:Parameter IsPartiallyFullfilled of type Boolean
						_IsPartiallyFullfilled = reader.GetBoolean(23);
						//24:Parameter IsFullyFullfilled of type Boolean
						_IsFullyFullfilled = reader.GetBoolean(24);
						//25:Parameter IsGTCAccepted of type Boolean
						_IsGTCAccepted = reader.GetBoolean(25);
						//26:Parameter IfGTCAccepted_ByAccount_RefID of type Guid
						_IfGTCAccepted_ByAccount_RefID = reader.GetGuid(26);
						//27:Parameter IfGTCAccepted_DateOfAcceptance of type DateTime
						_IfGTCAccepted_DateOfAcceptance = reader.GetDate(27);
						//28:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(28);
						//29:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(29);
						//30:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(30);
						//31:Parameter Modification_Timestamp of type DateTime
						_Modification_Timestamp = reader.GetDate(31);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_ORD_DIS_DistributionOrder_HeaderID != Guid.Empty){
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
			public Guid? ORD_DIS_DistributionOrder_HeaderID {	get; set; }
			public DateTime? DistributionOrderDate {	get; set; }
			public String DistributionOrderNumber {	get; set; }
			public Guid? Charged_CostCenter_RefID {	get; set; }
			public Boolean? IsCostCenterOrder {	get; set; }
			public Boolean? IsEmployeeOrder {	get; set; }
			public Guid? Recipient_Employee_RefID {	get; set; }
			public Boolean? IsOfficeOrder {	get; set; }
			public Guid? Recipient_Office_RefID {	get; set; }
			public Boolean? IsWarehouseOrder {	get; set; }
			public Guid? Recipient_Warehouse_RefID {	get; set; }
			public Decimal? InternallyCharged_TotalNetPriceValue {	get; set; }
			public double? InternallyCharged_TotalPointValue {	get; set; }
			public Guid? InternallyCharged_Currency_RefID {	get; set; }
			public Guid? DistributeTo_UCDAddress_RefID {	get; set; }
			public Boolean? IsCanceled {	get; set; }
			public Boolean? IsForPickup {	get; set; }
			public Guid? IfForPickup_PointOfSale_RefID {	get; set; }
			public DateTime? IfForPickup_DesiredPickupDate {	get; set; }
			public Boolean? IsForDelivery {	get; set; }
			public DateTime? IfForDelivery_RequestedDeliveryDate {	get; set; }
			public Guid? IfForDelivery_ShipmentType_RefID {	get; set; }
			public String IfForDelivery_LogisticsProvider_RefID {	get; set; }
			public Boolean? IsPartiallyFullfilled {	get; set; }
			public Boolean? IsFullyFullfilled {	get; set; }
			public Boolean? IsGTCAccepted {	get; set; }
			public Guid? IfGTCAccepted_ByAccount_RefID {	get; set; }
			public DateTime? IfGTCAccepted_DateOfAcceptance {	get; set; }
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
			public static List<ORM_ORD_DIS_DistributionOrder_Header> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_ORD_DIS_DistributionOrder_Header> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_ORD_DIS_DistributionOrder_Header> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_ORD_DIS_DistributionOrder_Header> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_ORD_DIS_DistributionOrder_Header> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_ORD_DIS_DistributionOrder_Header>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "ORD_DIS_DistributionOrder_HeaderID","DistributionOrderDate","DistributionOrderNumber","Charged_CostCenter_RefID","IsCostCenterOrder","IsEmployeeOrder","Recipient_Employee_RefID","IsOfficeOrder","Recipient_Office_RefID","IsWarehouseOrder","Recipient_Warehouse_RefID","InternallyCharged_TotalNetPriceValue","InternallyCharged_TotalPointValue","InternallyCharged_Currency_RefID","DistributeTo_UCDAddress_RefID","IsCanceled","IsForPickup","IfForPickup_PointOfSale_RefID","IfForPickup_DesiredPickupDate","IsForDelivery","IfForDelivery_RequestedDeliveryDate","IfForDelivery_ShipmentType_RefID","IfForDelivery_LogisticsProvider_RefID","IsPartiallyFullfilled","IsFullyFullfilled","IsGTCAccepted","IfGTCAccepted_ByAccount_RefID","IfGTCAccepted_DateOfAcceptance","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
			        while (reader.Read())
			        {
			            ORM_ORD_DIS_DistributionOrder_Header item = new ORM_ORD_DIS_DistributionOrder_Header();
						//0:Parameter ORD_DIS_DistributionOrder_HeaderID of type Guid
						item.ORD_DIS_DistributionOrder_HeaderID = reader.GetGuid(0);
						//1:Parameter DistributionOrderDate of type DateTime
						item.DistributionOrderDate = reader.GetDate(1);
						//2:Parameter DistributionOrderNumber of type String
						item.DistributionOrderNumber = reader.GetString(2);
						//3:Parameter Charged_CostCenter_RefID of type Guid
						item.Charged_CostCenter_RefID = reader.GetGuid(3);
						//4:Parameter IsCostCenterOrder of type Boolean
						item.IsCostCenterOrder = reader.GetBoolean(4);
						//5:Parameter IsEmployeeOrder of type Boolean
						item.IsEmployeeOrder = reader.GetBoolean(5);
						//6:Parameter Recipient_Employee_RefID of type Guid
						item.Recipient_Employee_RefID = reader.GetGuid(6);
						//7:Parameter IsOfficeOrder of type Boolean
						item.IsOfficeOrder = reader.GetBoolean(7);
						//8:Parameter Recipient_Office_RefID of type Guid
						item.Recipient_Office_RefID = reader.GetGuid(8);
						//9:Parameter IsWarehouseOrder of type Boolean
						item.IsWarehouseOrder = reader.GetBoolean(9);
						//10:Parameter Recipient_Warehouse_RefID of type Guid
						item.Recipient_Warehouse_RefID = reader.GetGuid(10);
						//11:Parameter InternallyCharged_TotalNetPriceValue of type Decimal
						item.InternallyCharged_TotalNetPriceValue = reader.GetDecimal(11);
						//12:Parameter InternallyCharged_TotalPointValue of type double
						item.InternallyCharged_TotalPointValue = reader.GetDouble(12);
						//13:Parameter InternallyCharged_Currency_RefID of type Guid
						item.InternallyCharged_Currency_RefID = reader.GetGuid(13);
						//14:Parameter DistributeTo_UCDAddress_RefID of type Guid
						item.DistributeTo_UCDAddress_RefID = reader.GetGuid(14);
						//15:Parameter IsCanceled of type Boolean
						item.IsCanceled = reader.GetBoolean(15);
						//16:Parameter IsForPickup of type Boolean
						item.IsForPickup = reader.GetBoolean(16);
						//17:Parameter IfForPickup_PointOfSale_RefID of type Guid
						item.IfForPickup_PointOfSale_RefID = reader.GetGuid(17);
						//18:Parameter IfForPickup_DesiredPickupDate of type DateTime
						item.IfForPickup_DesiredPickupDate = reader.GetDate(18);
						//19:Parameter IsForDelivery of type Boolean
						item.IsForDelivery = reader.GetBoolean(19);
						//20:Parameter IfForDelivery_RequestedDeliveryDate of type DateTime
						item.IfForDelivery_RequestedDeliveryDate = reader.GetDate(20);
						//21:Parameter IfForDelivery_ShipmentType_RefID of type Guid
						item.IfForDelivery_ShipmentType_RefID = reader.GetGuid(21);
						//22:Parameter IfForDelivery_LogisticsProvider_RefID of type String
						item.IfForDelivery_LogisticsProvider_RefID = reader.GetString(22);
						//23:Parameter IsPartiallyFullfilled of type Boolean
						item.IsPartiallyFullfilled = reader.GetBoolean(23);
						//24:Parameter IsFullyFullfilled of type Boolean
						item.IsFullyFullfilled = reader.GetBoolean(24);
						//25:Parameter IsGTCAccepted of type Boolean
						item.IsGTCAccepted = reader.GetBoolean(25);
						//26:Parameter IfGTCAccepted_ByAccount_RefID of type Guid
						item.IfGTCAccepted_ByAccount_RefID = reader.GetGuid(26);
						//27:Parameter IfGTCAccepted_DateOfAcceptance of type DateTime
						item.IfGTCAccepted_DateOfAcceptance = reader.GetDate(27);
						//28:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(28);
						//29:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(29);
						//30:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(30);
						//31:Parameter Modification_Timestamp of type DateTime
						item.Modification_Timestamp = reader.GetDate(31);


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
