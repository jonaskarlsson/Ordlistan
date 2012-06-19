using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ordlistan.Models
{
    public class SvenskBetydelseRepository
    {
        internal List<SvenskBetydelse> HittaSvenskBetydelse(string sokord, int maxResultat)
        {

            List<SvenskBetydelse> svenskBetydelse = new List<SvenskBetydelse>();

            ByggEnListaAvSvenskaBetydelser(svenskBetydelse);

            var result = from n in svenskBetydelse
                         where n.Betydelse.Contains(sokord)
                         orderby n.Betydelse
                         select n;

            return result.Take(maxResultat).ToList();

        }

        private static void ByggEnListaAvSvenskaBetydelser(List<SvenskBetydelse> names)
        {
            names.Add(new SvenskBetydelse { Id = 1, Betydelse = "Kristina H. Chung" });
            names.Add(new SvenskBetydelse { Id = 2, Betydelse = "Paige H. Chen" });
            names.Add(new SvenskBetydelse { Id = 3, Betydelse = "Sherri E. Melton" });
            names.Add(new SvenskBetydelse { Id = 4, Betydelse = "Gretchen I. Hill" });
            names.Add(new SvenskBetydelse { Id = 5, Betydelse = "Karen U. Puckett" });
            names.Add(new SvenskBetydelse { Id = 6, Betydelse = "Patrick O. Song" });
        }
    }
}