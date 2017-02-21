using System.ComponentModel.DataAnnotations;

namespace AulaMVC.Models
{
    public class ProdutoRodadaModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "* Obrigatório!")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "* Obrigatório!")]
        public int PessoasMesaId { get; set; }
        public virtual PessoasMesaModel Pessoas { get; set; }

        [Required(ErrorMessage = "* Obrigatório!")]
        public int ProdutoModelId { get; set; }

        public virtual ProdutoModel Produto { get; set; }

        [Required(ErrorMessage = "* Obrigatório!")]
        public int RodadaModelId { get; set; }

        public virtual RodadaModel Rodada { get; set; }
    }
}