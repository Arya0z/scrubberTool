using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace scrubberTool
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {


            TextBox3.Text = Convert.ToString(DropDownList1.SelectedItem.Value);//.DataBind();
            TextBox2.Text = Convert.ToString(DropDownList1.SelectedItem.Text);//.DataBind();
            Button4.Enabled = false;
            TextBox2.Enabled = false;
            TextBox3.Enabled = false;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {

                string path = Path.GetFileName(FileUpload1.FileName);
                path = path.Replace(" ", "");
                FileUpload1.SaveAs(Server.MapPath("~/ExcelFile/") + path);
                String ExcelPath = Server.MapPath("~/ExcelFile/") + path;
                OleDbConnection mycon = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + ExcelPath + "; Extended Properties=Excel 8.0; Persist Security Info = False");

                mycon.Open();
                OleDbCommand cmd = new OleDbCommand("select * from [Sheet1$]", mycon);
                OleDbDataAdapter da = new OleDbDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds);
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
                mycon.Close();
                Button2.Enabled = true;

            }
            catch (Exception)
            {
                /*Response.Write("<div class=\"alert alert-danger mt-3 ms-3 w-25  alert-dismissible fade show\" role=\"alert\">\r\n  " +
                         "  \r\n  " +
                         "<button type=\"button\" class=\"btn-close\" data-bs-dismiss=\"alert\" aria-label=\"Close\">" +
                         "</button>\r\n</div>");*/
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {


                string str = TextBox3.Text;
                string[] spearator = { "," };
                string[] strArray = str.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                int[] intArray = Array.ConvertAll(strArray, s => int.Parse(s));


                string textfile = string.Empty;
                /*  foreach (TableCell tcell in GridView1.HeaderRow.Cells)
                  {
                      textfile += tcell.Text + "\t\t";
                  }*/
                // textfile += "\r\n";

                foreach (GridViewRow row in GridView1.Rows)
                {
                    int i = 0;

                    while (i < intArray.Length)


                    {
                        foreach (TableCell rowcell in row.Cells)
                        {

                            string ttt = rowcell.Text;

                            string ass = ttt.Replace("&nbsp;", "").PadRight(intArray[i]);
                            //textfile += ttt.PadRight(50);

                            textfile += ass.Substring(0, intArray[i]) + " ";
                            i++;


                        }

                    }
                    textfile += "\r\n";
                }
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition ", "attachment;filename= text.txt");
                Response.Charset = "";
                Response.ContentType = "application/text";
                Response.Output.Write(textfile);
                Response.Flush();
                Response.End();
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alertMessage();", true);
                // Response.Write(ex);
            }

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox2.Text != String.Empty && TextBox3.Text != string.Empty)
                {
                    string filename = Server.MapPath("~/FileFormatData/FileFormat.xml");
                    XmlDocument doc = new XmlDocument();
                    doc.Load(filename);
                    XmlNode RootNode = doc.SelectSingleNode("ListItems");
                    // XmlNode node = doc.CreateNode(XmlNodeType.Element, " ListItem", null);
                    XmlNode ListItem = RootNode.AppendChild(doc.CreateNode(XmlNodeType.Element, "ListItem", null));

                    XmlAttribute _text = doc.CreateAttribute("text");
                    _text.Value = TextBox2.Text;
                    XmlAttribute _value = doc.CreateAttribute("value");

                    _value.Value = TextBox3.Text;

                    ListItem.Attributes.Append(_text);
                    ListItem.Attributes.Append(_value);

                    doc.DocumentElement.AppendChild(ListItem);

                    doc.Save(filename);
                    //  doc.DataBind(filename);
                    // doc.BaseURI = Server.MapPath("~/FileFormatData/FileFormat.xml");
                    TextBox3.Text = Convert.ToString(DropDownList1.SelectedItem.Value);
                    TextBox2.Text = Convert.ToString(DropDownList1.SelectedItem.Text);
                    Response.Write("<div class=\"alert alert-success  mt-3 ms-3 w-25  alert-dismissible fade show\" role=\"alert\">\r\n  " +
                         "  New format is save\r\n  " +
                         "<button type=\"button\" class=\"btn-close\" data-bs-dismiss=\"alert\" aria-label=\"Close\">" +
                         "</button>\r\n</div>");
                }
                else
                {
                    Response.Write("<div class=\"alert alert-danger mt-3 ms-3 w-25  alert-dismissible fade show\" role=\"alert\">\r\n  " +
                        "  Feel your all details\r\n  " +
                        "<button type=\"button\" class=\"btn-close\" data-bs-dismiss=\"alert\" aria-label=\"Close\">" +
                        "</button>\r\n</div>");
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                //  Response.Write(ex);
            }

        }


        protected void XmlDataSource1_Transforming(object sender, EventArgs e)
        {

        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Button4.Enabled = true;
            TextBox2.Enabled = true;
            TextBox3.Enabled = true;
            TextBox2.Text = string.Empty;
            TextBox3.Text = string.Empty;
            TextBox2.Focus();
        }


        public void DbData()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            using (SqlCommand cmd = con.CreateCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet dsLoadData = new DataSet();
                con.Close();

            }
        }
    }
}
