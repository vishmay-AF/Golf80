using Golf80.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Golf80.BusinessLogic.Interfaces
{
    public interface IDepartmentManager
    {
        Task<bool> AddAsync(DepartmentAddModel department);
        Task<bool> DeleteAsync(int id);
        Task<IReadOnlyCollection<DepartmentViewModel>> GetAllAsync();
        Task<DepartmentViewModel> GetAsync(int id);
        Task<bool> UpdateAsync(DepartmentUpdateModel department);
    }
}
