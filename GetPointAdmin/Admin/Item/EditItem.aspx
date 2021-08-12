<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="EditItem.aspx.cs" Inherits="GetPointAdmin.Admin.Item.EditItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">

    <div class="container-fluid">
        <div class="row">
            <p class="col-12 demo-content-title"> Edit Item</p>
        </div>
        <div class="row">
            <div class="col-12">
                <dx:BootstrapFormLayout ID="EditItemForm" runat="server" AlignItemCaptionsInAllGroups="True">

                    <Items>

                        <dx:BootstrapLayoutItem FieldName="CategoryID" Caption="Category" RequiredMarkDisplayMode="Required">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapComboBox  ID="CatCombo" runat="server" 
                                        ValueField="CategoryTitleAr" Width="100%" DataSourceID="SqlDataSource2" CallbackPageSize="15">
                                        <Fields>
                                            <dx:BootstrapListBoxField  FieldName="CategoryTitleAr" />
                                        </Fields>
                                    </dx:BootstrapComboBox>
                                    <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:GetPointConnectionString2 %>' SelectCommand="SELECT [CategoryID], [CategoryTitleAr] FROM [tbl_Category]"></asp:SqlDataSource>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>


                        <dx:BootstrapLayoutItem FieldName="ItemTitle" Caption="Title">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapTextBox runat="server" ID="txtTitle"></dx:BootstrapTextBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>


                        <dx:BootstrapLayoutItem FieldName="ItemDescription" Caption="Description">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapTextBox runat="server" ID="txtDescription"></dx:BootstrapTextBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>


                        <dx:BootstrapLayoutItem FieldName="ItemPrice" Caption="Price">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapSpinEdit runat="server" ID="Price"></dx:BootstrapSpinEdit>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>


                        <dx:BootstrapLayoutItem FieldName="ItemPic" Caption="Pic">
                            <ContentCollection>
                               <dx:ContentControl runat="server">
                                        <dx:BootstrapUploadControl runat="server"  ID="EditImage" ShowUploadButton="true" NullText="Select Image..."
                                        AdvancedModeSettings-EnableMultiSelect="false" ClientInstanceName="F3">
<%--                                            <ClientSideEvents FileUploadComplete="onFileUploadComplete" FilesUploadStart="onFilesUploadStart" />--%>
                                            <ValidationSettings MaxFileSize="4194304" AllowedFileExtensions=".jpg,.jpeg,.gif,.png" />
                                        </dx:BootstrapUploadControl>
                                        <small>Allowed file extensions: .jpg, .jpeg, .gif, .png.</small>
                                        <br />
                                        <small>Maximum file size: 4 MB.</small>  
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>

                         
                        <dx:BootstrapLayoutItem FieldName="SupplierID" Caption="Supplier">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                     <dx:BootstrapComboBox ID="SupID" runat="server"
                                        ValueField="SupplierTitle" ValueType="System.String" Width="100%" DataSourceID="SqlDataSource1" CallbackPageSize="15">
                                        <Fields>
                                            <dx:BootstrapListBoxField FieldName="SupplierTitle" />
                                        </Fields>
                                    </dx:BootstrapComboBox>
                                <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:GetPointConnectionString2 %>' SelectCommand="SELECT [SupplierID], [SupplierTitle] FROM [tbl_Supplier]"></asp:SqlDataSource>

                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>


                        <dx:BootstrapLayoutItem FieldName="SubCategoryId" Caption="SubCategory">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapComboBox ID="SubcatID" runat="server"
                                        ValueField="SubCategoryTitleAr" Width="100%" CallbackPageSize="15" DataSourceID="SqlDataSource3">
                                        <Fields>
                                            <dx:BootstrapListBoxField FieldName="SubCategoryTitleAr" />
                                        </Fields>
                                    </dx:BootstrapComboBox>
                                    <asp:SqlDataSource runat="server" ID="SqlDataSource3" ConnectionString='<%$ ConnectionStrings:GetPointConnectionString2 %>' SelectCommand="SELECT [SubCategoryTitleAr], [SubCategoryID] FROM [tbl_SubCategory]"></asp:SqlDataSource>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>


                        <dx:BootstrapLayoutItem FieldName="Points">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapSpinEdit runat="server" ID="Points"></dx:BootstrapSpinEdit>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>



                        <dx:BootstrapLayoutItem FieldName="PointsCredit">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapSpinEdit runat="server" ID="PointsCred"></dx:BootstrapSpinEdit>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                        
                        

                        <dx:BootstrapLayoutItem ShowCaption="false" ColSpanLg="12" ColSpanSm="12">
                            <ContentCollection>
                                <dx:ContentControl  runat="server">
                                    <dx:BootstrapButton Text="Save" runat="server" ID="UpdateButton" OnClick="UpdateButton_Click"></dx:BootstrapButton>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                        
                    </Items>
                    
                </dx:BootstrapFormLayout>
            </div>

        </div>

    </div>
</asp:Content>
