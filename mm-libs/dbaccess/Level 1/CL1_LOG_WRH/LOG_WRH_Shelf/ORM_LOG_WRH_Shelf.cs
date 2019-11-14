/* 
 * Generated on 8/18/2014 5:44:26 PM
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
	public class ORM_LOG_WRH_Shelf
	{
		public static readonly string TableName = "log_wrh_shelves";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_LOG_WRH_Shelf()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_LOG_WRH_ShelfID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _LOG_WRH_ShelfID = default(Guid);
		private String _GlobalPropertyMatchingID = default(String);
		private Guid _Rack_RefID = default(Guid);
		private Guid _R_Warehouse_RefID = default(Guid);
		private Guid _R_Area_RefID = default(Guid);
		private String _Shelf_Name = default(String);
		private String _CoordinateCode = default(String);
		private String _CoordinateX = default(String);
		private String _CoordinateY = default(String);
		private String _CoordinateZ = default(String);
		private Guid _ShelfCapacity_Unit_RefID = default(Guid);
		private decimal _ShelfCapacity_Maximum = default(decimal);
		private decimal _R_ShelfCapacity_Free = default(decimal);
		private decimal _R_ShelfCapacity_Used = default(decimal);
		private Boolean _LimitShelfContent_ToOneProduct = default(Boolean);
		private Boolean _LimitShelfContent_ToOneProductVariant = default(Boolean);
		private Boolean _LimitShelfContent_ToOneProductRelease = default(Boolean);
		private Boolean _IsShelfLocked = default(Boolean);
		private Guid _Predefined_Product_RefID = default(Guid);
		private Guid _Predefined_Product_Variant_RefID = default(Guid);
		private Guid _Predefined_Product_Release_RefID = default(Guid);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid LOG_WRH_ShelfID { 
			get {
				return _LOG_WRH_ShelfID;
			}
			set {
				if(_LOG_WRH_ShelfID != value){
					_LOG_WRH_ShelfID = value;
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
		public Guid Rack_RefID { 
			get {
				return _Rack_RefID;
			}
			set {
				if(_Rack_RefID != value){
					_Rack_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid R_Warehouse_RefID { 
			get {
				return _R_Warehouse_RefID;
			}
			set {
				if(_R_Warehouse_RefID != value){
					_R_Warehouse_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid R_Area_RefID { 
			get {
				return _R_Area_RefID;
			}
			set {
				if(_R_Area_RefID != value){
					_R_Area_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String Shelf_Name { 
			get {
				return _Shelf_Name;
			}
			set {
				if(_Shelf_Name != value){
					_Shelf_Name = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String CoordinateCode { 
			get {
				return _CoordinateCode;
			}
			set {
				if(_CoordinateCode != value){
					_CoordinateCode = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String CoordinateX { 
			get {
				return _CoordinateX;
			}
			set {
				if(_CoordinateX != value){
					_CoordinateX = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String CoordinateY { 
			get {
				return _CoordinateY;
			}
			set {
				if(_CoordinateY != value){
					_CoordinateY = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String CoordinateZ { 
			get {
				return _CoordinateZ;
			}
			set {
				if(_CoordinateZ != value){
					_CoordinateZ = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid ShelfCapacity_Unit_RefID { 
			get {
				return _ShelfCapacity_Unit_RefID;
			}
			set {
				if(_ShelfCapacity_Unit_RefID != value){
					_ShelfCapacity_Unit_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public decimal ShelfCapacity_Maximum { 
			get {
				return _ShelfCapacity_Maximum;
			}
			set {
				if(_ShelfCapacity_Maximum != value){
					_ShelfCapacity_Maximum = value;
					Status_IsDirty = true;
				}
			}
		} 
		public decimal R_ShelfCapacity_Free { 
			get {
				return _R_ShelfCapacity_Free;
			}
			set {
				if(_R_ShelfCapacity_Free != value){
					_R_ShelfCapacity_Free = value;
					Status_IsDirty = true;
				}
			}
		} 
		public decimal R_ShelfCapacity_Used { 
			get {
				return _R_ShelfCapacity_Used;
			}
			set {
				if(_R_ShelfCapacity_Used != value){
					_R_ShelfCapacity_Used = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean LimitShelfContent_ToOneProduct { 
			get {
				return _LimitShelfContent_ToOneProduct;
			}
			set {
				if(_LimitShelfContent_ToOneProduct != value){
					_LimitShelfContent_ToOneProduct = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean LimitShelfContent_ToOneProductVariant { 
			get {
				return _LimitShelfContent_ToOneProductVariant;
			}
			set {
				if(_LimitShelfContent_ToOneProductVariant != value){
					_LimitShelfContent_ToOneProductVariant = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean LimitShelfContent_ToOneProductRelease { 
			get {
				return _LimitShelfContent_ToOneProductRelease;
			}
			set {
				if(_LimitShelfContent_ToOneProductRelease != value){
					_LimitShelfContent_ToOneProductRelease = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsShelfLocked { 
			get {
				return _IsShelfLocked;
			}
			set {
				if(_IsShelfLocked != value){
					_IsShelfLocked = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Predefined_Product_RefID { 
			get {
				return _Predefined_Product_RefID;
			}
			set {
				if(_Predefined_Product_RefID != value){
					_Predefined_Product_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Predefined_Product_Variant_RefID { 
			get {
				return _Predefined_Product_Variant_RefID;
			}
			set {
				if(_Predefined_Product_Variant_RefID != value){
					_Predefined_Product_Variant_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Predefined_Product_Release_RefID { 
			get {
				return _Predefined_Product_Release_RefID;
			}
			set {
				if(_Predefined_Product_Release_RefID != value){
					_Predefined_Product_Release_RefID = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_LOG_WRH.LOG_WRH_Shelf.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_LOG_WRH.LOG_WRH_Shelf.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "LOG_WRH_ShelfID", _LOG_WRH_ShelfID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "GlobalPropertyMatchingID", _GlobalPropertyMatchingID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Rack_RefID", _Rack_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "R_Warehouse_RefID", _R_Warehouse_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "R_Area_RefID", _R_Area_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Shelf_Name", _Shelf_Name);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CoordinateCode", _CoordinateCode);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CoordinateX", _CoordinateX);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CoordinateY", _CoordinateY);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CoordinateZ", _CoordinateZ);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ShelfCapacity_Unit_RefID", _ShelfCapacity_Unit_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ShelfCapacity_Maximum", _ShelfCapacity_Maximum);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "R_ShelfCapacity_Free", _R_ShelfCapacity_Free);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "R_ShelfCapacity_Used", _R_ShelfCapacity_Used);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "LimitShelfContent_ToOneProduct", _LimitShelfContent_ToOneProduct);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "LimitShelfContent_ToOneProductVariant", _LimitShelfContent_ToOneProductVariant);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "LimitShelfContent_ToOneProductRelease", _LimitShelfContent_ToOneProductRelease);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsShelfLocked", _IsShelfLocked);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Predefined_Product_RefID", _Predefined_Product_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Predefined_Product_Variant_RefID", _Predefined_Product_Variant_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Predefined_Product_Release_RefID", _Predefined_Product_Release_RefID);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_LOG_WRH.LOG_WRH_Shelf.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_LOG_WRH_ShelfID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"LOG_WRH_ShelfID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "LOG_WRH_ShelfID","GlobalPropertyMatchingID","Rack_RefID","R_Warehouse_RefID","R_Area_RefID","Shelf_Name","CoordinateCode","CoordinateX","CoordinateY","CoordinateZ","ShelfCapacity_Unit_RefID","ShelfCapacity_Maximum","R_ShelfCapacity_Free","R_ShelfCapacity_Used","LimitShelfContent_ToOneProduct","LimitShelfContent_ToOneProductVariant","LimitShelfContent_ToOneProductRelease","IsShelfLocked","Predefined_Product_RefID","Predefined_Product_Variant_RefID","Predefined_Product_Release_RefID","Creation_Timestamp","Tenant_RefID","IsDeleted" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter LOG_WRH_ShelfID of type Guid
						_LOG_WRH_ShelfID = reader.GetGuid(0);
						//1:Parameter GlobalPropertyMatchingID of type String
						_GlobalPropertyMatchingID = reader.GetString(1);
						//2:Parameter Rack_RefID of type Guid
						_Rack_RefID = reader.GetGuid(2);
						//3:Parameter R_Warehouse_RefID of type Guid
						_R_Warehouse_RefID = reader.GetGuid(3);
						//4:Parameter R_Area_RefID of type Guid
						_R_Area_RefID = reader.GetGuid(4);
						//5:Parameter Shelf_Name of type String
						_Shelf_Name = reader.GetString(5);
						//6:Parameter CoordinateCode of type String
						_CoordinateCode = reader.GetString(6);
						//7:Parameter CoordinateX of type String
						_CoordinateX = reader.GetString(7);
						//8:Parameter CoordinateY of type String
						_CoordinateY = reader.GetString(8);
						//9:Parameter CoordinateZ of type String
						_CoordinateZ = reader.GetString(9);
						//10:Parameter ShelfCapacity_Unit_RefID of type Guid
						_ShelfCapacity_Unit_RefID = reader.GetGuid(10);
						//11:Parameter ShelfCapacity_Maximum of type decimal
						_ShelfCapacity_Maximum = reader.GetDecimal(11);
						//12:Parameter R_ShelfCapacity_Free of type decimal
						_R_ShelfCapacity_Free = reader.GetDecimal(12);
						//13:Parameter R_ShelfCapacity_Used of type decimal
						_R_ShelfCapacity_Used = reader.GetDecimal(13);
						//14:Parameter LimitShelfContent_ToOneProduct of type Boolean
						_LimitShelfContent_ToOneProduct = reader.GetBoolean(14);
						//15:Parameter LimitShelfContent_ToOneProductVariant of type Boolean
						_LimitShelfContent_ToOneProductVariant = reader.GetBoolean(15);
						//16:Parameter LimitShelfContent_ToOneProductRelease of type Boolean
						_LimitShelfContent_ToOneProductRelease = reader.GetBoolean(16);
						//17:Parameter IsShelfLocked of type Boolean
						_IsShelfLocked = reader.GetBoolean(17);
						//18:Parameter Predefined_Product_RefID of type Guid
						_Predefined_Product_RefID = reader.GetGuid(18);
						//19:Parameter Predefined_Product_Variant_RefID of type Guid
						_Predefined_Product_Variant_RefID = reader.GetGuid(19);
						//20:Parameter Predefined_Product_Release_RefID of type Guid
						_Predefined_Product_Release_RefID = reader.GetGuid(20);
						//21:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(21);
						//22:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(22);
						//23:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(23);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_LOG_WRH_ShelfID != Guid.Empty){
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
			public Guid? LOG_WRH_ShelfID {	get; set; }
			public String GlobalPropertyMatchingID {	get; set; }
			public Guid? Rack_RefID {	get; set; }
			public Guid? R_Warehouse_RefID {	get; set; }
			public Guid? R_Area_RefID {	get; set; }
			public String Shelf_Name {	get; set; }
			public String CoordinateCode {	get; set; }
			public String CoordinateX {	get; set; }
			public String CoordinateY {	get; set; }
			public String CoordinateZ {	get; set; }
			public Guid? ShelfCapacity_Unit_RefID {	get; set; }
			public decimal? ShelfCapacity_Maximum {	get; set; }
			public decimal? R_ShelfCapacity_Free {	get; set; }
			public decimal? R_ShelfCapacity_Used {	get; set; }
			public Boolean? LimitShelfContent_ToOneProduct {	get; set; }
			public Boolean? LimitShelfContent_ToOneProductVariant {	get; set; }
			public Boolean? LimitShelfContent_ToOneProductRelease {	get; set; }
			public Boolean? IsShelfLocked {	get; set; }
			public Guid? Predefined_Product_RefID {	get; set; }
			public Guid? Predefined_Product_Variant_RefID {	get; set; }
			public Guid? Predefined_Product_Release_RefID {	get; set; }
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
			public static List<ORM_LOG_WRH_Shelf> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_LOG_WRH_Shelf> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_LOG_WRH_Shelf> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_LOG_WRH_Shelf> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_LOG_WRH_Shelf> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_LOG_WRH_Shelf>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "LOG_WRH_ShelfID","GlobalPropertyMatchingID","Rack_RefID","R_Warehouse_RefID","R_Area_RefID","Shelf_Name","CoordinateCode","CoordinateX","CoordinateY","CoordinateZ","ShelfCapacity_Unit_RefID","ShelfCapacity_Maximum","R_ShelfCapacity_Free","R_ShelfCapacity_Used","LimitShelfContent_ToOneProduct","LimitShelfContent_ToOneProductVariant","LimitShelfContent_ToOneProductRelease","IsShelfLocked","Predefined_Product_RefID","Predefined_Product_Variant_RefID","Predefined_Product_Release_RefID","Creation_Timestamp","Tenant_RefID","IsDeleted" });
			        while (reader.Read())
			        {
			            ORM_LOG_WRH_Shelf item = new ORM_LOG_WRH_Shelf();
						//0:Parameter LOG_WRH_ShelfID of type Guid
						item.LOG_WRH_ShelfID = reader.GetGuid(0);
						//1:Parameter GlobalPropertyMatchingID of type String
						item.GlobalPropertyMatchingID = reader.GetString(1);
						//2:Parameter Rack_RefID of type Guid
						item.Rack_RefID = reader.GetGuid(2);
						//3:Parameter R_Warehouse_RefID of type Guid
						item.R_Warehouse_RefID = reader.GetGuid(3);
						//4:Parameter R_Area_RefID of type Guid
						item.R_Area_RefID = reader.GetGuid(4);
						//5:Parameter Shelf_Name of type String
						item.Shelf_Name = reader.GetString(5);
						//6:Parameter CoordinateCode of type String
						item.CoordinateCode = reader.GetString(6);
						//7:Parameter CoordinateX of type String
						item.CoordinateX = reader.GetString(7);
						//8:Parameter CoordinateY of type String
						item.CoordinateY = reader.GetString(8);
						//9:Parameter CoordinateZ of type String
						item.CoordinateZ = reader.GetString(9);
						//10:Parameter ShelfCapacity_Unit_RefID of type Guid
						item.ShelfCapacity_Unit_RefID = reader.GetGuid(10);
						//11:Parameter ShelfCapacity_Maximum of type decimal
						item.ShelfCapacity_Maximum = reader.GetDecimal(11);
						//12:Parameter R_ShelfCapacity_Free of type decimal
						item.R_ShelfCapacity_Free = reader.GetDecimal(12);
						//13:Parameter R_ShelfCapacity_Used of type decimal
						item.R_ShelfCapacity_Used = reader.GetDecimal(13);
						//14:Parameter LimitShelfContent_ToOneProduct of type Boolean
						item.LimitShelfContent_ToOneProduct = reader.GetBoolean(14);
						//15:Parameter LimitShelfContent_ToOneProductVariant of type Boolean
						item.LimitShelfContent_ToOneProductVariant = reader.GetBoolean(15);
						//16:Parameter LimitShelfContent_ToOneProductRelease of type Boolean
						item.LimitShelfContent_ToOneProductRelease = reader.GetBoolean(16);
						//17:Parameter IsShelfLocked of type Boolean
						item.IsShelfLocked = reader.GetBoolean(17);
						//18:Parameter Predefined_Product_RefID of type Guid
						item.Predefined_Product_RefID = reader.GetGuid(18);
						//19:Parameter Predefined_Product_Variant_RefID of type Guid
						item.Predefined_Product_Variant_RefID = reader.GetGuid(19);
						//20:Parameter Predefined_Product_Release_RefID of type Guid
						item.Predefined_Product_Release_RefID = reader.GetGuid(20);
						//21:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(21);
						//22:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(22);
						//23:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(23);


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
