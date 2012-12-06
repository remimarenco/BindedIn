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
        Boolean self;

        protected void Page_Load(object sender, EventArgs e)
        {
            editExp.Visible = false;
            editFormation.Visible = false;
            editSkills.Visible = false;
            string idParam = Request.Params["id"];
            string userIdParam = Request.Params["userId"];
            
            if (idParam != null && Membership.GetUser(Request.Params["id"], false) != null)
            {
                Profile = UserProfile.GetUserProfile(Request.Params["id"]);
                UserId = (Guid)(Membership.GetUser(Request.Params["id"], false).ProviderUserKey);
                ShowEditButtons(false);
                if(Business.RelationService.isInRelationWith(Request.Params["id"]) == 3)
                {
                    showConnectionButton(deconnectionButton);
                }
                else if (Business.RelationService.isInRelationWith(Request.Params["id"]) == 1)
                {
                    showConnectionButton(waitingButton);
                }
                else
                {
                    showConnectionButton(connectionButton);
                }
                self = false;
            }
            else if (userIdParam != null && Membership.GetUser(Request.Params["userId"], false) != null)
            {
                Profile = UserProfile.GetUserProfile(Business.UserService.GetUtilisateurById(Guid.Parse(Request.Params["userId"])).UserName);
                UserId = Guid.Parse(Request.Params["userId"]);
                ShowEditButtons(false);

                if (Business.RelationService.isInRelationWith(Request.Params["id"]) == 3)
                {
                    showConnectionButton(deconnectionButton);
                }
                else if (Business.RelationService.isInRelationWith(Request.Params["id"]) == 1)
                {
                    showConnectionButton(waitingButton);
                }
                else
                {
                    showConnectionButton(connectionButton);
                }

                self = false;
            }
            else
            {
                Profile = UserProfile.GetUserProfile(User.Identity.Name);
                UserId = (Guid)(Membership.GetUser(User.Identity.Name, false).ProviderUserKey);
                ShowEditButtons(true);
                showConnectionButton(null);
                connectionButton.Visible = false;
                self = true;
            }

            ObjectDataSourceUserProfile.SelectParameters["id"].DefaultValue = UserId.ToString();
            ObjectDataSourceSkillsForUser.SelectParameters["userId"].DefaultValue = UserId.ToString();
            ObjectDataSourceFormationForUser.SelectParameters["userId"].DefaultValue = UserId.ToString();
            ObjectDataSourceProferssionalExpCompanies.SelectParameters["userId"].DefaultValue = UserId.ToString();
            ObjectDataSourceRecommandation.SelectParameters["userId"].DefaultValue = UserId.ToString();
            ImageProfile.ImageUrl = "/ShowImage.ashx?iduser=" + UserId.ToString();
            // Fix cache issues
            ImageProfile.ImageUrl += "&tmp=" + DateTime.Now;
            Repeater1.ItemDataBound += new RepeaterItemEventHandler(Repeater1_ItemDataBound);
            RepeaterFormation.ItemDataBound += new RepeaterItemEventHandler(RepeaterFormation_ItemDataBound);
            Repeater2.ItemDataBound += new RepeaterItemEventHandler(Repeater2_ItemDataBound);
            Repeater3.ItemDataBound += new RepeaterItemEventHandler(Repeater3_ItemDataBound);
        }

        void Repeater2_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            ShowEditionControls(e);
        }

        void RepeaterFormation_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            ShowEditionControls(e);
        }

        void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            ShowEditionControls(e);
        }

        void showConnectionButton(Button buttonToShow)
        {
            connectionButton.Visible = false;
            deconnectionButton.Visible = false;
            waitingButton.Visible = false;

            if (buttonToShow != null)
            {
                buttonToShow.Visible = true;
            }
        }

        void Repeater3_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            e.Item.FindControl("messages_links").Visible = (!self);
        }      

        private void ShowEditButtons(bool b)
        {
            ButtonEditExp.Visible = b;
            ButtonEditFormation.Visible = b;
            ButtonEditSkills.Visible = b;            
        }

        private void ShowEditionControls(RepeaterItemEventArgs e)
        {
           // string idParam = Request.Params["id"];
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                foreach (Control c in e.Item.Controls)
                {
                    if (c is Button)
                    {
                        // Grab label
                        Button btn = c as Button;
                        if (!self)
                            btn.Visible = false;
                        else
                            btn.Visible = true;
                    }
                    else if (c is LinkButton)
                    {
                        // Grab label
                        LinkButton btn = c as LinkButton;
                        if (!self)
                            btn.Visible = false;
                        else
                            btn.Visible = true;
                    }
                }
            }    
        }

        private void MessageBox(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                Response.Write("<script type=\"text/javascript\" language=\"javascript\">");
                Response.Write("alert('" + message + "');");
                Response.Write("</script>");
            }
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

        private void RazFormationFormFields()
        {
            TextBoxFormationDescription.Text = string.Empty;
            TextBoxFormationEtablissement.Text = string.Empty;
            TextBoxFormationName.Text = string.Empty;
            TextBoxDateDebut.Text = string.Empty;
            TextBoxDateFin.Text = string.Empty;
        }

        private bool ValidateFormationFormFields()
        {
            if (
                TextBoxFormationDescription.Text != string.Empty &&
                TextBoxFormationEtablissement.Text != string.Empty &&
                TextBoxFormationName.Text != string.Empty &&
                TextBoxDateDebut.Text != string.Empty &&
                TextBoxDateFin.Text != string.Empty)
                return true;
            else
                return false;
        }

        protected void ButtonSaveFormation_Click(object sender, EventArgs e)
        {
            if (ValidateFormationFormFields())
            {
                Business.FormationService
                    .InsertNewFormation(TextBoxFormationName.Text,
                    TextBoxFormationDescription.Text,
                    TextBoxDateDebut.Text,
                    TextBoxDateFin.Text,
                    TextBoxFormationEtablissement.Text, UserId);
                ObjectDataSourceFormationForUser.Update();
                RazFormationFormFields();
            }
            else
                MessageBox("Les champs Nom, Description, Etablissement, et les dates de début et fin doivent etre saisies");
        }
        protected void ButtonDeleteFormation_Click(object sender, EventArgs e)
        {
            Button but = (Button)sender;
            Business.FormationService.Remove(but.CommandArgument, UserId);

            ObjectDataSourceFormationForUser.Update();
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
        private void RazExpProFormFields()
        {
            TextBoxExpProCompanyAddress.Text = string.Empty;
            TextBoxExpProCompanyName.Text = string.Empty;
            TextBoxExpProCompanyTel.Text = string.Empty;
            TextBoxExpProDescription.Text = string.Empty;
            TextBoxDateFinExpPro.Text = string.Empty;
            TextBoxDateDebutEXpPro.Text = string.Empty;
            TextBoxNomExpPro.Text = string.Empty;
        }

        private bool ValidateExpProFormFields()
        {
            if (
                TextBoxExpProCompanyAddress.Text != string.Empty &&
                TextBoxExpProCompanyName.Text != string.Empty &&
                TextBoxExpProDescription.Text != string.Empty &&
                TextBoxDateFinExpPro.Text != string.Empty &&
                TextBoxDateDebutEXpPro.Text != string.Empty &&
                TextBoxNomExpPro.Text != string.Empty)
                return true;
            else
                return false;
        }
        protected void ButtonSaveExpPro_Click(object sender, EventArgs e)
        {
            if (ValidateExpProFormFields())
            {
                Business.ProfessionalExpService.InsertNewProfessionalExp(TextBoxNomExpPro.Text,
                    TextBoxExpProDescription.Text,
                    TextBoxDateDebutEXpPro.Text, TextBoxDateFinExpPro.Text,
                    TextBoxExpProCompanyName.Text,
                    TextBoxExpProCompanyAddress.Text,
                    TextBoxExpProCompanyTel.Text,
                    UserId);

                ObjectDataSourceProferssionalExpCompanies.Update();
                RazExpProFormFields();
            }
            else
                MessageBox("Les champs Nom, Description, Société, , adresse, et les dates de début et fin doivent etre saisies");

        }

        protected void ButtonDeleteExpPro_Click(object sender, EventArgs e)
        {
            Button but = (Button)sender;
            Business.ProfessionalExpService.Remove(but.CommandArgument, UserId);

            ObjectDataSourceProferssionalExpCompanies.Update();
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

        private void RazSkillsFormFields()
        {
            TextBoxCompeDescription.Text = string.Empty;
            TextBoxCompeName.Text = string.Empty;          
        }

        private bool ValidateSkillsFormFields()
        {

            if (TextBoxCompeDescription.Text != string.Empty && TextBoxCompeName.Text != string.Empty)
                return true;
            else
                return false;
        }

        protected void ButtonSkills_Click(object sender, EventArgs e)
        {
            if (ValidateSkillsFormFields())
            {
                Business.SkillService.InsertNewSkill(TextBoxCompeName.Text, TextBoxCompeDescription.Text, RatingNiveau.CurrentRating, UserId);
                ObjectDataSourceSkillsForUser.Update();
                RazSkillsFormFields();
            }
            else
                MessageBox("Les champs Nom et Description doivent etre saisies");
        }

        protected void ButtonDeleteSkills_Click(object sender, EventArgs e)
        {
            LinkButton but = (LinkButton)sender;
            Business.SkillService.Remove(but.CommandArgument, UserId);

            ObjectDataSourceSkillsForUser.Update();
        }

        #endregion

        #region relation

        protected void createRelation_Click(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("Invitation.aspx?id={0}", Request.Params["id"]));
        }

        protected void deleteRelation_Click(object sender, EventArgs e)
        {
            Business.RelationService.deleteRelation((Guid)(Membership.GetUser(User.Identity.Name, false).ProviderUserKey), (Guid)(Membership.GetUser(Request.Params["id"], false).ProviderUserKey));
            Response.Redirect(Request.RawUrl);
        }

        #endregion

        
    }
}