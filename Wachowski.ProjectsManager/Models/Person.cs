using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Wachowski.ProjectsManager.CORE.Enums;
using Wachowski.ProjectsManager.INTERFACES;

namespace Wachowski.ProjectsManager.Models
{
    public class Person: IPerson<Project>
    {
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public Role Role { get; set; }
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime DateOfBirth { get; set; }
        [ForeignKey("Project")]
        [Required(ErrorMessage = "Project field is required.")]
        [Display(Name = "Project")]
        public int ProjectId { get; set; }
        public Project? Project { get; set; }
        [Display(Name = "Full name")]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
    }
}
