using FHS.Services.Service.Dict;
using FHS.Services.Service.Features;
using FHS.Interfaces.Mapper.Features;
using Mapper.Mappers.Features;
using Serilog;
using FHS.Interfaces.Services.Dict;
using FHS.Interfaces.Services.Features;

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