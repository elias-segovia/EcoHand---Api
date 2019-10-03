using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoHand.Data.Models
{
    public class SecuenciaItem
    {
        public int SecuenciaID { get; set; }

        public int Tipo { get; set; }
        public int? PosPulgar { get; set; }

        public int? Posindice { get; set; }

        public int? PosMayor { get; set; }

        public int? PosAnular { get; set; }

        public int? PosMeñique { get; set; }

        
    }
}
