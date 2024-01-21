using DataService.Data;
using FHS.Domain.Interfaces.Dto.Base;
using FHS.Entities.Interfaces.ListModel.Base;
using FHS.Entities.Interfaces.Model.Base;
using FHS.Interfaces.Services.Base;
using FHS.Interfaces.Mapper.Base;
using Serilog;

namespace FHS.Services.Service.Base;

public abstract class BaseDictCrudService<TDictListModel, TDictModel, TDictEntity, TDictMapper>
    : BaseCrudService<TDictListModel, TDictModel, TDictEntity, TDictMapper>, IBaseDictCrud<TDictListModel, TDictModel, TDictEntity>
    where TDictListModel : class, IBaseDictListModel
    where TDictModel : class, IBaseDictModel
    where TDictEntity : class, IBaseDictEntity
    where TDictMapper : IBaseDictMapper<TDictListModel, TDictModel, TDictEntity>
{
    protected BaseDictCrudService(ILogger logger, AppDbContext dbContext, TDictMapper mapper) : base(logger, dbContext, mapper)
    {
    }
}