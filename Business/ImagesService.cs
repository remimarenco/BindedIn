using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Business
{
    public class ImagesService
    {
        public static List<Image> GetCurrentImages()
        {
            bindedinEntities bie = SingletonEntities.Instance;
            var retour = from i in bie.Images
                         where i.Current.Equals(true)
                            select i;
            return retour.ToList();
        }

        public static List<Image> GetAllImages()
        {
            bindedinEntities bie = SingletonEntities.Instance;
            var retour = from i in bie.Images
                         select i;
            return retour.ToList();
        }

        public static List<Image> GetCurrentImages(Guid userId)
        {
            bindedinEntities bie = SingletonEntities.Instance;
            var retour = from i in bie.Images
                         where i.UserId.Equals(userId)
                         where i.Current.Equals(true)
                         select i;
            
            return retour.ToList();
        }

        public static List<Image> GetAllImages(Guid userId)
        {
            bindedinEntities bie = SingletonEntities.Instance;

            var retour = from i in bie.Images
                         orderby i.Current descending, i.Date descending
                         where i.UserId.Equals(userId)
                         select i;
            //retour.OrderBy(i => i.Current).ThenBy(i => i.Date);
            
           
            return retour.ToList();
        }

        public static Stream getCurrentImageAsStream(string userId)
        {
            string conn = ConfigurationManager.ConnectionStrings["ASPNETMembership"].ConnectionString;
            SqlConnection connection = new SqlConnection(conn);
            string sql = "SELECT Image FROM Image WHERE UserId = @UserID AND [Current] = @Current";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@UserID", userId);
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

        public static Stream getImageAsStream(int idimg)
        {
            string conn = ConfigurationManager.ConnectionStrings["ASPNETMembership"].ConnectionString;
            SqlConnection connection = new SqlConnection(conn);
            string sql = "SELECT Image FROM Image WHERE id = @id";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@id", idimg);
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
    }
}
