using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CodeFirstApproach.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }



        [Required]
        public string Name { get; set; }



        [Required]
        [EmailAddress]
        [Remote (action: "IsEmailidIdInUse", controller: "Employee") ]
        public string Email { get; set; }




        [DisplayName("Department")]
        [Required]
        public int DepartmentId { get; set; }    
        


        public string? DepartmentName { get; set; }        
    }
}
