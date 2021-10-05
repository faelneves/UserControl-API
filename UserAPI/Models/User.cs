using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserAPI.Models
{
    public class User
    {
        [Key]
        [Required]
        public int UsuarioId { get; internal set; }
        [Required(ErrorMessage ="O nome é obrigatório", AllowEmptyStrings = false)]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "O nome deve conter pelo menos 3 caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "A data de nascimento é obrigatória", AllowEmptyStrings = false)]
        public DateTime DataNascimento { get; set; }
        [Required(ErrorMessage = "O email é obrigatório", AllowEmptyStrings=false)]
        public string Email { get; set; }
        public string Senha { get; set; }
        [Required]
        public int SexoId { get; set; }
        public Boolean Ativo { get; set; }
    }
}
