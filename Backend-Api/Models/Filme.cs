using Backend_Api.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Api.Models
{
    public class Filme
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Genero { get; set; }
        public List<FilmeLocadora> FilmeLocadoras { get; set; }
        public List<Diretor> Diretors { get; set; }
    }
}
