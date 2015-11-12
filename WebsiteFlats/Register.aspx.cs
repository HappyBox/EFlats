using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using WcfEFlatsService;
using System.Runtime.Serialization;




public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       // Response.Write("Prob1");
        // if (IsPostBack)
        // {
        //   SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dmaj0914_2Sem_4ConnectionString"].ConnectionString);
        // conn.Open();
        //      string checkuser = "select count(*) from LD_Main where Email='"+ TextBox1.Text+"'";
        //      SqlCommand com = new SqlCommand(checkuser, conn);
        //     int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
        //      if(temp ==1)
        //      {
        //          Response.Write("Email already exists");
        //      }
        //      conn.Close();
        //   }


    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Write("Prob1");

       // if (IsPostBack)
       // {
           // try
           // {
                if (StudentOrLandlord.SelectedValue == "2")
                {
            Response.Write("Prob2");
            WcfEFlatsServiceReference.WcfEFlatsServiceClient client = new WcfEFlatsServiceReference.WcfEFlatsServiceClient();
                    client.AddLandlord(TextBox1.Text, TextBox2.Text, false, System.DateTime.Now, TextBox5.Text, TextBox7.Text, TextBox9.Text, TextBox11.Text, TextBox13.Text, TextBox15.Text, TextBox17.Text);
            Response.Write("Prob2.1");
        }


                else
                {
            Response.Write("Prob3");
        }




           // }

          //  catch (Exception ex)
          //  {
            //    Response.Write("Error " + ex.ToString());
          //  }
      //  }
    }









            //  if (IsPostBack)
            //  {
            //     try {
            //        if (StudentOrLandlord.SelectedValue == "2")
            //         {
            //

            //
            //                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dmaj0914_2Sem_4ConnectionString"].ConnectionString);
            //                conn.Open();
            //
            //                string insertQuery = "insert into LD_Main (Email, Password) values (@email, @password)";
            //                string insertQuery2 = "insert into LD_Personal (Name, Surname, Address, PostCode, City, Country, Phone) values (@name, @surname, @address, @postcode, @city, @country, @phone)";
            //     string insertQuery3 = "insert into LD_Queue (DateOfCreation) values (@dateOfCreation)";

            //                SqlCommand com = new SqlCommand(insertQuery, conn);
            //                SqlCommand com2 = new SqlCommand(insertQuery2, conn);
            //     SqlCommand com3 = new SqlCommand(insertQuery3, conn);


            //                com.Parameters.AddWithValue("@email", TextBox1.Text);
            //                com.Parameters.AddWithValue("@password", TextBox2.Text);
            //                com2.Parameters.AddWithValue("@name", TextBox5.Text);
            //                com2.Parameters.AddWithValue("@surname", TextBox7.Text);
            //                com2.Parameters.AddWithValue("@address", TextBox9.Text);
            //                com2.Parameters.AddWithValue("@postcode", TextBox11.Text);
            //                com2.Parameters.AddWithValue("@city", TextBox13.Text);
            //                com2.Parameters.AddWithValue("@country", TextBox15.Text);
            //                com2.Parameters.AddWithValue("@phone", TextBox17.Text);
            //  com3.Parameters.AddWithValue("@email", TextBox1.Text);

            //                    com.ExecuteNonQuery();
            //                    com2.ExecuteNonQuery();
            // com3.ExecuteNonQuery();


            //                    Response.Redirect("Login.aspx");
            //                    Response.Write("Registration successfull! :)");

            //                    conn.Close();
            //
            //                }
            //                else
            //               {

            //
            //               }

            //           }
            //           catch(Exception ex)
            //          {
            //              Response.Write("Error " + ex.ToString());
            //         }
            //
            //
            //       }
       // }

    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void StudentOrLandlord_SelectedIndexChanged(object sender, EventArgs e)
    {
    
        if (StudentOrLandlord.SelectedValue == "0")
        {
            TextBox4.Visible = false;
            TextBox5.Visible = false;
            TextBox6.Visible = false;
            TextBox7.Visible = false;
            TextBox8.Visible = false;
            TextBox9.Visible = false;
            TextBox10.Visible = false;
            TextBox11.Visible = false;
            TextBox12.Visible = false;
            TextBox13.Visible = false;
            TextBox14.Visible = false;
            TextBox15.Visible = false;
            TextBox16.Visible = false;
            TextBox17.Visible = false;


            Label1.Visible = false;
            Label2.Visible = false;
            Label3.Visible = false;
            Label4.Visible = false;
            Label5.Visible = false;
            Label6.Visible = false;
            Label7.Visible = false;
        }
        else if (StudentOrLandlord.SelectedValue == "1")
        {
            TextBox5.Visible = true;
            TextBox7.Visible = true;
            TextBox9.Visible = true;
            TextBox11.Visible = true;
            TextBox13.Visible = true;
            TextBox15.Visible = true;
            TextBox17.Visible = true;

            TextBox4.Visible = false;
            TextBox6.Visible = false;
            TextBox8.Visible = false;
            TextBox10.Visible = false;
            TextBox12.Visible = false;
            TextBox14.Visible = false;
            TextBox16.Visible = false;

            Label1.Visible = true;
            Label2.Visible = true;
            Label3.Visible = true;
            Label4.Visible = true;
            Label5.Visible = true;
            Label6.Visible = true;
            Label7.Visible = true;

        }
        else
        {
            TextBox4.Visible = true;
            TextBox6.Visible = true;
            TextBox8.Visible = true;
            TextBox10.Visible = true;
            TextBox12.Visible = true;
            TextBox14.Visible = true;
            TextBox16.Visible = true;

            TextBox5.Visible = false;
            TextBox7.Visible = false;
            TextBox9.Visible = false;
            TextBox11.Visible = false;
            TextBox13.Visible = false;
            TextBox15.Visible = false;
            TextBox17.Visible = false;

            Label1.Visible = true;
            Label2.Visible = true;
            Label3.Visible = true;
            Label4.Visible = true;
            Label5.Visible = true;
            Label6.Visible = true;
            Label7.Visible = true;
        }
    }
}
