using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class ado_01 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        ShowMembers();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        //註解：第一、連結SQL資料庫
        SqlConnection Conn = new SqlConnection("Data Source=AA201-14\\SQLEXPRESS;Initial Catalog=NORTHWND;User ID=test;Password=test");
        Conn.Open();

        //註解：第二、執行SQL指令，使用ExecuteNonQuery
        SqlCommand cmd = new SqlCommand("Insert Into Member (mId,pId,name,birthday,phone,address,email,introducer) " +
            "Values ('d0000001', 'A123456789','John', '1980-03-31 00:00:00.000','07-5321140','新北市中山路號','john33@gmail.com', NULL) ", Conn);
        cmd.ExecuteNonQuery();

        //註解：第四、關閉資源
        cmd.Dispose();
        Conn.Close();
        Conn.Dispose();
        ShowMembers();
    }

    protected void ShowMembers()
    {
        Response.Write("Member資料表 <br>");
        //註解：第一、連結SQL資料庫
        SqlConnection Conn = new SqlConnection("Data Source=AA201-14\\SQLEXPRESS;Initial Catalog=NORTHWND;User ID=test;Password=test");
        Conn.Open();

        //註解：第二、執行SQL指令，使用DataReader
        SqlCommand cmd = new SqlCommand("Select top 5 * From Employees", Conn);
        SqlDataReader dr = cmd.ExecuteReader();
        int i;
        //註解：第三、自由發揮
        while(dr.Read())
        {
            Response.Write("FirstName：" + dr["FirstName"].ToString() + "<br>");
            Response.Write("LastName：" + dr["LastName"].ToString() + "<br>");
            Response.Write("Title：" + dr["Title"].ToString());
            Response.Write("<hr>");
        }

        //註解：第四、關閉資源
        cmd.Dispose();
        dr.Close();
        Conn.Close();
        Conn.Dispose();
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        //註解：第一、連結SQL資料庫
        SqlConnection Conn = new SqlConnection("Data Source=AA201-14\\SQLEXPRESS;Initial Catalog=NORTHWND;User ID=test;Password=test");
        Conn.Open();

        //註解：第二、執行SQL指令，使用ExecuteNonQuery
        SqlCommand cmd = new SqlCommand("Update Member Set name='Jason', phone='04-1234567' Where mId='d0000001' ", Conn);
        cmd.ExecuteNonQuery();

        //註解：第四、關閉資源
        cmd.Dispose();
        Conn.Close();
        Conn.Dispose();
        ShowMembers();
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        //註解：第一、連結SQL資料庫
        SqlConnection Conn = new SqlConnection("Data Source=AA201-14\\SQLEXPRESS;Initial Catalog=NORTHWND;User ID=test;Password=test");
        Conn.Open();

        //註解：第二、執行SQL指令，使用ExecuteNonQuery
        SqlCommand cmd = new SqlCommand("Delete From Member Where mId='d0000001' ", Conn);
        cmd.ExecuteNonQuery();

        //註解：第四、關閉資源
        cmd.Dispose();
        Conn.Close();
        Conn.Dispose();
        ShowMembers();
    }
}