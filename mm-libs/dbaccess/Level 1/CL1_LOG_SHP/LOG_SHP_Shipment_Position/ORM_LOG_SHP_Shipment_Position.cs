/* 
 * Generated on 11/5/2014 10:49:07 AM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_LOG_SHP
{
	[Serializable]
	public class ORM_LOG_SHP_Shipment_Position
	{
		public static readonly string TableName = "log_shp_shipment_positions";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_LOG_SHP_Shipment_Position()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_LOG_SHP_Shipment_PositionID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _LOG_SHP_Shipment_PositionID = default(Guid);
		private String _ShipmentPositionITL = default(String);
		private Guid _LOG_SHP_Shipment_Header_RefID = default(Guid);
		private Guid _CMN_PRO_Product_RefID = default(Guid);
		private Guid _CMN_PRO_ProductVariant_RefID = default(Guid);
		private Guid _CMN_PRO_ProductRelease_RefID = default(Guid);
		private Guid _TrackingInstance_ToShip_RefID = default(Guid);
		private double _QuantityToShip = default(double);
		private Decimal _ShipmentPosition_ValueWithoutTax = default(Decimal);
		private Decimal _ShipmentPosition_PricePerUnitValueWithoutTax = default(Decimal);
		private Boolean _IsCancelled = default(Boolean);
		private Guid _CancelledBy_BusinessParticipant_RefID = default(Guid);
		private DateTime _CancelledOnDate = default(DateTime);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		private DateTime _Modification_Timestamp = default(DateTime);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid LOG_SHP_Shipment_PositionID { 
			get {
				return _LOG_SHP_Shipment_PositionID;
			}
			set {
				if(_LOG_SHP_Shipment_PositionID != value){
					_LOG_SHP_Shipment_PositionID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String ShipmentPositionITL { 
			get {
				return _ShipmentPositionITL;
			}
			set {
				if(_ShipmentPositionITL != value){
					_ShipmentPositionITL = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid LOG_SHP_Shipment_Header_RefID { 
			get {
				return _LOG_SHP_Shipment_Header_RefID;
			}
			set {
				if(_LOG_SHP_Shipment_Header_RefID != value){
					_LOG_SHP_Shipment_Header_RefID = value;
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
		public Guid CMN_PRO_ProductVariant_RefID { 
			get {
				return _CMN_PRO_ProductVariant_RefID;
			}
			set {
				if(_CMN_PRO_ProductVariant_RefID != value){
					_CMN_PRO_ProductVariant_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid CMN_PRO_ProductRelease_RefID { 
			get {
				return _CMN_PRO_ProductRelease_RefID;
			}
			set {
				if(_CMN_PRO_ProductRelease_RefID != value){
					_CMN_PRO_ProductRelease_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid TrackingInstance_ToShip_RefID { 
			get {
				return _TrackingInstance_ToShip_RefID;
			}
			set {
				if(_TrackingInstance_ToShip_RefID != value){
					_TrackingInstance_ToShip_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public double QuantityToShip { 
			get {
				return _QuantityToShip;
			}
			set {
				if(_QuantityToShip != value){
					_QuantityToShip = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Decimal ShipmentPosition_ValueWithoutTax { 
			get {
				return _ShipmentPosition_ValueWithoutTax;
			}
			set {
				if(_ShipmentPosition_ValueWithoutTax != value){
					_ShipmentPosition_ValueWithoutTax = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Decimal ShipmentPosition_PricePerUnitValueWithoutTax { 
			get {
				return _ShipmentPosition_PricePerUnitValueWithoutTax;
			}
			set {
				if(_ShipmentPosition_PricePerUnitValueWithoutTax != value){
					_ShipmentPosition_PricePerUnitValueWithoutTax = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsCancelled { 
			get {
				return _IsCancelled;
			}
			set {
				if(_IsCancelled != value){
					_IsCancelled = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid CancelledBy_BusinessParticipant_RefID { 
			get {
				return _CancelledBy_BusinessParticipant_RefID;
			}
			set {
				if(_CancelledBy_BusinessParticipant_RefID != value){
					_CancelledBy_BusinessParticipant_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime CancelledOnDate { 
			get {
				return _CancelledOnDate;
			}
			set {
				if(_CancelledOnDate != value){
					_CancelledOnDate = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_LOG_SHP.LOG_SHP_Shipment_Position.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_LOG_SHP.LOG_SHP_Shipment_Position.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "LOG_SHP_Shipment_PositionID", _LOG_SHP_Shipment_PositionID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ShipmentPositionITL", _ShipmentPositionITL);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "LOG_SHP_Shipment_Header_RefID", _LOG_SHP_Shipment_Header_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_PRO_Product_RefID", _CMN_PRO_Product_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_PRO_ProductVariant_RefID", _CMN_PRO_ProductVariant_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_PRO_ProductRelease_RefID", _CMN_PRO_ProductRelease_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "TrackingInstance_ToShip_RefID", _TrackingInstance_ToShip_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "QuantityToShip", _QuantityToShip);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ShipmentPosition_ValueWithoutTax", _ShipmentPosition_ValueWithoutTax);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ShipmentPosition_PricePerUnitValueWithoutTax", _ShipmentPosition_PricePerUnitValueWithoutTax);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsCancelled", _IsCancelled);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CancelledBy_BusinessParticipant_RefID", _CancelledBy_BusinessParticipant_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CancelledOnDate", _CancelledOnDate);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_LOG_SHP.LOG_SHP_Shipment_Position.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_LOG_SHP_Shipment_PositionID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"LOG_SHP_Shipment_PositionID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "LOG_SHP_Shipment_PositionID","ShipmentPositionITL","LOG_SHP_Shipment_Header_RefID","CMN_PRO_Product_RefID","CMN_PRO_ProductVariant_RefID","CMN_PRO_ProductRelease_RefID","TrackingInstance_ToShip_RefID","QuantityToShip","ShipmentPosition_ValueWithoutTax","ShipmentPosition_PricePerUnitValueWithoutTax","IsCancelled","CancelledBy_BusinessParticipant_RefID","CancelledOnDate","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter LOG_SHP_Shipment_PositionID of type Guid
						_LOG_SHP_Shipment_PositionID = reader.GetGuid(0);
						//1:Parameter ShipmentPositionITL of type String
						_ShipmentPositionITL = reader.GetString(1);
						//2:Parameter LOG_SHP_Shipment_Header_RefID of type Guid
						_LOG_SHP_Shipment_Header_RefID = reader.GetGuid(2);
						//3:Parameter CMN_PRO_Product_RefID of type Guid
						_CMN_PRO_Product_RefID = reader.GetGuid(3);
						//4:Parameter CMN_PRO_ProductVariant_RefID of type Guid
						_CMN_PRO_ProductVariant_RefID = reader.GetGuid(4);
						//5:Parameter CMN_PRO_ProductRelease_RefID of type Guid
						_CMN_PRO_ProductRelease_RefID = reader.GetGuid(5);
						//6:Parameter TrackingInstance_ToShip_RefID of type Guid
						_TrackingInstance_ToShip_RefID = reader.GetGuid(6);
						//7:Parameter QuantityToShip of type double
						_QuantityToShip = reader.GetDouble(7);
						//8:Parameter ShipmentPosition_ValueWithoutTax of type Decimal
						_ShipmentPosition_ValueWithoutTax = reader.GetDecimal(8);
						//9:Parameter ShipmentPosition_PricePerUnitValueWithoutTax of type Decimal
						_ShipmentPosition_PricePerUnitValueWithoutTax = reader.GetDecimal(9);
						//10:Parameter IsCancelled of type Boolean
						_IsCancelled = reader.GetBoolean(10);
						//11:Parameter CancelledBy_BusinessParticipant_RefID of type Guid
						_CancelledBy_BusinessParticipant_RefID = reader.GetGuid(11);
						//12:Parameter CancelledOnDate of type DateTime
						_CancelledOnDate = reader.GetDate(12);
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

					if(_LOG_SHP_Shipment_PositionID != Guid.Empty){
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
			public Guid? LOG_SHP_Shipment_PositionID {	get; set; }
			public String ShipmentPositionITL {	get; set; }
			public Guid? LOG_SHP_Shipment_Header_RefID {	get; set; }
			public Guid? CMN_PRO_Product_RefID {	get; set; }
			public Guid? CMN_PRO_ProductVariant_RefID {	get; set; }
			public Guid? CMN_PRO_ProductRelease_RefID {	get; set; }
			public Guid? TrackingInstance_ToShip_RefID {	get; set; }
			public double? QuantityToShip {	get; set; }
			public Decimal? ShipmentPosition_ValueWithoutTax {	get; set; }
			public Decimal? ShipmentPosition_PricePerUnitValueWithoutTax {	get; set; }
			public Boolean? IsCancelled {	get; set; }
			public Guid? CancelledBy_BusinessParticipant_RefID {	get; set; }
			public DateTime? CancelledOnDate {	get; set; }
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
			public static List<ORM_LOG_SHP_Shipment_Position> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_LOG_SHP_Shipment_Position> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_LOG_SHP_Shipment_Position> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_LOG_SHP_Shipment_Position> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_LOG_SHP_Shipment_Position> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_LOG_SHP_Shipment_Position>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "LOG_SHP_Shipment_PositionID","ShipmentPositionITL","LOG_SHP_Shipment_Header_RefID","CMN_PRO_Product_RefID","CMN_PRO_ProductVariant_RefID","CMN_PRO_ProductRelease_RefID","TrackingInstance_ToShip_RefID","QuantityToShip","ShipmentPosition_ValueWithoutTax","ShipmentPosition_PricePerUnitValueWithoutTax","IsCancelled","CancelledBy_BusinessParticipant_RefID","CancelledOnDate","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
			        while (reader.Read())
			        {
			            ORM_LOG_SHP_Shipment_Position item = new ORM_LOG_SHP_Shipment_Position();
						//0:Parameter LOG_SHP_Shipment_PositionID of type Guid
						item.LOG_SHP_Shipment_PositionID = reader.GetGuid(0);
						//1:Parameter ShipmentPositionITL of type String
						item.ShipmentPositionITL = reader.GetString(1);
						//2:Parameter LOG_SHP_Shipment_Header_RefID of type Guid
						item.LOG_SHP_Shipment_Header_RefID = reader.GetGuid(2);
						//3:Parameter CMN_PRO_Product_RefID of type Guid
						item.CMN_PRO_Product_RefID = reader.GetGuid(3);
						//4:Parameter CMN_PRO_ProductVariant_RefID of type Guid
						item.CMN_PRO_ProductVariant_RefID = reader.GetGuid(4);
						//5:Parameter CMN_PRO_ProductRelease_RefID of type Guid
						item.CMN_PRO_ProductRelease_RefID = reader.GetGuid(5);
						//6:Parameter TrackingInstance_ToShip_RefID of type Guid
						item.TrackingInstance_ToShip_RefID = reader.GetGuid(6);
						//7:Parameter QuantityToShip of type double
						item.QuantityToShip = reader.GetDouble(7);
						//8:Parameter ShipmentPosition_ValueWithoutTax of type Decimal
						item.ShipmentPosition_ValueWithoutTax = reader.GetDecimal(8);
						//9:Parameter ShipmentPosition_PricePerUnitValueWithoutTax of type Decimal
						item.ShipmentPosition_PricePerUnitValueWithoutTax = reader.GetDecimal(9);
						//10:Parameter IsCancelled of type Boolean
						item.IsCancelled = reader.GetBoolean(10);
						//11:Parameter CancelledBy_BusinessParticipant_RefID of type Guid
						item.CancelledBy_BusinessParticipant_RefID = reader.GetGuid(11);
						//12:Parameter CancelledOnDate of type DateTime
						item.CancelledOnDate = reader.GetDate(12);
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
