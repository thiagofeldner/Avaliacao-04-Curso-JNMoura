using System;
using System.ComponentModel.DataAnnotations;

namespace web_api_loja.Models
{
    public class Veiculo
    {
        public int Id { get; set; }

        [Required (ErrorMessage = "Informe a Marca do veículo")]
        [StringLength(50, ErrorMessage = "Marca não deve exceder {50} caracteres")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "Informe o Nome do veículo")]
        [StringLength(100, ErrorMessage = "O Nome do veículo não deve exceder {100} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o Ano Modelo do veículo")]
        public int AnoModelo { get; set; }

        [Required(ErrorMessage = "Informe a Data de Fabricação do veículo")]
        public DateTime DataFabricacao { get; set; }

        [Required(ErrorMessage = "Informe o Valor do veículo")]
        public decimal Valor { get; set; }

        public string Opcionais { get; set; }
    }
}