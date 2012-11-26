using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;

namespace Business
{
    public class SingletonEntities
    {
        private static bindedinEntities instance;

        public static bindedinEntities Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new bindedinEntities();

                }

                return instance;
            }
        }

        private SingletonEntities() { }
    }
}
