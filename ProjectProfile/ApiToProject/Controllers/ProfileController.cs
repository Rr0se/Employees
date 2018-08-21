﻿using ApiToProject.Entities;
using ApiToProject.InputModels;
using ApiToProject.Models;
using ApiToProject.Services;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ApiToProject.Controllers
{
    [Route("api/employees")]
    public class ProfileController:Controller
    {
        private readonly DataBaseContext context;

        public ProfileController(DataBaseContext context)
        {
            this.context = context;
        }
        private Models.Profile GenerateProfile(Guid Id)
        {
            var employee = context.Employees.FirstOrDefault(x => x.Id == Id);
            if (employee == null)
            {
                return null;
            }

            var output = new Models.Profile
            {

                Id = employee.Id,
                Name = employee.FirstName ,
                LastName =employee.LastName,
                Specialization = employee.Specialization,
                Rating = employee.Rating,
                OverallTenure = employee.YearsOfWork

            };

            return output;
        }

        private IList<ProfileSkill> GenerateSkills(Guid Id)
        {
            var employee = context.Employees.Include(x => x.EmployeeSkills).ThenInclude(x => x.Skill).FirstOrDefault(x => x.Id == Id);
            if (employee == null)
                return null;
            var skills = employee.EmployeeSkills;
            var output = new List<ProfileSkill>();

            foreach (var skill in skills)
            {
                output.Add(new ProfileSkill
                {
                    Id = skill.Skill.Id,
                    Name = skill.Skill.SkillName,
                    Experience = skill.Skill.ExperienceInYears,
                    Profficiency = skill.Skill.Profficiency
                });
            }

            return output;
        }

        private IList<ProfileProject> GenerateProject(Guid Id)
        {
            var employee = context.Employees.Include(z => z.EmployeeProjects).ThenInclude(z => z.Project).FirstOrDefault(z => z.Id == Id);
            if (employee == null)
                return null;

            var projects = employee.EmployeeProjects;
            var output = new List<ProfileProject>();

            foreach(var project in projects)
            {
                output.Add(new ProfileProject
                {
                    Id=project.Project.Id,
                    Name=project.Project.Title,
                    ClientSector=project.Project.ClientSector,
                    Technologies=project.Project.Technologies,
                    StartDate=project.Project.StartDate,
                    EndDate=project.Project.EndDate
                });
            }
            return output;
        }


        private IList<ProfileLanguage> GenerateLanguage(Guid Id)
        {
            var employee = context.Employees.Include(z => z.EmployeeLanguages).ThenInclude(z => z.Language).FirstOrDefault(z => z.Id == Id);
            if (employee == null)
                return null;
            var languages = employee.EmployeeLanguages;
            var output = new List<ProfileLanguage>();

            foreach(var language in languages)
            {
                output.Add(new ProfileLanguage
                {
                    Id = language.Language.Id,
                    Name = language.Language.LanguageName,
                    Speaking = language.SpeakingLevel,
                    Writing = language.WritingLevel,
                    Reading = language.ReadingLevel

                });
            }

            return output;

        }




        [Route("GetEmployee")]
        [HttpGet]
        public IActionResult GetEmployee(Guid Id)
        {
            var output = new EmployeeViewModel
            {
                Profile = GenerateProfile(Id),
                Skills = GenerateSkills(Id),
                Languages = GenerateLanguage(Id),
                Projects = GenerateProject(Id)
            };
            return StatusCode(200, output);
        }

        [Route("GetEmployees")]
        [HttpGet]
        public IActionResult GetEmployees()
        {
            var tmp = context.Employees
                 .ToList();

            var output = new List<EmployeeViewModel>();

            foreach(var emp in tmp)
            {
                output.Add(new EmployeeViewModel
                {
                    Profile = GenerateProfile(emp.Id),
                    Skills = GenerateSkills(emp.Id),
                    Languages = GenerateLanguage(emp.Id),
                    Projects = GenerateProject(emp.Id)
                });
            }

            return StatusCode(200, output);
        }


        [HttpPost]
        [Route("AddEmployee")]
        public IActionResult AddEmployee([FromBody] InputEmployeeModel employeeInputModel)
        {
            var employee = new Employee()
            {
                FirstName = employeeInputModel.Name,
                LastName = employeeInputModel.LastName,
                Specialization = employeeInputModel.Specialization,
                Rating = employeeInputModel.Rating,
                YearsOfWork = int.Parse(employeeInputModel.OverallTenure),

            };
            context.Employees.Add(employee);
            context.SaveChanges();       
            return StatusCode((int)HttpStatusCode.OK);
        }      

        [HttpPut]
        [Route("EditEmployee")]
        public IActionResult EditEmployee(InputEmployeeModel inputEmployeeModel)
        {
            if (inputEmployeeModel == null)
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            var employee = context.Employees.FirstOrDefault(x => x.Id == inputEmployeeModel.Id);

            if (employee == null)
                return new StatusCodeResult((int)HttpStatusCode.NotFound);

            employee.FirstName = inputEmployeeModel.Name;
            employee.LastName = inputEmployeeModel.LastName;
            employee.Specialization = inputEmployeeModel.Specialization;
            employee.Rating = inputEmployeeModel.Rating;
            employee.YearsOfWork = int.Parse(inputEmployeeModel.OverallTenure);

            context.SaveChanges();

            return StatusCode((int)HttpStatusCode.OK);
        }

        [Route("DeleteEmployee")]
        [HttpDelete]
        public IActionResult DeleteEmployee(Guid Id)
        {
            Employee employee = context.Employees.Find(Id);
            context.Employees.Remove(employee);

            context.SaveChanges();
            return StatusCode((int)HttpStatusCode.OK);
        }



        [HttpPost]
        [Route("AddLanguageToEmployee")]
        public async Task<IActionResult> AddLanguageToEmployee([FromBody] EmployeeLanguageInputModel model)
        {
            var employee = context.Employees.Include(x => x.EmployeeLanguages).FirstOrDefault(x => x.Id == model.EmployeeId);
            if (employee == null)
                return StatusCode((int) HttpStatusCode.NotFound);

            var lang = context.Languages.Include(x => x.EmployeeLanguages).FirstOrDefault(x => x.Id == model.LanguageId);
            if(lang == null)
                return StatusCode((int)HttpStatusCode.NotFound);

            if(employee.EmployeeLanguages == null)
                employee.EmployeeLanguages = new List<EmployeeLanguage>();
            if(lang.EmployeeLanguages == null)
                employee.EmployeeLanguages = new List<EmployeeLanguage>();

            if (employee.EmployeeLanguages.Any(x => x.LanguageId == lang.Id))
                return StatusCode((int) HttpStatusCode.BadRequest);

            var employeeLang = new EmployeeLanguage
            {
                Employee = employee,
                EmployeeId = model.EmployeeId,
                Language = lang,
                ReadingLevel = model.ReadingLevel,
                WritingLevel = model.WritingLevel,
                SpeakingLevel = model.SpeakingLevel
            };

            employee.EmployeeLanguages.Add(employeeLang);
            lang.EmployeeLanguages.Add(employeeLang);
            await context.SaveChangesAsync();
            return StatusCode((int) HttpStatusCode.OK);
        }

    }

}





