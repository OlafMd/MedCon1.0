/* 
 * Generated on 05/19/15 18:05:08
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_HEC_PRC
{
	[Serializable]
	public class ORM_HEC_PRC_ProcurementOrder_Position
	{
		public static readonly string TableName = "hec_prc_procurementorder_positions";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_HEC_PRC_ProcurementOrder_Position()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_HEC_PRC_ProcurementOrder_PositionID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _HEC_PRC_ProcurementOrder_PositionID = default(Guid);
		private Guid _Ext_ORD_PRC_ProcurementOrder_Position_RefID = default(Guid);
		private Guid _Clearing_Doctor_RefID = default(Guid);
		private String _ClearingDoctor_DisplayName = default(String);
		private Guid _OrderedFor_Patient_RefID = default(Guid);
		private String _OrderedForPatient_DisplayName = default(String);
		private Guid _OrderedFor_Doctor_RefID = default(Guid);
		private String _OrderedForDoctor_DisplayName = default(String);
		private Boolean _IsOrderForPatient_PatientFeeWaived = default(Boolean);
		private Boolean _IfProFormaOrderPosition_PrintLabelOnly = default(Boolean);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		private DateTime _Modification_Timestamp = default(DateTime);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid HEC_PRC_ProcurementOrder_PositionID { 
			get {
				return _HEC_PRC_ProcurementOrder_PositionID;
			}
			set {
				if(_HEC_PRC_ProcurementOrder_PositionID != value){
					_HEC_PRC_ProcurementOrder_PositionID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Ext_ORD_PRC_ProcurementOrder_Position_RefID { 
			get {
				return _Ext_ORD_PRC_ProcurementOrder_Position_RefID;
			}
			set {
				if(_Ext_ORD_PRC_ProcurementOrder_Position_RefID != value){
					_Ext_ORD_PRC_ProcurementOrder_Position_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Clearing_Doctor_RefID { 
			get {
				return _Clearing_Doctor_RefID;
			}
			set {
				if(_Clearing_Doctor_RefID != value){
					_Clearing_Doctor_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String ClearingDoctor_DisplayName { 
			get {
				return _ClearingDoctor_DisplayName;
			}
			set {
				if(_ClearingDoctor_DisplayName != value){
					_ClearingDoctor_DisplayName = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid OrderedFor_Patient_RefID { 
			get {
				return _OrderedFor_Patient_RefID;
			}
			set {
				if(_OrderedFor_Patient_RefID != value){
					_OrderedFor_Patient_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String OrderedForPatient_DisplayName { 
			get {
				return _OrderedForPatient_DisplayName;
			}
			set {
				if(_OrderedForPatient_DisplayName != value){
					_OrderedForPatient_DisplayName = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid OrderedFor_Doctor_RefID { 
			get {
				return _OrderedFor_Doctor_RefID;
			}
			set {
				if(_OrderedFor_Doctor_RefID != value){
					_OrderedFor_Doctor_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String OrderedForDoctor_DisplayName { 
			get {
				return _OrderedForDoctor_DisplayName;
			}
			set {
				if(_OrderedForDoctor_DisplayName != value){
					_OrderedForDoctor_DisplayName = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsOrderForPatient_PatientFeeWaived { 
			get {
				return _IsOrderForPatient_PatientFeeWaived;
			}
			set {
				if(_IsOrderForPatient_PatientFeeWaived != value){
					_IsOrderForPatient_PatientFeeWaived = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IfProFormaOrderPosition_PrintLabelOnly { 
			get {
				return _IfProFormaOrderPosition_PrintLabelOnly;
			}
			set {
				if(_IfProFormaOrderPosition_PrintLabelOnly != value){
					_IfProFormaOrderPosition_PrintLabelOnly = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC_PRC.HEC_PRC_ProcurementOrder_Position.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC_PRC.HEC_PRC_ProcurementOrder_Position.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "HEC_PRC_ProcurementOrder_PositionID", _HEC_PRC_ProcurementOrder_PositionID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Ext_ORD_PRC_ProcurementOrder_Position_RefID", _Ext_ORD_PRC_ProcurementOrder_Position_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Clearing_Doctor_RefID", _Clearing_Doctor_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ClearingDoctor_DisplayName", _ClearingDoctor_DisplayName);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "OrderedFor_Patient_RefID", _OrderedFor_Patient_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "OrderedForPatient_DisplayName", _OrderedForPatient_DisplayName);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "OrderedFor_Doctor_RefID", _OrderedFor_Doctor_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "OrderedForDoctor_DisplayName", _OrderedForDoctor_DisplayName);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsOrderForPatient_PatientFeeWaived", _IsOrderForPatient_PatientFeeWaived);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfProFormaOrderPosition_PrintLabelOnly", _IfProFormaOrderPosition_PrintLabelOnly);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC_PRC.HEC_PRC_ProcurementOrder_Position.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_HEC_PRC_ProcurementOrder_PositionID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"HEC_PRC_ProcurementOrder_PositionID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "HEC_PRC_ProcurementOrder_PositionID","Ext_ORD_PRC_ProcurementOrder_Position_RefID","Clearing_Doctor_RefID","ClearingDoctor_DisplayName","OrderedFor_Patient_RefID","OrderedForPatient_DisplayName","OrderedFor_Doctor_RefID","OrderedForDoctor_DisplayName","IsOrderForPatient_PatientFeeWaived","IfProFormaOrderPosition_PrintLabelOnly","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter HEC_PRC_ProcurementOrder_PositionID of type Guid
						_HEC_PRC_ProcurementOrder_PositionID = reader.GetGuid(0);
						//1:Parameter Ext_ORD_PRC_ProcurementOrder_Position_RefID of type Guid
						_Ext_ORD_PRC_ProcurementOrder_Position_RefID = reader.GetGuid(1);
						//2:Parameter Clearing_Doctor_RefID of type Guid
						_Clearing_Doctor_RefID = reader.GetGuid(2);
						//3:Parameter ClearingDoctor_DisplayName of type String
						_ClearingDoctor_DisplayName = reader.GetString(3);
						//4:Parameter OrderedFor_Patient_RefID of type Guid
						_OrderedFor_Patient_RefID = reader.GetGuid(4);
						//5:Parameter OrderedForPatient_DisplayName of type String
						_OrderedForPatient_DisplayName = reader.GetString(5);
						//6:Parameter OrderedFor_Doctor_RefID of type Guid
						_OrderedFor_Doctor_RefID = reader.GetGuid(6);
						//7:Parameter OrderedForDoctor_DisplayName of type String
						_OrderedForDoctor_DisplayName = reader.GetString(7);
						//8:Parameter IsOrderForPatient_PatientFeeWaived of type Boolean
						_IsOrderForPatient_PatientFeeWaived = reader.GetBoolean(8);
						//9:Parameter IfProFormaOrderPosition_PrintLabelOnly of type Boolean
						_IfProFormaOrderPosition_PrintLabelOnly = reader.GetBoolean(9);
						//10:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(10);
						//11:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(11);
						//12:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(12);
						//13:Parameter Modification_Timestamp of type DateTime
						_Modification_Timestamp = reader.GetDate(13);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_HEC_PRC_ProcurementOrder_PositionID != Guid.Empty){
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
			public Guid? HEC_PRC_ProcurementOrder_PositionID {	get; set; }
			public Guid? Ext_ORD_PRC_ProcurementOrder_Position_RefID {	get; set; }
			public Guid? Clearing_Doctor_RefID {	get; set; }
			public String ClearingDoctor_DisplayName {	get; set; }
			public Guid? OrderedFor_Patient_RefID {	get; set; }
			public String OrderedForPatient_DisplayName {	get; set; }
			public Guid? OrderedFor_Doctor_RefID {	get; set; }
			public String OrderedForDoctor_DisplayName {	get; set; }
			public Boolean? IsOrderForPatient_PatientFeeWaived {	get; set; }
			public Boolean? IfProFormaOrderPosition_PrintLabelOnly {	get; set; }
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
			public static List<ORM_HEC_PRC_ProcurementOrder_Position> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_HEC_PRC_ProcurementOrder_Position> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_HEC_PRC_ProcurementOrder_Position> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_HEC_PRC_ProcurementOrder_Position> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_HEC_PRC_ProcurementOrder_Position> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_HEC_PRC_ProcurementOrder_Position>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "HEC_PRC_ProcurementOrder_PositionID","Ext_ORD_PRC_ProcurementOrder_Position_RefID","Clearing_Doctor_RefID","ClearingDoctor_DisplayName","OrderedFor_Patient_RefID","OrderedForPatient_DisplayName","OrderedFor_Doctor_RefID","OrderedForDoctor_DisplayName","IsOrderForPatient_PatientFeeWaived","IfProFormaOrderPosition_PrintLabelOnly","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
			        while (reader.Read())
			        {
			            ORM_HEC_PRC_ProcurementOrder_Position item = new ORM_HEC_PRC_ProcurementOrder_Position();
						//0:Parameter HEC_PRC_ProcurementOrder_PositionID of type Guid
						item.HEC_PRC_ProcurementOrder_PositionID = reader.GetGuid(0);
						//1:Parameter Ext_ORD_PRC_ProcurementOrder_Position_RefID of type Guid
						item.Ext_ORD_PRC_ProcurementOrder_Position_RefID = reader.GetGuid(1);
						//2:Parameter Clearing_Doctor_RefID of type Guid
						item.Clearing_Doctor_RefID = reader.GetGuid(2);
						//3:Parameter ClearingDoctor_DisplayName of type String
						item.ClearingDoctor_DisplayName = reader.GetString(3);
						//4:Parameter OrderedFor_Patient_RefID of type Guid
						item.OrderedFor_Patient_RefID = reader.GetGuid(4);
						//5:Parameter OrderedForPatient_DisplayName of type String
						item.OrderedForPatient_DisplayName = reader.GetString(5);
						//6:Parameter OrderedFor_Doctor_RefID of type Guid
						item.OrderedFor_Doctor_RefID = reader.GetGuid(6);
						//7:Parameter OrderedForDoctor_DisplayName of type String
						item.OrderedForDoctor_DisplayName = reader.GetString(7);
						//8:Parameter IsOrderForPatient_PatientFeeWaived of type Boolean
						item.IsOrderForPatient_PatientFeeWaived = reader.GetBoolean(8);
						//9:Parameter IfProFormaOrderPosition_PrintLabelOnly of type Boolean
						item.IfProFormaOrderPosition_PrintLabelOnly = reader.GetBoolean(9);
						//10:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(10);
						//11:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(11);
						//12:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(12);
						//13:Parameter Modification_Timestamp of type DateTime
						item.Modification_Timestamp = reader.GetDate(13);


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
