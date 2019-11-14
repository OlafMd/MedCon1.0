/* 
 * Generated on 5/29/2014 1:33:14 PM
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
	public class ORM_ACC_BOK_Accounting_BookingLine
	{
		public static readonly string TableName = "acc_bok_accounting_bookinglines";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_ACC_BOK_Accounting_BookingLine()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_ACC_BOK_Accounting_BookingLineID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _ACC_BOK_Accounting_BookingLineID = default(Guid);
		private String _ExternalBankKey = default(String);
		private Guid _PartOfAccountingTransaction_RefID = default(Guid);
		private Guid _BookingAccount_RefID = default(Guid);
		private Decimal _TransactionValue = default(Decimal);
		private DateTime _DateOfBooking = default(DateTime);
		private DateTime _DateOfTransaction = default(DateTime);
		private String _SenderText = default(String);
		private String _SenderComment = default(String);
		private Guid _Currency_RefID = default(Guid);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid ACC_BOK_Accounting_BookingLineID { 
			get {
				return _ACC_BOK_Accounting_BookingLineID;
			}
			set {
				if(_ACC_BOK_Accounting_BookingLineID != value){
					_ACC_BOK_Accounting_BookingLineID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String ExternalBankKey { 
			get {
				return _ExternalBankKey;
			}
			set {
				if(_ExternalBankKey != value){
					_ExternalBankKey = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid PartOfAccountingTransaction_RefID { 
			get {
				return _PartOfAccountingTransaction_RefID;
			}
			set {
				if(_PartOfAccountingTransaction_RefID != value){
					_PartOfAccountingTransaction_RefID = value;
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
		public Decimal TransactionValue { 
			get {
				return _TransactionValue;
			}
			set {
				if(_TransactionValue != value){
					_TransactionValue = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime DateOfBooking { 
			get {
				return _DateOfBooking;
			}
			set {
				if(_DateOfBooking != value){
					_DateOfBooking = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime DateOfTransaction { 
			get {
				return _DateOfTransaction;
			}
			set {
				if(_DateOfTransaction != value){
					_DateOfTransaction = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String SenderText { 
			get {
				return _SenderText;
			}
			set {
				if(_SenderText != value){
					_SenderText = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String SenderComment { 
			get {
				return _SenderComment;
			}
			set {
				if(_SenderComment != value){
					_SenderComment = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Currency_RefID { 
			get {
				return _Currency_RefID;
			}
			set {
				if(_Currency_RefID != value){
					_Currency_RefID = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_ACC_BOK.ACC_BOK_Accounting_BookingLine.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_ACC_BOK.ACC_BOK_Accounting_BookingLine.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ACC_BOK_Accounting_BookingLineID", _ACC_BOK_Accounting_BookingLineID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ExternalBankKey", _ExternalBankKey);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "PartOfAccountingTransaction_RefID", _PartOfAccountingTransaction_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "BookingAccount_RefID", _BookingAccount_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "TransactionValue", _TransactionValue);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "DateOfBooking", _DateOfBooking);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "DateOfTransaction", _DateOfTransaction);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "SenderText", _SenderText);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "SenderComment", _SenderComment);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Currency_RefID", _Currency_RefID);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_ACC_BOK.ACC_BOK_Accounting_BookingLine.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_ACC_BOK_Accounting_BookingLineID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ACC_BOK_Accounting_BookingLineID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "ACC_BOK_Accounting_BookingLineID","ExternalBankKey","PartOfAccountingTransaction_RefID","BookingAccount_RefID","TransactionValue","DateOfBooking","DateOfTransaction","SenderText","SenderComment","Currency_RefID","Creation_Timestamp","Tenant_RefID","IsDeleted" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter ACC_BOK_Accounting_BookingLineID of type Guid
						_ACC_BOK_Accounting_BookingLineID = reader.GetGuid(0);
						//1:Parameter ExternalBankKey of type String
						_ExternalBankKey = reader.GetString(1);
						//2:Parameter PartOfAccountingTransaction_RefID of type Guid
						_PartOfAccountingTransaction_RefID = reader.GetGuid(2);
						//3:Parameter BookingAccount_RefID of type Guid
						_BookingAccount_RefID = reader.GetGuid(3);
						//4:Parameter TransactionValue of type Decimal
						_TransactionValue = reader.GetDecimal(4);
						//5:Parameter DateOfBooking of type DateTime
						_DateOfBooking = reader.GetDate(5);
						//6:Parameter DateOfTransaction of type DateTime
						_DateOfTransaction = reader.GetDate(6);
						//7:Parameter SenderText of type String
						_SenderText = reader.GetString(7);
						//8:Parameter SenderComment of type String
						_SenderComment = reader.GetString(8);
						//9:Parameter Currency_RefID of type Guid
						_Currency_RefID = reader.GetGuid(9);
						//10:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(10);
						//11:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(11);
						//12:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(12);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_ACC_BOK_Accounting_BookingLineID != Guid.Empty){
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
			public Guid? ACC_BOK_Accounting_BookingLineID {	get; set; }
			public String ExternalBankKey {	get; set; }
			public Guid? PartOfAccountingTransaction_RefID {	get; set; }
			public Guid? BookingAccount_RefID {	get; set; }
			public Decimal? TransactionValue {	get; set; }
			public DateTime? DateOfBooking {	get; set; }
			public DateTime? DateOfTransaction {	get; set; }
			public String SenderText {	get; set; }
			public String SenderComment {	get; set; }
			public Guid? Currency_RefID {	get; set; }
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
			public static List<ORM_ACC_BOK_Accounting_BookingLine> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_ACC_BOK_Accounting_BookingLine> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_ACC_BOK_Accounting_BookingLine> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_ACC_BOK_Accounting_BookingLine> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_ACC_BOK_Accounting_BookingLine> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_ACC_BOK_Accounting_BookingLine>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "ACC_BOK_Accounting_BookingLineID","ExternalBankKey","PartOfAccountingTransaction_RefID","BookingAccount_RefID","TransactionValue","DateOfBooking","DateOfTransaction","SenderText","SenderComment","Currency_RefID","Creation_Timestamp","Tenant_RefID","IsDeleted" });
			        while (reader.Read())
			        {
			            ORM_ACC_BOK_Accounting_BookingLine item = new ORM_ACC_BOK_Accounting_BookingLine();
						//0:Parameter ACC_BOK_Accounting_BookingLineID of type Guid
						item.ACC_BOK_Accounting_BookingLineID = reader.GetGuid(0);
						//1:Parameter ExternalBankKey of type String
						item.ExternalBankKey = reader.GetString(1);
						//2:Parameter PartOfAccountingTransaction_RefID of type Guid
						item.PartOfAccountingTransaction_RefID = reader.GetGuid(2);
						//3:Parameter BookingAccount_RefID of type Guid
						item.BookingAccount_RefID = reader.GetGuid(3);
						//4:Parameter TransactionValue of type Decimal
						item.TransactionValue = reader.GetDecimal(4);
						//5:Parameter DateOfBooking of type DateTime
						item.DateOfBooking = reader.GetDate(5);
						//6:Parameter DateOfTransaction of type DateTime
						item.DateOfTransaction = reader.GetDate(6);
						//7:Parameter SenderText of type String
						item.SenderText = reader.GetString(7);
						//8:Parameter SenderComment of type String
						item.SenderComment = reader.GetString(8);
						//9:Parameter Currency_RefID of type Guid
						item.Currency_RefID = reader.GetGuid(9);
						//10:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(10);
						//11:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(11);
						//12:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(12);


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
