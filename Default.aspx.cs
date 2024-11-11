using System;
using System.Web;
using System.Web.UI;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace HRMS
{
    public partial class _Default : Page
    {
        SqlConnection conn;
        int year, month,days;
        int abs;
        double insalary;
        double s;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cnf = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cnf);
            conn.Open();
            Panel1.Dispose();
            Panel1.Visible=false;
           
            month = int.Parse(DateTime.Now.Month.ToString());
            year = int.Parse(DateTime.Now.Year.ToString());
            days = DateTime.DaysInMonth(year, month);
            string q2 = $"update payslip set tdays='{days}'";
            SqlCommand cmd2 = new SqlCommand(q2, conn);
            cmd2.ExecuteNonQuery();
        }

        //protected void fetchdetails()
        //{
        //    string q = $"select * from payslip";
           
        //}
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=PaySlip.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter writer = new HtmlTextWriter(sw);
            Panel1.RenderControl(writer);
            StringReader stringReader = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
            HTMLWorker worker = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            worker.Parse(stringReader);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
        }
        protected double salary_Fun(int abs)
        {
            s = 20000.00d / days;
            double sd=(abs*s);
            insalary = Math.Round(20000.00d - sd, 2);
            return insalary;
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            int idfetch=int.Parse(TextBox1.Text);
            
            string q = $"select * from payslip where userid= '{idfetch}'";
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataReader r = cmd.ExecuteReader();
            if(r.HasRows)
            {
            Panel1.Visible = true;
            r.Read();
            Label2.Text = r["userid"].ToString();
           
            Label1.Text = r["present"].ToString();
                abs = int.Parse(r["absent"].ToString());
                Label3.Text =abs.ToString();
                Label5.Text=salary_Fun(abs).ToString();


                Label4.Text = days.ToString();
                //Label5.Text = r["salary"].ToString();
             
            }
        }
    }
}