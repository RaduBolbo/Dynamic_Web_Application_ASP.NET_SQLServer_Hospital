<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="logout.aspx.cs" Inherits="P3.logout1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <a>
            <b>Logout</b>
             <p></p>
    </a>

    <div>
        <div class="form-group">
        <asp:Button class="btn btn-outline-dark btn-block btn-lg" ID="Button1" runat="server" Text="Logout" OnClick="Button1_Click" Width="200" />
        </div>

    </div>

</asp:Content>
