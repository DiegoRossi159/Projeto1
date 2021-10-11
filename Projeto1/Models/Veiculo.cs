using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto1.Models
{
    [Table("Veiculos")]
    public class Veiculo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A Placa do Veiculo obrigatório", AllowEmptyStrings = false)]
        public string Placa { get; set; }
        [Required(ErrorMessage = "Informe o Renavan", AllowEmptyStrings = false)]
        public string Renavan { get; set; }
        [Required(ErrorMessage = "Informe o Nome do Proprietario", AllowEmptyStrings = false)]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Informe o CPF do Proprietario", AllowEmptyStrings = false)]
        public string Cpf { get; set; }
        public string Imagem { get; set; }

        

    }
}