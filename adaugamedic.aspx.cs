using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace P3
{
    public partial class adaugamedic : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] == null)
            {
                Button_adauga.Visible = false;
            }
        }

        protected void Button_adauga_Click(object sender, EventArgs e)
        {
            String nume = TextBox_nume.Text;
            String prenume = TextBox_prenume.Text;
            String specializare = TextBox_specializare.Text;

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
                cmd.CommandText = "INSERT INTO medic(numemedic, prenumemedic, specializare) VALUES(@nume, @prenume, @specializare)";

                // acum abia se sefinesc valorile acxelea
                cmd.Parameters.AddWithValue("@nume", nume);
                cmd.Parameters.AddWithValue("@prenume", prenume);
                cmd.Parameters.AddWithValue("@specializare", specializare);

                // abia acum are loc executia efectiva a comenzii
                SqlDataReader reader = cmd.ExecuteReader();
                // !!!!!!!!!!!!
                con.Close();

                Response.Redirect("medicadaugatcusucces.aspx");
            }

            catch (Exception ex)
            {
                // previne blocarea
                Response.Write("<script>alert('" + ex.Message + ")</script>");
                System.Console.WriteLine("Nu s-a putut accesa DB");
            }
        }

        protected void TextBox_nume_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox_prenume_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox_specializare_TextChanged(object sender, EventArgs e)
        {

        }
    }
}