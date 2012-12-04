using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;

namespace Business
{
    public class ImagesService
    {
        public static List<Image> GetImages()
        {
            bindedinEntities bie = SingletonEntities.Instance;
            var retour = from i in bie.Image
                         where i.Current.Equals(true)
                            select i;
            return retour.ToList();
        }

        public static List<Image> GetImages(Guid userId)
        {
            bindedinEntities bie = SingletonEntities.Instance;
            var retour = from i in bie.Image
                         where i.UserId.Equals(userId)
                         where i.Current.Equals(true)
                         select i;
            return retour.ToList();
        }
    }
}
