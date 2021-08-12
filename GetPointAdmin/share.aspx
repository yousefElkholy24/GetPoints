<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="share.aspx.cs" Inherits="GetPointAdmin.share" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <asp:PlaceHolder runat="server">
        <link id="themeLink" rel="stylesheet"
            href='<%= Page.ResolveUrl("~/Content/light/bootstrap.min.css")%>'
            data-theme-dark-url='<%= Page.ResolveUrl("~/Content/dark/bootstrap.min.css")%>'
            data-theme-light-url='<%= Page.ResolveUrl("~/Content/light/bootstrap.min.css")%>' />
        <link href='<%= Page.ResolveUrl("~/Content/demo-icons.css")%>' rel="stylesheet" />
        <link href='<%= Page.ResolveUrl("~/Content/common.css")%>' rel="stylesheet" />
        <link href='<%= Page.ResolveUrl("~/Content/Custom.css")%>' rel="stylesheet" />
        <link href='<%= Page.ResolveUrl("~/Content/Font/css/all.css")%>' rel="stylesheet" />

        <link href="https://fonts.googleapis.com/css?family=Lato:300,400,400i,700|Poppins:300,400,500,600,700|PT+Serif:400,400i&display=swap" rel="stylesheet" type="text/css" />
        <link rel="stylesheet" href="/Content/Public/css/bootstrap.css" type="text/css" />
        <link rel="stylesheet" href="/Content/Public/css/style.css" type="text/css" />
        <link rel="stylesheet" href="/Content/Public/css/dark.css" type="text/css" />
        <link rel="stylesheet" href="/Content/Public/css/font-icons.css" type="text/css" />
        <link rel="stylesheet" href="/Content/Public/css/animate.css" type="text/css" />
        <link rel="stylesheet" href="/Content/Public/css/magnific-popup.css" type="text/css" />

        <link rel="stylesheet" href="/Content/Public/css/custom.css" type="text/css" />
        <meta name="viewport" content="width=device-width, initial-scale=1" />
        <script src='<%= Page.ResolveUrl("~/Content/common.js")%>' defer></script>
        <%--<script src="https://code.jquery.com/jquery-3.5.0.js"></script>--%>

    </asp:PlaceHolder>
</head>
<body>
    <section id="content">
        <div class="content-wrap py-0">

            <div class="section p-0 m-0 h-100 position-absolute" style="background: url('~/Images/GetPointLogo.png') center center no-repeat; background-size: cover;"></div>

            <div class="section bg-transparent min-vh-100 p-0 m-0">
                <div class="vertical-middle">
                    <div class="container-fluid py-5 mx-auto">
                        <div class="center">
                            <h2 style="color: #FFFFFF;">GetPoints</h2>
                        </div>

                        <div class="card mx-auto rounded-0 border-0" style="max-width: 1000px; background-color: rgba(255,255,255,0.93);">
                            <div class="card-body" style="padding: 40px; width: 1000px">



                                <form id="logForm" runat="server">
                                    <h3 style="text-align: center">Item Details</h3>
                                    <div class="row">
                                        <div class="center">
                                        <dx:BootstrapImage ID="BootstrapImage1" runat="server" ImageUrl="~/Images/GetPointLogo.png" ShowLoadingImage="True" Width="300" ImageAlign="Middle"></dx:BootstrapImage>
                                         </div>
                                        <dx:BootstrapFormLayout ID="AddItemForm" runat="server" AlignItemCaptionsInAllGroups="True" DataSourceID="SqlDataSource1">

                                            <Items>
                                                <dx:BootstrapLayoutItem FieldName="ItemTitle" Caption="Title" ColSpanLg="8" ColSpanMd="8" ColSpanSm="8">
                                                    <ContentCollection>
                                                        <dx:ContentControl runat="server">
                                                            <dx:BootstrapTextBox runat="server" ID="txtTitle" ReadOnly="true"></dx:BootstrapTextBox>
                                                        </dx:ContentControl>
                                                    </ContentCollection>
                                                </dx:BootstrapLayoutItem>

                                                 <dx:BootstrapLayoutItem FieldName="ItemPrice" Caption="Price" ColSpanLg="4" ColSpanMd="4" ColSpanSm="4">
                                                    <ContentCollection>
                                                        <dx:ContentControl runat="server">
                                                            <dx:BootstrapSpinEdit runat="server" ID="Price" ReadOnly="true"></dx:BootstrapSpinEdit>
                                                        </dx:ContentControl>
                                                    </ContentCollection>
                                                </dx:BootstrapLayoutItem>

                                                <dx:BootstrapLayoutItem FieldName="ItemDescription" Caption="Description"  ColSpanLg="12" ColSpanMd="12" ColSpanSm="12">
                                                    <ContentCollection>
                                                        <dx:ContentControl runat="server">
                                                            <dx:BootstrapMemo runat="server" ID="txtDescription" ReadOnly="true"></dx:BootstrapMemo>
                                                        </dx:ContentControl>
                                                    </ContentCollection>
                                                </dx:BootstrapLayoutItem>
                                            </Items> 
                                        </dx:BootstrapFormLayout>
                                       <div class="center" style="display:inline-block;padding-left:200px">
                                            <dx:BootstrapGridView ID="ShowImage" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" Width="600px">
                                                <Columns>
                                                    <dx:BootstrapGridViewImageColumn FieldName="ItemPic" Width="400px" VisibleIndex="0" Caption="Pic">
                                                        <PropertiesImage ImageUrlFormatString="~/images/{0}" ImageHeight="200px" ImageWidth="200px" />
                                                        <ExportCellStyle HorizontalAlign="Center" VerticalAlign="Middle"></ExportCellStyle>
                                                    </dx:BootstrapGridViewImageColumn>
                                                </Columns>
                                            </dx:BootstrapGridView>
                                        </div>

                                        <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:GetPointConnectionString2 %>' SelectCommand="SELECT [ItemTitle], [ItemDescription], [ItemPrice], [ItemPic] FROM [tbl_Item] WHERE ([ItemID] = @ItemID)">
                                            <SelectParameters>
                                                <asp:QueryStringParameter QueryStringField="id" DefaultValue="0" Name="ItemID" Type="Int32"></asp:QueryStringParameter>
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                    </div>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>

    </section>
</body>
</html>
