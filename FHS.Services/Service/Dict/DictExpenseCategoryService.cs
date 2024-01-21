using DataService.Data;
using FHS.Entities.Dto.Dict;
using FHS.Entities.ListModel.Dict;
using FHS.Entities.Model.Dict;
using FHS.Interfaces.Services.Dict;
using FHS.Services.Service.Base;
using FHS.Interfaces.Mapper.Features;
using Serilog;

namespace FHS.Services.Service.Dict;

public sealed class DictExpenseCategoryService 
    : BaseDictCrudService<DictExpenseCategoryListModel, DictExpenseCategoryModel, DictExpenseCategory, IDictExpenseCategoryMapper>, IDictExpenseCategoryService
{
    public DictExpenseCategoryService(ILogger logger, AppDbContext dbContext, IDictExpenseCategoryMapper mapper) : base(logger, dbContext, mapper)
    {
    }
}