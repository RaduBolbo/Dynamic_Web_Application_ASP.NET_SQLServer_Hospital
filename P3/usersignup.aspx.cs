using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// pentru hash
using System.Security.Cryptography;
using System.Text;

using System.Data;

namespace P3
{
    public partial class usersignup : System.Web.UI.Page
    {
        // INSTANTIEZ CONNECTION STRING
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private static string GetHash(HashAlgorithm hashAlgorithm, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Instantiere Stringbuilder
            var sBuilder = new StringBuilder();

            // se parcurg elementele si se fac in hexa
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // se transmorma StringBuilder-ul in string
            return sBuilder.ToString();
        }

        // verifica egalitatrea dintre hash si string
        private static bool VerifyHash(HashAlgorithm hashAlgorithm, string input, string hash)
        {
            // face hash pe input
            var hashOfInput = GetHash(hashAlgorithm, input);

            // Instantiaza StringComparer  pentru a compara
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            return comparer.Compare(hashOfInput, hash) == 0;
        }

        // mai jos e metoda care defineste functionalitatea din spatele butonul;uio de signup
        protected void Button1_Click(object sender, EventArgs e)
        {
            // preiau ce e in TExtBox
            String username = TextBox1.Text;
            String password = TextBox2.Text;

            ////////////////////////////////// HASH ////////////////////////////////////////////////
            using (SHA256 sha256Hash = SHA256.Create())
            {
                password = GetHash(sha256Hash, password);

                //if (VerifyHash(sha256Hash, source, hash)) // pe asta il folosesc la login
                
            }
            ///////////////////////////////////// HASH /////////////////////////////////////////

            bool checkMemberExists()
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("SELECT * from useri_comuni where username='" + username + "';", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count >= 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                    return false;
                }
            }

            try
            {
                // voi folosi o clasa speciala pentru obiectul conexiune
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                // se va defini o comanda SQL, prin instantuierea clasei SqlCommand
                SqlCommand cmd = new SqlCommand("insert into useri_comuni VALUES(@username, @password)", con);
                //SqlCommand cmd = new SqlCommand("insert into useri_admin VALUES(@username, @password)", con); // FOLOSIT DOAR O SINGURA DATA, CAND VREAU SA BAG ADM<IN DE MANA

                // acum abia se sefinesc valorile acelea
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                // abia acum are loc executia efectiva a comenzii
                SqlDataReader reader = cmd.ExecuteReader();

                bool doesitexist = checkMemberExists();


                con.Close();
                

                // il redirectionez spre pagina de logare. Logica se sa se logheze imediat dupa CE  ADATY SIGNUP
                Response.Redirect("userlogin.aspx");

            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }





        }
    }
}