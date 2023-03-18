<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="pacienti.aspx.cs" Inherits="P3.WebForm3" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h>
        <%--anchor cu iconita si titlu --%>
        <a>
            <img src="imgs/pac3.png" width="80" height="80"/>
            <b>Pacienti</b>
             <p></p>
            <asp:Button class="btn btn-success btn-block btn-lg" ID="Button_adauga" runat="server"
                Text="Adauga Pacient" OnClick="Button_adauga_Click" BackColor="White" Width="200" ForeColor="Black" BorderColor="Black"/>
            <p></p>
            <asp:Button class="btn btn-success btn-block btn-lg" ID="Button_modifica" runat="server"
                Text="Modifica Pacient" OnClick="Button_modifica_Click" BackColor="White" Width="200" ForeColor="Black" BorderColor="Black"/>
             <p></p>
            <asp:Button class="btn btn-success btn-block btn-lg" ID="Button_sterge" runat="server"
                Text="Sterge Pacient" OnClick="Button_sterge_Click" BackColor="White" Width="200" ForeColor="Black" BorderColor="Black" Visible="false"/>
             <p></p>
        </a>
    </h>

    <h>

    <!-- afisarea tabelei -->

    <table width="100%" align="center" cellpadding="2" cellspacing="2" border="0" bgcolor="#EAEAEA" >
        <tr align="left" style="background-color:White;color:Black;" >
            <td> pacientID </td>
            <td> CNP </td>
            <td> nume </td>            
            <td> prenume </td>    
            <td> adresa </td> 
            <td> asigurare </td> 
        </tr>

        <%=getWhileLoopData()%>

    </table>

    </a></asp:Content>
