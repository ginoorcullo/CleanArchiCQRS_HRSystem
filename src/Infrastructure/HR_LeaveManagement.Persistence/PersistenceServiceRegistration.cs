using HR_LeaveManagement.Application.Contracts.Persistence;
using HR_LeaveManagement.Persistence.DatabaseContext;
using HR_LeaveManagement.Persistence.Reposotories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HR_LeaveManagement.Persistence {
    public static class PersistenceServiceRegistration {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration) {
            
            services.AddDbContext<HrDatabaseContext>(options => {
                options.UseSqlServer(
                        configuration.GetConnectionString("HrDBConnection")
                    );
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
            services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();
            services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();

            return services;
        }
    }
}
