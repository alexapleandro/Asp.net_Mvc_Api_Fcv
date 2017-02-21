using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AulaMVC.Models
{
    public class TipoModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "* Obrigatório!")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "* O campo {0} aceita mínimo de {2} e máximo de {1} caracteres!")]
        public string Nome { get; set; }
    }
}