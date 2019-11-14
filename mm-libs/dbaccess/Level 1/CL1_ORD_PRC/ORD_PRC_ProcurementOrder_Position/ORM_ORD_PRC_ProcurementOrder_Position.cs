/* 
 * Generated on 05/19/15 18:05:56
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_ORD_PRC
{
	[Serializable]
	public class ORM_ORD_PRC_ProcurementOrder_Position
	{
		public static readonly string TableName = "ord_prc_procurementorder_positions";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_ORD_PRC_ProcurementOrder_Position()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_ORD_PRC_ProcurementOrder_PositionID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _ORD_PRC_ProcurementOrder_PositionID = default(Guid);
		private String _SupplierCustomerOrderPositionITL = default(String);
		private Guid _ProcurementOrder_Header_RefID = default(Guid);
		private int _Position_OrdinalNumber = default(int);
		private double _Position_Quantity = default(double);
		private Decimal _Position_ValuePerUnit = default(Decimal);
		private Decimal _Position_ValueTotal = default(Decimal);
		private String _Position_Comment = default(String);
		private Guid _Position_Unit_RefID = default(Guid);
		private DateTime _Position_RequestedDateOfDelivery = default(DateTime);
		private Guid _CMN_PRO_Product_RefID = default(Guid);
		private Guid _CMN_PRO_Product_Variant_RefID = default(Guid);
		private Guid _CMN_PRO_Product_Release_RefID = default(Guid);
		private Boolean _IsProductReplacementAllowed = default(Boolean);
		private Boolean _IsBonusDelivery_WasNotOrdered = default(Boolean);
		private DateTime _RequestedDateOfDelivery_TimeFrame_From = default(DateTime);
		private DateTime _RequestedDateOfDelivery_TimeFrame_To = default(DateTime);
		private Guid _BillTo_BusinessParticipant_RefID = default(Guid);
		private Boolean _IsProFormaOrderPosition = default(Boolean);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		private DateTime _Modification_Timestamp = default(DateTime);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid ORD_PRC_ProcurementOrder_PositionID { 
			get {
				return _ORD_PRC_ProcurementOrder_PositionID;
			}
			set {
				if(_ORD_PRC_ProcurementOrder_PositionID != value){
					_ORD_PRC_ProcurementOrder_PositionID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String SupplierCustomerOrderPositionITL { 
			get {
				return _SupplierCustomerOrderPositionITL;
			}
			set {
				if(_SupplierCustomerOrderPositionITL != value){
					_SupplierCustomerOrderPositionITL = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid ProcurementOrder_Header_RefID { 
			get {
				return _ProcurementOrder_Header_RefID;
			}
			set {
				if(_ProcurementOrder_Header_RefID != value){
					_ProcurementOrder_Header_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int Position_OrdinalNumber { 
			get {
				return _Position_OrdinalNumber;
			}
			set {
				if(_Position_OrdinalNumber != value){
					_Position_OrdinalNumber = value;
					Status_IsDirty = true;
				}
			}
		} 
		public double Position_Quantity { 
			get {
				return _Position_Quantity;
			}
			set {
				if(_Position_Quantity != value){
					_Position_Quantity = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Decimal Position_ValuePerUnit { 
			get {
				return _Position_ValuePerUnit;
			}
			set {
				if(_Position_ValuePerUnit != value){
					_Position_ValuePerUnit = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Decimal Position_ValueTotal { 
			get {
				return _Position_ValueTotal;
			}
			set {
				if(_Position_ValueTotal != value){
					_Position_ValueTotal = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String Position_Comment { 
			get {
				return _Position_Comment;
			}
			set {
				if(_Position_Comment != value){
					_Position_Comment = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Position_Unit_RefID { 
			get {
				return _Position_Unit_RefID;
			}
			set {
				if(_Position_Unit_RefID != value){
					_Position_Unit_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime Position_RequestedDateOfDelivery { 
			get {
				return _Position_RequestedDateOfDelivery;
			}
			set {
				if(_Position_RequestedDateOfDelivery != value){
					_Position_RequestedDateOfDelivery = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid CMN_PRO_Product_RefID { 
			get {
				return _CMN_PRO_Product_RefID;
			}
			set {
				if(_CMN_PRO_Product_RefID != value){
					_CMN_PRO_Product_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid CMN_PRO_Product_Variant_RefID { 
			get {
				return _CMN_PRO_Product_Variant_RefID;
			}
			set {
				if(_CMN_PRO_Product_Variant_RefID != value){
					_CMN_PRO_Product_Variant_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid CMN_PRO_Product_Release_RefID { 
			get {
				return _CMN_PRO_Product_Release_RefID;
			}
			set {
				if(_CMN_PRO_Product_Release_RefID != value){
					_CMN_PRO_Product_Release_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsProductReplacementAllowed { 
			get {
				return _IsProductReplacementAllowed;
			}
			set {
				if(_IsProductReplacementAllowed != value){
					_IsProductReplacementAllowed = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsBonusDelivery_WasNotOrdered { 
			get {
				return _IsBonusDelivery_WasNotOrdered;
			}
			set {
				if(_IsBonusDelivery_WasNotOrdered != value){
					_IsBonusDelivery_WasNotOrdered = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime RequestedDateOfDelivery_TimeFrame_From { 
			get {
				return _RequestedDateOfDelivery_TimeFrame_From;
			}
			set {
				if(_RequestedDateOfDelivery_TimeFrame_From != value){
					_RequestedDateOfDelivery_TimeFrame_From = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime RequestedDateOfDelivery_TimeFrame_To { 
			get {
				return _RequestedDateOfDelivery_TimeFrame_To;
			}
			set {
				if(_RequestedDateOfDelivery_TimeFrame_To != value){
					_RequestedDateOfDelivery_TimeFrame_To = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid BillTo_BusinessParticipant_RefID { 
			get {
				return _BillTo_BusinessParticipant_RefID;
			}
			set {
				if(_BillTo_BusinessParticipant_RefID != value){
					_BillTo_BusinessParticipant_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsProFormaOrderPosition { 
			get {
				return _IsProFormaOrderPosition;
			}
			set {
				if(_IsProFormaOrderPosition != value){
					_IsProFormaOrderPosition = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_ORD_PRC.ORD_PRC_ProcurementOrder_Position.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_ORD_PRC.ORD_PRC_ProcurementOrder_Position.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ORD_PRC_ProcurementOrder_PositionID", _ORD_PRC_ProcurementOrder_PositionID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "SupplierCustomerOrderPositionITL", _SupplierCustomerOrderPositionITL);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ProcurementOrder_Header_RefID", _ProcurementOrder_Header_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Position_OrdinalNumber", _Position_OrdinalNumber);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Position_Quantity", _Position_Quantity);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Position_ValuePerUnit", _Position_ValuePerUnit);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Position_ValueTotal", _Position_ValueTotal);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Position_Comment", _Position_Comment);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Position_Unit_RefID", _Position_Unit_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Position_RequestedDateOfDelivery", _Position_RequestedDateOfDelivery);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_PRO_Product_RefID", _CMN_PRO_Product_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_PRO_Product_Variant_RefID", _CMN_PRO_Product_Variant_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_PRO_Product_Release_RefID", _CMN_PRO_Product_Release_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsProductReplacementAllowed", _IsProductReplacementAllowed);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsBonusDelivery_WasNotOrdered", _IsBonusDelivery_WasNotOrdered);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "RequestedDateOfDelivery_TimeFrame_From", _RequestedDateOfDelivery_TimeFrame_From);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "RequestedDateOfDelivery_TimeFrame_To", _RequestedDateOfDelivery_TimeFrame_To);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "BillTo_BusinessParticipant_RefID", _BillTo_BusinessParticipant_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsProFormaOrderPosition", _IsProFormaOrderPosition);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_ORD_PRC.ORD_PRC_ProcurementOrder_Position.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_ORD_PRC_ProcurementOrder_PositionID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ORD_PRC_ProcurementOrder_PositionID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "ORD_PRC_ProcurementOrder_PositionID","SupplierCustomerOrderPositionITL","ProcurementOrder_Header_RefID","Position_OrdinalNumber","Position_Quantity","Position_ValuePerUnit","Position_ValueTotal","Position_Comment","Position_Unit_RefID","Position_RequestedDateOfDelivery","CMN_PRO_Product_RefID","CMN_PRO_Product_Variant_RefID","CMN_PRO_Product_Release_RefID","IsProductReplacementAllowed","IsBonusDelivery_WasNotOrdered","RequestedDateOfDelivery_TimeFrame_From","RequestedDateOfDelivery_TimeFrame_To","BillTo_BusinessParticipant_RefID","IsProFormaOrderPosition","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter ORD_PRC_ProcurementOrder_PositionID of type Guid
						_ORD_PRC_ProcurementOrder_PositionID = reader.GetGuid(0);
						//1:Parameter SupplierCustomerOrderPositionITL of type String
						_SupplierCustomerOrderPositionITL = reader.GetString(1);
						//2:Parameter ProcurementOrder_Header_RefID of type Guid
						_ProcurementOrder_Header_RefID = reader.GetGuid(2);
						//3:Parameter Position_OrdinalNumber of type int
						_Position_OrdinalNumber = reader.GetInteger(3);
						//4:Parameter Position_Quantity of type double
						_Position_Quantity = reader.GetDouble(4);
						//5:Parameter Position_ValuePerUnit of type Decimal
						_Position_ValuePerUnit = reader.GetDecimal(5);
						//6:Parameter Position_ValueTotal of type Decimal
						_Position_ValueTotal = reader.GetDecimal(6);
						//7:Parameter Position_Comment of type String
						_Position_Comment = reader.GetString(7);
						//8:Parameter Position_Unit_RefID of type Guid
						_Position_Unit_RefID = reader.GetGuid(8);
						//9:Parameter Position_RequestedDateOfDelivery of type DateTime
						_Position_RequestedDateOfDelivery = reader.GetDate(9);
						//10:Parameter CMN_PRO_Product_RefID of type Guid
						_CMN_PRO_Product_RefID = reader.GetGuid(10);
						//11:Parameter CMN_PRO_Product_Variant_RefID of type Guid
						_CMN_PRO_Product_Variant_RefID = reader.GetGuid(11);
						//12:Parameter CMN_PRO_Product_Release_RefID of type Guid
						_CMN_PRO_Product_Release_RefID = reader.GetGuid(12);
						//13:Parameter IsProductReplacementAllowed of type Boolean
						_IsProductReplacementAllowed = reader.GetBoolean(13);
						//14:Parameter IsBonusDelivery_WasNotOrdered of type Boolean
						_IsBonusDelivery_WasNotOrdered = reader.GetBoolean(14);
						//15:Parameter RequestedDateOfDelivery_TimeFrame_From of type DateTime
						_RequestedDateOfDelivery_TimeFrame_From = reader.GetDate(15);
						//16:Parameter RequestedDateOfDelivery_TimeFrame_To of type DateTime
						_RequestedDateOfDelivery_TimeFrame_To = reader.GetDate(16);
						//17:Parameter BillTo_BusinessParticipant_RefID of type Guid
						_BillTo_BusinessParticipant_RefID = reader.GetGuid(17);
						//18:Parameter IsProFormaOrderPosition of type Boolean
						_IsProFormaOrderPosition = reader.GetBoolean(18);
						//19:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(19);
						//20:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(20);
						//21:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(21);
						//22:Parameter Modification_Timestamp of type DateTime
						_Modification_Timestamp = reader.GetDate(22);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_ORD_PRC_ProcurementOrder_PositionID != Guid.Empty){
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
			public Guid? ORD_PRC_ProcurementOrder_PositionID {	get; set; }
			public String SupplierCustomerOrderPositionITL {	get; set; }
			public Guid? ProcurementOrder_Header_RefID {	get; set; }
			public int? Position_OrdinalNumber {	get; set; }
			public double? Position_Quantity {	get; set; }
			public Decimal? Position_ValuePerUnit {	get; set; }
			public Decimal? Position_ValueTotal {	get; set; }
			public String Position_Comment {	get; set; }
			public Guid? Position_Unit_RefID {	get; set; }
			public DateTime? Position_RequestedDateOfDelivery {	get; set; }
			public Guid? CMN_PRO_Product_RefID {	get; set; }
			public Guid? CMN_PRO_Product_Variant_RefID {	get; set; }
			public Guid? CMN_PRO_Product_Release_RefID {	get; set; }
			public Boolean? IsProductReplacementAllowed {	get; set; }
			public Boolean? IsBonusDelivery_WasNotOrdered {	get; set; }
			public DateTime? RequestedDateOfDelivery_TimeFrame_From {	get; set; }
			public DateTime? RequestedDateOfDelivery_TimeFrame_To {	get; set; }
			public Guid? BillTo_BusinessParticipant_RefID {	get; set; }
			public Boolean? IsProFormaOrderPosition {	get; set; }
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
			public static List<ORM_ORD_PRC_ProcurementOrder_Position> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_ORD_PRC_ProcurementOrder_Position> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_ORD_PRC_ProcurementOrder_Position> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_ORD_PRC_ProcurementOrder_Position> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_ORD_PRC_ProcurementOrder_Position> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_ORD_PRC_ProcurementOrder_Position>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "ORD_PRC_ProcurementOrder_PositionID","SupplierCustomerOrderPositionITL","ProcurementOrder_Header_RefID","Position_OrdinalNumber","Position_Quantity","Position_ValuePerUnit","Position_ValueTotal","Position_Comment","Position_Unit_RefID","Position_RequestedDateOfDelivery","CMN_PRO_Product_RefID","CMN_PRO_Product_Variant_RefID","CMN_PRO_Product_Release_RefID","IsProductReplacementAllowed","IsBonusDelivery_WasNotOrdered","RequestedDateOfDelivery_TimeFrame_From","RequestedDateOfDelivery_TimeFrame_To","BillTo_BusinessParticipant_RefID","IsProFormaOrderPosition","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
			        while (reader.Read())
			        {
			            ORM_ORD_PRC_ProcurementOrder_Position item = new ORM_ORD_PRC_ProcurementOrder_Position();
						//0:Parameter ORD_PRC_ProcurementOrder_PositionID of type Guid
						item.ORD_PRC_ProcurementOrder_PositionID = reader.GetGuid(0);
						//1:Parameter SupplierCustomerOrderPositionITL of type String
						item.SupplierCustomerOrderPositionITL = reader.GetString(1);
						//2:Parameter ProcurementOrder_Header_RefID of type Guid
						item.ProcurementOrder_Header_RefID = reader.GetGuid(2);
						//3:Parameter Position_OrdinalNumber of type int
						item.Position_OrdinalNumber = reader.GetInteger(3);
						//4:Parameter Position_Quantity of type double
						item.Position_Quantity = reader.GetDouble(4);
						//5:Parameter Position_ValuePerUnit of type Decimal
						item.Position_ValuePerUnit = reader.GetDecimal(5);
						//6:Parameter Position_ValueTotal of type Decimal
						item.Position_ValueTotal = reader.GetDecimal(6);
						//7:Parameter Position_Comment of type String
						item.Position_Comment = reader.GetString(7);
						//8:Parameter Position_Unit_RefID of type Guid
						item.Position_Unit_RefID = reader.GetGuid(8);
						//9:Parameter Position_RequestedDateOfDelivery of type DateTime
						item.Position_RequestedDateOfDelivery = reader.GetDate(9);
						//10:Parameter CMN_PRO_Product_RefID of type Guid
						item.CMN_PRO_Product_RefID = reader.GetGuid(10);
						//11:Parameter CMN_PRO_Product_Variant_RefID of type Guid
						item.CMN_PRO_Product_Variant_RefID = reader.GetGuid(11);
						//12:Parameter CMN_PRO_Product_Release_RefID of type Guid
						item.CMN_PRO_Product_Release_RefID = reader.GetGuid(12);
						//13:Parameter IsProductReplacementAllowed of type Boolean
						item.IsProductReplacementAllowed = reader.GetBoolean(13);
						//14:Parameter IsBonusDelivery_WasNotOrdered of type Boolean
						item.IsBonusDelivery_WasNotOrdered = reader.GetBoolean(14);
						//15:Parameter RequestedDateOfDelivery_TimeFrame_From of type DateTime
						item.RequestedDateOfDelivery_TimeFrame_From = reader.GetDate(15);
						//16:Parameter RequestedDateOfDelivery_TimeFrame_To of type DateTime
						item.RequestedDateOfDelivery_TimeFrame_To = reader.GetDate(16);
						//17:Parameter BillTo_BusinessParticipant_RefID of type Guid
						item.BillTo_BusinessParticipant_RefID = reader.GetGuid(17);
						//18:Parameter IsProFormaOrderPosition of type Boolean
						item.IsProFormaOrderPosition = reader.GetBoolean(18);
						//19:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(19);
						//20:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(20);
						//21:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(21);
						//22:Parameter Modification_Timestamp of type DateTime
						item.Modification_Timestamp = reader.GetDate(22);


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
