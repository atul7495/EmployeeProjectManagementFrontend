using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    public class ProjectModal
    {
        [Key]
        public int ProjId { get; set; }

        [Required]
        public string Pname { get; set; }

        [Required]
        public string Pdetail { get; set; }

        [Required]
        public string Pdate { get; set; }
    }
}
