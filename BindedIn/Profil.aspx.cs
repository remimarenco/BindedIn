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
            editSkills.Visible = false;
            editExp.Visible = false;
            editFormation.Visible = false;

            if(false)
            {

            }
            else
            {
            Profile = UserProfile.GetUserProfile(User.Identity.Name);
            UserId = (Guid)(Membership.GetUser(User.Identity.Name, false).ProviderUserKey);
            }

            ObjectDataSourceUserProfile.SelectParameters["id"].DefaultValue = UserId.ToString();
            ObjectDataSourceSkillsForUser.SelectParameters["userId"].DefaultValue = UserId.ToString();
            ObjectDataSourceFormationForUser.SelectParameters["userId"].DefaultValue = UserId.ToString();
            ObjectDataSourceEXpForUser.SelectParameters["userId"].DefaultValue = UserId.ToString();
            ImageProfile.ImageUrl = "/ShowImage.ashx?iduser=" + UserId.ToString();
            // Fix cache issues
            ImageProfile.ImageUrl += "tmp=" + DateTime.Now;
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


        #region Formation

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
                TextBoxFormationEtablissement.Text,UserId);
        }

        #endregion

        #region Exp_Professionnelle


        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static string[] SuggestExpProNames(string prefixText, int count, string contextKey)
        {
            List<string> names = new List<string>();
            foreach (var item in Business.ProfessionalExpService.GetProferssionalExp())
            {
                if (item.name.ToLower().Contains(prefixText.ToLower()))
                    names.Add(item.name);
            }


            return names.ToArray();
        }


        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static string[] SuggestExpProDescription(string prefixText, int count, string contextKey)
        {
            List<string> desc = new List<string>();
            foreach (var item in Business.ProfessionalExpService.GetProferssionalExp())
            {
                if (item.description.ToLower().Contains(prefixText.ToLower()))
                    desc.Add(item.description);
            }


            return desc.ToArray();
        }


        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static string[] SuggestExpProCompanyName(string prefixText, int count, string contextKey)
        {
            List<string> names = new List<string>();
            foreach (var item in Business.CompanyService.GetCompanies())
            {
                if (item.nom.ToLower().Contains(prefixText.ToLower()))
                    names.Add(item.nom);
            }


            return names.ToArray();
        }


        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static string[] SuggestExpProCompanyAddress(string prefixText, int count, string contextKey)
        {
            List<string> adresse = new List<string>();
            foreach (var item in Business.CompanyService.GetCompanies())
            {
                if (item.adresse.ToLower().Contains(prefixText.ToLower()))
                    adresse.Add(item.adresse);
            }


            return adresse.ToArray();
        }


        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static string[] SuggestExpProCompanyTel(string prefixText, int count, string contextKey)
        {
            List<string> tel = new List<string>();
            foreach (var item in Business.CompanyService.GetCompanies())
            {
                if (item.telephone!=null && item.telephone.ToLower().Contains(prefixText.ToLower()))
                    tel.Add(item.telephone);
            }


            return tel.ToArray();
        }


        protected void ButtonSaveExpPro_Click(object sender, EventArgs e)
        {
            Business.ProfessionalExpService.InsertNewProfessionalExp(TextBoxNomExpPro.Text,
                TextBoxExpProDescription.Text,
                TextBoxDateDebutEXpPro.Text,TextBoxDateFinExpPro.Text,
                TextBoxExpProCompanyName.Text,
                TextBoxExpProCompanyAddress.Text,
                TextBoxExpProCompanyTel.Text,
                UserId);
        }

        #endregion

        #region Compétences



        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static string[] SuggestCompetenceNames(string prefixText, int count, string contextKey)
        {
            List<string> names = new List<string>();
            foreach (var item in Business.SkillService.GetSkills())
            {
                if (item.name.ToLower().Contains(prefixText.ToLower()))
                    names.Add(item.name);
            }


            return names.ToArray();
        }

        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static string[] SuggestCompetenceDescription(string prefixText, int count, string contextKey)
        {
            List<string> desc = new List<string>();
            foreach (var item in Business.SkillService.GetSkills())
            {
                if (item.description.ToLower().Contains(prefixText.ToLower()))
                    desc.Add(item.description);
            }


            return desc.ToArray();
        }

        protected void ButtonSkills_Click(object sender, EventArgs e)
        {
            Business.SkillService.InsertNewSkill(TextBoxCompeName.Text, TextBoxCompeDescription.Text, RatingNiveau.CurrentRating,UserId);
        }

        #endregion


    }
}