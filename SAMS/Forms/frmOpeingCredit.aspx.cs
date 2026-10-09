using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMSCommon.Classes;
using SAMSBusinessLayer.Classes;

/// <summary>
/// Form To Add Opening Credit
/// </summary>
public partial class Forms_frmOpeingCredit : System.Web.UI.Page
{
    /// <summary>
    /// Page_Load Function Populates All Combos, ListBox And Grid On The Page
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    DataControl dc = new DataControl();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            DateTime pOrderDate = DateTime.Parse(this.Session["CurrentWorkDate"].ToString());
            txtFromdate.Text = pOrderDate.ToString("dd-MMM-yyyy");
            this.LoadPrincipal();
            this.LoadDistributor();
            this.LoadDeliveryman();
           
            this.LoadOrderBooker();
            this.LoadData();
           
            this.LoadOpeningCredit();
        
        }
    }

    /// <summary>
    /// Loads Locations To Location Combo
    /// </summary>
    private void LoadDistributor()
    {
        DistributorController DController = new DistributorController();
        DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.drpDistributor, dt, 0, 2, true);
    }
    
    /// <summary>
    /// Loads Markets To Market Combo
    /// </summary>
    

    
    /// <summary>
    /// Loads Customers To Customer ListBox
    /// </summary>
    private void LoadData()
    {
        if (drpDistributor.Items.Count > 0 )
        {
            CustomerDataController mController = new CustomerDataController();
            DataTable dt = mController.SelectPrincipalCustomer(int.Parse(drpDistributor.SelectedValue.ToString()), Constants.IntNullValue, Constants.IntNullValue, int.Parse(DrpPrincipal.SelectedValue.ToString()),1);
            clsWebFormUtil.FillListBox(this.ListCustomer, dt, "CUSTOMER_DETAIL", "CUSTOMER_DETAIL2", true);
            clsWebFormUtil.FillDropDownList(this.DrpCustomer, dt, "CUSTOMER_ID", "CUSTOMER_DETAIL2", true);
            this.Session.Add("dt", dt);
        }
    }
    private void LoadDiscountData(int p_Distributor_ID, long p_Sale_invoice_id)
    {
        cleardiscount();
        OrderEntryController ord = new OrderEntryController();
        DataTable dtInvoice = ord.SelectInvoiceDiscount(p_Distributor_ID, p_Sale_invoice_id);
        if (dtInvoice != null)
        {
            if (dtInvoice.Rows.Count > 0)
            {
                txtWholeSaleDiscount.Text = dtInvoice.Rows[0]["WHOLE_SALE_DISCOUNT"].ToString();
                txtBrd.Text = dtInvoice.Rows[0]["BRD"].ToString();
                txtTradeOffer.Text = dtInvoice.Rows[0]["TRADE_OFFER"].ToString();
                txtOtherDiscount.Text = dtInvoice.Rows[0]["OTHER_DISCOUNT"].ToString();
                txtIncentive.Text = dtInvoice.Rows[0]["INCENTIVE"].ToString();
                txtRental.Text = dtInvoice.Rows[0]["RENTAL"].ToString();
                txtDisplay.Text = dtInvoice.Rows[0]["DISPLAY"].ToString();
                
            }
        }

    }
    private void cleardiscount()
    {
        txtWholeSaleDiscount.Text = "";
        txtBrd.Text = "";
        txtTradeOffer.Text = "";
        txtOtherDiscount.Text = "";
        txtIncentive.Text = "";
        txtRental.Text = "";
        txtDisplay.Text = "";

    }
    /// <summary>
    /// Resets Form Controls
    /// </summary>
    private void ClearAll()
    {
        txtChequeNo.Text = "";
        txtOutletCode.Text = "";
        txtAmount.Text = "";
        txtOutletName.Text = "";
        txtRemarks.Text = "";
        btnSave.Text = "Save";
        txtOutletCode.Focus();
        //DrpRoute.Enabled = true;
       // DrpRoute.SelectedIndex = 0;
        LoadData();
        DrpDeliveryMan.Enabled = true;
    }

    private void LoadPrincipal()
    {
        SKUPriceDetailController PController = new SKUPriceDetailController();
        DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), Constants.IntNullValue, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        clsWebFormUtil.FillDropDownList(this.DrpPrincipal, m_dt, 0, 1, true);
    }
  
    private void LoadDeliveryman()
    {
        if (drpDistributor.Items.Count > 0 )
        {
            SaleForceController mDController = new SaleForceController();
            DataTable m_dt = mDController.SelectSaleForceAssignedArea(int.Parse(drpDistributor.SelectedValue.ToString()), Constants.IntNullValue, int.Parse(this.Session["CompanyId"].ToString()));
            clsWebFormUtil.FillDropDownList(this.DrpDeliveryMan, m_dt, 0, 3, true);
        }
        else
        {
            DrpDeliveryMan.Items.Clear();
        }
    }
    
    private void LoadOpeningCredit()
    {
        if (drpDistributor.Items.Count > 0 && DrpDeliveryMan .Items .Count >0 && DrpOrderBooker.Items.Count >0)
        {
            CustomerDataController cdc = new CustomerDataController();
            DataTable dt = cdc.SelectOpeningCredit2(int.Parse(drpDistributor.SelectedValue.ToString()),DateTime.Parse(txtFromdate.Text), int.Parse( DrpDeliveryMan .SelectedValue), int.Parse(DrpOrderBooker.SelectedValue));
            GrdOrder.DataSource = dt;
            GrdOrder.DataBind();
        }
        else
        {
            GrdOrder.DataSource = null;
            GrdOrder.DataBind();

        }
    }
        
    protected void drpDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadDeliveryman();
        
        LoadOrderBooker();
        this.LoadData();
      
        this.LoadOpeningCredit();
        btnSave.Text = "Save";
    }
    
    protected void DrpPrincipal_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadData();
    }
    
    private bool IsBillBookNoExist(int p_Type)
    {
        bool flag = false;
        if (txtChequeNo.Text.Trim().Length > 0)
        {
            OrderEntryController OEC = new OrderEntryController();
            DataTable dtBillBookNo = OEC.SelectBillBookNo(Convert.ToInt32(drpDistributor.SelectedValue), txtChequeNo.Text, p_Type);
            if (dtBillBookNo.Rows.Count > 0)
            {
                flag = true;
            }
        }

        return flag;
    }

    protected void GrdOrder_RowEditing(object sender, GridViewEditEventArgs e)
    {
        DrpCreditType.SelectedValue = GrdOrder.Rows[e.NewEditIndex].Cells[7].Text;
        DrpPrincipal.SelectedValue = GrdOrder.Rows[e.NewEditIndex].Cells[1].Text;
        


        txtFromdate.Text = Convert.ToDateTime(GrdOrder.Rows[e.NewEditIndex].Cells[9].Text).ToString("dd-MMM-yyyy");
        txtOutletCode.Text = GrdOrder.Rows[e.NewEditIndex].Cells[8].Text;
        txtOutletName.Text = GrdOrder.Rows[e.NewEditIndex].Cells[3].Text;
        txtChequeNo.Text = GrdOrder.Rows[e.NewEditIndex].Cells[5].Text;
        txtAmount.Text = GrdOrder.Rows[e.NewEditIndex].Cells[6].Text;
        btnSave.Text = "Update";

        try
        {
            DrpDeliveryMan.SelectedValue = GrdOrder.Rows[e.NewEditIndex].Cells[12].Text;
        }
        catch (Exception)
        {
        }

        
        LoadOrderBooker();
        try
        {
            DrpOrderBooker.SelectedValue = GrdOrder.Rows[e.NewEditIndex].Cells[13].Text;
         //   DrpRoute.SelectedValue = GrdOrder.Rows[e.NewEditIndex].Cells[11].Text;
        }
        catch (Exception)
        {
        }
       

        hfLegendID.Value = GrdOrder.Rows[e.NewEditIndex].Cells[7].Text;
        hfPrincipalID.Value = GrdOrder.Rows[e.NewEditIndex].Cells[1].Text;
        hfCustomerID.Value = GrdOrder.Rows[e.NewEditIndex].Cells[0].Text;
        hfSaleInvoiceID.Value = GrdOrder.Rows[e.NewEditIndex].Cells[10].Text;
        this.LoadData();
        
     //   ImgBntFromCalc.Enabled = true;
     //   DrpRoute.Enabled = false;
        DrpCustomer.SelectedValue = GrdOrder.Rows[e.NewEditIndex].Cells[0].Text;
        
        DrpDeliveryMan.Enabled = false;
        LoadDiscountData(int.Parse(drpDistributor.SelectedValue), long.Parse(hfSaleInvoiceID.Value));
    }

    protected void GrdOrder_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        hfLegendID.Value = GrdOrder.Rows[e.RowIndex ].Cells[7].Text;
        hfPrincipalID.Value = GrdOrder.Rows[e.RowIndex].Cells[1].Text;
        hfCustomerID.Value = GrdOrder.Rows[e.RowIndex].Cells[0].Text;
        hfSaleInvoiceID.Value = GrdOrder.Rows[e.RowIndex].Cells[10].Text;

        LedgerController LedgerCtl = new LedgerController();
        if (LedgerCtl.DeleteOpeningCredit(Convert.ToInt32(drpDistributor.SelectedValue), Convert.ToInt32(hfPrincipalID.Value), Convert.ToInt32(hfLegendID.Value), Convert.ToDateTime(txtFromdate.Text), Convert.ToInt32(hfCustomerID.Value), Convert.ToInt64(hfSaleInvoiceID.Value), Convert.ToInt32(this.Session["UserId"])))
        {
            this.ClearAll();
            this.LoadOpeningCredit();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Some error occured. Opening Credit not deleted.');", true);
        }

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

        if (decimal.Parse(dc.chkNull_0(txtAmount.Text)) < 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Please Enter Amount');", true);
            return;
        }

        LedgerController LedgerCtl = new LedgerController();
        CustomerDataController CDC = new CustomerDataController();
        DataControl DC = new DataControl();
        if (IsDayClosed())
        {
            UserController UserCtl = new UserController();

            UserCtl.InsertUserLogoutTime(Convert.ToInt32(Session["User_Log_ID"]), Convert.ToInt32(Session["UserID"]));
            this.Session.Clear();
            System.Web.Security.FormsAuthentication.SignOut();
            Response.Redirect("../Login.aspx");
        }
        else
        {

            if (btnSave.Text == "Update")
            {
                LedgerCtl.DeleteOpeningCredit(Convert.ToInt32(drpDistributor.SelectedValue), Convert.ToInt32(hfPrincipalID.Value), Convert.ToInt32(hfLegendID.Value), Convert.ToDateTime(txtFromdate.Text), Convert.ToInt32(hfCustomerID.Value), Convert.ToInt64(hfSaleInvoiceID.Value), Convert.ToInt32(this.Session["UserId"]));
            }

            if (!IsBillBookNoExist(1))
            {
                DataTable dtCustomer = (DataTable)this.Session["dt"];
                DataRow[] foundRows = dtCustomer.Select("CUSTOMER_CODE  = '" + txtOutletCode.Text.Trim() + "'");
                if (foundRows.Length > 0)
                {
                    //DataTable dt = CDC.SelectCustomerCreditBalance(long.Parse(foundRows[0]["CUSTOMER_ID"].ToString()), int.Parse(DrpPrincipal.SelectedValue), int.Parse(drpDistributor.SelectedValue), Constants.Credit_Order_Id);
                    decimal NetAmount = decimal.Parse(DC.chkNull_0(txtAmount.Text));


                    // credit limit restriction removed on customer requirment vide MOM sr No 01 conducted by Nehal Yousaf  
                    //if (decimal.Parse(DC.chkNull_0(dt.Rows[0][0].ToString())) <= NetAmount)
                    //{
                    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Customer Credit Limit/Advance Amount is " + DC.chkNull_0(dt.Rows[0][0].ToString()) + "');", true);
                    //   return;
                    //}


                    CustomerDataController mController = new CustomerDataController();
                    DataTable dt1 = mController.SelectPrincipalCustomer(int.Parse(drpDistributor.SelectedValue.ToString()), Constants .IntNullValue , Constants.IntNullValue, Constants .IntNullValue , 2,int.Parse(foundRows[0]["CUSTOMER_ID"].ToString()));
                    var Area_ID = dt1.Rows[0]["AREA_ID"].ToString();

                    LedgerCtl.OpeningCredit(int.Parse(drpDistributor.SelectedValue.ToString()), txtChequeNo.Text.ToUpper(), int.Parse(foundRows[0]["TOWN_ID"].ToString()), int.Parse(Area_ID),
                    DateTime.Parse(txtFromdate.Text), int.Parse(DrpPrincipal.SelectedValue.ToString()), long.Parse(foundRows[0]["CUSTOMER_ID"].ToString()), long.Parse(foundRows[0]["CUSTOMER_ID"].ToString()),
                    int.Parse(DrpOrderBooker.SelectedValue), int.Parse(DrpDeliveryMan.SelectedValue.ToString()), decimal.Parse(txtAmount.Text), int.Parse(this.Session["UserId"].ToString()), int.Parse(DrpCreditType.SelectedValue.ToString())
                    ,Decimal.Parse(DC.chkNull_0(txtWholeSaleDiscount.Text)), Decimal.Parse(DC.chkNull_0(txtBrd.Text)), Decimal.Parse(DC.chkNull_0(txtTradeOffer.Text)), Decimal.Parse(DC.chkNull_0(txtOtherDiscount.Text)), Decimal.Parse(DC.chkNull_0(txtIncentive.Text)), Decimal.Parse(DC.chkNull_0(txtRental.Text)), Decimal.Parse(DC.chkNull_0(txtDisplay.Text)));
                    this.ClearAll();
                    this.LoadOpeningCredit();
                    this.cleardiscount();
                }
                ScriptManager.GetCurrent(Page).SetFocus(txtOutletCode);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('This Invoice No already exist,Kindly enter different Invoice No');", true);
            }
        }
    }
    
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        this.ClearAll();
    }

    private bool IsDayClosed()
    {
        bool flag = false;
        DistributorController DistrCtl = new DistributorController();
        DataTable dtDayClose = DistrCtl.MaxDayClose(Convert.ToInt32(drpDistributor.SelectedValue), 3);
        var dat = Convert.ToDateTime(Session["CurrentWorkDate"]);
        if (dat == Convert.ToDateTime(dtDayClose.Rows[0]["DayClose"]))
        {
            flag = false;
        }
        else
        {
            flag = true;
        }

        return flag;
    }
    protected void DrpCreditType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DrpCreditType.SelectedValue == 25.ToString())
        {
         // CalendarExtender1.Enabled = true;
          ImgBntFromCalc.Enabled = true;
  
        }
        else
        {
           // CalendarExtender1.Enabled = false;
            ImgBntFromCalc.Enabled = false;
        }
    }
    protected void DrpDeliveryMan_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        LoadOrderBooker();
        LoadData();

        LoadOpeningCredit();
    }
    
    private void LoadOrderBooker()
    {
        if (drpDistributor.Items.Count > 0 && DrpPrincipal.Items.Count > 0)
        {
            DrpOrderBooker.Items.Clear();
               SaleForceController mDController = new SaleForceController();
            DataTable m_dt = mDController.SelectSaleForceAssignedArea(Constants.SALES_FORCE_ORDERBOOKER, int.Parse(drpDistributor.SelectedValue.ToString()),Constants.IntNullValue, int.Parse(this.Session["CompanyId"].ToString()), Convert.ToInt32(DrpPrincipal.SelectedValue));
            clsWebFormUtil.FillDropDownList(this.DrpOrderBooker, m_dt, 0, 3, true);
        }
        else
        {
            DrpOrderBooker.Items.Clear();
        }
    }

    protected void DrpOrderBooker_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadOpeningCredit();
    }
}
