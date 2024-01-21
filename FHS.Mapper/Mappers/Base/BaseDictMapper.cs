using FHS.Domain.Interfaces.Dto.Base;
using FHS.Entities.Interfaces.ListModel.Base;
using FHS.Entities.Interfaces.Model.Base;
using FHS.Interfaces.Mapper.Base;

namespace Mapper.Mappers.Base;

public abstract class BaseDictMapper<TDictListModel, TDictModel, TDictEntity>
    : BaseMapper<TDictListModel, TDictModel, TDictEntity>,
        IBaseDictMapper<TDictListModel, TDictModel, TDictEntity>
    where TDictListModel : class, IBaseDictListModel
    where TDictModel : class, IBaseDictModel
    where TDictEntity : class, IBaseDictEntity
{
}