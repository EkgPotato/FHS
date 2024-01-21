using FHS.Domain.Interfaces.Dto.Base;
using FHS.Entities.Interfaces.ListModel.Base;
using FHS.Entities.Interfaces.Model.Base;

namespace FHS.Interfaces.Services.Base;

public interface IBaseDictCrud<TDictListModel, TDictModel, TDictEntity> : IBaseCrudService<TDictListModel, TDictModel, TDictEntity>
    where TDictListModel : IBaseDictListModel
    where TDictModel : IBaseDictModel
    where TDictEntity : IBaseDictEntity
{
}