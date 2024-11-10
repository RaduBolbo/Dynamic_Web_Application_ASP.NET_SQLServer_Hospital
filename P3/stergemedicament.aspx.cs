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
    public partial class stergemedicament : System.Web.UI.Page
    {
        // aici adaug obiec tul connectionstring, pe baza celuid efinit in Web.config
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            // voi pune inm Page_Load codul care incarca liniil;e in DropDown

            if (Session["role"] == null)
            {
                Button_adauga.Visible = false;
            }
            else
            {
                if (!IsPostBack)
                {
                    dropdown();
                    if (Session["role"] == null)
                    {
                        Button_adauga.Visible = false;
                    }
                }
            }

        }

        protected void dropdown()
        {
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
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM medicamente";


                SqlDataAdapter da = new SqlDataAdapter(cmd);
                // se creeazqa un DataSet
                DataSet ds = new DataSet();

                // EXPLIACTYIE:
                // intrucat DataSet-ul nu permite concatenarea coloanelor saua daugarea de coloane, voi
                // folosi DataTable.

                DataTable dt = new DataTable();
                da.Fill(dt);

                dt.Columns.Add("FullLine", typeof(string), "medicamentid + ' ' + denumire");

                DropDownList1.DataTextField = "FullLine";
                DropDownList1.DataValueField = "medicamentid";
                DropDownList1.DataSource = dt;

                //DropDownList1.DataValueField = ds.Tables[0].Columns["pacientid"].ToString();
                // to retrive specific  textfield name   
                //DropDownList1.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
                DropDownList1.DataBind();  //binding dropdownlist


                con.Close();

            }

            catch (Exception ex)
            {
                // previne blocarea
                Response.Write("<script>alert('" + ex.Message + ")</script>");
                System.Console.WriteLine("Nu s-a putut accesa DB");
            }
        }

        protected void Button_sterge_Click(object sender, EventArgs e)
        {
            String selected_id = DropDownList1.SelectedItem.Value;
            //int x = Int32.Parse(selected_id);

            // creez diun timp textul pentru comanda
            String text_comanda = "DELETE FROM medicamente WHERE medicamentid = " + selected_id + ";";

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
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = text_comanda;

                // abia acum are loc executia efectiva a comenzii
                SqlDataReader reader = cmd.ExecuteReader();
                con.Close();

                Response.Redirect("medicamentsterscusucces.aspx");
            }
            catch (Exception ex)
            {
                // previne blocarea
                Response.Write("<script>alert('" + ex.Message + ")</script>");
                System.Console.WriteLine("Nu s-a putut accesa DB");
            }
        }
    }
}