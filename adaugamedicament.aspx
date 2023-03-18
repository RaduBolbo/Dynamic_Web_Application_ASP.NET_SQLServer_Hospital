<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adaugamedicament.aspx.cs" Inherits="P3.adaugamedicament" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <a>
            <img src="imgs/medicine2.png" width="80" height="80"/>
            <b>Adauga MEdicament</b>
             <p></p>
    </a>

    <div>
        <!-- ID-ul de la pacient are IDENTITYUU, care actioneaza ca auto-increment, deci nu se adauga explicit -->
        <label>Denumire</label>
            <!-- form-group e o clasa bootstrap pentru highlight si alte functionalitati ale text-box-ulkui -->
            <div class="form-group">
            <!-- ascum adaug un text box standard asp -->
            <asp:TextBox CssClass="form-control" ID="TextBox_denumire" runat="server" placeholder="denumire medicament" OnTextChanged="TextBox_nume_TextChanged"></asp:TextBox>
         </div>

        <p></p>
            <asp:Button class="btn btn-success btn-block btn-lg" ID="Button_adauga" runat="server"
                Text="Adauga Medicament" OnClick="Button_adauga_Click" BackColor="White" Width="200" ForeColor="Black" BorderColor="Black"/>
        <p></p>

    </div>

</asp:Content>
