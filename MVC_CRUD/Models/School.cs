using System.ComponentModel.DataAnnotations;

namespace MVC_CRUD.Models
{
    public class School
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Okul adı zorunlu bir alandır.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Okul adresi zorunlu bir alandır.")]
        public string Address { get; set; }

        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
