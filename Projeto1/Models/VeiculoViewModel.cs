using System;
using System.ComponentModel.DataAnnotations;
using System.Web;
using Projeto1.Models;

namespace Projeto1.Models

{

    public class VeiculoViewModel
    {
        public Int32 Id { get; set; }
        [Required(ErrorMessage = "A Placa do Veículo é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Placa do Veículo")]
        [MaxLength(8)]
        public String Placa { get; set; }
        [MaxLength(11)]
        [Required(ErrorMessage = "O Renavan é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Renavan do Veículo")]
        public String Renavan { get; set; }
        [Required(ErrorMessage = "Informe o Nome do Proprietario", AllowEmptyStrings = false)]
        [Display(Name = "Nome")]
        [MaxLength(150)]
        public String Nome { get; set; }
        [Required(ErrorMessage = "Informe o Cpf do Proprietario", AllowEmptyStrings = false)]
        [Display(Name = "Cpf")]
        [MaxLength(11)]
        public String Cpf { get; set; }
        [Required]
        [DataType(DataType.Upload)]
        [Display(Name = "Imagem")]
        public HttpPostedFileBase ImageUpload { get; set; }
    }
}