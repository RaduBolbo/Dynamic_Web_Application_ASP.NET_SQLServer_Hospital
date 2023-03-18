<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="consultatii.aspx.cs" Inherits="P3.consultatii" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h>
        
        <%--anchor cu iconita si titlu --%>
        <a>
            <img src="imgs/consult2.png" width="80" height="80"/>
            <b>Consultatii</b>
        </a>
    </h>


    <p></p>
            <asp:Button class="btn btn-success btn-block btn-lg" ID="Button_adauga" runat="server"
                Text="Adauga Consultie" OnClick="Button_adauga_Click" BackColor="White" Width="200" ForeColor="Black" BorderColor="Black"/>
            <p></p>
            <asp:Button class="btn btn-success btn-block btn-lg" ID="Button_modifica" runat="server"
                Text="Modifica Consultie" OnClick="Button_modifica_Click" BackColor="White" Width="200" ForeColor="Black" BorderColor="Black"/>
             <p></p>
            <asp:Button class="btn btn-success btn-block btn-lg" ID="Button_sterge" runat="server"
                Text="Sterge Consultie" OnClick="Button_sterge_Click" BackColor="White" Width="200" ForeColor="Black" BorderColor="Black" Visible="false"/>
             <p></p>
        </a>
    </h>

    <h>
    </h>

        <!-- afisarea tabelei -->

    <table width="100%" align="center" cellpadding="2" cellspacing="2" border="0" bgcolor="#EAEAEA" >
        <tr align="left" style="background-color:White;color:Black;" >
            <td> consultatieID </td>
            <td> data </td>
            <td> diagnostic </td>
            <td> medicID </td>
            <td> nume_medic </td>            
            <td> prenume_medic </td>    
            <td> specializare </td> 
            <td> pacientID </td>
            <td> nume_pacient </td>            
            <td> prenume_pacient </td>    
            <td> CNP </td> 
            <td> adresa </td> 
            <td> medicamentID </td>    
            <td> denumire </td>
            <td> dozamedicament </td>
        </tr>

        <%=getWhileLoopData()%>

    </table>

</asp:Content>
