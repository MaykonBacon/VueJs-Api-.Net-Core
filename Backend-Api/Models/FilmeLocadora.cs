using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Api.Models
{
    public class FilmeLocadora
    {
        public int FilmeId { get; set; }
        public Filme Filme { get; set; }
        public int LocadoraId { get; set; }
        public Locadora Locadora { get; set; }
    }
}
