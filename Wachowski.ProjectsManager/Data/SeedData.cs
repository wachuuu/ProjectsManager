using Microsoft.EntityFrameworkCore;
using Wachowski.ProjectsManager.Models;

namespace Wachowski.ProjectsManager.Data
{
    public static class SeedData
    {
        public static void Initialize(WachowskiProjectsManagerContext context)
        {
            context.Database.EnsureCreated();

            if (context.Projects.Any() || context.Members.Any())
            {
                return;
            }

            var projects = new Project[]
            {
                new Project { Name="RNApdbee", Description="Webserver for 3D RNA analysis", DueDate=DateTime.Parse("2023-01-18"), NumberOfStages=1 },
                new Project { Name="clickUp", Description="Powerful task manager", DueDate=DateTime.Parse("2025-02-22"), NumberOfStages=7 },
                new Project { Name="SmartGarden", Description="Gardening in a nutshell", DueDate=DateTime.Parse("2023-12-25"), NumberOfStages=2 },
                new Project { Name="Many Mornings", Description="Wake up more easily", DueDate=DateTime.Parse("2023-06-25"), NumberOfStages=5 },
                new Project { Name="RNApolis", Description="RNA annotator for specialists", DueDate=DateTime.Parse("2023-01-18"), NumberOfStages=3 },
                new Project { Name="ProjectsManager", Description="The best .NET app ever created", DueDate=DateTime.Parse("2023-01-25"), NumberOfStages=1 },
            };
            context.Projects.AddRange(projects);
            context.SaveChanges();

            var members = new Person[]
            {
                new Person() { FirstName="Gabriel", LastName="Wachowski", Role=CORE.Enums.Role.Developer, ProjectId=projects.Single(i => i.Name == "ProjectsManager").Id, DateOfBirth=DateTime.Parse("2000-12-15") },
                new Person() { FirstName="Adam", LastName="Malysh", Role=CORE.Enums.Role.Leader, ProjectId=projects.Single(i => i.Name == "RNApdbee").Id, DateOfBirth=DateTime.Parse("1973-12-22") },
                new Person() { FirstName="Ryshard", LastName="Peya", Role=CORE.Enums.Role.Designer, ProjectId=projects.Single(i => i.Name == "RNApdbee").Id, DateOfBirth=DateTime.Parse("1978-02-11") },
                new Person() { FirstName="Mariusz", LastName="Pudzianowski", Role=CORE.Enums.Role.Tester, ProjectId=projects.Single(i => i.Name == "RNApdbee").Id, DateOfBirth=DateTime.Parse("1999-01-02") },
                new Person() { FirstName="Jeremiasz", LastName="Nowak", Role=CORE.Enums.Role.Leader, ProjectId=projects.Single(i => i.Name == "clickUp").Id, DateOfBirth=DateTime.Parse("1995-10-22") },
                new Person() { FirstName="Włodzimierz", LastName="Biały", Role=CORE.Enums.Role.Developer, ProjectId=projects.Single(i => i.Name == "clickUp").Id, DateOfBirth=DateTime.Parse("1989-10-08") },
                new Person() { FirstName="Elżbieta", LastName="Druga", Role=CORE.Enums.Role.Developer, ProjectId=projects.Single(i => i.Name == "RNApolis").Id, DateOfBirth=DateTime.Parse("2000-10-21") },
                new Person() { FirstName="Adam", LastName="Ewa", Role=CORE.Enums.Role.Designer, ProjectId=projects.Single(i => i.Name == "SmartGarden").Id, DateOfBirth=DateTime.Parse("1987-08-11") },
                new Person() { FirstName="Anna", LastName="Kowalska", Role=CORE.Enums.Role.Developer, ProjectId=projects.Single(i => i.Name == "SmartGarden").Id, DateOfBirth=DateTime.Parse("1995-11-01") },
                new Person() { FirstName="Arkadiusz", LastName="Fajny", Role=CORE.Enums.Role.Tester, ProjectId=projects.Single(i => i.Name == "SmartGarden").Id, DateOfBirth=DateTime.Parse("1999-06-30") },
            };
            context.Members.AddRange(members);
            context.SaveChanges();
        }
    }
}
