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
                         && i.Current == true
                         select i;

            if (retour.Count() > 0)
                return retour.ToList();
            return null;
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

        public static List<Image> GetImage(int imgId)
        {
            bindedinEntities bie = SingletonEntities.Instance;
            var retour = from i in bie.Images
                         where i.id.Equals(imgId)
                         select i;
            if (retour.Count() > 0)
                return retour.ToList();
            return null;
        }

        public static void setImageAsCurrent(int idImg, Guid userId)
        {
            List<Image> l;
            if ((l = GetCurrentImages(userId)) != null)
            {
                Image curImg = l.First();
                curImg.Current = false;
            }
            Image newCurImg = GetImage(idImg).First();
            newCurImg.Current = true;

            SingletonEntities.Instance.SaveChanges();
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

        public static int addNewImage(Guid userId, Byte[] image)
        {
            bindedinEntities bie = SingletonEntities.Instance;

            Image newImg = new Image
            {
                UserId = userId,
                Image1 = image,
                Date = DateTime.Now,
            };
            bie.AddToImages(newImg);
            bie.SaveChanges();

            setImageAsCurrent(newImg.id, userId);
            return newImg.id;
        }

        public static void deleteImage(int idImg, Guid userId)
        {
            bindedinEntities bie = SingletonEntities.Instance;

            var retour = from i in bie.Images
                         where i.id.Equals(idImg)
                         && i.UserId.Equals(userId)
                         select i;
            foreach (Image img in retour)
            {
                bie.Images.DeleteObject(img);
            }
            bie.SaveChanges();
        }
    }
}
