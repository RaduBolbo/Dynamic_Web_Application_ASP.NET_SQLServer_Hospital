<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="stergepacient.aspx.cs" Inherits="P3.stergepacient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server" EnableViewState="true">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <a>
            <img src="imgs/pac3.png" width="80" height="80"/>
            <b>Sterge Pacient</b>
             <p></p>
    </a>

    <asp:DropDownList ID="DropDownList1" runat="server" Width="100px">  
    </asp:DropDownList>

    <p></p>

        <p></p>
            <asp:Button class="btn btn-success btn-block btn-lg" ID="Button_adauga" runat="server"
                Text="Sterge Pacient" OnClick="Button_sterge_Click" BackColor="White" Width="200" ForeColor="Black" BorderColor="Black"/>
        <p></p>

</asp:Content>
