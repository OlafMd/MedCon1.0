/* 
 * Generated on 6/20/2013 10:43:50 AM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_RES_QST
{
	[Serializable]
	public class ORM_RES_QST_Questionnaire_Version
	{
		public static readonly string TableName = "res_qst_questionnaire_version";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_RES_QST_Questionnaire_Version()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_RES_QST_Questionnaire_VersionID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _RES_QST_Questionnaire_VersionID = default(Guid);
		private Guid _Questionnaire_RefID = default(Guid);
		private String _QuestionnaireVersion_Comment = default(String);
		private int _QuestionnaireVersion_VersionNumber = default(int);
		private Boolean _IsApartmentStructureVisible = default(Boolean);
		private Boolean _IsStaircaseStructureVisible = default(Boolean);
		private Boolean _IsOutdoorFacilityVisible = default(Boolean);
		private Boolean _IsFacadeVisible = default(Boolean);
		private Boolean _IsRoofVisible = default(Boolean);
		private Boolean _IsAtticVisible = default(Boolean);
		private Boolean _IsBasementVisible = default(Boolean);
		private Boolean _IsHVACRVisible = default(Boolean);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Boolean _IsDeleted = default(Boolean);
		private Guid _Tenant_RefID = default(Guid);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid RES_QST_Questionnaire_VersionID { 
			get {
				return _RES_QST_Questionnaire_VersionID;
			}
			set {
				if(_RES_QST_Questionnaire_VersionID != value){
					_RES_QST_Questionnaire_VersionID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Questionnaire_RefID { 
			get {
				return _Questionnaire_RefID;
			}
			set {
				if(_Questionnaire_RefID != value){
					_Questionnaire_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String QuestionnaireVersion_Comment { 
			get {
				return _QuestionnaireVersion_Comment;
			}
			set {
				if(_QuestionnaireVersion_Comment != value){
					_QuestionnaireVersion_Comment = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int QuestionnaireVersion_VersionNumber { 
			get {
				return _QuestionnaireVersion_VersionNumber;
			}
			set {
				if(_QuestionnaireVersion_VersionNumber != value){
					_QuestionnaireVersion_VersionNumber = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsApartmentStructureVisible { 
			get {
				return _IsApartmentStructureVisible;
			}
			set {
				if(_IsApartmentStructureVisible != value){
					_IsApartmentStructureVisible = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsStaircaseStructureVisible { 
			get {
				return _IsStaircaseStructureVisible;
			}
			set {
				if(_IsStaircaseStructureVisible != value){
					_IsStaircaseStructureVisible = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsOutdoorFacilityVisible { 
			get {
				return _IsOutdoorFacilityVisible;
			}
			set {
				if(_IsOutdoorFacilityVisible != value){
					_IsOutdoorFacilityVisible = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsFacadeVisible { 
			get {
				return _IsFacadeVisible;
			}
			set {
				if(_IsFacadeVisible != value){
					_IsFacadeVisible = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsRoofVisible { 
			get {
				return _IsRoofVisible;
			}
			set {
				if(_IsRoofVisible != value){
					_IsRoofVisible = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsAtticVisible { 
			get {
				return _IsAtticVisible;
			}
			set {
				if(_IsAtticVisible != value){
					_IsAtticVisible = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsBasementVisible { 
			get {
				return _IsBasementVisible;
			}
			set {
				if(_IsBasementVisible != value){
					_IsBasementVisible = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsHVACRVisible { 
			get {
				return _IsHVACRVisible;
			}
			set {
				if(_IsHVACRVisible != value){
					_IsHVACRVisible = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_RES_QST.RES_QST_Questionnaire_Version.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_RES_QST.RES_QST_Questionnaire_Version.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "RES_QST_Questionnaire_VersionID", _RES_QST_Questionnaire_VersionID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Questionnaire_RefID", _Questionnaire_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "QuestionnaireVersion_Comment", _QuestionnaireVersion_Comment);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "QuestionnaireVersion_VersionNumber", _QuestionnaireVersion_VersionNumber);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsApartmentStructureVisible", _IsApartmentStructureVisible);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsStaircaseStructureVisible", _IsStaircaseStructureVisible);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsOutdoorFacilityVisible", _IsOutdoorFacilityVisible);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsFacadeVisible", _IsFacadeVisible);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsRoofVisible", _IsRoofVisible);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsAtticVisible", _IsAtticVisible);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsBasementVisible", _IsBasementVisible);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsHVACRVisible", _IsHVACRVisible);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_RES_QST.RES_QST_Questionnaire_Version.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_RES_QST_Questionnaire_VersionID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"RES_QST_Questionnaire_VersionID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "RES_QST_Questionnaire_VersionID","Questionnaire_RefID","QuestionnaireVersion_Comment","QuestionnaireVersion_VersionNumber","IsApartmentStructureVisible","IsStaircaseStructureVisible","IsOutdoorFacilityVisible","IsFacadeVisible","IsRoofVisible","IsAtticVisible","IsBasementVisible","IsHVACRVisible","Creation_Timestamp","IsDeleted","Tenant_RefID" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter RES_QST_Questionnaire_VersionID of type Guid
						_RES_QST_Questionnaire_VersionID = reader.GetGuid(0);
						//1:Parameter Questionnaire_RefID of type Guid
						_Questionnaire_RefID = reader.GetGuid(1);
						//2:Parameter QuestionnaireVersion_Comment of type String
						_QuestionnaireVersion_Comment = reader.GetString(2);
						//3:Parameter QuestionnaireVersion_VersionNumber of type int
						_QuestionnaireVersion_VersionNumber = reader.GetInteger(3);
						//4:Parameter IsApartmentStructureVisible of type Boolean
						_IsApartmentStructureVisible = reader.GetBoolean(4);
						//5:Parameter IsStaircaseStructureVisible of type Boolean
						_IsStaircaseStructureVisible = reader.GetBoolean(5);
						//6:Parameter IsOutdoorFacilityVisible of type Boolean
						_IsOutdoorFacilityVisible = reader.GetBoolean(6);
						//7:Parameter IsFacadeVisible of type Boolean
						_IsFacadeVisible = reader.GetBoolean(7);
						//8:Parameter IsRoofVisible of type Boolean
						_IsRoofVisible = reader.GetBoolean(8);
						//9:Parameter IsAtticVisible of type Boolean
						_IsAtticVisible = reader.GetBoolean(9);
						//10:Parameter IsBasementVisible of type Boolean
						_IsBasementVisible = reader.GetBoolean(10);
						//11:Parameter IsHVACRVisible of type Boolean
						_IsHVACRVisible = reader.GetBoolean(11);
						//12:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(12);
						//13:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(13);
						//14:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(14);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_RES_QST_Questionnaire_VersionID != Guid.Empty){
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
			public Guid? RES_QST_Questionnaire_VersionID {	get; set; }
			public Guid? Questionnaire_RefID {	get; set; }
			public String QuestionnaireVersion_Comment {	get; set; }
			public int? QuestionnaireVersion_VersionNumber {	get; set; }
			public Boolean? IsApartmentStructureVisible {	get; set; }
			public Boolean? IsStaircaseStructureVisible {	get; set; }
			public Boolean? IsOutdoorFacilityVisible {	get; set; }
			public Boolean? IsFacadeVisible {	get; set; }
			public Boolean? IsRoofVisible {	get; set; }
			public Boolean? IsAtticVisible {	get; set; }
			public Boolean? IsBasementVisible {	get; set; }
			public Boolean? IsHVACRVisible {	get; set; }
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
			public static List<ORM_RES_QST_Questionnaire_Version> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_RES_QST_Questionnaire_Version> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_RES_QST_Questionnaire_Version> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_RES_QST_Questionnaire_Version> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_RES_QST_Questionnaire_Version> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_RES_QST_Questionnaire_Version>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "RES_QST_Questionnaire_VersionID","Questionnaire_RefID","QuestionnaireVersion_Comment","QuestionnaireVersion_VersionNumber","IsApartmentStructureVisible","IsStaircaseStructureVisible","IsOutdoorFacilityVisible","IsFacadeVisible","IsRoofVisible","IsAtticVisible","IsBasementVisible","IsHVACRVisible","Creation_Timestamp","IsDeleted","Tenant_RefID" });
			        while (reader.Read())
			        {
			            ORM_RES_QST_Questionnaire_Version item = new ORM_RES_QST_Questionnaire_Version();
						//0:Parameter RES_QST_Questionnaire_VersionID of type Guid
						item.RES_QST_Questionnaire_VersionID = reader.GetGuid(0);
						//1:Parameter Questionnaire_RefID of type Guid
						item.Questionnaire_RefID = reader.GetGuid(1);
						//2:Parameter QuestionnaireVersion_Comment of type String
						item.QuestionnaireVersion_Comment = reader.GetString(2);
						//3:Parameter QuestionnaireVersion_VersionNumber of type int
						item.QuestionnaireVersion_VersionNumber = reader.GetInteger(3);
						//4:Parameter IsApartmentStructureVisible of type Boolean
						item.IsApartmentStructureVisible = reader.GetBoolean(4);
						//5:Parameter IsStaircaseStructureVisible of type Boolean
						item.IsStaircaseStructureVisible = reader.GetBoolean(5);
						//6:Parameter IsOutdoorFacilityVisible of type Boolean
						item.IsOutdoorFacilityVisible = reader.GetBoolean(6);
						//7:Parameter IsFacadeVisible of type Boolean
						item.IsFacadeVisible = reader.GetBoolean(7);
						//8:Parameter IsRoofVisible of type Boolean
						item.IsRoofVisible = reader.GetBoolean(8);
						//9:Parameter IsAtticVisible of type Boolean
						item.IsAtticVisible = reader.GetBoolean(9);
						//10:Parameter IsBasementVisible of type Boolean
						item.IsBasementVisible = reader.GetBoolean(10);
						//11:Parameter IsHVACRVisible of type Boolean
						item.IsHVACRVisible = reader.GetBoolean(11);
						//12:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(12);
						//13:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(13);
						//14:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(14);


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
