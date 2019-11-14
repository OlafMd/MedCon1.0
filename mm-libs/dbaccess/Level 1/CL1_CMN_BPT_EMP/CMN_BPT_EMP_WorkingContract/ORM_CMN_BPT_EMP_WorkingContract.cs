/* 
 * Generated on 22-Oct-13 14:26:06
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;

namespace CL1_CMN_BPT_EMP
{
	[Serializable]
	public class ORM_CMN_BPT_EMP_WorkingContract
	{
		public static readonly string TableName = "cmn_bpt_emp_workingcontracts";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_CMN_BPT_EMP_WorkingContract()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_CMN_BPT_EMP_WorkingContractID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _CMN_BPT_EMP_WorkingContractID = default(Guid);
		private Guid _ExtraWorkCalculation_RefID = default(Guid);
		private Guid _WorkingContract_InCurrency_RefID = default(Guid);
		private DateTime _Contract_StartDate = default(DateTime);
		private DateTime _Contract_EndDate = default(DateTime);
		private Boolean _IsContractEndDateDefined = default(Boolean);
		private Boolean _IsWorkTimeCalculated_InHours = default(Boolean);
		private Boolean _IsWorkTimeCalculated_InDays = default(Boolean);
		private Double _R_WorkTime_DaysPerWeek = default(Double);
		private Double _R_WorkTime_HoursPerWeek = default(Double);
		private Boolean _IsWorktimeChecked_Weekly = default(Boolean);
		private Boolean _IsWorktimeChecked_Monthly = default(Boolean);
		private Boolean _SurchargeCalculation_UseMaximum = default(Boolean);
		private Boolean _SurchargeCalculation_UseAccumulated = default(Boolean);
		private Boolean _IsMealAllowanceProvided = default(Boolean);
		private String _WorkingContract_Comment = default(String);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Boolean _IsDeleted = default(Boolean);
		private Guid _Tenant_RefID = default(Guid);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid CMN_BPT_EMP_WorkingContractID { 
			get {
				return _CMN_BPT_EMP_WorkingContractID;
			}
			set {
				if(_CMN_BPT_EMP_WorkingContractID != value){
					_CMN_BPT_EMP_WorkingContractID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid ExtraWorkCalculation_RefID { 
			get {
				return _ExtraWorkCalculation_RefID;
			}
			set {
				if(_ExtraWorkCalculation_RefID != value){
					_ExtraWorkCalculation_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid WorkingContract_InCurrency_RefID { 
			get {
				return _WorkingContract_InCurrency_RefID;
			}
			set {
				if(_WorkingContract_InCurrency_RefID != value){
					_WorkingContract_InCurrency_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime Contract_StartDate { 
			get {
				return _Contract_StartDate;
			}
			set {
				if(_Contract_StartDate != value){
					_Contract_StartDate = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime Contract_EndDate { 
			get {
				return _Contract_EndDate;
			}
			set {
				if(_Contract_EndDate != value){
					_Contract_EndDate = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsContractEndDateDefined { 
			get {
				return _IsContractEndDateDefined;
			}
			set {
				if(_IsContractEndDateDefined != value){
					_IsContractEndDateDefined = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsWorkTimeCalculated_InHours { 
			get {
				return _IsWorkTimeCalculated_InHours;
			}
			set {
				if(_IsWorkTimeCalculated_InHours != value){
					_IsWorkTimeCalculated_InHours = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsWorkTimeCalculated_InDays { 
			get {
				return _IsWorkTimeCalculated_InDays;
			}
			set {
				if(_IsWorkTimeCalculated_InDays != value){
					_IsWorkTimeCalculated_InDays = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Double R_WorkTime_DaysPerWeek { 
			get {
				return _R_WorkTime_DaysPerWeek;
			}
			set {
				if(_R_WorkTime_DaysPerWeek != value){
					_R_WorkTime_DaysPerWeek = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Double R_WorkTime_HoursPerWeek { 
			get {
				return _R_WorkTime_HoursPerWeek;
			}
			set {
				if(_R_WorkTime_HoursPerWeek != value){
					_R_WorkTime_HoursPerWeek = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsWorktimeChecked_Weekly { 
			get {
				return _IsWorktimeChecked_Weekly;
			}
			set {
				if(_IsWorktimeChecked_Weekly != value){
					_IsWorktimeChecked_Weekly = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsWorktimeChecked_Monthly { 
			get {
				return _IsWorktimeChecked_Monthly;
			}
			set {
				if(_IsWorktimeChecked_Monthly != value){
					_IsWorktimeChecked_Monthly = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean SurchargeCalculation_UseMaximum { 
			get {
				return _SurchargeCalculation_UseMaximum;
			}
			set {
				if(_SurchargeCalculation_UseMaximum != value){
					_SurchargeCalculation_UseMaximum = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean SurchargeCalculation_UseAccumulated { 
			get {
				return _SurchargeCalculation_UseAccumulated;
			}
			set {
				if(_SurchargeCalculation_UseAccumulated != value){
					_SurchargeCalculation_UseAccumulated = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsMealAllowanceProvided { 
			get {
				return _IsMealAllowanceProvided;
			}
			set {
				if(_IsMealAllowanceProvided != value){
					_IsMealAllowanceProvided = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String WorkingContract_Comment { 
			get {
				return _WorkingContract_Comment;
			}
			set {
				if(_WorkingContract_Comment != value){
					_WorkingContract_Comment = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_BPT_EMP.CMN_BPT_EMP_WorkingContract.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_BPT_EMP.CMN_BPT_EMP_WorkingContract.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_BPT_EMP_WorkingContractID", _CMN_BPT_EMP_WorkingContractID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ExtraWorkCalculation_RefID", _ExtraWorkCalculation_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "WorkingContract_InCurrency_RefID", _WorkingContract_InCurrency_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Contract_StartDate", _Contract_StartDate);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Contract_EndDate", _Contract_EndDate);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsContractEndDateDefined", _IsContractEndDateDefined);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsWorkTimeCalculated_InHours", _IsWorkTimeCalculated_InHours);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsWorkTimeCalculated_InDays", _IsWorkTimeCalculated_InDays);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "R_WorkTime_DaysPerWeek", _R_WorkTime_DaysPerWeek);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "R_WorkTime_HoursPerWeek", _R_WorkTime_HoursPerWeek);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsWorktimeChecked_Weekly", _IsWorktimeChecked_Weekly);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsWorktimeChecked_Monthly", _IsWorktimeChecked_Monthly);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "SurchargeCalculation_UseMaximum", _SurchargeCalculation_UseMaximum);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "SurchargeCalculation_UseAccumulated", _SurchargeCalculation_UseAccumulated);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsMealAllowanceProvided", _IsMealAllowanceProvided);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "WorkingContract_Comment", _WorkingContract_Comment);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_BPT_EMP.CMN_BPT_EMP_WorkingContract.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_CMN_BPT_EMP_WorkingContractID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CMN_BPT_EMP_WorkingContractID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_BPT_EMP_WorkingContractID","ExtraWorkCalculation_RefID","WorkingContract_InCurrency_RefID","Contract_StartDate","Contract_EndDate","IsContractEndDateDefined","IsWorkTimeCalculated_InHours","IsWorkTimeCalculated_InDays","R_WorkTime_DaysPerWeek","R_WorkTime_HoursPerWeek","IsWorktimeChecked_Weekly","IsWorktimeChecked_Monthly","SurchargeCalculation_UseMaximum","SurchargeCalculation_UseAccumulated","IsMealAllowanceProvided","WorkingContract_Comment","Creation_Timestamp","IsDeleted","Tenant_RefID" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter CMN_BPT_EMP_WorkingContractID of type Guid
						_CMN_BPT_EMP_WorkingContractID = reader.GetGuid(0);
						//1:Parameter ExtraWorkCalculation_RefID of type Guid
						_ExtraWorkCalculation_RefID = reader.GetGuid(1);
						//2:Parameter WorkingContract_InCurrency_RefID of type Guid
						_WorkingContract_InCurrency_RefID = reader.GetGuid(2);
						//3:Parameter Contract_StartDate of type DateTime
						_Contract_StartDate = reader.GetDate(3);
						//4:Parameter Contract_EndDate of type DateTime
						_Contract_EndDate = reader.GetDate(4);
						//5:Parameter IsContractEndDateDefined of type Boolean
						_IsContractEndDateDefined = reader.GetBoolean(5);
						//6:Parameter IsWorkTimeCalculated_InHours of type Boolean
						_IsWorkTimeCalculated_InHours = reader.GetBoolean(6);
						//7:Parameter IsWorkTimeCalculated_InDays of type Boolean
						_IsWorkTimeCalculated_InDays = reader.GetBoolean(7);
						//8:Parameter R_WorkTime_DaysPerWeek of type Double
						_R_WorkTime_DaysPerWeek = reader.GetDouble(8);
						//9:Parameter R_WorkTime_HoursPerWeek of type Double
						_R_WorkTime_HoursPerWeek = reader.GetDouble(9);
						//10:Parameter IsWorktimeChecked_Weekly of type Boolean
						_IsWorktimeChecked_Weekly = reader.GetBoolean(10);
						//11:Parameter IsWorktimeChecked_Monthly of type Boolean
						_IsWorktimeChecked_Monthly = reader.GetBoolean(11);
						//12:Parameter SurchargeCalculation_UseMaximum of type Boolean
						_SurchargeCalculation_UseMaximum = reader.GetBoolean(12);
						//13:Parameter SurchargeCalculation_UseAccumulated of type Boolean
						_SurchargeCalculation_UseAccumulated = reader.GetBoolean(13);
						//14:Parameter IsMealAllowanceProvided of type Boolean
						_IsMealAllowanceProvided = reader.GetBoolean(14);
						//15:Parameter WorkingContract_Comment of type String
						_WorkingContract_Comment = reader.GetString(15);
						//16:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(16);
						//17:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(17);
						//18:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(18);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_CMN_BPT_EMP_WorkingContractID != Guid.Empty){
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
			public Guid? CMN_BPT_EMP_WorkingContractID {	get; set; }
			public Guid? ExtraWorkCalculation_RefID {	get; set; }
			public Guid? WorkingContract_InCurrency_RefID {	get; set; }
			public DateTime? Contract_StartDate {	get; set; }
			public DateTime? Contract_EndDate {	get; set; }
			public Boolean? IsContractEndDateDefined {	get; set; }
			public Boolean? IsWorkTimeCalculated_InHours {	get; set; }
			public Boolean? IsWorkTimeCalculated_InDays {	get; set; }
			public Double? R_WorkTime_DaysPerWeek {	get; set; }
			public Double? R_WorkTime_HoursPerWeek {	get; set; }
			public Boolean? IsWorktimeChecked_Weekly {	get; set; }
			public Boolean? IsWorktimeChecked_Monthly {	get; set; }
			public Boolean? SurchargeCalculation_UseMaximum {	get; set; }
			public Boolean? SurchargeCalculation_UseAccumulated {	get; set; }
			public Boolean? IsMealAllowanceProvided {	get; set; }
			public String WorkingContract_Comment {	get; set; }
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
			public static List<ORM_CMN_BPT_EMP_WorkingContract> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_CMN_BPT_EMP_WorkingContract> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_CMN_BPT_EMP_WorkingContract> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_CMN_BPT_EMP_WorkingContract> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_CMN_BPT_EMP_WorkingContract> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_CMN_BPT_EMP_WorkingContract>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_BPT_EMP_WorkingContractID","ExtraWorkCalculation_RefID","WorkingContract_InCurrency_RefID","Contract_StartDate","Contract_EndDate","IsContractEndDateDefined","IsWorkTimeCalculated_InHours","IsWorkTimeCalculated_InDays","R_WorkTime_DaysPerWeek","R_WorkTime_HoursPerWeek","IsWorktimeChecked_Weekly","IsWorktimeChecked_Monthly","SurchargeCalculation_UseMaximum","SurchargeCalculation_UseAccumulated","IsMealAllowanceProvided","WorkingContract_Comment","Creation_Timestamp","IsDeleted","Tenant_RefID" });
			        while (reader.Read())
			        {
			            ORM_CMN_BPT_EMP_WorkingContract item = new ORM_CMN_BPT_EMP_WorkingContract();
						//0:Parameter CMN_BPT_EMP_WorkingContractID of type Guid
						item.CMN_BPT_EMP_WorkingContractID = reader.GetGuid(0);
						//1:Parameter ExtraWorkCalculation_RefID of type Guid
						item.ExtraWorkCalculation_RefID = reader.GetGuid(1);
						//2:Parameter WorkingContract_InCurrency_RefID of type Guid
						item.WorkingContract_InCurrency_RefID = reader.GetGuid(2);
						//3:Parameter Contract_StartDate of type DateTime
						item.Contract_StartDate = reader.GetDate(3);
						//4:Parameter Contract_EndDate of type DateTime
						item.Contract_EndDate = reader.GetDate(4);
						//5:Parameter IsContractEndDateDefined of type Boolean
						item.IsContractEndDateDefined = reader.GetBoolean(5);
						//6:Parameter IsWorkTimeCalculated_InHours of type Boolean
						item.IsWorkTimeCalculated_InHours = reader.GetBoolean(6);
						//7:Parameter IsWorkTimeCalculated_InDays of type Boolean
						item.IsWorkTimeCalculated_InDays = reader.GetBoolean(7);
						//8:Parameter R_WorkTime_DaysPerWeek of type Double
						item.R_WorkTime_DaysPerWeek = reader.GetDouble(8);
						//9:Parameter R_WorkTime_HoursPerWeek of type Double
						item.R_WorkTime_HoursPerWeek = reader.GetDouble(9);
						//10:Parameter IsWorktimeChecked_Weekly of type Boolean
						item.IsWorktimeChecked_Weekly = reader.GetBoolean(10);
						//11:Parameter IsWorktimeChecked_Monthly of type Boolean
						item.IsWorktimeChecked_Monthly = reader.GetBoolean(11);
						//12:Parameter SurchargeCalculation_UseMaximum of type Boolean
						item.SurchargeCalculation_UseMaximum = reader.GetBoolean(12);
						//13:Parameter SurchargeCalculation_UseAccumulated of type Boolean
						item.SurchargeCalculation_UseAccumulated = reader.GetBoolean(13);
						//14:Parameter IsMealAllowanceProvided of type Boolean
						item.IsMealAllowanceProvided = reader.GetBoolean(14);
						//15:Parameter WorkingContract_Comment of type String
						item.WorkingContract_Comment = reader.GetString(15);
						//16:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(16);
						//17:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(17);
						//18:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(18);


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
