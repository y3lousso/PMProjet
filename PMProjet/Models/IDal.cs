using System;
using System.Collections.Generic;

namespace PMProjet.Models
{
    public interface IDal : IDisposable
    {
        //Info & Login
        User GetUser();
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
