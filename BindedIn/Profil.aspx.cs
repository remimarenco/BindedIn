using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Data;
using System.Web.Security;

namespace BindedIn
{
    public partial class Profil : System.Web.UI.Page
    {
        UserProfile Profile;
        Guid UserId;

        protected void Page_Load(object sender, EventArgs e)
        {
            //editSkills.Visible = false;
            //editExp.Visible = false;
            editFormation.Visible = false;

            //Profile = UserProfile.GetUserProfile(User.Identity.Name);
            //UserId = (Guid)(Membership.GetUser(User.Identity.Name, false).ProviderUserKey);

            ////LabelNom.Text = Profile.FirstName + " " + Profile.LastName;
            //ObjectDataSourceUserProfile.SelectParameters["id"].DefaultValue = UserId.ToString();
            //ImageProfile.ImageUrl = "/ShowImage.ashx?id=" + UserId.ToString();
        }

        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            if(sender.Equals(ButtonEditSkills))
                editSkills.Visible = true;
            else if (sender.Equals(ButtonEditFormation))
                editFormation.Visible = true;
            else if (sender.Equals(ButtonEditExp))
                editExp.Visible = true;
        }


        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static string[] SuggestFormationNames(string prefixText, int count, string contextKey)
        {
            List<string> names = new List<string>();
            foreach (var item in Business.FormationService.GetFormations())
            {
                if(item.name.ToLower().Contains(prefixText.ToLower()))
                    names.Add(item.name);
            }      
                

            return names.ToArray();
        }

        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static string[] SuggestFormationDescription(string prefixText, int count, string contextKey)
        {
            List<string> descriptions = new List<string>();
            foreach (var item in Business.FormationService.GetFormations())
            {
                if (item.description.ToLower().Contains(prefixText.ToLower()))
                    descriptions.Add(item.description);
            }


            return descriptions.ToArray();
        }

        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static string[] SuggestFormationSchool(string prefixText, int count, string contextKey)
        {
            List<string> schools = new List<string>();
            foreach (var sc in Business.SchoolsService.GetSchools())
            {                
                     if (sc.name.ToLower().Contains(prefixText.ToLower()))
                            schools.Add(sc.name);         
               
            }
            return schools.ToArray();
        }

        protected void ButtonSaveFormation_Click(object sender, EventArgs e)
        {
            Business.FormationService
                .InsertNewFormation(TextBoxFormationName.Text,
                TextBoxFormationDescription.Text,
                TextBoxDateDebut.Text,
                TextBoxDateFin.Text,
                TextBoxFormationEtablissement.Text);
        }  
    }
}