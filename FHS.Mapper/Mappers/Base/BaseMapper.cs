using FHS.Domain.Interfaces.Dto.Base;
using FHS.Entities.Interfaces.ListModel.Base;
using FHS.Entities.Interfaces.Model.Base;
using FHS.Interfaces.Mapper.Base;
using Mapster;

namespace Mapper.Mappers.Base;

public abstract class BaseMapper<TListModel, TModel, TEntity> : IBaseMapper<TListModel, TModel, TEntity>
    where TListModel : class, IBaseListModel
    where TModel : class, IBaseModel
    where TEntity : class, IBaseEntity
{
    public TModel MapToModel(TEntity? source)
    {
        return source.Adapt<TModel>();
    }

    public TEntity MapToEntity(TModel? source)
    {
        return source.Adapt<TEntity>();
    }

    public IEnumerable<TListModel> MapToListModels(IEnumerable<TEntity> sourceEnumerable)
    {
        return sourceEnumerable.Adapt<IEnumerable<TListModel>>();
    }
}