<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adaugaconsultatie.aspx.cs" Inherits="P3.adaugaconsultatie" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <a>
            <img src="imgs/consult2.png" width="80" height="80"/>
            <b>Consultatii</b>
             <p></p>
    </a>

    <div>
        <!-- ID-ul de la pacient are IDENTITYUU, care actioneaza ca auto-increment, deci nu se adauga explicit -->
        <label>medicid</label>
            <!-- form-group e o clasa bootstrap pentru highlight si alte functionalitati ale text-box-ulkui -->
            <div class="form-group">
            <!-- ascum adaug un text box standard asp -->
            <asp:TextBox CssClass="form-control" ID="TextBox_medicid" runat="server" placeholder="medicid" OnTextChanged="TextBox_nume_TextChanged"></asp:TextBox>
            </div>
        <label>pacientid</label>
            <!-- form-group e o clasa bootstrap pentru highlight si alte functionalitati ale text-box-ulkui -->
            <div class="form-group">
            <!-- ascum adaug un text box standard asp -->
            <asp:TextBox CssClass="form-control" ID="TextBox_pacientid" runat="server" placeholder="pacientid" OnTextChanged="TextBox_prenume_TextChanged"></asp:TextBox>
         </div>
        <label>medicamentid</label>
            <!-- form-group e o clasa bootstrap pentru highlight si alte functionalitati ale text-box-ulkui -->
            <div class="form-group">
            <!-- ascum adaug un text box standard asp -->
            <asp:TextBox CssClass="form-control" ID="TextBox_medicamentid" runat="server" placeholder="medicamentid" OnTextChanged="TextBox_specializare_TextChanged"></asp:TextBox>
         </div>
        <label>diagnostic</label>
            <!-- form-group e o clasa bootstrap pentru highlight si alte functionalitati ale text-box-ulkui -->
            <div class="form-group">
            <!-- ascum adaug un text box standard asp -->
            <asp:TextBox CssClass="form-control" ID="TextBox_diagnostic" runat="server" placeholder="diagnostic" OnTextChanged="TextBox_nume_TextChanged"></asp:TextBox>
            </div>
        <label>data</label>
            <!-- form-group e o clasa bootstrap pentru highlight si alte functionalitati ale text-box-ulkui -->
            <div class="form-group">
            <!-- ascum adaug un text box standard asp -->
            <asp:TextBox CssClass="form-control" ID="TextBox_data" runat="server" placeholder="data" OnTextChanged="TextBox_prenume_TextChanged"></asp:TextBox>
         </div>
        <label>doza medicament</label>
            <!-- form-group e o clasa bootstrap pentru highlight si alte functionalitati ale text-box-ulkui -->
            <div class="form-group">
            <!-- ascum adaug un text box standard asp -->
            <asp:TextBox CssClass="form-control" ID="TextBox_doza" runat="server" placeholder="doza medicament" OnTextChanged="TextBox_specializare_TextChanged"></asp:TextBox>
         </div>

        <p></p>
            <asp:Button class="btn btn-success btn-block btn-lg" ID="Button_adauga" runat="server"
                Text="Adauga Consultatie" OnClick="Button_adauga_Click" BackColor="White" Width="200" ForeColor="Black" BorderColor="Black"/>
        <p></p>

    </div>

</asp:Content>
