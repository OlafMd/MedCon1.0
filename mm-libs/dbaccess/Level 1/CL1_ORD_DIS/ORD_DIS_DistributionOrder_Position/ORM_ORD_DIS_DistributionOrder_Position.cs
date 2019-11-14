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
	public class ORM_ORD_DIS_DistributionOrder_Position
	{
		public static readonly string TableName = "ord_dis_distributionorder_positions";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_ORD_DIS_DistributionOrder_Position()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_ORD_DIS_DistributionOrder_PositionID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _ORD_DIS_DistributionOrder_PositionID = default(Guid);
		private Guid _DistributionOrder_Header_RefID = default(Guid);
		private Guid _Product_RefID = default(Guid);
		private Guid _Product_Variant_RefID = default(Guid);
		private Guid _Product_Release_RefID = default(Guid);
		private double _Quantity = default(double);
		private Decimal _InternallyCharged_TotalNetPriceValue = default(Decimal);
		private double _InternallyCharged_TotalPointValue = default(double);
		private int _Position_OrdinalNumber = default(int);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		private DateTime _Modification_Timestamp = default(DateTime);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid ORD_DIS_DistributionOrder_PositionID { 
			get {
				return _ORD_DIS_DistributionOrder_PositionID;
			}
			set {
				if(_ORD_DIS_DistributionOrder_PositionID != value){
					_ORD_DIS_DistributionOrder_PositionID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid DistributionOrder_Header_RefID { 
			get {
				return _DistributionOrder_Header_RefID;
			}
			set {
				if(_DistributionOrder_Header_RefID != value){
					_DistributionOrder_Header_RefID = value;
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
		public double Quantity { 
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
		public int Position_OrdinalNumber { 
			get {
				return _Position_OrdinalNumber;
			}
			set {
				if(_Position_OrdinalNumber != value){
					_Position_OrdinalNumber = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_ORD_DIS.ORD_DIS_DistributionOrder_Position.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_ORD_DIS.ORD_DIS_DistributionOrder_Position.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ORD_DIS_DistributionOrder_PositionID", _ORD_DIS_DistributionOrder_PositionID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "DistributionOrder_Header_RefID", _DistributionOrder_Header_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Product_RefID", _Product_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Product_Variant_RefID", _Product_Variant_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Product_Release_RefID", _Product_Release_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Quantity", _Quantity);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "InternallyCharged_TotalNetPriceValue", _InternallyCharged_TotalNetPriceValue);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "InternallyCharged_TotalPointValue", _InternallyCharged_TotalPointValue);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Position_OrdinalNumber", _Position_OrdinalNumber);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_ORD_DIS.ORD_DIS_DistributionOrder_Position.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_ORD_DIS_DistributionOrder_PositionID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ORD_DIS_DistributionOrder_PositionID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "ORD_DIS_DistributionOrder_PositionID","DistributionOrder_Header_RefID","Product_RefID","Product_Variant_RefID","Product_Release_RefID","Quantity","InternallyCharged_TotalNetPriceValue","InternallyCharged_TotalPointValue","Position_OrdinalNumber","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter ORD_DIS_DistributionOrder_PositionID of type Guid
						_ORD_DIS_DistributionOrder_PositionID = reader.GetGuid(0);
						//1:Parameter DistributionOrder_Header_RefID of type Guid
						_DistributionOrder_Header_RefID = reader.GetGuid(1);
						//2:Parameter Product_RefID of type Guid
						_Product_RefID = reader.GetGuid(2);
						//3:Parameter Product_Variant_RefID of type Guid
						_Product_Variant_RefID = reader.GetGuid(3);
						//4:Parameter Product_Release_RefID of type Guid
						_Product_Release_RefID = reader.GetGuid(4);
						//5:Parameter Quantity of type double
						_Quantity = reader.GetDouble(5);
						//6:Parameter InternallyCharged_TotalNetPriceValue of type Decimal
						_InternallyCharged_TotalNetPriceValue = reader.GetDecimal(6);
						//7:Parameter InternallyCharged_TotalPointValue of type double
						_InternallyCharged_TotalPointValue = reader.GetDouble(7);
						//8:Parameter Position_OrdinalNumber of type int
						_Position_OrdinalNumber = reader.GetInteger(8);
						//9:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(9);
						//10:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(10);
						//11:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(11);
						//12:Parameter Modification_Timestamp of type DateTime
						_Modification_Timestamp = reader.GetDate(12);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_ORD_DIS_DistributionOrder_PositionID != Guid.Empty){
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
			public Guid? ORD_DIS_DistributionOrder_PositionID {	get; set; }
			public Guid? DistributionOrder_Header_RefID {	get; set; }
			public Guid? Product_RefID {	get; set; }
			public Guid? Product_Variant_RefID {	get; set; }
			public Guid? Product_Release_RefID {	get; set; }
			public double? Quantity {	get; set; }
			public Decimal? InternallyCharged_TotalNetPriceValue {	get; set; }
			public double? InternallyCharged_TotalPointValue {	get; set; }
			public int? Position_OrdinalNumber {	get; set; }
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
			public static List<ORM_ORD_DIS_DistributionOrder_Position> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_ORD_DIS_DistributionOrder_Position> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_ORD_DIS_DistributionOrder_Position> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_ORD_DIS_DistributionOrder_Position> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_ORD_DIS_DistributionOrder_Position> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_ORD_DIS_DistributionOrder_Position>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "ORD_DIS_DistributionOrder_PositionID","DistributionOrder_Header_RefID","Product_RefID","Product_Variant_RefID","Product_Release_RefID","Quantity","InternallyCharged_TotalNetPriceValue","InternallyCharged_TotalPointValue","Position_OrdinalNumber","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
			        while (reader.Read())
			        {
			            ORM_ORD_DIS_DistributionOrder_Position item = new ORM_ORD_DIS_DistributionOrder_Position();
						//0:Parameter ORD_DIS_DistributionOrder_PositionID of type Guid
						item.ORD_DIS_DistributionOrder_PositionID = reader.GetGuid(0);
						//1:Parameter DistributionOrder_Header_RefID of type Guid
						item.DistributionOrder_Header_RefID = reader.GetGuid(1);
						//2:Parameter Product_RefID of type Guid
						item.Product_RefID = reader.GetGuid(2);
						//3:Parameter Product_Variant_RefID of type Guid
						item.Product_Variant_RefID = reader.GetGuid(3);
						//4:Parameter Product_Release_RefID of type Guid
						item.Product_Release_RefID = reader.GetGuid(4);
						//5:Parameter Quantity of type double
						item.Quantity = reader.GetDouble(5);
						//6:Parameter InternallyCharged_TotalNetPriceValue of type Decimal
						item.InternallyCharged_TotalNetPriceValue = reader.GetDecimal(6);
						//7:Parameter InternallyCharged_TotalPointValue of type double
						item.InternallyCharged_TotalPointValue = reader.GetDouble(7);
						//8:Parameter Position_OrdinalNumber of type int
						item.Position_OrdinalNumber = reader.GetInteger(8);
						//9:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(9);
						//10:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(10);
						//11:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(11);
						//12:Parameter Modification_Timestamp of type DateTime
						item.Modification_Timestamp = reader.GetDate(12);


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
