using System;
using System.Collections.Generic;
using System.Text;

namespace lifeSpan
{
    public class populationModel
    {
        public int bornYear { get; set; }
        public int deathYear { get; set; }

        public bool isAlive
        {
            get
            {
                return deathYear == 0 ? true : false;
            }
            set
            {

            }
        }

    }
}
