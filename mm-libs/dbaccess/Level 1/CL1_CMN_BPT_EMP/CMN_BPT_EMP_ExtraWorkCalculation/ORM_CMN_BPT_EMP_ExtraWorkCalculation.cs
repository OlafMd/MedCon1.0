/* 
 * Generated on 22-Oct-13 14:25:21
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_CMN_BPT_EMP
{
	[Serializable]
	public class ORM_CMN_BPT_EMP_ExtraWorkCalculation
	{
		public static readonly string TableName = "cmn_bpt_emp_extraworkcalculations";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_CMN_BPT_EMP_ExtraWorkCalculation()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_CMN_BPT_EMP_ExtraWorkCalculationID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _CMN_BPT_EMP_ExtraWorkCalculationID = default(Guid);
		private String _GlobalPropertyMatchingID = default(String);
		private Dict _ExtraWorkCalculation_Name = new Dict(TableName);
		private Boolean _IsCalculatingOvertimeEnabled = default(Boolean);
		private Boolean _AreAdditionalWorkDays_CalculatedIn_Hours = default(Boolean);
		private Boolean _AreAdditionalWorkDays_CalculatedIn_DaysAsHours = default(Boolean);
		private Boolean _AreAdditionalWorkDays_CalculatedIn_Days = default(Boolean);
		private int _StandardWorkDay_in_mins = default(int);
		private Boolean _IsDisplayedAs_HoursAsDays = default(Boolean);
		private Boolean _IsDisplayedAs_DaysAndHours = default(Boolean);
		private int _MinimalOvertimeTreshold_in_minutes = default(int);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Boolean _IsDeleted = default(Boolean);
		private Guid _Tenant_RefID = default(Guid);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid CMN_BPT_EMP_ExtraWorkCalculationID { 
			get {
				return _CMN_BPT_EMP_ExtraWorkCalculationID;
			}
			set {
				if(_CMN_BPT_EMP_ExtraWorkCalculationID != value){
					_CMN_BPT_EMP_ExtraWorkCalculationID = value;
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
		public Dict ExtraWorkCalculation_Name { 
			get {
				return _ExtraWorkCalculation_Name;
			}
			set {
				if(_ExtraWorkCalculation_Name != value){
					_ExtraWorkCalculation_Name = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsCalculatingOvertimeEnabled { 
			get {
				return _IsCalculatingOvertimeEnabled;
			}
			set {
				if(_IsCalculatingOvertimeEnabled != value){
					_IsCalculatingOvertimeEnabled = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean AreAdditionalWorkDays_CalculatedIn_Hours { 
			get {
				return _AreAdditionalWorkDays_CalculatedIn_Hours;
			}
			set {
				if(_AreAdditionalWorkDays_CalculatedIn_Hours != value){
					_AreAdditionalWorkDays_CalculatedIn_Hours = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean AreAdditionalWorkDays_CalculatedIn_DaysAsHours { 
			get {
				return _AreAdditionalWorkDays_CalculatedIn_DaysAsHours;
			}
			set {
				if(_AreAdditionalWorkDays_CalculatedIn_DaysAsHours != value){
					_AreAdditionalWorkDays_CalculatedIn_DaysAsHours = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean AreAdditionalWorkDays_CalculatedIn_Days { 
			get {
				return _AreAdditionalWorkDays_CalculatedIn_Days;
			}
			set {
				if(_AreAdditionalWorkDays_CalculatedIn_Days != value){
					_AreAdditionalWorkDays_CalculatedIn_Days = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int StandardWorkDay_in_mins { 
			get {
				return _StandardWorkDay_in_mins;
			}
			set {
				if(_StandardWorkDay_in_mins != value){
					_StandardWorkDay_in_mins = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsDisplayedAs_HoursAsDays { 
			get {
				return _IsDisplayedAs_HoursAsDays;
			}
			set {
				if(_IsDisplayedAs_HoursAsDays != value){
					_IsDisplayedAs_HoursAsDays = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsDisplayedAs_DaysAndHours { 
			get {
				return _IsDisplayedAs_DaysAndHours;
			}
			set {
				if(_IsDisplayedAs_DaysAndHours != value){
					_IsDisplayedAs_DaysAndHours = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int MinimalOvertimeTreshold_in_minutes { 
			get {
				return _MinimalOvertimeTreshold_in_minutes;
			}
			set {
				if(_MinimalOvertimeTreshold_in_minutes != value){
					_MinimalOvertimeTreshold_in_minutes = value;
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

				bool saveDictionary = !Status_IsAlreadySaved || ExtraWorkCalculation_Name.IsDirty ;
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
								loader.Append(ExtraWorkCalculation_Name,TableName);

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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_BPT_EMP.CMN_BPT_EMP_ExtraWorkCalculation.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_BPT_EMP.CMN_BPT_EMP_ExtraWorkCalculation.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_BPT_EMP_ExtraWorkCalculationID", _CMN_BPT_EMP_ExtraWorkCalculationID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "GlobalPropertyMatchingID", _GlobalPropertyMatchingID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ExtraWorkCalculation_Name", _ExtraWorkCalculation_Name.DictionaryID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsCalculatingOvertimeEnabled", _IsCalculatingOvertimeEnabled);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "AreAdditionalWorkDays_CalculatedIn_Hours", _AreAdditionalWorkDays_CalculatedIn_Hours);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "AreAdditionalWorkDays_CalculatedIn_DaysAsHours", _AreAdditionalWorkDays_CalculatedIn_DaysAsHours);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "AreAdditionalWorkDays_CalculatedIn_Days", _AreAdditionalWorkDays_CalculatedIn_Days);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "StandardWorkDay_in_mins", _StandardWorkDay_in_mins);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsDisplayedAs_HoursAsDays", _IsDisplayedAs_HoursAsDays);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsDisplayedAs_DaysAndHours", _IsDisplayedAs_DaysAndHours);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "MinimalOvertimeTreshold_in_minutes", _MinimalOvertimeTreshold_in_minutes);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_BPT_EMP.CMN_BPT_EMP_ExtraWorkCalculation.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_CMN_BPT_EMP_ExtraWorkCalculationID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CMN_BPT_EMP_ExtraWorkCalculationID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_BPT_EMP_ExtraWorkCalculationID","GlobalPropertyMatchingID","ExtraWorkCalculation_Name_DictID","IsCalculatingOvertimeEnabled","AreAdditionalWorkDays_CalculatedIn_Hours","AreAdditionalWorkDays_CalculatedIn_DaysAsHours","AreAdditionalWorkDays_CalculatedIn_Days","StandardWorkDay_in_mins","IsDisplayedAs_HoursAsDays","IsDisplayedAs_DaysAndHours","MinimalOvertimeTreshold_in_minutes","Creation_Timestamp","IsDeleted","Tenant_RefID" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter CMN_BPT_EMP_ExtraWorkCalculationID of type Guid
						_CMN_BPT_EMP_ExtraWorkCalculationID = reader.GetGuid(0);
						//1:Parameter GlobalPropertyMatchingID of type String
						_GlobalPropertyMatchingID = reader.GetString(1);
						//2:Parameter ExtraWorkCalculation_Name of type Dict
						_ExtraWorkCalculation_Name = reader.GetDictionary(2);
						loader.Append(_ExtraWorkCalculation_Name,TableName);
						//3:Parameter IsCalculatingOvertimeEnabled of type Boolean
						_IsCalculatingOvertimeEnabled = reader.GetBoolean(3);
						//4:Parameter AreAdditionalWorkDays_CalculatedIn_Hours of type Boolean
						_AreAdditionalWorkDays_CalculatedIn_Hours = reader.GetBoolean(4);
						//5:Parameter AreAdditionalWorkDays_CalculatedIn_DaysAsHours of type Boolean
						_AreAdditionalWorkDays_CalculatedIn_DaysAsHours = reader.GetBoolean(5);
						//6:Parameter AreAdditionalWorkDays_CalculatedIn_Days of type Boolean
						_AreAdditionalWorkDays_CalculatedIn_Days = reader.GetBoolean(6);
						//7:Parameter StandardWorkDay_in_mins of type int
						_StandardWorkDay_in_mins = reader.GetInteger(7);
						//8:Parameter IsDisplayedAs_HoursAsDays of type Boolean
						_IsDisplayedAs_HoursAsDays = reader.GetBoolean(8);
						//9:Parameter IsDisplayedAs_DaysAndHours of type Boolean
						_IsDisplayedAs_DaysAndHours = reader.GetBoolean(9);
						//10:Parameter MinimalOvertimeTreshold_in_minutes of type int
						_MinimalOvertimeTreshold_in_minutes = reader.GetInteger(10);
						//11:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(11);
						//12:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(12);
						//13:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(13);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_CMN_BPT_EMP_ExtraWorkCalculationID != Guid.Empty){
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
			public Guid? CMN_BPT_EMP_ExtraWorkCalculationID {	get; set; }
			public String GlobalPropertyMatchingID {	get; set; }
			public Dict ExtraWorkCalculation_Name {	get; set; }
			public Boolean? IsCalculatingOvertimeEnabled {	get; set; }
			public Boolean? AreAdditionalWorkDays_CalculatedIn_Hours {	get; set; }
			public Boolean? AreAdditionalWorkDays_CalculatedIn_DaysAsHours {	get; set; }
			public Boolean? AreAdditionalWorkDays_CalculatedIn_Days {	get; set; }
			public int? StandardWorkDay_in_mins {	get; set; }
			public Boolean? IsDisplayedAs_HoursAsDays {	get; set; }
			public Boolean? IsDisplayedAs_DaysAndHours {	get; set; }
			public int? MinimalOvertimeTreshold_in_minutes {	get; set; }
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
			public static List<ORM_CMN_BPT_EMP_ExtraWorkCalculation> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_CMN_BPT_EMP_ExtraWorkCalculation> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_CMN_BPT_EMP_ExtraWorkCalculation> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_CMN_BPT_EMP_ExtraWorkCalculation> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_CMN_BPT_EMP_ExtraWorkCalculation> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_CMN_BPT_EMP_ExtraWorkCalculation>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_BPT_EMP_ExtraWorkCalculationID","GlobalPropertyMatchingID","ExtraWorkCalculation_Name_DictID","IsCalculatingOvertimeEnabled","AreAdditionalWorkDays_CalculatedIn_Hours","AreAdditionalWorkDays_CalculatedIn_DaysAsHours","AreAdditionalWorkDays_CalculatedIn_Days","StandardWorkDay_in_mins","IsDisplayedAs_HoursAsDays","IsDisplayedAs_DaysAndHours","MinimalOvertimeTreshold_in_minutes","Creation_Timestamp","IsDeleted","Tenant_RefID" });
			        while (reader.Read())
			        {
			            ORM_CMN_BPT_EMP_ExtraWorkCalculation item = new ORM_CMN_BPT_EMP_ExtraWorkCalculation();
						//0:Parameter CMN_BPT_EMP_ExtraWorkCalculationID of type Guid
						item.CMN_BPT_EMP_ExtraWorkCalculationID = reader.GetGuid(0);
						//1:Parameter GlobalPropertyMatchingID of type String
						item.GlobalPropertyMatchingID = reader.GetString(1);
						//2:Parameter ExtraWorkCalculation_Name of type Dict
						item.ExtraWorkCalculation_Name = reader.GetDictionary(2);
						loader.Append(item.ExtraWorkCalculation_Name,TableName);
						//3:Parameter IsCalculatingOvertimeEnabled of type Boolean
						item.IsCalculatingOvertimeEnabled = reader.GetBoolean(3);
						//4:Parameter AreAdditionalWorkDays_CalculatedIn_Hours of type Boolean
						item.AreAdditionalWorkDays_CalculatedIn_Hours = reader.GetBoolean(4);
						//5:Parameter AreAdditionalWorkDays_CalculatedIn_DaysAsHours of type Boolean
						item.AreAdditionalWorkDays_CalculatedIn_DaysAsHours = reader.GetBoolean(5);
						//6:Parameter AreAdditionalWorkDays_CalculatedIn_Days of type Boolean
						item.AreAdditionalWorkDays_CalculatedIn_Days = reader.GetBoolean(6);
						//7:Parameter StandardWorkDay_in_mins of type int
						item.StandardWorkDay_in_mins = reader.GetInteger(7);
						//8:Parameter IsDisplayedAs_HoursAsDays of type Boolean
						item.IsDisplayedAs_HoursAsDays = reader.GetBoolean(8);
						//9:Parameter IsDisplayedAs_DaysAndHours of type Boolean
						item.IsDisplayedAs_DaysAndHours = reader.GetBoolean(9);
						//10:Parameter MinimalOvertimeTreshold_in_minutes of type int
						item.MinimalOvertimeTreshold_in_minutes = reader.GetInteger(10);
						//11:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(11);
						//12:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(12);
						//13:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(13);


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
