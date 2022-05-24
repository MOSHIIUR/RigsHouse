using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;



namespace RigsHouse
{
    class connectionString
    {
        public static string cs()
        {
            string cs = ConfigurationManager.ConnectionStrings["pltops"].ConnectionString;
            return cs;
        }

    }
}
