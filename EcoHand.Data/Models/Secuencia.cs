using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoHand.Data.Models
{
    [Table("Secuencias")]
    public class Secuencia
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime FechaModificacion { get; set; }

        public string CodigoEjecutable { get; set; }

        public string CodigoEstructura { get; set; }

        public int UsuarioID { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
