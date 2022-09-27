using System;
using System.ComponentModel.DataAnnotations;

namespace APIPerfumes
{
    public class Perfume
    {
        [Key]
        [Required]
        public string Id { get; set; }

        public Perfume()
        {
            Id = Guid.NewGuid().ToString().Substring(0, 8);
        }


        [Required(ErrorMessage = "O campo Marca é obrigatório")]
        public string Marca { get; set; }


        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "O campo Gênero é obrigatório")]
        public string Genero { get; set; }


        [Required(ErrorMessage = "O campo Volume é obrigatório")]
        public int VolumeEmMl { get; set; }
    }
}
