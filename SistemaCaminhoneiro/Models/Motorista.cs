using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaCaminhoneiro.Models
{
    public class Motorista
    {
        [Display(Name ="Id")]
        public int Cod { get; set; }

        [Required (ErrorMessage = "Informe  o Nome:")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe  a Marca do Caminhão:")]
        public string  Marca { get; set; }

        [Required(ErrorMessage = "Informe  o Modelo do Caminhão:")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "Informe  a Placa do  Caminhão:")]
        public string Placa { get; set; }

        [Required(ErrorMessage = "Informe  o Eixo:")]
        public string Eixo { get; set; }

        [Required(ErrorMessage = "Informe  o Endereço:")]
        public string Rua { get; set; }
        public string Cep { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }
        public string Estado { get; set; }

        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
        public DateTime DataExcluido { get; set; }


    }
}