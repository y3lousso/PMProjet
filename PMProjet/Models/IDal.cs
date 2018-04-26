using System;
using System.Collections.Generic;

namespace PMProjet.Models
{
    public interface IDal : IDisposable
    {
        //Info & Login
        User GetUser();
        void ModifyUserInfo(string pseudo, string firstName, string lastName, string jobTitle, string email);
        void ModifyUserPassword(string password);
        bool CheckUser(string username, string password);

        //Project
        List<Project> GetAllProjects();
        Project GetProject(int id);
        void AddProject(string name, string date, string description, string thumbnail);
        void ModifyProject(int id, string name, string date, string description, string thumbnail);
        void DeleteProject(int id);

        //Slide
        void AddSlide(int projectId, string title, string description, string image);
        Slide GetSlide(int slideId);
        List<Slide> GetSlidesFor(int projectId);
        void ModifySlide(int slideId, string title, string description, string image);
        void DeleteSlide(int slideId);

        //Education
        List<Education> GetAllEducations();
        Education GetEducation(int id);
        void AddEducation(string name, string date, string description, string thumbnail, string websiteAdress);
        void ModifyEducation(int id, string name, string date, string description, string thumbnail, string websiteAdress);
        void DeleteEducation(int id);

    }
}
