using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;
using System.Configuration;

namespace P3
{
    public partial class adaugapacient : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] == null)
            {
                Button_adauga.Visible = false;
            }
        }

        protected void TextBox_nume_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void TextBox_prenume_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox_CNP_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox_adresa_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox_asigurare_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button_adauga_Click(object sender, EventArgs e)
        {
            String nume = TextBox_nume.Text;
            String prenume = TextBox_prenume.Text;
            String CNP = TextBox_CNP.Text;
            String adresa = TextBox_adresa.Text;
            String asigurare = TextBox_asigurare.Text;

            int a = 1;
            foreach (char c in CNP)
            {
                if (c < '0' || c > '9')
                    a = 0;
            }
            if (CNP.Length != 13)
            {
                a = 0;
            }

                if (a == 1){
                try
                {

                    // ABIA AICI SE CONECTEAZA LA DB, pe baza strcon
                    // se instenatiaza clasa SqlConnection, dandu-se strcon ca argument la constructyor
                    SqlConnection con = new SqlConnection(strcon);


                    if (con.State == ConnectionState.Closed)
                    {
                        // daca conerxiuneae inchisa, se condeeschide (nush exACT CE INSEMAN)
                        con.Open();
                    }
                    // acum voi introduce query-urile
                    // se va instantia SqlCommand, adica o proiectie a unei comenzi sql, in C#
                    //SqlCommand cmd = new SqlCommand("SELECT * FROM pacienti", con);
                    //SqlConnection con = new SqlConnection(strcon);
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "INSERT INTO pacient(CNP, numepacient, prenumepacient, adresa, asigurare) VALUES(@CNP, @nume, @prenume, @adresa, @asigurare)";

                    // acum abia se sefinesc valorile acxelea
                    cmd.Parameters.AddWithValue("@CNP", CNP);
                    cmd.Parameters.AddWithValue("@nume", nume);
                    cmd.Parameters.AddWithValue("@prenume", prenume);
                    cmd.Parameters.AddWithValue("@adresa", adresa);
                    cmd.Parameters.AddWithValue("@asigurare", asigurare);

                    // abia acum are loc executia efectiva a comenzii
                    SqlDataReader reader = cmd.ExecuteReader();
                    // !!!!!!!!!!!!
                    con.Close();

                    Response.Redirect("pacientadaugatcusucces.aspx");
                }

                catch (Exception ex)
                {
                    // previne blocarea
                    Response.Write("<script>alert('" + ex.Message + ")</script>");
                    System.Console.WriteLine("Nu s-a putut accesa DB");
                }
            }
            else
            {
                // daca nu e indeplinita conditia de CNP
                Response.Write("<script>alert('" + "CNP trebuiie sa aiba exact 13 cifre!" + ")</script>");
                System.Console.WriteLine("Nu s-a putut accesa DB");
            }
            

        }
    }
}