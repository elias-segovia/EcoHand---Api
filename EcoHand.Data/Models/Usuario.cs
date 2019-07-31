using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoHand.Data.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Contraseña { get; set; }

        public DateTime FechaCreacion { get; set; }

        public virtual ICollection<Gesto> Gestos { get; set; }

        public virtual ICollection<Secuencia> Secuencias { get; set; }
    }
}
