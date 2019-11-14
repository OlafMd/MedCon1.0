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
	public class ORM_CMN_QST_Questionnaire_QuestionItem
	{
		public static readonly string TableName = "cmn_qst_questionnaire_questionitems";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_CMN_QST_Questionnaire_QuestionItem()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_CMN_QST_Questionnaire_ItemID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _CMN_QST_Questionnaire_ItemID = default(Guid);
		private Guid _Questionnaire_Template_RefID = default(Guid);
		private Dict _QuestionItem_Label = new Dict(TableName);
		private Dict _QuestionItem_Description = new Dict(TableName);
		private int _QuestionItem_SequenceNumber = default(int);
		private Boolean _IsAnswer_Standard = default(Boolean);
		private Guid _IfAnswer_StandardType_RefID = default(Guid);
		private Boolean _IsAnswer_Enum = default(Boolean);
		private Guid _IfAnswer_EnumType_RefID = default(Guid);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Boolean _IsDeleted = default(Boolean);
		private Guid _Tenant_RefID = default(Guid);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid CMN_QST_Questionnaire_ItemID { 
			get {
				return _CMN_QST_Questionnaire_ItemID;
			}
			set {
				if(_CMN_QST_Questionnaire_ItemID != value){
					_CMN_QST_Questionnaire_ItemID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Questionnaire_Template_RefID { 
			get {
				return _Questionnaire_Template_RefID;
			}
			set {
				if(_Questionnaire_Template_RefID != value){
					_Questionnaire_Template_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Dict QuestionItem_Label { 
			get {
				return _QuestionItem_Label;
			}
			set {
				if(_QuestionItem_Label != value){
					_QuestionItem_Label = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Dict QuestionItem_Description { 
			get {
				return _QuestionItem_Description;
			}
			set {
				if(_QuestionItem_Description != value){
					_QuestionItem_Description = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int QuestionItem_SequenceNumber { 
			get {
				return _QuestionItem_SequenceNumber;
			}
			set {
				if(_QuestionItem_SequenceNumber != value){
					_QuestionItem_SequenceNumber = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsAnswer_Standard { 
			get {
				return _IsAnswer_Standard;
			}
			set {
				if(_IsAnswer_Standard != value){
					_IsAnswer_Standard = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid IfAnswer_StandardType_RefID { 
			get {
				return _IfAnswer_StandardType_RefID;
			}
			set {
				if(_IfAnswer_StandardType_RefID != value){
					_IfAnswer_StandardType_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsAnswer_Enum { 
			get {
				return _IsAnswer_Enum;
			}
			set {
				if(_IsAnswer_Enum != value){
					_IsAnswer_Enum = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid IfAnswer_EnumType_RefID { 
			get {
				return _IfAnswer_EnumType_RefID;
			}
			set {
				if(_IfAnswer_EnumType_RefID != value){
					_IfAnswer_EnumType_RefID = value;
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

				bool saveDictionary = !Status_IsAlreadySaved || QuestionItem_Label.IsDirty || QuestionItem_Description.IsDirty ;
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
								loader.Append(QuestionItem_Label,TableName);
								loader.Append(QuestionItem_Description,TableName);

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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_QST.CMN_QST_Questionnaire_QuestionItem.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_QST.CMN_QST_Questionnaire_QuestionItem.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_QST_Questionnaire_ItemID", _CMN_QST_Questionnaire_ItemID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Questionnaire_Template_RefID", _Questionnaire_Template_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "QuestionItem_Label", _QuestionItem_Label.DictionaryID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "QuestionItem_Description", _QuestionItem_Description.DictionaryID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "QuestionItem_SequenceNumber", _QuestionItem_SequenceNumber);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsAnswer_Standard", _IsAnswer_Standard);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfAnswer_StandardType_RefID", _IfAnswer_StandardType_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsAnswer_Enum", _IsAnswer_Enum);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfAnswer_EnumType_RefID", _IfAnswer_EnumType_RefID);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_QST.CMN_QST_Questionnaire_QuestionItem.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_CMN_QST_Questionnaire_ItemID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CMN_QST_Questionnaire_ItemID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_QST_Questionnaire_ItemID","Questionnaire_Template_RefID","QuestionItem_Label_DictID","QuestionItem_Description_DictID","QuestionItem_SequenceNumber","IsAnswer_Standard","IfAnswer_StandardType_RefID","IsAnswer_Enum","IfAnswer_EnumType_RefID","Creation_Timestamp","IsDeleted","Tenant_RefID" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter CMN_QST_Questionnaire_ItemID of type Guid
						_CMN_QST_Questionnaire_ItemID = reader.GetGuid(0);
						//1:Parameter Questionnaire_Template_RefID of type Guid
						_Questionnaire_Template_RefID = reader.GetGuid(1);
						//2:Parameter QuestionItem_Label of type Dict
						_QuestionItem_Label = reader.GetDictionary(2);
						loader.Append(_QuestionItem_Label,TableName);
						//3:Parameter QuestionItem_Description of type Dict
						_QuestionItem_Description = reader.GetDictionary(3);
						loader.Append(_QuestionItem_Description,TableName);
						//4:Parameter QuestionItem_SequenceNumber of type int
						_QuestionItem_SequenceNumber = reader.GetInteger(4);
						//5:Parameter IsAnswer_Standard of type Boolean
						_IsAnswer_Standard = reader.GetBoolean(5);
						//6:Parameter IfAnswer_StandardType_RefID of type Guid
						_IfAnswer_StandardType_RefID = reader.GetGuid(6);
						//7:Parameter IsAnswer_Enum of type Boolean
						_IsAnswer_Enum = reader.GetBoolean(7);
						//8:Parameter IfAnswer_EnumType_RefID of type Guid
						_IfAnswer_EnumType_RefID = reader.GetGuid(8);
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

					if(_CMN_QST_Questionnaire_ItemID != Guid.Empty){
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
			public Guid? CMN_QST_Questionnaire_ItemID {	get; set; }
			public Guid? Questionnaire_Template_RefID {	get; set; }
			public Dict QuestionItem_Label {	get; set; }
			public Dict QuestionItem_Description {	get; set; }
			public int? QuestionItem_SequenceNumber {	get; set; }
			public Boolean? IsAnswer_Standard {	get; set; }
			public Guid? IfAnswer_StandardType_RefID {	get; set; }
			public Boolean? IsAnswer_Enum {	get; set; }
			public Guid? IfAnswer_EnumType_RefID {	get; set; }
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
			public static List<ORM_CMN_QST_Questionnaire_QuestionItem> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_CMN_QST_Questionnaire_QuestionItem> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_CMN_QST_Questionnaire_QuestionItem> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_CMN_QST_Questionnaire_QuestionItem> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_CMN_QST_Questionnaire_QuestionItem> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_CMN_QST_Questionnaire_QuestionItem>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_QST_Questionnaire_ItemID","Questionnaire_Template_RefID","QuestionItem_Label_DictID","QuestionItem_Description_DictID","QuestionItem_SequenceNumber","IsAnswer_Standard","IfAnswer_StandardType_RefID","IsAnswer_Enum","IfAnswer_EnumType_RefID","Creation_Timestamp","IsDeleted","Tenant_RefID" });
			        while (reader.Read())
			        {
			            ORM_CMN_QST_Questionnaire_QuestionItem item = new ORM_CMN_QST_Questionnaire_QuestionItem();
						//0:Parameter CMN_QST_Questionnaire_ItemID of type Guid
						item.CMN_QST_Questionnaire_ItemID = reader.GetGuid(0);
						//1:Parameter Questionnaire_Template_RefID of type Guid
						item.Questionnaire_Template_RefID = reader.GetGuid(1);
						//2:Parameter QuestionItem_Label of type Dict
						item.QuestionItem_Label = reader.GetDictionary(2);
						loader.Append(item.QuestionItem_Label,TableName);
						//3:Parameter QuestionItem_Description of type Dict
						item.QuestionItem_Description = reader.GetDictionary(3);
						loader.Append(item.QuestionItem_Description,TableName);
						//4:Parameter QuestionItem_SequenceNumber of type int
						item.QuestionItem_SequenceNumber = reader.GetInteger(4);
						//5:Parameter IsAnswer_Standard of type Boolean
						item.IsAnswer_Standard = reader.GetBoolean(5);
						//6:Parameter IfAnswer_StandardType_RefID of type Guid
						item.IfAnswer_StandardType_RefID = reader.GetGuid(6);
						//7:Parameter IsAnswer_Enum of type Boolean
						item.IsAnswer_Enum = reader.GetBoolean(7);
						//8:Parameter IfAnswer_EnumType_RefID of type Guid
						item.IfAnswer_EnumType_RefID = reader.GetGuid(8);
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
