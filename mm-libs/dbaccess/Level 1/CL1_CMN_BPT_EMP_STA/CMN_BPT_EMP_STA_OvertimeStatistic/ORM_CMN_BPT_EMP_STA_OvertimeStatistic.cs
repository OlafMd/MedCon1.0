/* 
 * Generated on 30/09/2014 09:54:39
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
	public class ORM_CMN_BPT_EMP_STA_OvertimeStatistic
	{
		public static readonly string TableName = "cmn_bpt_emp_sta_overtimestatistics";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_CMN_BPT_EMP_STA_OvertimeStatistic()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_CMN_BPT_EMP_STA_OvertimeStatisticsID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _CMN_BPT_EMP_STA_OvertimeStatisticsID = default(Guid);
		private Guid _CMN_CAL_CalculationTimeframe_RefID = default(Guid);
		private Guid _Employee_RefID = default(Guid);
		private Double _OvertimeIn_EmployeeDays = default(Double);
		private Double _OvertimeIn_EmployeeHours = default(Double);
		private Boolean _IsOvertimeInEmployeeDays = default(Boolean);
		private Boolean _IsOvertimeInEmployeeHours = default(Boolean);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid CMN_BPT_EMP_STA_OvertimeStatisticsID { 
			get {
				return _CMN_BPT_EMP_STA_OvertimeStatisticsID;
			}
			set {
				if(_CMN_BPT_EMP_STA_OvertimeStatisticsID != value){
					_CMN_BPT_EMP_STA_OvertimeStatisticsID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid CMN_CAL_CalculationTimeframe_RefID { 
			get {
				return _CMN_CAL_CalculationTimeframe_RefID;
			}
			set {
				if(_CMN_CAL_CalculationTimeframe_RefID != value){
					_CMN_CAL_CalculationTimeframe_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Employee_RefID { 
			get {
				return _Employee_RefID;
			}
			set {
				if(_Employee_RefID != value){
					_Employee_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Double OvertimeIn_EmployeeDays { 
			get {
				return _OvertimeIn_EmployeeDays;
			}
			set {
				if(_OvertimeIn_EmployeeDays != value){
					_OvertimeIn_EmployeeDays = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Double OvertimeIn_EmployeeHours { 
			get {
				return _OvertimeIn_EmployeeHours;
			}
			set {
				if(_OvertimeIn_EmployeeHours != value){
					_OvertimeIn_EmployeeHours = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsOvertimeInEmployeeDays { 
			get {
				return _IsOvertimeInEmployeeDays;
			}
			set {
				if(_IsOvertimeInEmployeeDays != value){
					_IsOvertimeInEmployeeDays = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsOvertimeInEmployeeHours { 
			get {
				return _IsOvertimeInEmployeeHours;
			}
			set {
				if(_IsOvertimeInEmployeeHours != value){
					_IsOvertimeInEmployeeHours = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_BPT_EMP.CMN_BPT_EMP_STA_OvertimeStatistic.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_BPT_EMP.CMN_BPT_EMP_STA_OvertimeStatistic.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_BPT_EMP_STA_OvertimeStatisticsID", _CMN_BPT_EMP_STA_OvertimeStatisticsID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_CAL_CalculationTimeframe_RefID", _CMN_CAL_CalculationTimeframe_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Employee_RefID", _Employee_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "OvertimeIn_EmployeeDays", _OvertimeIn_EmployeeDays);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "OvertimeIn_EmployeeHours", _OvertimeIn_EmployeeHours);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsOvertimeInEmployeeDays", _IsOvertimeInEmployeeDays);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsOvertimeInEmployeeHours", _IsOvertimeInEmployeeHours);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Creation_Timestamp", _Creation_Timestamp);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Tenant_RefID", _Tenant_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsDeleted", _IsDeleted);


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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_BPT_EMP.CMN_BPT_EMP_STA_OvertimeStatistic.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_CMN_BPT_EMP_STA_OvertimeStatisticsID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CMN_BPT_EMP_STA_OvertimeStatisticsID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_BPT_EMP_STA_OvertimeStatisticsID","CMN_CAL_CalculationTimeframe_RefID","Employee_RefID","OvertimeIn_EmployeeDays","OvertimeIn_EmployeeHours","IsOvertimeInEmployeeDays","IsOvertimeInEmployeeHours","Creation_Timestamp","Tenant_RefID","IsDeleted" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter CMN_BPT_EMP_STA_OvertimeStatisticsID of type Guid
						_CMN_BPT_EMP_STA_OvertimeStatisticsID = reader.GetGuid(0);
						//1:Parameter CMN_CAL_CalculationTimeframe_RefID of type Guid
						_CMN_CAL_CalculationTimeframe_RefID = reader.GetGuid(1);
						//2:Parameter Employee_RefID of type Guid
						_Employee_RefID = reader.GetGuid(2);
						//3:Parameter OvertimeIn_EmployeeDays of type Double
						_OvertimeIn_EmployeeDays = reader.GetDouble(3);
						//4:Parameter OvertimeIn_EmployeeHours of type Double
						_OvertimeIn_EmployeeHours = reader.GetDouble(4);
						//5:Parameter IsOvertimeInEmployeeDays of type Boolean
						_IsOvertimeInEmployeeDays = reader.GetBoolean(5);
						//6:Parameter IsOvertimeInEmployeeHours of type Boolean
						_IsOvertimeInEmployeeHours = reader.GetBoolean(6);
						//7:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(7);
						//8:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(8);
						//9:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(9);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_CMN_BPT_EMP_STA_OvertimeStatisticsID != Guid.Empty){
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
			public Guid? CMN_BPT_EMP_STA_OvertimeStatisticsID {	get; set; }
			public Guid? CMN_CAL_CalculationTimeframe_RefID {	get; set; }
			public Guid? Employee_RefID {	get; set; }
			public Double? OvertimeIn_EmployeeDays {	get; set; }
			public Double? OvertimeIn_EmployeeHours {	get; set; }
			public Boolean? IsOvertimeInEmployeeDays {	get; set; }
			public Boolean? IsOvertimeInEmployeeHours {	get; set; }
			public DateTime? Creation_Timestamp {	get; set; }
			public Guid? Tenant_RefID {	get; set; }
			public Boolean? IsDeleted {	get; set; }
			 

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
			public static List<ORM_CMN_BPT_EMP_STA_OvertimeStatistic> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_CMN_BPT_EMP_STA_OvertimeStatistic> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_CMN_BPT_EMP_STA_OvertimeStatistic> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_CMN_BPT_EMP_STA_OvertimeStatistic> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_CMN_BPT_EMP_STA_OvertimeStatistic> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_CMN_BPT_EMP_STA_OvertimeStatistic>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_BPT_EMP_STA_OvertimeStatisticsID","CMN_CAL_CalculationTimeframe_RefID","Employee_RefID","OvertimeIn_EmployeeDays","OvertimeIn_EmployeeHours","IsOvertimeInEmployeeDays","IsOvertimeInEmployeeHours","Creation_Timestamp","Tenant_RefID","IsDeleted" });
			        while (reader.Read())
			        {
			            ORM_CMN_BPT_EMP_STA_OvertimeStatistic item = new ORM_CMN_BPT_EMP_STA_OvertimeStatistic();
						//0:Parameter CMN_BPT_EMP_STA_OvertimeStatisticsID of type Guid
						item.CMN_BPT_EMP_STA_OvertimeStatisticsID = reader.GetGuid(0);
						//1:Parameter CMN_CAL_CalculationTimeframe_RefID of type Guid
						item.CMN_CAL_CalculationTimeframe_RefID = reader.GetGuid(1);
						//2:Parameter Employee_RefID of type Guid
						item.Employee_RefID = reader.GetGuid(2);
						//3:Parameter OvertimeIn_EmployeeDays of type Double
						item.OvertimeIn_EmployeeDays = reader.GetDouble(3);
						//4:Parameter OvertimeIn_EmployeeHours of type Double
						item.OvertimeIn_EmployeeHours = reader.GetDouble(4);
						//5:Parameter IsOvertimeInEmployeeDays of type Boolean
						item.IsOvertimeInEmployeeDays = reader.GetBoolean(5);
						//6:Parameter IsOvertimeInEmployeeHours of type Boolean
						item.IsOvertimeInEmployeeHours = reader.GetBoolean(6);
						//7:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(7);
						//8:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(8);
						//9:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(9);


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
