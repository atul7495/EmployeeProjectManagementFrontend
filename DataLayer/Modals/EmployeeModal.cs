using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    public class EmployeeModal
    {
        [Key]
        public int empId { get; set; }

        [Required]
        public string ename { get; set; }
        [Required]
        public int eage { get; set; }
        [Required]
        public int esal { get; set; }


    }
}
