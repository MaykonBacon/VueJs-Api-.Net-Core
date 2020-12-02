using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Api.Models
{
    public class Diretor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Filme Filme { get; set; }
        public int FilmeId { get; set; }

    }
}
