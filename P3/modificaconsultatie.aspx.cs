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
    
    public partial class modificaconsultatie : System.Web.UI.Page
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
                string conditie = "consultatie.pacientid = pacient.pacientid and consultatie.medicid = medic.medicid and consultatie.medicamentid = medicamente.medicamentid";
                string lista_atribute = "consultatieid, data, diagnostic, medic.medicid, numemedic, prenumemedic, specializare, pacient.pacientid, numepacient, prenumepacient, CNP, " +
                    "adresa, medicamente.medicamentid, denumire, dozamedicament ";
                cmd.CommandText = "SELECT " + lista_atribute + " from consultatie, medic, pacient, medicamente where " + conditie;


                SqlDataAdapter da = new SqlDataAdapter(cmd);
                // se creeazqa un DataSet
                DataSet ds = new DataSet();

                // EXPLIACTYIE:
                // intrucat DataSet-ul nu permite concatenarea coloanelor saua daugarea de coloane, voi
                // folosi DataTable.

                DataTable dt = new DataTable();
                da.Fill(dt);

                dt.Columns.Add("FullLine", typeof(string), "consultatieid + ' ' + data + ' ' + diagnostic + ' ' + medicid + ' ' + 'numemedic'  + ' ' + prenumemedic " +
                    "+ ' ' + specializare + ' ' + pacientid + ' ' + numepacient + ' ' + prenumepacient + ' ' + CNP" +
                    "+ ' ' + adresa + ' ' + medicamentid + ' ' + denumire + ' ' + dozamedicament");

                DropDownList1.DataTextField = "FullLine";
                DropDownList1.DataValueField = "consultatieid";
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

        protected void TextBox_specializare_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button_modifica_Click(object sender, EventArgs e)
        {
            String selected_id = DropDownList1.SelectedItem.Value;
            //int x = Int32.Parse(selected_id);

            String list_of_modified_columns = "";

            if (TextBox_idmedic.Text.Length != 0)
            {
                if (list_of_modified_columns != "")
                {
                    list_of_modified_columns = list_of_modified_columns + ", ";
                }

                list_of_modified_columns = list_of_modified_columns + "medicid = " + "'" + TextBox_idmedic.Text + "'";
            }

            if (TextBox_pacientid.Text.Length != 0)
            {
                if (list_of_modified_columns != "")
                {
                    list_of_modified_columns = list_of_modified_columns + ", ";
                }

                list_of_modified_columns = list_of_modified_columns + "pacientid = " + "'" + TextBox_pacientid.Text + "'";
            }

            if (TextBox_medicamentid.Text.Length != 0)
            {
                if (list_of_modified_columns != "")
                {
                    list_of_modified_columns = list_of_modified_columns + ", ";
                }

                list_of_modified_columns = list_of_modified_columns + "medicamentid = " + "'" + TextBox_medicamentid.Text + "'";
            }
            if (TextBox_data.Text.Length != 0)
            {
                if (list_of_modified_columns != "")
                {
                    list_of_modified_columns = list_of_modified_columns + ", ";
                }

                list_of_modified_columns = list_of_modified_columns + "data = " + "'" + TextBox_data.Text + "'";
            }
            if (TextBox_diagnostic.Text.Length != 0)
            {
                if (list_of_modified_columns != "")
                {
                    list_of_modified_columns = list_of_modified_columns + ", ";
                }

                list_of_modified_columns = list_of_modified_columns + "diagnostic = " + "'" + TextBox_diagnostic.Text + "'";
            }
            if (TextBox_doza.Text.Length != 0)
            {
                if (list_of_modified_columns != "")
                {
                    list_of_modified_columns = list_of_modified_columns + ", ";
                }

                list_of_modified_columns = list_of_modified_columns + "dozamedicament = " + "'" + TextBox_doza.Text + "'";
            }

            // creez diun timp textul pentru comanda
            String text_comanda = "UPDATE consultatie SET " + list_of_modified_columns + " WHERE consultatieid = " + selected_id + ";";

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

                Response.Redirect("consultatiemodificatacusucces.aspx");
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