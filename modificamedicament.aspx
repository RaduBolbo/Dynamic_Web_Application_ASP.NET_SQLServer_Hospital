<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="modificamedicament.aspx.cs" Inherits="P3.modificamedicament" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
<a>
            <img src="imgs/medicine2.png" width="80" height="80"/>
            <b>Modifica Medicament</b>
             <p></p>
    </a>

    <asp:DropDownList ID="DropDownList1" runat="server" Width="100px">  
    </asp:DropDownList>

    <p></p>

    <!-- ID-ul de la pacient are IDENTITYUU, care actioneaza ca auto-increment, deci nu se adauga explicit -->
        <label>denumire noua</label>
            <!-- form-group e o clasa bootstrap pentru highlight si alte functionalitati ale text-box-ulkui -->
            <div class="form-group">
            <!-- ascum adaug un text box standard asp -->
            <asp:TextBox CssClass="form-control" ID="TextBox_denumire" runat="server" placeholder="denumire noua medicament" OnTextChanged="TextBox_denumire_TextChanged"></asp:TextBox>
         </div>

        <p></p>
            <asp:Button class="btn btn-success btn-block btn-lg" ID="Button_adauga" runat="server"
                Text="Modifica Mediacament" OnClick="Button_modifica_Click" BackColor="White" Width="200" ForeColor="Black" BorderColor="Black"/>
        <p></p>
</asp:Content>
