using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMProjet.Models
{
    public interface IDal : IDisposable
    {
        //Info & Login
        //int AddUser(string username, string password);
        //int AddUser(string username, string password, string firstname, string lastname, string jobTitle);
        User GetUser(int id = 1);
        User GetUser(string id);
        User GetUser(string username, string password);
        bool CheckUser(string username, string password);

        //Project
        List<Project> GetAllProjects();
        Project GetProject(int id);
        void AddProject(string name, string date, string description, string thumbnail);

        //Education
        List<Education> GetAllEducations();
        Education GetEducation(int id);
        void AddEducation(string name, string date, string description, string thumbnail);

    }
}
