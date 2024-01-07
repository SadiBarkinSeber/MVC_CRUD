using System.ComponentModel.DataAnnotations;

namespace MVC_CRUD.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Öğrenci adı zorunlu bir alandır.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Okul seçimi zorunlu bir alandır.")]
        public int SchoolId { get; set; }

        public School School { get; set; }
    }
}
