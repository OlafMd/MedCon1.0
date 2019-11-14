/* 
 * Generated on 4/7/2014 5:29:04 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;

namespace CL1_ORD_PRC
{
	[Serializable]
	public class ORM_ORD_PRC_SPB_SupplierBill_Position
	{
		public static readonly string TableName = "ord_prc_spb_supplierbill_positions";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_ORD_PRC_SPB_SupplierBill_Position()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_ORD_PRC_SPB_SupplierBill_PositionID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _ORD_PRC_SPB_SupplierBill_PositionID = default(Guid);
		private Guid _SupplierBill_Header_RefID = default(Guid);
		private String _PositionNumber = default(String);
		private String _BillPosition_Comment = default(String);
		private int _PositionIndex = default(int);
		private Decimal _PositionValue_BeforeTax = default(Decimal);
		private Decimal _PositionValue_IncludingTax = default(Decimal);
		private String _BillPosition_ProductNumber = default(String);
		private Double _Quantity = default(Double);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid ORD_PRC_SPB_SupplierBill_PositionID { 
			get {
				return _ORD_PRC_SPB_SupplierBill_PositionID;
			}
			set {
				if(_ORD_PRC_SPB_SupplierBill_PositionID != value){
					_ORD_PRC_SPB_SupplierBill_PositionID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid SupplierBill_Header_RefID { 
			get {
				return _SupplierBill_Header_RefID;
			}
			set {
				if(_SupplierBill_Header_RefID != value){
					_SupplierBill_Header_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String PositionNumber { 
			get {
				return _PositionNumber;
			}
			set {
				if(_PositionNumber != value){
					_PositionNumber = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String BillPosition_Comment { 
			get {
				return _BillPosition_Comment;
			}
			set {
				if(_BillPosition_Comment != value){
					_BillPosition_Comment = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int PositionIndex { 
			get {
				return _PositionIndex;
			}
			set {
				if(_PositionIndex != value){
					_PositionIndex = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Decimal PositionValue_BeforeTax { 
			get {
				return _PositionValue_BeforeTax;
			}
			set {
				if(_PositionValue_BeforeTax != value){
					_PositionValue_BeforeTax = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Decimal PositionValue_IncludingTax { 
			get {
				return _PositionValue_IncludingTax;
			}
			set {
				if(_PositionValue_IncludingTax != value){
					_PositionValue_IncludingTax = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String BillPosition_ProductNumber { 
			get {
				return _BillPosition_ProductNumber;
			}
			set {
				if(_BillPosition_ProductNumber != value){
					_BillPosition_ProductNumber = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Double Quantity { 
			get {
				return _Quantity;
			}
			set {
				if(_Quantity != value){
					_Quantity = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_ORD_PRC.ORD_PRC_SPB_SupplierBill_Position.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_ORD_PRC.ORD_PRC_SPB_SupplierBill_Position.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ORD_PRC_SPB_SupplierBill_PositionID", _ORD_PRC_SPB_SupplierBill_PositionID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "SupplierBill_Header_RefID", _SupplierBill_Header_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "PositionNumber", _PositionNumber);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "BillPosition_Comment", _BillPosition_Comment);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "PositionIndex", _PositionIndex);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "PositionValue_BeforeTax", _PositionValue_BeforeTax);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "PositionValue_IncludingTax", _PositionValue_IncludingTax);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "BillPosition_ProductNumber", _BillPosition_ProductNumber);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Quantity", _Quantity);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_ORD_PRC.ORD_PRC_SPB_SupplierBill_Position.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_ORD_PRC_SPB_SupplierBill_PositionID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ORD_PRC_SPB_SupplierBill_PositionID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "ORD_PRC_SPB_SupplierBill_PositionID","SupplierBill_Header_RefID","PositionNumber","BillPosition_Comment","PositionIndex","PositionValue_BeforeTax","PositionValue_IncludingTax","BillPosition_ProductNumber","Quantity","Creation_Timestamp","Tenant_RefID","IsDeleted" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter ORD_PRC_SPB_SupplierBill_PositionID of type Guid
						_ORD_PRC_SPB_SupplierBill_PositionID = reader.GetGuid(0);
						//1:Parameter SupplierBill_Header_RefID of type Guid
						_SupplierBill_Header_RefID = reader.GetGuid(1);
						//2:Parameter PositionNumber of type String
						_PositionNumber = reader.GetString(2);
						//3:Parameter BillPosition_Comment of type String
						_BillPosition_Comment = reader.GetString(3);
						//4:Parameter PositionIndex of type int
						_PositionIndex = reader.GetInteger(4);
						//5:Parameter PositionValue_BeforeTax of type Decimal
						_PositionValue_BeforeTax = reader.GetDecimal(5);
						//6:Parameter PositionValue_IncludingTax of type Decimal
						_PositionValue_IncludingTax = reader.GetDecimal(6);
						//7:Parameter BillPosition_ProductNumber of type String
						_BillPosition_ProductNumber = reader.GetString(7);
						//8:Parameter Quantity of type Double
						_Quantity = reader.GetDouble(8);
						//9:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(9);
						//10:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(10);
						//11:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(11);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_ORD_PRC_SPB_SupplierBill_PositionID != Guid.Empty){
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
			public Guid? ORD_PRC_SPB_SupplierBill_PositionID {	get; set; }
			public Guid? SupplierBill_Header_RefID {	get; set; }
			public String PositionNumber {	get; set; }
			public String BillPosition_Comment {	get; set; }
			public int? PositionIndex {	get; set; }
			public Decimal? PositionValue_BeforeTax {	get; set; }
			public Decimal? PositionValue_IncludingTax {	get; set; }
			public String BillPosition_ProductNumber {	get; set; }
			public Double? Quantity {	get; set; }
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
			public static List<ORM_ORD_PRC_SPB_SupplierBill_Position> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_ORD_PRC_SPB_SupplierBill_Position> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_ORD_PRC_SPB_SupplierBill_Position> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_ORD_PRC_SPB_SupplierBill_Position> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_ORD_PRC_SPB_SupplierBill_Position> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_ORD_PRC_SPB_SupplierBill_Position>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "ORD_PRC_SPB_SupplierBill_PositionID","SupplierBill_Header_RefID","PositionNumber","BillPosition_Comment","PositionIndex","PositionValue_BeforeTax","PositionValue_IncludingTax","BillPosition_ProductNumber","Quantity","Creation_Timestamp","Tenant_RefID","IsDeleted" });
			        while (reader.Read())
			        {
			            ORM_ORD_PRC_SPB_SupplierBill_Position item = new ORM_ORD_PRC_SPB_SupplierBill_Position();
						//0:Parameter ORD_PRC_SPB_SupplierBill_PositionID of type Guid
						item.ORD_PRC_SPB_SupplierBill_PositionID = reader.GetGuid(0);
						//1:Parameter SupplierBill_Header_RefID of type Guid
						item.SupplierBill_Header_RefID = reader.GetGuid(1);
						//2:Parameter PositionNumber of type String
						item.PositionNumber = reader.GetString(2);
						//3:Parameter BillPosition_Comment of type String
						item.BillPosition_Comment = reader.GetString(3);
						//4:Parameter PositionIndex of type int
						item.PositionIndex = reader.GetInteger(4);
						//5:Parameter PositionValue_BeforeTax of type Decimal
						item.PositionValue_BeforeTax = reader.GetDecimal(5);
						//6:Parameter PositionValue_IncludingTax of type Decimal
						item.PositionValue_IncludingTax = reader.GetDecimal(6);
						//7:Parameter BillPosition_ProductNumber of type String
						item.BillPosition_ProductNumber = reader.GetString(7);
						//8:Parameter Quantity of type Double
						item.Quantity = reader.GetDouble(8);
						//9:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(9);
						//10:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(10);
						//11:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(11);


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
