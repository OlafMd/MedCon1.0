/* 
 * Generated on 20.02.2015 15:18:44
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_HEC_DIA_STA
{
	[Serializable]
	public class ORM_HEC_DIA_STA_Diagnosis_MedicationUsageStatistic
	{
		public static readonly string TableName = "hec_dia_sta_diagnosis_medicationusagestatistics";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_HEC_DIA_STA_Diagnosis_MedicationUsageStatistic()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_HEC_DIA_STA_Diagnosis_ProductUsageStatisticsID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _HEC_DIA_STA_Diagnosis_ProductUsageStatisticsID = default(Guid);
		private Boolean _IsHealthcareProduct = default(Boolean);
		private Guid _IfHealthcareProduct_HealthcareProduct_RefID = default(Guid);
		private Boolean _IsSubstance = default(Boolean);
		private Guid _IfSubstance_Substance_RefID = default(Guid);
		private String _IfSubstance_Strength = default(String);
		private String _DosageText = default(String);
		private Guid _PotentialDiagnosis_RefID = default(Guid);
		private int _NumberOfOccurences = default(int);
		private Boolean _IsStatistics_ForDoctor = default(Boolean);
		private Guid _IfStatistics_ForDoctor_Doctor_RefID = default(Guid);
		private Boolean _IsStatistics_ForHCG = default(Boolean);
		private Guid _IfStatistics_ForHCG_HealthcareCommunityGroup_RefID = default(Guid);
		private DateTime _StatisticsPeriod_From = default(DateTime);
		private DateTime _StatisticsPeriod_Through = default(DateTime);
		private Boolean _IsLatestStatisticsData = default(Boolean);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		private DateTime _Modification_Timestamp = default(DateTime);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid HEC_DIA_STA_Diagnosis_ProductUsageStatisticsID { 
			get {
				return _HEC_DIA_STA_Diagnosis_ProductUsageStatisticsID;
			}
			set {
				if(_HEC_DIA_STA_Diagnosis_ProductUsageStatisticsID != value){
					_HEC_DIA_STA_Diagnosis_ProductUsageStatisticsID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsHealthcareProduct { 
			get {
				return _IsHealthcareProduct;
			}
			set {
				if(_IsHealthcareProduct != value){
					_IsHealthcareProduct = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid IfHealthcareProduct_HealthcareProduct_RefID { 
			get {
				return _IfHealthcareProduct_HealthcareProduct_RefID;
			}
			set {
				if(_IfHealthcareProduct_HealthcareProduct_RefID != value){
					_IfHealthcareProduct_HealthcareProduct_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsSubstance { 
			get {
				return _IsSubstance;
			}
			set {
				if(_IsSubstance != value){
					_IsSubstance = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid IfSubstance_Substance_RefID { 
			get {
				return _IfSubstance_Substance_RefID;
			}
			set {
				if(_IfSubstance_Substance_RefID != value){
					_IfSubstance_Substance_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String IfSubstance_Strength { 
			get {
				return _IfSubstance_Strength;
			}
			set {
				if(_IfSubstance_Strength != value){
					_IfSubstance_Strength = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String DosageText { 
			get {
				return _DosageText;
			}
			set {
				if(_DosageText != value){
					_DosageText = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid PotentialDiagnosis_RefID { 
			get {
				return _PotentialDiagnosis_RefID;
			}
			set {
				if(_PotentialDiagnosis_RefID != value){
					_PotentialDiagnosis_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int NumberOfOccurences { 
			get {
				return _NumberOfOccurences;
			}
			set {
				if(_NumberOfOccurences != value){
					_NumberOfOccurences = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsStatistics_ForDoctor { 
			get {
				return _IsStatistics_ForDoctor;
			}
			set {
				if(_IsStatistics_ForDoctor != value){
					_IsStatistics_ForDoctor = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid IfStatistics_ForDoctor_Doctor_RefID { 
			get {
				return _IfStatistics_ForDoctor_Doctor_RefID;
			}
			set {
				if(_IfStatistics_ForDoctor_Doctor_RefID != value){
					_IfStatistics_ForDoctor_Doctor_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsStatistics_ForHCG { 
			get {
				return _IsStatistics_ForHCG;
			}
			set {
				if(_IsStatistics_ForHCG != value){
					_IsStatistics_ForHCG = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid IfStatistics_ForHCG_HealthcareCommunityGroup_RefID { 
			get {
				return _IfStatistics_ForHCG_HealthcareCommunityGroup_RefID;
			}
			set {
				if(_IfStatistics_ForHCG_HealthcareCommunityGroup_RefID != value){
					_IfStatistics_ForHCG_HealthcareCommunityGroup_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime StatisticsPeriod_From { 
			get {
				return _StatisticsPeriod_From;
			}
			set {
				if(_StatisticsPeriod_From != value){
					_StatisticsPeriod_From = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime StatisticsPeriod_Through { 
			get {
				return _StatisticsPeriod_Through;
			}
			set {
				if(_StatisticsPeriod_Through != value){
					_StatisticsPeriod_Through = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsLatestStatisticsData { 
			get {
				return _IsLatestStatisticsData;
			}
			set {
				if(_IsLatestStatisticsData != value){
					_IsLatestStatisticsData = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC_DIA_STA.HEC_DIA_STA_Diagnosis_MedicationUsageStatistic.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC_DIA_STA.HEC_DIA_STA_Diagnosis_MedicationUsageStatistic.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "HEC_DIA_STA_Diagnosis_ProductUsageStatisticsID", _HEC_DIA_STA_Diagnosis_ProductUsageStatisticsID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsHealthcareProduct", _IsHealthcareProduct);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfHealthcareProduct_HealthcareProduct_RefID", _IfHealthcareProduct_HealthcareProduct_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsSubstance", _IsSubstance);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfSubstance_Substance_RefID", _IfSubstance_Substance_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfSubstance_Strength", _IfSubstance_Strength);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "DosageText", _DosageText);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "PotentialDiagnosis_RefID", _PotentialDiagnosis_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "NumberOfOccurences", _NumberOfOccurences);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsStatistics_ForDoctor", _IsStatistics_ForDoctor);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfStatistics_ForDoctor_Doctor_RefID", _IfStatistics_ForDoctor_Doctor_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsStatistics_ForHCG", _IsStatistics_ForHCG);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfStatistics_ForHCG_HealthcareCommunityGroup_RefID", _IfStatistics_ForHCG_HealthcareCommunityGroup_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "StatisticsPeriod_From", _StatisticsPeriod_From);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "StatisticsPeriod_Through", _StatisticsPeriod_Through);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsLatestStatisticsData", _IsLatestStatisticsData);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC_DIA_STA.HEC_DIA_STA_Diagnosis_MedicationUsageStatistic.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_HEC_DIA_STA_Diagnosis_ProductUsageStatisticsID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"HEC_DIA_STA_Diagnosis_ProductUsageStatisticsID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "HEC_DIA_STA_Diagnosis_ProductUsageStatisticsID","IsHealthcareProduct","IfHealthcareProduct_HealthcareProduct_RefID","IsSubstance","IfSubstance_Substance_RefID","IfSubstance_Strength","DosageText","PotentialDiagnosis_RefID","NumberOfOccurences","IsStatistics_ForDoctor","IfStatistics_ForDoctor_Doctor_RefID","IsStatistics_ForHCG","IfStatistics_ForHCG_HealthcareCommunityGroup_RefID","StatisticsPeriod_From","StatisticsPeriod_Through","IsLatestStatisticsData","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter HEC_DIA_STA_Diagnosis_ProductUsageStatisticsID of type Guid
						_HEC_DIA_STA_Diagnosis_ProductUsageStatisticsID = reader.GetGuid(0);
						//1:Parameter IsHealthcareProduct of type Boolean
						_IsHealthcareProduct = reader.GetBoolean(1);
						//2:Parameter IfHealthcareProduct_HealthcareProduct_RefID of type Guid
						_IfHealthcareProduct_HealthcareProduct_RefID = reader.GetGuid(2);
						//3:Parameter IsSubstance of type Boolean
						_IsSubstance = reader.GetBoolean(3);
						//4:Parameter IfSubstance_Substance_RefID of type Guid
						_IfSubstance_Substance_RefID = reader.GetGuid(4);
						//5:Parameter IfSubstance_Strength of type String
						_IfSubstance_Strength = reader.GetString(5);
						//6:Parameter DosageText of type String
						_DosageText = reader.GetString(6);
						//7:Parameter PotentialDiagnosis_RefID of type Guid
						_PotentialDiagnosis_RefID = reader.GetGuid(7);
						//8:Parameter NumberOfOccurences of type int
						_NumberOfOccurences = reader.GetInteger(8);
						//9:Parameter IsStatistics_ForDoctor of type Boolean
						_IsStatistics_ForDoctor = reader.GetBoolean(9);
						//10:Parameter IfStatistics_ForDoctor_Doctor_RefID of type Guid
						_IfStatistics_ForDoctor_Doctor_RefID = reader.GetGuid(10);
						//11:Parameter IsStatistics_ForHCG of type Boolean
						_IsStatistics_ForHCG = reader.GetBoolean(11);
						//12:Parameter IfStatistics_ForHCG_HealthcareCommunityGroup_RefID of type Guid
						_IfStatistics_ForHCG_HealthcareCommunityGroup_RefID = reader.GetGuid(12);
						//13:Parameter StatisticsPeriod_From of type DateTime
						_StatisticsPeriod_From = reader.GetDate(13);
						//14:Parameter StatisticsPeriod_Through of type DateTime
						_StatisticsPeriod_Through = reader.GetDate(14);
						//15:Parameter IsLatestStatisticsData of type Boolean
						_IsLatestStatisticsData = reader.GetBoolean(15);
						//16:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(16);
						//17:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(17);
						//18:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(18);
						//19:Parameter Modification_Timestamp of type DateTime
						_Modification_Timestamp = reader.GetDate(19);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_HEC_DIA_STA_Diagnosis_ProductUsageStatisticsID != Guid.Empty){
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
			public Guid? HEC_DIA_STA_Diagnosis_ProductUsageStatisticsID {	get; set; }
			public Boolean? IsHealthcareProduct {	get; set; }
			public Guid? IfHealthcareProduct_HealthcareProduct_RefID {	get; set; }
			public Boolean? IsSubstance {	get; set; }
			public Guid? IfSubstance_Substance_RefID {	get; set; }
			public String IfSubstance_Strength {	get; set; }
			public String DosageText {	get; set; }
			public Guid? PotentialDiagnosis_RefID {	get; set; }
			public int? NumberOfOccurences {	get; set; }
			public Boolean? IsStatistics_ForDoctor {	get; set; }
			public Guid? IfStatistics_ForDoctor_Doctor_RefID {	get; set; }
			public Boolean? IsStatistics_ForHCG {	get; set; }
			public Guid? IfStatistics_ForHCG_HealthcareCommunityGroup_RefID {	get; set; }
			public DateTime? StatisticsPeriod_From {	get; set; }
			public DateTime? StatisticsPeriod_Through {	get; set; }
			public Boolean? IsLatestStatisticsData {	get; set; }
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
			public static List<ORM_HEC_DIA_STA_Diagnosis_MedicationUsageStatistic> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_HEC_DIA_STA_Diagnosis_MedicationUsageStatistic> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_HEC_DIA_STA_Diagnosis_MedicationUsageStatistic> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_HEC_DIA_STA_Diagnosis_MedicationUsageStatistic> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_HEC_DIA_STA_Diagnosis_MedicationUsageStatistic> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_HEC_DIA_STA_Diagnosis_MedicationUsageStatistic>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "HEC_DIA_STA_Diagnosis_ProductUsageStatisticsID","IsHealthcareProduct","IfHealthcareProduct_HealthcareProduct_RefID","IsSubstance","IfSubstance_Substance_RefID","IfSubstance_Strength","DosageText","PotentialDiagnosis_RefID","NumberOfOccurences","IsStatistics_ForDoctor","IfStatistics_ForDoctor_Doctor_RefID","IsStatistics_ForHCG","IfStatistics_ForHCG_HealthcareCommunityGroup_RefID","StatisticsPeriod_From","StatisticsPeriod_Through","IsLatestStatisticsData","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
			        while (reader.Read())
			        {
			            ORM_HEC_DIA_STA_Diagnosis_MedicationUsageStatistic item = new ORM_HEC_DIA_STA_Diagnosis_MedicationUsageStatistic();
						//0:Parameter HEC_DIA_STA_Diagnosis_ProductUsageStatisticsID of type Guid
						item.HEC_DIA_STA_Diagnosis_ProductUsageStatisticsID = reader.GetGuid(0);
						//1:Parameter IsHealthcareProduct of type Boolean
						item.IsHealthcareProduct = reader.GetBoolean(1);
						//2:Parameter IfHealthcareProduct_HealthcareProduct_RefID of type Guid
						item.IfHealthcareProduct_HealthcareProduct_RefID = reader.GetGuid(2);
						//3:Parameter IsSubstance of type Boolean
						item.IsSubstance = reader.GetBoolean(3);
						//4:Parameter IfSubstance_Substance_RefID of type Guid
						item.IfSubstance_Substance_RefID = reader.GetGuid(4);
						//5:Parameter IfSubstance_Strength of type String
						item.IfSubstance_Strength = reader.GetString(5);
						//6:Parameter DosageText of type String
						item.DosageText = reader.GetString(6);
						//7:Parameter PotentialDiagnosis_RefID of type Guid
						item.PotentialDiagnosis_RefID = reader.GetGuid(7);
						//8:Parameter NumberOfOccurences of type int
						item.NumberOfOccurences = reader.GetInteger(8);
						//9:Parameter IsStatistics_ForDoctor of type Boolean
						item.IsStatistics_ForDoctor = reader.GetBoolean(9);
						//10:Parameter IfStatistics_ForDoctor_Doctor_RefID of type Guid
						item.IfStatistics_ForDoctor_Doctor_RefID = reader.GetGuid(10);
						//11:Parameter IsStatistics_ForHCG of type Boolean
						item.IsStatistics_ForHCG = reader.GetBoolean(11);
						//12:Parameter IfStatistics_ForHCG_HealthcareCommunityGroup_RefID of type Guid
						item.IfStatistics_ForHCG_HealthcareCommunityGroup_RefID = reader.GetGuid(12);
						//13:Parameter StatisticsPeriod_From of type DateTime
						item.StatisticsPeriod_From = reader.GetDate(13);
						//14:Parameter StatisticsPeriod_Through of type DateTime
						item.StatisticsPeriod_Through = reader.GetDate(14);
						//15:Parameter IsLatestStatisticsData of type Boolean
						item.IsLatestStatisticsData = reader.GetBoolean(15);
						//16:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(16);
						//17:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(17);
						//18:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(18);
						//19:Parameter Modification_Timestamp of type DateTime
						item.Modification_Timestamp = reader.GetDate(19);


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
