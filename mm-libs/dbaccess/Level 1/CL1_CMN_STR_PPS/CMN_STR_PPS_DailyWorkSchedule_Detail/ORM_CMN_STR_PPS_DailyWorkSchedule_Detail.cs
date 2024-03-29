/* 
 * Generated on 15/12/2014 08:21:54
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_CMN_STR_PPS
{
	[Serializable]
	public class ORM_CMN_STR_PPS_DailyWorkSchedule_Detail
	{
		public static readonly string TableName = "cmn_str_pps_dailyworkschedule_details";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_CMN_STR_PPS_DailyWorkSchedule_Detail()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_CMN_STR_PPS_DailyWorkSchedule_DetailID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _CMN_STR_PPS_DailyWorkSchedule_DetailID = default(Guid);
		private Guid _InstantiatedWithShiftTemplate_RefID = default(Guid);
		private Guid _CMN_CAL_Event_RefID = default(Guid);
		private Guid _DailyWorkSchedule_RefID = default(Guid);
		private Guid _AbsenceReason_RefID = default(Guid);
		private Guid _SheduleForWorkplace_RefID = default(Guid);
		private Boolean _IsWorkBreak = default(Boolean);
		private Guid _CMN_BPT_EMP_Employee_LeaveRequest_RefID = default(Guid);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		private DateTime _Modification_Timestamp = default(DateTime);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid CMN_STR_PPS_DailyWorkSchedule_DetailID { 
			get {
				return _CMN_STR_PPS_DailyWorkSchedule_DetailID;
			}
			set {
				if(_CMN_STR_PPS_DailyWorkSchedule_DetailID != value){
					_CMN_STR_PPS_DailyWorkSchedule_DetailID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid InstantiatedWithShiftTemplate_RefID { 
			get {
				return _InstantiatedWithShiftTemplate_RefID;
			}
			set {
				if(_InstantiatedWithShiftTemplate_RefID != value){
					_InstantiatedWithShiftTemplate_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid CMN_CAL_Event_RefID { 
			get {
				return _CMN_CAL_Event_RefID;
			}
			set {
				if(_CMN_CAL_Event_RefID != value){
					_CMN_CAL_Event_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid DailyWorkSchedule_RefID { 
			get {
				return _DailyWorkSchedule_RefID;
			}
			set {
				if(_DailyWorkSchedule_RefID != value){
					_DailyWorkSchedule_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid AbsenceReason_RefID { 
			get {
				return _AbsenceReason_RefID;
			}
			set {
				if(_AbsenceReason_RefID != value){
					_AbsenceReason_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid SheduleForWorkplace_RefID { 
			get {
				return _SheduleForWorkplace_RefID;
			}
			set {
				if(_SheduleForWorkplace_RefID != value){
					_SheduleForWorkplace_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsWorkBreak { 
			get {
				return _IsWorkBreak;
			}
			set {
				if(_IsWorkBreak != value){
					_IsWorkBreak = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid CMN_BPT_EMP_Employee_LeaveRequest_RefID { 
			get {
				return _CMN_BPT_EMP_Employee_LeaveRequest_RefID;
			}
			set {
				if(_CMN_BPT_EMP_Employee_LeaveRequest_RefID != value){
					_CMN_BPT_EMP_Employee_LeaveRequest_RefID = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_STR_PPS.CMN_STR_PPS_DailyWorkSchedule_Detail.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_STR_PPS.CMN_STR_PPS_DailyWorkSchedule_Detail.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_STR_PPS_DailyWorkSchedule_DetailID", _CMN_STR_PPS_DailyWorkSchedule_DetailID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "InstantiatedWithShiftTemplate_RefID", _InstantiatedWithShiftTemplate_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_CAL_Event_RefID", _CMN_CAL_Event_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "DailyWorkSchedule_RefID", _DailyWorkSchedule_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "AbsenceReason_RefID", _AbsenceReason_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "SheduleForWorkplace_RefID", _SheduleForWorkplace_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsWorkBreak", _IsWorkBreak);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_BPT_EMP_Employee_LeaveRequest_RefID", _CMN_BPT_EMP_Employee_LeaveRequest_RefID);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_STR_PPS.CMN_STR_PPS_DailyWorkSchedule_Detail.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_CMN_STR_PPS_DailyWorkSchedule_DetailID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CMN_STR_PPS_DailyWorkSchedule_DetailID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_STR_PPS_DailyWorkSchedule_DetailID","InstantiatedWithShiftTemplate_RefID","CMN_CAL_Event_RefID","DailyWorkSchedule_RefID","AbsenceReason_RefID","SheduleForWorkplace_RefID","IsWorkBreak","CMN_BPT_EMP_Employee_LeaveRequest_RefID","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter CMN_STR_PPS_DailyWorkSchedule_DetailID of type Guid
						_CMN_STR_PPS_DailyWorkSchedule_DetailID = reader.GetGuid(0);
						//1:Parameter InstantiatedWithShiftTemplate_RefID of type Guid
						_InstantiatedWithShiftTemplate_RefID = reader.GetGuid(1);
						//2:Parameter CMN_CAL_Event_RefID of type Guid
						_CMN_CAL_Event_RefID = reader.GetGuid(2);
						//3:Parameter DailyWorkSchedule_RefID of type Guid
						_DailyWorkSchedule_RefID = reader.GetGuid(3);
						//4:Parameter AbsenceReason_RefID of type Guid
						_AbsenceReason_RefID = reader.GetGuid(4);
						//5:Parameter SheduleForWorkplace_RefID of type Guid
						_SheduleForWorkplace_RefID = reader.GetGuid(5);
						//6:Parameter IsWorkBreak of type Boolean
						_IsWorkBreak = reader.GetBoolean(6);
						//7:Parameter CMN_BPT_EMP_Employee_LeaveRequest_RefID of type Guid
						_CMN_BPT_EMP_Employee_LeaveRequest_RefID = reader.GetGuid(7);
						//8:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(8);
						//9:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(9);
						//10:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(10);
						//11:Parameter Modification_Timestamp of type DateTime
						_Modification_Timestamp = reader.GetDate(11);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_CMN_STR_PPS_DailyWorkSchedule_DetailID != Guid.Empty){
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
			public Guid? CMN_STR_PPS_DailyWorkSchedule_DetailID {	get; set; }
			public Guid? InstantiatedWithShiftTemplate_RefID {	get; set; }
			public Guid? CMN_CAL_Event_RefID {	get; set; }
			public Guid? DailyWorkSchedule_RefID {	get; set; }
			public Guid? AbsenceReason_RefID {	get; set; }
			public Guid? SheduleForWorkplace_RefID {	get; set; }
			public Boolean? IsWorkBreak {	get; set; }
			public Guid? CMN_BPT_EMP_Employee_LeaveRequest_RefID {	get; set; }
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
			public static List<ORM_CMN_STR_PPS_DailyWorkSchedule_Detail> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_CMN_STR_PPS_DailyWorkSchedule_Detail> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_CMN_STR_PPS_DailyWorkSchedule_Detail> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_CMN_STR_PPS_DailyWorkSchedule_Detail> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_CMN_STR_PPS_DailyWorkSchedule_Detail> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_CMN_STR_PPS_DailyWorkSchedule_Detail>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_STR_PPS_DailyWorkSchedule_DetailID","InstantiatedWithShiftTemplate_RefID","CMN_CAL_Event_RefID","DailyWorkSchedule_RefID","AbsenceReason_RefID","SheduleForWorkplace_RefID","IsWorkBreak","CMN_BPT_EMP_Employee_LeaveRequest_RefID","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
			        while (reader.Read())
			        {
			            ORM_CMN_STR_PPS_DailyWorkSchedule_Detail item = new ORM_CMN_STR_PPS_DailyWorkSchedule_Detail();
						//0:Parameter CMN_STR_PPS_DailyWorkSchedule_DetailID of type Guid
						item.CMN_STR_PPS_DailyWorkSchedule_DetailID = reader.GetGuid(0);
						//1:Parameter InstantiatedWithShiftTemplate_RefID of type Guid
						item.InstantiatedWithShiftTemplate_RefID = reader.GetGuid(1);
						//2:Parameter CMN_CAL_Event_RefID of type Guid
						item.CMN_CAL_Event_RefID = reader.GetGuid(2);
						//3:Parameter DailyWorkSchedule_RefID of type Guid
						item.DailyWorkSchedule_RefID = reader.GetGuid(3);
						//4:Parameter AbsenceReason_RefID of type Guid
						item.AbsenceReason_RefID = reader.GetGuid(4);
						//5:Parameter SheduleForWorkplace_RefID of type Guid
						item.SheduleForWorkplace_RefID = reader.GetGuid(5);
						//6:Parameter IsWorkBreak of type Boolean
						item.IsWorkBreak = reader.GetBoolean(6);
						//7:Parameter CMN_BPT_EMP_Employee_LeaveRequest_RefID of type Guid
						item.CMN_BPT_EMP_Employee_LeaveRequest_RefID = reader.GetGuid(7);
						//8:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(8);
						//9:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(9);
						//10:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(10);
						//11:Parameter Modification_Timestamp of type DateTime
						item.Modification_Timestamp = reader.GetDate(11);


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
