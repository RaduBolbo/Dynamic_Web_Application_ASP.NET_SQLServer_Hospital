<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="modificaconsultatie.aspx.cs" Inherits="P3.modificaconsultatie" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <a>
            <img src="imgs/consult2.png" width="80" height="80"/>
            <b>Modifica consultatie</b>
             <p></p>
    </a>

    <asp:DropDownList ID="DropDownList1" runat="server" Width="100px">  
    </asp:DropDownList>

    <p></p>

    <!-- ID-ul de la pacient are IDENTITYUU, care actioneaza ca auto-increment, deci nu se adauga explicit -->
        <label>idmedic nou</label>
            <!-- form-group e o clasa bootstrap pentru highlight si alte functionalitati ale text-box-ulkui -->
            <div class="form-group">
            <!-- ascum adaug un text box standard asp -->
            <asp:TextBox CssClass="form-control" ID="TextBox_idmedic" runat="server" placeholder="idmedic nou" OnTextChanged="TextBox_nume_TextChanged"></asp:TextBox>
         </div>
        <label>idpacient nou</label>
            <!-- form-group e o clasa bootstrap pentru highlight si alte functionalitati ale text-box-ulkui -->
            <div class="form-group">
            <!-- ascum adaug un text box standard asp -->
            <asp:TextBox CssClass="form-control" ID="TextBox_pacientid" runat="server" placeholder="idpacient nou" OnTextChanged="TextBox_prenume_TextChanged"></asp:TextBox>
         </div>
        <label>idmedicament nou</label>
            <!-- form-group e o clasa bootstrap pentru highlight si alte functionalitati ale text-box-ulkui -->
            <div class="form-group">
            <!-- ascum adaug un text box standard asp -->
            <asp:TextBox CssClass="form-control" ID="TextBox_medicamentid" runat="server" placeholder="idmedicament nou" OnTextChanged="TextBox_specializare_TextChanged"></asp:TextBox>
         </div>
        <label>data noua</label>
            <!-- form-group e o clasa bootstrap pentru highlight si alte functionalitati ale text-box-ulkui -->
            <div class="form-group">
            <!-- ascum adaug un text box standard asp -->
            <asp:TextBox CssClass="form-control" ID="TextBox_data" runat="server" placeholder="data noua" OnTextChanged="TextBox_specializare_TextChanged"></asp:TextBox>
         </div>
        <label>diagnostic nou</label>
            <!-- form-group e o clasa bootstrap pentru highlight si alte functionalitati ale text-box-ulkui -->
            <div class="form-group">
            <!-- ascum adaug un text box standard asp -->
            <asp:TextBox CssClass="form-control" ID="TextBox_diagnostic" runat="server" placeholder="diagnostic nou" OnTextChanged="TextBox_specializare_TextChanged"></asp:TextBox>
         </div>
        <label>doza medicament noua</label>
            <!-- form-group e o clasa bootstrap pentru highlight si alte functionalitati ale text-box-ulkui -->
            <div class="form-group">
            <!-- ascum adaug un text box standard asp -->
            <asp:TextBox CssClass="form-control" ID="TextBox_doza" runat="server" placeholder="doza medicament noua" OnTextChanged="TextBox_specializare_TextChanged"></asp:TextBox>
         </div>

        <p></p>
            <asp:Button class="btn btn-success btn-block btn-lg" ID="Button_adauga" runat="server"
                Text="Modifica consultatie" OnClick="Button_modifica_Click" BackColor="White" Width="200" ForeColor="Black" BorderColor="Black"/>
        <p></p>

</asp:Content>
