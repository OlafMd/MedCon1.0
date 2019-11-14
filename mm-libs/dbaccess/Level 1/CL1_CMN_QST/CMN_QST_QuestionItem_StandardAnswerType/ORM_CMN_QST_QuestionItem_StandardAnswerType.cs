/* 
 * Generated on 6/18/2013 4:47:24 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_CMN_QST
{
	[Serializable]
	public class ORM_CMN_QST_QuestionItem_StandardAnswerType
	{
		public static readonly string TableName = "cmn_qst_questionitem_standardanswertypes";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_CMN_QST_QuestionItem_StandardAnswerType()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_CMN_QST_QuestionItem_StandardAnswerTypeID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _CMN_QST_QuestionItem_StandardAnswerTypeID = default(Guid);
		private Boolean _IsBoolean = default(Boolean);
		private Boolean _IsNumber = default(Boolean);
		private Boolean _IfNumber_IsInteger = default(Boolean);
		private int _IfNumber_Min_Inclusive = default(int);
		private int _IfNumber_Max_Exclusive = default(int);
		private Boolean _IsShortText = default(Boolean);
		private int _IfShortText_MaxLength = default(int);
		private Boolean _IsLongText = default(Boolean);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Boolean _IsDeleted = default(Boolean);
		private Guid _Tenant_RefID = default(Guid);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid CMN_QST_QuestionItem_StandardAnswerTypeID { 
			get {
				return _CMN_QST_QuestionItem_StandardAnswerTypeID;
			}
			set {
				if(_CMN_QST_QuestionItem_StandardAnswerTypeID != value){
					_CMN_QST_QuestionItem_StandardAnswerTypeID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsBoolean { 
			get {
				return _IsBoolean;
			}
			set {
				if(_IsBoolean != value){
					_IsBoolean = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsNumber { 
			get {
				return _IsNumber;
			}
			set {
				if(_IsNumber != value){
					_IsNumber = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IfNumber_IsInteger { 
			get {
				return _IfNumber_IsInteger;
			}
			set {
				if(_IfNumber_IsInteger != value){
					_IfNumber_IsInteger = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int IfNumber_Min_Inclusive { 
			get {
				return _IfNumber_Min_Inclusive;
			}
			set {
				if(_IfNumber_Min_Inclusive != value){
					_IfNumber_Min_Inclusive = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int IfNumber_Max_Exclusive { 
			get {
				return _IfNumber_Max_Exclusive;
			}
			set {
				if(_IfNumber_Max_Exclusive != value){
					_IfNumber_Max_Exclusive = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsShortText { 
			get {
				return _IsShortText;
			}
			set {
				if(_IsShortText != value){
					_IsShortText = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int IfShortText_MaxLength { 
			get {
				return _IfShortText_MaxLength;
			}
			set {
				if(_IfShortText_MaxLength != value){
					_IfShortText_MaxLength = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsLongText { 
			get {
				return _IsLongText;
			}
			set {
				if(_IsLongText != value){
					_IsLongText = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_QST.CMN_QST_QuestionItem_StandardAnswerType.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_QST.CMN_QST_QuestionItem_StandardAnswerType.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_QST_QuestionItem_StandardAnswerTypeID", _CMN_QST_QuestionItem_StandardAnswerTypeID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsBoolean", _IsBoolean);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsNumber", _IsNumber);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfNumber_IsInteger", _IfNumber_IsInteger);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfNumber_Min_Inclusive", _IfNumber_Min_Inclusive);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfNumber_Max_Exclusive", _IfNumber_Max_Exclusive);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsShortText", _IsShortText);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfShortText_MaxLength", _IfShortText_MaxLength);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsLongText", _IsLongText);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_QST.CMN_QST_QuestionItem_StandardAnswerType.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_CMN_QST_QuestionItem_StandardAnswerTypeID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CMN_QST_QuestionItem_StandardAnswerTypeID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_QST_QuestionItem_StandardAnswerTypeID","IsBoolean","IsNumber","IfNumber_IsInteger","IfNumber_Min_Inclusive","IfNumber_Max_Exclusive","IsShortText","IfShortText_MaxLength","IsLongText","Creation_Timestamp","IsDeleted","Tenant_RefID" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter CMN_QST_QuestionItem_StandardAnswerTypeID of type Guid
						_CMN_QST_QuestionItem_StandardAnswerTypeID = reader.GetGuid(0);
						//1:Parameter IsBoolean of type Boolean
						_IsBoolean = reader.GetBoolean(1);
						//2:Parameter IsNumber of type Boolean
						_IsNumber = reader.GetBoolean(2);
						//3:Parameter IfNumber_IsInteger of type Boolean
						_IfNumber_IsInteger = reader.GetBoolean(3);
						//4:Parameter IfNumber_Min_Inclusive of type int
						_IfNumber_Min_Inclusive = reader.GetInteger(4);
						//5:Parameter IfNumber_Max_Exclusive of type int
						_IfNumber_Max_Exclusive = reader.GetInteger(5);
						//6:Parameter IsShortText of type Boolean
						_IsShortText = reader.GetBoolean(6);
						//7:Parameter IfShortText_MaxLength of type int
						_IfShortText_MaxLength = reader.GetInteger(7);
						//8:Parameter IsLongText of type Boolean
						_IsLongText = reader.GetBoolean(8);
						//9:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(9);
						//10:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(10);
						//11:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(11);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_CMN_QST_QuestionItem_StandardAnswerTypeID != Guid.Empty){
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
			public Guid? CMN_QST_QuestionItem_StandardAnswerTypeID {	get; set; }
			public Boolean? IsBoolean {	get; set; }
			public Boolean? IsNumber {	get; set; }
			public Boolean? IfNumber_IsInteger {	get; set; }
			public int? IfNumber_Min_Inclusive {	get; set; }
			public int? IfNumber_Max_Exclusive {	get; set; }
			public Boolean? IsShortText {	get; set; }
			public int? IfShortText_MaxLength {	get; set; }
			public Boolean? IsLongText {	get; set; }
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
			public static List<ORM_CMN_QST_QuestionItem_StandardAnswerType> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_CMN_QST_QuestionItem_StandardAnswerType> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_CMN_QST_QuestionItem_StandardAnswerType> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_CMN_QST_QuestionItem_StandardAnswerType> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_CMN_QST_QuestionItem_StandardAnswerType> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_CMN_QST_QuestionItem_StandardAnswerType>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_QST_QuestionItem_StandardAnswerTypeID","IsBoolean","IsNumber","IfNumber_IsInteger","IfNumber_Min_Inclusive","IfNumber_Max_Exclusive","IsShortText","IfShortText_MaxLength","IsLongText","Creation_Timestamp","IsDeleted","Tenant_RefID" });
			        while (reader.Read())
			        {
			            ORM_CMN_QST_QuestionItem_StandardAnswerType item = new ORM_CMN_QST_QuestionItem_StandardAnswerType();
						//0:Parameter CMN_QST_QuestionItem_StandardAnswerTypeID of type Guid
						item.CMN_QST_QuestionItem_StandardAnswerTypeID = reader.GetGuid(0);
						//1:Parameter IsBoolean of type Boolean
						item.IsBoolean = reader.GetBoolean(1);
						//2:Parameter IsNumber of type Boolean
						item.IsNumber = reader.GetBoolean(2);
						//3:Parameter IfNumber_IsInteger of type Boolean
						item.IfNumber_IsInteger = reader.GetBoolean(3);
						//4:Parameter IfNumber_Min_Inclusive of type int
						item.IfNumber_Min_Inclusive = reader.GetInteger(4);
						//5:Parameter IfNumber_Max_Exclusive of type int
						item.IfNumber_Max_Exclusive = reader.GetInteger(5);
						//6:Parameter IsShortText of type Boolean
						item.IsShortText = reader.GetBoolean(6);
						//7:Parameter IfShortText_MaxLength of type int
						item.IfShortText_MaxLength = reader.GetInteger(7);
						//8:Parameter IsLongText of type Boolean
						item.IsLongText = reader.GetBoolean(8);
						//9:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(9);
						//10:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(10);
						//11:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(11);


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
