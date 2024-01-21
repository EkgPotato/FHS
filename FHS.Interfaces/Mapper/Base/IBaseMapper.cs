using FHS.Domain.Interfaces.Dto.Base;
using FHS.Entities.Interfaces.ListModel.Base;
using FHS.Entities.Interfaces.Model.Base;

namespace FHS.Interfaces.Mapper.Base;

public interface IBaseMapper<TListModel, TModel, TEntity>
where TListModel : IBaseListModel
where TModel : IBaseModel
where TEntity : IBaseEntity
{
    TModel MapToModel(TEntity? source);
    TEntity MapToEntity(TModel? source);
    IEnumerable<TListModel> MapToListModels(IEnumerable<TEntity> sourceEnumerable);
}