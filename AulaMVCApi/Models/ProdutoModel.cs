using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AulaMVC.Models
{
    public class ProdutoModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "* Obrigatório!")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "* O campo {0} aceita mínimo de {2} e máximo de {1} caracteres!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "* Obrigatório!")]
        public decimal Volume { get; set; }

        [Required(ErrorMessage = "* Obrigatório!")]
        public decimal Valor { get; set; }

        [Display(Name = "Teor Alcoolico")]
        public decimal? TeorAlc { get; set; }

        [Required(ErrorMessage = "* Obrigatório!")]
        [Display(Name = "Tipo")]
        public int TipoModelId { get; set; }

        public virtual TipoModel TipoModel { get; set; }

        [Display(Name = "Fabricante")]
        public int? FabricanteModelId { get; set; }

        public virtual FabricanteModel FabricanteModel { get; set; }
    }
}