/* 
 * Generated on 12/23/2014 4:40:45 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_CMN
{
	[Serializable]
	public class ORM_CMN_Address
	{
		public static readonly string TableName = "cmn_addresses";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_CMN_Address()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_CMN_AddressID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _CMN_AddressID = default(Guid);
		private String _Street_Name = default(String);
		private String _Street_Number = default(String);
		private String _City_AdministrativeDistrict = default(String);
		private String _City_Region = default(String);
		private String _City_Name = default(String);
		private String _City_PostalCode = default(String);
		private String _Province_Name = default(String);
		private String _Country_Name = default(String);
		private String _CareOf = default(String);
		private String _Country_ISOCode = default(String);
		private Guid _Province_EconomicRegion_RefID = default(Guid);
		private double _Lattitude = default(double);
		private double _Longitude = default(double);
		private String _POBox = default(String);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		private DateTime _Modification_Timestamp = default(DateTime);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid CMN_AddressID { 
			get {
				return _CMN_AddressID;
			}
			set {
				if(_CMN_AddressID != value){
					_CMN_AddressID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String Street_Name { 
			get {
				return _Street_Name;
			}
			set {
				if(_Street_Name != value){
					_Street_Name = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String Street_Number { 
			get {
				return _Street_Number;
			}
			set {
				if(_Street_Number != value){
					_Street_Number = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String City_AdministrativeDistrict { 
			get {
				return _City_AdministrativeDistrict;
			}
			set {
				if(_City_AdministrativeDistrict != value){
					_City_AdministrativeDistrict = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String City_Region { 
			get {
				return _City_Region;
			}
			set {
				if(_City_Region != value){
					_City_Region = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String City_Name { 
			get {
				return _City_Name;
			}
			set {
				if(_City_Name != value){
					_City_Name = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String City_PostalCode { 
			get {
				return _City_PostalCode;
			}
			set {
				if(_City_PostalCode != value){
					_City_PostalCode = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String Province_Name { 
			get {
				return _Province_Name;
			}
			set {
				if(_Province_Name != value){
					_Province_Name = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String Country_Name { 
			get {
				return _Country_Name;
			}
			set {
				if(_Country_Name != value){
					_Country_Name = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String CareOf { 
			get {
				return _CareOf;
			}
			set {
				if(_CareOf != value){
					_CareOf = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String Country_ISOCode { 
			get {
				return _Country_ISOCode;
			}
			set {
				if(_Country_ISOCode != value){
					_Country_ISOCode = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Province_EconomicRegion_RefID { 
			get {
				return _Province_EconomicRegion_RefID;
			}
			set {
				if(_Province_EconomicRegion_RefID != value){
					_Province_EconomicRegion_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public double Lattitude { 
			get {
				return _Lattitude;
			}
			set {
				if(_Lattitude != value){
					_Lattitude = value;
					Status_IsDirty = true;
				}
			}
		} 
		public double Longitude { 
			get {
				return _Longitude;
			}
			set {
				if(_Longitude != value){
					_Longitude = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String POBox { 
			get {
				return _POBox;
			}
			set {
				if(_POBox != value){
					_POBox = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN.CMN_Address.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN.CMN_Address.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_AddressID", _CMN_AddressID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Street_Name", _Street_Name);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Street_Number", _Street_Number);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "City_AdministrativeDistrict", _City_AdministrativeDistrict);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "City_Region", _City_Region);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "City_Name", _City_Name);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "City_PostalCode", _City_PostalCode);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Province_Name", _Province_Name);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Country_Name", _Country_Name);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CareOf", _CareOf);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Country_ISOCode", _Country_ISOCode);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Province_EconomicRegion_RefID", _Province_EconomicRegion_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Lattitude", _Lattitude);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Longitude", _Longitude);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "POBox", _POBox);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN.CMN_Address.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_CMN_AddressID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CMN_AddressID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_AddressID","Street_Name","Street_Number","City_AdministrativeDistrict","City_Region","City_Name","City_PostalCode","Province_Name","Country_Name","CareOf","Country_ISOCode","Province_EconomicRegion_RefID","Lattitude","Longitude","POBox","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter CMN_AddressID of type Guid
						_CMN_AddressID = reader.GetGuid(0);
						//1:Parameter Street_Name of type String
						_Street_Name = reader.GetString(1);
						//2:Parameter Street_Number of type String
						_Street_Number = reader.GetString(2);
						//3:Parameter City_AdministrativeDistrict of type String
						_City_AdministrativeDistrict = reader.GetString(3);
						//4:Parameter City_Region of type String
						_City_Region = reader.GetString(4);
						//5:Parameter City_Name of type String
						_City_Name = reader.GetString(5);
						//6:Parameter City_PostalCode of type String
						_City_PostalCode = reader.GetString(6);
						//7:Parameter Province_Name of type String
						_Province_Name = reader.GetString(7);
						//8:Parameter Country_Name of type String
						_Country_Name = reader.GetString(8);
						//9:Parameter CareOf of type String
						_CareOf = reader.GetString(9);
						//10:Parameter Country_ISOCode of type String
						_Country_ISOCode = reader.GetString(10);
						//11:Parameter Province_EconomicRegion_RefID of type Guid
						_Province_EconomicRegion_RefID = reader.GetGuid(11);
						//12:Parameter Lattitude of type double
						_Lattitude = reader.GetDouble(12);
						//13:Parameter Longitude of type double
						_Longitude = reader.GetDouble(13);
						//14:Parameter POBox of type String
						_POBox = reader.GetString(14);
						//15:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(15);
						//16:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(16);
						//17:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(17);
						//18:Parameter Modification_Timestamp of type DateTime
						_Modification_Timestamp = reader.GetDate(18);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_CMN_AddressID != Guid.Empty){
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
			public Guid? CMN_AddressID {	get; set; }
			public String Street_Name {	get; set; }
			public String Street_Number {	get; set; }
			public String City_AdministrativeDistrict {	get; set; }
			public String City_Region {	get; set; }
			public String City_Name {	get; set; }
			public String City_PostalCode {	get; set; }
			public String Province_Name {	get; set; }
			public String Country_Name {	get; set; }
			public String CareOf {	get; set; }
			public String Country_ISOCode {	get; set; }
			public Guid? Province_EconomicRegion_RefID {	get; set; }
			public double? Lattitude {	get; set; }
			public double? Longitude {	get; set; }
			public String POBox {	get; set; }
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
			public static List<ORM_CMN_Address> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_CMN_Address> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_CMN_Address> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_CMN_Address> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_CMN_Address> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_CMN_Address>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_AddressID","Street_Name","Street_Number","City_AdministrativeDistrict","City_Region","City_Name","City_PostalCode","Province_Name","Country_Name","CareOf","Country_ISOCode","Province_EconomicRegion_RefID","Lattitude","Longitude","POBox","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
			        while (reader.Read())
			        {
			            ORM_CMN_Address item = new ORM_CMN_Address();
						//0:Parameter CMN_AddressID of type Guid
						item.CMN_AddressID = reader.GetGuid(0);
						//1:Parameter Street_Name of type String
						item.Street_Name = reader.GetString(1);
						//2:Parameter Street_Number of type String
						item.Street_Number = reader.GetString(2);
						//3:Parameter City_AdministrativeDistrict of type String
						item.City_AdministrativeDistrict = reader.GetString(3);
						//4:Parameter City_Region of type String
						item.City_Region = reader.GetString(4);
						//5:Parameter City_Name of type String
						item.City_Name = reader.GetString(5);
						//6:Parameter City_PostalCode of type String
						item.City_PostalCode = reader.GetString(6);
						//7:Parameter Province_Name of type String
						item.Province_Name = reader.GetString(7);
						//8:Parameter Country_Name of type String
						item.Country_Name = reader.GetString(8);
						//9:Parameter CareOf of type String
						item.CareOf = reader.GetString(9);
						//10:Parameter Country_ISOCode of type String
						item.Country_ISOCode = reader.GetString(10);
						//11:Parameter Province_EconomicRegion_RefID of type Guid
						item.Province_EconomicRegion_RefID = reader.GetGuid(11);
						//12:Parameter Lattitude of type double
						item.Lattitude = reader.GetDouble(12);
						//13:Parameter Longitude of type double
						item.Longitude = reader.GetDouble(13);
						//14:Parameter POBox of type String
						item.POBox = reader.GetString(14);
						//15:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(15);
						//16:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(16);
						//17:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(17);
						//18:Parameter Modification_Timestamp of type DateTime
						item.Modification_Timestamp = reader.GetDate(18);


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
