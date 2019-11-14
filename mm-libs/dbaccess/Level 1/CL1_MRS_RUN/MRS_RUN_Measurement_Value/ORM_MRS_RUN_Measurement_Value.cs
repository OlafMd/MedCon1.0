/* 
 * Generated on 2/26/2015 8:38:16 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_MRS_RUN
{
	[Serializable]
	public class ORM_MRS_RUN_Measurement_Value
	{
		public static readonly string TableName = "mrs_run_measurement_values";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_MRS_RUN_Measurement_Value()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_MRS_RUN_Measurement_ValueID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _MRS_RUN_Measurement_ValueID = default(Guid);
		private Guid _Measurement_RefID = default(Guid);
		private double _MeasurementValue = default(double);
		private Guid _MeasurementTariff_RefID = default(Guid);
		private DateTime _MeasuredAt_Time = default(DateTime);
		private double _MeasuredAt_Lattitude = default(double);
		private double _MeasuredAt_Longitude = default(double);
		private Guid _Measurement_AcquisitionType_RefID = default(Guid);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		private DateTime _Modification_Timestamp = default(DateTime);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid MRS_RUN_Measurement_ValueID { 
			get {
				return _MRS_RUN_Measurement_ValueID;
			}
			set {
				if(_MRS_RUN_Measurement_ValueID != value){
					_MRS_RUN_Measurement_ValueID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Measurement_RefID { 
			get {
				return _Measurement_RefID;
			}
			set {
				if(_Measurement_RefID != value){
					_Measurement_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public double MeasurementValue { 
			get {
				return _MeasurementValue;
			}
			set {
				if(_MeasurementValue != value){
					_MeasurementValue = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid MeasurementTariff_RefID { 
			get {
				return _MeasurementTariff_RefID;
			}
			set {
				if(_MeasurementTariff_RefID != value){
					_MeasurementTariff_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime MeasuredAt_Time { 
			get {
				return _MeasuredAt_Time;
			}
			set {
				if(_MeasuredAt_Time != value){
					_MeasuredAt_Time = value;
					Status_IsDirty = true;
				}
			}
		} 
		public double MeasuredAt_Lattitude { 
			get {
				return _MeasuredAt_Lattitude;
			}
			set {
				if(_MeasuredAt_Lattitude != value){
					_MeasuredAt_Lattitude = value;
					Status_IsDirty = true;
				}
			}
		} 
		public double MeasuredAt_Longitude { 
			get {
				return _MeasuredAt_Longitude;
			}
			set {
				if(_MeasuredAt_Longitude != value){
					_MeasuredAt_Longitude = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Measurement_AcquisitionType_RefID { 
			get {
				return _Measurement_AcquisitionType_RefID;
			}
			set {
				if(_Measurement_AcquisitionType_RefID != value){
					_Measurement_AcquisitionType_RefID = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_MRS_RUN.MRS_RUN_Measurement_Value.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_MRS_RUN.MRS_RUN_Measurement_Value.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "MRS_RUN_Measurement_ValueID", _MRS_RUN_Measurement_ValueID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Measurement_RefID", _Measurement_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "MeasurementValue", _MeasurementValue);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "MeasurementTariff_RefID", _MeasurementTariff_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "MeasuredAt_Time", _MeasuredAt_Time);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "MeasuredAt_Lattitude", _MeasuredAt_Lattitude);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "MeasuredAt_Longitude", _MeasuredAt_Longitude);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Measurement_AcquisitionType_RefID", _Measurement_AcquisitionType_RefID);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_MRS_RUN.MRS_RUN_Measurement_Value.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_MRS_RUN_Measurement_ValueID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"MRS_RUN_Measurement_ValueID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "MRS_RUN_Measurement_ValueID","Measurement_RefID","MeasurementValue","MeasurementTariff_RefID","MeasuredAt_Time","MeasuredAt_Lattitude","MeasuredAt_Longitude","Measurement_AcquisitionType_RefID","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter MRS_RUN_Measurement_ValueID of type Guid
						_MRS_RUN_Measurement_ValueID = reader.GetGuid(0);
						//1:Parameter Measurement_RefID of type Guid
						_Measurement_RefID = reader.GetGuid(1);
						//2:Parameter MeasurementValue of type double
						_MeasurementValue = reader.GetDouble(2);
						//3:Parameter MeasurementTariff_RefID of type Guid
						_MeasurementTariff_RefID = reader.GetGuid(3);
						//4:Parameter MeasuredAt_Time of type DateTime
						_MeasuredAt_Time = reader.GetDate(4);
						//5:Parameter MeasuredAt_Lattitude of type double
						_MeasuredAt_Lattitude = reader.GetDouble(5);
						//6:Parameter MeasuredAt_Longitude of type double
						_MeasuredAt_Longitude = reader.GetDouble(6);
						//7:Parameter Measurement_AcquisitionType_RefID of type Guid
						_Measurement_AcquisitionType_RefID = reader.GetGuid(7);
						//8:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(8);
						//9:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(9);
						//10:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(10);
						//11:Parameter Modification_Timestamp of type DateTime
						_Modification_Timestamp = reader.GetDate(11);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_MRS_RUN_Measurement_ValueID != Guid.Empty){
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
			public Guid? MRS_RUN_Measurement_ValueID {	get; set; }
			public Guid? Measurement_RefID {	get; set; }
			public double? MeasurementValue {	get; set; }
			public Guid? MeasurementTariff_RefID {	get; set; }
			public DateTime? MeasuredAt_Time {	get; set; }
			public double? MeasuredAt_Lattitude {	get; set; }
			public double? MeasuredAt_Longitude {	get; set; }
			public Guid? Measurement_AcquisitionType_RefID {	get; set; }
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
			public static List<ORM_MRS_RUN_Measurement_Value> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_MRS_RUN_Measurement_Value> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_MRS_RUN_Measurement_Value> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_MRS_RUN_Measurement_Value> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_MRS_RUN_Measurement_Value> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_MRS_RUN_Measurement_Value>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "MRS_RUN_Measurement_ValueID","Measurement_RefID","MeasurementValue","MeasurementTariff_RefID","MeasuredAt_Time","MeasuredAt_Lattitude","MeasuredAt_Longitude","Measurement_AcquisitionType_RefID","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
			        while (reader.Read())
			        {
			            ORM_MRS_RUN_Measurement_Value item = new ORM_MRS_RUN_Measurement_Value();
						//0:Parameter MRS_RUN_Measurement_ValueID of type Guid
						item.MRS_RUN_Measurement_ValueID = reader.GetGuid(0);
						//1:Parameter Measurement_RefID of type Guid
						item.Measurement_RefID = reader.GetGuid(1);
						//2:Parameter MeasurementValue of type double
						item.MeasurementValue = reader.GetDouble(2);
						//3:Parameter MeasurementTariff_RefID of type Guid
						item.MeasurementTariff_RefID = reader.GetGuid(3);
						//4:Parameter MeasuredAt_Time of type DateTime
						item.MeasuredAt_Time = reader.GetDate(4);
						//5:Parameter MeasuredAt_Lattitude of type double
						item.MeasuredAt_Lattitude = reader.GetDouble(5);
						//6:Parameter MeasuredAt_Longitude of type double
						item.MeasuredAt_Longitude = reader.GetDouble(6);
						//7:Parameter Measurement_AcquisitionType_RefID of type Guid
						item.Measurement_AcquisitionType_RefID = reader.GetGuid(7);
						//8:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(8);
						//9:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(9);
						//10:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(10);
						//11:Parameter Modification_Timestamp of type DateTime
						item.Modification_Timestamp = reader.GetDate(11);


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
