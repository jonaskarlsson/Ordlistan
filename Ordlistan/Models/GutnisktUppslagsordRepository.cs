using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ordlistan.Models
{
    public class GutnisktUppslagsordRepository
    {
        
        internal List<GutnisktUppslagsord> HittaGutnisktUppslagsord(string sokord, int maxResultat)
        {

            List<GutnisktUppslagsord> gutnisktUppslagsord = new List<GutnisktUppslagsord>();

            ByggListaAvGutniskaUppslagsord(gutnisktUppslagsord);
            
            var result = from n in gutnisktUppslagsord
                         where n.Uppslagsord.Contains(sokord)
                         orderby n.Uppslagsord
                         select n;

            return result.Take(maxResultat).ToList();
        
        }

        private static void ByggListaAvGutniskaUppslagsord(List<GutnisktUppslagsord> gutnisktUppslagsord)
        {
            gutnisktUppslagsord.Add(new GutnisktUppslagsord { Id = 1, Uppslagsord = "Kristina H. Chung" });
            gutnisktUppslagsord.Add(new GutnisktUppslagsord { Id = 2, Uppslagsord = "Paige H. Chen" });
            gutnisktUppslagsord.Add(new GutnisktUppslagsord { Id = 3, Uppslagsord = "Sherri E. Melton" });
            gutnisktUppslagsord.Add(new GutnisktUppslagsord { Id = 4, Uppslagsord = "Gretchen I. Hill" });
            gutnisktUppslagsord.Add(new GutnisktUppslagsord { Id = 5, Uppslagsord = "Karen U. Puckett" });
            gutnisktUppslagsord.Add(new GutnisktUppslagsord { Id = 6, Uppslagsord = "Patrick O. Song" });
        }
    }
}