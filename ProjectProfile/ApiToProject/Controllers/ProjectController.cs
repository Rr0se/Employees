using ApiToProject.Entities;
using ApiToProject.InputModels;
using ApiToProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ApiToProject.Controllers
{
    [Route("api/projects")]
    public class ProjectController:Controller
    {
        private readonly DataBaseContext context;

        public ProjectController(DataBaseContext context)
        {
            this.context = context;
        }

        private Models.ProfileProject GenerateProject(Guid Id)
        {
            var project = context.Projects.FirstOrDefault(x => x.Id == Id);
            if (project == null)
            {
                return null;
            }
            var output = new Models.ProfileProject
            {              
                Id = project.Id,      
                Name = project.Title ,
                ClientSector = project.ClientSector,
                StartDate = project.StartDate,
                EndDate = project.EndDate
            };
            return output;
        }

        private IList<Profile> GenerateProfile(Guid Id)
        {
            var employee = context.Projects.Include(z => z.EmployeeProjects).ThenInclude(z => z.Employee).FirstOrDefault(z => z.Id == Id);
            if (employee == null)
                return null;
            var languages = employee.EmployeeProjects;
            var output = new List<Profile>();

            foreach (var e in languages)
            {
                output.Add(new Profile
                {
                    Id = e.Employee.Id,
                    Name = e.Employee.FirstName,
                    LastName = e.Employee.LastName,
                    Specialization = e.Employee.Specialization,
                    Rating = e.Employee.Rating,
                    OverallTenure = e.Employee.YearsOfWork
                });
            }

            return output;

        }

        private IList<ProfileTechnology> GenerateTechnologies(Guid Id)
        {
            var employee = context.Projects.Include(x => x.ProjectTechnology).ThenInclude(x => x.Technology).FirstOrDefault(x => x.Id == Id);
            if (employee == null)
                return null;
            var technologies = employee.ProjectTechnology;
            var output = new List<ProfileTechnology>();

            foreach (var techno in technologies)
            {
                output.Add(new ProfileTechnology
                {
                    Id = techno.Technology.Id,
                    Name = techno.Technology.TechnologyName,
                    
                });
            }

            return output;
        }

        [Route("GetProject")]
        [HttpGet]
        public IActionResult GetProject(Guid Id)
        {
            var output = new ProjectViewModel
            {
                ProfileProject = GenerateProject(Id),
                Profiles = GenerateProfile(Id)
            };
            return StatusCode((int)HttpStatusCode.OK, output);
        }

        [Route("GetProjects")]
        [HttpGet]
        public IActionResult GetProjects()
        {
            var tmp=context.Projects.ToList();

            var output = new List<ProjectViewModel>();
                 foreach(var proj in tmp)
            {
                output.Add(new ProjectViewModel
                {
                    Id = proj.Id,
                    Name = proj.Title,
                    ClientSector = proj.ClientSector,
                    StartDate = proj.StartDate,
                    EndDate = proj.EndDate,
                    ProfileProject = GenerateProject(proj.Id),
                    Profiles = GenerateProfile(proj.Id)
                });
            }

            return StatusCode((int)HttpStatusCode.OK, output);
        }

        [HttpPost]
        [Route("AddProject")]
        public IActionResult AddProject(InputProjectModel inputProjectModel)
        {

            context.Projects.Add(new Project()
            {
                Title = inputProjectModel.Name,
            });
            context.SaveChanges();
            return StatusCode((int)HttpStatusCode.OK);
        }

        [HttpPut]
        [Route("EditProject")]
        public IActionResult EditProject(InputProjectModel inputProjectModel)
        {
            if (inputProjectModel == null)
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            var project = context.Projects.FirstOrDefault(x => x.Id == inputProjectModel.Id);

            if (project == null)
                return new StatusCodeResult((int)HttpStatusCode.NotFound);

            project.Title = inputProjectModel.Name;
            project.ClientSector = inputProjectModel.ClientSector;
            project.StartDate = inputProjectModel.StartDate;
            project.EndDate = inputProjectModel.EndDate;

            context.SaveChanges();

            return StatusCode((int)HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("DeleteProject")]
        public IActionResult DeleteProject(Guid Id)
        {
            Project project = context.Projects.Find(Id);
            context.Projects.Remove(project);

            context.SaveChanges();
            return StatusCode((int)HttpStatusCode.OK);
        }

        [HttpPost]
        [Route("AddEmployeeToProject")]
        public async Task<IActionResult> AddEmployeeToProject([FromBody] ProjectEmployeeInputModel model)
        {
            var project = context.Projects.Include(x => x.EmployeeProjects).FirstOrDefault(x => x.Id == model.ProjectId);
            if (project == null)
                return StatusCode((int)HttpStatusCode.NotFound);

            var emplo = context.Employees.Include(x => x.EmployeeProjects).FirstOrDefault(x => x.Id == model.EmployeeId);
            if (emplo == null)
                return StatusCode((int)HttpStatusCode.NotFound);

            if (project.EmployeeProjects == null)
                project.EmployeeProjects = new List<EmployeeProject>();
            if (emplo.EmployeeProjects == null)
                emplo.EmployeeProjects = new List<EmployeeProject>();

            if (project.EmployeeProjects.Any(x => x.EmployeeId == emplo.Id))
                return StatusCode((int)HttpStatusCode.BadRequest);

            var projectEmplo = new EmployeeProject
            {
                Project = project,
                ProjectId = model.ProjectId,
                Employee = emplo,
                EmployeeId = model.EmployeeId,
                JoinDate = DateTime.Now

            };
            emplo.EmployeeProjects.Add(projectEmplo);
            project.EmployeeProjects.Add(projectEmplo);
            await context.SaveChangesAsync();
            return StatusCode((int)HttpStatusCode.OK);
            
        }
        [HttpPost]
        [Route("AddTechnologyToProject")]
        public async Task<IActionResult> AddTechnologyToProject([FromBody] ProjectTechnologyInputModel model)
        {
            var project = context.Projects.Include(x => x.ProjectTechnology).FirstOrDefault(x => x.Id == model.ProjectId);
            if (project == null)
                return StatusCode((int)HttpStatusCode.NotFound);

            var techno = context.Technologies.Include(x => x.ProjectTechnology).FirstOrDefault(x => x.Id == model.TechnologyId);
            if (techno == null)
                return StatusCode((int)HttpStatusCode.NotFound);

            if (project.ProjectTechnology == null)
                project.ProjectTechnology = new List<ProjectTechnology>();
            if (techno.ProjectTechnology == null)
                techno.ProjectTechnology = new List<ProjectTechnology>();

            if (project.EmployeeProjects.Any(x => x.EmployeeId == techno.Id))
                return StatusCode((int)HttpStatusCode.BadRequest);

            var projectTechno = new ProjectTechnology
            {
                Project = project,
                ProjectId = model.ProjectId,
                Technology = techno,
                TechnologyId = model.TechnologyId,
                TechnologiesName = model.TechnologiesName

            };
            techno.ProjectTechnology.Add(projectTechno);
            project.ProjectTechnology.Add(projectTechno);
            await context.SaveChangesAsync();
            return StatusCode((int)HttpStatusCode.OK);

        }


    }
}
