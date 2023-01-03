using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Wachowski.ProjectsManager.INTERFACES
{
    public interface IProject<P>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public int NumberOfStages { get; set; }

        public ICollection<P> Members { get; set; }
    }
}
