﻿using CarInformation.API.Features.Company.Models;

namespace CarInformation.API.Features.Company.Repositories.Interface
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<CarsCompany>> GetAllCompaniesAsync();
        Task<CarsCompany> GetCompanyByIdAsync(int id);
        Task AddCompanyAsync(CarsCompany company);
        Task UpdateCompanyAsync(CarsCompany company);
        Task DeleteCompanyAsync(int id);
    }
}
