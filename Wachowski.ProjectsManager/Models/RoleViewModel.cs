using Microsoft.AspNetCore.Mvc.Rendering;

namespace Wachowski.ProjectsManager.Models
{
    public class RoleViewModel
    {
        public List<Person>? Members { get; set; }
        public SelectList? Roles { get; set; }
        public string? MemberRole { get; set; }
        public string? Search { get; set; }
    }
}
