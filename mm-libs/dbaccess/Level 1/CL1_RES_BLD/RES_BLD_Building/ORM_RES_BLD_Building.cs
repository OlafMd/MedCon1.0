/* 
 * Generated on 7/3/2013 11:03:29 AM
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
	public class ORM_RES_BLD_Building
	{
		public static readonly string TableName = "res_bld_buildings";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_RES_BLD_Building()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_RES_BLD_BuildingID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _RES_BLD_BuildingID = default(Guid);
		private Guid _Building_CurrentAverageRentPrice_per_sqm_RefID = default(Guid);
		private Guid _BuildingRevisionHeader_RefID = default(Guid);
		private double _Building_BalconyPortionPercent = default(double);
		private String _Building_Name = default(String);
		private Guid _Building_DocumentationStructure_RefID = default(Guid);
		private Boolean _IsContaminationSuspected = default(Boolean);
		private int _Building_NumberOfFloors = default(int);
		private double _Building_ElevatorCoveragePercent = default(double);
		private int _Building_NumberOfAppartments = default(int);
		private int _Building_NumberOfOccupiedAppartments = default(int);
		private int _Building_NumberOfOffices = default(int);
		private int _Building_NumberOfRetailUnits = default(int);
		private int _Building_NumberOfProductionUnits = default(int);
		private int _Building_NumberOfOtherUnits = default(int);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Boolean _IsDeleted = default(Boolean);
		private Guid _Tenant_RefID = default(Guid);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid RES_BLD_BuildingID { 
			get {
				return _RES_BLD_BuildingID;
			}
			set {
				if(_RES_BLD_BuildingID != value){
					_RES_BLD_BuildingID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Building_CurrentAverageRentPrice_per_sqm_RefID { 
			get {
				return _Building_CurrentAverageRentPrice_per_sqm_RefID;
			}
			set {
				if(_Building_CurrentAverageRentPrice_per_sqm_RefID != value){
					_Building_CurrentAverageRentPrice_per_sqm_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid BuildingRevisionHeader_RefID { 
			get {
				return _BuildingRevisionHeader_RefID;
			}
			set {
				if(_BuildingRevisionHeader_RefID != value){
					_BuildingRevisionHeader_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public double Building_BalconyPortionPercent { 
			get {
				return _Building_BalconyPortionPercent;
			}
			set {
				if(_Building_BalconyPortionPercent != value){
					_Building_BalconyPortionPercent = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String Building_Name { 
			get {
				return _Building_Name;
			}
			set {
				if(_Building_Name != value){
					_Building_Name = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Building_DocumentationStructure_RefID { 
			get {
				return _Building_DocumentationStructure_RefID;
			}
			set {
				if(_Building_DocumentationStructure_RefID != value){
					_Building_DocumentationStructure_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsContaminationSuspected { 
			get {
				return _IsContaminationSuspected;
			}
			set {
				if(_IsContaminationSuspected != value){
					_IsContaminationSuspected = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int Building_NumberOfFloors { 
			get {
				return _Building_NumberOfFloors;
			}
			set {
				if(_Building_NumberOfFloors != value){
					_Building_NumberOfFloors = value;
					Status_IsDirty = true;
				}
			}
		} 
		public double Building_ElevatorCoveragePercent { 
			get {
				return _Building_ElevatorCoveragePercent;
			}
			set {
				if(_Building_ElevatorCoveragePercent != value){
					_Building_ElevatorCoveragePercent = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int Building_NumberOfAppartments { 
			get {
				return _Building_NumberOfAppartments;
			}
			set {
				if(_Building_NumberOfAppartments != value){
					_Building_NumberOfAppartments = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int Building_NumberOfOccupiedAppartments { 
			get {
				return _Building_NumberOfOccupiedAppartments;
			}
			set {
				if(_Building_NumberOfOccupiedAppartments != value){
					_Building_NumberOfOccupiedAppartments = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int Building_NumberOfOffices { 
			get {
				return _Building_NumberOfOffices;
			}
			set {
				if(_Building_NumberOfOffices != value){
					_Building_NumberOfOffices = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int Building_NumberOfRetailUnits { 
			get {
				return _Building_NumberOfRetailUnits;
			}
			set {
				if(_Building_NumberOfRetailUnits != value){
					_Building_NumberOfRetailUnits = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int Building_NumberOfProductionUnits { 
			get {
				return _Building_NumberOfProductionUnits;
			}
			set {
				if(_Building_NumberOfProductionUnits != value){
					_Building_NumberOfProductionUnits = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int Building_NumberOfOtherUnits { 
			get {
				return _Building_NumberOfOtherUnits;
			}
			set {
				if(_Building_NumberOfOtherUnits != value){
					_Building_NumberOfOtherUnits = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_RES_BLD.RES_BLD_Building.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_RES_BLD.RES_BLD_Building.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "RES_BLD_BuildingID", _RES_BLD_BuildingID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Building_CurrentAverageRentPrice_per_sqm_RefID", _Building_CurrentAverageRentPrice_per_sqm_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "BuildingRevisionHeader_RefID", _BuildingRevisionHeader_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Building_BalconyPortionPercent", _Building_BalconyPortionPercent);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Building_Name", _Building_Name);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Building_DocumentationStructure_RefID", _Building_DocumentationStructure_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsContaminationSuspected", _IsContaminationSuspected);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Building_NumberOfFloors", _Building_NumberOfFloors);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Building_ElevatorCoveragePercent", _Building_ElevatorCoveragePercent);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Building_NumberOfAppartments", _Building_NumberOfAppartments);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Building_NumberOfOccupiedAppartments", _Building_NumberOfOccupiedAppartments);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Building_NumberOfOffices", _Building_NumberOfOffices);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Building_NumberOfRetailUnits", _Building_NumberOfRetailUnits);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Building_NumberOfProductionUnits", _Building_NumberOfProductionUnits);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Building_NumberOfOtherUnits", _Building_NumberOfOtherUnits);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_RES_BLD.RES_BLD_Building.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_RES_BLD_BuildingID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"RES_BLD_BuildingID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "RES_BLD_BuildingID","Building_CurrentAverageRentPrice_per_sqm_RefID","BuildingRevisionHeader_RefID","Building_BalconyPortionPercent","Building_Name","Building_DocumentationStructure_RefID","IsContaminationSuspected","Building_NumberOfFloors","Building_ElevatorCoveragePercent","Building_NumberOfAppartments","Building_NumberOfOccupiedAppartments","Building_NumberOfOffices","Building_NumberOfRetailUnits","Building_NumberOfProductionUnits","Building_NumberOfOtherUnits","Creation_Timestamp","IsDeleted","Tenant_RefID" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter RES_BLD_BuildingID of type Guid
						_RES_BLD_BuildingID = reader.GetGuid(0);
						//1:Parameter Building_CurrentAverageRentPrice_per_sqm_RefID of type Guid
						_Building_CurrentAverageRentPrice_per_sqm_RefID = reader.GetGuid(1);
						//2:Parameter BuildingRevisionHeader_RefID of type Guid
						_BuildingRevisionHeader_RefID = reader.GetGuid(2);
						//3:Parameter Building_BalconyPortionPercent of type double
						_Building_BalconyPortionPercent = reader.GetDouble(3);
						//4:Parameter Building_Name of type String
						_Building_Name = reader.GetString(4);
						//5:Parameter Building_DocumentationStructure_RefID of type Guid
						_Building_DocumentationStructure_RefID = reader.GetGuid(5);
						//6:Parameter IsContaminationSuspected of type Boolean
						_IsContaminationSuspected = reader.GetBoolean(6);
						//7:Parameter Building_NumberOfFloors of type int
						_Building_NumberOfFloors = reader.GetInteger(7);
						//8:Parameter Building_ElevatorCoveragePercent of type double
						_Building_ElevatorCoveragePercent = reader.GetDouble(8);
						//9:Parameter Building_NumberOfAppartments of type int
						_Building_NumberOfAppartments = reader.GetInteger(9);
						//10:Parameter Building_NumberOfOccupiedAppartments of type int
						_Building_NumberOfOccupiedAppartments = reader.GetInteger(10);
						//11:Parameter Building_NumberOfOffices of type int
						_Building_NumberOfOffices = reader.GetInteger(11);
						//12:Parameter Building_NumberOfRetailUnits of type int
						_Building_NumberOfRetailUnits = reader.GetInteger(12);
						//13:Parameter Building_NumberOfProductionUnits of type int
						_Building_NumberOfProductionUnits = reader.GetInteger(13);
						//14:Parameter Building_NumberOfOtherUnits of type int
						_Building_NumberOfOtherUnits = reader.GetInteger(14);
						//15:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(15);
						//16:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(16);
						//17:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(17);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_RES_BLD_BuildingID != Guid.Empty){
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
			public Guid? RES_BLD_BuildingID {	get; set; }
			public Guid? Building_CurrentAverageRentPrice_per_sqm_RefID {	get; set; }
			public Guid? BuildingRevisionHeader_RefID {	get; set; }
			public double? Building_BalconyPortionPercent {	get; set; }
			public String Building_Name {	get; set; }
			public Guid? Building_DocumentationStructure_RefID {	get; set; }
			public Boolean? IsContaminationSuspected {	get; set; }
			public int? Building_NumberOfFloors {	get; set; }
			public double? Building_ElevatorCoveragePercent {	get; set; }
			public int? Building_NumberOfAppartments {	get; set; }
			public int? Building_NumberOfOccupiedAppartments {	get; set; }
			public int? Building_NumberOfOffices {	get; set; }
			public int? Building_NumberOfRetailUnits {	get; set; }
			public int? Building_NumberOfProductionUnits {	get; set; }
			public int? Building_NumberOfOtherUnits {	get; set; }
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
			public static List<ORM_RES_BLD_Building> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_RES_BLD_Building> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_RES_BLD_Building> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_RES_BLD_Building> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_RES_BLD_Building> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_RES_BLD_Building>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "RES_BLD_BuildingID","Building_CurrentAverageRentPrice_per_sqm_RefID","BuildingRevisionHeader_RefID","Building_BalconyPortionPercent","Building_Name","Building_DocumentationStructure_RefID","IsContaminationSuspected","Building_NumberOfFloors","Building_ElevatorCoveragePercent","Building_NumberOfAppartments","Building_NumberOfOccupiedAppartments","Building_NumberOfOffices","Building_NumberOfRetailUnits","Building_NumberOfProductionUnits","Building_NumberOfOtherUnits","Creation_Timestamp","IsDeleted","Tenant_RefID" });
			        while (reader.Read())
			        {
			            ORM_RES_BLD_Building item = new ORM_RES_BLD_Building();
						//0:Parameter RES_BLD_BuildingID of type Guid
						item.RES_BLD_BuildingID = reader.GetGuid(0);
						//1:Parameter Building_CurrentAverageRentPrice_per_sqm_RefID of type Guid
						item.Building_CurrentAverageRentPrice_per_sqm_RefID = reader.GetGuid(1);
						//2:Parameter BuildingRevisionHeader_RefID of type Guid
						item.BuildingRevisionHeader_RefID = reader.GetGuid(2);
						//3:Parameter Building_BalconyPortionPercent of type double
						item.Building_BalconyPortionPercent = reader.GetDouble(3);
						//4:Parameter Building_Name of type String
						item.Building_Name = reader.GetString(4);
						//5:Parameter Building_DocumentationStructure_RefID of type Guid
						item.Building_DocumentationStructure_RefID = reader.GetGuid(5);
						//6:Parameter IsContaminationSuspected of type Boolean
						item.IsContaminationSuspected = reader.GetBoolean(6);
						//7:Parameter Building_NumberOfFloors of type int
						item.Building_NumberOfFloors = reader.GetInteger(7);
						//8:Parameter Building_ElevatorCoveragePercent of type double
						item.Building_ElevatorCoveragePercent = reader.GetDouble(8);
						//9:Parameter Building_NumberOfAppartments of type int
						item.Building_NumberOfAppartments = reader.GetInteger(9);
						//10:Parameter Building_NumberOfOccupiedAppartments of type int
						item.Building_NumberOfOccupiedAppartments = reader.GetInteger(10);
						//11:Parameter Building_NumberOfOffices of type int
						item.Building_NumberOfOffices = reader.GetInteger(11);
						//12:Parameter Building_NumberOfRetailUnits of type int
						item.Building_NumberOfRetailUnits = reader.GetInteger(12);
						//13:Parameter Building_NumberOfProductionUnits of type int
						item.Building_NumberOfProductionUnits = reader.GetInteger(13);
						//14:Parameter Building_NumberOfOtherUnits of type int
						item.Building_NumberOfOtherUnits = reader.GetInteger(14);
						//15:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(15);
						//16:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(16);
						//17:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(17);


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
