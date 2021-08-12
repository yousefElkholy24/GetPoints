<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="OrderTest.aspx.cs" Inherits="GetPointAdmin.Admin.Order.OrderTest" %>

<%@ Register Assembly="DevExpress.XtraReports.v21.1.Web.WebForms, Version=21.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <dx:ASPxWebDocumentViewer ID="OrdersTest" runat="server" ReportSourceId="GetPointAdmin.Admin.Report.XtraReport1" ></dx:aspxwebdocumentviewer>

</asp:Content>
