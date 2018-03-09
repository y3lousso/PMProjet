using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMProjet.Models
{
    public interface IDal : IDisposable
    {
        //Info & Login
        User GetUser();

        //Project
        List<Project> GetAllProjects();
        void AddProject(string name, string date, string description);

        //Education
        List<Education> GetAllEducation();
        void AddEducation();

    }
}
