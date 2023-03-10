using System.ComponentModel.DataAnnotations;
using Wachowski.ProjectsManager.INTERFACES;

namespace Wachowski.ProjectsManager.Models
{
    public class Project: IProject<Person>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Display(Name = "Due date")]
        public DateTime DueDate { get; set; }
        [Display(Name = "Number of stages")]
        public int NumberOfStages { get; set; }
        public ICollection<Person> Members { get; set; } = new List<Person>();
    }
}
