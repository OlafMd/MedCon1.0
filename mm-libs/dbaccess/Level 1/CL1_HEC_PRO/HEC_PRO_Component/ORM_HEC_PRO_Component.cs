/* 
 * Generated on 2/12/2015 11:06:15 AM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_HEC_PRO
{
	[Serializable]
	public class ORM_HEC_PRO_Component
	{
		public static readonly string TableName = "hec_pro_components";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_HEC_PRO_Component()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_HEC_PRO_ComponentID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _HEC_PRO_ComponentID = default(Guid);
		private String _GlobalPropertyMatchingID = default(String);
		private int _ComponentMatterState = default(int);
		private Guid _AbsoluteCompositionValue_Unit_RefID = default(Guid);
		private Double _AbsoluteCompositionValue = default(Double);
		private Guid _RelativeCompositionValue_Unit_RefID = default(Guid);
		private Double _RelativeCompositionValue = default(Double);
		private Double _BreadUnitContainedAmount = default(Double);
		private Double _EthanolContained_VolumePercentage = default(Double);
		private Double _ComponentEneryValue_in_kJ = default(Double);
		private String _Component_SimpleName = default(String);
		private Dict _Component_Name = new Dict(TableName);
		private Dict _Component_Description = new Dict(TableName);
		private int _ComponentDisposalSpeedStatus = default(int);
		private int _GalenicalTypeInsidePackageStatus = default(int);
		private int _ComponentExcipientStatus = default(int);
		private String _GalenicalType_RelativeComposition = default(String);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		private DateTime _Modification_Timestamp = default(DateTime);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid HEC_PRO_ComponentID { 
			get {
				return _HEC_PRO_ComponentID;
			}
			set {
				if(_HEC_PRO_ComponentID != value){
					_HEC_PRO_ComponentID = value;
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
		public int ComponentMatterState { 
			get {
				return _ComponentMatterState;
			}
			set {
				if(_ComponentMatterState != value){
					_ComponentMatterState = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid AbsoluteCompositionValue_Unit_RefID { 
			get {
				return _AbsoluteCompositionValue_Unit_RefID;
			}
			set {
				if(_AbsoluteCompositionValue_Unit_RefID != value){
					_AbsoluteCompositionValue_Unit_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Double AbsoluteCompositionValue { 
			get {
				return _AbsoluteCompositionValue;
			}
			set {
				if(_AbsoluteCompositionValue != value){
					_AbsoluteCompositionValue = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid RelativeCompositionValue_Unit_RefID { 
			get {
				return _RelativeCompositionValue_Unit_RefID;
			}
			set {
				if(_RelativeCompositionValue_Unit_RefID != value){
					_RelativeCompositionValue_Unit_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Double RelativeCompositionValue { 
			get {
				return _RelativeCompositionValue;
			}
			set {
				if(_RelativeCompositionValue != value){
					_RelativeCompositionValue = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Double BreadUnitContainedAmount { 
			get {
				return _BreadUnitContainedAmount;
			}
			set {
				if(_BreadUnitContainedAmount != value){
					_BreadUnitContainedAmount = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Double EthanolContained_VolumePercentage { 
			get {
				return _EthanolContained_VolumePercentage;
			}
			set {
				if(_EthanolContained_VolumePercentage != value){
					_EthanolContained_VolumePercentage = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Double ComponentEneryValue_in_kJ { 
			get {
				return _ComponentEneryValue_in_kJ;
			}
			set {
				if(_ComponentEneryValue_in_kJ != value){
					_ComponentEneryValue_in_kJ = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String Component_SimpleName { 
			get {
				return _Component_SimpleName;
			}
			set {
				if(_Component_SimpleName != value){
					_Component_SimpleName = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Dict Component_Name { 
			get {
				return _Component_Name;
			}
			set {
				if(_Component_Name != value){
					_Component_Name = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Dict Component_Description { 
			get {
				return _Component_Description;
			}
			set {
				if(_Component_Description != value){
					_Component_Description = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int ComponentDisposalSpeedStatus { 
			get {
				return _ComponentDisposalSpeedStatus;
			}
			set {
				if(_ComponentDisposalSpeedStatus != value){
					_ComponentDisposalSpeedStatus = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int GalenicalTypeInsidePackageStatus { 
			get {
				return _GalenicalTypeInsidePackageStatus;
			}
			set {
				if(_GalenicalTypeInsidePackageStatus != value){
					_GalenicalTypeInsidePackageStatus = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int ComponentExcipientStatus { 
			get {
				return _ComponentExcipientStatus;
			}
			set {
				if(_ComponentExcipientStatus != value){
					_ComponentExcipientStatus = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String GalenicalType_RelativeComposition { 
			get {
				return _GalenicalType_RelativeComposition;
			}
			set {
				if(_GalenicalType_RelativeComposition != value){
					_GalenicalType_RelativeComposition = value;
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

				bool saveDictionary = !Status_IsAlreadySaved || Component_Name.IsDirty || Component_Description.IsDirty ;
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
								loader.Append(Component_Name,TableName);
								loader.Append(Component_Description,TableName);

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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC_PRO.HEC_PRO_Component.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC_PRO.HEC_PRO_Component.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "HEC_PRO_ComponentID", _HEC_PRO_ComponentID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "GlobalPropertyMatchingID", _GlobalPropertyMatchingID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ComponentMatterState", _ComponentMatterState);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "AbsoluteCompositionValue_Unit_RefID", _AbsoluteCompositionValue_Unit_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "AbsoluteCompositionValue", _AbsoluteCompositionValue);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "RelativeCompositionValue_Unit_RefID", _RelativeCompositionValue_Unit_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "RelativeCompositionValue", _RelativeCompositionValue);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "BreadUnitContainedAmount", _BreadUnitContainedAmount);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "EthanolContained_VolumePercentage", _EthanolContained_VolumePercentage);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ComponentEneryValue_in_kJ", _ComponentEneryValue_in_kJ);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Component_SimpleName", _Component_SimpleName);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Component_Name", _Component_Name.DictionaryID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Component_Description", _Component_Description.DictionaryID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ComponentDisposalSpeedStatus", _ComponentDisposalSpeedStatus);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "GalenicalTypeInsidePackageStatus", _GalenicalTypeInsidePackageStatus);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ComponentExcipientStatus", _ComponentExcipientStatus);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "GalenicalType_RelativeComposition", _GalenicalType_RelativeComposition);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC_PRO.HEC_PRO_Component.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_HEC_PRO_ComponentID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"HEC_PRO_ComponentID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "HEC_PRO_ComponentID","GlobalPropertyMatchingID","ComponentMatterState","AbsoluteCompositionValue_Unit_RefID","AbsoluteCompositionValue","RelativeCompositionValue_Unit_RefID","RelativeCompositionValue","BreadUnitContainedAmount","EthanolContained_VolumePercentage","ComponentEneryValue_in_kJ","Component_SimpleName","Component_Name_DictID","Component_Description_DictID","ComponentDisposalSpeedStatus","GalenicalTypeInsidePackageStatus","ComponentExcipientStatus","GalenicalType_RelativeComposition","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter HEC_PRO_ComponentID of type Guid
						_HEC_PRO_ComponentID = reader.GetGuid(0);
						//1:Parameter GlobalPropertyMatchingID of type String
						_GlobalPropertyMatchingID = reader.GetString(1);
						//2:Parameter ComponentMatterState of type int
						_ComponentMatterState = reader.GetInteger(2);
						//3:Parameter AbsoluteCompositionValue_Unit_RefID of type Guid
						_AbsoluteCompositionValue_Unit_RefID = reader.GetGuid(3);
						//4:Parameter AbsoluteCompositionValue of type Double
						_AbsoluteCompositionValue = reader.GetDouble(4);
						//5:Parameter RelativeCompositionValue_Unit_RefID of type Guid
						_RelativeCompositionValue_Unit_RefID = reader.GetGuid(5);
						//6:Parameter RelativeCompositionValue of type Double
						_RelativeCompositionValue = reader.GetDouble(6);
						//7:Parameter BreadUnitContainedAmount of type Double
						_BreadUnitContainedAmount = reader.GetDouble(7);
						//8:Parameter EthanolContained_VolumePercentage of type Double
						_EthanolContained_VolumePercentage = reader.GetDouble(8);
						//9:Parameter ComponentEneryValue_in_kJ of type Double
						_ComponentEneryValue_in_kJ = reader.GetDouble(9);
						//10:Parameter Component_SimpleName of type String
						_Component_SimpleName = reader.GetString(10);
						//11:Parameter Component_Name of type Dict
						_Component_Name = reader.GetDictionary(11);
						loader.Append(_Component_Name,TableName);
						//12:Parameter Component_Description of type Dict
						_Component_Description = reader.GetDictionary(12);
						loader.Append(_Component_Description,TableName);
						//13:Parameter ComponentDisposalSpeedStatus of type int
						_ComponentDisposalSpeedStatus = reader.GetInteger(13);
						//14:Parameter GalenicalTypeInsidePackageStatus of type int
						_GalenicalTypeInsidePackageStatus = reader.GetInteger(14);
						//15:Parameter ComponentExcipientStatus of type int
						_ComponentExcipientStatus = reader.GetInteger(15);
						//16:Parameter GalenicalType_RelativeComposition of type String
						_GalenicalType_RelativeComposition = reader.GetString(16);
						//17:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(17);
						//18:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(18);
						//19:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(19);
						//20:Parameter Modification_Timestamp of type DateTime
						_Modification_Timestamp = reader.GetDate(20);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_HEC_PRO_ComponentID != Guid.Empty){
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
			public Guid? HEC_PRO_ComponentID {	get; set; }
			public String GlobalPropertyMatchingID {	get; set; }
			public int? ComponentMatterState {	get; set; }
			public Guid? AbsoluteCompositionValue_Unit_RefID {	get; set; }
			public Double? AbsoluteCompositionValue {	get; set; }
			public Guid? RelativeCompositionValue_Unit_RefID {	get; set; }
			public Double? RelativeCompositionValue {	get; set; }
			public Double? BreadUnitContainedAmount {	get; set; }
			public Double? EthanolContained_VolumePercentage {	get; set; }
			public Double? ComponentEneryValue_in_kJ {	get; set; }
			public String Component_SimpleName {	get; set; }
			public Dict Component_Name {	get; set; }
			public Dict Component_Description {	get; set; }
			public int? ComponentDisposalSpeedStatus {	get; set; }
			public int? GalenicalTypeInsidePackageStatus {	get; set; }
			public int? ComponentExcipientStatus {	get; set; }
			public String GalenicalType_RelativeComposition {	get; set; }
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
					throw ex;
				}
			}
			#endregion

			#region Search
			public static List<ORM_HEC_PRO_Component> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_HEC_PRO_Component> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_HEC_PRO_Component> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_HEC_PRO_Component> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_HEC_PRO_Component> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_HEC_PRO_Component>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "HEC_PRO_ComponentID","GlobalPropertyMatchingID","ComponentMatterState","AbsoluteCompositionValue_Unit_RefID","AbsoluteCompositionValue","RelativeCompositionValue_Unit_RefID","RelativeCompositionValue","BreadUnitContainedAmount","EthanolContained_VolumePercentage","ComponentEneryValue_in_kJ","Component_SimpleName","Component_Name_DictID","Component_Description_DictID","ComponentDisposalSpeedStatus","GalenicalTypeInsidePackageStatus","ComponentExcipientStatus","GalenicalType_RelativeComposition","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
			        while (reader.Read())
			        {
			            ORM_HEC_PRO_Component item = new ORM_HEC_PRO_Component();
						//0:Parameter HEC_PRO_ComponentID of type Guid
						item.HEC_PRO_ComponentID = reader.GetGuid(0);
						//1:Parameter GlobalPropertyMatchingID of type String
						item.GlobalPropertyMatchingID = reader.GetString(1);
						//2:Parameter ComponentMatterState of type int
						item.ComponentMatterState = reader.GetInteger(2);
						//3:Parameter AbsoluteCompositionValue_Unit_RefID of type Guid
						item.AbsoluteCompositionValue_Unit_RefID = reader.GetGuid(3);
						//4:Parameter AbsoluteCompositionValue of type Double
						item.AbsoluteCompositionValue = reader.GetDouble(4);
						//5:Parameter RelativeCompositionValue_Unit_RefID of type Guid
						item.RelativeCompositionValue_Unit_RefID = reader.GetGuid(5);
						//6:Parameter RelativeCompositionValue of type Double
						item.RelativeCompositionValue = reader.GetDouble(6);
						//7:Parameter BreadUnitContainedAmount of type Double
						item.BreadUnitContainedAmount = reader.GetDouble(7);
						//8:Parameter EthanolContained_VolumePercentage of type Double
						item.EthanolContained_VolumePercentage = reader.GetDouble(8);
						//9:Parameter ComponentEneryValue_in_kJ of type Double
						item.ComponentEneryValue_in_kJ = reader.GetDouble(9);
						//10:Parameter Component_SimpleName of type String
						item.Component_SimpleName = reader.GetString(10);
						//11:Parameter Component_Name of type Dict
						item.Component_Name = reader.GetDictionary(11);
						loader.Append(item.Component_Name,TableName);
						//12:Parameter Component_Description of type Dict
						item.Component_Description = reader.GetDictionary(12);
						loader.Append(item.Component_Description,TableName);
						//13:Parameter ComponentDisposalSpeedStatus of type int
						item.ComponentDisposalSpeedStatus = reader.GetInteger(13);
						//14:Parameter GalenicalTypeInsidePackageStatus of type int
						item.GalenicalTypeInsidePackageStatus = reader.GetInteger(14);
						//15:Parameter ComponentExcipientStatus of type int
						item.ComponentExcipientStatus = reader.GetInteger(15);
						//16:Parameter GalenicalType_RelativeComposition of type String
						item.GalenicalType_RelativeComposition = reader.GetString(16);
						//17:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(17);
						//18:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(18);
						//19:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(19);
						//20:Parameter Modification_Timestamp of type DateTime
						item.Modification_Timestamp = reader.GetDate(20);


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
