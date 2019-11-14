/* 
 * Generated on 1/16/2014 11:16:30 AM
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
	public class ORM_CMN_BPT_EMP_ContractAbsenceAdjustment
	{
		public static readonly string TableName = "cmn_bpt_emp_contractabsenceadjustments";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_CMN_BPT_EMP_ContractAbsenceAdjustment()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_CMN_BPT_EMP_ContractAbsenceAdjustmentID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _CMN_BPT_EMP_ContractAbsenceAdjustmentID = default(Guid);
		private Guid _EmploymentRelationship_Timeframe_RefID = default(Guid);
		private Guid _AbsenceReason_RefID = default(Guid);
		private Guid _ContractAbsenceAdjustment_Group_RefID = default(Guid);
		private Double _AbsenceTime_InMinutes = default(Double);
		private String _AdjustmentComment = default(String);
		private Guid _TriggeringAccount_RefID = default(Guid);
		private Boolean _IsManual = default(Boolean);
		private String _InternalAdjustmentType = default(String);
		private DateTime _AdjustmentDate = default(DateTime);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid CMN_BPT_EMP_ContractAbsenceAdjustmentID { 
			get {
				return _CMN_BPT_EMP_ContractAbsenceAdjustmentID;
			}
			set {
				if(_CMN_BPT_EMP_ContractAbsenceAdjustmentID != value){
					_CMN_BPT_EMP_ContractAbsenceAdjustmentID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid EmploymentRelationship_Timeframe_RefID { 
			get {
				return _EmploymentRelationship_Timeframe_RefID;
			}
			set {
				if(_EmploymentRelationship_Timeframe_RefID != value){
					_EmploymentRelationship_Timeframe_RefID = value;
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
		public Guid ContractAbsenceAdjustment_Group_RefID { 
			get {
				return _ContractAbsenceAdjustment_Group_RefID;
			}
			set {
				if(_ContractAbsenceAdjustment_Group_RefID != value){
					_ContractAbsenceAdjustment_Group_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Double AbsenceTime_InMinutes { 
			get {
				return _AbsenceTime_InMinutes;
			}
			set {
				if(_AbsenceTime_InMinutes != value){
					_AbsenceTime_InMinutes = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String AdjustmentComment { 
			get {
				return _AdjustmentComment;
			}
			set {
				if(_AdjustmentComment != value){
					_AdjustmentComment = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid TriggeringAccount_RefID { 
			get {
				return _TriggeringAccount_RefID;
			}
			set {
				if(_TriggeringAccount_RefID != value){
					_TriggeringAccount_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsManual { 
			get {
				return _IsManual;
			}
			set {
				if(_IsManual != value){
					_IsManual = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String InternalAdjustmentType { 
			get {
				return _InternalAdjustmentType;
			}
			set {
				if(_InternalAdjustmentType != value){
					_InternalAdjustmentType = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime AdjustmentDate { 
			get {
				return _AdjustmentDate;
			}
			set {
				if(_AdjustmentDate != value){
					_AdjustmentDate = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_BPT_EMP.CMN_BPT_EMP_ContractAbsenceAdjustment.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_BPT_EMP.CMN_BPT_EMP_ContractAbsenceAdjustment.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_BPT_EMP_ContractAbsenceAdjustmentID", _CMN_BPT_EMP_ContractAbsenceAdjustmentID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "EmploymentRelationship_Timeframe_RefID", _EmploymentRelationship_Timeframe_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "AbsenceReason_RefID", _AbsenceReason_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ContractAbsenceAdjustment_Group_RefID", _ContractAbsenceAdjustment_Group_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "AbsenceTime_InMinutes", _AbsenceTime_InMinutes);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "AdjustmentComment", _AdjustmentComment);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "TriggeringAccount_RefID", _TriggeringAccount_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsManual", _IsManual);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "InternalAdjustmentType", _InternalAdjustmentType);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "AdjustmentDate", _AdjustmentDate);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_BPT_EMP.CMN_BPT_EMP_ContractAbsenceAdjustment.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_CMN_BPT_EMP_ContractAbsenceAdjustmentID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CMN_BPT_EMP_ContractAbsenceAdjustmentID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_BPT_EMP_ContractAbsenceAdjustmentID","EmploymentRelationship_Timeframe_RefID","AbsenceReason_RefID","ContractAbsenceAdjustment_Group_RefID","AbsenceTime_InMinutes","AdjustmentComment","TriggeringAccount_RefID","IsManual","InternalAdjustmentType","AdjustmentDate","Creation_Timestamp","Tenant_RefID","IsDeleted" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter CMN_BPT_EMP_ContractAbsenceAdjustmentID of type Guid
						_CMN_BPT_EMP_ContractAbsenceAdjustmentID = reader.GetGuid(0);
						//1:Parameter EmploymentRelationship_Timeframe_RefID of type Guid
						_EmploymentRelationship_Timeframe_RefID = reader.GetGuid(1);
						//2:Parameter AbsenceReason_RefID of type Guid
						_AbsenceReason_RefID = reader.GetGuid(2);
						//3:Parameter ContractAbsenceAdjustment_Group_RefID of type Guid
						_ContractAbsenceAdjustment_Group_RefID = reader.GetGuid(3);
						//4:Parameter AbsenceTime_InMinutes of type Double
						_AbsenceTime_InMinutes = reader.GetDouble(4);
						//5:Parameter AdjustmentComment of type String
						_AdjustmentComment = reader.GetString(5);
						//6:Parameter TriggeringAccount_RefID of type Guid
						_TriggeringAccount_RefID = reader.GetGuid(6);
						//7:Parameter IsManual of type Boolean
						_IsManual = reader.GetBoolean(7);
						//8:Parameter InternalAdjustmentType of type String
						_InternalAdjustmentType = reader.GetString(8);
						//9:Parameter AdjustmentDate of type DateTime
						_AdjustmentDate = reader.GetDate(9);
						//10:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(10);
						//11:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(11);
						//12:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(12);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_CMN_BPT_EMP_ContractAbsenceAdjustmentID != Guid.Empty){
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
			public Guid? CMN_BPT_EMP_ContractAbsenceAdjustmentID {	get; set; }
			public Guid? EmploymentRelationship_Timeframe_RefID {	get; set; }
			public Guid? AbsenceReason_RefID {	get; set; }
			public Guid? ContractAbsenceAdjustment_Group_RefID {	get; set; }
			public Double? AbsenceTime_InMinutes {	get; set; }
			public String AdjustmentComment {	get; set; }
			public Guid? TriggeringAccount_RefID {	get; set; }
			public Boolean? IsManual {	get; set; }
			public String InternalAdjustmentType {	get; set; }
			public DateTime? AdjustmentDate {	get; set; }
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
					throw ex;
				}
			}
			#endregion

			#region Search
			public static List<ORM_CMN_BPT_EMP_ContractAbsenceAdjustment> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_CMN_BPT_EMP_ContractAbsenceAdjustment> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_CMN_BPT_EMP_ContractAbsenceAdjustment> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_CMN_BPT_EMP_ContractAbsenceAdjustment> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_CMN_BPT_EMP_ContractAbsenceAdjustment> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_CMN_BPT_EMP_ContractAbsenceAdjustment>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_BPT_EMP_ContractAbsenceAdjustmentID","EmploymentRelationship_Timeframe_RefID","AbsenceReason_RefID","ContractAbsenceAdjustment_Group_RefID","AbsenceTime_InMinutes","AdjustmentComment","TriggeringAccount_RefID","IsManual","InternalAdjustmentType","AdjustmentDate","Creation_Timestamp","Tenant_RefID","IsDeleted" });
			        while (reader.Read())
			        {
			            ORM_CMN_BPT_EMP_ContractAbsenceAdjustment item = new ORM_CMN_BPT_EMP_ContractAbsenceAdjustment();
						//0:Parameter CMN_BPT_EMP_ContractAbsenceAdjustmentID of type Guid
						item.CMN_BPT_EMP_ContractAbsenceAdjustmentID = reader.GetGuid(0);
						//1:Parameter EmploymentRelationship_Timeframe_RefID of type Guid
						item.EmploymentRelationship_Timeframe_RefID = reader.GetGuid(1);
						//2:Parameter AbsenceReason_RefID of type Guid
						item.AbsenceReason_RefID = reader.GetGuid(2);
						//3:Parameter ContractAbsenceAdjustment_Group_RefID of type Guid
						item.ContractAbsenceAdjustment_Group_RefID = reader.GetGuid(3);
						//4:Parameter AbsenceTime_InMinutes of type Double
						item.AbsenceTime_InMinutes = reader.GetDouble(4);
						//5:Parameter AdjustmentComment of type String
						item.AdjustmentComment = reader.GetString(5);
						//6:Parameter TriggeringAccount_RefID of type Guid
						item.TriggeringAccount_RefID = reader.GetGuid(6);
						//7:Parameter IsManual of type Boolean
						item.IsManual = reader.GetBoolean(7);
						//8:Parameter InternalAdjustmentType of type String
						item.InternalAdjustmentType = reader.GetString(8);
						//9:Parameter AdjustmentDate of type DateTime
						item.AdjustmentDate = reader.GetDate(9);
						//10:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(10);
						//11:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(11);
						//12:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(12);


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
