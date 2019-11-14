/* 
 * Generated on 06/02/15 09:15:46
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
	public class ORM_BIL_BillHeader
	{
		public static readonly string TableName = "bil_billheaders";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_BIL_BillHeader()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_BIL_BillHeaderID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _BIL_BillHeaderID = default(Guid);
		private Guid _BillRecipient_BuisnessParticipant_RefID = default(Guid);
		private Guid _CreatedBy_BusinessParticipant_RefID = default(Guid);
		private Guid _Currency_RefID = default(Guid);
		private String _BillNumber = default(String);
		private DateTime _DateOnBill = default(DateTime);
		private Decimal _TotalValue_BeforeTax = default(Decimal);
		private Decimal _TotalValue_IncludingTax = default(Decimal);
		private Guid _SourceEconomicRegion_RefID = default(Guid);
		private Guid _TargetEconomicRegion_RefID = default(Guid);
		private Guid _BillingAddress_UCD_RefID = default(Guid);
		private Guid _BillHeader_PaymentCondition_RefID = default(Guid);
		private String _BillComment = default(String);
		private Boolean _IsFullyPaid = default(Boolean);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		private DateTime _Modification_Timestamp = default(DateTime);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid BIL_BillHeaderID { 
			get {
				return _BIL_BillHeaderID;
			}
			set {
				if(_BIL_BillHeaderID != value){
					_BIL_BillHeaderID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid BillRecipient_BuisnessParticipant_RefID { 
			get {
				return _BillRecipient_BuisnessParticipant_RefID;
			}
			set {
				if(_BillRecipient_BuisnessParticipant_RefID != value){
					_BillRecipient_BuisnessParticipant_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid CreatedBy_BusinessParticipant_RefID { 
			get {
				return _CreatedBy_BusinessParticipant_RefID;
			}
			set {
				if(_CreatedBy_BusinessParticipant_RefID != value){
					_CreatedBy_BusinessParticipant_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Currency_RefID { 
			get {
				return _Currency_RefID;
			}
			set {
				if(_Currency_RefID != value){
					_Currency_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String BillNumber { 
			get {
				return _BillNumber;
			}
			set {
				if(_BillNumber != value){
					_BillNumber = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime DateOnBill { 
			get {
				return _DateOnBill;
			}
			set {
				if(_DateOnBill != value){
					_DateOnBill = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Decimal TotalValue_BeforeTax { 
			get {
				return _TotalValue_BeforeTax;
			}
			set {
				if(_TotalValue_BeforeTax != value){
					_TotalValue_BeforeTax = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Decimal TotalValue_IncludingTax { 
			get {
				return _TotalValue_IncludingTax;
			}
			set {
				if(_TotalValue_IncludingTax != value){
					_TotalValue_IncludingTax = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid SourceEconomicRegion_RefID { 
			get {
				return _SourceEconomicRegion_RefID;
			}
			set {
				if(_SourceEconomicRegion_RefID != value){
					_SourceEconomicRegion_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid TargetEconomicRegion_RefID { 
			get {
				return _TargetEconomicRegion_RefID;
			}
			set {
				if(_TargetEconomicRegion_RefID != value){
					_TargetEconomicRegion_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid BillingAddress_UCD_RefID { 
			get {
				return _BillingAddress_UCD_RefID;
			}
			set {
				if(_BillingAddress_UCD_RefID != value){
					_BillingAddress_UCD_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid BillHeader_PaymentCondition_RefID { 
			get {
				return _BillHeader_PaymentCondition_RefID;
			}
			set {
				if(_BillHeader_PaymentCondition_RefID != value){
					_BillHeader_PaymentCondition_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String BillComment { 
			get {
				return _BillComment;
			}
			set {
				if(_BillComment != value){
					_BillComment = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_BIL.BIL_BillHeader.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_BIL.BIL_BillHeader.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "BIL_BillHeaderID", _BIL_BillHeaderID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "BillRecipient_BuisnessParticipant_RefID", _BillRecipient_BuisnessParticipant_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CreatedBy_BusinessParticipant_RefID", _CreatedBy_BusinessParticipant_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Currency_RefID", _Currency_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "BillNumber", _BillNumber);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "DateOnBill", _DateOnBill);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "TotalValue_BeforeTax", _TotalValue_BeforeTax);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "TotalValue_IncludingTax", _TotalValue_IncludingTax);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "SourceEconomicRegion_RefID", _SourceEconomicRegion_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "TargetEconomicRegion_RefID", _TargetEconomicRegion_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "BillingAddress_UCD_RefID", _BillingAddress_UCD_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "BillHeader_PaymentCondition_RefID", _BillHeader_PaymentCondition_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "BillComment", _BillComment);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_BIL.BIL_BillHeader.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_BIL_BillHeaderID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"BIL_BillHeaderID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "BIL_BillHeaderID","BillRecipient_BuisnessParticipant_RefID","CreatedBy_BusinessParticipant_RefID","Currency_RefID","BillNumber","DateOnBill","TotalValue_BeforeTax","TotalValue_IncludingTax","SourceEconomicRegion_RefID","TargetEconomicRegion_RefID","BillingAddress_UCD_RefID","BillHeader_PaymentCondition_RefID","BillComment","IsFullyPaid","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter BIL_BillHeaderID of type Guid
						_BIL_BillHeaderID = reader.GetGuid(0);
						//1:Parameter BillRecipient_BuisnessParticipant_RefID of type Guid
						_BillRecipient_BuisnessParticipant_RefID = reader.GetGuid(1);
						//2:Parameter CreatedBy_BusinessParticipant_RefID of type Guid
						_CreatedBy_BusinessParticipant_RefID = reader.GetGuid(2);
						//3:Parameter Currency_RefID of type Guid
						_Currency_RefID = reader.GetGuid(3);
						//4:Parameter BillNumber of type String
						_BillNumber = reader.GetString(4);
						//5:Parameter DateOnBill of type DateTime
						_DateOnBill = reader.GetDate(5);
						//6:Parameter TotalValue_BeforeTax of type Decimal
						_TotalValue_BeforeTax = reader.GetDecimal(6);
						//7:Parameter TotalValue_IncludingTax of type Decimal
						_TotalValue_IncludingTax = reader.GetDecimal(7);
						//8:Parameter SourceEconomicRegion_RefID of type Guid
						_SourceEconomicRegion_RefID = reader.GetGuid(8);
						//9:Parameter TargetEconomicRegion_RefID of type Guid
						_TargetEconomicRegion_RefID = reader.GetGuid(9);
						//10:Parameter BillingAddress_UCD_RefID of type Guid
						_BillingAddress_UCD_RefID = reader.GetGuid(10);
						//11:Parameter BillHeader_PaymentCondition_RefID of type Guid
						_BillHeader_PaymentCondition_RefID = reader.GetGuid(11);
						//12:Parameter BillComment of type String
						_BillComment = reader.GetString(12);
						//13:Parameter IsFullyPaid of type Boolean
						_IsFullyPaid = reader.GetBoolean(13);
						//14:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(14);
						//15:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(15);
						//16:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(16);
						//17:Parameter Modification_Timestamp of type DateTime
						_Modification_Timestamp = reader.GetDate(17);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_BIL_BillHeaderID != Guid.Empty){
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
			public Guid? BIL_BillHeaderID {	get; set; }
			public Guid? BillRecipient_BuisnessParticipant_RefID {	get; set; }
			public Guid? CreatedBy_BusinessParticipant_RefID {	get; set; }
			public Guid? Currency_RefID {	get; set; }
			public String BillNumber {	get; set; }
			public DateTime? DateOnBill {	get; set; }
			public Decimal? TotalValue_BeforeTax {	get; set; }
			public Decimal? TotalValue_IncludingTax {	get; set; }
			public Guid? SourceEconomicRegion_RefID {	get; set; }
			public Guid? TargetEconomicRegion_RefID {	get; set; }
			public Guid? BillingAddress_UCD_RefID {	get; set; }
			public Guid? BillHeader_PaymentCondition_RefID {	get; set; }
			public String BillComment {	get; set; }
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
			public static List<ORM_BIL_BillHeader> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_BIL_BillHeader> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_BIL_BillHeader> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_BIL_BillHeader> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_BIL_BillHeader> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_BIL_BillHeader>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "BIL_BillHeaderID","BillRecipient_BuisnessParticipant_RefID","CreatedBy_BusinessParticipant_RefID","Currency_RefID","BillNumber","DateOnBill","TotalValue_BeforeTax","TotalValue_IncludingTax","SourceEconomicRegion_RefID","TargetEconomicRegion_RefID","BillingAddress_UCD_RefID","BillHeader_PaymentCondition_RefID","BillComment","IsFullyPaid","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
			        while (reader.Read())
			        {
			            ORM_BIL_BillHeader item = new ORM_BIL_BillHeader();
						//0:Parameter BIL_BillHeaderID of type Guid
						item.BIL_BillHeaderID = reader.GetGuid(0);
						//1:Parameter BillRecipient_BuisnessParticipant_RefID of type Guid
						item.BillRecipient_BuisnessParticipant_RefID = reader.GetGuid(1);
						//2:Parameter CreatedBy_BusinessParticipant_RefID of type Guid
						item.CreatedBy_BusinessParticipant_RefID = reader.GetGuid(2);
						//3:Parameter Currency_RefID of type Guid
						item.Currency_RefID = reader.GetGuid(3);
						//4:Parameter BillNumber of type String
						item.BillNumber = reader.GetString(4);
						//5:Parameter DateOnBill of type DateTime
						item.DateOnBill = reader.GetDate(5);
						//6:Parameter TotalValue_BeforeTax of type Decimal
						item.TotalValue_BeforeTax = reader.GetDecimal(6);
						//7:Parameter TotalValue_IncludingTax of type Decimal
						item.TotalValue_IncludingTax = reader.GetDecimal(7);
						//8:Parameter SourceEconomicRegion_RefID of type Guid
						item.SourceEconomicRegion_RefID = reader.GetGuid(8);
						//9:Parameter TargetEconomicRegion_RefID of type Guid
						item.TargetEconomicRegion_RefID = reader.GetGuid(9);
						//10:Parameter BillingAddress_UCD_RefID of type Guid
						item.BillingAddress_UCD_RefID = reader.GetGuid(10);
						//11:Parameter BillHeader_PaymentCondition_RefID of type Guid
						item.BillHeader_PaymentCondition_RefID = reader.GetGuid(11);
						//12:Parameter BillComment of type String
						item.BillComment = reader.GetString(12);
						//13:Parameter IsFullyPaid of type Boolean
						item.IsFullyPaid = reader.GetBoolean(13);
						//14:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(14);
						//15:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(15);
						//16:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(16);
						//17:Parameter Modification_Timestamp of type DateTime
						item.Modification_Timestamp = reader.GetDate(17);


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
