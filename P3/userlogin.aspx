<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userlogin.aspx.cs" Inherits="P3.userlogin" %>
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
                                    <img width="150px" src="imgs/user.png"/>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Logare User</h3>
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

                        <!-- acum urmeaza text-box-urile -->

                        <div class="row">
                            <div class="col">
                                <center>
                                    <label>Username</label>
                                    <!-- form-group e o clasa bootstrap pentru highlight si alte functionalitati ale text-box-ulkui -->
                                    <div class="form-group">
                                        <!-- ascum adaug un text box standard asp -->
                                        <asp:TextBox CssClass="form-control" ID="TextBox1"
                                            runat="server" placeholder="Username"></asp:TextBox>
                                    </div>

                                    <label>Password</label>
                                    <!-- form-group e o clasa bootstrap pentru highlight si alte functionalitati ale text-box-ulkui -->
                                    <div class="form-group">
                                        <!-- ascum adaug un text box standard asp -->
                                        <asp:TextBox CssClass="form-control" ID="TextBox2"
                                            runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>

                                        <p></p>

                                        <div class="form-group">
                                            <a href="usersignup.aspx"><asp:Button class="btn btn-outline-dark btn-block btn-lg" ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" /></a>

                                        </div>

                                        <div class="form-group">
                                            <a href="usersignup.aspx"><input class="btn btn-outline-dark btn-block btn-lg" id="Button2" type="button" value="Sign Up" OnClick="Button2_Click" />

                                        </div>

                                </center>
                            </div>
                        </div>


                    </div>
                </div>

                <a href="homepage.aspx"><< Back Home</a>

            </div>

        </div>
    </div>

</asp:Content>
