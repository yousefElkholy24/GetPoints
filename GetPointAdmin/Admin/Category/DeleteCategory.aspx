<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="DeleteCategory.aspx.cs" Inherits="GetPointAdmin.Admin.Category.DeleteCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
    

<asp:Content ID="Content4" ContentPlaceHolderID="mainContent" runat="server">
   
    
    <div class="container-fluid">
        <div class="row">
            <p class="col-12 demo-content-title">Delete Category</p> 
        </div>
        <div class="row"> 
            <div class="col-12">
              
                <dx:bootstrapformlayout id="BootstrapFormLayout1" runat="server" alignitemcaptionsinallgroups="True">
                    <Items>


                         <dx:BootstrapLayoutItem ShowCaption="False" ColSpanLg="12" ColSpanMd="12"  HorizontalAlign="Center"  >
                           <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <asp:Label runat="server" ID="lblError" Visible="false" Text="" CssClass="text-danger"></asp:Label>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>

                        <dx:BootstrapLayoutItem FieldName="CategoryTitleAr" Caption="Arabic Title"  >
                           <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapTextBox runat="server" ID="txtTitleAr" readonly="true">
                                    </dx:BootstrapTextBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>


                        <dx:BootstrapLayoutItem FieldName="CategoryTitleEn" Caption="English Title">
                             <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapTextBox runat="server" ID="txtTitleEn"  readonly="true">
                                    </dx:BootstrapTextBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>


                        <dx:BootstrapLayoutItem FieldName="CategoryPic" Caption="Image" ColSpanLg="6" ColSpanMd="6">
                           <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapImage runat="server" ID="pic" Width="120"></dx:BootstrapImage>
                                
                                </dx:ContentControl>
                           </ContentCollection>
                        </dx:BootstrapLayoutItem>


                        <dx:BootstrapLayoutItem FieldName="CategoryIsActive" Caption="Active" ColSpanLg="3" ColSpanSm="3" >
                            <ContentCollection> 
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapCheckBox runat="server" ID="chkActive" Enabled="false" ></dx:BootstrapCheckBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>


                        <dx:BootstrapLayoutItem FieldName="CategorySort" Caption="Order"  ColSpanLg="3" ColSpanSm="3">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapSpinEdit runat="server" ID="txtOrder" ReadOnly="true"></dx:BootstrapSpinEdit>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>


                        <dx:BootstrapLayoutItem ColSpanMd="12" ColSpanLg="12" FieldName="CategoryDescription" Caption="Description">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapMemo runat="server" ID="txtDescription" ReadOnly="true"></dx:BootstrapMemo>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>


                        <dx:BootstrapLayoutItem ShowCaption="false">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapButton Text="Delete" runat="server" ID="btnDelete" OnClick="btnDelete_Click"></dx:BootstrapButton>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>

                    </Items>
                </dx:bootstrapformlayout>

            </div>
        </div>
    </div>
   

</asp:Content>
