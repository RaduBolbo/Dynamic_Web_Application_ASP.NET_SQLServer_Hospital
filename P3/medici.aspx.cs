using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace P3
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        // in interiorul clasei instantiez un conector C#
        // deci strcon va avea valoarea egala cu string-ul "connectionString" din interiorul
        // <connectionStrings>-ul;ui "con", din fisierul Web.config cu configurari de sistem
        //ATENTIE: NU AICI SE CONECTEAZA LA DB. Se va conecta in trye-except, pe baza strcon

        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        public string getWhileLoopData()
        {
            

            // aceasta e metoda executata la incarcarea paginii.
            // Aici voi pune metodele de afisare a continutului relatiei
            // voi incerca conectarea la DB

            try
            {
                if (Session["role"] == null)
                {
                    return null;
                }
                else
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
                    string htmlStr = "";
                    //SqlConnection con = new SqlConnection(strcon);
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT * from medic";
                    //con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        //System.Console.WriteLine(id.ToString());
                        //int id = Int32.Parse(reader.GetString(0));
                        string nume = reader.GetString(1);
                        string prenume = reader.GetString(2);
                        string specializare = reader.GetString(3);
                        htmlStr += "<tr><td>" + id + "</td><td>" + nume + "</td><td>" + prenume + "</td><td>" + specializare + "</td><td>";
                    }
                    // !!!!!!!!!!!!
                    con.Close();
                    return htmlStr;
                }

                
            }

            catch (Exception ex)
            {
                // previne blocarea
                Response.Write("<script>alert('" + ex.Message + ")</script>");
                System.Console.WriteLine("Nu s-a putut accesa DB");
                return null;
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] == "admin")
            {
                Button_sterge.Visible = true;
            }
            if (Session["role"] == null)
            {
                Button_adauga.Visible = false;
                Button_modifica.Visible = false;
            }
        }



        protected void Button_adauga_Click(object sender, EventArgs e)
        {
            Response.Redirect("adaugamedic.aspx");
        }

        protected void Button_modifica_Click(object sender, EventArgs e)
        {
            Response.Redirect("modificamedic.aspx");
        }

        protected void Button_sterge_Click(object sender, EventArgs e)
        {
            Response.Redirect("stergemedic.aspx");
        }
    }
}