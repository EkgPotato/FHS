using FHS.Services.Interfaces.Dict;
using FHS.Services.Interfaces.Features;
using FHS.Services.Service.Dict;
using FHS.Services.Service.Features;
using Mapper.Interfaces.Features;
using Mapper.Mappers.Features;
using Serilog;

namespace FHS.Api.Startup;

public static class DependencyInjectionSetup
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddControllers();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddSingleton(Log.Logger);

        services.AddScoped<IDictExpenseCategoryMapper, DictExpenseCategoryMapper>();
        services.AddScoped<IDictIncomeCategoryMapper, DictIncomeCategoryMapper>();
        services.AddScoped<IIncomeMapper, IncomeMapper>();
        services.AddScoped<IExpenseMapper, ExpenseMapper>();
        
        services.AddScoped<IDictExpenseCategoryService, DictExpenseCategoryService>();
        services.AddScoped<IDictIncomeCategoryService, DictIncomeCategoryService>();
        services.AddScoped<IIncomeService, IncomeService>();
        services.AddScoped<IExpenseService, ExpenseService>();

        return services;
    }
}