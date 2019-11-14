/* 
 * Generated on 06/02/15 11:09:37
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_HEC_BIL
{
	[Serializable]
	public class ORM_HEC_BIL_BillPosition_BillCode
	{
		public static readonly string TableName = "hec_bil_billposition_billcodes";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_HEC_BIL_BillPosition_BillCode()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_HEC_BIL_BillPosition_BillCodeID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _HEC_BIL_BillPosition_BillCodeID = default(Guid);
		private Guid _PotentialCode_RefID = default(Guid);
		private Guid _BillPosition_RefID = default(Guid);
		private Decimal _TotalPrice_IncludingTax = default(Decimal);
		private double _TotalPointValue = default(double);
		private double _ValueMultiplicator = default(double);
		private String _ValueMultiplicator_Comment = default(String);
		private double _PointValue = default(double);
		private Decimal _UnitPrice_BeforeTax = default(Decimal);
		private Decimal _UnitPrice_IncludingTax = default(Decimal);
		private Decimal _TotalPrice_BeforeTax = default(Decimal);
		private String _IM_BillingCode = default(String);
		private String _IM_BillingCode_Name = default(String);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		private DateTime _Modification_Timestamp = default(DateTime);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid HEC_BIL_BillPosition_BillCodeID { 
			get {
				return _HEC_BIL_BillPosition_BillCodeID;
			}
			set {
				if(_HEC_BIL_BillPosition_BillCodeID != value){
					_HEC_BIL_BillPosition_BillCodeID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid PotentialCode_RefID { 
			get {
				return _PotentialCode_RefID;
			}
			set {
				if(_PotentialCode_RefID != value){
					_PotentialCode_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid BillPosition_RefID { 
			get {
				return _BillPosition_RefID;
			}
			set {
				if(_BillPosition_RefID != value){
					_BillPosition_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Decimal TotalPrice_IncludingTax { 
			get {
				return _TotalPrice_IncludingTax;
			}
			set {
				if(_TotalPrice_IncludingTax != value){
					_TotalPrice_IncludingTax = value;
					Status_IsDirty = true;
				}
			}
		} 
		public double TotalPointValue { 
			get {
				return _TotalPointValue;
			}
			set {
				if(_TotalPointValue != value){
					_TotalPointValue = value;
					Status_IsDirty = true;
				}
			}
		} 
		public double ValueMultiplicator { 
			get {
				return _ValueMultiplicator;
			}
			set {
				if(_ValueMultiplicator != value){
					_ValueMultiplicator = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String ValueMultiplicator_Comment { 
			get {
				return _ValueMultiplicator_Comment;
			}
			set {
				if(_ValueMultiplicator_Comment != value){
					_ValueMultiplicator_Comment = value;
					Status_IsDirty = true;
				}
			}
		} 
		public double PointValue { 
			get {
				return _PointValue;
			}
			set {
				if(_PointValue != value){
					_PointValue = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Decimal UnitPrice_BeforeTax { 
			get {
				return _UnitPrice_BeforeTax;
			}
			set {
				if(_UnitPrice_BeforeTax != value){
					_UnitPrice_BeforeTax = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Decimal UnitPrice_IncludingTax { 
			get {
				return _UnitPrice_IncludingTax;
			}
			set {
				if(_UnitPrice_IncludingTax != value){
					_UnitPrice_IncludingTax = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Decimal TotalPrice_BeforeTax { 
			get {
				return _TotalPrice_BeforeTax;
			}
			set {
				if(_TotalPrice_BeforeTax != value){
					_TotalPrice_BeforeTax = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String IM_BillingCode { 
			get {
				return _IM_BillingCode;
			}
			set {
				if(_IM_BillingCode != value){
					_IM_BillingCode = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String IM_BillingCode_Name { 
			get {
				return _IM_BillingCode_Name;
			}
			set {
				if(_IM_BillingCode_Name != value){
					_IM_BillingCode_Name = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC_BIL.HEC_BIL_BillPosition_BillCode.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC_BIL.HEC_BIL_BillPosition_BillCode.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "HEC_BIL_BillPosition_BillCodeID", _HEC_BIL_BillPosition_BillCodeID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "PotentialCode_RefID", _PotentialCode_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "BillPosition_RefID", _BillPosition_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "TotalPrice_IncludingTax", _TotalPrice_IncludingTax);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "TotalPointValue", _TotalPointValue);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ValueMultiplicator", _ValueMultiplicator);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ValueMultiplicator_Comment", _ValueMultiplicator_Comment);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "PointValue", _PointValue);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "UnitPrice_BeforeTax", _UnitPrice_BeforeTax);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "UnitPrice_IncludingTax", _UnitPrice_IncludingTax);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "TotalPrice_BeforeTax", _TotalPrice_BeforeTax);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IM_BillingCode", _IM_BillingCode);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IM_BillingCode_Name", _IM_BillingCode_Name);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC_BIL.HEC_BIL_BillPosition_BillCode.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_HEC_BIL_BillPosition_BillCodeID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"HEC_BIL_BillPosition_BillCodeID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "HEC_BIL_BillPosition_BillCodeID","PotentialCode_RefID","BillPosition_RefID","TotalPrice_IncludingTax","TotalPointValue","ValueMultiplicator","ValueMultiplicator_Comment","PointValue","UnitPrice_BeforeTax","UnitPrice_IncludingTax","TotalPrice_BeforeTax","IM_BillingCode","IM_BillingCode_Name","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter HEC_BIL_BillPosition_BillCodeID of type Guid
						_HEC_BIL_BillPosition_BillCodeID = reader.GetGuid(0);
						//1:Parameter PotentialCode_RefID of type Guid
						_PotentialCode_RefID = reader.GetGuid(1);
						//2:Parameter BillPosition_RefID of type Guid
						_BillPosition_RefID = reader.GetGuid(2);
						//3:Parameter TotalPrice_IncludingTax of type Decimal
						_TotalPrice_IncludingTax = reader.GetDecimal(3);
						//4:Parameter TotalPointValue of type double
						_TotalPointValue = reader.GetDouble(4);
						//5:Parameter ValueMultiplicator of type double
						_ValueMultiplicator = reader.GetDouble(5);
						//6:Parameter ValueMultiplicator_Comment of type String
						_ValueMultiplicator_Comment = reader.GetString(6);
						//7:Parameter PointValue of type double
						_PointValue = reader.GetDouble(7);
						//8:Parameter UnitPrice_BeforeTax of type Decimal
						_UnitPrice_BeforeTax = reader.GetDecimal(8);
						//9:Parameter UnitPrice_IncludingTax of type Decimal
						_UnitPrice_IncludingTax = reader.GetDecimal(9);
						//10:Parameter TotalPrice_BeforeTax of type Decimal
						_TotalPrice_BeforeTax = reader.GetDecimal(10);
						//11:Parameter IM_BillingCode of type String
						_IM_BillingCode = reader.GetString(11);
						//12:Parameter IM_BillingCode_Name of type String
						_IM_BillingCode_Name = reader.GetString(12);
						//13:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(13);
						//14:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(14);
						//15:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(15);
						//16:Parameter Modification_Timestamp of type DateTime
						_Modification_Timestamp = reader.GetDate(16);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_HEC_BIL_BillPosition_BillCodeID != Guid.Empty){
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
			public Guid? HEC_BIL_BillPosition_BillCodeID {	get; set; }
			public Guid? PotentialCode_RefID {	get; set; }
			public Guid? BillPosition_RefID {	get; set; }
			public Decimal? TotalPrice_IncludingTax {	get; set; }
			public double? TotalPointValue {	get; set; }
			public double? ValueMultiplicator {	get; set; }
			public String ValueMultiplicator_Comment {	get; set; }
			public double? PointValue {	get; set; }
			public Decimal? UnitPrice_BeforeTax {	get; set; }
			public Decimal? UnitPrice_IncludingTax {	get; set; }
			public Decimal? TotalPrice_BeforeTax {	get; set; }
			public String IM_BillingCode {	get; set; }
			public String IM_BillingCode_Name {	get; set; }
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
			public static List<ORM_HEC_BIL_BillPosition_BillCode> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_HEC_BIL_BillPosition_BillCode> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_HEC_BIL_BillPosition_BillCode> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_HEC_BIL_BillPosition_BillCode> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_HEC_BIL_BillPosition_BillCode> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_HEC_BIL_BillPosition_BillCode>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "HEC_BIL_BillPosition_BillCodeID","PotentialCode_RefID","BillPosition_RefID","TotalPrice_IncludingTax","TotalPointValue","ValueMultiplicator","ValueMultiplicator_Comment","PointValue","UnitPrice_BeforeTax","UnitPrice_IncludingTax","TotalPrice_BeforeTax","IM_BillingCode","IM_BillingCode_Name","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
			        while (reader.Read())
			        {
			            ORM_HEC_BIL_BillPosition_BillCode item = new ORM_HEC_BIL_BillPosition_BillCode();
						//0:Parameter HEC_BIL_BillPosition_BillCodeID of type Guid
						item.HEC_BIL_BillPosition_BillCodeID = reader.GetGuid(0);
						//1:Parameter PotentialCode_RefID of type Guid
						item.PotentialCode_RefID = reader.GetGuid(1);
						//2:Parameter BillPosition_RefID of type Guid
						item.BillPosition_RefID = reader.GetGuid(2);
						//3:Parameter TotalPrice_IncludingTax of type Decimal
						item.TotalPrice_IncludingTax = reader.GetDecimal(3);
						//4:Parameter TotalPointValue of type double
						item.TotalPointValue = reader.GetDouble(4);
						//5:Parameter ValueMultiplicator of type double
						item.ValueMultiplicator = reader.GetDouble(5);
						//6:Parameter ValueMultiplicator_Comment of type String
						item.ValueMultiplicator_Comment = reader.GetString(6);
						//7:Parameter PointValue of type double
						item.PointValue = reader.GetDouble(7);
						//8:Parameter UnitPrice_BeforeTax of type Decimal
						item.UnitPrice_BeforeTax = reader.GetDecimal(8);
						//9:Parameter UnitPrice_IncludingTax of type Decimal
						item.UnitPrice_IncludingTax = reader.GetDecimal(9);
						//10:Parameter TotalPrice_BeforeTax of type Decimal
						item.TotalPrice_BeforeTax = reader.GetDecimal(10);
						//11:Parameter IM_BillingCode of type String
						item.IM_BillingCode = reader.GetString(11);
						//12:Parameter IM_BillingCode_Name of type String
						item.IM_BillingCode_Name = reader.GetString(12);
						//13:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(13);
						//14:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(14);
						//15:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(15);
						//16:Parameter Modification_Timestamp of type DateTime
						item.Modification_Timestamp = reader.GetDate(16);


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
