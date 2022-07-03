using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetoBase.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string? Nome { get; set; }

        public string? Nick { get; set; }

        [Required]
        // [EmailAddress]
        public string? Email { get; set; }

        [Required]
        // [StringLength(150, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 8)]
        public string? Pass { get; set; }

        public bool Ativo { get; set; } = true;

        public List<Message>? Messages { get; set; }
    }
}