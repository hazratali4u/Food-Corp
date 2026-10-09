using System;
using System.Data;
using SAMSCommon.Classes;
using SAMSDataAccessLayer.Classes;
using SAMSDatabaseLayer.Classes;
using SAMSDatabaseLayer.InputClasses;

namespace SAMSBusinessLayer.Classes
{
    /// <summary>
    /// Class For Fetching Data Of Different Crystal Reports
    /// </summary>
    public class DocumentPrintController
    {
        #region Constructor

        /// <summary>
        /// Constructor for DocumentPrintController
        /// </summary>
        public DocumentPrintController()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

        #region Public Methods

        /// <summary>
        /// Gets Company Name For All Reports
        /// </summary>
        /// <param name="p_Distributor_ID">Location</param>
        /// <returns></returns>
        public DataTable SelectReportTitle(int p_Distributor_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspSelectReportTitile ObjPrint = new UspSelectReportTitile();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBUTOR_ID = p_Distributor_ID;
                DataTable dt = ObjPrint.ExecuteTable();
                return dt;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return null;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }
        }

        public DataTable SelectDistributoUrl(int p_Distributor_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspSelectDistributorUrl ObjPrint = new UspSelectDistributorUrl();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBUTOR_ID = p_Distributor_ID;
                DataTable dt = ObjPrint.ExecuteTable();
                return dt;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return null;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }
        }

        /// <summary>
        /// Gets Data For Print Sale Document Report
        /// </summary>
        /// <param name="p_Distributor_ID">Location</param>
        /// <param name="p_Areaid">Route</param>
        /// <param name="p_Principal_Id">Principal</param>
        /// <param name="FromDocNo">DateFrom</param>
        /// <param name="ToDocNo">DateTo</param>
        /// <param name="DocumentTypeId">Type</param>
        /// <param name="p_DOCUMENT_ID">Document</param>
        /// <param name="p_IS_REGISTERED">IsRegistered</param>
        /// <param name="p_CUSTOMER_ID">Customer</param>
        /// <param name="p_Route_ID">Market</param>
        /// <returns>DataSet</returns>
        public DataSet SelectDocumentforPrint(int p_Distributor_ID, int p_Areaid, int p_Principal_Id, DateTime FromDocNo, DateTime ToDocNo, int DocumentTypeId, long p_DOCUMENT_ID, int p_IS_REGISTERED, int p_CUSTOMER_ID, int p_Route_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspDocumentPrinting ObjPrint = new UspDocumentPrinting();
                SAMSBusinessLayer.Reports.DsReport ds = new SAMSBusinessLayer.Reports.DsReport();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBTOR_ID = p_Distributor_ID;
                ObjPrint.AREA_ID = p_Areaid;
                ObjPrint.PRINCIPAL_ID = p_Principal_Id;
                ObjPrint.FROM_DATE = FromDocNo;
                ObjPrint.TO_DATE = ToDocNo;
                ObjPrint.TYPE_ID = DocumentTypeId;
                ObjPrint.DOCUMENT_ID = p_DOCUMENT_ID;
                ObjPrint.IS_REGISTERED = p_IS_REGISTERED;
                ObjPrint.CUSTOMER_ID = p_CUSTOMER_ID;
                ObjPrint.ROUTE_ID = p_Route_ID;
                DataTable dt = ObjPrint.ExecuteTable();

                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["SALE_DOCUMENTPRINT"].ImportRow(dr);
                }

                uspPrintSALE_ORDER_PROMOTION Promotion = new uspPrintSALE_ORDER_PROMOTION();

                Promotion.Connection = mConnection;
                Promotion.DISTRIBTOR_ID = p_Distributor_ID;
                Promotion.AREA_ID = p_Areaid;
                Promotion.PRINCIPAL_ID = p_Principal_Id;
                Promotion.FROM_DATE = FromDocNo;
                Promotion.TO_DATE = ToDocNo;
                Promotion.TYPE_ID = DocumentTypeId;
                DataTable dtPro = Promotion.ExecuteTable();

                foreach (DataRow dr in dtPro.Rows)
                {
                    ds.Tables["SALE_PROMOTIONPRINT"].ImportRow(dr);
                }
                return ds;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return null;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }

        }
        
        /// <summary>
        /// Gets Data For Role Management (View Report)
        /// </summary>
        /// <param name="p_Role_Id">Role</param>
        /// <returns>DataSet</returns>
        public DataSet SelectRoleManagmentReport(int p_Role_Id)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspRolemanagementDetail ObjPrint = new UspRolemanagementDetail();
                SAMSBusinessLayer.Reports.DsReport2 ds = new SAMSBusinessLayer.Reports.DsReport2();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBUTOR_ID = Constants.IntNullValue;
                ObjPrint.ROLE_ID = p_Role_Id;
                DataTable dt = ObjPrint.ExecuteTable();
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["RptRoleManagement"].ImportRow(dr);
                }

                return ds;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return null;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }
        }
        
        /// <summary>
        /// Gets Data For Voucher Editing (Print Voucher)
        /// </summary>
        /// <param name="p_Vouchertype_id">Type</param>
        /// <param name="p_DistributorId">Location</param>
        /// <param name="p_Fromdate">DateFrom</param>
        /// <param name="p_ToDate">DateTo</param>
        /// <param name="Posted">Posted</param>
        /// <param name="p_UserId">User</param>
        /// <returns>DataSet</returns>
        public DataSet PrintVouchers(int p_Vouchertype_id, int p_DistributorId, DateTime p_Fromdate, DateTime p_ToDate, int Posted, int p_UserId)
        {
            IDbConnection mConnection = null;
            try
            {
                SAMSBusinessLayer.Reports.DsReport2 ds = new SAMSBusinessLayer.Reports.DsReport2();
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spPrintVouchers ObjLedger = new spPrintVouchers();
                ObjLedger.Connection = mConnection;
                ObjLedger.VOUCHER_TYPE_ID = p_Vouchertype_id;
                ObjLedger.DISTRIBUTOR_ID = p_DistributorId;
                ObjLedger.FROM_DATE = p_Fromdate;
                ObjLedger.TO_DATE = p_ToDate;
                ObjLedger.POSTED = Posted;
                ObjLedger.USER_ID = p_UserId;
                DataTable dt = ObjLedger.ExecuteTable();

                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["RptVoucherView"].ImportRow(dr);
                }
                return ds;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return null;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }
        }

        public DataSet GetCreditAgingSummary(int p_DISTRIBUTOR_ID, int p_PRINCIPAL_ID, long p_CUSTOMER_ID, DateTime p_DATE_TO, int p_SORT_BY, int p_ORDER_BY)
        {

            IDbConnection mConnection = null;

            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                Reports.dsSalesPurchaseRegister ds = new Reports.dsSalesPurchaseRegister();
                uspGetCreditAgingSummary objCreditAge = new uspGetCreditAgingSummary();
                objCreditAge.Connection = mConnection;
                objCreditAge.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                objCreditAge.PRINCIPAL_ID = p_PRINCIPAL_ID;
                objCreditAge.CUSTOMER_ID = p_CUSTOMER_ID;
                objCreditAge.DATE_TO = p_DATE_TO;
                objCreditAge.SORT_BY = p_SORT_BY;
                objCreditAge.ORDER_BY = p_ORDER_BY;
                DataTable DT = objCreditAge.ExecuteTable();

                foreach (DataRow dr in DT.Rows)
                {
                    ds.Tables["uspGetCreditAgingSummary"].ImportRow(dr);
                }
                return ds;
            }
            catch (Exception excp)
            {
                ExceptionPublisher.PublishException(excp);
                return null;

            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }
        }

        public DataSet GetCreditAgingReport(int P_DistributorType, int P_PrincipalId, int P_DistributorId, int p_UserId, int p_Type, DateTime p_Document_Date)
        {

            IDbConnection mConnection = null;

            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                Reports.DsReport ds = new Reports.DsReport();
                UspCreditAgintReport2 obj_regionwise = new UspCreditAgintReport2();
                obj_regionwise.Connection = mConnection;
                obj_regionwise.DISTRIBUTOR_ID = P_DistributorId;
                obj_regionwise.DISTRIBUTOR_TYPE_ID = P_DistributorType;
                obj_regionwise.TYPE_ID = p_Type;
                obj_regionwise.PRINCIPAL_ID = P_PrincipalId;
                obj_regionwise.USER_ID = p_UserId;
                obj_regionwise.DOCUMENT_DATE = p_Document_Date;
                DataTable DT = obj_regionwise.ExecuteTable();

                foreach (DataRow dr in DT.Rows)
                {
                    ds.Tables["RptCreditAgingReport"].ImportRow(dr);
                }
                return ds;
            }
            catch (Exception excp)
            {
                ExceptionPublisher.PublishException(excp);
                return null;

            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }
        }
        #endregion

        #region M. IJAZ JAMIL AKHTAR
        public DataSet SelectAccountHeadMappingReport(int Type_ID, int p_Distributor_Id)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectACCOUNT_HEAD_MAPPING ObjPrint = new spSelectACCOUNT_HEAD_MAPPING();
                SAMSBusinessLayer.Reports.dsSalesPurchaseRegister ds = new SAMSBusinessLayer.Reports.dsSalesPurchaseRegister();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBUTOR_ID = p_Distributor_Id;
                ObjPrint.TYPE_ID = Type_ID;
                DataTable dt = ObjPrint.ExecuteTable();
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["spSelectACCOUNT_HEAD_MAPPING"].ImportRow(dr);
                }

                return ds;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return null;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }
        }
        #endregion
    }
}