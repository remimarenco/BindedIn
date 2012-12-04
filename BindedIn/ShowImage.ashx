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
using Business;

public class ShowImage : IHttpHandler 
{
    public void ProcessRequest(HttpContext context)
    {
       String idUser = null;
       int idImg = -1;
       if (context.Request.QueryString["iduser"] != null)
           idUser = context.Request.QueryString["iduser"];
       else if (context.Request.QueryString["idimg"] != null)
           idImg = Convert.ToInt32(context.Request.QueryString["idimg"]);
       else
            throw new ArgumentException("No parameter specified");

       context.Response.ContentType = "image/jpeg";
       Stream strm = (idUser == null) ? ShowEmpImage(idImg) : ShowEmpImage(idUser);
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
        return ImagesService.getCurrentImageAsStream(empno);
    }

    public Stream ShowEmpImage(int empno)
    {
        return ImagesService.getImageAsStream(empno);
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }


}