/* 
 * Generated on 06/02/15 11:09:02
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_BIL
{
	[Serializable]
	public class ORM_BIL_BillPosition
	{
		public static readonly string TableName = "bil_billpositions";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_BIL_BillPosition()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_BIL_BillPositionID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _BIL_BillPositionID = default(Guid);
		private Guid _BIL_BilHeader_RefID = default(Guid);
		private Guid _BIL_BillPosition_Group_RefID = default(Guid);
		private Guid _ApplicableSalesTax_RefID = default(Guid);
		private Decimal _ApplicableSalesTax_Value = default(Decimal);
		private Decimal _ApplicableSalesTax_PerUnitValue = default(Decimal);
		private String _PositionNumber = default(String);
		private String _BillPosition_Description = default(String);
		private String _BillPosition_Comment = default(String);
		private int _PositionIndex = default(int);
		private Decimal _PositionValue_BeforeTax = default(Decimal);
		private Decimal _PositionValue_IncludingTax = default(Decimal);
		private Decimal _PositionPricePerUnitValue_BeforeTax = default(Decimal);
		private Decimal _PositionPricePerUnitValue_IncludingTax = default(Decimal);
		private String _BillPosition_ProductNumber = default(String);
		private double _Quantity = default(double);
		private String _External_PositionReferenceField = default(String);
		private String _External_PositionCode = default(String);
		private String _External_PositionType = default(String);
		private Boolean _IsFullyPaid = default(Boolean);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		private DateTime _Modification_Timestamp = default(DateTime);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid BIL_BillPositionID { 
			get {
				return _BIL_BillPositionID;
			}
			set {
				if(_BIL_BillPositionID != value){
					_BIL_BillPositionID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid BIL_BilHeader_RefID { 
			get {
				return _BIL_BilHeader_RefID;
			}
			set {
				if(_BIL_BilHeader_RefID != value){
					_BIL_BilHeader_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid BIL_BillPosition_Group_RefID { 
			get {
				return _BIL_BillPosition_Group_RefID;
			}
			set {
				if(_BIL_BillPosition_Group_RefID != value){
					_BIL_BillPosition_Group_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid ApplicableSalesTax_RefID { 
			get {
				return _ApplicableSalesTax_RefID;
			}
			set {
				if(_ApplicableSalesTax_RefID != value){
					_ApplicableSalesTax_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Decimal ApplicableSalesTax_Value { 
			get {
				return _ApplicableSalesTax_Value;
			}
			set {
				if(_ApplicableSalesTax_Value != value){
					_ApplicableSalesTax_Value = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Decimal ApplicableSalesTax_PerUnitValue { 
			get {
				return _ApplicableSalesTax_PerUnitValue;
			}
			set {
				if(_ApplicableSalesTax_PerUnitValue != value){
					_ApplicableSalesTax_PerUnitValue = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String PositionNumber { 
			get {
				return _PositionNumber;
			}
			set {
				if(_PositionNumber != value){
					_PositionNumber = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String BillPosition_Description { 
			get {
				return _BillPosition_Description;
			}
			set {
				if(_BillPosition_Description != value){
					_BillPosition_Description = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String BillPosition_Comment { 
			get {
				return _BillPosition_Comment;
			}
			set {
				if(_BillPosition_Comment != value){
					_BillPosition_Comment = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int PositionIndex { 
			get {
				return _PositionIndex;
			}
			set {
				if(_PositionIndex != value){
					_PositionIndex = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Decimal PositionValue_BeforeTax { 
			get {
				return _PositionValue_BeforeTax;
			}
			set {
				if(_PositionValue_BeforeTax != value){
					_PositionValue_BeforeTax = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Decimal PositionValue_IncludingTax { 
			get {
				return _PositionValue_IncludingTax;
			}
			set {
				if(_PositionValue_IncludingTax != value){
					_PositionValue_IncludingTax = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Decimal PositionPricePerUnitValue_BeforeTax { 
			get {
				return _PositionPricePerUnitValue_BeforeTax;
			}
			set {
				if(_PositionPricePerUnitValue_BeforeTax != value){
					_PositionPricePerUnitValue_BeforeTax = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Decimal PositionPricePerUnitValue_IncludingTax { 
			get {
				return _PositionPricePerUnitValue_IncludingTax;
			}
			set {
				if(_PositionPricePerUnitValue_IncludingTax != value){
					_PositionPricePerUnitValue_IncludingTax = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String BillPosition_ProductNumber { 
			get {
				return _BillPosition_ProductNumber;
			}
			set {
				if(_BillPosition_ProductNumber != value){
					_BillPosition_ProductNumber = value;
					Status_IsDirty = true;
				}
			}
		} 
		public double Quantity { 
			get {
				return _Quantity;
			}
			set {
				if(_Quantity != value){
					_Quantity = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String External_PositionReferenceField { 
			get {
				return _External_PositionReferenceField;
			}
			set {
				if(_External_PositionReferenceField != value){
					_External_PositionReferenceField = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String External_PositionCode { 
			get {
				return _External_PositionCode;
			}
			set {
				if(_External_PositionCode != value){
					_External_PositionCode = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String External_PositionType { 
			get {
				return _External_PositionType;
			}
			set {
				if(_External_PositionType != value){
					_External_PositionType = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsFullyPaid { 
			get {
				return _IsFullyPaid;
			}
			set {
				if(_IsFullyPaid != value){
					_IsFullyPaid = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_BIL.BIL_BillPosition.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_BIL.BIL_BillPosition.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "BIL_BillPositionID", _BIL_BillPositionID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "BIL_BilHeader_RefID", _BIL_BilHeader_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "BIL_BillPosition_Group_RefID", _BIL_BillPosition_Group_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ApplicableSalesTax_RefID", _ApplicableSalesTax_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ApplicableSalesTax_Value", _ApplicableSalesTax_Value);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ApplicableSalesTax_PerUnitValue", _ApplicableSalesTax_PerUnitValue);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "PositionNumber", _PositionNumber);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "BillPosition_Description", _BillPosition_Description);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "BillPosition_Comment", _BillPosition_Comment);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "PositionIndex", _PositionIndex);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "PositionValue_BeforeTax", _PositionValue_BeforeTax);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "PositionValue_IncludingTax", _PositionValue_IncludingTax);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "PositionPricePerUnitValue_BeforeTax", _PositionPricePerUnitValue_BeforeTax);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "PositionPricePerUnitValue_IncludingTax", _PositionPricePerUnitValue_IncludingTax);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "BillPosition_ProductNumber", _BillPosition_ProductNumber);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Quantity", _Quantity);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "External_PositionReferenceField", _External_PositionReferenceField);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "External_PositionCode", _External_PositionCode);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "External_PositionType", _External_PositionType);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsFullyPaid", _IsFullyPaid);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_BIL.BIL_BillPosition.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_BIL_BillPositionID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"BIL_BillPositionID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "BIL_BillPositionID","BIL_BilHeader_RefID","BIL_BillPosition_Group_RefID","ApplicableSalesTax_RefID","ApplicableSalesTax_Value","ApplicableSalesTax_PerUnitValue","PositionNumber","BillPosition_Description","BillPosition_Comment","PositionIndex","PositionValue_BeforeTax","PositionValue_IncludingTax","PositionPricePerUnitValue_BeforeTax","PositionPricePerUnitValue_IncludingTax","BillPosition_ProductNumber","Quantity","External_PositionReferenceField","External_PositionCode","External_PositionType","IsFullyPaid","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter BIL_BillPositionID of type Guid
						_BIL_BillPositionID = reader.GetGuid(0);
						//1:Parameter BIL_BilHeader_RefID of type Guid
						_BIL_BilHeader_RefID = reader.GetGuid(1);
						//2:Parameter BIL_BillPosition_Group_RefID of type Guid
						_BIL_BillPosition_Group_RefID = reader.GetGuid(2);
						//3:Parameter ApplicableSalesTax_RefID of type Guid
						_ApplicableSalesTax_RefID = reader.GetGuid(3);
						//4:Parameter ApplicableSalesTax_Value of type Decimal
						_ApplicableSalesTax_Value = reader.GetDecimal(4);
						//5:Parameter ApplicableSalesTax_PerUnitValue of type Decimal
						_ApplicableSalesTax_PerUnitValue = reader.GetDecimal(5);
						//6:Parameter PositionNumber of type String
						_PositionNumber = reader.GetString(6);
						//7:Parameter BillPosition_Description of type String
						_BillPosition_Description = reader.GetString(7);
						//8:Parameter BillPosition_Comment of type String
						_BillPosition_Comment = reader.GetString(8);
						//9:Parameter PositionIndex of type int
						_PositionIndex = reader.GetInteger(9);
						//10:Parameter PositionValue_BeforeTax of type Decimal
						_PositionValue_BeforeTax = reader.GetDecimal(10);
						//11:Parameter PositionValue_IncludingTax of type Decimal
						_PositionValue_IncludingTax = reader.GetDecimal(11);
						//12:Parameter PositionPricePerUnitValue_BeforeTax of type Decimal
						_PositionPricePerUnitValue_BeforeTax = reader.GetDecimal(12);
						//13:Parameter PositionPricePerUnitValue_IncludingTax of type Decimal
						_PositionPricePerUnitValue_IncludingTax = reader.GetDecimal(13);
						//14:Parameter BillPosition_ProductNumber of type String
						_BillPosition_ProductNumber = reader.GetString(14);
						//15:Parameter Quantity of type double
						_Quantity = reader.GetDouble(15);
						//16:Parameter External_PositionReferenceField of type String
						_External_PositionReferenceField = reader.GetString(16);
						//17:Parameter External_PositionCode of type String
						_External_PositionCode = reader.GetString(17);
						//18:Parameter External_PositionType of type String
						_External_PositionType = reader.GetString(18);
						//19:Parameter IsFullyPaid of type Boolean
						_IsFullyPaid = reader.GetBoolean(19);
						//20:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(20);
						//21:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(21);
						//22:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(22);
						//23:Parameter Modification_Timestamp of type DateTime
						_Modification_Timestamp = reader.GetDate(23);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_BIL_BillPositionID != Guid.Empty){
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
			public Guid? BIL_BillPositionID {	get; set; }
			public Guid? BIL_BilHeader_RefID {	get; set; }
			public Guid? BIL_BillPosition_Group_RefID {	get; set; }
			public Guid? ApplicableSalesTax_RefID {	get; set; }
			public Decimal? ApplicableSalesTax_Value {	get; set; }
			public Decimal? ApplicableSalesTax_PerUnitValue {	get; set; }
			public String PositionNumber {	get; set; }
			public String BillPosition_Description {	get; set; }
			public String BillPosition_Comment {	get; set; }
			public int? PositionIndex {	get; set; }
			public Decimal? PositionValue_BeforeTax {	get; set; }
			public Decimal? PositionValue_IncludingTax {	get; set; }
			public Decimal? PositionPricePerUnitValue_BeforeTax {	get; set; }
			public Decimal? PositionPricePerUnitValue_IncludingTax {	get; set; }
			public String BillPosition_ProductNumber {	get; set; }
			public double? Quantity {	get; set; }
			public String External_PositionReferenceField {	get; set; }
			public String External_PositionCode {	get; set; }
			public String External_PositionType {	get; set; }
			public Boolean? IsFullyPaid {	get; set; }
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
			public static List<ORM_BIL_BillPosition> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_BIL_BillPosition> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_BIL_BillPosition> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_BIL_BillPosition> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_BIL_BillPosition> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_BIL_BillPosition>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "BIL_BillPositionID","BIL_BilHeader_RefID","BIL_BillPosition_Group_RefID","ApplicableSalesTax_RefID","ApplicableSalesTax_Value","ApplicableSalesTax_PerUnitValue","PositionNumber","BillPosition_Description","BillPosition_Comment","PositionIndex","PositionValue_BeforeTax","PositionValue_IncludingTax","PositionPricePerUnitValue_BeforeTax","PositionPricePerUnitValue_IncludingTax","BillPosition_ProductNumber","Quantity","External_PositionReferenceField","External_PositionCode","External_PositionType","IsFullyPaid","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
			        while (reader.Read())
			        {
			            ORM_BIL_BillPosition item = new ORM_BIL_BillPosition();
						//0:Parameter BIL_BillPositionID of type Guid
						item.BIL_BillPositionID = reader.GetGuid(0);
						//1:Parameter BIL_BilHeader_RefID of type Guid
						item.BIL_BilHeader_RefID = reader.GetGuid(1);
						//2:Parameter BIL_BillPosition_Group_RefID of type Guid
						item.BIL_BillPosition_Group_RefID = reader.GetGuid(2);
						//3:Parameter ApplicableSalesTax_RefID of type Guid
						item.ApplicableSalesTax_RefID = reader.GetGuid(3);
						//4:Parameter ApplicableSalesTax_Value of type Decimal
						item.ApplicableSalesTax_Value = reader.GetDecimal(4);
						//5:Parameter ApplicableSalesTax_PerUnitValue of type Decimal
						item.ApplicableSalesTax_PerUnitValue = reader.GetDecimal(5);
						//6:Parameter PositionNumber of type String
						item.PositionNumber = reader.GetString(6);
						//7:Parameter BillPosition_Description of type String
						item.BillPosition_Description = reader.GetString(7);
						//8:Parameter BillPosition_Comment of type String
						item.BillPosition_Comment = reader.GetString(8);
						//9:Parameter PositionIndex of type int
						item.PositionIndex = reader.GetInteger(9);
						//10:Parameter PositionValue_BeforeTax of type Decimal
						item.PositionValue_BeforeTax = reader.GetDecimal(10);
						//11:Parameter PositionValue_IncludingTax of type Decimal
						item.PositionValue_IncludingTax = reader.GetDecimal(11);
						//12:Parameter PositionPricePerUnitValue_BeforeTax of type Decimal
						item.PositionPricePerUnitValue_BeforeTax = reader.GetDecimal(12);
						//13:Parameter PositionPricePerUnitValue_IncludingTax of type Decimal
						item.PositionPricePerUnitValue_IncludingTax = reader.GetDecimal(13);
						//14:Parameter BillPosition_ProductNumber of type String
						item.BillPosition_ProductNumber = reader.GetString(14);
						//15:Parameter Quantity of type double
						item.Quantity = reader.GetDouble(15);
						//16:Parameter External_PositionReferenceField of type String
						item.External_PositionReferenceField = reader.GetString(16);
						//17:Parameter External_PositionCode of type String
						item.External_PositionCode = reader.GetString(17);
						//18:Parameter External_PositionType of type String
						item.External_PositionType = reader.GetString(18);
						//19:Parameter IsFullyPaid of type Boolean
						item.IsFullyPaid = reader.GetBoolean(19);
						//20:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(20);
						//21:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(21);
						//22:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(22);
						//23:Parameter Modification_Timestamp of type DateTime
						item.Modification_Timestamp = reader.GetDate(23);


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
