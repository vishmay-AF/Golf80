using Golf80.BusinessLogic.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Golf80.BusinessLogic.IOCConfig
{
    public class IocConfig
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IDepartmentManager, DepartmentManager>();
        }
    }
}
