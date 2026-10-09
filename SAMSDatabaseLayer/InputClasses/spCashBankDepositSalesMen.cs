using System;
using System.Data;
using SAMSCommon.Classes;
using SAMSDataAccessLayer.Classes;
namespace SAMSDatabaseLayer.Classes
{
	public class spCashBankDepositSalesMen
	{
		#region Private Members
		private string sp_Name = "spCashBankDepositSalesMen" ;
		private IDbConnection m_connection;
		private IDbTransaction m_transaction;
		private int m_DISTRIBUTOR_ID;
		private int m_PRINCIPAL_ID;
		private int m_DEPOSIT_TYPE;
		private DateTime m_START_DATE;
		private DateTime m_END_DATE;
		private string m_DELIVERYMAN_ID;
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
		public int PRINCIPAL_ID
		{
			set
			{
				m_PRINCIPAL_ID = value ;
			}
			get
			{
				return m_PRINCIPAL_ID;
			}
		}
		public int DEPOSIT_TYPE
		{
			set
			{
				m_DEPOSIT_TYPE = value ;
			}
			get
			{
				return m_DEPOSIT_TYPE;
			}
		}
		public DateTime START_DATE
		{
			set
			{
				m_START_DATE = value ;
			}
			get
			{
				return m_START_DATE;
			}
		}
		public DateTime END_DATE
		{
			set
			{
				m_END_DATE = value ;
			}
			get
			{
				return m_END_DATE;
			}
		}
		public string DELIVERYMAN_ID
		{
			set
			{
				m_DELIVERYMAN_ID = value ;
			}
			get
			{
				return m_DELIVERYMAN_ID;
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
		public spCashBankDepositSalesMen()
		{
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
				m_PRINCIPAL_ID= Convert.ToInt32(dr["PRINCIPAL_ID"]);
				m_DEPOSIT_TYPE= Convert.ToInt32(dr["DEPOSIT_TYPE"]);
				m_START_DATE= Convert.ToDateTime(dr["START_DATE"]);
				m_END_DATE= Convert.ToDateTime(dr["END_DATE"]);
				m_DELIVERYMAN_ID= Convert.ToString(dr["DELIVERYMAN_ID"]);
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
			parameter.ParameterName = "@PRINCIPAL_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_PRINCIPAL_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_PRINCIPAL_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@DEPOSIT_TYPE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_DEPOSIT_TYPE==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_DEPOSIT_TYPE;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@START_DATE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
			if(m_START_DATE==Constants.DateNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_START_DATE;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@END_DATE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
			if(m_END_DATE==Constants.DateNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_END_DATE;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@DELIVERYMAN_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.NVarChar);
			if(m_DELIVERYMAN_ID== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_DELIVERYMAN_ID;
			}
			pparams.Add(parameter);



		}
		#endregion
	}
}
