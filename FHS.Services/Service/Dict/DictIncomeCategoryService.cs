using DataService.Data;
using FHS.Entities.Dto.Dict;
using FHS.Entities.ListModel.Dict;
using FHS.Entities.Model.Dict;
using FHS.Interfaces.Services.Dict;
using FHS.Services.Service.Base;
using FHS.Interfaces.Mapper.Features;
using Serilog;

namespace FHS.Services.Service.Dict;

public sealed class DictIncomeCategoryService 
    : BaseDictCrudService<DictIncomeCategoryListModel, DictIncomeCategoryModel, DictIncomeCategory, IDictIncomeCategoryMapper>, IDictIncomeCategoryService
{
    public DictIncomeCategoryService(ILogger logger, AppDbContext dbContext, IDictIncomeCategoryMapper mapper) : base(logger, dbContext, mapper)
    {
    }
}