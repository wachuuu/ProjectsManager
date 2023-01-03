using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Wachowski.ProjectsManager.CORE.Enums;

namespace Wachowski.ProjectsManager.INTERFACES
{
    public interface IPerson<P>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Role Role { get; set; }
        public DateTime DateOfBirth { get; set; }
        public P Project { get; set; }
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
    }
}
