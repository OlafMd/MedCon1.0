/* 
 * Generated on 4/28/2014 9:42:32 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;

namespace CL1_LOG_RCP
{
	[Serializable]
	public class ORM_LOG_RCP_Receipt_Header
	{
		public static readonly string TableName = "log_rcp_receipt_headers";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_LOG_RCP_Receipt_Header()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_LOG_RCP_Receipt_HeaderID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _LOG_RCP_Receipt_HeaderID = default(Guid);
		private String _ReceiptHeaderITL = default(String);
		private Boolean _IsCustomerReturnReceipt = default(Boolean);
		private Guid _ExpectedDeliveryHeader_RefID = default(Guid);
		private Guid _ReceiptHeaderCurrency_RefID = default(Guid);
		private String _ReceiptNumber = default(String);
		private Guid _ProvidingSupplier_RefID = default(Guid);
		private Guid _DeliveringBusinessParticipant_RefID = default(Guid);
		private Guid _WRH_Warehouse_RefID = default(Guid);
		private String _DeliverySlip_Number = default(String);
		private DateTime _DeliverySlip_Date = default(DateTime);
		private Guid _DeliverySlip_Document_RefID = default(Guid);
		private Boolean _IsQualityControlPerformed = default(Boolean);
		private Guid _QualityControlPerformed_ByAccount_RefID = default(Guid);
		private DateTime _QualityControlPerformed_AtDate = default(DateTime);
		private Boolean _IsPriceConditionsManuallyCleared = default(Boolean);
		private Guid _PriceConditionsManuallyCleared_ByAccount_RefID = default(Guid);
		private DateTime _PriceConditionsManuallyCleared_AtDate = default(DateTime);
		private Boolean _IsTakenIntoStock = default(Boolean);
		private Guid _TakenIntoStock_ByAccount_RefID = default(Guid);
		private DateTime _TakenIntoStock_AtDate = default(DateTime);
		private Boolean _IsReceiptForwardedToBookkeeping = default(Boolean);
		private Guid _ReceiptForwardedToBookkeeping_ByAccount_RefID = default(Guid);
		private DateTime _ReceiptForwardedToBookkeeping_AtDate = default(DateTime);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid LOG_RCP_Receipt_HeaderID { 
			get {
				return _LOG_RCP_Receipt_HeaderID;
			}
			set {
				if(_LOG_RCP_Receipt_HeaderID != value){
					_LOG_RCP_Receipt_HeaderID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String ReceiptHeaderITL { 
			get {
				return _ReceiptHeaderITL;
			}
			set {
				if(_ReceiptHeaderITL != value){
					_ReceiptHeaderITL = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsCustomerReturnReceipt { 
			get {
				return _IsCustomerReturnReceipt;
			}
			set {
				if(_IsCustomerReturnReceipt != value){
					_IsCustomerReturnReceipt = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid ExpectedDeliveryHeader_RefID { 
			get {
				return _ExpectedDeliveryHeader_RefID;
			}
			set {
				if(_ExpectedDeliveryHeader_RefID != value){
					_ExpectedDeliveryHeader_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid ReceiptHeaderCurrency_RefID { 
			get {
				return _ReceiptHeaderCurrency_RefID;
			}
			set {
				if(_ReceiptHeaderCurrency_RefID != value){
					_ReceiptHeaderCurrency_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String ReceiptNumber { 
			get {
				return _ReceiptNumber;
			}
			set {
				if(_ReceiptNumber != value){
					_ReceiptNumber = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid ProvidingSupplier_RefID { 
			get {
				return _ProvidingSupplier_RefID;
			}
			set {
				if(_ProvidingSupplier_RefID != value){
					_ProvidingSupplier_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid DeliveringBusinessParticipant_RefID { 
			get {
				return _DeliveringBusinessParticipant_RefID;
			}
			set {
				if(_DeliveringBusinessParticipant_RefID != value){
					_DeliveringBusinessParticipant_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid WRH_Warehouse_RefID { 
			get {
				return _WRH_Warehouse_RefID;
			}
			set {
				if(_WRH_Warehouse_RefID != value){
					_WRH_Warehouse_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String DeliverySlip_Number { 
			get {
				return _DeliverySlip_Number;
			}
			set {
				if(_DeliverySlip_Number != value){
					_DeliverySlip_Number = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime DeliverySlip_Date { 
			get {
				return _DeliverySlip_Date;
			}
			set {
				if(_DeliverySlip_Date != value){
					_DeliverySlip_Date = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid DeliverySlip_Document_RefID { 
			get {
				return _DeliverySlip_Document_RefID;
			}
			set {
				if(_DeliverySlip_Document_RefID != value){
					_DeliverySlip_Document_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsQualityControlPerformed { 
			get {
				return _IsQualityControlPerformed;
			}
			set {
				if(_IsQualityControlPerformed != value){
					_IsQualityControlPerformed = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid QualityControlPerformed_ByAccount_RefID { 
			get {
				return _QualityControlPerformed_ByAccount_RefID;
			}
			set {
				if(_QualityControlPerformed_ByAccount_RefID != value){
					_QualityControlPerformed_ByAccount_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime QualityControlPerformed_AtDate { 
			get {
				return _QualityControlPerformed_AtDate;
			}
			set {
				if(_QualityControlPerformed_AtDate != value){
					_QualityControlPerformed_AtDate = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsPriceConditionsManuallyCleared { 
			get {
				return _IsPriceConditionsManuallyCleared;
			}
			set {
				if(_IsPriceConditionsManuallyCleared != value){
					_IsPriceConditionsManuallyCleared = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid PriceConditionsManuallyCleared_ByAccount_RefID { 
			get {
				return _PriceConditionsManuallyCleared_ByAccount_RefID;
			}
			set {
				if(_PriceConditionsManuallyCleared_ByAccount_RefID != value){
					_PriceConditionsManuallyCleared_ByAccount_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime PriceConditionsManuallyCleared_AtDate { 
			get {
				return _PriceConditionsManuallyCleared_AtDate;
			}
			set {
				if(_PriceConditionsManuallyCleared_AtDate != value){
					_PriceConditionsManuallyCleared_AtDate = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsTakenIntoStock { 
			get {
				return _IsTakenIntoStock;
			}
			set {
				if(_IsTakenIntoStock != value){
					_IsTakenIntoStock = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid TakenIntoStock_ByAccount_RefID { 
			get {
				return _TakenIntoStock_ByAccount_RefID;
			}
			set {
				if(_TakenIntoStock_ByAccount_RefID != value){
					_TakenIntoStock_ByAccount_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime TakenIntoStock_AtDate { 
			get {
				return _TakenIntoStock_AtDate;
			}
			set {
				if(_TakenIntoStock_AtDate != value){
					_TakenIntoStock_AtDate = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsReceiptForwardedToBookkeeping { 
			get {
				return _IsReceiptForwardedToBookkeeping;
			}
			set {
				if(_IsReceiptForwardedToBookkeeping != value){
					_IsReceiptForwardedToBookkeeping = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid ReceiptForwardedToBookkeeping_ByAccount_RefID { 
			get {
				return _ReceiptForwardedToBookkeeping_ByAccount_RefID;
			}
			set {
				if(_ReceiptForwardedToBookkeeping_ByAccount_RefID != value){
					_ReceiptForwardedToBookkeeping_ByAccount_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime ReceiptForwardedToBookkeeping_AtDate { 
			get {
				return _ReceiptForwardedToBookkeeping_AtDate;
			}
			set {
				if(_ReceiptForwardedToBookkeeping_AtDate != value){
					_ReceiptForwardedToBookkeeping_AtDate = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_LOG_RCP.LOG_RCP_Receipt_Header.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_LOG_RCP.LOG_RCP_Receipt_Header.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "LOG_RCP_Receipt_HeaderID", _LOG_RCP_Receipt_HeaderID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ReceiptHeaderITL", _ReceiptHeaderITL);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsCustomerReturnReceipt", _IsCustomerReturnReceipt);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ExpectedDeliveryHeader_RefID", _ExpectedDeliveryHeader_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ReceiptHeaderCurrency_RefID", _ReceiptHeaderCurrency_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ReceiptNumber", _ReceiptNumber);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ProvidingSupplier_RefID", _ProvidingSupplier_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "DeliveringBusinessParticipant_RefID", _DeliveringBusinessParticipant_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "WRH_Warehouse_RefID", _WRH_Warehouse_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "DeliverySlip_Number", _DeliverySlip_Number);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "DeliverySlip_Date", _DeliverySlip_Date);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "DeliverySlip_Document_RefID", _DeliverySlip_Document_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsQualityControlPerformed", _IsQualityControlPerformed);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "QualityControlPerformed_ByAccount_RefID", _QualityControlPerformed_ByAccount_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "QualityControlPerformed_AtDate", _QualityControlPerformed_AtDate);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsPriceConditionsManuallyCleared", _IsPriceConditionsManuallyCleared);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "PriceConditionsManuallyCleared_ByAccount_RefID", _PriceConditionsManuallyCleared_ByAccount_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "PriceConditionsManuallyCleared_AtDate", _PriceConditionsManuallyCleared_AtDate);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsTakenIntoStock", _IsTakenIntoStock);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "TakenIntoStock_ByAccount_RefID", _TakenIntoStock_ByAccount_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "TakenIntoStock_AtDate", _TakenIntoStock_AtDate);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsReceiptForwardedToBookkeeping", _IsReceiptForwardedToBookkeeping);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ReceiptForwardedToBookkeeping_ByAccount_RefID", _ReceiptForwardedToBookkeeping_ByAccount_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ReceiptForwardedToBookkeeping_AtDate", _ReceiptForwardedToBookkeeping_AtDate);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_LOG_RCP.LOG_RCP_Receipt_Header.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_LOG_RCP_Receipt_HeaderID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"LOG_RCP_Receipt_HeaderID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "LOG_RCP_Receipt_HeaderID","ReceiptHeaderITL","IsCustomerReturnReceipt","ExpectedDeliveryHeader_RefID","ReceiptHeaderCurrency_RefID","ReceiptNumber","ProvidingSupplier_RefID","DeliveringBusinessParticipant_RefID","WRH_Warehouse_RefID","DeliverySlip_Number","DeliverySlip_Date","DeliverySlip_Document_RefID","IsQualityControlPerformed","QualityControlPerformed_ByAccount_RefID","QualityControlPerformed_AtDate","IsPriceConditionsManuallyCleared","PriceConditionsManuallyCleared_ByAccount_RefID","PriceConditionsManuallyCleared_AtDate","IsTakenIntoStock","TakenIntoStock_ByAccount_RefID","TakenIntoStock_AtDate","IsReceiptForwardedToBookkeeping","ReceiptForwardedToBookkeeping_ByAccount_RefID","ReceiptForwardedToBookkeeping_AtDate","Creation_Timestamp","Tenant_RefID","IsDeleted" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter LOG_RCP_Receipt_HeaderID of type Guid
						_LOG_RCP_Receipt_HeaderID = reader.GetGuid(0);
						//1:Parameter ReceiptHeaderITL of type String
						_ReceiptHeaderITL = reader.GetString(1);
						//2:Parameter IsCustomerReturnReceipt of type Boolean
						_IsCustomerReturnReceipt = reader.GetBoolean(2);
						//3:Parameter ExpectedDeliveryHeader_RefID of type Guid
						_ExpectedDeliveryHeader_RefID = reader.GetGuid(3);
						//4:Parameter ReceiptHeaderCurrency_RefID of type Guid
						_ReceiptHeaderCurrency_RefID = reader.GetGuid(4);
						//5:Parameter ReceiptNumber of type String
						_ReceiptNumber = reader.GetString(5);
						//6:Parameter ProvidingSupplier_RefID of type Guid
						_ProvidingSupplier_RefID = reader.GetGuid(6);
						//7:Parameter DeliveringBusinessParticipant_RefID of type Guid
						_DeliveringBusinessParticipant_RefID = reader.GetGuid(7);
						//8:Parameter WRH_Warehouse_RefID of type Guid
						_WRH_Warehouse_RefID = reader.GetGuid(8);
						//9:Parameter DeliverySlip_Number of type String
						_DeliverySlip_Number = reader.GetString(9);
						//10:Parameter DeliverySlip_Date of type DateTime
						_DeliverySlip_Date = reader.GetDate(10);
						//11:Parameter DeliverySlip_Document_RefID of type Guid
						_DeliverySlip_Document_RefID = reader.GetGuid(11);
						//12:Parameter IsQualityControlPerformed of type Boolean
						_IsQualityControlPerformed = reader.GetBoolean(12);
						//13:Parameter QualityControlPerformed_ByAccount_RefID of type Guid
						_QualityControlPerformed_ByAccount_RefID = reader.GetGuid(13);
						//14:Parameter QualityControlPerformed_AtDate of type DateTime
						_QualityControlPerformed_AtDate = reader.GetDate(14);
						//15:Parameter IsPriceConditionsManuallyCleared of type Boolean
						_IsPriceConditionsManuallyCleared = reader.GetBoolean(15);
						//16:Parameter PriceConditionsManuallyCleared_ByAccount_RefID of type Guid
						_PriceConditionsManuallyCleared_ByAccount_RefID = reader.GetGuid(16);
						//17:Parameter PriceConditionsManuallyCleared_AtDate of type DateTime
						_PriceConditionsManuallyCleared_AtDate = reader.GetDate(17);
						//18:Parameter IsTakenIntoStock of type Boolean
						_IsTakenIntoStock = reader.GetBoolean(18);
						//19:Parameter TakenIntoStock_ByAccount_RefID of type Guid
						_TakenIntoStock_ByAccount_RefID = reader.GetGuid(19);
						//20:Parameter TakenIntoStock_AtDate of type DateTime
						_TakenIntoStock_AtDate = reader.GetDate(20);
						//21:Parameter IsReceiptForwardedToBookkeeping of type Boolean
						_IsReceiptForwardedToBookkeeping = reader.GetBoolean(21);
						//22:Parameter ReceiptForwardedToBookkeeping_ByAccount_RefID of type Guid
						_ReceiptForwardedToBookkeeping_ByAccount_RefID = reader.GetGuid(22);
						//23:Parameter ReceiptForwardedToBookkeeping_AtDate of type DateTime
						_ReceiptForwardedToBookkeeping_AtDate = reader.GetDate(23);
						//24:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(24);
						//25:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(25);
						//26:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(26);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_LOG_RCP_Receipt_HeaderID != Guid.Empty){
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
			public Guid? LOG_RCP_Receipt_HeaderID {	get; set; }
			public String ReceiptHeaderITL {	get; set; }
			public Boolean? IsCustomerReturnReceipt {	get; set; }
			public Guid? ExpectedDeliveryHeader_RefID {	get; set; }
			public Guid? ReceiptHeaderCurrency_RefID {	get; set; }
			public String ReceiptNumber {	get; set; }
			public Guid? ProvidingSupplier_RefID {	get; set; }
			public Guid? DeliveringBusinessParticipant_RefID {	get; set; }
			public Guid? WRH_Warehouse_RefID {	get; set; }
			public String DeliverySlip_Number {	get; set; }
			public DateTime? DeliverySlip_Date {	get; set; }
			public Guid? DeliverySlip_Document_RefID {	get; set; }
			public Boolean? IsQualityControlPerformed {	get; set; }
			public Guid? QualityControlPerformed_ByAccount_RefID {	get; set; }
			public DateTime? QualityControlPerformed_AtDate {	get; set; }
			public Boolean? IsPriceConditionsManuallyCleared {	get; set; }
			public Guid? PriceConditionsManuallyCleared_ByAccount_RefID {	get; set; }
			public DateTime? PriceConditionsManuallyCleared_AtDate {	get; set; }
			public Boolean? IsTakenIntoStock {	get; set; }
			public Guid? TakenIntoStock_ByAccount_RefID {	get; set; }
			public DateTime? TakenIntoStock_AtDate {	get; set; }
			public Boolean? IsReceiptForwardedToBookkeeping {	get; set; }
			public Guid? ReceiptForwardedToBookkeeping_ByAccount_RefID {	get; set; }
			public DateTime? ReceiptForwardedToBookkeeping_AtDate {	get; set; }
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
			public static List<ORM_LOG_RCP_Receipt_Header> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_LOG_RCP_Receipt_Header> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_LOG_RCP_Receipt_Header> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_LOG_RCP_Receipt_Header> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_LOG_RCP_Receipt_Header> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_LOG_RCP_Receipt_Header>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "LOG_RCP_Receipt_HeaderID","ReceiptHeaderITL","IsCustomerReturnReceipt","ExpectedDeliveryHeader_RefID","ReceiptHeaderCurrency_RefID","ReceiptNumber","ProvidingSupplier_RefID","DeliveringBusinessParticipant_RefID","WRH_Warehouse_RefID","DeliverySlip_Number","DeliverySlip_Date","DeliverySlip_Document_RefID","IsQualityControlPerformed","QualityControlPerformed_ByAccount_RefID","QualityControlPerformed_AtDate","IsPriceConditionsManuallyCleared","PriceConditionsManuallyCleared_ByAccount_RefID","PriceConditionsManuallyCleared_AtDate","IsTakenIntoStock","TakenIntoStock_ByAccount_RefID","TakenIntoStock_AtDate","IsReceiptForwardedToBookkeeping","ReceiptForwardedToBookkeeping_ByAccount_RefID","ReceiptForwardedToBookkeeping_AtDate","Creation_Timestamp","Tenant_RefID","IsDeleted" });
			        while (reader.Read())
			        {
			            ORM_LOG_RCP_Receipt_Header item = new ORM_LOG_RCP_Receipt_Header();
						//0:Parameter LOG_RCP_Receipt_HeaderID of type Guid
						item.LOG_RCP_Receipt_HeaderID = reader.GetGuid(0);
						//1:Parameter ReceiptHeaderITL of type String
						item.ReceiptHeaderITL = reader.GetString(1);
						//2:Parameter IsCustomerReturnReceipt of type Boolean
						item.IsCustomerReturnReceipt = reader.GetBoolean(2);
						//3:Parameter ExpectedDeliveryHeader_RefID of type Guid
						item.ExpectedDeliveryHeader_RefID = reader.GetGuid(3);
						//4:Parameter ReceiptHeaderCurrency_RefID of type Guid
						item.ReceiptHeaderCurrency_RefID = reader.GetGuid(4);
						//5:Parameter ReceiptNumber of type String
						item.ReceiptNumber = reader.GetString(5);
						//6:Parameter ProvidingSupplier_RefID of type Guid
						item.ProvidingSupplier_RefID = reader.GetGuid(6);
						//7:Parameter DeliveringBusinessParticipant_RefID of type Guid
						item.DeliveringBusinessParticipant_RefID = reader.GetGuid(7);
						//8:Parameter WRH_Warehouse_RefID of type Guid
						item.WRH_Warehouse_RefID = reader.GetGuid(8);
						//9:Parameter DeliverySlip_Number of type String
						item.DeliverySlip_Number = reader.GetString(9);
						//10:Parameter DeliverySlip_Date of type DateTime
						item.DeliverySlip_Date = reader.GetDate(10);
						//11:Parameter DeliverySlip_Document_RefID of type Guid
						item.DeliverySlip_Document_RefID = reader.GetGuid(11);
						//12:Parameter IsQualityControlPerformed of type Boolean
						item.IsQualityControlPerformed = reader.GetBoolean(12);
						//13:Parameter QualityControlPerformed_ByAccount_RefID of type Guid
						item.QualityControlPerformed_ByAccount_RefID = reader.GetGuid(13);
						//14:Parameter QualityControlPerformed_AtDate of type DateTime
						item.QualityControlPerformed_AtDate = reader.GetDate(14);
						//15:Parameter IsPriceConditionsManuallyCleared of type Boolean
						item.IsPriceConditionsManuallyCleared = reader.GetBoolean(15);
						//16:Parameter PriceConditionsManuallyCleared_ByAccount_RefID of type Guid
						item.PriceConditionsManuallyCleared_ByAccount_RefID = reader.GetGuid(16);
						//17:Parameter PriceConditionsManuallyCleared_AtDate of type DateTime
						item.PriceConditionsManuallyCleared_AtDate = reader.GetDate(17);
						//18:Parameter IsTakenIntoStock of type Boolean
						item.IsTakenIntoStock = reader.GetBoolean(18);
						//19:Parameter TakenIntoStock_ByAccount_RefID of type Guid
						item.TakenIntoStock_ByAccount_RefID = reader.GetGuid(19);
						//20:Parameter TakenIntoStock_AtDate of type DateTime
						item.TakenIntoStock_AtDate = reader.GetDate(20);
						//21:Parameter IsReceiptForwardedToBookkeeping of type Boolean
						item.IsReceiptForwardedToBookkeeping = reader.GetBoolean(21);
						//22:Parameter ReceiptForwardedToBookkeeping_ByAccount_RefID of type Guid
						item.ReceiptForwardedToBookkeeping_ByAccount_RefID = reader.GetGuid(22);
						//23:Parameter ReceiptForwardedToBookkeeping_AtDate of type DateTime
						item.ReceiptForwardedToBookkeeping_AtDate = reader.GetDate(23);
						//24:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(24);
						//25:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(25);
						//26:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(26);


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
