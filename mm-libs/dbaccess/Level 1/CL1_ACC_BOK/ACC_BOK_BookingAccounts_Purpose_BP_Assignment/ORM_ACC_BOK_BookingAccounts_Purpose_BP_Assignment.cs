/* 
 * Generated on 6/9/2014 3:45:49 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;

namespace CL1_ACC_BOK
{
	[Serializable]
	public class ORM_ACC_BOK_BookingAccounts_Purpose_BP_Assignment
	{
		public static readonly string TableName = "acc_bok_bookingaccounts_purpose_bp_assignments";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_ACC_BOK_BookingAccounts_Purpose_BP_Assignment()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_ACC_BOK_BookingAccounts_Purpose_BP_AssignmentID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _ACC_BOK_BookingAccounts_Purpose_BP_AssignmentID = default(Guid);
		private Guid _BusinessParticipant_RefID = default(Guid);
		private Guid _BookingAccount_RefID = default(Guid);
		private Boolean _Is_L1_BalanceSheet_Account = default(Boolean);
		private Boolean _Is_L1_IncomeStatement_Account = default(Boolean);
		private Boolean _Is_L2_AssetAccount = default(Boolean);
		private Boolean _Is_L2_LiabilitiesAccount = default(Boolean);
		private Boolean _Is_L2_RevenuesOrIncomeAccount = default(Boolean);
		private Boolean _Is_L2_ExpensesOrLossesAccount = default(Boolean);
		private Guid _If_L3_AssetAccount_BankAccount_RefID = default(Guid);
		private Guid _If_L3_AssetAccount_CashBox_RefID = default(Guid);
		private Boolean _Is_L3_BankAccount = default(Boolean);
		private Boolean _Is_L3_CustomerAccount = default(Boolean);
		private Boolean _Is_L3_SupplierAccount = default(Boolean);
		private Boolean _Is_L3_VATAccount = default(Boolean);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid ACC_BOK_BookingAccounts_Purpose_BP_AssignmentID { 
			get {
				return _ACC_BOK_BookingAccounts_Purpose_BP_AssignmentID;
			}
			set {
				if(_ACC_BOK_BookingAccounts_Purpose_BP_AssignmentID != value){
					_ACC_BOK_BookingAccounts_Purpose_BP_AssignmentID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid BusinessParticipant_RefID { 
			get {
				return _BusinessParticipant_RefID;
			}
			set {
				if(_BusinessParticipant_RefID != value){
					_BusinessParticipant_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid BookingAccount_RefID { 
			get {
				return _BookingAccount_RefID;
			}
			set {
				if(_BookingAccount_RefID != value){
					_BookingAccount_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean Is_L1_BalanceSheet_Account { 
			get {
				return _Is_L1_BalanceSheet_Account;
			}
			set {
				if(_Is_L1_BalanceSheet_Account != value){
					_Is_L1_BalanceSheet_Account = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean Is_L1_IncomeStatement_Account { 
			get {
				return _Is_L1_IncomeStatement_Account;
			}
			set {
				if(_Is_L1_IncomeStatement_Account != value){
					_Is_L1_IncomeStatement_Account = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean Is_L2_AssetAccount { 
			get {
				return _Is_L2_AssetAccount;
			}
			set {
				if(_Is_L2_AssetAccount != value){
					_Is_L2_AssetAccount = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean Is_L2_LiabilitiesAccount { 
			get {
				return _Is_L2_LiabilitiesAccount;
			}
			set {
				if(_Is_L2_LiabilitiesAccount != value){
					_Is_L2_LiabilitiesAccount = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean Is_L2_RevenuesOrIncomeAccount { 
			get {
				return _Is_L2_RevenuesOrIncomeAccount;
			}
			set {
				if(_Is_L2_RevenuesOrIncomeAccount != value){
					_Is_L2_RevenuesOrIncomeAccount = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean Is_L2_ExpensesOrLossesAccount { 
			get {
				return _Is_L2_ExpensesOrLossesAccount;
			}
			set {
				if(_Is_L2_ExpensesOrLossesAccount != value){
					_Is_L2_ExpensesOrLossesAccount = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid If_L3_AssetAccount_BankAccount_RefID { 
			get {
				return _If_L3_AssetAccount_BankAccount_RefID;
			}
			set {
				if(_If_L3_AssetAccount_BankAccount_RefID != value){
					_If_L3_AssetAccount_BankAccount_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid If_L3_AssetAccount_CashBox_RefID { 
			get {
				return _If_L3_AssetAccount_CashBox_RefID;
			}
			set {
				if(_If_L3_AssetAccount_CashBox_RefID != value){
					_If_L3_AssetAccount_CashBox_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean Is_L3_BankAccount { 
			get {
				return _Is_L3_BankAccount;
			}
			set {
				if(_Is_L3_BankAccount != value){
					_Is_L3_BankAccount = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean Is_L3_CustomerAccount { 
			get {
				return _Is_L3_CustomerAccount;
			}
			set {
				if(_Is_L3_CustomerAccount != value){
					_Is_L3_CustomerAccount = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean Is_L3_SupplierAccount { 
			get {
				return _Is_L3_SupplierAccount;
			}
			set {
				if(_Is_L3_SupplierAccount != value){
					_Is_L3_SupplierAccount = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean Is_L3_VATAccount { 
			get {
				return _Is_L3_VATAccount;
			}
			set {
				if(_Is_L3_VATAccount != value){
					_Is_L3_VATAccount = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_ACC_BOK.ACC_BOK_BookingAccounts_Purpose_BP_Assignment.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_ACC_BOK.ACC_BOK_BookingAccounts_Purpose_BP_Assignment.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ACC_BOK_BookingAccounts_Purpose_BP_AssignmentID", _ACC_BOK_BookingAccounts_Purpose_BP_AssignmentID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "BusinessParticipant_RefID", _BusinessParticipant_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "BookingAccount_RefID", _BookingAccount_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Is_L1_BalanceSheet_Account", _Is_L1_BalanceSheet_Account);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Is_L1_IncomeStatement_Account", _Is_L1_IncomeStatement_Account);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Is_L2_AssetAccount", _Is_L2_AssetAccount);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Is_L2_LiabilitiesAccount", _Is_L2_LiabilitiesAccount);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Is_L2_RevenuesOrIncomeAccount", _Is_L2_RevenuesOrIncomeAccount);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Is_L2_ExpensesOrLossesAccount", _Is_L2_ExpensesOrLossesAccount);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "If_L3_AssetAccount_BankAccount_RefID", _If_L3_AssetAccount_BankAccount_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "If_L3_AssetAccount_CashBox_RefID", _If_L3_AssetAccount_CashBox_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Is_L3_BankAccount", _Is_L3_BankAccount);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Is_L3_CustomerAccount", _Is_L3_CustomerAccount);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Is_L3_SupplierAccount", _Is_L3_SupplierAccount);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Is_L3_VATAccount", _Is_L3_VATAccount);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_ACC_BOK.ACC_BOK_BookingAccounts_Purpose_BP_Assignment.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_ACC_BOK_BookingAccounts_Purpose_BP_AssignmentID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ACC_BOK_BookingAccounts_Purpose_BP_AssignmentID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "ACC_BOK_BookingAccounts_Purpose_BP_AssignmentID","BusinessParticipant_RefID","BookingAccount_RefID","Is_L1_BalanceSheet_Account","Is_L1_IncomeStatement_Account","Is_L2_AssetAccount","Is_L2_LiabilitiesAccount","Is_L2_RevenuesOrIncomeAccount","Is_L2_ExpensesOrLossesAccount","If_L3_AssetAccount_BankAccount_RefID","If_L3_AssetAccount_CashBox_RefID","Is_L3_BankAccount","Is_L3_CustomerAccount","Is_L3_SupplierAccount","Is_L3_VATAccount","Creation_Timestamp","Tenant_RefID","IsDeleted" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter ACC_BOK_BookingAccounts_Purpose_BP_AssignmentID of type Guid
						_ACC_BOK_BookingAccounts_Purpose_BP_AssignmentID = reader.GetGuid(0);
						//1:Parameter BusinessParticipant_RefID of type Guid
						_BusinessParticipant_RefID = reader.GetGuid(1);
						//2:Parameter BookingAccount_RefID of type Guid
						_BookingAccount_RefID = reader.GetGuid(2);
						//3:Parameter Is_L1_BalanceSheet_Account of type Boolean
						_Is_L1_BalanceSheet_Account = reader.GetBoolean(3);
						//4:Parameter Is_L1_IncomeStatement_Account of type Boolean
						_Is_L1_IncomeStatement_Account = reader.GetBoolean(4);
						//5:Parameter Is_L2_AssetAccount of type Boolean
						_Is_L2_AssetAccount = reader.GetBoolean(5);
						//6:Parameter Is_L2_LiabilitiesAccount of type Boolean
						_Is_L2_LiabilitiesAccount = reader.GetBoolean(6);
						//7:Parameter Is_L2_RevenuesOrIncomeAccount of type Boolean
						_Is_L2_RevenuesOrIncomeAccount = reader.GetBoolean(7);
						//8:Parameter Is_L2_ExpensesOrLossesAccount of type Boolean
						_Is_L2_ExpensesOrLossesAccount = reader.GetBoolean(8);
						//9:Parameter If_L3_AssetAccount_BankAccount_RefID of type Guid
						_If_L3_AssetAccount_BankAccount_RefID = reader.GetGuid(9);
						//10:Parameter If_L3_AssetAccount_CashBox_RefID of type Guid
						_If_L3_AssetAccount_CashBox_RefID = reader.GetGuid(10);
						//11:Parameter Is_L3_BankAccount of type Boolean
						_Is_L3_BankAccount = reader.GetBoolean(11);
						//12:Parameter Is_L3_CustomerAccount of type Boolean
						_Is_L3_CustomerAccount = reader.GetBoolean(12);
						//13:Parameter Is_L3_SupplierAccount of type Boolean
						_Is_L3_SupplierAccount = reader.GetBoolean(13);
						//14:Parameter Is_L3_VATAccount of type Boolean
						_Is_L3_VATAccount = reader.GetBoolean(14);
						//15:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(15);
						//16:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(16);
						//17:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(17);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_ACC_BOK_BookingAccounts_Purpose_BP_AssignmentID != Guid.Empty){
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
			public Guid? ACC_BOK_BookingAccounts_Purpose_BP_AssignmentID {	get; set; }
			public Guid? BusinessParticipant_RefID {	get; set; }
			public Guid? BookingAccount_RefID {	get; set; }
			public Boolean? Is_L1_BalanceSheet_Account {	get; set; }
			public Boolean? Is_L1_IncomeStatement_Account {	get; set; }
			public Boolean? Is_L2_AssetAccount {	get; set; }
			public Boolean? Is_L2_LiabilitiesAccount {	get; set; }
			public Boolean? Is_L2_RevenuesOrIncomeAccount {	get; set; }
			public Boolean? Is_L2_ExpensesOrLossesAccount {	get; set; }
			public Guid? If_L3_AssetAccount_BankAccount_RefID {	get; set; }
			public Guid? If_L3_AssetAccount_CashBox_RefID {	get; set; }
			public Boolean? Is_L3_BankAccount {	get; set; }
			public Boolean? Is_L3_CustomerAccount {	get; set; }
			public Boolean? Is_L3_SupplierAccount {	get; set; }
			public Boolean? Is_L3_VATAccount {	get; set; }
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
			public static List<ORM_ACC_BOK_BookingAccounts_Purpose_BP_Assignment> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_ACC_BOK_BookingAccounts_Purpose_BP_Assignment> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_ACC_BOK_BookingAccounts_Purpose_BP_Assignment> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_ACC_BOK_BookingAccounts_Purpose_BP_Assignment> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_ACC_BOK_BookingAccounts_Purpose_BP_Assignment> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_ACC_BOK_BookingAccounts_Purpose_BP_Assignment>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "ACC_BOK_BookingAccounts_Purpose_BP_AssignmentID","BusinessParticipant_RefID","BookingAccount_RefID","Is_L1_BalanceSheet_Account","Is_L1_IncomeStatement_Account","Is_L2_AssetAccount","Is_L2_LiabilitiesAccount","Is_L2_RevenuesOrIncomeAccount","Is_L2_ExpensesOrLossesAccount","If_L3_AssetAccount_BankAccount_RefID","If_L3_AssetAccount_CashBox_RefID","Is_L3_BankAccount","Is_L3_CustomerAccount","Is_L3_SupplierAccount","Is_L3_VATAccount","Creation_Timestamp","Tenant_RefID","IsDeleted" });
			        while (reader.Read())
			        {
			            ORM_ACC_BOK_BookingAccounts_Purpose_BP_Assignment item = new ORM_ACC_BOK_BookingAccounts_Purpose_BP_Assignment();
						//0:Parameter ACC_BOK_BookingAccounts_Purpose_BP_AssignmentID of type Guid
						item.ACC_BOK_BookingAccounts_Purpose_BP_AssignmentID = reader.GetGuid(0);
						//1:Parameter BusinessParticipant_RefID of type Guid
						item.BusinessParticipant_RefID = reader.GetGuid(1);
						//2:Parameter BookingAccount_RefID of type Guid
						item.BookingAccount_RefID = reader.GetGuid(2);
						//3:Parameter Is_L1_BalanceSheet_Account of type Boolean
						item.Is_L1_BalanceSheet_Account = reader.GetBoolean(3);
						//4:Parameter Is_L1_IncomeStatement_Account of type Boolean
						item.Is_L1_IncomeStatement_Account = reader.GetBoolean(4);
						//5:Parameter Is_L2_AssetAccount of type Boolean
						item.Is_L2_AssetAccount = reader.GetBoolean(5);
						//6:Parameter Is_L2_LiabilitiesAccount of type Boolean
						item.Is_L2_LiabilitiesAccount = reader.GetBoolean(6);
						//7:Parameter Is_L2_RevenuesOrIncomeAccount of type Boolean
						item.Is_L2_RevenuesOrIncomeAccount = reader.GetBoolean(7);
						//8:Parameter Is_L2_ExpensesOrLossesAccount of type Boolean
						item.Is_L2_ExpensesOrLossesAccount = reader.GetBoolean(8);
						//9:Parameter If_L3_AssetAccount_BankAccount_RefID of type Guid
						item.If_L3_AssetAccount_BankAccount_RefID = reader.GetGuid(9);
						//10:Parameter If_L3_AssetAccount_CashBox_RefID of type Guid
						item.If_L3_AssetAccount_CashBox_RefID = reader.GetGuid(10);
						//11:Parameter Is_L3_BankAccount of type Boolean
						item.Is_L3_BankAccount = reader.GetBoolean(11);
						//12:Parameter Is_L3_CustomerAccount of type Boolean
						item.Is_L3_CustomerAccount = reader.GetBoolean(12);
						//13:Parameter Is_L3_SupplierAccount of type Boolean
						item.Is_L3_SupplierAccount = reader.GetBoolean(13);
						//14:Parameter Is_L3_VATAccount of type Boolean
						item.Is_L3_VATAccount = reader.GetBoolean(14);
						//15:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(15);
						//16:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(16);
						//17:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(17);


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
