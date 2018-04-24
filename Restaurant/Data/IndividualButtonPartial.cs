using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Data
{
    public class IndividualButtonPartial
    {
        public string Page { get; set; }
        public string Glyphicon { get; set; }
        public string ButtonType { get; set; }

        public int? Id { get; set; }

        public string ActionParameters
        {
            get
            {
                if(Id!=0 && Id!= null)
                {
                    return Id.ToString();
                }
                return null;
            }
        }
    }
}
