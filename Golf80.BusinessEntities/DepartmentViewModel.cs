using System.Collections.Generic;

namespace Golf80.BusinessEntities
{
    public class DepartmentViewModel: DepartmentUpdateModel
    {
        public IList<EmployeeViewModel> Employees { get; set; }
    }
}
