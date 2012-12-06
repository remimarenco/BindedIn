using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;
using System.Web.Security;
using System.Web;

namespace Business
{
    public class RelationService
    {      

        public static List<UserProfile> GetRelations(Guid userId)
        {
            bindedinEntities bie = SingletonEntities.Instance;

            UserProfile profile = UserProfile.GetUserProfile(System.Web.HttpContext.Current.User.Identity.Name);
            bie.Refresh(System.Data.Objects.RefreshMode.StoreWins, bie.relation_status);
            
            // On récupère les utilisateurs qui sont en relation 
            var relations = from rel in bie.relation_status
                            where rel.status == 3
                            select rel;

            List<UserProfile> userRelations = new List<UserProfile>();
            UserProfile profil;
            foreach (var relation in relations)
            {
                if (relation.status == 3)
                {
                    if (relation.asked_user == userId)
                    {
                        profil = UserProfile.GetUserProfile(Membership.GetUser(relation.asking_user).UserName);
                        Guid userGuid = (Guid)Membership.GetUser(profil.UserName, false).ProviderUserKey;
                        profil.imageUrl = "/ShowImage.ashx?iduser=" + userGuid.ToString();
                        userRelations.Add(profil);
                    }
                    else if (relation.asking_user == userId)
                    {
                        profil = UserProfile.GetUserProfile(Membership.GetUser(relation.asked_user).UserName);
                        Guid userGuid = (Guid)Membership.GetUser(profil.UserName, false).ProviderUserKey;
                        profil.imageUrl = "/ShowImage.ashx?iduser=" + userGuid.ToString();
                        userRelations.Add(profil);
                    }
                }
            }
            return userRelations;
        }

        public static List<UserProfile> GetFarFromOneRelations(Guid userId)
        {
            // On cherche nos relations. On cherche les relations de nos relations => récursif
            List<UserProfile> listUserRelations = GetRelations(userId);

            List<UserProfile> listLoggedUserRelation = GetRelations((Guid)(Membership.GetUser(System.Web.HttpContext.Current.User.Identity.Name, false).ProviderUserKey));

            List<UserProfile> listFarFromOneRelations = new List<UserProfile>();

            // We search all the directly connected users to the actual logged user relations
            foreach (UserProfile userRelation in listUserRelations)
            {
                listFarFromOneRelations.AddRange(GetRelations((Guid)(Membership.GetUser(userRelation.UserName, false).ProviderUserKey)));
            }

            UserProfile actualUser = UserProfile.GetUserProfile(System.Web.HttpContext.Current.User.Identity.Name);
            while(listFarFromOneRelations.Contains(actualUser))
            {
                // We delete all the occurences of the actual user
                listFarFromOneRelations.Remove(actualUser);
            }

            // On supprime les utilisateurs qui sont déjà directement connectés avec l'utilisateur
            foreach (UserProfile user in listLoggedUserRelation)
            {
                if (listFarFromOneRelations.Contains(user))
                {
                    listFarFromOneRelations.Remove(user);
                }
            }

            return listFarFromOneRelations;
        }

        public static Boolean SendInvitation(String asking_userName, String asked_username, String message)
        {
            UserProfile loggedInProfile = UserProfile.GetUserProfile(asking_userName);

            String obj = String.Format("{0} {1} veut vous inviter dans son réseau !", loggedInProfile.FirstName, loggedInProfile.LastName);

            String messageToSend = message;

            messageToSend += "\n";

            Uri uri = HttpContext.Current.Request.Url;
            String host = uri.Scheme + Uri.SchemeDelimiter + uri.Host + ":" + uri.Port;
            String linkForInvitation = host + String.Format("/AcceptedInvitation.aspx?id_asking={0}&id_asked={1}", (Guid)(Membership.GetUser(asking_userName, false).ProviderUserKey), (Guid)(Membership.GetUser(asked_username, false).ProviderUserKey));

            messageToSend += String.Format("Voici le lien pour accepter cette invitation : {0}", linkForInvitation);
            messageToSend += "\n";
            messageToSend += "Sinon ignorez tout simplement ce message";
            messageToSend += "\nCordialement,";
            messageToSend += "\nVotre équipe BindedIn";

            Business.MessageService.SendMessage((Guid)(Membership.GetUser(asking_userName, false).ProviderUserKey), (Guid)(Membership.GetUser(asked_username, false).ProviderUserKey), obj, messageToSend);

            bindedinEntities bie = SingletonEntities.Instance;

            relation_status newRelation = new relation_status();
            newRelation.status = 1;
            newRelation.asked_date = DateTime.Now;
            newRelation.asked_user = (Guid)(Membership.GetUser(asked_username, false).ProviderUserKey);
            newRelation.asking_user = (Guid)(Membership.GetUser(asking_userName, false).ProviderUserKey);

            bie.relation_status.AddObject(newRelation);
            bie.SaveChanges();

            return true;
        }

        public static Boolean updateRelation(Guid askedUser, Guid askingUser)
        {
            bindedinEntities bie = SingletonEntities.Instance;
            bie.Refresh(System.Data.Objects.RefreshMode.StoreWins, bie.relation_status);

            var relation = from r in bie.relation_status
                           where r.asking_user == askingUser
                           where r.asked_user == askedUser
                           select r;

            relation_status relationTrouve = relation.First();

            relationTrouve.status = 3;

            bie.SaveChanges();

            return true;
        }

        public static Boolean deleteRelation(Guid user1, Guid user2)
        {
            bindedinEntities bie = SingletonEntities.Instance;
            bie.Refresh(System.Data.Objects.RefreshMode.StoreWins, bie.relation_status);

            var relation = from r in bie.relation_status
                           where (r.asked_user == user1 && r.asking_user == user2)
                            || (r.asked_user == user2 && r.asking_user == user1)
                           select r;

            relation_status relationTrouve = relation.First();

            relationTrouve.status = 4;

            bie.SaveChanges();

            return true;
        }

        public static int isInRelationWith(String username)
        {
            Guid askingRelation = (Guid)Membership.GetUser(username, false).ProviderUserKey;

            Guid loggedRelation = (Guid)Membership.GetUser(System.Web.HttpContext.Current.User.Identity.Name, false).ProviderUserKey;

            bindedinEntities bie = SingletonEntities.Instance;
            bie.Refresh(System.Data.Objects.RefreshMode.StoreWins, bie.relation_status);

            var listRelation = from r in bie.relation_status
                               where (r.asked_user == loggedRelation && r.asking_user == askingRelation)
                                || (r.asked_user == askingRelation && r.asking_user == loggedRelation)
                               select r;

            if (listRelation.Count() > 0)
            {
                return (listRelation.First().status);
            }
            else
            {
                return -1;
            }
            
        }
    }
}
