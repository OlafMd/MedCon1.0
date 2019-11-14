/* 
 * Generated on 2/27/2014 4:34:31 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_ORD_PRC_SPB
{
	[Serializable]
	public class ORM_ORD_PRC_SPB_SupplierBill_Header
	{
		public static readonly string TableName = "ord_prc_spb_supplierbill_headers";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_ORD_PRC_SPB_SupplierBill_Header()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_ORD_PRC_SPB_SupplierBill_HeaderID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _ORD_PRC_SPB_SupplierBill_HeaderID = default(Guid);
		private Guid _Supplier_RefID = default(Guid);
		private Guid _Currency_RefID = default(Guid);
		private String _SupplierBillNumber = default(String);
		private DateTime _DateOnBill = default(DateTime);
		private Decimal _TotalValue_BeforeTax = default(Decimal);
		private Decimal _TotalValue_IncludingTax = default(Decimal);
		private String _BillComment = default(String);
		private DateTime _PaymentTargetDate = default(DateTime);
		private Double _CashDiscountInPercent = default(Double);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid ORD_PRC_SPB_SupplierBill_HeaderID { 
			get {
				return _ORD_PRC_SPB_SupplierBill_HeaderID;
			}
			set {
				if(_ORD_PRC_SPB_SupplierBill_HeaderID != value){
					_ORD_PRC_SPB_SupplierBill_HeaderID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Supplier_RefID { 
			get {
				return _Supplier_RefID;
			}
			set {
				if(_Supplier_RefID != value){
					_Supplier_RefID = value;
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
		public String SupplierBillNumber { 
			get {
				return _SupplierBillNumber;
			}
			set {
				if(_SupplierBillNumber != value){
					_SupplierBillNumber = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime DateOnBill { 
			get {
				return _DateOnBill;
			}
			set {
				if(_DateOnBill != value){
					_DateOnBill = value;
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
		public Decimal TotalValue_IncludingTax { 
			get {
				return _TotalValue_IncludingTax;
			}
			set {
				if(_TotalValue_IncludingTax != value){
					_TotalValue_IncludingTax = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String BillComment { 
			get {
				return _BillComment;
			}
			set {
				if(_BillComment != value){
					_BillComment = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime PaymentTargetDate { 
			get {
				return _PaymentTargetDate;
			}
			set {
				if(_PaymentTargetDate != value){
					_PaymentTargetDate = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Double CashDiscountInPercent { 
			get {
				return _CashDiscountInPercent;
			}
			set {
				if(_CashDiscountInPercent != value){
					_CashDiscountInPercent = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_ORD_PRC_SPB.ORD_PRC_SPB_SupplierBill_Header.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_ORD_PRC_SPB.ORD_PRC_SPB_SupplierBill_Header.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ORD_PRC_SPB_SupplierBill_HeaderID", _ORD_PRC_SPB_SupplierBill_HeaderID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Supplier_RefID", _Supplier_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Currency_RefID", _Currency_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "SupplierBillNumber", _SupplierBillNumber);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "DateOnBill", _DateOnBill);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "TotalValue_BeforeTax", _TotalValue_BeforeTax);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "TotalValue_IncludingTax", _TotalValue_IncludingTax);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "BillComment", _BillComment);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "PaymentTargetDate", _PaymentTargetDate);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CashDiscountInPercent", _CashDiscountInPercent);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_ORD_PRC_SPB.ORD_PRC_SPB_SupplierBill_Header.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_ORD_PRC_SPB_SupplierBill_HeaderID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ORD_PRC_SPB_SupplierBill_HeaderID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "ORD_PRC_SPB_SupplierBill_HeaderID","Supplier_RefID","Currency_RefID","SupplierBillNumber","DateOnBill","TotalValue_BeforeTax","TotalValue_IncludingTax","BillComment","PaymentTargetDate","CashDiscountInPercent","Creation_Timestamp","Tenant_RefID","IsDeleted" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter ORD_PRC_SPB_SupplierBill_HeaderID of type Guid
						_ORD_PRC_SPB_SupplierBill_HeaderID = reader.GetGuid(0);
						//1:Parameter Supplier_RefID of type Guid
						_Supplier_RefID = reader.GetGuid(1);
						//2:Parameter Currency_RefID of type Guid
						_Currency_RefID = reader.GetGuid(2);
						//3:Parameter SupplierBillNumber of type String
						_SupplierBillNumber = reader.GetString(3);
						//4:Parameter DateOnBill of type DateTime
						_DateOnBill = reader.GetDate(4);
						//5:Parameter TotalValue_BeforeTax of type Decimal
						_TotalValue_BeforeTax = reader.GetDecimal(5);
						//6:Parameter TotalValue_IncludingTax of type Decimal
						_TotalValue_IncludingTax = reader.GetDecimal(6);
						//7:Parameter BillComment of type String
						_BillComment = reader.GetString(7);
						//8:Parameter PaymentTargetDate of type DateTime
						_PaymentTargetDate = reader.GetDate(8);
						//9:Parameter CashDiscountInPercent of type Double
						_CashDiscountInPercent = reader.GetDouble(9);
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

					if(_ORD_PRC_SPB_SupplierBill_HeaderID != Guid.Empty){
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
			public Guid? ORD_PRC_SPB_SupplierBill_HeaderID {	get; set; }
			public Guid? Supplier_RefID {	get; set; }
			public Guid? Currency_RefID {	get; set; }
			public String SupplierBillNumber {	get; set; }
			public DateTime? DateOnBill {	get; set; }
			public Decimal? TotalValue_BeforeTax {	get; set; }
			public Decimal? TotalValue_IncludingTax {	get; set; }
			public String BillComment {	get; set; }
			public DateTime? PaymentTargetDate {	get; set; }
			public Double? CashDiscountInPercent {	get; set; }
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
			public static List<ORM_ORD_PRC_SPB_SupplierBill_Header> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_ORD_PRC_SPB_SupplierBill_Header> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_ORD_PRC_SPB_SupplierBill_Header> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_ORD_PRC_SPB_SupplierBill_Header> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_ORD_PRC_SPB_SupplierBill_Header> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_ORD_PRC_SPB_SupplierBill_Header>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "ORD_PRC_SPB_SupplierBill_HeaderID","Supplier_RefID","Currency_RefID","SupplierBillNumber","DateOnBill","TotalValue_BeforeTax","TotalValue_IncludingTax","BillComment","PaymentTargetDate","CashDiscountInPercent","Creation_Timestamp","Tenant_RefID","IsDeleted" });
			        while (reader.Read())
			        {
			            ORM_ORD_PRC_SPB_SupplierBill_Header item = new ORM_ORD_PRC_SPB_SupplierBill_Header();
						//0:Parameter ORD_PRC_SPB_SupplierBill_HeaderID of type Guid
						item.ORD_PRC_SPB_SupplierBill_HeaderID = reader.GetGuid(0);
						//1:Parameter Supplier_RefID of type Guid
						item.Supplier_RefID = reader.GetGuid(1);
						//2:Parameter Currency_RefID of type Guid
						item.Currency_RefID = reader.GetGuid(2);
						//3:Parameter SupplierBillNumber of type String
						item.SupplierBillNumber = reader.GetString(3);
						//4:Parameter DateOnBill of type DateTime
						item.DateOnBill = reader.GetDate(4);
						//5:Parameter TotalValue_BeforeTax of type Decimal
						item.TotalValue_BeforeTax = reader.GetDecimal(5);
						//6:Parameter TotalValue_IncludingTax of type Decimal
						item.TotalValue_IncludingTax = reader.GetDecimal(6);
						//7:Parameter BillComment of type String
						item.BillComment = reader.GetString(7);
						//8:Parameter PaymentTargetDate of type DateTime
						item.PaymentTargetDate = reader.GetDate(8);
						//9:Parameter CashDiscountInPercent of type Double
						item.CashDiscountInPercent = reader.GetDouble(9);
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
