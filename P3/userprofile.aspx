<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userprofile.aspx.cs" Inherits="P3.userprofile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- fac un tabel cu 1 col si maimulte lijn pt logare -->
    <div class="container">
        <div class="row">
            <!-- mx-auto e clasa si face ca elementele de pe coloanas a fie centrate -->
            <div class="col-md-6 mx-auto">

                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100px" src="imgs/user.png"/>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>User profile</h3>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <hr></hr>
                                </center>
                            </div>
                        </div>

                        <!-- aici mai creeaz cumva 2 coloane -->

                        <div class="row">
                            <label>Sunteti logat cu username:</label>
                        </div>

                        <div class="row">
                                    <!-- form-group e o clasa bootstrap pentru highlight si alte functionalitati ale text-box-ulkui -->
                                    <div class="form-group">
                                        <!-- ascum adaug un text box standard asp -->
                                        <asp:TextBox CssClass="form-control" ID="TextBox1"
                                            runat="server" placeholder="Username" TextMode="Password" ReadOnly="True"></asp:TextBox>
                                    </div>
                        </div>

                    </div>
                </div>

                <a href="homepage.aspx"><< Back Home</a>

            </div>

        </div>
    </div>

</asp:Content>
