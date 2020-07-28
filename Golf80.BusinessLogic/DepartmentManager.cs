using AutoMapper;
using Golf80.BusinessEntities;
using Golf80.BusinessLogic.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Golf80.BusinessLogic
{
    public class DepartmentManager : IDepartmentManager
    {
        private readonly DataContext.DataContext _dataContext;
        private readonly IMapper _mapper;
        public DepartmentManager(DataContext.DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public async Task<IReadOnlyCollection<DepartmentViewModel>> GetAllAsync()
        {
            return _mapper
                .Map<IReadOnlyCollection<DepartmentViewModel>>
                (
                await _dataContext
                .Departments
                .Include(x => x.Employees)
                .ToListAsync()
                );
        }
        public async Task<DepartmentViewModel> GetAsync(int id)
        {
            return _mapper
                .Map<DepartmentViewModel>(
                await _dataContext
                .Departments
                .Include(x => x.Employees)
                .FirstOrDefaultAsync(x => x.Id.Equals(id))
                );
        }
        public async Task<bool> AddAsync(DepartmentAddModel department)
        {
            await _dataContext
               .Departments
               .AddAsync
               (
                _mapper
                .Map<DataEntities.Department>(department)
                );
            await _dataContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateAsync(DepartmentUpdateModel department)
        {
            var departmentDB =
                await
                _dataContext
                .Departments
                .FirstOrDefaultAsync(x => x.Id.Equals(department.Id));

            if (departmentDB == null)
                return false;

            departmentDB.Name = department.Name;

            _dataContext
                    .Departments
                    .Update(departmentDB);
            await _dataContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var departmentDB =
                await
                _dataContext
                .Departments
                .FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (departmentDB == null)
                return false;

            _dataContext
                    .Departments
                    .Remove(departmentDB);
            await _dataContext.SaveChangesAsync();
            return true;
        }
    }
}
