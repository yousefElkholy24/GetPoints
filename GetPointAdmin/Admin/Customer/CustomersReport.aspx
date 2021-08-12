<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="CustomersReport.aspx.cs" Inherits="GetPointAdmin.Admin.Customer.CustomersReport" %>

<%@ Register Assembly="DevExpress.XtraReports.v21.1.Web.WebForms, Version=21.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <dx:ASPxWebDocumentViewer ID="CustReport" runat="server" ReportSourceId="GetPointAdmin.Admin.Report.CustomersReport">


    </dx:ASPxWebDocumentViewer>
</asp:Content>
