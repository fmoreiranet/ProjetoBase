using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoBase.Models
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string? Nome { get; set; }

        public bool Ativo { get; set; } = true;
    }
}