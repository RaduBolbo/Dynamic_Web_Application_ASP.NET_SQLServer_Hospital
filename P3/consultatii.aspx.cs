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
    public partial class consultatii : System.Web.UI.Page
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
                    string conditie = "consultatie.pacientid = pacient.pacientid and consultatie.medicid = medic.medicid and consultatie.medicamentid = medicamente.medicamentid";
                    string lista_atribute = "consultatieid, data, diagnostic, medic.medicid, numemedic, prenumemedic, specializare, pacient.pacientid, numepacient, prenumepacient, CNP, " +
                        "adresa, medicamente.medicamentid, denumire, dozamedicament ";
                    cmd.CommandText = "SELECT " + lista_atribute + " from consultatie, medic, pacient, medicamente where " + conditie;
                    //con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int consultatieid = reader.GetInt32(0);
                        string data = Convert.ToString(reader.GetDateTime(1));
                        string diagnostic = reader.GetString(2);
                        int medicid = reader.GetInt32(3);
                        string numemedic = reader.GetString(4);
                        string prenumemedic = reader.GetString(5);
                        string specializare = reader.GetString(6);
                        int pacientid = reader.GetInt32(7);
                        string numepacient = reader.GetString(8);
                        string prenumepacient = reader.GetString(9);
                        string CNP = reader.GetString(10);
                        string adresa = reader.GetString(11);
                        int medicamentid = reader.GetInt32(12);
                        string denumire = reader.GetString(13);
                        string dozamedicament = reader.GetString(14);
                        htmlStr += "<tr><td>" + consultatieid + "</td><td>" + data + "</td><td>" + diagnostic + "</td><td>" + medicid + "</td><td>" + numemedic + "</td><td>" + prenumemedic + "</td><td>"
                             + specializare + "</td><td>" + pacientid + "</td><td>" + numepacient + "</td><td>" + prenumepacient + "</td><td>" + CNP + "</td><td>" + adresa + "</td><td>" + medicamentid + "</td><td>"
                              + denumire + "</td><td>" + dozamedicament + "</td><td>";
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
            Response.Redirect("adaugaconsultatie.aspx");
        }

        protected void Button_modifica_Click(object sender, EventArgs e)
        {
            Response.Redirect("modificaconsultatie.aspx");
        }

        protected void Button_sterge_Click(object sender, EventArgs e)
        {
            Response.Redirect("stergeconsultatie.aspx");
        }
    }
}