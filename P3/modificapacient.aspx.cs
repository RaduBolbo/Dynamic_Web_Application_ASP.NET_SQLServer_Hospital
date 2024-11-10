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
    public partial class modificapacient : System.Web.UI.Page
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
                cmd.CommandText = "SELECT * FROM pacient";


                SqlDataAdapter da = new SqlDataAdapter(cmd);
                // se creeazqa un DataSet
                DataSet ds = new DataSet();

                // EXPLIACTYIE:
                // intrucat DataSet-ul nu permite concatenarea coloanelor saua daugarea de coloane, voi
                // folosi DataTable.

                DataTable dt = new DataTable();
                da.Fill(dt);

                dt.Columns.Add("FullLine", typeof(string), "pacientid + ' ' + CNP + ' ' + numepacient + ' ' + prenumepacient + ' ' + adresa + ' ' + asigurare");

                DropDownList1.DataTextField = "FullLine";
                DropDownList1.DataValueField = "pacientid";
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

        protected void Button_modifica_Click(object sender, EventArgs e)
        {
            String selected_id = DropDownList1.SelectedItem.Value;
            //int x = Int32.Parse(selected_id);

            String list_of_modified_columns = "";
            int a = 1;

            if (TextBox_nume.Text.Length != 0)
            {
                if(list_of_modified_columns != "")
                {
                    list_of_modified_columns = list_of_modified_columns + ", ";
                }

                list_of_modified_columns = list_of_modified_columns + "numepacient = " + "'" + TextBox_nume.Text + "'";
            }

            if (TextBox_prenume.Text.Length != 0)
            {
                if (list_of_modified_columns != "")
                {
                    list_of_modified_columns = list_of_modified_columns + ", ";
                }

                list_of_modified_columns = list_of_modified_columns + "prenumepacient = " + "'" + TextBox_prenume.Text + "'";
            }

            if (TextBox_CNP.Text.Length != 0)
            {
                if (list_of_modified_columns != "")
                {
                    list_of_modified_columns = list_of_modified_columns + ", ";
                }

                foreach (char c in TextBox_CNP.Text)
                {
                    if (c < '0' || c > '9')
                        a = 0;
                }
                if (TextBox_CNP.Text.Length != 13)
                {
                    a = 0;
                }
                list_of_modified_columns = list_of_modified_columns + "CNP = " + "'" + TextBox_CNP.Text + "'";
            }

            if (TextBox_adresa.Text.Length != 0)
            {
                if (list_of_modified_columns != "")
                {
                    list_of_modified_columns = list_of_modified_columns + ", ";
                }
                

                list_of_modified_columns = list_of_modified_columns + "adresa = " + "'" + TextBox_adresa.Text + "'";
            }

            if (TextBox_asigurare.Text.Length != 0)
            {
                if (list_of_modified_columns != "")
                {
                    list_of_modified_columns = list_of_modified_columns + ", ";
                }

                list_of_modified_columns = list_of_modified_columns + "asigurare = " + "'" + TextBox_asigurare.Text + "'";
            }

            // creez diun timp textul pentru comanda
            String text_comanda = "UPDATE pacient SET " + list_of_modified_columns + " WHERE pacientid = " + selected_id + ";";

            if (a == 1)
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
                    // se va instantia SqlCommand, adica o proiectie a unei comenzi sql, in C#
                    //SqlCommand cmd = new SqlCommand("SELECT * FROM pacienti", con);
                    //SqlConnection con = new SqlConnection(strcon);
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = text_comanda;

                    // abia acum are loc executia efectiva a comenzii
                    SqlDataReader reader = cmd.ExecuteReader();
                    con.Close();

                    Response.Redirect("pacientmodificatcusucces.aspx");
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