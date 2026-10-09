<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true"
    CodeFile="frmSKUData.aspx.cs" Inherits="Forms_frmSKUData" Title="SAMS: SKU Information" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphPage" runat="Server">
    <div id="right_data">
        <div>
            <table width="100%">
                <tr>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <table>
                                    <tbody>
                                        <tr>
                                            <td align="left" colspan="4">
                                                <asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100px" align="left">
                                                <strong>
                                                    <asp:Label ID="Label1" runat="server" Width="100px" Text="SKU Principal"></asp:Label></strong>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddskuPrincipal" runat="server" Width="200px" AutoPostBack="True"
                                                    OnSelectedIndexChanged="ddskuPrincipal_SelectedIndexChanged" CssClass="DropList">
                                                </asp:DropDownList>
                                            </td>
                                            <td></td>
                                            <td align="left" rowspan="10"></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100px" align="left">
                                                <strong>
                                                    <asp:Label ID="Label2" runat="server" Width="100px" Text="SKU Division"></asp:Label></strong>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddskudivision" runat="server" Width="200px" AutoPostBack="True"
                                                    OnSelectedIndexChanged="ddskudivision_SelectedIndexChanged" CssClass="DropList">
                                                </asp:DropDownList>
                                            </td>
                                            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100px" align="left">
                                                <strong>
                                                    <asp:Label ID="Label3" runat="server" Width="100px" Text="SKU Category"></asp:Label></strong>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddskucategory" runat="server" Width="200px" AutoPostBack="True"
                                                    OnSelectedIndexChanged="ddskucategory_SelectedIndexChanged" CssClass="DropList">
                                                </asp:DropDownList>
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100px" align="left">
                                                <strong>
                                                    <asp:Label ID="Label4" runat="server" Width="100px" Text="SKU Brand"></asp:Label></strong>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddskuBrand" runat="server" Width="200px" AutoPostBack="True"
                                                    CssClass="DropList">
                                                </asp:DropDownList>
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="width: 100px">
                                                <strong>
                                                    <asp:Label ID="Label9" runat="server" Text="GST On"></asp:Label></strong>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="DrpSKUTaxType" runat="server" Width="200px" CssClass="DropList">
                                                    <asp:ListItem Value="T">Trade Price</asp:ListItem>
                                                    <asp:ListItem Value="R">Retail Price</asp:ListItem>
                                                    <asp:ListItem Value="E">Exempted</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100px" align="left">
                                                <strong>
                                                    <asp:Label ID="Label6" runat="server" Text="SKU Code"></asp:Label></strong>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtskucode" runat="server" Width="198px" CssClass="txtBox "></asp:TextBox>
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100px; height: 20px" align="left">
                                                <strong>
                                                    <asp:Label ID="Label7" runat="server" Text="SKU Name"></asp:Label></strong>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtskuname" runat="server" Width="198px" CssClass="txtBox "></asp:TextBox>
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100px" align="left">
                                                <strong>
                                                    <asp:Label ID="Label8" runat="server" Text="Pack Size"></asp:Label></strong>
                                            </td>
                                            <td style="width: 37px">
                                                <asp:TextBox ID="txtpacksize" runat="server" Width="198px" CssClass="txtBox "></asp:TextBox>
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100px" align="left">
                                                <strong>
                                                    <asp:Label ID="Label12" runat="server" Text="Unit In Case"></asp:Label></strong>
                                            </td>
                                            <td style="width: 37px">
                                                <asp:TextBox ID="txtunitincase" runat="server" Width="198px" CssClass="txtBox "></asp:TextBox>
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100px" align="left">
                                                <strong>
                                                    <asp:Label ID="lblweight" runat="server" Text="Weight"></asp:Label>
                                                </strong>
                                            </td>
                                            <td style="width: 37px">
                                                <asp:TextBox ID="txtweight" runat="server" CssClass="txtBox " Width="198px"></asp:TextBox>
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100px; height: 12px">
                                                <strong>
                                                    <asp:Label ID="lblUOM" runat="server" Text="UOM"></asp:Label>
                                                </strong>
                                            </td>
                                            <td style="width: 37px; height: 12px">
                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtunitincase"
                                                    FilterType="Numbers">
                                                </cc1:FilteredTextBoxExtender>
                                                <asp:DropDownList ID="DrpUOM" runat="server" Width="200px" CssClass="DropList">
                                                    <asp:ListItem Value="K">Kg</asp:ListItem>
                                                    <asp:ListItem Value="L">Ltr</asp:ListItem>
                                                    <asp:ListItem Value="G">Grm</asp:ListItem>
                                                    <asp:ListItem Value="M">Ml</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td></td>
                                            <td style="width: 37px; height: 12px"></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100px" align="left">
                                                <strong>
                                                    <asp:Label ID="Label5" runat="server" Text="FMR"></asp:Label>
                                                </strong>
                                            </td>
                                            <td style="width: 37px">
                                                <asp:TextBox ID="txtFMR" runat="server" CssClass="txtBox " Width="198px"></asp:TextBox>
                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                                    TargetControlID="txtFMR" ValidChars="0123456789." FilterType="Custom">
                                                </cc1:FilteredTextBoxExtender>
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100px" align="left">
                                                <strong>
                                                    <asp:Label ID="Label11" runat="server" Text="MR(Un.Loading)"></asp:Label>
                                                </strong>
                                            </td>
                                            <td style="width: 37px">
                                                <asp:TextBox ID="txtMR" runat="server" CssClass="txtBox " Width="198px"></asp:TextBox>
                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                                    TargetControlID="txtMR" ValidChars="0123456789." FilterType="Custom">
                                                </cc1:FilteredTextBoxExtender>
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100px" align="left">
                                                <strong>
                                                    <asp:Label ID="Label13" runat="server" Text="Pur. Discount"></asp:Label>
                                                </strong>
                                            </td>
                                            <td style="width: 37px">
                                                <asp:TextBox ID="txtPurchaseDiscount" runat="server" CssClass="txtBox " Width="198px"></asp:TextBox>
                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                                    TargetControlID="txtPurchaseDiscount" ValidChars="0123456789." FilterType="Custom">
                                                </cc1:FilteredTextBoxExtender>
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100px; height: 12px"></td>
                                            <td style="height: 12px" align="left" colspan="2">
                                                <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" Width="86px" Font-Size="8pt"
                                                    Text="Save" CssClass="Button" />
                                            </td>
                                            <td style="width: 37px; height: 12px" align="left"></td>
                                        </tr>
                                    </tbody>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:UpdateProgress ID="UpdateProgress5" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                            <ProgressTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" Width="26px" Height="23px" ImageUrl="~/App_Themes/Granite/Images/image003.gif"></asp:ImageButton>&nbsp; Loading....
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <table class="tblhead">
                        <tbody>
                            <tr>
                                <td style="color: White; font-weight: bold;">
                                    <asp:Label ID="Label10" runat="server" Width="153px" Text="Select Searching Type"></asp:Label>
                                </td>
                                <td style="width: 170px; height: 22px" align="left">
                                    <asp:DropDownList ID="ddSearchType" runat="server" Width="200px" CssClass="DropList">
                                        <asp:ListItem Value="SKU_code">All Records</asp:ListItem>
                                        <asp:ListItem Value="Principal">Principal</asp:ListItem>
                                        <asp:ListItem Value="Division">Division</asp:ListItem>
                                        <asp:ListItem Value="Category">Category</asp:ListItem>
                                        <asp:ListItem>Brand</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 224px; height: 22px" align="left">
                                    <asp:TextBox ID="txtSeach" runat="server" Width="200px" CssClass="txtBox "></asp:TextBox>
                                </td>
                                <td style="width: 250px; height: 22px" align="left">
                                    <asp:Button ID="btnFilter" runat="server" Width="85px" Font-Size="8pt" Text="Filter"
                                        OnClick="btnFilter_Click"></asp:Button>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <asp:Panel ID="Panel1" runat="server" Width="100%" Height="200px" ScrollBars="Vertical" BorderWidth="1px">
                        <asp:GridView ID="grdSKUData" runat="server" Width="100%" ForeColor="SteelBlue" CssClass="gridRow2"
                            OnPageIndexChanging="grdSKUData_PageIndexChanging" HorizontalAlign="Center" BorderColor="White"
                            BackColor="White" AutoGenerateColumns="False" OnRowEditing="grdSKUData_RowEditing"
                            OnRowDeleting="grdSKUData_RowDeleting">
                            <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                                PreviousPageText="Previous"></PagerSettings>
                            <Columns>
                                <asp:BoundField DataField="Principal_Id" ReadOnly="true">
                                    <HeaderStyle CssClass="HidePanel"></HeaderStyle>
                                    <ItemStyle CssClass="HidePanel"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Division_Id" ReadOnly="true">
                                    <HeaderStyle CssClass="HidePanel"></HeaderStyle>
                                    <ItemStyle CssClass="HidePanel"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Category_Id" ReadOnly="true" HeaderText="Category_Id">
                                    <HeaderStyle CssClass="HidePanel"></HeaderStyle>
                                    <ItemStyle CssClass="HidePanel"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Brand_Id" ReadOnly="true" HeaderText="Brand_Id">
                                    <HeaderStyle CssClass="HidePanel"></HeaderStyle>
                                    <ItemStyle CssClass="HidePanel"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="SKU_ID" ReadOnly="true" HeaderText="SKU_ID">
                                    <HeaderStyle CssClass="HidePanel"></HeaderStyle>
                                    <ItemStyle CssClass="HidePanel"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Principal" ReadOnly="true" HeaderText="Principal">
                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Division" ReadOnly="true" HeaderText="Division">
                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Category" ReadOnly="true" HeaderText="Category">
                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Brand" ReadOnly="true" HeaderText="Brand">
                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="SKU_CODE" ReadOnly="true" HeaderText="Code">
                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="SKU_NAME" ReadOnly="true" HeaderText="Name">
                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="PACKSIZE" ReadOnly="true" HeaderText="Pack Size">
                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="UNITS_IN_CASE" ReadOnly="true" HeaderText="UIC">
                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" CssClass="HidePanel"></ItemStyle>
                                    <HeaderStyle CssClass="HidePanel" />
                                </asp:BoundField>
                                <asp:BoundField DataField="GST_ON" ReadOnly="true" HeaderText="GST">
                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="SKU_Weight" ReadOnly="true" HeaderText="Weight">
                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="ISEXEMPTED" ReadOnly="true" HeaderText="IsExemted">
                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                    <HeaderStyle CssClass="HidePanel"></HeaderStyle>
                                    <ItemStyle CssClass="HidePanel"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="UOM" ReadOnly="true" HeaderText="UOM">
                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="FMR" ReadOnly="true" HeaderText="FMR">
                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="MR" ReadOnly="true" HeaderText="MR">
                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Pur_Discount" ReadOnly="true" HeaderText="P.Disc">
                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" Text="Edit" ToolTip="Edit">
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle BorderColor="Silver" BorderWidth="2px" BorderStyle="Solid" Width="30px"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnDelete" runat="server" Text="Delete" OnClientClick="javascript:return confirm('Are you sure you want to Delete?');return false;"
                                            CommandName="Delete"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle CssClass="tblhead"></HeaderStyle>
                        </asp:GridView>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
