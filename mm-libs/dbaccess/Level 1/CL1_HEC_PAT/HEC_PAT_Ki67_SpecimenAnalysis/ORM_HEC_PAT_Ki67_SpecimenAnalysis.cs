/* 
 * Generated on 6/18/2013 5:00:15 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_HEC_PAT
{
	[Serializable]
	public class ORM_HEC_PAT_Ki67_SpecimenAnalysis
	{
		public static readonly string TableName = "hec_pat_ki67_specimenanalysis";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_HEC_PAT_Ki67_SpecimenAnalysis()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_HEC_PAT_Ki67_SpecimenAnalysisID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _HEC_PAT_Ki67_SpecimenAnalysisID = default(Guid);
		private String _Analysis_Name = default(String);
		private Guid _AnalysisPersistedBy_Account_RefID = default(Guid);
		private Guid _Specimen_RefID = default(Guid);
		private String _AnalysisResults = default(String);
		private Guid _CellMap_Document_RefID = default(Guid);
		private Guid _MarkupNoFill_Document_RefID = default(Guid);
		private Guid _MarkupFill_Document_RefID = default(Guid);
		private Boolean _IsReportCreated = default(Boolean);
		private Guid _IfReportCreated_Report_Document_RefID = default(Guid);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Boolean _IsDeleted = default(Boolean);
		private Guid _Tenant_RefID = default(Guid);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid HEC_PAT_Ki67_SpecimenAnalysisID { 
			get {
				return _HEC_PAT_Ki67_SpecimenAnalysisID;
			}
			set {
				if(_HEC_PAT_Ki67_SpecimenAnalysisID != value){
					_HEC_PAT_Ki67_SpecimenAnalysisID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String Analysis_Name { 
			get {
				return _Analysis_Name;
			}
			set {
				if(_Analysis_Name != value){
					_Analysis_Name = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid AnalysisPersistedBy_Account_RefID { 
			get {
				return _AnalysisPersistedBy_Account_RefID;
			}
			set {
				if(_AnalysisPersistedBy_Account_RefID != value){
					_AnalysisPersistedBy_Account_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Specimen_RefID { 
			get {
				return _Specimen_RefID;
			}
			set {
				if(_Specimen_RefID != value){
					_Specimen_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String AnalysisResults { 
			get {
				return _AnalysisResults;
			}
			set {
				if(_AnalysisResults != value){
					_AnalysisResults = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid CellMap_Document_RefID { 
			get {
				return _CellMap_Document_RefID;
			}
			set {
				if(_CellMap_Document_RefID != value){
					_CellMap_Document_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid MarkupNoFill_Document_RefID { 
			get {
				return _MarkupNoFill_Document_RefID;
			}
			set {
				if(_MarkupNoFill_Document_RefID != value){
					_MarkupNoFill_Document_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid MarkupFill_Document_RefID { 
			get {
				return _MarkupFill_Document_RefID;
			}
			set {
				if(_MarkupFill_Document_RefID != value){
					_MarkupFill_Document_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsReportCreated { 
			get {
				return _IsReportCreated;
			}
			set {
				if(_IsReportCreated != value){
					_IsReportCreated = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid IfReportCreated_Report_Document_RefID { 
			get {
				return _IfReportCreated_Report_Document_RefID;
			}
			set {
				if(_IfReportCreated_Report_Document_RefID != value){
					_IfReportCreated_Report_Document_RefID = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC_PAT.HEC_PAT_Ki67_SpecimenAnalysis.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC_PAT.HEC_PAT_Ki67_SpecimenAnalysis.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "HEC_PAT_Ki67_SpecimenAnalysisID", _HEC_PAT_Ki67_SpecimenAnalysisID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Analysis_Name", _Analysis_Name);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "AnalysisPersistedBy_Account_RefID", _AnalysisPersistedBy_Account_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Specimen_RefID", _Specimen_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "AnalysisResults", _AnalysisResults);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CellMap_Document_RefID", _CellMap_Document_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "MarkupNoFill_Document_RefID", _MarkupNoFill_Document_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "MarkupFill_Document_RefID", _MarkupFill_Document_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsReportCreated", _IsReportCreated);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfReportCreated_Report_Document_RefID", _IfReportCreated_Report_Document_RefID);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC_PAT.HEC_PAT_Ki67_SpecimenAnalysis.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_HEC_PAT_Ki67_SpecimenAnalysisID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"HEC_PAT_Ki67_SpecimenAnalysisID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "HEC_PAT_Ki67_SpecimenAnalysisID","Analysis_Name","AnalysisPersistedBy_Account_RefID","Specimen_RefID","AnalysisResults","CellMap_Document_RefID","MarkupNoFill_Document_RefID","MarkupFill_Document_RefID","IsReportCreated","IfReportCreated_Report_Document_RefID","Creation_Timestamp","IsDeleted","Tenant_RefID" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter HEC_PAT_Ki67_SpecimenAnalysisID of type Guid
						_HEC_PAT_Ki67_SpecimenAnalysisID = reader.GetGuid(0);
						//1:Parameter Analysis_Name of type String
						_Analysis_Name = reader.GetString(1);
						//2:Parameter AnalysisPersistedBy_Account_RefID of type Guid
						_AnalysisPersistedBy_Account_RefID = reader.GetGuid(2);
						//3:Parameter Specimen_RefID of type Guid
						_Specimen_RefID = reader.GetGuid(3);
						//4:Parameter AnalysisResults of type String
						_AnalysisResults = reader.GetString(4);
						//5:Parameter CellMap_Document_RefID of type Guid
						_CellMap_Document_RefID = reader.GetGuid(5);
						//6:Parameter MarkupNoFill_Document_RefID of type Guid
						_MarkupNoFill_Document_RefID = reader.GetGuid(6);
						//7:Parameter MarkupFill_Document_RefID of type Guid
						_MarkupFill_Document_RefID = reader.GetGuid(7);
						//8:Parameter IsReportCreated of type Boolean
						_IsReportCreated = reader.GetBoolean(8);
						//9:Parameter IfReportCreated_Report_Document_RefID of type Guid
						_IfReportCreated_Report_Document_RefID = reader.GetGuid(9);
						//10:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(10);
						//11:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(11);
						//12:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(12);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_HEC_PAT_Ki67_SpecimenAnalysisID != Guid.Empty){
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
			public Guid? HEC_PAT_Ki67_SpecimenAnalysisID {	get; set; }
			public String Analysis_Name {	get; set; }
			public Guid? AnalysisPersistedBy_Account_RefID {	get; set; }
			public Guid? Specimen_RefID {	get; set; }
			public String AnalysisResults {	get; set; }
			public Guid? CellMap_Document_RefID {	get; set; }
			public Guid? MarkupNoFill_Document_RefID {	get; set; }
			public Guid? MarkupFill_Document_RefID {	get; set; }
			public Boolean? IsReportCreated {	get; set; }
			public Guid? IfReportCreated_Report_Document_RefID {	get; set; }
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
			public static List<ORM_HEC_PAT_Ki67_SpecimenAnalysis> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_HEC_PAT_Ki67_SpecimenAnalysis> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_HEC_PAT_Ki67_SpecimenAnalysis> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_HEC_PAT_Ki67_SpecimenAnalysis> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_HEC_PAT_Ki67_SpecimenAnalysis> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_HEC_PAT_Ki67_SpecimenAnalysis>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "HEC_PAT_Ki67_SpecimenAnalysisID","Analysis_Name","AnalysisPersistedBy_Account_RefID","Specimen_RefID","AnalysisResults","CellMap_Document_RefID","MarkupNoFill_Document_RefID","MarkupFill_Document_RefID","IsReportCreated","IfReportCreated_Report_Document_RefID","Creation_Timestamp","IsDeleted","Tenant_RefID" });
			        while (reader.Read())
			        {
			            ORM_HEC_PAT_Ki67_SpecimenAnalysis item = new ORM_HEC_PAT_Ki67_SpecimenAnalysis();
						//0:Parameter HEC_PAT_Ki67_SpecimenAnalysisID of type Guid
						item.HEC_PAT_Ki67_SpecimenAnalysisID = reader.GetGuid(0);
						//1:Parameter Analysis_Name of type String
						item.Analysis_Name = reader.GetString(1);
						//2:Parameter AnalysisPersistedBy_Account_RefID of type Guid
						item.AnalysisPersistedBy_Account_RefID = reader.GetGuid(2);
						//3:Parameter Specimen_RefID of type Guid
						item.Specimen_RefID = reader.GetGuid(3);
						//4:Parameter AnalysisResults of type String
						item.AnalysisResults = reader.GetString(4);
						//5:Parameter CellMap_Document_RefID of type Guid
						item.CellMap_Document_RefID = reader.GetGuid(5);
						//6:Parameter MarkupNoFill_Document_RefID of type Guid
						item.MarkupNoFill_Document_RefID = reader.GetGuid(6);
						//7:Parameter MarkupFill_Document_RefID of type Guid
						item.MarkupFill_Document_RefID = reader.GetGuid(7);
						//8:Parameter IsReportCreated of type Boolean
						item.IsReportCreated = reader.GetBoolean(8);
						//9:Parameter IfReportCreated_Report_Document_RefID of type Guid
						item.IfReportCreated_Report_Document_RefID = reader.GetGuid(9);
						//10:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(10);
						//11:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(11);
						//12:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(12);


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
