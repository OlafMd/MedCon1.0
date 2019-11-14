/* 
 * Generated on 6/24/2014 12:46:26 PM
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
	public class ORM_ORD_PRC_ExtraDemandProduct
	{
		public static readonly string TableName = "ord_prc_extrademandproducts";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_ORD_PRC_ExtraDemandProduct()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_ORD_PRC_ExtraDemandProductID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _ORD_PRC_ExtraDemandProductID = default(Guid);
		private Guid _Supplier_RefID = default(Guid);
		private Guid _Product_RefID = default(Guid);
		private Guid _Product_Variant_RefID = default(Guid);
		private Guid _Product_Release_RefID = default(Guid);
		private Double _RequestedQuantity = default(Double);
		private Boolean _IsProcurementRunning = default(Boolean);
		private Guid _ProcurementOrderPosition_RefID = default(Guid);
		private Guid _CreatedBy_BusinessParticipant_RefID = default(Guid);
		private Guid _CreatedFor_Office_RefID = default(Guid);
		private Guid _DeliveryTo_Warehouse_RefID = default(Guid);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid ORD_PRC_ExtraDemandProductID { 
			get {
				return _ORD_PRC_ExtraDemandProductID;
			}
			set {
				if(_ORD_PRC_ExtraDemandProductID != value){
					_ORD_PRC_ExtraDemandProductID = value;
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
		public Double RequestedQuantity { 
			get {
				return _RequestedQuantity;
			}
			set {
				if(_RequestedQuantity != value){
					_RequestedQuantity = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsProcurementRunning { 
			get {
				return _IsProcurementRunning;
			}
			set {
				if(_IsProcurementRunning != value){
					_IsProcurementRunning = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid ProcurementOrderPosition_RefID { 
			get {
				return _ProcurementOrderPosition_RefID;
			}
			set {
				if(_ProcurementOrderPosition_RefID != value){
					_ProcurementOrderPosition_RefID = value;
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
		public Guid CreatedFor_Office_RefID { 
			get {
				return _CreatedFor_Office_RefID;
			}
			set {
				if(_CreatedFor_Office_RefID != value){
					_CreatedFor_Office_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid DeliveryTo_Warehouse_RefID { 
			get {
				return _DeliveryTo_Warehouse_RefID;
			}
			set {
				if(_DeliveryTo_Warehouse_RefID != value){
					_DeliveryTo_Warehouse_RefID = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_ORD_PRC.ORD_PRC_ExtraDemandProduct.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_ORD_PRC.ORD_PRC_ExtraDemandProduct.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ORD_PRC_ExtraDemandProductID", _ORD_PRC_ExtraDemandProductID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Supplier_RefID", _Supplier_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Product_RefID", _Product_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Product_Variant_RefID", _Product_Variant_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Product_Release_RefID", _Product_Release_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "RequestedQuantity", _RequestedQuantity);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsProcurementRunning", _IsProcurementRunning);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ProcurementOrderPosition_RefID", _ProcurementOrderPosition_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CreatedBy_BusinessParticipant_RefID", _CreatedBy_BusinessParticipant_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CreatedFor_Office_RefID", _CreatedFor_Office_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "DeliveryTo_Warehouse_RefID", _DeliveryTo_Warehouse_RefID);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_ORD_PRC.ORD_PRC_ExtraDemandProduct.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_ORD_PRC_ExtraDemandProductID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ORD_PRC_ExtraDemandProductID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "ORD_PRC_ExtraDemandProductID","Supplier_RefID","Product_RefID","Product_Variant_RefID","Product_Release_RefID","RequestedQuantity","IsProcurementRunning","ProcurementOrderPosition_RefID","CreatedBy_BusinessParticipant_RefID","CreatedFor_Office_RefID","DeliveryTo_Warehouse_RefID","Creation_Timestamp","Tenant_RefID","IsDeleted" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter ORD_PRC_ExtraDemandProductID of type Guid
						_ORD_PRC_ExtraDemandProductID = reader.GetGuid(0);
						//1:Parameter Supplier_RefID of type Guid
						_Supplier_RefID = reader.GetGuid(1);
						//2:Parameter Product_RefID of type Guid
						_Product_RefID = reader.GetGuid(2);
						//3:Parameter Product_Variant_RefID of type Guid
						_Product_Variant_RefID = reader.GetGuid(3);
						//4:Parameter Product_Release_RefID of type Guid
						_Product_Release_RefID = reader.GetGuid(4);
						//5:Parameter RequestedQuantity of type Double
						_RequestedQuantity = reader.GetDouble(5);
						//6:Parameter IsProcurementRunning of type Boolean
						_IsProcurementRunning = reader.GetBoolean(6);
						//7:Parameter ProcurementOrderPosition_RefID of type Guid
						_ProcurementOrderPosition_RefID = reader.GetGuid(7);
						//8:Parameter CreatedBy_BusinessParticipant_RefID of type Guid
						_CreatedBy_BusinessParticipant_RefID = reader.GetGuid(8);
						//9:Parameter CreatedFor_Office_RefID of type Guid
						_CreatedFor_Office_RefID = reader.GetGuid(9);
						//10:Parameter DeliveryTo_Warehouse_RefID of type Guid
						_DeliveryTo_Warehouse_RefID = reader.GetGuid(10);
						//11:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(11);
						//12:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(12);
						//13:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(13);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_ORD_PRC_ExtraDemandProductID != Guid.Empty){
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
			public Guid? ORD_PRC_ExtraDemandProductID {	get; set; }
			public Guid? Supplier_RefID {	get; set; }
			public Guid? Product_RefID {	get; set; }
			public Guid? Product_Variant_RefID {	get; set; }
			public Guid? Product_Release_RefID {	get; set; }
			public Double? RequestedQuantity {	get; set; }
			public Boolean? IsProcurementRunning {	get; set; }
			public Guid? ProcurementOrderPosition_RefID {	get; set; }
			public Guid? CreatedBy_BusinessParticipant_RefID {	get; set; }
			public Guid? CreatedFor_Office_RefID {	get; set; }
			public Guid? DeliveryTo_Warehouse_RefID {	get; set; }
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
			public static List<ORM_ORD_PRC_ExtraDemandProduct> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_ORD_PRC_ExtraDemandProduct> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_ORD_PRC_ExtraDemandProduct> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_ORD_PRC_ExtraDemandProduct> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_ORD_PRC_ExtraDemandProduct> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_ORD_PRC_ExtraDemandProduct>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "ORD_PRC_ExtraDemandProductID","Supplier_RefID","Product_RefID","Product_Variant_RefID","Product_Release_RefID","RequestedQuantity","IsProcurementRunning","ProcurementOrderPosition_RefID","CreatedBy_BusinessParticipant_RefID","CreatedFor_Office_RefID","DeliveryTo_Warehouse_RefID","Creation_Timestamp","Tenant_RefID","IsDeleted" });
			        while (reader.Read())
			        {
			            ORM_ORD_PRC_ExtraDemandProduct item = new ORM_ORD_PRC_ExtraDemandProduct();
						//0:Parameter ORD_PRC_ExtraDemandProductID of type Guid
						item.ORD_PRC_ExtraDemandProductID = reader.GetGuid(0);
						//1:Parameter Supplier_RefID of type Guid
						item.Supplier_RefID = reader.GetGuid(1);
						//2:Parameter Product_RefID of type Guid
						item.Product_RefID = reader.GetGuid(2);
						//3:Parameter Product_Variant_RefID of type Guid
						item.Product_Variant_RefID = reader.GetGuid(3);
						//4:Parameter Product_Release_RefID of type Guid
						item.Product_Release_RefID = reader.GetGuid(4);
						//5:Parameter RequestedQuantity of type Double
						item.RequestedQuantity = reader.GetDouble(5);
						//6:Parameter IsProcurementRunning of type Boolean
						item.IsProcurementRunning = reader.GetBoolean(6);
						//7:Parameter ProcurementOrderPosition_RefID of type Guid
						item.ProcurementOrderPosition_RefID = reader.GetGuid(7);
						//8:Parameter CreatedBy_BusinessParticipant_RefID of type Guid
						item.CreatedBy_BusinessParticipant_RefID = reader.GetGuid(8);
						//9:Parameter CreatedFor_Office_RefID of type Guid
						item.CreatedFor_Office_RefID = reader.GetGuid(9);
						//10:Parameter DeliveryTo_Warehouse_RefID of type Guid
						item.DeliveryTo_Warehouse_RefID = reader.GetGuid(10);
						//11:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(11);
						//12:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(12);
						//13:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(13);


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
