/* 
 * Generated on 11/6/2013 11:22:42 AM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_RES_BLD
{
	[Serializable]
	public class ORM_RES_BLD_Apartment
	{
		public static readonly string TableName = "res_bld_apartments";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_RES_BLD_Apartment()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_RES_BLD_ApartmentID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _RES_BLD_ApartmentID = default(Guid);
		private Guid _Building_RefID = default(Guid);
		private Boolean _IsAppartment_ForRent = default(Boolean);
		private Guid _ApartmentSize_Unit_RefID = default(Guid);
		private Double _ApartmentSize_Value = default(Double);
		private Guid _TypeOfHeating_RefID = default(Guid);
		private Guid _TypeOfFlooring_RefID = default(Guid);
		private Guid _TypeOfWallCovering_RefID = default(Guid);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Boolean _IsDeleted = default(Boolean);
		private Guid _Tenant_RefID = default(Guid);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid RES_BLD_ApartmentID { 
			get {
				return _RES_BLD_ApartmentID;
			}
			set {
				if(_RES_BLD_ApartmentID != value){
					_RES_BLD_ApartmentID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Building_RefID { 
			get {
				return _Building_RefID;
			}
			set {
				if(_Building_RefID != value){
					_Building_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsAppartment_ForRent { 
			get {
				return _IsAppartment_ForRent;
			}
			set {
				if(_IsAppartment_ForRent != value){
					_IsAppartment_ForRent = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid ApartmentSize_Unit_RefID { 
			get {
				return _ApartmentSize_Unit_RefID;
			}
			set {
				if(_ApartmentSize_Unit_RefID != value){
					_ApartmentSize_Unit_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Double ApartmentSize_Value { 
			get {
				return _ApartmentSize_Value;
			}
			set {
				if(_ApartmentSize_Value != value){
					_ApartmentSize_Value = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid TypeOfHeating_RefID { 
			get {
				return _TypeOfHeating_RefID;
			}
			set {
				if(_TypeOfHeating_RefID != value){
					_TypeOfHeating_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid TypeOfFlooring_RefID { 
			get {
				return _TypeOfFlooring_RefID;
			}
			set {
				if(_TypeOfFlooring_RefID != value){
					_TypeOfFlooring_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid TypeOfWallCovering_RefID { 
			get {
				return _TypeOfWallCovering_RefID;
			}
			set {
				if(_TypeOfWallCovering_RefID != value){
					_TypeOfWallCovering_RefID = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_RES_BLD.RES_BLD_Apartment.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_RES_BLD.RES_BLD_Apartment.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "RES_BLD_ApartmentID", _RES_BLD_ApartmentID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Building_RefID", _Building_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsAppartment_ForRent", _IsAppartment_ForRent);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ApartmentSize_Unit_RefID", _ApartmentSize_Unit_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ApartmentSize_Value", _ApartmentSize_Value);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "TypeOfHeating_RefID", _TypeOfHeating_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "TypeOfFlooring_RefID", _TypeOfFlooring_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "TypeOfWallCovering_RefID", _TypeOfWallCovering_RefID);
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
						throw ex;
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

				throw ex;
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_RES_BLD.RES_BLD_Apartment.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_RES_BLD_ApartmentID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"RES_BLD_ApartmentID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "RES_BLD_ApartmentID","Building_RefID","IsAppartment_ForRent","ApartmentSize_Unit_RefID","ApartmentSize_Value","TypeOfHeating_RefID","TypeOfFlooring_RefID","TypeOfWallCovering_RefID","Creation_Timestamp","IsDeleted","Tenant_RefID" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter RES_BLD_ApartmentID of type Guid
						_RES_BLD_ApartmentID = reader.GetGuid(0);
						//1:Parameter Building_RefID of type Guid
						_Building_RefID = reader.GetGuid(1);
						//2:Parameter IsAppartment_ForRent of type Boolean
						_IsAppartment_ForRent = reader.GetBoolean(2);
						//3:Parameter ApartmentSize_Unit_RefID of type Guid
						_ApartmentSize_Unit_RefID = reader.GetGuid(3);
						//4:Parameter ApartmentSize_Value of type Double
						_ApartmentSize_Value = reader.GetDouble(4);
						//5:Parameter TypeOfHeating_RefID of type Guid
						_TypeOfHeating_RefID = reader.GetGuid(5);
						//6:Parameter TypeOfFlooring_RefID of type Guid
						_TypeOfFlooring_RefID = reader.GetGuid(6);
						//7:Parameter TypeOfWallCovering_RefID of type Guid
						_TypeOfWallCovering_RefID = reader.GetGuid(7);
						//8:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(8);
						//9:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(9);
						//10:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(10);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_RES_BLD_ApartmentID != Guid.Empty){
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
					throw ex;
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

				throw ex;
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
			public Guid? RES_BLD_ApartmentID {	get; set; }
			public Guid? Building_RefID {	get; set; }
			public Boolean? IsAppartment_ForRent {	get; set; }
			public Guid? ApartmentSize_Unit_RefID {	get; set; }
			public Double? ApartmentSize_Value {	get; set; }
			public Guid? TypeOfHeating_RefID {	get; set; }
			public Guid? TypeOfFlooring_RefID {	get; set; }
			public Guid? TypeOfWallCovering_RefID {	get; set; }
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
					throw ex;
				}
			}
			#endregion

			#region Search
			public static List<ORM_RES_BLD_Apartment> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_RES_BLD_Apartment> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_RES_BLD_Apartment> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_RES_BLD_Apartment> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_RES_BLD_Apartment> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_RES_BLD_Apartment>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "RES_BLD_ApartmentID","Building_RefID","IsAppartment_ForRent","ApartmentSize_Unit_RefID","ApartmentSize_Value","TypeOfHeating_RefID","TypeOfFlooring_RefID","TypeOfWallCovering_RefID","Creation_Timestamp","IsDeleted","Tenant_RefID" });
			        while (reader.Read())
			        {
			            ORM_RES_BLD_Apartment item = new ORM_RES_BLD_Apartment();
						//0:Parameter RES_BLD_ApartmentID of type Guid
						item.RES_BLD_ApartmentID = reader.GetGuid(0);
						//1:Parameter Building_RefID of type Guid
						item.Building_RefID = reader.GetGuid(1);
						//2:Parameter IsAppartment_ForRent of type Boolean
						item.IsAppartment_ForRent = reader.GetBoolean(2);
						//3:Parameter ApartmentSize_Unit_RefID of type Guid
						item.ApartmentSize_Unit_RefID = reader.GetGuid(3);
						//4:Parameter ApartmentSize_Value of type Double
						item.ApartmentSize_Value = reader.GetDouble(4);
						//5:Parameter TypeOfHeating_RefID of type Guid
						item.TypeOfHeating_RefID = reader.GetGuid(5);
						//6:Parameter TypeOfFlooring_RefID of type Guid
						item.TypeOfFlooring_RefID = reader.GetGuid(6);
						//7:Parameter TypeOfWallCovering_RefID of type Guid
						item.TypeOfWallCovering_RefID = reader.GetGuid(7);
						//8:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(8);
						//9:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(9);
						//10:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(10);


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
			        throw ex;
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
					throw ex;
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
					throw ex;
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
					throw ex;
				}
			}
			#endregion			
		}
		#endregion
	}	
}
