using Microsoft.Extensions.Logging;
using Northwind.Employees.Application.Contracts;
using Northwind.Employees.Application.Dtos;
using Northwind.Employees.Application.Base;
using Northwind.Employees.Domain.Interfaces;
using EmployeesDomainEntities = Northwind.Employees.Domain.Entities;

namespace Northwind.Employees.Application.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly IEmployeesRepository employeesRepository;
        private readonly ILogger<EmployeesService> logger;

        public EmployeesService(IEmployeesRepository employeesRepository, ILogger<EmployeesService> logger)
        {
            this.employeesRepository = employeesRepository;
            this.logger = logger;
        }

        public ServiceResult GetAll()
        {
            var result = new ServiceResult();
            try
            {
                var employees = this.employeesRepository.GetAll();

                result.Result = employees.Select(employee => new EmployeesDtoGetAll
                {
                    EmployeeID = employee.EmployeeID,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Title = employee.Title,
                    TitleOfCourtesy = employee.TitleOfCourtesy,
                    BirthDate = employee.BirthDate,
                    HireDate = employee.HireDate,
                    Address = employee.Address,
                    City = employee.City,
                    Region = employee.Region,
                    PostalCode = employee.PostalCode,
                    Country = employee.Country,
                    HomePhone = employee.HomePhone,
                    Extension = employee.Extension,
                    Photo = employee.Photo,
                    Notes = employee.Notes,
                    ReportsTo = employee.ReportsTo,
                    PhotoPath = employee.PhotoPath
                }).ToList();

                result.Success = true;
                result.Message = "Employees successfully obtained.";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obtaining employees.";
                this.logger.LogError(result.Message, ex);
            }
            return result;
        }

        public ServiceResult GetById(int id)
        {
            var result = new ServiceResult();
            try
            {
                var employee = this.employeesRepository.GetEntityBy(id);

                if (employee == null)
                {
                    result.Success = false;
                    result.Message = $"No employee found with ID: {id}.";
                }
                else
                {
                    result.Result = new EmployeesDtoGetAll
                    {
                        EmployeeID = employee.EmployeeID,
                        FirstName = employee.FirstName,
                        LastName = employee.LastName,
                        Title = employee.Title,
                        TitleOfCourtesy = employee.TitleOfCourtesy,
                        BirthDate = employee.BirthDate,
                        HireDate = employee.HireDate,
                        Address = employee.Address,
                        City = employee.City,
                        Region = employee.Region,
                        PostalCode = employee.PostalCode,
                        Country = employee.Country,
                        HomePhone = employee.HomePhone,
                        Extension = employee.Extension,
                        Photo = employee.Photo,
                        Notes = employee.Notes,
                        ReportsTo = employee.ReportsTo,
                        PhotoPath = employee.PhotoPath
                    };
                    result.Success = true;
                    result.Message = "Employee successfully obtained.";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obtaining the employee.";
                this.logger.LogError(result.Message, ex);
            }

            return result;
        }

        public ServiceResult Add(EmployeesDtoSave employeeDtoSave)
        {
            var result = new ServiceResult();
            try
            {
                result = employeeDtoSave.IsValidEmployee();

                if (!result.Success)
                    return result;

                var employee = new EmployeesDomainEntities.Employees
                {
                    FirstName = employeeDtoSave.FirstName,
                    LastName = employeeDtoSave.LastName,
                    Title = employeeDtoSave.Title,
                    TitleOfCourtesy = employeeDtoSave.TitleOfCourtesy,
                    BirthDate = employeeDtoSave.BirthDate,
                    HireDate = employeeDtoSave.HireDate,
                    Address = employeeDtoSave.Address,
                    City = employeeDtoSave.City,
                    Region = employeeDtoSave.Region,
                    PostalCode = employeeDtoSave.PostalCode,
                    Country = employeeDtoSave.Country,
                    HomePhone = employeeDtoSave.HomePhone,
                    Extension = employeeDtoSave.Extension,
                    Photo = employeeDtoSave.Photo,
                    Notes = employeeDtoSave.Notes,
                    ReportsTo = employeeDtoSave.ReportsTo,
                    PhotoPath = employeeDtoSave.PhotoPath
                };

                this.employeesRepository.Save(employee);
                result.Success = true;
                result.Message = "Employee successfully added.";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error saving the employee.";
                this.logger.LogError(result.Message, ex);
            }

            return result;
        }

        public ServiceResult Update(EmployeesDtoUpdate employeeDtoUpdate)
        {
            var result = new ServiceResult();
            try
            {
                result = employeeDtoUpdate.IsValidEmployee();

                if (!result.Success)
                    return result;

                var employee = new EmployeesDomainEntities.Employees
                {
                    EmployeeID = employeeDtoUpdate.EmployeeID,
                    FirstName = employeeDtoUpdate.FirstName,
                    LastName = employeeDtoUpdate.LastName,
                    Title = employeeDtoUpdate.Title,
                    TitleOfCourtesy = employeeDtoUpdate.TitleOfCourtesy,
                    BirthDate = employeeDtoUpdate.BirthDate,
                    HireDate = employeeDtoUpdate.HireDate,
                    Address = employeeDtoUpdate.Address,
                    City = employeeDtoUpdate.City,
                    Region = employeeDtoUpdate.Region,
                    PostalCode = employeeDtoUpdate.PostalCode,
                    Country = employeeDtoUpdate.Country,
                    HomePhone = employeeDtoUpdate.HomePhone,
                    Extension = employeeDtoUpdate.Extension,
                    Photo = employeeDtoUpdate.Photo,
                    Notes = employeeDtoUpdate.Notes,
                    ReportsTo = employeeDtoUpdate.ReportsTo,
                    PhotoPath = employeeDtoUpdate.PhotoPath
                };

                this.employeesRepository.Update(employee);
                result.Success = true;
                result.Message = "Employee successfully updated.";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error updating the employee.";
                this.logger.LogError(result.Message, ex);
            }

            return result;
        }

        public ServiceResult Remove(EmployeesDtoRemove employeeDtoRemove)
        {
            var result = new ServiceResult();
            try
            {
                var employee = this.employeesRepository.GetEntityBy(employeeDtoRemove.EmployeeID);
                if (employee == null)
                {
                    result.Success = false;
                    result.Message = $"No employee found with ID: {employeeDtoRemove.EmployeeID}.";
                    return result;
                }

                this.employeesRepository.Remove(employee);
                result.Success = true;
                result.Message = "Employee successfully removed.";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error removing the employee.";
                this.logger.LogError(result.Message, ex);
            }

            return result;
        }
    }
}
