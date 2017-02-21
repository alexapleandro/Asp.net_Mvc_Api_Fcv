using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AulaMVC.Models
{
    public class RodadaModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "* Obrigatório!")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "* O campo {0} aceita mínimo de {2} e máximo de {1} caracteres!")]
        public string Local { get; set; }

        [Required(ErrorMessage = "* Obrigatório!")]
        [DataType(DataType.DateTime)]
        public DateTime Data { get; set; }

        [StringLength(30, ErrorMessage = "* O campo {0} aceita no máximo de {1} caracteres!")]
        [Display(Name = "Obs.")]
        public string Observacao { get; set; }

        public decimal Total { get; set; }

        public IEnumerable<PessoasMesaModel> Pessoas { get; set; }

        public IEnumerable<ProdutoRodadaModel> Produtos { get; set; }


    }
}