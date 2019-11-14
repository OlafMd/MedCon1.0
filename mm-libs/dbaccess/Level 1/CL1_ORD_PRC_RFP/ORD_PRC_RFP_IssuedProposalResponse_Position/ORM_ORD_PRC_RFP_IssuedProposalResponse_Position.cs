/* 
 * Generated on 8/5/2014 1:46:36 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_ORD_PRC_RFP
{
	[Serializable]
	public class ORM_ORD_PRC_RFP_IssuedProposalResponse_Position
	{
		public static readonly string TableName = "ord_prc_rfp_issuedproposalresponse_positions";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_ORD_PRC_RFP_IssuedProposalResponse_Position()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_ORD_PRC_RFP_IssuedProposalResponse_PositionID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _ORD_PRC_RFP_IssuedProposalResponse_PositionID = default(Guid);
		private String _ProposalResponsePositionITPL = default(String);
		private Guid _IssuedProposalResponseHeader_RefID = default(Guid);
		private Guid _CMN_PRO_Product_RefID = default(Guid);
		private Guid _CMN_PRO_Product_Variant_RefID = default(Guid);
		private Guid _CMN_PRO_Product_Release_RefID = default(Guid);
		private Guid _CreatedFrom_RequestForProposal_Position_RefID = default(Guid);
		private double _Quantity = default(double);
		private Decimal _TotalPrice_WithoutTax = default(Decimal);
		private Decimal _TotalPrice_IncludingTax = default(Decimal);
		private Decimal _PricePerUnit_WithoutTax = default(Decimal);
		private Decimal _PricePerUnit_IncludingTax = default(Decimal);
		private Boolean _IsReplacementProduct = default(Boolean);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid ORD_PRC_RFP_IssuedProposalResponse_PositionID { 
			get {
				return _ORD_PRC_RFP_IssuedProposalResponse_PositionID;
			}
			set {
				if(_ORD_PRC_RFP_IssuedProposalResponse_PositionID != value){
					_ORD_PRC_RFP_IssuedProposalResponse_PositionID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String ProposalResponsePositionITPL { 
			get {
				return _ProposalResponsePositionITPL;
			}
			set {
				if(_ProposalResponsePositionITPL != value){
					_ProposalResponsePositionITPL = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid IssuedProposalResponseHeader_RefID { 
			get {
				return _IssuedProposalResponseHeader_RefID;
			}
			set {
				if(_IssuedProposalResponseHeader_RefID != value){
					_IssuedProposalResponseHeader_RefID = value;
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
		public Guid CreatedFrom_RequestForProposal_Position_RefID { 
			get {
				return _CreatedFrom_RequestForProposal_Position_RefID;
			}
			set {
				if(_CreatedFrom_RequestForProposal_Position_RefID != value){
					_CreatedFrom_RequestForProposal_Position_RefID = value;
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
		public Decimal TotalPrice_WithoutTax { 
			get {
				return _TotalPrice_WithoutTax;
			}
			set {
				if(_TotalPrice_WithoutTax != value){
					_TotalPrice_WithoutTax = value;
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
		public Decimal PricePerUnit_WithoutTax { 
			get {
				return _PricePerUnit_WithoutTax;
			}
			set {
				if(_PricePerUnit_WithoutTax != value){
					_PricePerUnit_WithoutTax = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Decimal PricePerUnit_IncludingTax { 
			get {
				return _PricePerUnit_IncludingTax;
			}
			set {
				if(_PricePerUnit_IncludingTax != value){
					_PricePerUnit_IncludingTax = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsReplacementProduct { 
			get {
				return _IsReplacementProduct;
			}
			set {
				if(_IsReplacementProduct != value){
					_IsReplacementProduct = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_ORD_PRC_RFP.ORD_PRC_RFP_IssuedProposalResponse_Position.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_ORD_PRC_RFP.ORD_PRC_RFP_IssuedProposalResponse_Position.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ORD_PRC_RFP_IssuedProposalResponse_PositionID", _ORD_PRC_RFP_IssuedProposalResponse_PositionID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ProposalResponsePositionITPL", _ProposalResponsePositionITPL);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IssuedProposalResponseHeader_RefID", _IssuedProposalResponseHeader_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_PRO_Product_RefID", _CMN_PRO_Product_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_PRO_Product_Variant_RefID", _CMN_PRO_Product_Variant_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_PRO_Product_Release_RefID", _CMN_PRO_Product_Release_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CreatedFrom_RequestForProposal_Position_RefID", _CreatedFrom_RequestForProposal_Position_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Quantity", _Quantity);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "TotalPrice_WithoutTax", _TotalPrice_WithoutTax);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "TotalPrice_IncludingTax", _TotalPrice_IncludingTax);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "PricePerUnit_WithoutTax", _PricePerUnit_WithoutTax);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "PricePerUnit_IncludingTax", _PricePerUnit_IncludingTax);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsReplacementProduct", _IsReplacementProduct);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Creation_Timestamp", _Creation_Timestamp);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Tenant_RefID", _Tenant_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsDeleted", _IsDeleted);


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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_ORD_PRC_RFP.ORD_PRC_RFP_IssuedProposalResponse_Position.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_ORD_PRC_RFP_IssuedProposalResponse_PositionID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ORD_PRC_RFP_IssuedProposalResponse_PositionID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "ORD_PRC_RFP_IssuedProposalResponse_PositionID","ProposalResponsePositionITPL","IssuedProposalResponseHeader_RefID","CMN_PRO_Product_RefID","CMN_PRO_Product_Variant_RefID","CMN_PRO_Product_Release_RefID","CreatedFrom_RequestForProposal_Position_RefID","Quantity","TotalPrice_WithoutTax","TotalPrice_IncludingTax","PricePerUnit_WithoutTax","PricePerUnit_IncludingTax","IsReplacementProduct","Creation_Timestamp","Tenant_RefID","IsDeleted" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter ORD_PRC_RFP_IssuedProposalResponse_PositionID of type Guid
						_ORD_PRC_RFP_IssuedProposalResponse_PositionID = reader.GetGuid(0);
						//1:Parameter ProposalResponsePositionITPL of type String
						_ProposalResponsePositionITPL = reader.GetString(1);
						//2:Parameter IssuedProposalResponseHeader_RefID of type Guid
						_IssuedProposalResponseHeader_RefID = reader.GetGuid(2);
						//3:Parameter CMN_PRO_Product_RefID of type Guid
						_CMN_PRO_Product_RefID = reader.GetGuid(3);
						//4:Parameter CMN_PRO_Product_Variant_RefID of type Guid
						_CMN_PRO_Product_Variant_RefID = reader.GetGuid(4);
						//5:Parameter CMN_PRO_Product_Release_RefID of type Guid
						_CMN_PRO_Product_Release_RefID = reader.GetGuid(5);
						//6:Parameter CreatedFrom_RequestForProposal_Position_RefID of type Guid
						_CreatedFrom_RequestForProposal_Position_RefID = reader.GetGuid(6);
						//7:Parameter Quantity of type double
						_Quantity = reader.GetDouble(7);
						//8:Parameter TotalPrice_WithoutTax of type Decimal
						_TotalPrice_WithoutTax = reader.GetDecimal(8);
						//9:Parameter TotalPrice_IncludingTax of type Decimal
						_TotalPrice_IncludingTax = reader.GetDecimal(9);
						//10:Parameter PricePerUnit_WithoutTax of type Decimal
						_PricePerUnit_WithoutTax = reader.GetDecimal(10);
						//11:Parameter PricePerUnit_IncludingTax of type Decimal
						_PricePerUnit_IncludingTax = reader.GetDecimal(11);
						//12:Parameter IsReplacementProduct of type Boolean
						_IsReplacementProduct = reader.GetBoolean(12);
						//13:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(13);
						//14:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(14);
						//15:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(15);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_ORD_PRC_RFP_IssuedProposalResponse_PositionID != Guid.Empty){
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
			public Guid? ORD_PRC_RFP_IssuedProposalResponse_PositionID {	get; set; }
			public String ProposalResponsePositionITPL {	get; set; }
			public Guid? IssuedProposalResponseHeader_RefID {	get; set; }
			public Guid? CMN_PRO_Product_RefID {	get; set; }
			public Guid? CMN_PRO_Product_Variant_RefID {	get; set; }
			public Guid? CMN_PRO_Product_Release_RefID {	get; set; }
			public Guid? CreatedFrom_RequestForProposal_Position_RefID {	get; set; }
			public double? Quantity {	get; set; }
			public Decimal? TotalPrice_WithoutTax {	get; set; }
			public Decimal? TotalPrice_IncludingTax {	get; set; }
			public Decimal? PricePerUnit_WithoutTax {	get; set; }
			public Decimal? PricePerUnit_IncludingTax {	get; set; }
			public Boolean? IsReplacementProduct {	get; set; }
			public DateTime? Creation_Timestamp {	get; set; }
			public Guid? Tenant_RefID {	get; set; }
			public Boolean? IsDeleted {	get; set; }
			 

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
			public static List<ORM_ORD_PRC_RFP_IssuedProposalResponse_Position> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_ORD_PRC_RFP_IssuedProposalResponse_Position> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_ORD_PRC_RFP_IssuedProposalResponse_Position> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_ORD_PRC_RFP_IssuedProposalResponse_Position> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_ORD_PRC_RFP_IssuedProposalResponse_Position> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_ORD_PRC_RFP_IssuedProposalResponse_Position>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "ORD_PRC_RFP_IssuedProposalResponse_PositionID","ProposalResponsePositionITPL","IssuedProposalResponseHeader_RefID","CMN_PRO_Product_RefID","CMN_PRO_Product_Variant_RefID","CMN_PRO_Product_Release_RefID","CreatedFrom_RequestForProposal_Position_RefID","Quantity","TotalPrice_WithoutTax","TotalPrice_IncludingTax","PricePerUnit_WithoutTax","PricePerUnit_IncludingTax","IsReplacementProduct","Creation_Timestamp","Tenant_RefID","IsDeleted" });
			        while (reader.Read())
			        {
			            ORM_ORD_PRC_RFP_IssuedProposalResponse_Position item = new ORM_ORD_PRC_RFP_IssuedProposalResponse_Position();
						//0:Parameter ORD_PRC_RFP_IssuedProposalResponse_PositionID of type Guid
						item.ORD_PRC_RFP_IssuedProposalResponse_PositionID = reader.GetGuid(0);
						//1:Parameter ProposalResponsePositionITPL of type String
						item.ProposalResponsePositionITPL = reader.GetString(1);
						//2:Parameter IssuedProposalResponseHeader_RefID of type Guid
						item.IssuedProposalResponseHeader_RefID = reader.GetGuid(2);
						//3:Parameter CMN_PRO_Product_RefID of type Guid
						item.CMN_PRO_Product_RefID = reader.GetGuid(3);
						//4:Parameter CMN_PRO_Product_Variant_RefID of type Guid
						item.CMN_PRO_Product_Variant_RefID = reader.GetGuid(4);
						//5:Parameter CMN_PRO_Product_Release_RefID of type Guid
						item.CMN_PRO_Product_Release_RefID = reader.GetGuid(5);
						//6:Parameter CreatedFrom_RequestForProposal_Position_RefID of type Guid
						item.CreatedFrom_RequestForProposal_Position_RefID = reader.GetGuid(6);
						//7:Parameter Quantity of type double
						item.Quantity = reader.GetDouble(7);
						//8:Parameter TotalPrice_WithoutTax of type Decimal
						item.TotalPrice_WithoutTax = reader.GetDecimal(8);
						//9:Parameter TotalPrice_IncludingTax of type Decimal
						item.TotalPrice_IncludingTax = reader.GetDecimal(9);
						//10:Parameter PricePerUnit_WithoutTax of type Decimal
						item.PricePerUnit_WithoutTax = reader.GetDecimal(10);
						//11:Parameter PricePerUnit_IncludingTax of type Decimal
						item.PricePerUnit_IncludingTax = reader.GetDecimal(11);
						//12:Parameter IsReplacementProduct of type Boolean
						item.IsReplacementProduct = reader.GetBoolean(12);
						//13:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(13);
						//14:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(14);
						//15:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(15);


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
