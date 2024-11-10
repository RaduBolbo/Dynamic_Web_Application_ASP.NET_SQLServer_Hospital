using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace P3
{
    public partial class adminlogin : System.Web.UI.Page
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
        protected void Button1_Click(object sender, EventArgs e)
        {
            // preiau ce e in TExtBox
            String username = TextBox1.Text;
            String password = TextBox2.Text;


            using (SHA256 sha256Hash = SHA256.Create())
            {
                password = GetHash(sha256Hash, password);

                //if (VerifyHash(sha256Hash, source, hash)) // pe asta il folosesc la login

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
                SqlCommand cmd = new SqlCommand("select * from useri_admin where username = " + "'" + username + "'" + " AND password = " + "'" + password + "'" + ";", con);


                // abia acum are loc executia efectiva a comenzii
                SqlDataReader reader = cmd.ExecuteReader();

                // verifc daca s-a gasit linia:
                if (reader.HasRows) // dacaa exista linia
                {
                    while (reader.Read())
                    {
                        // SSSSSSSSSSSSSSSSSS Vareiabile de sesiune SSSSSSSSSSSSSSSSSSSSSSSSSSSS 
                        // session var = ramane vizibila pe tot parcursul sesiunii
                        // by default, o variabila de sesiune este distrusa dupa 20min de inactivitate

                        // variabila de seiune e ca un fel de array cu indecsi strring-> ca un dictionar din python
                        Session["username"] = username;
                        // se asigneaza  si un rol user-ului
                        Session["role"] = "admin";
                        // SSSSSSSSSSSSSSSSSS Vareiabile de sesiune SSSSSSSSSSSSSSSSSSSSSSSSSSSS 

                        // se da si un mesaj de notificare, ca asa e elegant
                        Response.Write("<script>alert('" + reader.GetValue(1) + " Logat cu succes!" + "')</script>");
                        Response.Redirect("homepage.aspx");
                    }

                }
                else
                {
                    Response.Write("<script>alert('" + "Invalid Credentials" + "')</script>");

                }

                con.Close();


                // il redirectionez spre pagina de logare. Logica se sa se logheze imediat dupa CE  ADATY SIGNUP
                //Response.Redirect("userlogin.aspx");

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}