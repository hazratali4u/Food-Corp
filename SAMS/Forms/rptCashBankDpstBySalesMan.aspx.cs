using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMSBusinessLayer.Classes;
using SAMSCommon.Classes;    
using SAMSBusinessLayer.Reports;
using System.Collections.Generic;
/// <summary>
/// Form For Sale Person DSR Report
/// </summary>
public partial class Forms_rptCashBankDpstBySalesMan : System.Web.UI.Page
{


    /// <summary>
    /// Page_Load Function
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.LoadDistributor();
            this.LoadPrincipal();
        
            LoadOrderBooker();
            SAMSCommon.Classes.Configuration.SystemCurrentDateTime = (DateTime)this.Session["CurrentWorkDate"];
            txtStartDate.Text = SAMSCommon.Classes.Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
            txtEndDate.Text = SAMSCommon.Classes.Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
           
        }
    }

    /// <summary>
    /// Loads Principals To Principal Combo
    /// </summary>
    /// 


    private void LoadOrderBooker()
    {
        if (drpDistributor.Items.Count > 0 && DrpPrincipal.Items.Count > 0)
        {
            SaleForceController mDController = new SaleForceController();
            DataTable m_dt = mDController.SelectSaleForceAssignedArea(int.Parse(drpDistributor.SelectedValue.ToString()), Constants.IntNullValue, int.Parse(this.Session["CompanyId"].ToString()));
            clsWebFormUtil.FillListBox(this.ChbOrderBookerList, m_dt, 0, 3, true);
        }
        else
        {
            ChbOrderBookerList.Items.Clear();
        }
    }
    private void LoadPrincipal()
    {
        SKUPriceDetailController PController = new SKUPriceDetailController();
        DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), Constants.IntNullValue, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        DrpPrincipal.Items.Add(new ListItem("All",Constants.IntNullValue.ToString()));       
        clsWebFormUtil.FillDropDownList(this.DrpPrincipal, m_dt, 0, 1);
    }

    /// <summary>
    /// Loads Locations To Location Combo
    /// </summary>
    private void LoadDistributor()
    {
        DistributorController DController = new DistributorController();
        DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        drpDistributor.Items.Add(new ListItem("All", Constants.IntNullValue.ToString()));
        clsWebFormUtil.FillDropDownList(this.drpDistributor, dt, 0, 2);
    }
   

    /// <summary>
    /// Shows Sale Person DSR in PDF
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnViewPDF_Click(object sender, EventArgs e)
    {
        ShowReport(0);
    }

    /// <summary>
    /// Shows Sale Person DSR in Excel
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">EventArgs</param>
    protected void btnViewExcel_Click(object sender, EventArgs e)
    {
        ShowReport(1);
    }

    /// <summary>
    /// Gets Sale Person DSR And Shows Either in Excel or PDF
    /// </summary>
    /// <param name="p_ReportType">Type</param>
    private void ShowReport(int p_ReprotType)
    {
       
       
            DocumentPrintController DPrint = new DocumentPrintController();
            RptSaleController RptSaleCtl = new RptSaleController();
            DataTable dt = DPrint.SelectReportTitle(int.Parse(drpDistributor.SelectedValue.ToString()));
            DataSet ds = null;

             List <Int32 > OrderBookerList= new List<Int32> ();

            string OrderBooker="";
            string OrderBookerNAme = "";
            for (int i = 0; i < ChbOrderBookerList.Items.Count; i++)
            {
                if (ChbOrderBookerList.Items[i].Selected == true)
                {
                   // OrderBookerList.Add (ChbOrderBookerList .Items [i].Selected) 
                    OrderBooker = OrderBooker + ChbOrderBookerList.Items[i].Value.ToString() + ",";
                    OrderBookerNAme = OrderBookerNAme + ChbOrderBookerList.Items[i].Text + ",";
                }
            }
            var dc = new DataControl();
            ds = RptSaleCtl.getCashBankDepositOnSalesmenRpt(int.Parse(drpDistributor.SelectedValue.ToString()),int.Parse( DrpPrincipal .SelectedValue) ,
                DateTime.Parse(txtStartDate.Text + " 00:00:00"), DateTime.Parse(txtEndDate.Text + " 23:59:59"), int.Parse(this.Session["UserId"].ToString()), int.Parse(drpDepositType.SelectedValue), OrderBooker);

            var crpReport = new CrpCashBankDpstSalemenwise();


            crpReport.SetDataSource(ds);
            crpReport.Refresh();
            crpReport.SetParameterValue("Distributor_Name", drpDistributor.SelectedItem.Text);
            crpReport.SetParameterValue("FROM_DATE", DateTime.Parse(txtStartDate.Text));
            crpReport.SetParameterValue("TO_DATE", DateTime.Parse(txtEndDate.Text));
            crpReport.SetParameterValue("Principal",DrpPrincipal .SelectedItem .Text);
           // crpReport.SetParameterValue("Route", DrpRoute.SelectedItem.Text);
            crpReport.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());
            crpReport.SetParameterValue("OrderBookerName",OrderBookerNAme );

            this.Session.Add("CrpReport", crpReport);
            this.Session.Add("ReportType", p_ReprotType);
            string url = "'Default.aspx'";                                      
            string script = "<script language='JavaScript' type='text/javascript'> window.open(" + url + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
            Type cstype = this.GetType();
            ClientScriptManager cs = Page.ClientScript;
            cs.RegisterStartupScript(cstype, "OpenWindow", script);   
    }
    protected void DrpPrincipal_SelectedIndexChanged(object sender, EventArgs e)
    {
        ChbSelectAll.Checked = false;
       // this.LoadArea();
        this.LoadOrderBooker();

    }
    protected void drpDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
        ChbSelectAll.Checked = false;
        this.LoadPrincipal();
       // this.LoadArea();
        this.LoadOrderBooker();
    }
}
