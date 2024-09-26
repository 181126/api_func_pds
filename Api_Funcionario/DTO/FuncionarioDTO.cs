using System.ComponentModel.DataAnnotations;

namespace Api_Funcionario.DTO
{
    public class FuncionarioDTO
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string CPF { get; set; }
        [Required]
        public string CTPS { get; set; }
        [Required]
        public string RG { get; set; }
        [Required]
        public string Funcao { get; set; }
        [Required]
        public string Setor { get; set; }
        [Required]
        public string Sala { get; set; }
        [Required]
        public string Telefone { get; set; }
        [Required]
        public string UF { get; set; }
        [Required]
        public string Cidade { get; set; }
        [Required]
        public string Bairro { get; set; }
        [Required]
        public int Numero { get; set; }
        [Required]
        public int CEP { get; set; }
    }
}
