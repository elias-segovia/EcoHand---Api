using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoHand.Data.Models
{
    [Table("Gestos")]
    public class Gesto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        
        public DateTime FechaCreacion { get; set; }

        public DateTime FechaModificacion { get; set; }

        public int PosPulgar { get; set; }

        public int Posindice { get; set; }

        public int PosMayor { get; set; }

        public int PosAnular { get; set; }

        public int PosMeñique { get; set; }

        public int UsuarioID { get; set; }

    }
}
