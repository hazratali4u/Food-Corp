using System;
using System.Data;
using SAMSCommon.Classes;
using SAMSDataAccessLayer.Classes;

namespace SAMSDatabaseLayer.Classes
{
	public class spInsertSALE_INVOICE_DISCOUNT
	{
		#region Private Members
		private string sp_Name = "spInsertSALE_INVOICE_DISCOUNT" ;
		private IDbConnection m_connection;
		private IDbTransaction m_transaction;
		private int m_DISTRIBUTOR_ID;
		private decimal m_WHOLE_SALE_DISCOUNT;
		private decimal m_BRD;
		private decimal m_TRADE_OFFER;
		private decimal m_OTHER_DISCOUNT;
		private decimal m_INCENTIVE;
		private decimal m_RENTAL;
		private decimal m_DISPLAY;
		private bool m_IS_DELETED;
		private long m_SALE_INVOICE_ID;
		private long m_INVOICE_DISCOUNT_ID;
		private string m_MANUAL_INVOICE_ID;
		#endregion
		#region Public Properties
		public int DISTRIBUTOR_ID
		{
			set
			{
				m_DISTRIBUTOR_ID = value ;
			}
			get
			{
				return m_DISTRIBUTOR_ID;
			}
		}
		public decimal  WHOLE_SALE_DISCOUNT
		{
			set
			{
				m_WHOLE_SALE_DISCOUNT = value ;
			}
			get
			{
				return m_WHOLE_SALE_DISCOUNT;
			}
		}
		public decimal  BRD
		{
			set
			{
				m_BRD = value ;
			}
			get
			{
				return m_BRD;
			}
		}
		public decimal  TRADE_OFFER
		{
			set
			{
				m_TRADE_OFFER = value ;
			}
			get
			{
				return m_TRADE_OFFER;
			}
		}
		public decimal  OTHER_DISCOUNT
		{
			set
			{
				m_OTHER_DISCOUNT = value ;
			}
			get
			{
				return m_OTHER_DISCOUNT;
			}
		}
		public decimal  INCENTIVE
		{
			set
			{
				m_INCENTIVE = value ;
			}
			get
			{
				return m_INCENTIVE;
			}
		}
		public decimal  RENTAL
		{
			set
			{
				m_RENTAL = value ;
			}
			get
			{
				return m_RENTAL;
			}
		}
		public decimal  DISPLAY
		{
			set
			{
				m_DISPLAY = value ;
			}
			get
			{
				return m_DISPLAY;
			}
		}
		public bool IS_DELETED
		{
			set
			{
				m_IS_DELETED = value ;
			}
			get
			{
				return m_IS_DELETED;
			}
		}
		public long SALE_INVOICE_ID
		{
			set
			{
				m_SALE_INVOICE_ID = value ;
			}
			get
			{
				return m_SALE_INVOICE_ID;
			}
		}
		public long INVOICE_DISCOUNT_ID
		{
			get
			{
				return m_INVOICE_DISCOUNT_ID;
			}
		}
		public  string MANUAL_INVOICE_ID
		{
			set
			{
				m_MANUAL_INVOICE_ID = value ;
			}
			get
			{
				return m_MANUAL_INVOICE_ID;
			}
		}


		public IDbConnection  Connection
		{
			set
			{
				m_connection = value;
			}
			get
			{
				return m_connection;
			}
		}
		public IDbTransaction  Transaction
		{
			set
			{
				m_transaction = value;
			}
			get
			{
				return m_transaction;
			}
		}
		#endregion
		#region Constructor
		public spInsertSALE_INVOICE_DISCOUNT()
		{
            m_DISTRIBUTOR_ID = Constants.IntNullValue;
            m_SALE_INVOICE_ID = Constants.LongNullValue;
            m_IS_DELETED = false;
		}
		#endregion
		#region public Methods
		public bool  ExecuteQuery()
		{
			try
			{
			    IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
				cmd.CommandType =  CommandType.StoredProcedure;
				cmd.CommandText = sp_Name;
				cmd.Connection =   m_connection;
				if(m_transaction!=null)
				{
					cmd.Transaction = m_transaction;
				}
				GetParameterCollection(ref cmd);
				cmd.ExecuteNonQuery();
				m_INVOICE_DISCOUNT_ID = (long)((IDataParameter)(cmd.Parameters["@INVOICE_DISCOUNT_ID"])).Value;
				return true;
			}
			catch(Exception e)
			{
				throw e;
			}
			finally
			{
			}
		}
		public IDataReader ExecuteReader()
		{
			try
			{
				IDbCommand command = ProviderFactory.GetCommand(EnumProviders.SQLClient);
				command.CommandType = CommandType.StoredProcedure;
				command.CommandText = sp_Name;
				command.Connection = m_connection;
				if(m_transaction!=null)
				{
					command.Transaction = m_transaction;
				}
				GetParameterCollection(ref command);
				IDataReader dr = command.ExecuteReader();
				return dr;
			}
			catch(Exception exp)
			{
				throw exp;
			}
			finally
			{
			}
		}
		public DataTable ExecuteTable()
		{
			try
			{
				IDbCommand command = ProviderFactory.GetCommand(EnumProviders.SQLClient);
				command.CommandType = CommandType.StoredProcedure;
				command.CommandText = sp_Name;
				command.Connection = m_connection;
				if(m_transaction!=null)
				{
					command.Transaction = m_transaction;
				}
				GetParameterCollection(ref command);
				IDbDataAdapter da = ProviderFactory.GetAdapter(EnumProviders.SQLClient);
				da.SelectCommand = command;
				DataSet ds = new DataSet();
				da.Fill(ds);
				return ds.Tables[0];
			}
			catch(Exception exp)
			{
				throw exp;
			}
			finally
			{
			}
		}
		public string ExecuteScalar()
		{
			try
			{
				IDbCommand command = ProviderFactory.GetCommand(EnumProviders.SQLClient);
				command.CommandType = CommandType.StoredProcedure;
				command.CommandText = sp_Name;
				command.Connection = m_connection;
				if(m_transaction!=null)
				{
					command.Transaction = m_transaction;
				}
				GetParameterCollection(ref command);
				object o;
				o = command.ExecuteScalar();


				return o.ToString();
			}
			catch(Exception exp)
			{
				throw exp;
			}
			finally
			{
			}
		}
		public void FirstReader(IDataReader dr)
		{
			if(dr.Read())
			{
				m_DISTRIBUTOR_ID= Convert.ToInt32(dr["DISTRIBUTOR_ID"]);
				m_WHOLE_SALE_DISCOUNT= Convert.ToDecimal(dr["WHOLE_SALE_DISCOUNT"]);
				m_BRD= Convert.ToDecimal(dr["BRD"]);
				m_TRADE_OFFER= Convert.ToDecimal(dr["TRADE_OFFER"]);
				m_OTHER_DISCOUNT= Convert.ToDecimal(dr["OTHER_DISCOUNT"]);
				m_INCENTIVE= Convert.ToDecimal(dr["INCENTIVE"]);
				m_RENTAL= Convert.ToDecimal(dr["RENTAL"]);
				m_DISPLAY= Convert.ToDecimal(dr["DISPLAY"]);
				m_IS_DELETED=Convert.ToBoolean(dr["IS_DELETED"]);
				m_SALE_INVOICE_ID=Convert.ToInt64(dr["SALE_INVOICE_ID"]);
				m_INVOICE_DISCOUNT_ID=Convert.ToInt64(dr["INVOICE_DISCOUNT_ID"]);
				m_MANUAL_INVOICE_ID= Convert.ToString(dr["MANUAL_INVOICE_ID"]);
			}
		}
		public void GetParameterCollection(ref IDbCommand cmd)
		{
			IDataParameterCollection pparams = cmd.Parameters;
			IDataParameter parameter ;
			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@DISTRIBUTOR_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_DISTRIBUTOR_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_DISTRIBUTOR_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@WHOLE_SALE_DISCOUNT" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
			if(m_WHOLE_SALE_DISCOUNT==Constants.DecimalNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_WHOLE_SALE_DISCOUNT;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@BRD" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
			if(m_BRD==Constants.DecimalNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_BRD;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@TRADE_OFFER" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
			if(m_TRADE_OFFER==Constants.DecimalNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_TRADE_OFFER;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@OTHER_DISCOUNT" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
			if(m_OTHER_DISCOUNT==Constants.DecimalNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_OTHER_DISCOUNT;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@INCENTIVE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
			if(m_INCENTIVE==Constants.DecimalNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_INCENTIVE;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@RENTAL" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
			if(m_RENTAL==Constants.DecimalNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_RENTAL;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@DISPLAY" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
			if(m_DISPLAY==Constants.DecimalNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_DISPLAY;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@IS_DELETED" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
				parameter.Value = m_IS_DELETED;
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@SALE_INVOICE_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
			if(m_SALE_INVOICE_ID==Constants.LongNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_SALE_INVOICE_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@INVOICE_DISCOUNT_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
			parameter.Direction = ParameterDirection.Output;
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@MANUAL_INVOICE_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_MANUAL_INVOICE_ID== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_MANUAL_INVOICE_ID;
			}
			pparams.Add(parameter);


		}
		#endregion
	}
}
