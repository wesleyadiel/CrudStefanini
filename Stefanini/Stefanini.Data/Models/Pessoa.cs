using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Data
{
    public class Pessoa
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        [ForeignKey("Cidade")]
        public int Id_Cidade { get; set; }
        public Cidade Cidade {get;set;}
        public int Idade { get; set; }
    }
}
