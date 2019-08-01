using EcoHand.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcoHand.Api.DTO_Out
{
    public class DTO_Out_Usuario
    {

        public DTO_Out_Usuario(Usuario model)
        {
            Mapper(model);
        }

        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        void Mapper(Usuario model)
        {
            this.Id = model.ID.ToString();
            this.Username = model.Username;
            this.Email = model.Email;
        }
    }
}