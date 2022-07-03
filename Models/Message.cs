using System.ComponentModel.DataAnnotations;

namespace ProjetoBase.Models
{
    public class Message
    {

        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public User? Autor { get; set; }

        public Category? Categoria { get; set; }

        [Required]
        public string? Titulo { get; set; }

        [Required]
        public string? Texto { get; set; }

        public bool Ativo { get; set; } = true;
    }
}