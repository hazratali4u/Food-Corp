using System;
using System.Data;
using SAMSCommon.Classes;
using SAMSDataAccessLayer.Classes;
using SAMSDatabaseLayer.Classes;
using SAMSDatabaseLayer.InputClasses;

namespace SAMSBusinessLayer.Classes
{
    /// <summary>
    /// Class For Purchase, TranferOut, Purchase Return, TranferIn And Damage Related Tasks
    /// <example>
    /// <list type="bullet">
    /// <item>
    /// Insert Purchase, TranferOut, Purchase Return, TranferIn And Damage
    /// </item>
    /// <term>
    /// Update Purchase, TranferOut, Purchase Return, TranferIn And Damage
    /// </term>
    /// <item>
    /// Get Purchase, TranferOut, Purchase Return, TranferIn And Damage
    /// </item>
    /// </list>
    /// </example>
    /// </summary>
    public class PurchaseController
    {
        #region Constructor

        /// <summary>
        /// Constructor for PurchaseController
        /// </summary>
        public PurchaseController()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

        #region Private Variables
        
        IDbTransaction mTransaction;
        IDbConnection mConnection;

        #endregion

        #region Public Methods

        #region Select

        /// <summary>
        /// Get Purchase, TranferOut, Purchase Return, TranferIn And Damage Detail
        /// </summary>
        /// <remarks>
        /// Returns Purchase, TranferOut, Purchase Return, TranferIn And Damage Detail as Datatable
        /// </remarks>
        /// <param name="p_DISTRIBUTOR_ID">Location</param>
        /// <param name="p_PURCHASE_MASTER_ID">Purchase</param>
        /// <param name="PConnection">Connection</param>
        /// <param name="PTransaction">Transaction</param>
        /// <returns>Purchase, TranferOut, Purchase Return, TranferIn And Damage Detail as Datatable</returns>
        public DataTable SelectPrivousePurchaseDetail(int p_DISTRIBUTOR_ID, long p_PURCHASE_MASTER_ID, IDbConnection PConnection, IDbTransaction PTransaction)
        {
            try
            {
                spSelectPURCHASE_DETAIL mPurchaseDetail = new spSelectPURCHASE_DETAIL();
                mPurchaseDetail.Connection = PConnection;
                mPurchaseDetail.Transaction = PTransaction;
                mPurchaseDetail.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mPurchaseDetail.PURCHASE_MASTER_ID = p_PURCHASE_MASTER_ID;
                DataTable dt = mPurchaseDetail.ExecuteTable();
                return dt;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return null;
            }
        }

        /// <summary>
        /// Gets Purchase, TranferOut, Purchase Return, TranferIn And Damage Document No
        /// </summary>
        /// <remarks>
        /// Returns Purchase, TranferOut, Purchase Return, TranferIn And Damage Document No as Datatable
        /// </remarks>
        /// <param name="p_TYPE_ID">Type</param>
        /// <param name="p_DISTRIBUTOR_ID">Location</param>
        /// <param name="p_PURCHASE_MASTER_ID">Purchase</param>
        /// <param name="p_User_Id">InsertedBy</param>
        /// <param name="p_Posting">Posting</param>
        /// <returns>Purchase, TranferOut, Purchase Return, TranferIn And Damage  Document No as Datatable</returns>
        public DataTable SelectPurchaseDocumentNo(int p_TYPE_ID, int p_DISTRIBUTOR_ID, long p_PURCHASE_MASTER_ID, int p_User_Id, int p_Posting)
        {
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectPURCHASE_MASTER mPurchaseMaster = new spSelectPURCHASE_MASTER();
                mPurchaseMaster.Connection = mConnection;
                mPurchaseMaster.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mPurchaseMaster.TYPE_ID = p_TYPE_ID;
                mPurchaseMaster.PURCHASE_MASTER_ID = p_PURCHASE_MASTER_ID;
                mPurchaseMaster.USER_ID = p_User_Id;
                mPurchaseMaster.POSTING = p_Posting;
                DataTable dt = mPurchaseMaster.ExecuteTable();
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
        /// Gets Purchase, TranferOut, Purchase Return, TranferIn And Damage Document No
        /// </summary>
        /// <remarks>
        /// Returns Purchase, TranferOut, Purchase Return, TranferIn And Damage Document No as Datatable
        /// </remarks>
        /// <param name="p_TYPE_ID">Type</param>
        /// <param name="p_DISTRIBUTOR_ID">Location</param>
        /// <param name="P_DocumentDate">Date</param>
        /// <returns>Purchase, TranferOut, Purchase Return, TranferIn And Damage Document No as Datatable</returns>
        public DataTable SelectPurchaseDocumentNo(int p_TYPE_ID, int p_DISTRIBUTOR_ID, DateTime P_DocumentDate)
        {
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectPURCHASE_MASTER mPurchaseMaster = new spSelectPURCHASE_MASTER();
                mPurchaseMaster.Connection = mConnection;
                mPurchaseMaster.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mPurchaseMaster.TYPE_ID = p_TYPE_ID;
                mPurchaseMaster.DOCUMENT_DATE = P_DocumentDate;
                DataTable dt = mPurchaseMaster.ExecuteTable();
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
        /// Gets Purchase, TranferOut, Purchase Return, TranferIn And Damage Document No
        /// </summary>
        /// <remarks>
        /// Returns Purchase, TranferOut, Purchase Return, TranferIn And Damage Document No as Datatable
        /// </remarks>
        /// <param name="p_TYPE_ID">Type</param>
        /// <param name="p_DISTRIBUTOR_ID">Location</param>
        /// <param name="p_PURCHASE_MASTER_ID">Purchase</param>
        /// <param name="p_User_Id">InsertedBy</param>
        /// <param name="p_Posting">Posting</param>
        /// <param name="p_SOLD_TO">SoldTo</param>
        /// <returns>Purchase, TranferOut, Purchase Return, TranferIn And Damage Document No as Datatable</returns>
        public DataTable SelectPurchaseDocumentNo(int p_TYPE_ID, int p_DISTRIBUTOR_ID, long p_PURCHASE_MASTER_ID, int p_User_Id, int p_Posting, int p_SOLD_TO)
        {
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectPURCHASE_MASTER mPurchaseMaster = new spSelectPURCHASE_MASTER();
                mPurchaseMaster.Connection = mConnection;
                mPurchaseMaster.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mPurchaseMaster.TYPE_ID = p_TYPE_ID;
                mPurchaseMaster.PURCHASE_MASTER_ID = p_PURCHASE_MASTER_ID;
                mPurchaseMaster.USER_ID = Constants.IntNullValue;
                mPurchaseMaster.POSTING = p_Posting;
                mPurchaseMaster.SOLD_TO = p_SOLD_TO;
                DataTable dt = mPurchaseMaster.ExecuteTable();
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
        /// Get Purchase, TranferOut, Purchase Return, TranferIn And Damage Detail
        /// </summary>
        /// <remarks>
        /// Returns Purchase, TranferOut, Purchase Return, TranferIn And Damage Detail as Datatable
        /// </remarks>
        /// <param name="p_DISTRIBUTOR_ID">Location</param>
        /// <param name="p_PURCHASE_MASTER_ID">Purchase</param>
        /// <returns>Purchase, TranferOut, Purchase Return, TranferIn And Damage Detail as Datatable</returns>
        public DataTable SelectPurchaseDetail(int p_DISTRIBUTOR_ID, long p_PURCHASE_MASTER_ID)
        {
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                
                spSelectPURCHASE_DETAIL mPurchaseDetail = new spSelectPURCHASE_DETAIL();
                mPurchaseDetail.Connection = mConnection;
                mPurchaseDetail.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mPurchaseDetail.PURCHASE_MASTER_ID = p_PURCHASE_MASTER_ID;
                DataTable dt = mPurchaseDetail.ExecuteTable();
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

        public DataTable SelectPurchaseDetailOpening(int p_DISTRIBUTOR_ID, long p_PURCHASE_MASTER_ID)
        {
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectPURCHASE_DETAILOpnong mPurchaseDetail = new spSelectPURCHASE_DETAILOpnong();
                mPurchaseDetail.Connection = mConnection;
                mPurchaseDetail.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mPurchaseDetail.PURCHASE_MASTER_ID = p_PURCHASE_MASTER_ID;
                DataTable dt = mPurchaseDetail.ExecuteTable();
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




        public DataTable SelectPurchaseDetailstock(int p_DISTRIBUTOR_ID, long p_PURCHASE_MASTER_ID)
        {
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                //by Safdar.. the origional was spSelectPURCHASE_DETAIL 
                spSelectPURCHASE_DETAIL2 mPurchaseDetail = new spSelectPURCHASE_DETAIL2();
                mPurchaseDetail.Connection = mConnection;
                mPurchaseDetail.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mPurchaseDetail.PURCHASE_MASTER_ID = p_PURCHASE_MASTER_ID;
                DataTable dt = mPurchaseDetail.ExecuteTable();
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
        #endregion

        #region Insert, Update

        /// <summary>
        /// Inserts Purchase, TranferOut, Purchase Return, TranferIn And Damage Document
        /// </summary>
        /// <param name="p_DISTRIBUTOR_ID">Location</param>
        /// <param name="p_ORDER_NUMBER">DocumentNo</param>
        /// <param name="p_TYPE_ID">Type</param>
        /// <param name="p_DOCUMENT_DATE">Date</param>
        /// <param name="p_SOLD_TO">SoldTo</param>
        /// <param name="p_SOLD_FROM">SoldFrom</param>
        /// <param name="p_TOTAL_AMOUNT">Amount</param>
        /// <param name="p_IS_DELETE">IsDeleted</param>
        /// <param name="dtPurchaseDetail">PurchaseDetailDatatable</param>
        /// <param name="p_Posting">Posting</param>
        /// <param name="p_BuiltyNo">Builty</param>
        /// <param name="p_UserId">InsertedBy</param>
        /// <param name="p_PrincipalId">Principal</param>
        /// <returns>True On Success And False On Failure</returns>
        public bool InsertPurchaseDocument(int p_DISTRIBUTOR_ID,string p_ORDER_NUMBER,int p_TYPE_ID,DateTime p_DOCUMENT_DATE,int p_SOLD_TO,int p_SOLD_FROM,decimal p_TOTAL_AMOUNT,bool p_IS_DELETE,DataTable dtPurchaseDetail,int p_Posting,string p_BuiltyNo,int p_UserId,int p_PrincipalId) 
		{
			try
			{
                

                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
                mTransaction = ProviderFactory.GetTransaction(mConnection);
                spInsertPURCHASE_MASTER mPurchaseMaster = new spInsertPURCHASE_MASTER();
                mPurchaseMaster.Connection = mConnection;
                mPurchaseMaster.Transaction = mTransaction;
                mPurchaseMaster.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mPurchaseMaster.TYPE_ID = p_TYPE_ID;
                mPurchaseMaster.ORDER_NUMBER = p_ORDER_NUMBER;
                mPurchaseMaster.SOLD_FROM = p_SOLD_FROM;
                mPurchaseMaster.DOCUMENT_DATE = p_DOCUMENT_DATE;  
                mPurchaseMaster.SOLD_TO = p_SOLD_TO;
                mPurchaseMaster.TOTAL_AMOUNT = p_TOTAL_AMOUNT;
                mPurchaseMaster.USER_ID = p_UserId;
                mPurchaseMaster.TIME_STAMP = DateTime.Now;
                mPurchaseMaster.LAST_UPDATE = DateTime.Now;   
                mPurchaseMaster.POSTING = p_Posting;
                mPurchaseMaster.BUILTY_NO = p_BuiltyNo;
                mPurchaseMaster.PRINCIPAL_ID = p_PrincipalId; 
                mPurchaseMaster.ExecuteQuery();

                spInsertPURCHASE_DETAIL mPurchaseDetail = new spInsertPURCHASE_DETAIL();
                mPurchaseDetail.Connection = mConnection;
                mPurchaseDetail.Transaction = mTransaction;
                
                foreach (DataRow dr in dtPurchaseDetail.Rows)
                {
                    mPurchaseDetail.PURCHASE_MASTER_ID = mPurchaseMaster.PURCHASE_MASTER_ID;
                    mPurchaseDetail.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                    mPurchaseDetail.SKU_ID = int.Parse(dr["SKU_ID"].ToString());
                    mPurchaseDetail.BATCH_NO = dr["BATCH_NO"].ToString();
                    mPurchaseDetail.PRICE = decimal.Parse(dr["PRICE"].ToString());
                    mPurchaseDetail.QUANTITY = int.Parse(dr["Total_Unit"].ToString());
                    mPurchaseDetail.FREE_SKU = int.Parse(dr["FREE_SKU"].ToString());
                    mPurchaseDetail.AMOUNT = decimal.Parse(dr["AMOUNT"].ToString());
                    mPurchaseDetail.TYPE_ID = mPurchaseMaster.TYPE_ID;
                    mPurchaseDetail.TIME_STAMP = p_DOCUMENT_DATE;
                   
                    mPurchaseDetail.ExecuteQuery();
                    
                    UspProcessStockRegister mStockUpdate = new UspProcessStockRegister();
                    mStockUpdate.Connection = mConnection;
                    mStockUpdate.Transaction = mTransaction;
                    mStockUpdate.PRINCIPAL_ID = p_PrincipalId; 
                    mStockUpdate.TYPE_ID = mPurchaseMaster.TYPE_ID;
                    mStockUpdate.DISTRIBUTOR_ID = mPurchaseMaster.DISTRIBUTOR_ID;
                    mStockUpdate.STOCK_DATE = mPurchaseMaster.DOCUMENT_DATE;
                    mStockUpdate.SKU_ID = mPurchaseDetail.SKU_ID;
                    mStockUpdate.STOCK_QTY = mPurchaseDetail.QUANTITY;
                    mStockUpdate.FREE_QTY = mPurchaseDetail.FREE_SKU;
                    mStockUpdate.BATCHNO = mPurchaseDetail.BATCH_NO;   
                    mStockUpdate.ExecuteQuery();   
                }

                CustomerDataController cd = new CustomerDataController();
                string p_Voucher_No = "";
                string CodeFileName = "";
                int CodeFileType = 0;
                DataTable dtMappSetting = cd.SelectMappingSetting(Constants.IntNullValue, Constants.IntNullValue);

                if (dtMappSetting != null || dtMappSetting.Rows.Count > 0)
                {
                    CodeFileName = dtMappSetting.Rows[0]["CODE_FILE"].ToString();
                    Configuration.GetAppMapping(CodeFileName);
                    CodeFileType = int.Parse(dtMappSetting.Rows[0]["CODE_TYPE"].ToString());
                }

                #region Mapped Acount Selection
                long p_PrincipalAccount_ID = 88;    //2002080001	Payable to (Principal Wise)
                string p_PrincipalAccount_Name = "";
                if (mPurchaseMaster.TYPE_ID == 8 || mPurchaseMaster.TYPE_ID == 9)   // Short & Access
                {
                    DataTable dtAccount = cd.SelectAccountHeadMapping(1, Constants.IntNullValue, mPurchaseMaster.PRINCIPAL_ID, Constants.LongNullValue, Constants.IntNullValue);
                    if (dtAccount != null && dtAccount.Rows.Count > 0)
                    {
                        p_PrincipalAccount_ID = long.Parse(dtAccount.Rows[0]["Account_head_ID"].ToString());
                        p_PrincipalAccount_Name = dtAccount.Rows[0]["ACCOUNT_NAME"].ToString();

                    }
                }
                #endregion

                #region GL Voucher
                LedgerController LController = new LedgerController();
                string VoucherNo = LController.SelectMaxVoucherId(Constants.Journal_Voucher, p_DISTRIBUTOR_ID, DateTime.Now, mTransaction, mConnection);
                p_Voucher_No = VoucherNo;
                if (mPurchaseMaster.TYPE_ID == 2)// Purchase
                {
                    #region Purchases
                    string Remarks = "Default Purchase Voucher / Document # " + p_ORDER_NUMBER;
                    string Remarks2 = "Default Purchase Voucher";
                    string DocumentType = "Purchase";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), mPurchaseMaster.TOTAL_AMOUNT, 0, "Stock in Hand " + Remarks2, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, 0, mPurchaseMaster.TOTAL_AMOUNT, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, 897, mPurchaseMaster.TOTAL_AMOUNT, 0, "Purchases " + Remarks2, mTransaction, mConnection);
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, 0, mPurchaseMaster.TOTAL_AMOUNT, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 3)  // Purchase Return
                {
                    #region Purchase Return
                    string Remarks = "Default Purchase Return Voucher / Document # " + p_ORDER_NUMBER;
                    string Remarks2 = "Default Purchase Return Voucher";
                    string DocumentType = "Purchase Return";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), 0, mPurchaseMaster.TOTAL_AMOUNT, "Stock in Hand " + Remarks2, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, 897, 0, mPurchaseMaster.TOTAL_AMOUNT, "Purchases " + Remarks2, mTransaction, mConnection);
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 4)  // Transfer IN
                {
                    #region Transfer In
                    string Remarks = "Default Transfer In Voucher";
                    string DocumentType = "Transfer IN";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), mPurchaseMaster.TOTAL_AMOUNT, 0, "Stock in Hand " + Remarks, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.TransferInAccount), 0, mPurchaseMaster.TOTAL_AMOUNT, p_PrincipalAccount_Name + " " + Remarks, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 5)  // Transfer OUT
                {
                    #region Transfer Out
                    string Remarks = "Default Transfer Out Voucher";
                    string DocumentType = "Transfer Out";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.TransferOutAccount), mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), 0, mPurchaseMaster.TOTAL_AMOUNT, "Stock in Hand " + Remarks, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 6)  // Damage
                {
                    #region Damage
                    string Remarks = "Default Stock Damage Voucher / Document # " + mPurchaseMaster.PURCHASE_MASTER_ID;
                    string Remarks2 = "Default Stock Damage Voucher";
                    string DocumentType = "Stock Damage";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), 0, mPurchaseMaster.TOTAL_AMOUNT, "Stock In Hand " + Remarks2, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, 897, 0, mPurchaseMaster.TOTAL_AMOUNT, "Purchases " + Remarks2, mTransaction, mConnection);
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, 843, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 7) // Opening Stock
                {
                    #region Opening Stock
                    string Remarks = "Default Opening Stock Voucher";
                    string DocumentType = "Opening Stock";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, 0, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), mPurchaseMaster.TOTAL_AMOUNT, 0, "Stock In Hand " + Remarks, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.OpeningStock), 0, mPurchaseMaster.TOTAL_AMOUNT, "Opening at 31/8/19 " + Remarks, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp

                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 10) // Damage claimable
                {
                    #region Damage Claimable
                    string Remarks = "Default Stock Damage(Claimable) Voucher / Document # " + mPurchaseMaster.PURCHASE_MASTER_ID;
                    string Remarks2 = "Default Stock Damage(Claimable) Voucher";
                    string DocumentType = "Stock Damage(Claimable)";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), 0, mPurchaseMaster.TOTAL_AMOUNT, "Stock In Hand " + Remarks2, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, 897, 0, mPurchaseMaster.TOTAL_AMOUNT, "Purchases " + Remarks2, mTransaction, mConnection);
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, 845, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 8)  // Short
                {
                    #region Short
                    string Remarks = "Default Stock Short Voucher / Document # " + mPurchaseMaster.PURCHASE_MASTER_ID;
                    string Remarks2 = "Default Stock Short Voucher";
                    string DocumentType = "Stock Short";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, 0, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), 0, mPurchaseMaster.TOTAL_AMOUNT, "Stock In Hand " + Remarks2, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, 901, 0, mPurchaseMaster.TOTAL_AMOUNT, "Sales (All Principle) " + Remarks2, mTransaction, mConnection);
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, 898, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 9)  // Excess
                {
                    #region Excess
                    string Remarks = "Default Stock Excess Voucher / Document # " + mPurchaseMaster.PURCHASE_MASTER_ID;
                    string Remarks2 = "Default Stock Excess Voucher";
                    string DocumentType = "Stock Excess";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, 0, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), mPurchaseMaster.TOTAL_AMOUNT, 0, "Stock In Hand " + Remarks2, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, 0, mPurchaseMaster.TOTAL_AMOUNT, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, 897, mPurchaseMaster.TOTAL_AMOUNT, 0, "Purchases " + Remarks2, mTransaction, mConnection);
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, 900, 0, mPurchaseMaster.TOTAL_AMOUNT, "Unadjusted Credit Balance - Purchase " + Remarks2, mTransaction, mConnection);
                        }
                    }
                    #endregion
                }


                #endregion

                mTransaction.Commit();
                return true; 
			}
			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);
                mTransaction.Rollback();  
				return false;
			}
			finally
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}
			
		}

        public bool UpdatePurchaseDocument(long p_PURCHASE_MASTER_ID, int p_DISTRIBUTOR_ID, string p_ORDER_NUMBER, int p_TYPE_ID, DateTime p_DOCUMENT_DATE, int p_SOLD_TO, int p_SOLD_FROM, decimal p_TOTAL_AMOUNT, bool p_IS_DELETE, DataTable dtPurchaseDetail, int p_Posting, string p_BuiltyNo, int p_UserId, int p_Principal)
        {
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                mTransaction = ProviderFactory.GetTransaction(mConnection);
                spUpdatePURCHASE_MASTER mPurchaseMaster = new spUpdatePURCHASE_MASTER();
                mPurchaseMaster.Connection = mConnection;
                mPurchaseMaster.Transaction = mTransaction;
                mPurchaseMaster.PURCHASE_MASTER_ID = p_PURCHASE_MASTER_ID;
                mPurchaseMaster.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mPurchaseMaster.TYPE_ID = p_TYPE_ID;
                mPurchaseMaster.ORDER_NUMBER = p_ORDER_NUMBER;
                mPurchaseMaster.SOLD_FROM = p_SOLD_FROM;
                mPurchaseMaster.DOCUMENT_DATE = p_DOCUMENT_DATE;
                mPurchaseMaster.SOLD_TO = p_SOLD_TO;
                mPurchaseMaster.TOTAL_AMOUNT = p_TOTAL_AMOUNT;
                mPurchaseMaster.USER_ID = p_UserId;
                mPurchaseMaster.LAST_UPDATE = DateTime.Now;
                mPurchaseMaster.POSTING = p_Posting;
                mPurchaseMaster.BUILTY_NO = p_BuiltyNo;
                mPurchaseMaster.ExecuteQuery();

                //Get Privouse Update Purchase Detail and Rollback
                //LedgerController LController = new LedgerController();

                //string VoucherNo = LController.SelectLedgerMaxDocumentId(Constants.Journal_Voucher, p_DISTRIBUTOR_ID);

                DataTable dt = SelectPrivousePurchaseDetail(p_DISTRIBUTOR_ID, p_PURCHASE_MASTER_ID, mConnection, mTransaction);

                foreach (DataRow dr in dt.Rows)
                {
                    UspUpdatePurchaseDetailStock mPurchaseStock = new UspUpdatePurchaseDetailStock();
                    mPurchaseStock.Connection = mConnection;
                    mPurchaseStock.Transaction = mTransaction;
                    mPurchaseStock.TYPEID = p_TYPE_ID;
                    mPurchaseStock.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                    mPurchaseStock.PURCHASE_DETAIL_ID = long.Parse(dr["PURCHASE_DETAIL_ID"].ToString());
                    mPurchaseStock.PURCHASE_MASTER_ID = p_PURCHASE_MASTER_ID;
                    mPurchaseStock.BATCH_NO = dr["BATCH_NO"].ToString().Trim();
                    mPurchaseStock.SKU_ID = int.Parse(dr["SKU_ID"].ToString());
                    mPurchaseStock.ExecuteQuery();
                }

                spInsertPURCHASE_DETAIL mPurchaseDetail = new spInsertPURCHASE_DETAIL();
                mPurchaseDetail.Connection = mConnection;
                mPurchaseDetail.Transaction = mTransaction;

                foreach (DataRow dr in dtPurchaseDetail.Rows)
                {

                    //update stock;
                    mPurchaseDetail.PURCHASE_MASTER_ID = mPurchaseMaster.PURCHASE_MASTER_ID;
                    mPurchaseDetail.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                    mPurchaseDetail.SKU_ID = int.Parse(dr["SKU_ID"].ToString());
                    mPurchaseDetail.BATCH_NO = dr["BATCH_NO"].ToString();
                    mPurchaseDetail.PRICE = decimal.Parse(dr["PRICE"].ToString());
                    mPurchaseDetail.QUANTITY = int.Parse(dr["Total_Unit"].ToString());
                    mPurchaseDetail.FREE_SKU = int.Parse(dr["FREE_SKU"].ToString());
                    mPurchaseDetail.AMOUNT = decimal.Parse(dr["AMOUNT"].ToString());

                    mPurchaseDetail.TYPE_ID = mPurchaseMaster.TYPE_ID;
                    mPurchaseDetail.TIME_STAMP = p_DOCUMENT_DATE;
                    mPurchaseDetail.ExecuteQuery();

                    UspProcessStockRegister mStockUpdate = new UspProcessStockRegister();
                    mStockUpdate.Connection = mConnection;
                    mStockUpdate.Transaction = mTransaction;
                    mStockUpdate.PRINCIPAL_ID = p_Principal;
                    mStockUpdate.TYPE_ID = mPurchaseMaster.TYPE_ID;
                    mStockUpdate.DISTRIBUTOR_ID = mPurchaseMaster.DISTRIBUTOR_ID;
                    mStockUpdate.STOCK_DATE = mPurchaseMaster.DOCUMENT_DATE;
                    mStockUpdate.SKU_ID = mPurchaseDetail.SKU_ID;
                    mStockUpdate.STOCK_QTY = mPurchaseDetail.QUANTITY;
                    mStockUpdate.FREE_QTY = mPurchaseDetail.FREE_SKU;
                    mStockUpdate.BATCHNO = mPurchaseDetail.BATCH_NO;
                    mStockUpdate.ExecuteQuery();
                }


                CustomerDataController cd = new CustomerDataController();
                string p_Voucher_No = "";
                string CodeFileName = "";
                int CodeFileType = 0;
                DataTable dtMappSetting = cd.SelectMappingSetting(Constants.IntNullValue, Constants.IntNullValue);

                if (dtMappSetting != null || dtMappSetting.Rows.Count > 0)
                {
                    CodeFileName = dtMappSetting.Rows[0]["CODE_FILE"].ToString();
                    Configuration.GetAppMapping(CodeFileName);
                    CodeFileType = int.Parse(dtMappSetting.Rows[0]["CODE_TYPE"].ToString());
                }

                #region Mapped Acount Selection
                long p_PrincipalAccount_ID = 88;    //2002080001	Payable to (Principal Wise)
                string p_PrincipalAccount_Name = "";
                if (mPurchaseMaster.TYPE_ID == 8 || mPurchaseMaster.TYPE_ID == 9)   // Short & Access
                {
                    DataTable dtAccount = cd.SelectAccountHeadMapping(1, Constants.IntNullValue, p_Principal, Constants.LongNullValue, Constants.IntNullValue);
                    if (dtAccount != null && dtAccount.Rows.Count > 0)
                    {
                        p_PrincipalAccount_ID = long.Parse(dtAccount.Rows[0]["Account_head_ID"].ToString());
                        p_PrincipalAccount_Name = dtAccount.Rows[0]["ACCOUNT_NAME"].ToString();

                    }
                }
                #endregion

                #region GL Voucher
                LedgerController LController = new LedgerController();
                string VoucherNo = LController.SelectMaxVoucherId(Constants.Journal_Voucher, p_DISTRIBUTOR_ID, DateTime.Now, mTransaction, mConnection);
                p_Voucher_No = VoucherNo;
                if (mPurchaseMaster.TYPE_ID == 2)// Purchase
                {
                    #region Purchases
                    string Remarks = "Default Purchase Voucher / Document # " + p_ORDER_NUMBER;
                    string Remarks2 = "Default Purchase Voucher";
                    string DocumentType = "Purchase";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, p_Principal, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, p_Principal, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), mPurchaseMaster.TOTAL_AMOUNT, 0, "Stock in Hand " + Remarks2, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, p_Principal, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, 0, mPurchaseMaster.TOTAL_AMOUNT, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, 897, mPurchaseMaster.TOTAL_AMOUNT, 0, "Purchases " + Remarks2, mTransaction, mConnection);
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, 0, mPurchaseMaster.TOTAL_AMOUNT, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 3)  // Purchase Return
                {
                    #region Purchase Return
                    string Remarks = "Default Purchase Return Voucher / Document # " + p_ORDER_NUMBER;
                    string Remarks2 = "Default Purchase Return Voucher";
                    string DocumentType = "Purchase Return";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, p_Principal, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, p_Principal, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), 0, mPurchaseMaster.TOTAL_AMOUNT, "Stock in Hand " + Remarks2, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, p_Principal, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, 897, 0, mPurchaseMaster.TOTAL_AMOUNT, "Purchases " + Remarks2, mTransaction, mConnection);
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 4)  // Transfer IN
                {
                    #region Transfer In
                    string Remarks = "Default Transfer In Voucher";
                    string DocumentType = "Transfer IN";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, p_Principal, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, p_Principal, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), mPurchaseMaster.TOTAL_AMOUNT, 0, "Stock in Hand " + Remarks, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, p_Principal, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.TransferInAccount), 0, mPurchaseMaster.TOTAL_AMOUNT, p_PrincipalAccount_Name + " " + Remarks, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 5)  // Transfer OUT
                {
                    #region Transfer Out
                    string Remarks = "Default Transfer Out Voucher";
                    string DocumentType = "Transfer Out";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, p_Principal, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, p_Principal, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.TransferOutAccount), mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, p_Principal, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), 0, mPurchaseMaster.TOTAL_AMOUNT, "Stock in Hand " + Remarks, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 6)  // Damage
                {
                    #region Damage
                    string Remarks = "Default Stock Damage Voucher / Document # " + mPurchaseMaster.PURCHASE_MASTER_ID;
                    string Remarks2 = "Default Stock Damage Voucher";
                    string DocumentType = "Stock Damage";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, p_Principal, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, p_Principal, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), 0, mPurchaseMaster.TOTAL_AMOUNT, "Stock In Hand " + Remarks2, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, p_Principal, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, 897, 0, mPurchaseMaster.TOTAL_AMOUNT, "Purchases " + Remarks2, mTransaction, mConnection);
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, 843, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 7) // Opening Stock
                {
                    #region Opening Stock
                    string Remarks = "Default Opening Stock Voucher";
                    string DocumentType = "Opening Stock";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, 0, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), mPurchaseMaster.TOTAL_AMOUNT, 0, "Stock In Hand " + Remarks, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.OpeningStock), 0, mPurchaseMaster.TOTAL_AMOUNT, "Opening at 31/8/19 " + Remarks, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp

                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 10) // Damage claimable
                {
                    #region Damage Claimable
                    string Remarks = "Default Stock Damage(Claimable) Voucher / Document # " + mPurchaseMaster.PURCHASE_MASTER_ID;
                    string Remarks2 = "Default Stock Damage(Claimable) Voucher";
                    string DocumentType = "Stock Damage(Claimable)";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, p_Principal, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, p_Principal, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), 0, mPurchaseMaster.TOTAL_AMOUNT, "Stock In Hand " + Remarks2, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, p_Principal, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, 897, 0, mPurchaseMaster.TOTAL_AMOUNT, "Purchases " + Remarks2, mTransaction, mConnection);
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, 845, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 8)  // Short
                {
                    #region Short
                    string Remarks = "Default Stock Short Voucher / Document # " + mPurchaseMaster.PURCHASE_MASTER_ID;
                    string Remarks2 = "Default Stock Short Voucher";
                    string DocumentType = "Stock Short";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, 0, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), 0, mPurchaseMaster.TOTAL_AMOUNT, "Stock In Hand " + Remarks2, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, 901, 0, mPurchaseMaster.TOTAL_AMOUNT, "Sales (All Principle) " + Remarks2, mTransaction, mConnection);
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, 898, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 9)  // Excess
                {
                    #region Excess
                    string Remarks = "Default Stock Excess Voucher / Document # " + mPurchaseMaster.PURCHASE_MASTER_ID;
                    string Remarks2 = "Default Stock Excess Voucher";
                    string DocumentType = "Stock Excess";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, 0, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), mPurchaseMaster.TOTAL_AMOUNT, 0, "Stock In Hand " + Remarks2, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, 0, mPurchaseMaster.TOTAL_AMOUNT, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, 897, mPurchaseMaster.TOTAL_AMOUNT, 0, "Purchases " + Remarks2, mTransaction, mConnection);
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, 900, 0, mPurchaseMaster.TOTAL_AMOUNT, "Unadjusted Credit Balance - Purchase " + Remarks2, mTransaction, mConnection);
                        }
                    }
                    #endregion
                }


                #endregion

                mTransaction.Commit();
                return true;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                mTransaction.Rollback();
                return false;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }

        }

        public bool InsertPurchaseDocumentStock(int p_DISTRIBUTOR_ID, string p_ORDER_NUMBER, int p_TYPE_ID, DateTime p_DOCUMENT_DATE, int p_SOLD_TO, int p_SOLD_FROM, decimal p_TOTAL_AMOUNT, bool p_IS_DELETE, DataTable dtPurchaseDetail, int p_Posting, string p_BuiltyNo, int p_UserId, int p_PrincipalId)
        {
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                mTransaction = ProviderFactory.GetTransaction(mConnection);
                spInsertPURCHASE_MASTER mPurchaseMaster = new spInsertPURCHASE_MASTER();
                mPurchaseMaster.Connection = mConnection;
                mPurchaseMaster.Transaction = mTransaction;
                mPurchaseMaster.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mPurchaseMaster.TYPE_ID = p_TYPE_ID;
                mPurchaseMaster.ORDER_NUMBER = p_ORDER_NUMBER;
                mPurchaseMaster.SOLD_FROM = p_SOLD_FROM;
                mPurchaseMaster.DOCUMENT_DATE = p_DOCUMENT_DATE;
                mPurchaseMaster.SOLD_TO = p_SOLD_TO;
                mPurchaseMaster.TOTAL_AMOUNT = p_TOTAL_AMOUNT;
                mPurchaseMaster.USER_ID = p_UserId;
                mPurchaseMaster.TIME_STAMP = DateTime.Now;
                mPurchaseMaster.LAST_UPDATE = DateTime.Now;
                mPurchaseMaster.POSTING = p_Posting;
                mPurchaseMaster.BUILTY_NO = p_BuiltyNo;
                mPurchaseMaster.PRINCIPAL_ID = p_PrincipalId;
                mPurchaseMaster.ExecuteQuery();

                spInsertPURCHASE_DETAIL2 mPurchaseDetail = new spInsertPURCHASE_DETAIL2();
                mPurchaseDetail.Connection = mConnection;
                mPurchaseDetail.Transaction = mTransaction;

                foreach (DataRow dr in dtPurchaseDetail.Rows)
                {
                    mPurchaseDetail.PURCHASE_MASTER_ID = mPurchaseMaster.PURCHASE_MASTER_ID;
                    mPurchaseDetail.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                    mPurchaseDetail.SKU_ID = int.Parse(dr["SKU_ID"].ToString());
                    mPurchaseDetail.BATCH_NO = dr["BATCH_NO"].ToString();
                    mPurchaseDetail.PRICE = decimal.Parse(dr["PRICE"].ToString());
                    mPurchaseDetail.QUANTITY = int.Parse(dr["Total_Unit"].ToString());
                    mPurchaseDetail.FREE_SKU = int.Parse(dr["FREE_SKU"].ToString());
                    mPurchaseDetail.AMOUNT = decimal.Parse(dr["AMOUNT"].ToString());
                    mPurchaseDetail.TYPE_ID = mPurchaseMaster.TYPE_ID;
                    mPurchaseDetail.TIME_STAMP = p_DOCUMENT_DATE;
                    mPurchaseDetail.TDAMAGE = int.Parse(dr["TDAMAGE"].ToString());
                    mPurchaseDetail.ExecuteQuery();

                    UspProcessStockRegister mStockUpdate = new UspProcessStockRegister();
                    mStockUpdate.Connection = mConnection;
                    mStockUpdate.Transaction = mTransaction;
                    mStockUpdate.PRINCIPAL_ID = p_PrincipalId;
                    mStockUpdate.TYPE_ID = mPurchaseMaster.TYPE_ID;
                    mStockUpdate.DISTRIBUTOR_ID = mPurchaseMaster.DISTRIBUTOR_ID;
                    mStockUpdate.STOCK_DATE = mPurchaseMaster.DOCUMENT_DATE;
                    mStockUpdate.SKU_ID = mPurchaseDetail.SKU_ID;
                    mStockUpdate.STOCK_QTY = mPurchaseDetail.QUANTITY;
                    mStockUpdate.FREE_QTY = mPurchaseDetail.FREE_SKU;
                    mStockUpdate.BATCHNO = mPurchaseDetail.BATCH_NO;
                    mStockUpdate.ExecuteQuery();
                }
                CustomerDataController cd = new CustomerDataController();
                string p_Voucher_No = "";
                string CodeFileName = "";
                int CodeFileType = 0;
                DataTable dtMappSetting = cd.SelectMappingSetting(Constants.IntNullValue, Constants.IntNullValue);

                if (dtMappSetting != null || dtMappSetting.Rows.Count > 0)
                {
                    CodeFileName = dtMappSetting.Rows[0]["CODE_FILE"].ToString();
                    Configuration.GetAppMapping(CodeFileName);
                    CodeFileType = int.Parse(dtMappSetting.Rows[0]["CODE_TYPE"].ToString());
                }

                #region Mapped Acount Selection
                long p_PrincipalAccount_ID = 88;    //2002080001	Payable to (Principal Wise)
                string p_PrincipalAccount_Name = "";
                if (mPurchaseMaster.TYPE_ID == 2 || mPurchaseMaster.TYPE_ID == 3 || mPurchaseMaster.TYPE_ID == 4 ||
                    mPurchaseMaster.TYPE_ID == 5 || mPurchaseMaster.TYPE_ID == 6 || mPurchaseMaster.TYPE_ID == 8 ||
                    mPurchaseMaster.TYPE_ID == 9 || mPurchaseMaster.TYPE_ID == 10)
                {
                    DataTable dtAccount = cd.SelectAccountHeadMapping(1, Constants.IntNullValue, mPurchaseMaster.PRINCIPAL_ID, Constants.LongNullValue, Constants.IntNullValue);
                    if (dtAccount != null && dtAccount.Rows.Count > 0)
                    {
                        p_PrincipalAccount_ID = long.Parse(dtAccount.Rows[0]["Account_head_ID"].ToString());
                        p_PrincipalAccount_Name = dtAccount.Rows[0]["ACCOUNT_NAME"].ToString();

                    }
                }
                #endregion

                #region GL Voucher
                LedgerController LController = new LedgerController();
                string VoucherNo = LController.SelectMaxVoucherId(Constants.Journal_Voucher, p_DISTRIBUTOR_ID, DateTime.Now, mTransaction, mConnection);
                p_Voucher_No = VoucherNo;
                if (mPurchaseMaster.TYPE_ID == 2)// Purchase
                {
                    #region Purchases
                    string Remarks = "Default Purchase Voucher / Document # " + p_ORDER_NUMBER;
                    string Remarks2 = "Default Purchase Voucher";
                    string DocumentType = "Purchase";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), mPurchaseMaster.TOTAL_AMOUNT, 0, "Stock in Hand " + Remarks2, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, 0, mPurchaseMaster.TOTAL_AMOUNT, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, 897, mPurchaseMaster.TOTAL_AMOUNT, 0, "Purchases " + Remarks2, mTransaction, mConnection);
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, 0, mPurchaseMaster.TOTAL_AMOUNT, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 3)  // Purchase Return
                {
                    #region Purchase Return
                    string Remarks = "Default Purchase Return Voucher / Document # " + p_ORDER_NUMBER;
                    string Remarks2 = "Default Purchase Return Voucher";
                    string DocumentType = "Purchase Return";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), 0, mPurchaseMaster.TOTAL_AMOUNT, "Stock in Hand " + Remarks2, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, 897, 0, mPurchaseMaster.TOTAL_AMOUNT, "Purchases " + Remarks2, mTransaction, mConnection);
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 4)  // Transfer IN
                {
                    #region Transfer In
                    string Remarks = "Default Transfer In Voucher";
                    string DocumentType = "Transfer IN";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), mPurchaseMaster.TOTAL_AMOUNT, 0, "Stock in Hand " + Remarks, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.TransferInAccount), 0, mPurchaseMaster.TOTAL_AMOUNT, p_PrincipalAccount_Name + " " + Remarks, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 5)  // Transfer OUT
                {
                    #region Transfer Out
                    string Remarks = "Default Transfer Out Voucher";
                    string DocumentType = "Transfer Out";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.TransferOutAccount), mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), 0, mPurchaseMaster.TOTAL_AMOUNT, "Stock in Hand " + Remarks, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 6)  // Damage
                {
                    #region Damage
                    string Remarks = "Default Stock Damage Voucher / Document # " + mPurchaseMaster.PURCHASE_MASTER_ID;
                    string Remarks2 = "Default Stock Damage Voucher";
                    string DocumentType = "Stock Damage";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), 0, mPurchaseMaster.TOTAL_AMOUNT, "Stock In Hand " + Remarks2, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, 897, 0, mPurchaseMaster.TOTAL_AMOUNT, "Purchases " + Remarks2, mTransaction, mConnection);
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, 843, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 7) // Opening Stock
                {
                    #region Opening Stock
                    string Remarks = "Default Opening Stock Voucher";
                    string DocumentType = "Opening Stock";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, 0, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), mPurchaseMaster.TOTAL_AMOUNT, 0, "Stock In Hand " + Remarks, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.OpeningStock), 0, mPurchaseMaster.TOTAL_AMOUNT, "Opening at 31/8/19 " + Remarks, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp

                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 10) // Damage claimable
                {
                    #region Damage Claimable
                    string Remarks = "Default Stock Damage(Claimable) Voucher / Document # " + mPurchaseMaster.PURCHASE_MASTER_ID;
                    string Remarks2 = "Default Stock Damage(Claimable) Voucher";
                    string DocumentType = "Stock Damage(Claimable)";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), 0, mPurchaseMaster.TOTAL_AMOUNT, "Stock In Hand " + Remarks2, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, 897, 0, mPurchaseMaster.TOTAL_AMOUNT, "Purchases " + Remarks2, mTransaction, mConnection);
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, 845, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 8)  // Short
                {
                    #region Short
                    string Remarks = "Default Stock Short Voucher / Document # " + mPurchaseMaster.PURCHASE_MASTER_ID;
                    string Remarks2 = "Default Stock Short Voucher";
                    string DocumentType = "Stock Short";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, 0, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), 0, mPurchaseMaster.TOTAL_AMOUNT, "Stock In Hand " + Remarks2, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, 901, 0, mPurchaseMaster.TOTAL_AMOUNT, "Sales (All Principle) " + Remarks2, mTransaction, mConnection);
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, 898, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 9)  // Excess
                {
                    #region Excess
                    string Remarks = "Default Stock Excess Voucher / Document # " + mPurchaseMaster.PURCHASE_MASTER_ID;
                    string Remarks2 = "Default Stock Excess Voucher";
                    string DocumentType = "Stock Excess";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, 0, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), mPurchaseMaster.TOTAL_AMOUNT, 0, "Stock In Hand " + Remarks2, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, 0, mPurchaseMaster.TOTAL_AMOUNT, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, 897, mPurchaseMaster.TOTAL_AMOUNT, 0, "Purchases " + Remarks2, mTransaction, mConnection);
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, 900, 0, mPurchaseMaster.TOTAL_AMOUNT, "Unadjusted Credit Balance - Purchase " + Remarks2, mTransaction, mConnection);
                        }
                    }
                    #endregion
                }


                #endregion



                mTransaction.Commit();
                return true;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                mTransaction.Rollback();
                return false;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }

        }

        public bool InsertPurchase(int p_DISTRIBUTOR_ID, string p_ORDER_NUMBER, int p_TYPE_ID, DateTime p_DOCUMENT_DATE, int p_SOLD_TO, int p_SOLD_FROM, decimal p_TOTAL_AMOUNT, bool p_IS_DELETE, DataTable dtPurchaseDetail, int p_Posting, string p_BuiltyNo, int p_UserId, int p_PrincipalId, decimal p_FMR, decimal p_MR, decimal p_Pur_Discount, decimal p_Gst_Amount, decimal p_Tst_Amount, decimal p_total_Net_Amount, DateTime p_INVOICE_DATE)
        {
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                mTransaction = ProviderFactory.GetTransaction(mConnection);
                spInsertPURCHASE_MASTER mPurchaseMaster = new spInsertPURCHASE_MASTER();
                mPurchaseMaster.Connection = mConnection;
                mPurchaseMaster.Transaction = mTransaction;
                mPurchaseMaster.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mPurchaseMaster.TYPE_ID = p_TYPE_ID;
                mPurchaseMaster.ORDER_NUMBER = p_ORDER_NUMBER;
                mPurchaseMaster.SOLD_FROM = p_SOLD_FROM;
                mPurchaseMaster.DOCUMENT_DATE = p_DOCUMENT_DATE;
                mPurchaseMaster.SOLD_TO = p_SOLD_TO;
                mPurchaseMaster.TOTAL_AMOUNT = p_TOTAL_AMOUNT;
                mPurchaseMaster.USER_ID = p_UserId;
                mPurchaseMaster.TIME_STAMP = DateTime.Now;
                mPurchaseMaster.LAST_UPDATE = DateTime.Now;
                mPurchaseMaster.POSTING = p_Posting;
                mPurchaseMaster.BUILTY_NO = p_BuiltyNo;
                mPurchaseMaster.PRINCIPAL_ID = p_PrincipalId;
                mPurchaseMaster.FMR = p_FMR;
                mPurchaseMaster.MR = p_MR;
                mPurchaseMaster.PUR_DISCOUNT = p_Pur_Discount;
                mPurchaseMaster.GST_AMOUNT = p_Gst_Amount;
                mPurchaseMaster.TST_AMOUNT = p_Tst_Amount;
                mPurchaseMaster.TOTAL_NET_AMOUNT = p_total_Net_Amount;
                mPurchaseMaster.IS_DELETED = false;
                mPurchaseMaster.INVOICE_DATE = p_INVOICE_DATE;
                mPurchaseMaster.ExecuteQuery();

                spInsertPURCHASE_DETAIL2 mPurchaseDetail = new spInsertPURCHASE_DETAIL2();
                mPurchaseDetail.Connection = mConnection;
                mPurchaseDetail.Transaction = mTransaction;

                foreach (DataRow dr in dtPurchaseDetail.Rows)
                {
                    mPurchaseDetail.PURCHASE_MASTER_ID = mPurchaseMaster.PURCHASE_MASTER_ID;
                    mPurchaseDetail.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                    mPurchaseDetail.SKU_ID = int.Parse(dr["SKU_ID"].ToString());
                    mPurchaseDetail.BATCH_NO = dr["BATCH_NO"].ToString();
                    mPurchaseDetail.PRICE = decimal.Parse(dr["PRICE"].ToString());
                    mPurchaseDetail.QUANTITY = int.Parse(dr["Total_Unit"].ToString());
                    mPurchaseDetail.FREE_SKU = int.Parse(dr["FREE_SKU"].ToString());
                    mPurchaseDetail.AMOUNT = decimal.Parse(dr["AMOUNT"].ToString());

                    mPurchaseDetail.GST_AMOUNT = decimal.Parse(dr["GST_AMOUNT"].ToString());
                    mPurchaseDetail.TST_AMOUNT = decimal.Parse(dr["TST_AMOUNT"].ToString());
                    mPurchaseDetail.GST_RATE = decimal.Parse(dr["GST_RATE"].ToString());

                    mPurchaseDetail.TYPE_ID = mPurchaseMaster.TYPE_ID;
                    mPurchaseDetail.TIME_STAMP = p_DOCUMENT_DATE;
                    mPurchaseDetail.TDAMAGE = int.Parse(dr["TDAMAGE"].ToString());
                    mPurchaseDetail.FMR = decimal.Parse(dr["FMR"].ToString());
                    mPurchaseDetail.MR = decimal.Parse(dr["MR"].ToString());
                    mPurchaseDetail.PUR_DISCOUNT = decimal.Parse(dr["PUR_DISCOUNT"].ToString());
                    mPurchaseDetail.ExecuteQuery();

                    UspProcessStockRegister mStockUpdate = new UspProcessStockRegister();
                    mStockUpdate.Connection = mConnection;
                    mStockUpdate.Transaction = mTransaction;
                    mStockUpdate.PRINCIPAL_ID = p_PrincipalId;
                    mStockUpdate.TYPE_ID = mPurchaseMaster.TYPE_ID;
                    mStockUpdate.DISTRIBUTOR_ID = mPurchaseMaster.DISTRIBUTOR_ID;
                    mStockUpdate.STOCK_DATE = mPurchaseMaster.DOCUMENT_DATE;
                    mStockUpdate.SKU_ID = mPurchaseDetail.SKU_ID;
                    mStockUpdate.STOCK_QTY = mPurchaseDetail.QUANTITY;
                    mStockUpdate.FREE_QTY = mPurchaseDetail.FREE_SKU;
                    mStockUpdate.BATCHNO = mPurchaseDetail.BATCH_NO;
                    mStockUpdate.ExecuteQuery();
                }


                #region Mapped Acount Selection

                CustomerDataController cd = new CustomerDataController();
                string p_Voucher_No = "";
                string CodeFileName = "";
                int CodeFileType = 0;
                DataTable dtMappSetting = cd.SelectMappingSetting(Constants.IntNullValue, Constants.IntNullValue);

                if (dtMappSetting != null || dtMappSetting.Rows.Count > 0)
                {
                    CodeFileName = dtMappSetting.Rows[0]["CODE_FILE"].ToString();
                    Configuration.GetAppMapping(CodeFileName);
                    CodeFileType = int.Parse(dtMappSetting.Rows[0]["CODE_TYPE"].ToString());
                }


                long p_PrincipalAccount_ID = 88;    //2002080001	Payable to (Principal Wise)
                string p_PrincipalAccount_Name = "";
                if (mPurchaseMaster.TYPE_ID == 2 || mPurchaseMaster.TYPE_ID == 3 || mPurchaseMaster.TYPE_ID == 4 ||
                    mPurchaseMaster.TYPE_ID == 5 || mPurchaseMaster.TYPE_ID == 6 || mPurchaseMaster.TYPE_ID == 8 ||
                    mPurchaseMaster.TYPE_ID == 9 || mPurchaseMaster.TYPE_ID == 10)
                {
                    DataTable dtAccount = cd.SelectAccountHeadMapping(1, Constants.IntNullValue, mPurchaseMaster.PRINCIPAL_ID, Constants.LongNullValue, Constants.IntNullValue);
                    if (dtAccount != null && dtAccount.Rows.Count > 0)
                    {
                        p_PrincipalAccount_ID = long.Parse(dtAccount.Rows[0]["Account_head_ID"].ToString());
                        p_PrincipalAccount_Name = dtAccount.Rows[0]["ACCOUNT_NAME"].ToString();

                    }
                }
                #endregion

                #region GL Voucher
                LedgerController LController = new LedgerController();
                string VoucherNo = LController.SelectMaxVoucherId(Constants.Journal_Voucher, p_DISTRIBUTOR_ID, DateTime.Now, mTransaction, mConnection);
                p_Voucher_No = VoucherNo;
                if (mPurchaseMaster.TYPE_ID == 2)// Purchase
                {
                    #region Purchases
                    string Remarks = "Default Purchase Voucher / Document # " + p_ORDER_NUMBER;
                    string Remarks2 = "Default Purchase Voucher";
                    string DocumentType = "Purchase";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), mPurchaseMaster.TOTAL_AMOUNT, 0, "Stock in Hand " + Remarks2, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, 0, mPurchaseMaster.TOTAL_AMOUNT, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, 897, mPurchaseMaster.TOTAL_AMOUNT, 0, "Purchases " + Remarks2, mTransaction, mConnection);
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, 0, mPurchaseMaster.TOTAL_AMOUNT, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 3)  // Purchase Return
                {
                    #region Purchase Return
                    string Remarks = "Default Purchase Return Voucher / Document # " + p_ORDER_NUMBER;
                    string Remarks2 = "Default Purchase Return Voucher";
                    string DocumentType = "Purchase Return";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), 0, mPurchaseMaster.TOTAL_AMOUNT, "Stock in Hand " + Remarks2, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, 897, 0, mPurchaseMaster.TOTAL_AMOUNT, "Purchases " + Remarks2, mTransaction, mConnection);
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 4)  // Transfer IN
                {
                    #region Transfer In
                    string Remarks = "Default Transfer In Voucher";
                    string DocumentType = "Transfer IN";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), mPurchaseMaster.TOTAL_AMOUNT, 0, "Stock in Hand " + Remarks, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.TransferInAccount), 0, mPurchaseMaster.TOTAL_AMOUNT, p_PrincipalAccount_Name + " " + Remarks, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 5)  // Transfer OUT
                {
                    #region Transfer Out
                    string Remarks = "Default Transfer Out Voucher";
                    string DocumentType = "Transfer Out";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.TransferOutAccount), mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), 0, mPurchaseMaster.TOTAL_AMOUNT, "Stock in Hand " + Remarks, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 6)  // Damage
                {
                    #region Damage
                    string Remarks = "Default Stock Damage Voucher / Document # " + mPurchaseMaster.PURCHASE_MASTER_ID;
                    string Remarks2 = "Default Stock Damage Voucher";
                    string DocumentType = "Stock Damage";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), 0, mPurchaseMaster.TOTAL_AMOUNT, "Stock In Hand " + Remarks2, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, 897, 0, mPurchaseMaster.TOTAL_AMOUNT, "Purchases " + Remarks2, mTransaction, mConnection);
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, 843, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 7) // Opening Stock
                {
                    #region Opening Stock
                    string Remarks = "Default Opening Stock Voucher";
                    string DocumentType = "Opening Stock";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, 0, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), mPurchaseMaster.TOTAL_AMOUNT, 0, "Stock In Hand " + Remarks, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.OpeningStock), 0, mPurchaseMaster.TOTAL_AMOUNT, "Opening at 31/8/19 " + Remarks, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp

                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 10) // Damage claimable
                {
                    #region Damage Claimable
                    string Remarks = "Default Stock Damage(Claimable) Voucher / Document # " + mPurchaseMaster.PURCHASE_MASTER_ID;
                    string Remarks2 = "Default Stock Damage(Claimable) Voucher";
                    string DocumentType = "Stock Damage(Claimable)";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), 0, mPurchaseMaster.TOTAL_AMOUNT, "Stock In Hand " + Remarks2, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, 897, 0, mPurchaseMaster.TOTAL_AMOUNT, "Purchases " + Remarks2, mTransaction, mConnection);
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, 845, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 8)  // Short
                {
                    #region Short
                    string Remarks = "Default Stock Short Voucher / Document # " + mPurchaseMaster.PURCHASE_MASTER_ID;
                    string Remarks2 = "Default Stock Short Voucher";
                    string DocumentType = "Stock Short";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, 0, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), 0, mPurchaseMaster.TOTAL_AMOUNT, "Stock In Hand " + Remarks2, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, 901, 0, mPurchaseMaster.TOTAL_AMOUNT, "Sales (All Principle) " + Remarks2, mTransaction, mConnection);
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, 898, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 9)  // Excess
                {
                    #region Excess
                    string Remarks = "Default Stock Excess Voucher / Document # " + mPurchaseMaster.PURCHASE_MASTER_ID;
                    string Remarks2 = "Default Stock Excess Voucher";
                    string DocumentType = "Stock Excess";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, 0, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), mPurchaseMaster.TOTAL_AMOUNT, 0, "Stock In Hand " + Remarks2, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, 0, mPurchaseMaster.TOTAL_AMOUNT, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, 897, mPurchaseMaster.TOTAL_AMOUNT, 0, "Purchases " + Remarks2, mTransaction, mConnection);
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, 900, 0, mPurchaseMaster.TOTAL_AMOUNT, "Unadjusted Credit Balance - Purchase " + Remarks2, mTransaction, mConnection);
                        }
                    }
                    #endregion
                }


                #endregion



                mTransaction.Commit();
                return true;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                mTransaction.Rollback();
                return false;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }

        }

        public bool InsertPurchaseDocumentStock(int p_DISTRIBUTOR_ID, string p_ORDER_NUMBER, int p_TYPE_ID, DateTime p_DOCUMENT_DATE, int p_SOLD_TO, int p_SOLD_FROM, decimal p_TOTAL_AMOUNT, bool p_IS_DELETE, DataTable dtPurchaseDetail, int p_Posting, string p_BuiltyNo, int p_UserId, int p_PrincipalId,decimal p_Freight_Amount, decimal p_GST_AMOUNT, decimal p_TST_AMOUNT)
        {
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                mTransaction = ProviderFactory.GetTransaction(mConnection);
                spInsertPURCHASE_MASTER mPurchaseMaster = new spInsertPURCHASE_MASTER();
                mPurchaseMaster.Connection = mConnection;
                mPurchaseMaster.Transaction = mTransaction;
                mPurchaseMaster.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mPurchaseMaster.TYPE_ID = p_TYPE_ID;
                mPurchaseMaster.ORDER_NUMBER = p_ORDER_NUMBER;
                mPurchaseMaster.SOLD_FROM = p_SOLD_FROM;
                mPurchaseMaster.DOCUMENT_DATE = p_DOCUMENT_DATE;
                mPurchaseMaster.SOLD_TO = p_SOLD_TO;
                mPurchaseMaster.TOTAL_AMOUNT = p_TOTAL_AMOUNT;
                mPurchaseMaster.USER_ID = p_UserId;
                mPurchaseMaster.TIME_STAMP = DateTime.Now;
                mPurchaseMaster.LAST_UPDATE = DateTime.Now;
                mPurchaseMaster.POSTING = p_Posting;
                mPurchaseMaster.BUILTY_NO = p_BuiltyNo;
                mPurchaseMaster.PRINCIPAL_ID = p_PrincipalId;
                mPurchaseMaster.FREIGHT_AMOUNT = p_Freight_Amount;
                mPurchaseMaster.GST_AMOUNT = p_GST_AMOUNT;
                mPurchaseMaster.TST_AMOUNT = p_TST_AMOUNT;
                mPurchaseMaster.ExecuteQuery();

                spInsertPURCHASE_DETAIL2 mPurchaseDetail = new spInsertPURCHASE_DETAIL2();
                mPurchaseDetail.Connection = mConnection;
                mPurchaseDetail.Transaction = mTransaction;

                foreach (DataRow dr in dtPurchaseDetail.Rows)
                {
                    mPurchaseDetail.PURCHASE_MASTER_ID = mPurchaseMaster.PURCHASE_MASTER_ID;
                    mPurchaseDetail.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                    mPurchaseDetail.SKU_ID = int.Parse(dr["SKU_ID"].ToString());
                    mPurchaseDetail.BATCH_NO = dr["BATCH_NO"].ToString();
                    mPurchaseDetail.PRICE = decimal.Parse(dr["PRICE"].ToString());
                    mPurchaseDetail.QUANTITY = int.Parse(dr["Total_Unit"].ToString());
                    mPurchaseDetail.FREE_SKU = int.Parse(dr["FREE_SKU"].ToString());
                    mPurchaseDetail.AMOUNT = decimal.Parse(dr["AMOUNT"].ToString());
                    mPurchaseDetail.GST_AMOUNT = decimal.Parse(dr["GST_AMOUNT"].ToString());
                    mPurchaseDetail.TST_AMOUNT = decimal.Parse(dr["TST_AMOUNT"].ToString());
                    mPurchaseDetail.GST_RATE  = decimal.Parse(dr["GST_RATE"].ToString());


                    mPurchaseDetail.TYPE_ID = mPurchaseMaster.TYPE_ID;
                    mPurchaseDetail.TIME_STAMP = p_DOCUMENT_DATE;
                    mPurchaseDetail.TDAMAGE = int.Parse(dr["TDAMAGE"].ToString());
                    mPurchaseDetail.ExecuteQuery();

                    UspProcessStockRegister mStockUpdate = new UspProcessStockRegister();
                    mStockUpdate.Connection = mConnection;
                    mStockUpdate.Transaction = mTransaction;
                    mStockUpdate.PRINCIPAL_ID = p_PrincipalId;
                    mStockUpdate.TYPE_ID = mPurchaseMaster.TYPE_ID;
                    mStockUpdate.DISTRIBUTOR_ID = mPurchaseMaster.DISTRIBUTOR_ID;
                    mStockUpdate.STOCK_DATE = mPurchaseMaster.DOCUMENT_DATE;
                    mStockUpdate.SKU_ID = mPurchaseDetail.SKU_ID;
                    mStockUpdate.STOCK_QTY = mPurchaseDetail.QUANTITY;
                    mStockUpdate.FREE_QTY = mPurchaseDetail.FREE_SKU;
                    mStockUpdate.BATCHNO = mPurchaseDetail.BATCH_NO;
                    mStockUpdate.ExecuteQuery();
                }
                mTransaction.Commit();
                return true;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                mTransaction.Rollback();
                return false;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }

        }

        public bool InsertPurchaseDocumentStock(int p_DISTRIBUTOR_ID, string p_ORDER_NUMBER, int p_TYPE_ID, DateTime p_DOCUMENT_DATE, int p_SOLD_TO, int p_SOLD_FROM, decimal p_TOTAL_AMOUNT, bool p_IS_DELETE, DataTable dtPurchaseDetail, int p_Posting, string p_BuiltyNo, int p_UserId, int p_PrincipalId, int p_Damage_Type)
        {
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                mTransaction = ProviderFactory.GetTransaction(mConnection);
                spInsertPURCHASE_MASTER mPurchaseMaster = new spInsertPURCHASE_MASTER();
                mPurchaseMaster.Connection = mConnection;
                mPurchaseMaster.Transaction = mTransaction;
                mPurchaseMaster.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mPurchaseMaster.TYPE_ID = p_TYPE_ID;
                mPurchaseMaster.ORDER_NUMBER = p_ORDER_NUMBER;
                mPurchaseMaster.SOLD_FROM = p_SOLD_FROM;
                mPurchaseMaster.DOCUMENT_DATE = p_DOCUMENT_DATE;
                mPurchaseMaster.SOLD_TO = p_SOLD_TO;
                mPurchaseMaster.TOTAL_AMOUNT = p_TOTAL_AMOUNT;
                mPurchaseMaster.USER_ID = p_UserId;
                mPurchaseMaster.TIME_STAMP = DateTime.Now;
                mPurchaseMaster.LAST_UPDATE = DateTime.Now;
                mPurchaseMaster.POSTING = p_Posting;
                mPurchaseMaster.BUILTY_NO = p_BuiltyNo;
                mPurchaseMaster.PRINCIPAL_ID = p_PrincipalId;
                mPurchaseMaster.DAMAGE_TYPE = p_Damage_Type;
                mPurchaseMaster.ExecuteQuery();

                spInsertPURCHASE_DETAIL2 mPurchaseDetail = new spInsertPURCHASE_DETAIL2();
                mPurchaseDetail.Connection = mConnection;
                mPurchaseDetail.Transaction = mTransaction;

                foreach (DataRow dr in dtPurchaseDetail.Rows)
                {
                    mPurchaseDetail.PURCHASE_MASTER_ID = mPurchaseMaster.PURCHASE_MASTER_ID;
                    mPurchaseDetail.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                    mPurchaseDetail.SKU_ID = int.Parse(dr["SKU_ID"].ToString());
                    mPurchaseDetail.BATCH_NO = dr["BATCH_NO"].ToString();
                    mPurchaseDetail.PRICE = decimal.Parse(dr["PRICE"].ToString());
                    mPurchaseDetail.QUANTITY = int.Parse(dr["Total_Unit"].ToString());
                    mPurchaseDetail.FREE_SKU = int.Parse(dr["FREE_SKU"].ToString());
                    mPurchaseDetail.AMOUNT = decimal.Parse(dr["AMOUNT"].ToString());
                    mPurchaseDetail.TYPE_ID = mPurchaseMaster.TYPE_ID;
                    mPurchaseDetail.TIME_STAMP = p_DOCUMENT_DATE;
                    mPurchaseDetail.TDAMAGE = int.Parse(dr["TDAMAGE"].ToString());
                    mPurchaseDetail.ExecuteQuery();


                    UspProcessStockRegister mStockUpdate = new UspProcessStockRegister();
                    mStockUpdate.Connection = mConnection;
                    mStockUpdate.Transaction = mTransaction;
                    mStockUpdate.PRINCIPAL_ID = p_PrincipalId;
                    mStockUpdate.TYPE_ID = mPurchaseMaster.TYPE_ID;
                    mStockUpdate.DISTRIBUTOR_ID = mPurchaseMaster.DISTRIBUTOR_ID;
                    mStockUpdate.STOCK_DATE = mPurchaseMaster.DOCUMENT_DATE;
                    mStockUpdate.SKU_ID = mPurchaseDetail.SKU_ID;
                    mStockUpdate.STOCK_QTY = mPurchaseDetail.QUANTITY;
                    mStockUpdate.FREE_QTY = mPurchaseDetail.FREE_SKU;
                    mStockUpdate.BATCHNO = mPurchaseDetail.BATCH_NO;
                    mStockUpdate.ExecuteQuery();

                }

                CustomerDataController cd = new CustomerDataController();
                string p_Voucher_No = "";
                string CodeFileName = "";
                int CodeFileType = 0;
                DataTable dtMappSetting = cd.SelectMappingSetting(Constants.IntNullValue, Constants.IntNullValue);

                if (dtMappSetting != null || dtMappSetting.Rows.Count > 0)
                {
                    CodeFileName = dtMappSetting.Rows[0]["CODE_FILE"].ToString();
                    Configuration.GetAppMapping(CodeFileName);
                    CodeFileType = int.Parse(dtMappSetting.Rows[0]["CODE_TYPE"].ToString());
                }

                #region Mapped Acount Selection
                long p_PrincipalAccount_ID = 88;    //2002080001	Payable to (Principal Wise)
                string p_PrincipalAccount_Name = "";
                if (mPurchaseMaster.TYPE_ID == 2 || mPurchaseMaster.TYPE_ID == 3 || mPurchaseMaster.TYPE_ID == 4 ||
                    mPurchaseMaster.TYPE_ID == 5 || mPurchaseMaster.TYPE_ID == 6 || mPurchaseMaster.TYPE_ID == 8 ||
                    mPurchaseMaster.TYPE_ID == 9 || mPurchaseMaster.TYPE_ID == 10)
                {
                    DataTable dtAccount = cd.SelectAccountHeadMapping(1, Constants.IntNullValue, mPurchaseMaster.PRINCIPAL_ID, Constants.LongNullValue, Constants.IntNullValue);
                    if (dtAccount != null && dtAccount.Rows.Count > 0)
                    {
                        p_PrincipalAccount_ID = long.Parse(dtAccount.Rows[0]["Account_head_ID"].ToString());
                        p_PrincipalAccount_Name = dtAccount.Rows[0]["ACCOUNT_NAME"].ToString();

                    }
                }
                #endregion

                #region GL Voucher
                LedgerController LController = new LedgerController();
                string VoucherNo = LController.SelectMaxVoucherId(Constants.Journal_Voucher, p_DISTRIBUTOR_ID, DateTime.Now, mTransaction, mConnection);
                p_Voucher_No = VoucherNo;
                if (mPurchaseMaster.TYPE_ID == 2)// Purchase
                {
                    #region Purchases
                    string Remarks = "Default Purchase Voucher / Document # " + p_ORDER_NUMBER;
                    string Remarks2 = "Default Purchase Voucher";
                    string DocumentType = "Purchase";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), mPurchaseMaster.TOTAL_AMOUNT, 0, "Stock in Hand " + Remarks2, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, 0, mPurchaseMaster.TOTAL_AMOUNT, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, 897, mPurchaseMaster.TOTAL_AMOUNT, 0, "Purchases " + Remarks2, mTransaction, mConnection);
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, 0, mPurchaseMaster.TOTAL_AMOUNT, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 3)  // Purchase Return
                {
                    #region Purchase Return
                    string Remarks = "Default Purchase Return Voucher / Document # " + p_ORDER_NUMBER;
                    string Remarks2 = "Default Purchase Return Voucher";
                    string DocumentType = "Purchase Return";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), 0, mPurchaseMaster.TOTAL_AMOUNT, "Stock in Hand " + Remarks2, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, 897, 0, mPurchaseMaster.TOTAL_AMOUNT, "Purchases " + Remarks2, mTransaction, mConnection);
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 4)  // Transfer IN
                {
                    #region Transfer In
                    string Remarks = "Default Transfer In Voucher";
                    string DocumentType = "Transfer IN";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), mPurchaseMaster.TOTAL_AMOUNT, 0, "Stock in Hand " + Remarks, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.TransferInAccount), 0, mPurchaseMaster.TOTAL_AMOUNT, p_PrincipalAccount_Name + " " + Remarks, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 5)  // Transfer OUT
                {
                    #region Transfer Out
                    string Remarks = "Default Transfer Out Voucher";
                    string DocumentType = "Transfer Out";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.TransferOutAccount), mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), 0, mPurchaseMaster.TOTAL_AMOUNT, "Stock in Hand " + Remarks, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 6)  // Damage
                {
                    #region Damage
                    string Remarks = "Default Stock Damage Voucher / Document # " + mPurchaseMaster.PURCHASE_MASTER_ID;
                    string Remarks2 = "Default Stock Damage Voucher";
                    string DocumentType = "Stock Damage";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), 0, mPurchaseMaster.TOTAL_AMOUNT, "Stock In Hand " + Remarks2, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, 897, 0, mPurchaseMaster.TOTAL_AMOUNT, "Purchases " + Remarks2, mTransaction, mConnection);
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, 843, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 7) // Opening Stock
                {
                    #region Opening Stock
                    string Remarks = "Default Opening Stock Voucher";
                    string DocumentType = "Opening Stock";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, 0, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), mPurchaseMaster.TOTAL_AMOUNT, 0, "Stock In Hand " + Remarks, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.OpeningStock), 0, mPurchaseMaster.TOTAL_AMOUNT, "Opening at 31/8/19 " + Remarks, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp

                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 10) // Damage claimable
                {
                    #region Damage Claimable
                    string Remarks = "Default Stock Damage(Claimable) Voucher / Document # " + mPurchaseMaster.PURCHASE_MASTER_ID;
                    string Remarks2 = "Default Stock Damage(Claimable) Voucher";
                    string DocumentType = "Stock Damage(Claimable)";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), 0, mPurchaseMaster.TOTAL_AMOUNT, "Stock In Hand " + Remarks2, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, 897, 0, mPurchaseMaster.TOTAL_AMOUNT, "Purchases " + Remarks2, mTransaction, mConnection);
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, 845, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 8)  // Short
                {
                    #region Short
                    string Remarks = "Default Stock Short Voucher / Document # " + mPurchaseMaster.PURCHASE_MASTER_ID;
                    string Remarks2 = "Default Stock Short Voucher";
                    string DocumentType = "Stock Short";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, 0, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), 0, mPurchaseMaster.TOTAL_AMOUNT, "Stock In Hand " + Remarks2, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, 901, 0, mPurchaseMaster.TOTAL_AMOUNT, "Sales (All Principle) " + Remarks2, mTransaction, mConnection);
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, 898, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 9)  // Excess
                {
                    #region Excess
                    string Remarks = "Default Stock Excess Voucher / Document # " + mPurchaseMaster.PURCHASE_MASTER_ID;
                    string Remarks2 = "Default Stock Excess Voucher";
                    string DocumentType = "Stock Excess";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, 0, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), mPurchaseMaster.TOTAL_AMOUNT, 0, "Stock In Hand " + Remarks2, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, 0, mPurchaseMaster.TOTAL_AMOUNT, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, 897, mPurchaseMaster.TOTAL_AMOUNT, 0, "Purchases " + Remarks2, mTransaction, mConnection);
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, 900, 0, mPurchaseMaster.TOTAL_AMOUNT, "Unadjusted Credit Balance - Purchase " + Remarks2, mTransaction, mConnection);
                        }
                    }
                    #endregion
                }


                #endregion

                #region GL Master, Detail Old
                //if (p_TYPE_ID == 10)// Damage return
                //{
                //    LedgerController LController = new LedgerController();
                //    Configuration.GetAccountHead();

                //    if (p_Damage_Type == 2)// transit damage
                //    {
                //        string VoucherNo2 = LController.SelectMaxVoucherId(Constants.Journal_Voucher, p_DISTRIBUTOR_ID, DateTime.Now, mTransaction, mConnection);
                //        string Remarks = "Default Transit Damage Voucher";
                //        string Type = "Transit Damage Voucher";

                //        if (LController.PostingGLMaster(p_DISTRIBUTOR_ID, p_PrincipalId, VoucherNo2, Constants.Journal_Voucher, p_DOCUMENT_DATE, Constants.Document_Purchase, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                //        {
                //            LController.PostingGLDetail(p_DISTRIBUTOR_ID, p_PrincipalId, Constants.Journal_Voucher, VoucherNo2, long.Parse(Configuration.TransitDamage), p_TOTAL_AMOUNT, 0, "Transit Damage :" + Type, mTransaction, mConnection);
                //            LController.PostingGLDetail(p_DISTRIBUTOR_ID, p_PrincipalId, Constants.Journal_Voucher, VoucherNo2, long.Parse(Configuration.AccountReceivable), 0, p_TOTAL_AMOUNT, "Stock in Hand :" + Type, mTransaction, mConnection);
                //        }
                //    }

                //    if (p_Damage_Type == 0)// Market damage
                //    {
                //        string VoucherNo2 = LController.SelectMaxVoucherId(Constants.Journal_Voucher, p_DISTRIBUTOR_ID, DateTime.Now, mTransaction, mConnection);
                //        string Remarks = "Default Market Damage Voucher";
                //        string Type = "Market Damage Voucher";
                //        if (LController.PostingGLMaster(p_DISTRIBUTOR_ID, p_PrincipalId, VoucherNo2, Constants.Journal_Voucher, p_DOCUMENT_DATE, Constants.Document_Purchase, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                //        {
                //            LController.PostingGLDetail(p_DISTRIBUTOR_ID, p_PrincipalId, Constants.Journal_Voucher, VoucherNo2, long.Parse(Configuration.MarketDamage), p_TOTAL_AMOUNT, 0, "FMR (Principal Wise) :" + Type, mTransaction, mConnection);
                //            LController.PostingGLDetail(p_DISTRIBUTOR_ID, p_PrincipalId, Constants.Journal_Voucher, VoucherNo2, long.Parse(Configuration.AccountReceivable), 0, p_TOTAL_AMOUNT, "Stock in Hand :" + Type, mTransaction, mConnection);
                //        }
                //    }

                //}
                #endregion
                mTransaction.Commit();
                return true;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                mTransaction.Rollback();
                return false;
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
        /// Updates Purchase, TranferOut, Purchase Return, TranferIn And Damage Document
        /// </summary>
        /// <param name="p_PURCHASE_MASTER_ID">Purchase</param>
        /// <param name="p_DISTRIBUTOR_ID">Location</param>
        /// <param name="p_ORDER_NUMBER">DocumentNo</param>
        /// <param name="p_TYPE_ID">Type</param>
        /// <param name="p_DOCUMENT_DATE">Date</param>
        /// <param name="p_SOLD_TO">SoldTo</param>
        /// <param name="p_SOLD_FROM">SoldFrom</param>
        /// <param name="p_TOTAL_AMOUNT">Amount</param>
        /// <param name="p_IS_DELETE">IsDeleted</param>
        /// <param name="dtPurchaseDetail">PurchaseDetailDatatable</param>
        /// <param name="p_Posting">Posting</param>
        /// <param name="p_BuiltyNo">Builty</param>
        /// <param name="p_UserId">InsertedBy</param>
        /// <param name="p_Principal">Principal</param>
        /// <returns>True On Success And False On Failure</returns>

        public bool UpdatePurchaseDocumentStock(long p_PURCHASE_MASTER_ID, int p_DISTRIBUTOR_ID, string p_ORDER_NUMBER, int p_TYPE_ID, DateTime p_DOCUMENT_DATE, int p_SOLD_TO, int p_SOLD_FROM, decimal p_TOTAL_AMOUNT, bool p_IS_DELETE, DataTable dtPurchaseDetail, int p_Posting, string p_BuiltyNo, int p_UserId, int p_Principal)
        {
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                mTransaction = ProviderFactory.GetTransaction(mConnection);
                spUpdatePURCHASE_MASTER mPurchaseMaster = new spUpdatePURCHASE_MASTER();
                mPurchaseMaster.Connection = mConnection;
                mPurchaseMaster.Transaction = mTransaction;
                mPurchaseMaster.PURCHASE_MASTER_ID = p_PURCHASE_MASTER_ID;
                mPurchaseMaster.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mPurchaseMaster.TYPE_ID = p_TYPE_ID;
                mPurchaseMaster.ORDER_NUMBER = p_ORDER_NUMBER;
                mPurchaseMaster.SOLD_FROM = p_SOLD_FROM;
                mPurchaseMaster.DOCUMENT_DATE = p_DOCUMENT_DATE;
                mPurchaseMaster.SOLD_TO = p_SOLD_TO;
                mPurchaseMaster.TOTAL_AMOUNT = p_TOTAL_AMOUNT;
                mPurchaseMaster.USER_ID = p_UserId;
                mPurchaseMaster.LAST_UPDATE = DateTime.Now;
                mPurchaseMaster.POSTING = p_Posting;
                mPurchaseMaster.BUILTY_NO = p_BuiltyNo;
                mPurchaseMaster.ExecuteQuery();

                //Get Privouse Update Purchase Detail and Rollback
                //LedgerController LController = new LedgerController();

                //string VoucherNo = LController.SelectLedgerMaxDocumentId(Constants.Journal_Voucher, p_DISTRIBUTOR_ID);

                DataTable dt = SelectPrivousePurchaseDetail(p_DISTRIBUTOR_ID, p_PURCHASE_MASTER_ID, mConnection, mTransaction);

                foreach (DataRow dr in dt.Rows)
                {
                    UspUpdatePurchaseDetailStock mPurchaseStock = new UspUpdatePurchaseDetailStock();
                    mPurchaseStock.Connection = mConnection;
                    mPurchaseStock.Transaction = mTransaction;
                    mPurchaseStock.TYPEID = p_TYPE_ID;
                    mPurchaseStock.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                    mPurchaseStock.PURCHASE_DETAIL_ID = long.Parse(dr["PURCHASE_DETAIL_ID"].ToString());
                    mPurchaseStock.PURCHASE_MASTER_ID = p_PURCHASE_MASTER_ID;
                    mPurchaseStock.BATCH_NO = dr["BATCH_NO"].ToString().Trim();
                    mPurchaseStock.SKU_ID = int.Parse(dr["SKU_ID"].ToString());
                    mPurchaseStock.ExecuteQuery();
                }

                spInsertPURCHASE_DETAIL2 mPurchaseDetail = new spInsertPURCHASE_DETAIL2();
                mPurchaseDetail.Connection = mConnection;
                mPurchaseDetail.Transaction = mTransaction;

                foreach (DataRow dr in dtPurchaseDetail.Rows)
                {

                    //update stock;
                    mPurchaseDetail.PURCHASE_MASTER_ID = mPurchaseMaster.PURCHASE_MASTER_ID;
                    mPurchaseDetail.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                    mPurchaseDetail.SKU_ID = int.Parse(dr["SKU_ID"].ToString());
                    mPurchaseDetail.BATCH_NO = dr["BATCH_NO"].ToString();
                    mPurchaseDetail.PRICE = decimal.Parse(dr["PRICE"].ToString());
                    mPurchaseDetail.QUANTITY = int.Parse(dr["Total_Unit"].ToString());
                    mPurchaseDetail.FREE_SKU = int.Parse(dr["FREE_SKU"].ToString());
                    mPurchaseDetail.AMOUNT = decimal.Parse(dr["AMOUNT"].ToString());
                    mPurchaseDetail.TDAMAGE = int.Parse(dr["TDAMAGE"].ToString());
                    mPurchaseDetail.TYPE_ID = mPurchaseMaster.TYPE_ID;
                    mPurchaseDetail.TIME_STAMP = p_DOCUMENT_DATE;
                    mPurchaseDetail.ExecuteQuery();

                    UspProcessStockRegister mStockUpdate = new UspProcessStockRegister();
                    mStockUpdate.Connection = mConnection;
                    mStockUpdate.Transaction = mTransaction;
                    mStockUpdate.PRINCIPAL_ID = p_Principal;
                    mStockUpdate.TYPE_ID = mPurchaseMaster.TYPE_ID;
                    mStockUpdate.DISTRIBUTOR_ID = mPurchaseMaster.DISTRIBUTOR_ID;
                    mStockUpdate.STOCK_DATE = mPurchaseMaster.DOCUMENT_DATE;
                    mStockUpdate.SKU_ID = mPurchaseDetail.SKU_ID;
                    mStockUpdate.STOCK_QTY = mPurchaseDetail.QUANTITY;
                    mStockUpdate.FREE_QTY = mPurchaseDetail.FREE_SKU;
                    mStockUpdate.BATCHNO = mPurchaseDetail.BATCH_NO;
                    mStockUpdate.ExecuteQuery();
                }

                CustomerDataController cd = new CustomerDataController();
                string p_Voucher_No = "";
                string CodeFileName = "";
                int CodeFileType = 0;
                DataTable dtMappSetting = cd.SelectMappingSetting(Constants.IntNullValue, Constants.IntNullValue);

                if (dtMappSetting != null || dtMappSetting.Rows.Count > 0)
                {
                    CodeFileName = dtMappSetting.Rows[0]["CODE_FILE"].ToString();
                    Configuration.GetAppMapping(CodeFileName);
                    CodeFileType = int.Parse(dtMappSetting.Rows[0]["CODE_TYPE"].ToString());
                }

                #region Mapped Acount Selection
                long p_PrincipalAccount_ID = 88;    //2002080001	Payable to (Principal Wise)
                string p_PrincipalAccount_Name = "";
                if (mPurchaseMaster.TYPE_ID == 2 || mPurchaseMaster.TYPE_ID == 3 || mPurchaseMaster.TYPE_ID == 4 ||
                    mPurchaseMaster.TYPE_ID == 5 || mPurchaseMaster.TYPE_ID == 6 || mPurchaseMaster.TYPE_ID == 8 ||
                    mPurchaseMaster.TYPE_ID == 9 || mPurchaseMaster.TYPE_ID == 10)
                {
                    DataTable dtAccount = cd.SelectAccountHeadMapping(1, Constants.IntNullValue, p_Principal, Constants.LongNullValue, Constants.IntNullValue);
                    if (dtAccount != null && dtAccount.Rows.Count > 0)
                    {
                        p_PrincipalAccount_ID = long.Parse(dtAccount.Rows[0]["Account_head_ID"].ToString());
                        p_PrincipalAccount_Name = dtAccount.Rows[0]["ACCOUNT_NAME"].ToString();

                    }
                }
                #endregion

                #region GL Voucher
                LedgerController LController = new LedgerController();
                string VoucherNo = LController.SelectMaxVoucherId(Constants.Journal_Voucher, p_DISTRIBUTOR_ID, DateTime.Now, mTransaction, mConnection);
                p_Voucher_No = VoucherNo;
                if (mPurchaseMaster.TYPE_ID == 2)// Purchase
                {
                    #region Purchases
                    string Remarks = "Default Purchase Voucher / Document # " + p_ORDER_NUMBER;
                    string Remarks2 = "Default Purchase Voucher";
                    string DocumentType = "Purchase";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, p_Principal, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, p_Principal, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), mPurchaseMaster.TOTAL_AMOUNT, 0, "Stock in Hand " + Remarks2, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, p_Principal, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, 0, mPurchaseMaster.TOTAL_AMOUNT, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, 897, mPurchaseMaster.TOTAL_AMOUNT, 0, "Purchases " + Remarks2, mTransaction, mConnection);
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, 0, mPurchaseMaster.TOTAL_AMOUNT, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 3)  // Purchase Return
                {
                    #region Purchase Return
                    string Remarks = "Default Purchase Return Voucher / Document # " + p_ORDER_NUMBER;
                    string Remarks2 = "Default Purchase Return Voucher";
                    string DocumentType = "Purchase Return";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, p_Principal, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, p_Principal, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), 0, mPurchaseMaster.TOTAL_AMOUNT, "Stock in Hand " + Remarks2, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, p_Principal, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, 897, 0, mPurchaseMaster.TOTAL_AMOUNT, "Purchases " + Remarks2, mTransaction, mConnection);
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 4)  // Transfer IN
                {
                    #region Transfer In
                    string Remarks = "Default Transfer In Voucher";
                    string DocumentType = "Transfer IN";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, p_Principal, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, p_Principal, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), mPurchaseMaster.TOTAL_AMOUNT, 0, "Stock in Hand " + Remarks, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, p_Principal, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.TransferInAccount), 0, mPurchaseMaster.TOTAL_AMOUNT, p_PrincipalAccount_Name + " " + Remarks, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 5)  // Transfer OUT
                {
                    #region Transfer Out
                    string Remarks = "Default Transfer Out Voucher";
                    string DocumentType = "Transfer Out";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, p_Principal, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, p_Principal, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.TransferOutAccount), mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, p_Principal, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), 0, mPurchaseMaster.TOTAL_AMOUNT, "Stock in Hand " + Remarks, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 6)  // Damage
                {
                    #region Damage
                    string Remarks = "Default Stock Damage Voucher / Document # " + mPurchaseMaster.PURCHASE_MASTER_ID;
                    string Remarks2 = "Default Stock Damage Voucher";
                    string DocumentType = "Stock Damage";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, p_Principal, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, p_Principal, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), 0, mPurchaseMaster.TOTAL_AMOUNT, "Stock In Hand " + Remarks2, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, p_Principal, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, 897, 0, mPurchaseMaster.TOTAL_AMOUNT, "Purchases " + Remarks2, mTransaction, mConnection);
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, 843, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 7) // Opening Stock
                {
                    #region Opening Stock
                    string Remarks = "Default Opening Stock Voucher";
                    string DocumentType = "Opening Stock";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, 0, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), mPurchaseMaster.TOTAL_AMOUNT, 0, "Stock In Hand " + Remarks, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.OpeningStock), 0, mPurchaseMaster.TOTAL_AMOUNT, "Opening at 31/8/19 " + Remarks, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp

                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 10) // Damage claimable
                {
                    #region Damage Claimable
                    string Remarks = "Default Stock Damage(Claimable) Voucher / Document # " + mPurchaseMaster.PURCHASE_MASTER_ID;
                    string Remarks2 = "Default Stock Damage(Claimable) Voucher";
                    string DocumentType = "Stock Damage(Claimable)";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, p_Principal, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, p_Principal, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), 0, mPurchaseMaster.TOTAL_AMOUNT, "Stock In Hand " + Remarks2, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, p_Principal, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, 897, 0, mPurchaseMaster.TOTAL_AMOUNT, "Purchases " + Remarks2, mTransaction, mConnection);
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, 845, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 8)  // Short
                {
                    #region Short
                    string Remarks = "Default Stock Short Voucher / Document # " + mPurchaseMaster.PURCHASE_MASTER_ID;
                    string Remarks2 = "Default Stock Short Voucher";
                    string DocumentType = "Stock Short";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, 0, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), 0, mPurchaseMaster.TOTAL_AMOUNT, "Stock In Hand " + Remarks2, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, 901, 0, mPurchaseMaster.TOTAL_AMOUNT, "Sales (All Principle) " + Remarks2, mTransaction, mConnection);
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, 898, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 9)  // Excess
                {
                    #region Excess
                    string Remarks = "Default Stock Excess Voucher / Document # " + mPurchaseMaster.PURCHASE_MASTER_ID;
                    string Remarks2 = "Default Stock Excess Voucher";
                    string DocumentType = "Stock Excess";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, 0, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), mPurchaseMaster.TOTAL_AMOUNT, 0, "Stock In Hand " + Remarks2, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, 0, mPurchaseMaster.TOTAL_AMOUNT, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, 897, mPurchaseMaster.TOTAL_AMOUNT, 0, "Purchases " + Remarks2, mTransaction, mConnection);
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, 900, 0, mPurchaseMaster.TOTAL_AMOUNT, "Unadjusted Credit Balance - Purchase " + Remarks2, mTransaction, mConnection);
                        }
                    }
                    #endregion
                }
                #endregion

                mTransaction.Commit();
                return true;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                mTransaction.Rollback();
                return false;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }

        }

       
        public bool UpdatePurchaseDocumentStock(long p_PURCHASE_MASTER_ID, int p_DISTRIBUTOR_ID, string p_ORDER_NUMBER, int p_TYPE_ID, DateTime p_DOCUMENT_DATE, int p_SOLD_TO, int p_SOLD_FROM, decimal p_TOTAL_AMOUNT, bool p_IS_DELETE, DataTable dtPurchaseDetail, int p_Posting, string p_BuiltyNo, int p_UserId, int p_Principal, decimal p_FREIGHT_AMOUNT, decimal p_GST_AMOUNT, decimal p_TST_AMOUNT)
        {
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                mTransaction = ProviderFactory.GetTransaction(mConnection);
                spUpdatePURCHASE_MASTER mPurchaseMaster = new spUpdatePURCHASE_MASTER();
                mPurchaseMaster.Connection = mConnection;
                mPurchaseMaster.Transaction = mTransaction;
                mPurchaseMaster.PURCHASE_MASTER_ID = p_PURCHASE_MASTER_ID;
                mPurchaseMaster.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mPurchaseMaster.TYPE_ID = p_TYPE_ID;
                mPurchaseMaster.ORDER_NUMBER = p_ORDER_NUMBER;
                mPurchaseMaster.SOLD_FROM = p_SOLD_FROM;
                mPurchaseMaster.DOCUMENT_DATE = p_DOCUMENT_DATE;
                mPurchaseMaster.SOLD_TO = p_SOLD_TO;
                mPurchaseMaster.TOTAL_AMOUNT = p_TOTAL_AMOUNT;
                mPurchaseMaster.USER_ID = p_UserId;
                mPurchaseMaster.LAST_UPDATE = DateTime.Now;
                mPurchaseMaster.POSTING = p_Posting;
                mPurchaseMaster.BUILTY_NO = p_BuiltyNo;
                mPurchaseMaster.FREIGHT_AMOUNT = p_FREIGHT_AMOUNT;
                mPurchaseMaster.GST_AMOUNT = p_GST_AMOUNT;
                mPurchaseMaster.TST_AMOUNT = p_TST_AMOUNT;
                mPurchaseMaster.ExecuteQuery();

                //Get Privouse Update Purchase Detail and Rollback
                //LedgerController LController = new LedgerController();

                //string VoucherNo = LController.SelectLedgerMaxDocumentId(Constants.Journal_Voucher, p_DISTRIBUTOR_ID);

                DataTable dt = SelectPrivousePurchaseDetail(p_DISTRIBUTOR_ID, p_PURCHASE_MASTER_ID, mConnection, mTransaction);

                foreach (DataRow dr in dt.Rows)
                {
                    UspUpdatePurchaseDetailStock mPurchaseStock = new UspUpdatePurchaseDetailStock();
                    mPurchaseStock.Connection = mConnection;
                    mPurchaseStock.Transaction = mTransaction;
                    mPurchaseStock.TYPEID = p_TYPE_ID;
                    mPurchaseStock.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                    mPurchaseStock.PURCHASE_DETAIL_ID = long.Parse(dr["PURCHASE_DETAIL_ID"].ToString());
                    mPurchaseStock.PURCHASE_MASTER_ID = p_PURCHASE_MASTER_ID;
                    mPurchaseStock.BATCH_NO = dr["BATCH_NO"].ToString().Trim();
                    mPurchaseStock.SKU_ID = int.Parse(dr["SKU_ID"].ToString());
                    mPurchaseStock.ExecuteQuery();
                }

                spInsertPURCHASE_DETAIL2 mPurchaseDetail = new spInsertPURCHASE_DETAIL2();
                mPurchaseDetail.Connection = mConnection;
                mPurchaseDetail.Transaction = mTransaction;

                foreach (DataRow dr in dtPurchaseDetail.Rows)
                {

                    //update stock;
                    mPurchaseDetail.PURCHASE_MASTER_ID = mPurchaseMaster.PURCHASE_MASTER_ID;
                    mPurchaseDetail.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                    mPurchaseDetail.SKU_ID = int.Parse(dr["SKU_ID"].ToString());
                    mPurchaseDetail.BATCH_NO = dr["BATCH_NO"].ToString();
                    mPurchaseDetail.PRICE = decimal.Parse(dr["PRICE"].ToString());
                    mPurchaseDetail.QUANTITY = int.Parse(dr["Total_Unit"].ToString());
                    mPurchaseDetail.FREE_SKU = int.Parse(dr["FREE_SKU"].ToString());
                    mPurchaseDetail.AMOUNT = decimal.Parse(dr["AMOUNT"].ToString());
                    mPurchaseDetail.GST_AMOUNT = decimal.Parse(dr["GST_AMOUNT"].ToString());
                    mPurchaseDetail.TST_AMOUNT = decimal.Parse(dr["TST_AMOUNT"].ToString());
                    mPurchaseDetail.GST_RATE = decimal.Parse(dr["GST_RATE"].ToString());

                    mPurchaseDetail.TDAMAGE = int.Parse(dr["TDAMAGE"].ToString());
                    mPurchaseDetail.TYPE_ID = mPurchaseMaster.TYPE_ID;
                    mPurchaseDetail.TIME_STAMP = p_DOCUMENT_DATE;
                    mPurchaseDetail.ExecuteQuery();

                    UspProcessStockRegister mStockUpdate = new UspProcessStockRegister();
                    mStockUpdate.Connection = mConnection;
                    mStockUpdate.Transaction = mTransaction;
                    mStockUpdate.PRINCIPAL_ID = p_Principal;
                    mStockUpdate.TYPE_ID = mPurchaseMaster.TYPE_ID;
                    mStockUpdate.DISTRIBUTOR_ID = mPurchaseMaster.DISTRIBUTOR_ID;
                    mStockUpdate.STOCK_DATE = mPurchaseMaster.DOCUMENT_DATE;
                    mStockUpdate.SKU_ID = mPurchaseDetail.SKU_ID;
                    mStockUpdate.STOCK_QTY = mPurchaseDetail.QUANTITY;
                    mStockUpdate.FREE_QTY = mPurchaseDetail.FREE_SKU;
                    mStockUpdate.BATCHNO = mPurchaseDetail.BATCH_NO;
                    mStockUpdate.ExecuteQuery();
                }
                mTransaction.Commit();
                return true;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                mTransaction.Rollback();
                return false;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }

        }

        public bool UpdatePurchaseDocumentStock(long p_PURCHASE_MASTER_ID, int p_DISTRIBUTOR_ID, string p_ORDER_NUMBER, int p_TYPE_ID, DateTime p_DOCUMENT_DATE, int p_SOLD_TO, int p_SOLD_FROM, decimal p_TOTAL_AMOUNT, bool p_IS_DELETE, DataTable dtPurchaseDetail, int p_Posting, string p_BuiltyNo, int p_UserId, int p_Principal, int p_Damage_Type)
        {
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                mTransaction = ProviderFactory.GetTransaction(mConnection);
                spUpdatePURCHASE_MASTER mPurchaseMaster = new spUpdatePURCHASE_MASTER();
                mPurchaseMaster.Connection = mConnection;
                mPurchaseMaster.Transaction = mTransaction;
                mPurchaseMaster.PURCHASE_MASTER_ID = p_PURCHASE_MASTER_ID;
                mPurchaseMaster.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mPurchaseMaster.TYPE_ID = p_TYPE_ID;
                mPurchaseMaster.ORDER_NUMBER = p_ORDER_NUMBER;
                mPurchaseMaster.SOLD_FROM = p_SOLD_FROM;
                mPurchaseMaster.DOCUMENT_DATE = p_DOCUMENT_DATE;
                mPurchaseMaster.SOLD_TO = p_SOLD_TO;
                mPurchaseMaster.TOTAL_AMOUNT = p_TOTAL_AMOUNT;
                mPurchaseMaster.USER_ID = p_UserId;
                mPurchaseMaster.LAST_UPDATE = DateTime.Now;
                mPurchaseMaster.POSTING = p_Posting;
                mPurchaseMaster.BUILTY_NO = p_BuiltyNo;
                mPurchaseMaster.DAMAGE_TYPE = p_Damage_Type;
                mPurchaseMaster.ExecuteQuery();

                //Get Privouse Update Purchase Detail and Rollback
                //LedgerController LController = new LedgerController();

                //string VoucherNo = LController.SelectLedgerMaxDocumentId(Constants.Journal_Voucher, p_DISTRIBUTOR_ID);

                DataTable dt = SelectPrivousePurchaseDetail(p_DISTRIBUTOR_ID, p_PURCHASE_MASTER_ID, mConnection, mTransaction);

                foreach (DataRow dr in dt.Rows)
                {
                    UspUpdatePurchaseDetailStock mPurchaseStock = new UspUpdatePurchaseDetailStock();
                    mPurchaseStock.Connection = mConnection;
                    mPurchaseStock.Transaction = mTransaction;
                    mPurchaseStock.TYPEID = p_TYPE_ID;
                    mPurchaseStock.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                    mPurchaseStock.PURCHASE_DETAIL_ID = long.Parse(dr["PURCHASE_DETAIL_ID"].ToString());
                    mPurchaseStock.PURCHASE_MASTER_ID = p_PURCHASE_MASTER_ID;
                    mPurchaseStock.BATCH_NO = dr["BATCH_NO"].ToString().Trim();
                    mPurchaseStock.SKU_ID = int.Parse(dr["SKU_ID"].ToString());
                    mPurchaseStock.ExecuteQuery();
                }

                spInsertPURCHASE_DETAIL2 mPurchaseDetail = new spInsertPURCHASE_DETAIL2();
                mPurchaseDetail.Connection = mConnection;
                mPurchaseDetail.Transaction = mTransaction;

                foreach (DataRow dr in dtPurchaseDetail.Rows)
                {

                    //update stock;
                    mPurchaseDetail.PURCHASE_MASTER_ID = mPurchaseMaster.PURCHASE_MASTER_ID;
                    mPurchaseDetail.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                    mPurchaseDetail.SKU_ID = int.Parse(dr["SKU_ID"].ToString());
                    mPurchaseDetail.BATCH_NO = dr["BATCH_NO"].ToString();
                    mPurchaseDetail.PRICE = decimal.Parse(dr["PRICE"].ToString());
                    mPurchaseDetail.QUANTITY = int.Parse(dr["Total_Unit"].ToString());
                    mPurchaseDetail.FREE_SKU = int.Parse(dr["FREE_SKU"].ToString());
                    mPurchaseDetail.AMOUNT = decimal.Parse(dr["AMOUNT"].ToString());
                    mPurchaseDetail.TDAMAGE = int.Parse(dr["TDAMAGE"].ToString());
                    mPurchaseDetail.TYPE_ID = mPurchaseMaster.TYPE_ID;
                    mPurchaseDetail.TIME_STAMP = p_DOCUMENT_DATE;
                    mPurchaseDetail.ExecuteQuery();

                    UspProcessStockRegister mStockUpdate = new UspProcessStockRegister();
                    mStockUpdate.Connection = mConnection;
                    mStockUpdate.Transaction = mTransaction;
                    mStockUpdate.PRINCIPAL_ID = p_Principal;
                    mStockUpdate.TYPE_ID = mPurchaseMaster.TYPE_ID;
                    mStockUpdate.DISTRIBUTOR_ID = mPurchaseMaster.DISTRIBUTOR_ID;
                    mStockUpdate.STOCK_DATE = mPurchaseMaster.DOCUMENT_DATE;
                    mStockUpdate.SKU_ID = mPurchaseDetail.SKU_ID;
                    mStockUpdate.STOCK_QTY = mPurchaseDetail.QUANTITY;
                    mStockUpdate.FREE_QTY = mPurchaseDetail.FREE_SKU;
                    mStockUpdate.BATCHNO = mPurchaseDetail.BATCH_NO;
                    mStockUpdate.ExecuteQuery();
                }

                CustomerDataController cd = new CustomerDataController();
                string p_Voucher_No = "";
                string CodeFileName = "";
                int CodeFileType = 0;
                DataTable dtMappSetting = cd.SelectMappingSetting(Constants.IntNullValue, Constants.IntNullValue);

                if (dtMappSetting != null || dtMappSetting.Rows.Count > 0)
                {
                    CodeFileName = dtMappSetting.Rows[0]["CODE_FILE"].ToString();
                    Configuration.GetAppMapping(CodeFileName);
                    CodeFileType = int.Parse(dtMappSetting.Rows[0]["CODE_TYPE"].ToString());
                }


                #region Mapped Acount Selection
                long p_PrincipalAccount_ID = 88;    //2002080001	Payable to (Principal Wise)
                string p_PrincipalAccount_Name = "";
                if (mPurchaseMaster.TYPE_ID == 2 || mPurchaseMaster.TYPE_ID == 3 || mPurchaseMaster.TYPE_ID == 4 || 
                    mPurchaseMaster.TYPE_ID == 5 || mPurchaseMaster.TYPE_ID == 6 || mPurchaseMaster.TYPE_ID == 8 ||
                    mPurchaseMaster.TYPE_ID == 9 || mPurchaseMaster.TYPE_ID == 10) 
                {
                    DataTable dtAccount = cd.SelectAccountHeadMapping(1, Constants.IntNullValue, p_Principal, Constants.LongNullValue, Constants.IntNullValue);
                    if (dtAccount != null && dtAccount.Rows.Count > 0)
                    {
                        p_PrincipalAccount_ID = long.Parse(dtAccount.Rows[0]["Account_head_ID"].ToString());
                        p_PrincipalAccount_Name = dtAccount.Rows[0]["ACCOUNT_NAME"].ToString();

                    }
                }
                #endregion

                #region GL Voucher
                LedgerController LController = new LedgerController();
                string VoucherNo = LController.SelectMaxVoucherId(Constants.Journal_Voucher, p_DISTRIBUTOR_ID, DateTime.Now, mTransaction, mConnection);
                p_Voucher_No = VoucherNo;
                if (mPurchaseMaster.TYPE_ID == 2)// Purchase
                {
                    #region Purchases
                    string Remarks = "Default Purchase Voucher / Document # " + p_ORDER_NUMBER;
                    string Remarks2 = "Default Purchase Voucher";
                    string DocumentType = "Purchase";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, p_Principal, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, p_Principal, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), mPurchaseMaster.TOTAL_AMOUNT, 0, "Stock in Hand " + Remarks2, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, p_Principal, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, 0, mPurchaseMaster.TOTAL_AMOUNT, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, 897, mPurchaseMaster.TOTAL_AMOUNT, 0, "Purchases " + Remarks2, mTransaction, mConnection);
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, 0, mPurchaseMaster.TOTAL_AMOUNT, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 3)  // Purchase Return
                {
                    #region Purchase Return
                    string Remarks = "Default Purchase Return Voucher / Document # " + p_ORDER_NUMBER;
                    string Remarks2 = "Default Purchase Return Voucher";
                    string DocumentType = "Purchase Return";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, p_Principal, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, p_Principal, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), 0, mPurchaseMaster.TOTAL_AMOUNT, "Stock in Hand " + Remarks2, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, p_Principal, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, 897, 0, mPurchaseMaster.TOTAL_AMOUNT, "Purchases " + Remarks2, mTransaction, mConnection);
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 4)  // Transfer IN
                {
                    #region Transfer In
                    string Remarks = "Default Transfer In Voucher";
                    string DocumentType = "Transfer IN";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, p_Principal, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, p_Principal, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), mPurchaseMaster.TOTAL_AMOUNT, 0, "Stock in Hand " + Remarks, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, p_Principal, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.TransferInAccount), 0, mPurchaseMaster.TOTAL_AMOUNT, p_PrincipalAccount_Name + " " + Remarks, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 5)  // Transfer OUT
                {
                    #region Transfer Out
                    string Remarks = "Default Transfer Out Voucher";
                    string DocumentType = "Transfer Out";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, p_Principal, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, p_Principal, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.TransferOutAccount), mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, p_Principal, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), 0, mPurchaseMaster.TOTAL_AMOUNT, "Stock in Hand " + Remarks, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 6)  // Damage
                {
                    #region Damage
                    string Remarks = "Default Stock Damage Voucher / Document # " + mPurchaseMaster.PURCHASE_MASTER_ID;
                    string Remarks2 = "Default Stock Damage Voucher";
                    string DocumentType = "Stock Damage";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, p_Principal, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, p_Principal, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), 0, mPurchaseMaster.TOTAL_AMOUNT, "Stock In Hand " + Remarks2, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, p_Principal, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, 897, 0, mPurchaseMaster.TOTAL_AMOUNT, "Purchases " + Remarks2, mTransaction, mConnection);
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, 843, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 7) // Opening Stock
                {
                    #region Opening Stock
                    string Remarks = "Default Opening Stock Voucher";
                    string DocumentType = "Opening Stock";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, 0, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), mPurchaseMaster.TOTAL_AMOUNT, 0, "Stock In Hand " + Remarks, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.OpeningStock), 0, mPurchaseMaster.TOTAL_AMOUNT, "Opening at 31/8/19 " + Remarks, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp

                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 10) // Damage claimable
                {
                    #region Damage Claimable
                    string Remarks = "Default Stock Damage(Claimable) Voucher / Document # " + mPurchaseMaster.PURCHASE_MASTER_ID;
                    string Remarks2 = "Default Stock Damage(Claimable) Voucher";
                    string DocumentType = "Stock Damage(Claimable)";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, p_Principal, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, p_Principal, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), 0, mPurchaseMaster.TOTAL_AMOUNT, "Stock In Hand " + Remarks2, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, p_Principal, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, 897, 0, mPurchaseMaster.TOTAL_AMOUNT, "Purchases " + Remarks2, mTransaction, mConnection);
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, 845, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 8)  // Short
                {
                    #region Short
                    string Remarks = "Default Stock Short Voucher / Document # " + mPurchaseMaster.PURCHASE_MASTER_ID;
                    string Remarks2 = "Default Stock Short Voucher";
                    string DocumentType = "Stock Short";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, 0, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), 0, mPurchaseMaster.TOTAL_AMOUNT, "Stock In Hand " + Remarks2, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, 901, 0, mPurchaseMaster.TOTAL_AMOUNT, "Sales (All Principle) " + Remarks2, mTransaction, mConnection);
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, 898, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 9)  // Excess
                {
                    #region Excess
                    string Remarks = "Default Stock Excess Voucher / Document # " + mPurchaseMaster.PURCHASE_MASTER_ID;
                    string Remarks2 = "Default Stock Excess Voucher";
                    string DocumentType = "Stock Excess";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, 0, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), mPurchaseMaster.TOTAL_AMOUNT, 0, "Stock In Hand " + Remarks2, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, 0, mPurchaseMaster.TOTAL_AMOUNT, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, 897, mPurchaseMaster.TOTAL_AMOUNT, 0, "Purchases " + Remarks2, mTransaction, mConnection);
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, 900, 0, mPurchaseMaster.TOTAL_AMOUNT, "Unadjusted Credit Balance - Purchase " + Remarks2, mTransaction, mConnection);
                        }
                    }
                    #endregion
                }


                #endregion

                #region GL Master, Detail Old
                //if (p_TYPE_ID == 10)// Damage return
                //{
                //    LedgerController LController = new LedgerController();
                //    Configuration.GetAccountHead();
                //    //    //string VoucherNo = LController.SelectLedgerMaxDocumentId(Constants.Journal_Voucher, p_DISTRIBUTOR_ID, 1, mTransaction, mConnection);
                //    //    //LController.PostingPrinvipalInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.SaleAccount), p_DISTRIBUTOR_ID, 0, p_TOTAL_AMOUNT, mPrchMaster.DOCUMENT_DATE, "Transfer In Default", DateTime.Now, p_PrincipalId, mPrchMaster.PURCHASE_MASTER_ID, Convert.ToString(mPrchMaster.PURCHASE_MASTER_ID), Constants.Document_Transfer_In, p_UserId, mTransaction, mConnection, Constants.Document_Transfer_In, "Transfer IN");
                //    //    //LController.PostingPrinvipalInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.StockMovement), p_DISTRIBUTOR_ID, p_TOTAL_AMOUNT, 0, mPrchMaster.DOCUMENT_DATE, "Transfer In Default", DateTime.Now, p_PrincipalId, mPrchMaster.PURCHASE_MASTER_ID, Convert.ToString(mPrchMaster.PURCHASE_MASTER_ID), Constants.Document_Transfer_In, p_UserId, mTransaction, mConnection, Constants.Document_Transfer_In, "Transfer IN");

                //    if (p_Damage_Type == 2)// transit damage
                //    {
                //        string VoucherNo2 = LController.SelectMaxVoucherId(Constants.Journal_Voucher, p_DISTRIBUTOR_ID, DateTime.Now, mTransaction, mConnection);
                //        string Remarks = "Default Transit Damage Voucher";
                //        string Type = "Transit Damage Voucher";
                //        if (LController.PostingGLMaster(p_DISTRIBUTOR_ID, p_Principal, VoucherNo2, Constants.Journal_Voucher, p_DOCUMENT_DATE, Constants.Document_Purchase, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                //        {
                //            LController.PostingGLDetail(p_DISTRIBUTOR_ID, p_Principal, Constants.Journal_Voucher, VoucherNo2, long.Parse(Configuration.TransitDamage), p_TOTAL_AMOUNT, 0, "Transit Damage :" + Type, mTransaction, mConnection);
                //            LController.PostingGLDetail(p_DISTRIBUTOR_ID, p_Principal, Constants.Journal_Voucher, VoucherNo2, long.Parse(Configuration.AccountReceivable), 0, p_TOTAL_AMOUNT, "Stock in Hand :" + Type, mTransaction, mConnection);
                //        }
                //    }

                //    if (p_Damage_Type == 0)// Market damage
                //    {
                //        string VoucherNo2 = LController.SelectMaxVoucherId(Constants.Journal_Voucher, p_DISTRIBUTOR_ID, DateTime.Now, mTransaction, mConnection);
                //        string Remarks = "Default Market Damage Voucher";
                //        string Type = "Market Damage Voucher";
                //        if (LController.PostingGLMaster(p_DISTRIBUTOR_ID, p_Principal, VoucherNo2, Constants.Journal_Voucher, p_DOCUMENT_DATE, Constants.Document_Purchase, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                //        {
                //            LController.PostingGLDetail(p_DISTRIBUTOR_ID, p_Principal, Constants.Journal_Voucher, VoucherNo2, long.Parse(Configuration.MarketDamage), p_TOTAL_AMOUNT, 0, "FMR (Principal Wise) :" + Type, mTransaction, mConnection);
                //            LController.PostingGLDetail(p_DISTRIBUTOR_ID, p_Principal, Constants.Journal_Voucher, VoucherNo2, long.Parse(Configuration.AccountReceivable), 0, p_TOTAL_AMOUNT, "Stock in Hand :" + Type, mTransaction, mConnection);
                //        }
                //    }

                //}
                #endregion
                mTransaction.Commit();
                return true;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                mTransaction.Rollback();
                return false;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }

        }


        public bool UpdatePurchase(long p_PURCHASE_MASTER_ID, int p_DISTRIBUTOR_ID, string p_ORDER_NUMBER, int p_TYPE_ID, DateTime p_DOCUMENT_DATE, int p_SOLD_TO, int p_SOLD_FROM, decimal p_TOTAL_AMOUNT, bool p_IS_DELETE, DataTable dtPurchaseDetail, int p_Posting, string p_BuiltyNo, int p_UserId, int p_Principal, decimal p_FMR, decimal p_MR, decimal p_Pur_Discount, decimal p_GST_Amount, decimal p_Tst_Amount, decimal p_Total_Net_Amount, DateTime p_INVOICE_DATE)
        {
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                mTransaction = ProviderFactory.GetTransaction(mConnection);
                spUpdatePURCHASE_MASTER mPurchaseMaster = new spUpdatePURCHASE_MASTER();
                mPurchaseMaster.Connection = mConnection;
                mPurchaseMaster.Transaction = mTransaction;
                mPurchaseMaster.PURCHASE_MASTER_ID = p_PURCHASE_MASTER_ID;
                mPurchaseMaster.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mPurchaseMaster.TYPE_ID = p_TYPE_ID;
                mPurchaseMaster.ORDER_NUMBER = p_ORDER_NUMBER;
                mPurchaseMaster.SOLD_FROM = p_SOLD_FROM;
                mPurchaseMaster.DOCUMENT_DATE = p_DOCUMENT_DATE;
                mPurchaseMaster.SOLD_TO = p_SOLD_TO;
                mPurchaseMaster.TOTAL_AMOUNT = p_TOTAL_AMOUNT;
                mPurchaseMaster.USER_ID = p_UserId;
                mPurchaseMaster.LAST_UPDATE = DateTime.Now;
                mPurchaseMaster.POSTING = p_Posting;
                mPurchaseMaster.BUILTY_NO = p_BuiltyNo;
                mPurchaseMaster.FMR = p_FMR;
                mPurchaseMaster.MR = p_MR;
                mPurchaseMaster.PUR_DISCOUNT = p_Pur_Discount;
                mPurchaseMaster.GST_AMOUNT = p_GST_Amount;
                mPurchaseMaster.TST_AMOUNT = p_Tst_Amount;
                mPurchaseMaster.TOTAL_NET_AMOUNT = p_Total_Net_Amount;
                mPurchaseMaster.IS_DELETED = false;
                mPurchaseMaster.INVOICE_DATE = p_INVOICE_DATE;
                mPurchaseMaster.ExecuteQuery();

                //Get Privouse Update Purchase Detail and Rollback
                //LedgerController LController = new LedgerController();

                //string VoucherNo = LController.SelectLedgerMaxDocumentId(Constants.Journal_Voucher, p_DISTRIBUTOR_ID);

                DataTable dt = SelectPrivousePurchaseDetail(p_DISTRIBUTOR_ID, p_PURCHASE_MASTER_ID, mConnection, mTransaction);

                foreach (DataRow dr in dt.Rows)
                {
                    UspUpdatePurchaseDetailStock mPurchaseStock = new UspUpdatePurchaseDetailStock();
                    mPurchaseStock.Connection = mConnection;
                    mPurchaseStock.Transaction = mTransaction;
                    mPurchaseStock.TYPEID = p_TYPE_ID;
                    mPurchaseStock.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                    mPurchaseStock.PURCHASE_DETAIL_ID = long.Parse(dr["PURCHASE_DETAIL_ID"].ToString());
                    mPurchaseStock.PURCHASE_MASTER_ID = p_PURCHASE_MASTER_ID;
                    mPurchaseStock.BATCH_NO = dr["BATCH_NO"].ToString().Trim();
                    mPurchaseStock.SKU_ID = int.Parse(dr["SKU_ID"].ToString());
                    mPurchaseStock.ExecuteQuery();
                }

                spInsertPURCHASE_DETAIL2 mPurchaseDetail = new spInsertPURCHASE_DETAIL2();
                mPurchaseDetail.Connection = mConnection;
                mPurchaseDetail.Transaction = mTransaction;

                foreach (DataRow dr in dtPurchaseDetail.Rows)
                {

                    //update stock;
                    mPurchaseDetail.PURCHASE_MASTER_ID = mPurchaseMaster.PURCHASE_MASTER_ID;
                    mPurchaseDetail.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                    mPurchaseDetail.SKU_ID = int.Parse(dr["SKU_ID"].ToString());
                    mPurchaseDetail.BATCH_NO = dr["BATCH_NO"].ToString();
                    mPurchaseDetail.PRICE = decimal.Parse(dr["PRICE"].ToString());
                    mPurchaseDetail.QUANTITY = int.Parse(dr["Total_Unit"].ToString());
                    mPurchaseDetail.FREE_SKU = int.Parse(dr["FREE_SKU"].ToString());
                    mPurchaseDetail.AMOUNT = decimal.Parse(dr["AMOUNT"].ToString());
                    mPurchaseDetail.TDAMAGE = int.Parse(dr["TDAMAGE"].ToString());
                    mPurchaseDetail.TYPE_ID = mPurchaseMaster.TYPE_ID;
                    mPurchaseDetail.TIME_STAMP = p_DOCUMENT_DATE;
                    mPurchaseDetail.FMR = decimal.Parse(dr["FMR"].ToString());
                    mPurchaseDetail.MR = decimal.Parse(dr["MR"].ToString());
                    mPurchaseDetail.PUR_DISCOUNT = decimal.Parse(dr["PUR_DISCOUNT"].ToString());

                    mPurchaseDetail.GST_AMOUNT = decimal.Parse(dr["GST_AMOUNT"].ToString());
                    mPurchaseDetail.TST_AMOUNT = decimal.Parse(dr["TST_AMOUNT"].ToString());
                    mPurchaseDetail.GST_RATE = decimal.Parse(dr["GST_RATE"].ToString());

                    mPurchaseDetail.ExecuteQuery();

                    UspProcessStockRegister mStockUpdate = new UspProcessStockRegister();
                    mStockUpdate.Connection = mConnection;
                    mStockUpdate.Transaction = mTransaction;
                    mStockUpdate.PRINCIPAL_ID = p_Principal;
                    mStockUpdate.TYPE_ID = mPurchaseMaster.TYPE_ID;
                    mStockUpdate.DISTRIBUTOR_ID = mPurchaseMaster.DISTRIBUTOR_ID;
                    mStockUpdate.STOCK_DATE = mPurchaseMaster.DOCUMENT_DATE;
                    mStockUpdate.SKU_ID = mPurchaseDetail.SKU_ID;
                    mStockUpdate.STOCK_QTY = mPurchaseDetail.QUANTITY;
                    mStockUpdate.FREE_QTY = mPurchaseDetail.FREE_SKU;
                    mStockUpdate.BATCHNO = mPurchaseDetail.BATCH_NO;
                    mStockUpdate.ExecuteQuery();
                }


                #region Mapped Acount Selection

                CustomerDataController cd = new CustomerDataController();
                string p_Voucher_No = "";
                string CodeFileName = "";
                int CodeFileType = 0;
                DataTable dtMappSetting = cd.SelectMappingSetting(Constants.IntNullValue, Constants.IntNullValue);

                if (dtMappSetting != null || dtMappSetting.Rows.Count > 0)
                {
                    CodeFileName = dtMappSetting.Rows[0]["CODE_FILE"].ToString();
                    Configuration.GetAppMapping(CodeFileName);
                    CodeFileType = int.Parse(dtMappSetting.Rows[0]["CODE_TYPE"].ToString());
                }


                long p_PrincipalAccount_ID = 88;    //2002080001	Payable to (Principal Wise)
                string p_PrincipalAccount_Name = "";
                if (mPurchaseMaster.TYPE_ID == 2 || mPurchaseMaster.TYPE_ID == 3 || mPurchaseMaster.TYPE_ID == 4 ||
                    mPurchaseMaster.TYPE_ID == 5 || mPurchaseMaster.TYPE_ID == 6 || mPurchaseMaster.TYPE_ID == 8 ||
                    mPurchaseMaster.TYPE_ID == 9 || mPurchaseMaster.TYPE_ID == 10)
                {
                    DataTable dtAccount = cd.SelectAccountHeadMapping(1, Constants.IntNullValue, p_Principal, Constants.LongNullValue, Constants.IntNullValue);
                    if (dtAccount != null && dtAccount.Rows.Count > 0)
                    {
                        p_PrincipalAccount_ID = long.Parse(dtAccount.Rows[0]["Account_head_ID"].ToString());
                        p_PrincipalAccount_Name = dtAccount.Rows[0]["ACCOUNT_NAME"].ToString();

                    }
                }
                #endregion

                #region GL Voucher
                LedgerController LController = new LedgerController();
                string VoucherNo = LController.SelectMaxVoucherId(Constants.Journal_Voucher, p_DISTRIBUTOR_ID, DateTime.Now, mTransaction, mConnection);
                p_Voucher_No = VoucherNo;
                if (mPurchaseMaster.TYPE_ID == 2)// Purchase
                {
                    #region Purchases
                    string Remarks = "Default Purchase Voucher / Document # " + p_ORDER_NUMBER;
                    string Remarks2 = "Default Purchase Voucher";
                    string DocumentType = "Purchase";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, p_Principal, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, p_Principal, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), mPurchaseMaster.TOTAL_AMOUNT, 0, "Stock in Hand " + Remarks2, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, p_Principal, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, 0, mPurchaseMaster.TOTAL_AMOUNT, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, 897, mPurchaseMaster.TOTAL_AMOUNT, 0, "Purchases " + Remarks2, mTransaction, mConnection);
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, 0, mPurchaseMaster.TOTAL_AMOUNT, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 3)  // Purchase Return
                {
                    #region Purchase Return
                    string Remarks = "Default Purchase Return Voucher / Document # " + p_ORDER_NUMBER;
                    string Remarks2 = "Default Purchase Return Voucher";
                    string DocumentType = "Purchase Return";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, p_Principal, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, p_Principal, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), 0, mPurchaseMaster.TOTAL_AMOUNT, "Stock in Hand " + Remarks2, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, p_Principal, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, 897, 0, mPurchaseMaster.TOTAL_AMOUNT, "Purchases " + Remarks2, mTransaction, mConnection);
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 4)  // Transfer IN
                {
                    #region Transfer In
                    string Remarks = "Default Transfer In Voucher";
                    string DocumentType = "Transfer IN";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, p_Principal, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, p_Principal, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), mPurchaseMaster.TOTAL_AMOUNT, 0, "Stock in Hand " + Remarks, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, p_Principal, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.TransferInAccount), 0, mPurchaseMaster.TOTAL_AMOUNT, p_PrincipalAccount_Name + " " + Remarks, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 5)  // Transfer OUT
                {
                    #region Transfer Out
                    string Remarks = "Default Transfer Out Voucher";
                    string DocumentType = "Transfer Out";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, p_Principal, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, p_Principal, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.TransferOutAccount), mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, p_Principal, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), 0, mPurchaseMaster.TOTAL_AMOUNT, "Stock in Hand " + Remarks, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 6)  // Damage
                {
                    #region Damage
                    string Remarks = "Default Stock Damage Voucher / Document # " + mPurchaseMaster.PURCHASE_MASTER_ID;
                    string Remarks2 = "Default Stock Damage Voucher";
                    string DocumentType = "Stock Damage";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, p_Principal, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, p_Principal, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), 0, mPurchaseMaster.TOTAL_AMOUNT, "Stock In Hand " + Remarks2, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, p_Principal, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, 897, 0, mPurchaseMaster.TOTAL_AMOUNT, "Purchases " + Remarks2, mTransaction, mConnection);
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, 843, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 7) // Opening Stock
                {
                    #region Opening Stock
                    string Remarks = "Default Opening Stock Voucher";
                    string DocumentType = "Opening Stock";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, 0, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), mPurchaseMaster.TOTAL_AMOUNT, 0, "Stock In Hand " + Remarks, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.OpeningStock), 0, mPurchaseMaster.TOTAL_AMOUNT, "Opening at 31/8/19 " + Remarks, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp

                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 10) // Damage claimable
                {
                    #region Damage Claimable
                    string Remarks = "Default Stock Damage(Claimable) Voucher / Document # " + mPurchaseMaster.PURCHASE_MASTER_ID;
                    string Remarks2 = "Default Stock Damage(Claimable) Voucher";
                    string DocumentType = "Stock Damage(Claimable)";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, p_Principal, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, p_Principal, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), 0, mPurchaseMaster.TOTAL_AMOUNT, "Stock In Hand " + Remarks2, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, p_Principal, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, 897, 0, mPurchaseMaster.TOTAL_AMOUNT, "Purchases " + Remarks2, mTransaction, mConnection);
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, mPurchaseMaster.PRINCIPAL_ID, Constants.Journal_Voucher, VoucherNo, 845, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 8)  // Short
                {
                    #region Short
                    string Remarks = "Default Stock Short Voucher / Document # " + mPurchaseMaster.PURCHASE_MASTER_ID;
                    string Remarks2 = "Default Stock Short Voucher";
                    string DocumentType = "Stock Short";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, 0, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), 0, mPurchaseMaster.TOTAL_AMOUNT, "Stock In Hand " + Remarks2, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, 901, 0, mPurchaseMaster.TOTAL_AMOUNT, "Sales (All Principle) " + Remarks2, mTransaction, mConnection);
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, 898, mPurchaseMaster.TOTAL_AMOUNT, 0, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                    }
                    #endregion
                }
                else if (mPurchaseMaster.TYPE_ID == 9)  // Excess
                {
                    #region Excess
                    string Remarks = "Default Stock Excess Voucher / Document # " + mPurchaseMaster.PURCHASE_MASTER_ID;
                    string Remarks2 = "Default Stock Excess Voucher";
                    string DocumentType = "Stock Excess";
                    if (LController.PostingGLMaster(mPurchaseMaster.DISTRIBUTOR_ID, 0, VoucherNo, Constants.Journal_Voucher, mPurchaseMaster.DOCUMENT_DATE, mPurchaseMaster.TYPE_ID, Convert.ToString(mPurchaseMaster.PURCHASE_MASTER_ID), Remarks, p_UserId, DocumentType, mPurchaseMaster.PURCHASE_MASTER_ID, mPurchaseMaster.TYPE_ID, mTransaction, mConnection))
                    {
                        if (CodeFileType == 1)
                        {
                            // For Atlas Equipment
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, long.Parse(Configuration.PurchaseAccount), mPurchaseMaster.TOTAL_AMOUNT, 0, "Stock In Hand " + Remarks2, mTransaction, mConnection);
                            LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, p_PrincipalAccount_ID, 0, mPurchaseMaster.TOTAL_AMOUNT, p_PrincipalAccount_Name + " " + Remarks2, mTransaction, mConnection);
                        }
                        else
                        {
                            // For Food Corp
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, 897, mPurchaseMaster.TOTAL_AMOUNT, 0, "Purchases " + Remarks2, mTransaction, mConnection);
                            //LController.PostingGLDetail(p_DISTRIBUTOR_ID, 0, Constants.Journal_Voucher, VoucherNo, 900, 0, mPurchaseMaster.TOTAL_AMOUNT, "Unadjusted Credit Balance - Purchase " + Remarks2, mTransaction, mConnection);
                        }
                    }
                    #endregion
                }


                #endregion


                mTransaction.Commit();
                return true;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                mTransaction.Rollback();
                return false;
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
        /// Posts Pending Purchase, TranferOut, Purchase Return, TranferIn And Damage Document
        /// </summary>
        /// <param name="p_PURCHASE_MASTER_ID">Purchase</param>
        /// <param name="p_Type_Id">Type</param>
        /// <param name="p_Distributor_Id">Location</param>
        /// <param name="p_Posting">Posting</param>
        /// <returns>True On Success And False On Failure</returns>
        public bool PostPendingDocument(long p_PURCHASE_MASTER_ID,int p_Type_Id,int p_Distributor_Id,int p_Posting)
        {
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spUpdatePURCHASE_MASTER mPurchaseMaster = new spUpdatePURCHASE_MASTER();
                mPurchaseMaster.Connection = mConnection;
                mPurchaseMaster.PURCHASE_MASTER_ID = p_PURCHASE_MASTER_ID;
                mPurchaseMaster.DISTRIBUTOR_ID = p_Distributor_Id;
                mPurchaseMaster.TYPE_ID = p_Type_Id;  
                mPurchaseMaster.POSTING = p_Posting;
                mPurchaseMaster.ExecuteQuery();
                return true;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return false;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }

        }



        public DataTable SelectPurchaseOrderDocumentNo(long p_PURCHASE_ORDER_ID, int p_DISTRIBUTOR_ID, int p_TYPE_ID, int saleOrderID)
        {
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectPURCHASE_ORDER mPurchaseMaster = new spSelectPURCHASE_ORDER();
                mPurchaseMaster.Connection = mConnection;
                //mPurchaseMaster.PURCHASE_ORDER_ID = p_PURCHASE_ORDER_ID;
                //mPurchaseMaster.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                //mPurchaseMaster.TYPE_ID = p_TYPE_ID;
                mPurchaseMaster.SALE_ORDER_ID = saleOrderID;
                DataTable dt = mPurchaseMaster.ExecuteTable();
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

        public DataTable SelectPurchaseOrderDocumentNo2(long p_PURCHASE_ORDER_ID, int p_DISTRIBUTOR_ID, int p_TYPE_ID, int saleInvoiceID)
        { // by safdar 
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectPURCHASE_ORDER3 mPurchaseMaster = new spSelectPURCHASE_ORDER3();
                mPurchaseMaster.Connection = mConnection;
                //mPurchaseMaster.PURCHASE_ORDER_ID = p_PURCHASE_ORDER_ID;
                //mPurchaseMaster.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                //mPurchaseMaster.TYPE_ID = p_TYPE_ID;
                mPurchaseMaster.DOCUMENT_DATE = Constants.DateNullValue;
                mPurchaseMaster.SALE_INVOICE_ID = saleInvoiceID;
                DataTable dt = mPurchaseMaster.ExecuteTable();
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

        public DataTable SelectPurchaseOrderDocumentNo(long p_PURCHASE_ORDER_ID, int p_DISTRIBUTOR_ID, int p_TYPE_ID, DateTime p_DOCUMENT_DATE)
        {
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
               
                spSelectPURCHASE_ORDER mPurchaseMaster = new spSelectPURCHASE_ORDER();
                mPurchaseMaster.Connection = mConnection;
               
                mPurchaseMaster.DOCUMENT_DATE = p_DOCUMENT_DATE;
                DataTable dt = mPurchaseMaster.ExecuteTable();
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

        public DataTable SelectPurchaseOrderDocumentNo2(int p_SALE_INVOICE_ID, DateTime p_DOCUMENT_DATE)
        {
            // by safdar to use in view load pass form
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                // Origional is spSelectPURCHASE_ORDER ..by safdar .. from sale invoice master instead of sale order master
                spSelectPURCHASE_ORDER3 mPurchaseMaster = new spSelectPURCHASE_ORDER3();
                mPurchaseMaster.Connection = mConnection;
                mPurchaseMaster.SALE_INVOICE_ID = p_SALE_INVOICE_ID;
                mPurchaseMaster.DOCUMENT_DATE = p_DOCUMENT_DATE;
                DataTable dt = mPurchaseMaster.ExecuteTable();
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
        public DataTable SelectPurchaseOrderDocumentNo4(int UserID, DateTime p_DOCUMENT_DATE)
        {
            // by safdar to use in view load pass form
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                // Origional is spSelectPURCHASE_ORDER ..by safdar .. from sale invoice master instead of sale order master
                spSelectPURCHASE_ORDER4 mPurchaseMaster = new spSelectPURCHASE_ORDER4();
                mPurchaseMaster.Connection = mConnection;
                mPurchaseMaster.SALE_INVOICE_ID = UserID;
                mPurchaseMaster.DOCUMENT_DATE = p_DOCUMENT_DATE;
                DataTable dt = mPurchaseMaster.ExecuteTable();
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

        public DataTable SelectPurchaseOrderDetail(long p_SALE_ORDER_ID)
        {
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectPURCHASE_ORDER_DETAIL mPurchaseDetail = new spSelectPURCHASE_ORDER_DETAIL();
                mPurchaseDetail.Connection = mConnection;
                mPurchaseDetail.SALE_ORDER_ID = p_SALE_ORDER_ID;
                //mPurchaseDetail.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                DataTable dt = mPurchaseDetail.ExecuteTable();
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

        public DataTable SelectPurchaseOrderDetail2(int p_SALE_INVOICE_ID)
        {// by safdar to use in load pass 
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                // Origional was spSelectPURCHASE_ORDER_DETAIL
                spSelectPURCHASE_INVOICE_DETAIL mPurchaseDetail = new spSelectPURCHASE_INVOICE_DETAIL();
                mPurchaseDetail.Connection = mConnection;
                mPurchaseDetail.SALE_INVOICE_ID = p_SALE_INVOICE_ID;
                //mPurchaseDetail.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                DataTable dt = mPurchaseDetail.ExecuteTable();
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


        public bool UpdatePurchaseOrder(long p_PURCHASE_ORDER_ID, int p_TYPE_ID)
        {
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                //mTransaction = ProviderFactory.GetTransaction(mConnection);
                //spUpdatePURCHASE_ORDER mPurchaseMaster = new spUpdatePURCHASE_ORDER();
                //mPurchaseMaster.Connection = mConnection;
                //mPurchaseMaster.Transaction = mTransaction;
                //mPurchaseMaster.PURCHASE_ORDER_ID = p_PURCHASE_ORDER_ID;
                //mPurchaseMaster.TYPE_ID = p_TYPE_ID;
                //mPurchaseMaster.ExecuteQuery();

                //mTransaction.Commit();
                return true;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                mTransaction.Rollback();
                return false;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }

        }

        public bool UpdateLoadPass(long p_Sale_invoice_ID)
        {
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                mTransaction = ProviderFactory.GetTransaction(mConnection);
                spDeleteLoadPass mPurchaseMaster = new spDeleteLoadPass();
                mPurchaseMaster.Connection = mConnection;
                mPurchaseMaster.Transaction = mTransaction;
                mPurchaseMaster.SALE_INVOICE_ID = p_Sale_invoice_ID;
                
                mPurchaseMaster.ExecuteQuery();

                mTransaction.Commit();
                return true;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                mTransaction.Rollback();
                return false;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }

        }


        public DataTable selectLoadPassDocumentNo(int p_Distributor_id,int p_TOWN_ID, long p_AREA_ID, int p_PRINCIPAL_ID, int p_ORDERBOOKER_ID, int p_DELIVERYMAN_ID,DateTime p_DOCUMENT_DATE)
        {
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectLoadPassDocumentNo mPurchaseDetail = new spSelectLoadPassDocumentNo();
                mPurchaseDetail.Connection = mConnection;
                mPurchaseDetail.DISTRIBUTOR_ID = p_Distributor_id;
                mPurchaseDetail.TOWN_ID = p_TOWN_ID;
                mPurchaseDetail.AREA_ID = p_AREA_ID;
                mPurchaseDetail.PRINCIPAL_ID = p_PRINCIPAL_ID;
                mPurchaseDetail.ORDERBOOKER_ID = p_ORDERBOOKER_ID;
                mPurchaseDetail.DELIVERYMAN_ID = p_DELIVERYMAN_ID;
                mPurchaseDetail.DOCUMENT_DATE = p_DOCUMENT_DATE;
                //mPurchaseDetail.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                DataTable dt = mPurchaseDetail.ExecuteTable();
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




        public bool PostingGLMaster(int p_Distributor_id, int p_PRINCIPAL_ID, string p_VOUCHER_NO, int p_VOUCHER_TYPE_ID, DateTime p_VOUCHER_DATE, int p_PAYMENT_MODE, string p_PayeesName, string p_Remarks, int p_UserId, string pDocumentType, IDbTransaction mTransaction, IDbConnection mConnection)
        {
            try
            {
                spInsertGL_MASTER mISom = new spInsertGL_MASTER();
                mISom.Connection = mConnection;
                mISom.Transaction = mTransaction;

                //------------Insert into GL Master----------

                mISom.DISTRIBUTOR_ID = p_Distributor_id;
                mISom.PRINCIPAL_ID = p_PRINCIPAL_ID;
                mISom.VOUCHER_TYPE_ID = p_VOUCHER_TYPE_ID;
                mISom.VOUCHER_NO = p_VOUCHER_NO;
                mISom.VOUCHER_DATE = p_VOUCHER_DATE;
                mISom.PAYMENT_MODE = p_PAYMENT_MODE;
                mISom.CHEQUE_DATE = Constants.DateNullValue;
                mISom.CHEQUE_NO = null;
                mISom.PAYEES_NAME = p_PayeesName;
                mISom.REMARKS = p_Remarks;
                mISom.TIME_STAMP = DateTime.Now;
                mISom.USER_ID = p_UserId;
                mISom.Slip_No = pDocumentType;
                mISom.IS_POSTED = true;
                mISom.IS_DELETED = false;
                mISom.DUE_DATE = Constants.DateNullValue;
                mISom.ExecuteQuery();

                return true;

            }

            catch (Exception exp)
            {

                //  ExceptionPublisher.PublishException(exp);
                return false;
            }

        }



        public bool PostingGLMaster(int p_Distributor_id, int p_PRINCIPAL_ID, string p_VOUCHER_NO, int p_VOUCHER_TYPE_ID, DateTime p_VOUCHER_DATE, int p_PAYMENT_MODE, string p_PayeesName, string p_Remarks, int p_UserId, string pDocumentType, long p_Document_ID, int p_Document_Type_ID, IDbTransaction mTransaction, IDbConnection mConnection)
        {
            try
            {
                spInsertGL_MASTER mISom = new spInsertGL_MASTER();
                mISom.Connection = mConnection;
                mISom.Transaction = mTransaction;

                //------------Insert into GL Master----------

                mISom.DISTRIBUTOR_ID = p_Distributor_id;
                mISom.PRINCIPAL_ID = p_PRINCIPAL_ID;
                mISom.VOUCHER_TYPE_ID = p_VOUCHER_TYPE_ID;
                mISom.VOUCHER_NO = p_VOUCHER_NO;
                mISom.VOUCHER_DATE = p_VOUCHER_DATE;
                mISom.PAYMENT_MODE = p_PAYMENT_MODE;
                mISom.CHEQUE_DATE = Constants.DateNullValue;
                mISom.CHEQUE_NO = null;
                mISom.PAYEES_NAME = p_PayeesName;
                mISom.REMARKS = p_Remarks;
                mISom.TIME_STAMP = DateTime.Now;
                mISom.USER_ID = p_UserId;
                mISom.Slip_No = pDocumentType;
                mISom.IS_POSTED = true;
                mISom.IS_DELETED = false;
                mISom.DUE_DATE = Constants.DateNullValue;
                mISom.INVOICE_ID = p_Document_ID;
                mISom.INVOICE_TYPE = p_Document_Type_ID;
                mISom.ExecuteQuery();

                return true;

            }

            catch (Exception exp)
            {

                //  ExceptionPublisher.PublishException(exp);
                return false;
            }

        }



        public void PostingGLDetail(int pDistributorId, int pPrincpald, int pVoucherType, string pVoucherNo, long pAccountId, decimal pDebit, decimal pCredit, string pRemarks, IDbTransaction mTransaction, IDbConnection mConnection)
        {

            try
            {
                spInsertGL_DETAIL mISom2 = new spInsertGL_DETAIL();
                mISom2.Connection = mConnection;
                mISom2.Transaction = mTransaction;

                mISom2.DISTRIBUTOR_ID = pDistributorId;
                mISom2.PRINCIPAL_ID = pPrincpald;
                mISom2.VOUCHER_TYPE_ID = pVoucherType;
                mISom2.VOUCHER_NO = pVoucherNo;
                mISom2.ACCOUNT_HEAD_ID = pAccountId;
                mISom2.DEBIT = pDebit;
                mISom2.CREDIT = pCredit;
                mISom2.GL_REMARKS = pRemarks;
                mISom2.IS_DELETED = false;

                mISom2.ExecuteQuery();

            }

            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
            }
        }

        #endregion

        #endregion
    }
}
