using System.ComponentModel.DataAnnotations;

namespace PlanejaiFront.Models
{
    public class UserModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Informe seu nome.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Informe seu sobrenome.")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Informe um endereço de e-mail válido.")]
        public string? Email { get; set; }

        public string? Password { get; set; }

        [Required(ErrorMessage = "Informe um número de telefone.")]
        public string? PhoneNumber { get; set; }
    }
}
