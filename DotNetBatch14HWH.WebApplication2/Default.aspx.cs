using DotNetBatch14HWH.WebApplication2.ConnectionString;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNetBatch14HWH.WebApplication2
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadRecord();
            }
        }

        protected void InsertBtn_Click(object sender, EventArgs e)
        {
            string studentId = TextBox1.Text.Trim();
            string studentName = TextBox2.Text.Trim();
            string address = DropDownList1.SelectedValue.ToString();
            int age = Convert.ToInt32(TextBox3.Text);
            string contact = TextBox4.Text.Trim();
            string query = "INSERT INTO StudentInfo (StudentId, StudentName, Address, Age, Contact) VALUES (@ID, @Name, @Address, @Age, @Contact)";

            using (SqlConnection con = new SqlConnection(AppConnectionString.sqlConnectionStringBuilder.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Adding parameters to the command
                    cmd.Parameters.AddWithValue("@Id", studentId);
                    cmd.Parameters.AddWithValue("@Name", studentName);
                    cmd.Parameters.AddWithValue("@Age", age);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@Contact", contact);

                    // Open connection
                    con.Open();

                    // Execute the query
                    cmd.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Inserted Successfully');", true);
                    // Close connection (automatically closed when using block ends)

                    LoadRecord();
                }
            }
        }

        protected void LoadRecord()
        {
            string query = "select * from StudentInfo";
            using (SqlConnection con = new SqlConnection(AppConnectionString.sqlConnectionStringBuilder.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Open connection
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
        }

        protected void UpdateBtnClick(object sender, EventArgs e)
        {
            string studentId = TextBox1.Text.Trim();
            string studentName = TextBox2.Text.Trim();
            string address = DropDownList1.SelectedValue.ToString();
            int age = Convert.ToInt32(TextBox3.Text);
            string contact = TextBox4.Text.Trim();

            string query = "UPDATE StudentInfo SET StudentName = @Name, Address = @Address, Age = @Age, Contact = @Contact WHERE StudentId = @Id;";

            using (SqlConnection con = new SqlConnection(AppConnectionString.sqlConnectionStringBuilder.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Adding parameters to the command
                    cmd.Parameters.AddWithValue("@Id", studentId);
                    cmd.Parameters.AddWithValue("@Name", studentName);
                    cmd.Parameters.AddWithValue("@Age", age);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@Contact", contact);

                    // Open connection
                    con.Open();

                    // Execute the query
                    cmd.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Updated Successfully');", true);

                    // Reload updated records
                    LoadRecord();
                }
            }

        }

        protected void DeleteBtnClick(object sender, EventArgs e)
        {
            string studentId = TextBox1.Text.Trim();

            string query = "DELETE FROM StudentInfo WHERE StudentId = @Id;";

            using (SqlConnection con = new SqlConnection(AppConnectionString.sqlConnectionStringBuilder.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Adding parameters to the command
                    cmd.Parameters.AddWithValue("@Id", studentId);

                    // Open connection
                    con.Open();

                    // Execute the query
                    cmd.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Deleted Successfully');", true);

                    // Reload updated records
                    LoadRecord();
                }
            }
        }

        protected void SearchBtnClick(object sender, EventArgs e)
        {
            string studentId = TextBox1.Text.Trim();

            string query = "SELECT * FROM StudentInfo WHERE StudentId = @Id;";

            using (SqlConnection con = new SqlConnection(AppConnectionString.sqlConnectionStringBuilder.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Adding parameters to the command
                    cmd.Parameters.AddWithValue("@Id", studentId);

                    // Open connection
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
        }

        protected void GetBtnClick(object sender, EventArgs e)
        {
            string studentId = TextBox1.Text.Trim();
            string query = "SELECT * FROM StudentInfo WHERE StudentId = @Id;";

            using (SqlConnection con = new SqlConnection(AppConnectionString.sqlConnectionStringBuilder.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Adding parameters to the command
                    cmd.Parameters.AddWithValue("@Id", studentId);

                    // Open connection
                    con.Open();
                    SqlDataReader r = cmd.ExecuteReader();

                    while (r.Read()) 
                    {
                        TextBox2.Text = r.GetValue(1).ToString();
                        DropDownList1.SelectedValue = r.GetValue(2).ToString();
                        TextBox3.Text = r.GetValue(3).ToString();                        
                        TextBox4.Text = r.GetValue(4).ToString();
                    }

                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/ms-excel"; ;
            Response.AddHeader("content-disposition", "attachment; filename=studentinfo.xls");
            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter writer = new HtmlTextWriter(stringWriter);
            GridView1.RenderControl(writer);
            Response.Output.Write(stringWriter.ToString());
            Response.End();

        }
        protected void PrintPDF_Click(object sender, EventArgs e)
        {
            //Response.Clear();
            //Response.Buffer = true;
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment; filename=studnet.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache); 
            StringWriter writer = new StringWriter();
            HtmlTextWriter htmlTextWriter = new HtmlTextWriter(writer);
            GridView1.RenderControl(htmlTextWriter);
            Document doc = new Document(PageSize.A4,50f,50f,30f,30f);
            HTMLWorker hTMLWorker = new HTMLWorker(doc);
            PdfWriter.GetInstance(doc, Response.OutputStream);
            doc.Open();
            StringReader sr = new StringReader(writer.ToString());
            hTMLWorker.Parse(sr);
            doc.Close();
            Response.Write(doc);
            Response.End();

        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        }

        
    }
    
}