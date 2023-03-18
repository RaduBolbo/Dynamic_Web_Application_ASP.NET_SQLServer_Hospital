<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adaugapacient.aspx.cs" Inherits="P3.adaugapacient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <a>
            <img src="imgs/pac3.png" width="80" height="80"/>
            <b>Adauga Pacient</b>
             <p></p>
    </a>

    <div>
        <!-- ID-ul de la pacient are IDENTITYUU, care actioneaza ca auto-increment, deci nu se adauga explicit -->
        <label>nume</label>
            <!-- form-group e o clasa bootstrap pentru highlight si alte functionalitati ale text-box-ulkui -->
            <div class="form-group">
            <!-- ascum adaug un text box standard asp -->
            <asp:TextBox CssClass="form-control" ID="TextBox_nume" runat="server" placeholder="nume pacient" OnTextChanged="TextBox_nume_TextChanged"></asp:TextBox>
         </div>
        <label>prenume</label>
            <!-- form-group e o clasa bootstrap pentru highlight si alte functionalitati ale text-box-ulkui -->
            <div class="form-group">
            <!-- ascum adaug un text box standard asp -->
            <asp:TextBox CssClass="form-control" ID="TextBox_prenume" runat="server" placeholder="prenume pacient" OnTextChanged="TextBox_prenume_TextChanged"></asp:TextBox>
         </div>
        <label>CNP</label>
            <!-- form-group e o clasa bootstrap pentru highlight si alte functionalitati ale text-box-ulkui -->
            <div class="form-group">
            <!-- ascum adaug un text box standard asp -->
            <asp:TextBox CssClass="form-control" ID="TextBox_CNP" runat="server" placeholder="CNP" OnTextChanged="TextBox_CNP_TextChanged"></asp:TextBox>
         </div>
        <label>adresa</label>
            <!-- form-group e o clasa bootstrap pentru highlight si alte functionalitati ale text-box-ulkui -->
            <div class="form-group">
            <!-- ascum adaug un text box standard asp -->
            <asp:TextBox CssClass="form-control" ID="TextBox_adresa" runat="server" placeholder="adresa" OnTextChanged="TextBox_adresa_TextChanged"></asp:TextBox>
         </div>
        <label>asigurare</label>
            <!-- form-group e o clasa bootstrap pentru highlight si alte functionalitati ale text-box-ulkui -->
            <div class="form-group">
            <!-- ascum adaug un text box standard asp -->
            <asp:TextBox CssClass="form-control" ID="TextBox_asigurare" runat="server" placeholder="asigurare" OnTextChanged="TextBox_asigurare_TextChanged"></asp:TextBox>
         </div>

        <p></p>
            <asp:Button class="btn btn-success btn-block btn-lg" ID="Button_adauga" runat="server"
                Text="Adauga Pacient" OnClick="Button_adauga_Click" BackColor="White" Width="200" ForeColor="Black" BorderColor="Black"/>
        <p></p>

    </div>


</asp:Content>
