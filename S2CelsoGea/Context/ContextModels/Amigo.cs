using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace S2CelsoGea.Context.ContextModels
{
    public class Amigo : EntityBase
    {
        [Display(Name = "Nome de Usuário")]
        [Required(ErrorMessage = "O campo Nome de Usuário é obrigatório")]
        [MinLength(3, ErrorMessage = "O tamanho mínimo do campo Nome de Usuário é de 3 caractéres.")]
        [MaxLength(20, ErrorMessage = "O tamanho máximo do campo Nome de Usuário é de 20 caractéres.")]
        public string UserName { get; set; }

        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress, ErrorMessage = "O Email esta no padrão incorreto")]
        [MinLength(5, ErrorMessage = "O tamanho mínimo do campo email é de 5 caractéres.")]
        [MaxLength(100, ErrorMessage = "O tamanho máximo do campo email é de 100 caractéres.")]
        public string Email { get; set; }

        [Display(Name = "Telefone")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "O Telefone esta no padrão incorreto")]
        [MinLength(5, ErrorMessage = "O tamanho mínimo do campo Telefone é de 5 caractéres.")]
        [MaxLength(20, ErrorMessage = "O tamanho máximo do campo Telefone é de 20 caractéres.")]
        public string Telefone { get; set; }

        public ICollection<Jogo> Jogos { get; set; }
    }
}