/* 
 * Generated on 8/21/2013 2:16:03 PM
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
	public class ORM_RES_RealestateProperty
	{
		public static readonly string TableName = "res_realestateproperties";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_RES_RealestateProperty()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_RES_RealestatePropertyID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _RES_RealestatePropertyID = default(Guid);
		private String _RealestateProperty_Title = default(String);
		private String _RealestateProperty_InternalID = default(String);
		private Guid _InformationSubmittedBy_Account_RefID = default(Guid);
		private Guid _RealestateProperty_Address_RefID = default(Guid);
		private Guid _RealestateProperty_Location_RefID = default(Guid);
		private Guid _RealestateProperty_GroundValuePrice_RefID = default(Guid);
		private Guid _RealestateProperty_AverageAreaRentPrice_RefID = default(Guid);
		private DateTime _RealestateProperty_ConstructionDate = default(DateTime);
		private DateTime _RealestateProperty_RefurbishmentDate = default(DateTime);
		private DateTime _RealestateProperty_InformationDate = default(DateTime);
		private double _RealestateProperty_LivingSpace_in_sqm = default(double);
		private int _RealestateProperty_NumberOfResidentialUnits = default(int);
		private double _RealestateProperty_GroundAreaSize_in_sqm = default(double);
		private double _Geolocation_Lattitude = default(double);
		private double _Geolocation_Longitude = default(double);
		private DateTime _Creation_Timestamp = default(DateTime);
		private bool _IsLocked = default(bool);
		private bool _IsArchived = default(bool);
		private Boolean _IsDeleted = default(Boolean);
		private Guid _Tenant_RefID = default(Guid);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid RES_RealestatePropertyID { 
			get {
				return _RES_RealestatePropertyID;
			}
			set {
				if(_RES_RealestatePropertyID != value){
					_RES_RealestatePropertyID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String RealestateProperty_Title { 
			get {
				return _RealestateProperty_Title;
			}
			set {
				if(_RealestateProperty_Title != value){
					_RealestateProperty_Title = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String RealestateProperty_InternalID { 
			get {
				return _RealestateProperty_InternalID;
			}
			set {
				if(_RealestateProperty_InternalID != value){
					_RealestateProperty_InternalID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid InformationSubmittedBy_Account_RefID { 
			get {
				return _InformationSubmittedBy_Account_RefID;
			}
			set {
				if(_InformationSubmittedBy_Account_RefID != value){
					_InformationSubmittedBy_Account_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid RealestateProperty_Address_RefID { 
			get {
				return _RealestateProperty_Address_RefID;
			}
			set {
				if(_RealestateProperty_Address_RefID != value){
					_RealestateProperty_Address_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid RealestateProperty_Location_RefID { 
			get {
				return _RealestateProperty_Location_RefID;
			}
			set {
				if(_RealestateProperty_Location_RefID != value){
					_RealestateProperty_Location_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid RealestateProperty_GroundValuePrice_RefID { 
			get {
				return _RealestateProperty_GroundValuePrice_RefID;
			}
			set {
				if(_RealestateProperty_GroundValuePrice_RefID != value){
					_RealestateProperty_GroundValuePrice_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid RealestateProperty_AverageAreaRentPrice_RefID { 
			get {
				return _RealestateProperty_AverageAreaRentPrice_RefID;
			}
			set {
				if(_RealestateProperty_AverageAreaRentPrice_RefID != value){
					_RealestateProperty_AverageAreaRentPrice_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime RealestateProperty_ConstructionDate { 
			get {
				return _RealestateProperty_ConstructionDate;
			}
			set {
				if(_RealestateProperty_ConstructionDate != value){
					_RealestateProperty_ConstructionDate = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime RealestateProperty_RefurbishmentDate { 
			get {
				return _RealestateProperty_RefurbishmentDate;
			}
			set {
				if(_RealestateProperty_RefurbishmentDate != value){
					_RealestateProperty_RefurbishmentDate = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime RealestateProperty_InformationDate { 
			get {
				return _RealestateProperty_InformationDate;
			}
			set {
				if(_RealestateProperty_InformationDate != value){
					_RealestateProperty_InformationDate = value;
					Status_IsDirty = true;
				}
			}
		} 
		public double RealestateProperty_LivingSpace_in_sqm { 
			get {
				return _RealestateProperty_LivingSpace_in_sqm;
			}
			set {
				if(_RealestateProperty_LivingSpace_in_sqm != value){
					_RealestateProperty_LivingSpace_in_sqm = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int RealestateProperty_NumberOfResidentialUnits { 
			get {
				return _RealestateProperty_NumberOfResidentialUnits;
			}
			set {
				if(_RealestateProperty_NumberOfResidentialUnits != value){
					_RealestateProperty_NumberOfResidentialUnits = value;
					Status_IsDirty = true;
				}
			}
		} 
		public double RealestateProperty_GroundAreaSize_in_sqm { 
			get {
				return _RealestateProperty_GroundAreaSize_in_sqm;
			}
			set {
				if(_RealestateProperty_GroundAreaSize_in_sqm != value){
					_RealestateProperty_GroundAreaSize_in_sqm = value;
					Status_IsDirty = true;
				}
			}
		} 
		public double Geolocation_Lattitude { 
			get {
				return _Geolocation_Lattitude;
			}
			set {
				if(_Geolocation_Lattitude != value){
					_Geolocation_Lattitude = value;
					Status_IsDirty = true;
				}
			}
		} 
		public double Geolocation_Longitude { 
			get {
				return _Geolocation_Longitude;
			}
			set {
				if(_Geolocation_Longitude != value){
					_Geolocation_Longitude = value;
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
		public bool IsLocked { 
			get {
				return _IsLocked;
			}
			set {
				if(_IsLocked != value){
					_IsLocked = value;
					Status_IsDirty = true;
				}
			}
		} 
		public bool IsArchived { 
			get {
				return _IsArchived;
			}
			set {
				if(_IsArchived != value){
					_IsArchived = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_RES.RES_RealestateProperty.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_RES.RES_RealestateProperty.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "RES_RealestatePropertyID", _RES_RealestatePropertyID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "RealestateProperty_Title", _RealestateProperty_Title);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "RealestateProperty_InternalID", _RealestateProperty_InternalID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "InformationSubmittedBy_Account_RefID", _InformationSubmittedBy_Account_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "RealestateProperty_Address_RefID", _RealestateProperty_Address_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "RealestateProperty_Location_RefID", _RealestateProperty_Location_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "RealestateProperty_GroundValuePrice_RefID", _RealestateProperty_GroundValuePrice_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "RealestateProperty_AverageAreaRentPrice_RefID", _RealestateProperty_AverageAreaRentPrice_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "RealestateProperty_ConstructionDate", _RealestateProperty_ConstructionDate);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "RealestateProperty_RefurbishmentDate", _RealestateProperty_RefurbishmentDate);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "RealestateProperty_InformationDate", _RealestateProperty_InformationDate);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "RealestateProperty_LivingSpace_in_sqm", _RealestateProperty_LivingSpace_in_sqm);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "RealestateProperty_NumberOfResidentialUnits", _RealestateProperty_NumberOfResidentialUnits);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "RealestateProperty_GroundAreaSize_in_sqm", _RealestateProperty_GroundAreaSize_in_sqm);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Geolocation_Lattitude", _Geolocation_Lattitude);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Geolocation_Longitude", _Geolocation_Longitude);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Creation_Timestamp", _Creation_Timestamp);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsLocked", _IsLocked);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsArchived", _IsArchived);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_RES.RES_RealestateProperty.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_RES_RealestatePropertyID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"RES_RealestatePropertyID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "RES_RealestatePropertyID","RealestateProperty_Title","RealestateProperty_InternalID","InformationSubmittedBy_Account_RefID","RealestateProperty_Address_RefID","RealestateProperty_Location_RefID","RealestateProperty_GroundValuePrice_RefID","RealestateProperty_AverageAreaRentPrice_RefID","RealestateProperty_ConstructionDate","RealestateProperty_RefurbishmentDate","RealestateProperty_InformationDate","RealestateProperty_LivingSpace_in_sqm","RealestateProperty_NumberOfResidentialUnits","RealestateProperty_GroundAreaSize_in_sqm","Geolocation_Lattitude","Geolocation_Longitude","Creation_Timestamp","IsLocked","IsArchived","IsDeleted","Tenant_RefID" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter RES_RealestatePropertyID of type Guid
						_RES_RealestatePropertyID = reader.GetGuid(0);
						//1:Parameter RealestateProperty_Title of type String
						_RealestateProperty_Title = reader.GetString(1);
						//2:Parameter RealestateProperty_InternalID of type String
						_RealestateProperty_InternalID = reader.GetString(2);
						//3:Parameter InformationSubmittedBy_Account_RefID of type Guid
						_InformationSubmittedBy_Account_RefID = reader.GetGuid(3);
						//4:Parameter RealestateProperty_Address_RefID of type Guid
						_RealestateProperty_Address_RefID = reader.GetGuid(4);
						//5:Parameter RealestateProperty_Location_RefID of type Guid
						_RealestateProperty_Location_RefID = reader.GetGuid(5);
						//6:Parameter RealestateProperty_GroundValuePrice_RefID of type Guid
						_RealestateProperty_GroundValuePrice_RefID = reader.GetGuid(6);
						//7:Parameter RealestateProperty_AverageAreaRentPrice_RefID of type Guid
						_RealestateProperty_AverageAreaRentPrice_RefID = reader.GetGuid(7);
						//8:Parameter RealestateProperty_ConstructionDate of type DateTime
						_RealestateProperty_ConstructionDate = reader.GetDate(8);
						//9:Parameter RealestateProperty_RefurbishmentDate of type DateTime
						_RealestateProperty_RefurbishmentDate = reader.GetDate(9);
						//10:Parameter RealestateProperty_InformationDate of type DateTime
						_RealestateProperty_InformationDate = reader.GetDate(10);
						//11:Parameter RealestateProperty_LivingSpace_in_sqm of type double
						_RealestateProperty_LivingSpace_in_sqm = reader.GetDouble(11);
						//12:Parameter RealestateProperty_NumberOfResidentialUnits of type int
						_RealestateProperty_NumberOfResidentialUnits = reader.GetInteger(12);
						//13:Parameter RealestateProperty_GroundAreaSize_in_sqm of type double
						_RealestateProperty_GroundAreaSize_in_sqm = reader.GetDouble(13);
						//14:Parameter Geolocation_Lattitude of type double
						_Geolocation_Lattitude = reader.GetDouble(14);
						//15:Parameter Geolocation_Longitude of type double
						_Geolocation_Longitude = reader.GetDouble(15);
						//16:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(16);
						//17:Parameter IsLocked of type bool
						_IsLocked = reader.GetBoolean(17);
						//18:Parameter IsArchived of type bool
						_IsArchived = reader.GetBoolean(18);
						//19:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(19);
						//20:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(20);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_RES_RealestatePropertyID != Guid.Empty){
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
			public Guid? RES_RealestatePropertyID {	get; set; }
			public String RealestateProperty_Title {	get; set; }
			public String RealestateProperty_InternalID {	get; set; }
			public Guid? InformationSubmittedBy_Account_RefID {	get; set; }
			public Guid? RealestateProperty_Address_RefID {	get; set; }
			public Guid? RealestateProperty_Location_RefID {	get; set; }
			public Guid? RealestateProperty_GroundValuePrice_RefID {	get; set; }
			public Guid? RealestateProperty_AverageAreaRentPrice_RefID {	get; set; }
			public DateTime? RealestateProperty_ConstructionDate {	get; set; }
			public DateTime? RealestateProperty_RefurbishmentDate {	get; set; }
			public DateTime? RealestateProperty_InformationDate {	get; set; }
			public double? RealestateProperty_LivingSpace_in_sqm {	get; set; }
			public int? RealestateProperty_NumberOfResidentialUnits {	get; set; }
			public double? RealestateProperty_GroundAreaSize_in_sqm {	get; set; }
			public double? Geolocation_Lattitude {	get; set; }
			public double? Geolocation_Longitude {	get; set; }
			public DateTime? Creation_Timestamp {	get; set; }
			public bool? IsLocked {	get; set; }
			public bool? IsArchived {	get; set; }
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
			public static List<ORM_RES_RealestateProperty> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_RES_RealestateProperty> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_RES_RealestateProperty> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_RES_RealestateProperty> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_RES_RealestateProperty> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_RES_RealestateProperty>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "RES_RealestatePropertyID","RealestateProperty_Title","RealestateProperty_InternalID","InformationSubmittedBy_Account_RefID","RealestateProperty_Address_RefID","RealestateProperty_Location_RefID","RealestateProperty_GroundValuePrice_RefID","RealestateProperty_AverageAreaRentPrice_RefID","RealestateProperty_ConstructionDate","RealestateProperty_RefurbishmentDate","RealestateProperty_InformationDate","RealestateProperty_LivingSpace_in_sqm","RealestateProperty_NumberOfResidentialUnits","RealestateProperty_GroundAreaSize_in_sqm","Geolocation_Lattitude","Geolocation_Longitude","Creation_Timestamp","IsLocked","IsArchived","IsDeleted","Tenant_RefID" });
			        while (reader.Read())
			        {
			            ORM_RES_RealestateProperty item = new ORM_RES_RealestateProperty();
						//0:Parameter RES_RealestatePropertyID of type Guid
						item.RES_RealestatePropertyID = reader.GetGuid(0);
						//1:Parameter RealestateProperty_Title of type String
						item.RealestateProperty_Title = reader.GetString(1);
						//2:Parameter RealestateProperty_InternalID of type String
						item.RealestateProperty_InternalID = reader.GetString(2);
						//3:Parameter InformationSubmittedBy_Account_RefID of type Guid
						item.InformationSubmittedBy_Account_RefID = reader.GetGuid(3);
						//4:Parameter RealestateProperty_Address_RefID of type Guid
						item.RealestateProperty_Address_RefID = reader.GetGuid(4);
						//5:Parameter RealestateProperty_Location_RefID of type Guid
						item.RealestateProperty_Location_RefID = reader.GetGuid(5);
						//6:Parameter RealestateProperty_GroundValuePrice_RefID of type Guid
						item.RealestateProperty_GroundValuePrice_RefID = reader.GetGuid(6);
						//7:Parameter RealestateProperty_AverageAreaRentPrice_RefID of type Guid
						item.RealestateProperty_AverageAreaRentPrice_RefID = reader.GetGuid(7);
						//8:Parameter RealestateProperty_ConstructionDate of type DateTime
						item.RealestateProperty_ConstructionDate = reader.GetDate(8);
						//9:Parameter RealestateProperty_RefurbishmentDate of type DateTime
						item.RealestateProperty_RefurbishmentDate = reader.GetDate(9);
						//10:Parameter RealestateProperty_InformationDate of type DateTime
						item.RealestateProperty_InformationDate = reader.GetDate(10);
						//11:Parameter RealestateProperty_LivingSpace_in_sqm of type double
						item.RealestateProperty_LivingSpace_in_sqm = reader.GetDouble(11);
						//12:Parameter RealestateProperty_NumberOfResidentialUnits of type int
						item.RealestateProperty_NumberOfResidentialUnits = reader.GetInteger(12);
						//13:Parameter RealestateProperty_GroundAreaSize_in_sqm of type double
						item.RealestateProperty_GroundAreaSize_in_sqm = reader.GetDouble(13);
						//14:Parameter Geolocation_Lattitude of type double
						item.Geolocation_Lattitude = reader.GetDouble(14);
						//15:Parameter Geolocation_Longitude of type double
						item.Geolocation_Longitude = reader.GetDouble(15);
						//16:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(16);
						//17:Parameter IsLocked of type bool
						item.IsLocked = reader.GetBoolean(17);
						//18:Parameter IsArchived of type bool
						item.IsArchived = reader.GetBoolean(18);
						//19:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(19);
						//20:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(20);


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
