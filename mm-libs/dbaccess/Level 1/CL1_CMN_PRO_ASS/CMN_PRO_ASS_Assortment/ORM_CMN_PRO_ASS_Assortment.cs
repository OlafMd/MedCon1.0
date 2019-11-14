/* 
 * Generated on 2/10/2015 3:48:26 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_CMN_PRO_ASS
{
	[Serializable]
	public class ORM_CMN_PRO_ASS_Assortment
	{
		public static readonly string TableName = "cmn_pro_ass_assortments";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_CMN_PRO_ASS_Assortment()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_CMN_PRO_ASS_AssortmentID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _CMN_PRO_ASS_AssortmentID = default(Guid);
		private Dict _AssortmentName = new Dict(TableName);
		private DateTime _AvailableForSalesFrom = default(DateTime);
		private DateTime _AvailableForSalesThrough = default(DateTime);
		private DateTime _AvailableForOrderingFrom = default(DateTime);
		private DateTime _AvailableForOrderingThrough = default(DateTime);
		private Boolean _IsForInternalDistribution = default(Boolean);
		private Boolean _IsDefaultAssortment_ForCostcenterOrder = default(Boolean);
		private Boolean _IsDefaultAssortment_ForOfficeOrder = default(Boolean);
		private Boolean _IsDefaultAssortment_ForPersonalOrder = default(Boolean);
		private Boolean _IsDefaultAssortment_ForWarehouseOrder = default(Boolean);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		private DateTime _Modification_Timestamp = default(DateTime);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid CMN_PRO_ASS_AssortmentID { 
			get {
				return _CMN_PRO_ASS_AssortmentID;
			}
			set {
				if(_CMN_PRO_ASS_AssortmentID != value){
					_CMN_PRO_ASS_AssortmentID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Dict AssortmentName { 
			get {
				return _AssortmentName;
			}
			set {
				if(_AssortmentName != value){
					_AssortmentName = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime AvailableForSalesFrom { 
			get {
				return _AvailableForSalesFrom;
			}
			set {
				if(_AvailableForSalesFrom != value){
					_AvailableForSalesFrom = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime AvailableForSalesThrough { 
			get {
				return _AvailableForSalesThrough;
			}
			set {
				if(_AvailableForSalesThrough != value){
					_AvailableForSalesThrough = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime AvailableForOrderingFrom { 
			get {
				return _AvailableForOrderingFrom;
			}
			set {
				if(_AvailableForOrderingFrom != value){
					_AvailableForOrderingFrom = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime AvailableForOrderingThrough { 
			get {
				return _AvailableForOrderingThrough;
			}
			set {
				if(_AvailableForOrderingThrough != value){
					_AvailableForOrderingThrough = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsForInternalDistribution { 
			get {
				return _IsForInternalDistribution;
			}
			set {
				if(_IsForInternalDistribution != value){
					_IsForInternalDistribution = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsDefaultAssortment_ForCostcenterOrder { 
			get {
				return _IsDefaultAssortment_ForCostcenterOrder;
			}
			set {
				if(_IsDefaultAssortment_ForCostcenterOrder != value){
					_IsDefaultAssortment_ForCostcenterOrder = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsDefaultAssortment_ForOfficeOrder { 
			get {
				return _IsDefaultAssortment_ForOfficeOrder;
			}
			set {
				if(_IsDefaultAssortment_ForOfficeOrder != value){
					_IsDefaultAssortment_ForOfficeOrder = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsDefaultAssortment_ForPersonalOrder { 
			get {
				return _IsDefaultAssortment_ForPersonalOrder;
			}
			set {
				if(_IsDefaultAssortment_ForPersonalOrder != value){
					_IsDefaultAssortment_ForPersonalOrder = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsDefaultAssortment_ForWarehouseOrder { 
			get {
				return _IsDefaultAssortment_ForWarehouseOrder;
			}
			set {
				if(_IsDefaultAssortment_ForWarehouseOrder != value){
					_IsDefaultAssortment_ForWarehouseOrder = value;
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

				bool saveDictionary = !Status_IsAlreadySaved || AssortmentName.IsDirty ;
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
								loader.Append(AssortmentName,TableName);

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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_PRO_ASS.CMN_PRO_ASS_Assortment.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_PRO_ASS.CMN_PRO_ASS_Assortment.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_PRO_ASS_AssortmentID", _CMN_PRO_ASS_AssortmentID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "AssortmentName", _AssortmentName.DictionaryID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "AvailableForSalesFrom", _AvailableForSalesFrom);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "AvailableForSalesThrough", _AvailableForSalesThrough);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "AvailableForOrderingFrom", _AvailableForOrderingFrom);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "AvailableForOrderingThrough", _AvailableForOrderingThrough);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsForInternalDistribution", _IsForInternalDistribution);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsDefaultAssortment_ForCostcenterOrder", _IsDefaultAssortment_ForCostcenterOrder);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsDefaultAssortment_ForOfficeOrder", _IsDefaultAssortment_ForOfficeOrder);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsDefaultAssortment_ForPersonalOrder", _IsDefaultAssortment_ForPersonalOrder);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsDefaultAssortment_ForWarehouseOrder", _IsDefaultAssortment_ForWarehouseOrder);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_PRO_ASS.CMN_PRO_ASS_Assortment.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_CMN_PRO_ASS_AssortmentID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CMN_PRO_ASS_AssortmentID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_PRO_ASS_AssortmentID","AssortmentName_DictID","AvailableForSalesFrom","AvailableForSalesThrough","AvailableForOrderingFrom","AvailableForOrderingThrough","IsForInternalDistribution","IsDefaultAssortment_ForCostcenterOrder","IsDefaultAssortment_ForOfficeOrder","IsDefaultAssortment_ForPersonalOrder","IsDefaultAssortment_ForWarehouseOrder","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter CMN_PRO_ASS_AssortmentID of type Guid
						_CMN_PRO_ASS_AssortmentID = reader.GetGuid(0);
						//1:Parameter AssortmentName of type Dict
						_AssortmentName = reader.GetDictionary(1);
						loader.Append(_AssortmentName,TableName);
						//2:Parameter AvailableForSalesFrom of type DateTime
						_AvailableForSalesFrom = reader.GetDate(2);
						//3:Parameter AvailableForSalesThrough of type DateTime
						_AvailableForSalesThrough = reader.GetDate(3);
						//4:Parameter AvailableForOrderingFrom of type DateTime
						_AvailableForOrderingFrom = reader.GetDate(4);
						//5:Parameter AvailableForOrderingThrough of type DateTime
						_AvailableForOrderingThrough = reader.GetDate(5);
						//6:Parameter IsForInternalDistribution of type Boolean
						_IsForInternalDistribution = reader.GetBoolean(6);
						//7:Parameter IsDefaultAssortment_ForCostcenterOrder of type Boolean
						_IsDefaultAssortment_ForCostcenterOrder = reader.GetBoolean(7);
						//8:Parameter IsDefaultAssortment_ForOfficeOrder of type Boolean
						_IsDefaultAssortment_ForOfficeOrder = reader.GetBoolean(8);
						//9:Parameter IsDefaultAssortment_ForPersonalOrder of type Boolean
						_IsDefaultAssortment_ForPersonalOrder = reader.GetBoolean(9);
						//10:Parameter IsDefaultAssortment_ForWarehouseOrder of type Boolean
						_IsDefaultAssortment_ForWarehouseOrder = reader.GetBoolean(10);
						//11:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(11);
						//12:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(12);
						//13:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(13);
						//14:Parameter Modification_Timestamp of type DateTime
						_Modification_Timestamp = reader.GetDate(14);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_CMN_PRO_ASS_AssortmentID != Guid.Empty){
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
			public Guid? CMN_PRO_ASS_AssortmentID {	get; set; }
			public Dict AssortmentName {	get; set; }
			public DateTime? AvailableForSalesFrom {	get; set; }
			public DateTime? AvailableForSalesThrough {	get; set; }
			public DateTime? AvailableForOrderingFrom {	get; set; }
			public DateTime? AvailableForOrderingThrough {	get; set; }
			public Boolean? IsForInternalDistribution {	get; set; }
			public Boolean? IsDefaultAssortment_ForCostcenterOrder {	get; set; }
			public Boolean? IsDefaultAssortment_ForOfficeOrder {	get; set; }
			public Boolean? IsDefaultAssortment_ForPersonalOrder {	get; set; }
			public Boolean? IsDefaultAssortment_ForWarehouseOrder {	get; set; }
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
			public static List<ORM_CMN_PRO_ASS_Assortment> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_CMN_PRO_ASS_Assortment> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_CMN_PRO_ASS_Assortment> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_CMN_PRO_ASS_Assortment> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_CMN_PRO_ASS_Assortment> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_CMN_PRO_ASS_Assortment>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_PRO_ASS_AssortmentID","AssortmentName_DictID","AvailableForSalesFrom","AvailableForSalesThrough","AvailableForOrderingFrom","AvailableForOrderingThrough","IsForInternalDistribution","IsDefaultAssortment_ForCostcenterOrder","IsDefaultAssortment_ForOfficeOrder","IsDefaultAssortment_ForPersonalOrder","IsDefaultAssortment_ForWarehouseOrder","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
			        while (reader.Read())
			        {
			            ORM_CMN_PRO_ASS_Assortment item = new ORM_CMN_PRO_ASS_Assortment();
						//0:Parameter CMN_PRO_ASS_AssortmentID of type Guid
						item.CMN_PRO_ASS_AssortmentID = reader.GetGuid(0);
						//1:Parameter AssortmentName of type Dict
						item.AssortmentName = reader.GetDictionary(1);
						loader.Append(item.AssortmentName,TableName);
						//2:Parameter AvailableForSalesFrom of type DateTime
						item.AvailableForSalesFrom = reader.GetDate(2);
						//3:Parameter AvailableForSalesThrough of type DateTime
						item.AvailableForSalesThrough = reader.GetDate(3);
						//4:Parameter AvailableForOrderingFrom of type DateTime
						item.AvailableForOrderingFrom = reader.GetDate(4);
						//5:Parameter AvailableForOrderingThrough of type DateTime
						item.AvailableForOrderingThrough = reader.GetDate(5);
						//6:Parameter IsForInternalDistribution of type Boolean
						item.IsForInternalDistribution = reader.GetBoolean(6);
						//7:Parameter IsDefaultAssortment_ForCostcenterOrder of type Boolean
						item.IsDefaultAssortment_ForCostcenterOrder = reader.GetBoolean(7);
						//8:Parameter IsDefaultAssortment_ForOfficeOrder of type Boolean
						item.IsDefaultAssortment_ForOfficeOrder = reader.GetBoolean(8);
						//9:Parameter IsDefaultAssortment_ForPersonalOrder of type Boolean
						item.IsDefaultAssortment_ForPersonalOrder = reader.GetBoolean(9);
						//10:Parameter IsDefaultAssortment_ForWarehouseOrder of type Boolean
						item.IsDefaultAssortment_ForWarehouseOrder = reader.GetBoolean(10);
						//11:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(11);
						//12:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(12);
						//13:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(13);
						//14:Parameter Modification_Timestamp of type DateTime
						item.Modification_Timestamp = reader.GetDate(14);


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
