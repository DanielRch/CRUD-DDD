using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petshop.Domain.Entities
{
    public class Pets
    {
        public int IdPet { get; set; }
        public string Nome { get; set; }

        public string Raca { get; set; }

        public string Tipo { get; set; }

        public int? Idade { get; set; }

    }
}
