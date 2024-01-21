using FHS.Domain.Interfaces.Dto.Base;
using FHS.Entities.Interfaces.ListModel.Base;
using FHS.Entities.Interfaces.Model.Base;

namespace FHS.Interfaces.Mapper.Base;

public interface IBaseDictMapper<TDictListModel, TDictModel, TDictEntity>
    : IBaseMapper<TDictListModel, TDictModel, TDictEntity>
where TDictListModel : IBaseDictListModel
where TDictModel : IBaseDictModel
where TDictEntity : IBaseDictEntity
{

}