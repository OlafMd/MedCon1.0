/* 
 * Generated on 7/8/2013 11:01:43 AM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_RES
{
	[Serializable]
	public class ORM_RES_RealestateProperty_LandRegistrationEntry
	{
		public static readonly string TableName = "res_realestateproperty_landregistrationentries";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_RES_RealestateProperty_LandRegistrationEntry()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_RES_RealestateProperty_LandRegistrationEntryID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _RES_RealestateProperty_LandRegistrationEntryID = default(Guid);
		private Guid _RealestateProperty_RefID = default(Guid);
		private String _LandRegistrationEntry_LandTitleRegister = default(String);
		private String _LandRegistrationEntry_Marking = default(String);
		private int _LandRegistrationEntry_LandLot = default(int);
		private int _LandRegistrationEntry_Parcel_FromNumber = default(int);
		private int _LandRegistrationEntry_Parcel_ToNumber = default(int);
		private int _LandRegistrationEntry_Sheet = default(int);
		private double _LandRegistrationEntry_GroundAreaSize_in_sqm = default(double);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Boolean _IsDeleted = default(Boolean);
		private Guid _Tenant_RefID = default(Guid);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid RES_RealestateProperty_LandRegistrationEntryID { 
			get {
				return _RES_RealestateProperty_LandRegistrationEntryID;
			}
			set {
				if(_RES_RealestateProperty_LandRegistrationEntryID != value){
					_RES_RealestateProperty_LandRegistrationEntryID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid RealestateProperty_RefID { 
			get {
				return _RealestateProperty_RefID;
			}
			set {
				if(_RealestateProperty_RefID != value){
					_RealestateProperty_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String LandRegistrationEntry_LandTitleRegister { 
			get {
				return _LandRegistrationEntry_LandTitleRegister;
			}
			set {
				if(_LandRegistrationEntry_LandTitleRegister != value){
					_LandRegistrationEntry_LandTitleRegister = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String LandRegistrationEntry_Marking { 
			get {
				return _LandRegistrationEntry_Marking;
			}
			set {
				if(_LandRegistrationEntry_Marking != value){
					_LandRegistrationEntry_Marking = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int LandRegistrationEntry_LandLot { 
			get {
				return _LandRegistrationEntry_LandLot;
			}
			set {
				if(_LandRegistrationEntry_LandLot != value){
					_LandRegistrationEntry_LandLot = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int LandRegistrationEntry_Parcel_FromNumber { 
			get {
				return _LandRegistrationEntry_Parcel_FromNumber;
			}
			set {
				if(_LandRegistrationEntry_Parcel_FromNumber != value){
					_LandRegistrationEntry_Parcel_FromNumber = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int LandRegistrationEntry_Parcel_ToNumber { 
			get {
				return _LandRegistrationEntry_Parcel_ToNumber;
			}
			set {
				if(_LandRegistrationEntry_Parcel_ToNumber != value){
					_LandRegistrationEntry_Parcel_ToNumber = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int LandRegistrationEntry_Sheet { 
			get {
				return _LandRegistrationEntry_Sheet;
			}
			set {
				if(_LandRegistrationEntry_Sheet != value){
					_LandRegistrationEntry_Sheet = value;
					Status_IsDirty = true;
				}
			}
		} 
		public double LandRegistrationEntry_GroundAreaSize_in_sqm { 
			get {
				return _LandRegistrationEntry_GroundAreaSize_in_sqm;
			}
			set {
				if(_LandRegistrationEntry_GroundAreaSize_in_sqm != value){
					_LandRegistrationEntry_GroundAreaSize_in_sqm = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_RES.RES_RealestateProperty_LandRegistrationEntry.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_RES.RES_RealestateProperty_LandRegistrationEntry.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "RES_RealestateProperty_LandRegistrationEntryID", _RES_RealestateProperty_LandRegistrationEntryID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "RealestateProperty_RefID", _RealestateProperty_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "LandRegistrationEntry_LandTitleRegister", _LandRegistrationEntry_LandTitleRegister);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "LandRegistrationEntry_Marking", _LandRegistrationEntry_Marking);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "LandRegistrationEntry_LandLot", _LandRegistrationEntry_LandLot);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "LandRegistrationEntry_Parcel_FromNumber", _LandRegistrationEntry_Parcel_FromNumber);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "LandRegistrationEntry_Parcel_ToNumber", _LandRegistrationEntry_Parcel_ToNumber);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "LandRegistrationEntry_Sheet", _LandRegistrationEntry_Sheet);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "LandRegistrationEntry_GroundAreaSize_in_sqm", _LandRegistrationEntry_GroundAreaSize_in_sqm);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Creation_Timestamp", _Creation_Timestamp);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsDeleted", _IsDeleted);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Tenant_RefID", _Tenant_RefID);


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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_RES.RES_RealestateProperty_LandRegistrationEntry.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_RES_RealestateProperty_LandRegistrationEntryID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"RES_RealestateProperty_LandRegistrationEntryID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "RES_RealestateProperty_LandRegistrationEntryID","RealestateProperty_RefID","LandRegistrationEntry_LandTitleRegister","LandRegistrationEntry_Marking","LandRegistrationEntry_LandLot","LandRegistrationEntry_Parcel_FromNumber","LandRegistrationEntry_Parcel_ToNumber","LandRegistrationEntry_Sheet","LandRegistrationEntry_GroundAreaSize_in_sqm","Creation_Timestamp","IsDeleted","Tenant_RefID" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter RES_RealestateProperty_LandRegistrationEntryID of type Guid
						_RES_RealestateProperty_LandRegistrationEntryID = reader.GetGuid(0);
						//1:Parameter RealestateProperty_RefID of type Guid
						_RealestateProperty_RefID = reader.GetGuid(1);
						//2:Parameter LandRegistrationEntry_LandTitleRegister of type String
						_LandRegistrationEntry_LandTitleRegister = reader.GetString(2);
						//3:Parameter LandRegistrationEntry_Marking of type String
						_LandRegistrationEntry_Marking = reader.GetString(3);
						//4:Parameter LandRegistrationEntry_LandLot of type int
						_LandRegistrationEntry_LandLot = reader.GetInteger(4);
						//5:Parameter LandRegistrationEntry_Parcel_FromNumber of type int
						_LandRegistrationEntry_Parcel_FromNumber = reader.GetInteger(5);
						//6:Parameter LandRegistrationEntry_Parcel_ToNumber of type int
						_LandRegistrationEntry_Parcel_ToNumber = reader.GetInteger(6);
						//7:Parameter LandRegistrationEntry_Sheet of type int
						_LandRegistrationEntry_Sheet = reader.GetInteger(7);
						//8:Parameter LandRegistrationEntry_GroundAreaSize_in_sqm of type double
						_LandRegistrationEntry_GroundAreaSize_in_sqm = reader.GetDouble(8);
						//9:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(9);
						//10:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(10);
						//11:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(11);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_RES_RealestateProperty_LandRegistrationEntryID != Guid.Empty){
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
			public Guid? RES_RealestateProperty_LandRegistrationEntryID {	get; set; }
			public Guid? RealestateProperty_RefID {	get; set; }
			public String LandRegistrationEntry_LandTitleRegister {	get; set; }
			public String LandRegistrationEntry_Marking {	get; set; }
			public int? LandRegistrationEntry_LandLot {	get; set; }
			public int? LandRegistrationEntry_Parcel_FromNumber {	get; set; }
			public int? LandRegistrationEntry_Parcel_ToNumber {	get; set; }
			public int? LandRegistrationEntry_Sheet {	get; set; }
			public double? LandRegistrationEntry_GroundAreaSize_in_sqm {	get; set; }
			public DateTime? Creation_Timestamp {	get; set; }
			public Boolean? IsDeleted {	get; set; }
			public Guid? Tenant_RefID {	get; set; }
			 

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
			public static List<ORM_RES_RealestateProperty_LandRegistrationEntry> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_RES_RealestateProperty_LandRegistrationEntry> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_RES_RealestateProperty_LandRegistrationEntry> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_RES_RealestateProperty_LandRegistrationEntry> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_RES_RealestateProperty_LandRegistrationEntry> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_RES_RealestateProperty_LandRegistrationEntry>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "RES_RealestateProperty_LandRegistrationEntryID","RealestateProperty_RefID","LandRegistrationEntry_LandTitleRegister","LandRegistrationEntry_Marking","LandRegistrationEntry_LandLot","LandRegistrationEntry_Parcel_FromNumber","LandRegistrationEntry_Parcel_ToNumber","LandRegistrationEntry_Sheet","LandRegistrationEntry_GroundAreaSize_in_sqm","Creation_Timestamp","IsDeleted","Tenant_RefID" });
			        while (reader.Read())
			        {
			            ORM_RES_RealestateProperty_LandRegistrationEntry item = new ORM_RES_RealestateProperty_LandRegistrationEntry();
						//0:Parameter RES_RealestateProperty_LandRegistrationEntryID of type Guid
						item.RES_RealestateProperty_LandRegistrationEntryID = reader.GetGuid(0);
						//1:Parameter RealestateProperty_RefID of type Guid
						item.RealestateProperty_RefID = reader.GetGuid(1);
						//2:Parameter LandRegistrationEntry_LandTitleRegister of type String
						item.LandRegistrationEntry_LandTitleRegister = reader.GetString(2);
						//3:Parameter LandRegistrationEntry_Marking of type String
						item.LandRegistrationEntry_Marking = reader.GetString(3);
						//4:Parameter LandRegistrationEntry_LandLot of type int
						item.LandRegistrationEntry_LandLot = reader.GetInteger(4);
						//5:Parameter LandRegistrationEntry_Parcel_FromNumber of type int
						item.LandRegistrationEntry_Parcel_FromNumber = reader.GetInteger(5);
						//6:Parameter LandRegistrationEntry_Parcel_ToNumber of type int
						item.LandRegistrationEntry_Parcel_ToNumber = reader.GetInteger(6);
						//7:Parameter LandRegistrationEntry_Sheet of type int
						item.LandRegistrationEntry_Sheet = reader.GetInteger(7);
						//8:Parameter LandRegistrationEntry_GroundAreaSize_in_sqm of type double
						item.LandRegistrationEntry_GroundAreaSize_in_sqm = reader.GetDouble(8);
						//9:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(9);
						//10:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(10);
						//11:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(11);


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
