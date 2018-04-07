using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMProjet.Models
{
    public interface IDal : IDisposable
    {
        //Info & Login
        int AddUser(string username, string password);
        int AddUser(string username, string password, string firstname, string lastname, string jobTitle);
        User GetUser(int id);
        User GetUser(string id);
        bool CheckUser(string username, string password);

        //Project
        List<Project> GetAllProjects();
        void AddProject(string name, string date, string description, string thumbnail);

        //Education
        List<Education> GetAllEducations();
        void AddEducation(string name, string date, string description, string thumbnail);

    }
}
