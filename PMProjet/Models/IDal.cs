using System;
using System.Collections.Generic;

namespace PMProjet.Models
{
    public interface IDal : IDisposable
    {
        //Info & Login
        User GetUser();
        void ModifyUser(string pseudo, string password, string firstName, string lastName, string jobTitle, string email);
        bool CheckUser(string username, string password);

        // Project
        List<Project> GetAllProjects();
        Project GetProject(int id);
        void AddProject(string name, string date, string description, string thumbnail);
        void ModifyProject(int id, string name, string date, string description, string thumbnail);
        void DeleteProject(int id);
        
        // Slide
        void AddSlide(int projectId, string title, string description, string image);
        Slide GetSlide(int projectId, int id);
        void ModifySlide(int projectId, int id, string title, string description, string image);
        void DeleteSlide(int projectId, int id);

        // Education
        List<Education> GetAllEducations();
        Education GetEducation(int id);
        void AddEducation(string name, string date, string description, string thumbnail, string websiteAdress);
        void ModifyEducation(int id, string name, string date, string description, string thumbnail, string websiteAdress);
        void DeleteEducation(int id);

    }
}
