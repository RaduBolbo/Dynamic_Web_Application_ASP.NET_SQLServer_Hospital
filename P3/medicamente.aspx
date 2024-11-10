<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="medicamente.aspx.cs" Inherits="P3.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h>
        <%--anchor cu iconita si titlu --%>
        <a>
            <img src="imgs/medicine2.png" width="80" height="80"/>
            <b>Medicamente</b>
        </a>
        <p></p>
            <asp:Button class="btn btn-success btn-block btn-lg" ID="Button_adauga" runat="server"
                Text="Adauga Medicament" OnClick="Button_adauga_Click" BackColor="White" Width="220" ForeColor="Black" BorderColor="Black"/>
            <p></p>
            <asp:Button class="btn btn-success btn-block btn-lg" ID="Button_modifica" runat="server"
                Text="Modifica Medicament" OnClick="Button_modifica_Click" BackColor="White" Width="220" ForeColor="Black" BorderColor="Black"/>
             <p></p>
            <asp:Button class="btn btn-success btn-block btn-lg" ID="Button_sterge" runat="server"
                Text="Sterge Medicament" OnClick="Button_sterge_Click" BackColor="White" Width="220" ForeColor="Black" BorderColor="Black" Visible="false"/>
             <p></p>
    </h>


    
    <!-- afisarea tabelei -->

    <table width="100%" align="center" cellpadding="2" cellspacing="2" border="0" bgcolor="#EAEAEA" >
        <tr align="left" style="background-color:White;color:Black;" >
            <td> ID </td>
            <td> Denumire </td>
        </tr>

        <%=getWhileLoopData()%>

    </table>

</asp:Content>
