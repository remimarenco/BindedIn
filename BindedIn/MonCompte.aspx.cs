using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Data;

namespace BindedIn
{
    public partial class MonCompte : System.Web.UI.Page
    {
        UserProfile Profile;
        Guid UserId;
        protected void Page_Load(object sender, EventArgs e)
        {
            Profile = UserProfile.GetUserProfile(User.Identity.Name);
            UserId = (Guid)(Membership.GetUser(User.Identity.Name, false).ProviderUserKey);
            ObjectDataSourceImage.SelectParameters["userId"].DefaultValue = UserId.ToString();
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string strImageName = Membership.GetUser(User.Identity.Name, false).ProviderUserKey.ToString();
            if (FileUpload1.PostedFile != null && FileUpload1.PostedFile.FileName != "")
            {
                byte[] imageSize = new byte [FileUpload1.PostedFile.ContentLength];
                HttpPostedFile uploadedImage = FileUpload1.PostedFile;
                uploadedImage.InputStream.Read
                   (imageSize, 0, (int)FileUpload1.PostedFile.ContentLength);

                // Create SQL Connection 
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings
                                       ["ASPNETMembership"].ConnectionString;

                // Create SQL Command 

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO Image([UserId],[Image],[Current],[Date])" +
                                  " VALUES (@UserId,@Image,@Cur,@Date)";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                SqlParameter UserId = new SqlParameter
                                    ("@UserId", SqlDbType.UniqueIdentifier);
                UserId.Value = Membership.GetUser(User.Identity.Name, false).ProviderUserKey;
                cmd.Parameters.Add(UserId);

                SqlParameter UploadedImage = new SqlParameter
                              ("@Image", SqlDbType.Image, imageSize.Length);
                UploadedImage.Value = imageSize;
                cmd.Parameters.Add(UploadedImage);

                SqlParameter Date = new SqlParameter
                                    ("@Date", SqlDbType.DateTime);
                Date.Value = DateTime.Now;
                cmd.Parameters.Add(Date);

                SqlParameter Current = new SqlParameter
                                    ("@Cur", SqlDbType.Bit);
                Current.Value = true;
                cmd.Parameters.Add(Current);

                string query = cmd.CommandText;
                foreach (SqlParameter p in cmd.Parameters)
                {
                    query = query.Replace(p.ParameterName, p.Value.ToString());
                }

                con.Open();          
                int result = cmd.ExecuteNonQuery();
                con.Close();
                if (result > 0)
                    lblMessage.Text = "File Uploaded";
            }
        }
    }
}