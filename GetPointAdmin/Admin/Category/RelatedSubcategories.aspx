<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="RelatedSubcategories.aspx.cs" Inherits="GetPointAdmin.Admin.Category.RelatedSubcategories" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="mainContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <p class="col-12 demo-content-title">Sub Categories List</p>
        </div>
        <div class="row">
            <div class="col-12">
                  <script> 
                    function onToolbarItemClick(s, e) {
                        switch (e.item.name) { 
                            case "btnAddNew":
                                e.processOnServer = true;
                                e.usePostBack = true;
                                break; 
                        } 
                    }
                  </script>
                <dx:BootstrapGridView ID="BootstrapGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" KeyFieldName="SubCategoryID" OnToolbarItemClick="BootstrapGridView1_ToolbarItemClick" OnCustomButtonCallback="BootstrapGridView1_CustomButtonCallback">
                    <Settings ShowFilterRow="True" />
                    <ClientSideEvents ToolbarItemClick="onToolbarItemClick" />

                    <Columns>
                        <dx:BootstrapGridViewCommandColumn ShowEditButton="false" ShowSelectCheckbox="false" VisibleIndex="100" Caption="Actions">
                            <CustomButtons>
                                <dx:BootstrapGridViewCommandColumnCustomButton ID="btnEdit" Text="Edit" IconCssClass="fa fa-edit" />
                                <dx:BootstrapGridViewCommandColumnCustomButton ID="btnDelete" Text="Delete" IconCssClass="fa fa-trash-alt" />
                            </CustomButtons>
                        </dx:BootstrapGridViewCommandColumn>


                        <dx:BootstrapGridViewTextColumn FieldName="SubCategoryID" ReadOnly="True" VisibleIndex="0" Visible="false">
                            <SettingsEditForm Visible="False"></SettingsEditForm>
                        </dx:BootstrapGridViewTextColumn>



                        <dx:BootstrapGridViewTextColumn FieldName="SubCategoryTitleAr" VisibleIndex="1" Caption="Arabic title">
                        </dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="SubCategoryTitleEn" VisibleIndex="2" Caption="English Title">
                        </dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewCheckColumn FieldName="SubCategoryIsActive" VisibleIndex="4" Caption="Active">
                        </dx:BootstrapGridViewCheckColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="SubCategorySort" VisibleIndex="5" Caption="Order">
                        </dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="SubCategoryDescription" VisibleIndex="6" Visible="false">
                        </dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="CategoryID" VisibleIndex="7" Visible="false"></dx:BootstrapGridViewTextColumn>

                        <dx:BootstrapGridViewImageColumn FieldName="SubCategoryPic" Width="120px" VisibleIndex="0" Caption="Pic">
                            <PropertiesImage ImageUrlFormatString="~/Images/{0}" ImageHeight="100px" />
                        </dx:BootstrapGridViewImageColumn>
                    </Columns>
                    <Toolbars>
                        <dx:BootstrapGridViewToolbar Position="Top" ShowInsidePanel="true">
                            <Items>
                                <dx:BootstrapGridViewToolbarItem Name="btnAddNew" Text="Add New Sub Category"></dx:BootstrapGridViewToolbarItem>
                            </Items>
                        </dx:BootstrapGridViewToolbar>
                    </Toolbars>
                    <SettingsSearchPanel Visible="True" />
                </dx:BootstrapGridView>

              <%--  <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:GetPointsDBConnectionString %>' SelectCommand="SELECT [SubCategoryTitleAr], [SubCategoryPic], [SubCategoryTitleEn], [SubCategoryIsActive], [SubCategorySort], [SubCategoryDescription], [CategoryID] FROM [tbl_SubCategory] WHERE ([CategoryID] = @CategoryID)">
                    <SelectParameters>
                        <asp:QueryStringParameter QueryStringField="CategoryID" DefaultValue="0" Name="CategoryID" Type="Int32"></asp:QueryStringParameter>
                    </SelectParameters>
                </asp:SqlDataSource>--%>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GetPointConnectionString2 %>" SelectCommand="SELECT * FROM [tbl_SubCategory] WHERE ([CategoryID] = @CategoryID)">

                    <SelectParameters>
                        <asp:QueryStringParameter QueryStringField="id" DefaultValue="0" Name="CategoryID" Type="Int32"></asp:QueryStringParameter>
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>
        </div>
    </div>
</asp:Content>
