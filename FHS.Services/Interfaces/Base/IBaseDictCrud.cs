using FHS.Entities.Dto;
using FHS.Entities.ListModel;
using FHS.Entities.ListModel.Base;
using FHS.Entities.Model;

namespace FHS.Services.Interfaces.Base;

public interface IBaseDictCrud<TDictListModel, TDictModel, TDictEntity> : IBaseCrudService<TDictListModel, TDictModel, TDictEntity>
    where TDictListModel : BaseDictListModel
    where TDictModel : BaseDictModel
    where TDictEntity : BaseDictEntity
{
}