using FHS.Entities.Dto;
using FHS.Entities.ListModel;
using FHS.Entities.ListModel.Base;
using FHS.Entities.Model;
using FHS.Utilities.Common.Crud;

namespace FHS.Services.Interfaces.Base;

public interface IBaseCrudService<TListModel, TModel, TEntity>
    where TListModel : BaseListModel
    where TModel : BaseModel
    where TEntity : BaseEntity
{
    Task<TModel> GetAsync(int id, CrudResult result);
    Task<IEnumerable<TListModel>> GetAllAsync(CrudResult result);
    Task CreateAsync(TModel model, CrudResult result);
    Task UpdateAsync(int id, TModel model, CrudResult result);
    Task DeleteAsync(int id, CrudResult result);
}