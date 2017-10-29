using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace S2CelsoGea.Context.ContextModels
{
    public class User : Amigo
    {
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        [Required(ErrorMessage = "O campo senha é obrigatório")]
        [Compare("Password", ErrorMessage = "A senha e a confirmação de senha não conferem.")]
        [MinLength(3, ErrorMessage = "O tamanho mínimo do campo Senha é de 3 caractéres.")]
        [MaxLength(20, ErrorMessage = "O tamanho máximo do campo Senha é de 20 caractéres.")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme a Senha")]
        [Required(ErrorMessage = "O campo confirmação de senha é obrigatório")]
        [Compare("Password", ErrorMessage = "A senha e a confirmação de senha não conferem.")]
        [MinLength(3, ErrorMessage = "O tamanho mínimo do campo Senha é de 3 caractéres.")]
        [MaxLength(20, ErrorMessage = "O tamanho máximo do campo Senha é de 20 caractéres.")]
        public string ConfirmPassword { get; set; }
        
    }
}