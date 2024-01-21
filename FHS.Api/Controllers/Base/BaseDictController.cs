using FHS.Domain.Interfaces.Dto.Base;
using FHS.Entities.Interfaces.ListModel.Base;
using FHS.Entities.Interfaces.Model.Base;
using FHS.Interfaces.Services.Base;

namespace FHS.Api.Controllers.Base;

public abstract class BaseDictController<TDictListModel, TDictModel, TDictEntity, TDictService> : BaseController<TDictListModel, TDictModel, TDictEntity, TDictService>
    where TDictListModel : class, IBaseDictListModel
    where TDictModel : class, IBaseDictModel
    where TDictEntity : class, IBaseDictEntity
    where TDictService : IBaseDictCrud<TDictListModel, TDictModel, TDictEntity>
{
    protected BaseDictController(ILogger logger, TDictService service) : base(logger, service)
    {
    }
}