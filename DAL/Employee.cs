using System.ComponentModel.DataAnnotations;

namespace CodeFirstApproach.DAL
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

    }
}
