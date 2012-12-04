<%@ WebHandler Language="C#" Class="ShowImage" %>

/**
 * Original Author: Suprotim Agarwal
 * Source: http://www.dotnetcurry.com/ShowArticle.aspx?ID=129
 **/ 

using System;
using System.Configuration;
using System.Web;
using System.IO;
using System.Data;
using System.Data.SqlClient;

public class ShowImage : IHttpHandler 
{
    public void ProcessRequest(HttpContext context)
    {
       String empno;
       if (context.Request.QueryString["id"] != null)
            empno = context.Request.QueryString["id"];
       else
            throw new ArgumentException("No parameter specified");

       context.Response.ContentType = "image/jpeg";
       Stream strm = ShowEmpImage(empno);
       byte[] buffer = new byte[4096];
       int byteSeq = strm.Read(buffer, 0, 4096);

       while (byteSeq > 0)
       {
           context.Response.OutputStream.Write(buffer, 0, byteSeq);
           byteSeq = strm.Read(buffer, 0, 4096);
       }        
       //context.Response.BinaryWrite(buffer);
    }

    public Stream ShowEmpImage(String empno)
    {
        string conn = ConfigurationManager.ConnectionStrings["ASPNETMembership"].ConnectionString;
        SqlConnection connection = new SqlConnection(conn);
        string sql = "SELECT Image FROM Image WHERE UserId = @ID AND [Current] = @Current";
        SqlCommand cmd = new SqlCommand(sql,connection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("@ID", empno);
        cmd.Parameters.AddWithValue("@Current", true);
        connection.Open();
        object img = cmd.ExecuteScalar();
        try
        {
            return new MemoryStream((byte[])img);
        }
        catch 
        {
            return File.OpenRead(System.Web.HttpContext.Current.Server.MapPath("/Images/140x140.gif"));
        }
        finally
        {
            connection.Close();
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }


}