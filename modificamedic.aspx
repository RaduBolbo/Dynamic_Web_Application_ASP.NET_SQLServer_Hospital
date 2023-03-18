<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="modificamedic.aspx.cs" Inherits="P3.modificamedic" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <a>
            <img src="imgs/doc3.png" width="80" height="80"/>
            <b>Modifica medic</b>
             <p></p>
    </a>

    <asp:DropDownList ID="DropDownList1" runat="server" Width="100px">  
    </asp:DropDownList>

    <p></p>

    <!-- ID-ul de la pacient are IDENTITYUU, care actioneaza ca auto-increment, deci nu se adauga explicit -->
        <label>nume nou</label>
            <!-- form-group e o clasa bootstrap pentru highlight si alte functionalitati ale text-box-ulkui -->
            <div class="form-group">
            <!-- ascum adaug un text box standard asp -->
            <asp:TextBox CssClass="form-control" ID="TextBox_nume" runat="server" placeholder="nume nou medic" OnTextChanged="TextBox_nume_TextChanged"></asp:TextBox>
         </div>
        <label>prenume nou</label>
            <!-- form-group e o clasa bootstrap pentru highlight si alte functionalitati ale text-box-ulkui -->
            <div class="form-group">
            <!-- ascum adaug un text box standard asp -->
            <asp:TextBox CssClass="form-control" ID="TextBox_prenume" runat="server" placeholder="prenume nou medic" OnTextChanged="TextBox_prenume_TextChanged"></asp:TextBox>
         </div>
        <label>specializare noua</label>
            <!-- form-group e o clasa bootstrap pentru highlight si alte functionalitati ale text-box-ulkui -->
            <div class="form-group">
            <!-- ascum adaug un text box standard asp -->
            <asp:TextBox CssClass="form-control" ID="TextBox_specializare" runat="server" placeholder="specializare noua" OnTextChanged="TextBox_specializare_TextChanged"></asp:TextBox>
         </div>

        <p></p>
            <asp:Button class="btn btn-success btn-block btn-lg" ID="Button_adauga" runat="server"
                Text="Modifica Medic" OnClick="Button_modifica_Click" BackColor="White" Width="200" ForeColor="Black" BorderColor="Black"/>
        <p></p>

</asp:Content>
