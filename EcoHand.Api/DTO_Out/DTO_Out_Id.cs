using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcoHand.Api.DTO_Out
{
    public class DTO_Out_Id
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public DTO_Out_Id(int id, string nombre)
        {
            this.Id = id;
            this.Nombre = nombre;
        }      
    }
}