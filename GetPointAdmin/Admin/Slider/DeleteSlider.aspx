<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="DeleteSlider.aspx.cs" Inherits="GetPointAdmin.Admin.Slider.DeleteSlider" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">

     <div class="container-fluid">
        <div class="row">
            <p class="col-12 demo-content-title">Delete Slider</p> 
        </div>
        <div class="row"> 
            <div class="col-12">
              
                <dx:BootstrapFormLayout ID="DelSlider" runat="server" AlignItemCaptionsInAllGroups="True">

                    <Items>

                         <dx:BootstrapLayoutItem ShowCaption="False" ColSpanLg="12" ColSpanMd="12"  HorizontalAlign="Center"  >
                           <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <asp:Label runat="server" ID="lblError" Visible="false" Text="" CssClass="text-danger"></asp:Label>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>

                        <dx:BootstrapLayoutItem FieldName="SliderTitle" Caption="Title">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapTextBox runat="server" ID="txtTitle" ReadOnly="true"></dx:BootstrapTextBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                        <dx:BootstrapLayoutItem FieldName="SliderPic">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapImage runat="server" ID="Image" Width="120"></dx:BootstrapImage>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                        <dx:BootstrapLayoutItem FieldName="IsActive" Caption="Active">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapCheckBox runat="server" AccessibilityLabelText="" CheckState="Unchecked" ID="chkActive" Enabled="false"></dx:BootstrapCheckBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                        <dx:BootstrapLayoutItem FieldName="ItemID" Caption="Item">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapSpinEdit runat="server" ID="Item" ReadOnly="true"></dx:BootstrapSpinEdit>
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
                </dx:BootstrapFormLayout>
            </div>
            </div>
         </div>
</asp:Content>
