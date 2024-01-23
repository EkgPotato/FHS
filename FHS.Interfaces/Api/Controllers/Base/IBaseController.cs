using FHS.Entities.Interfaces.ListModel.Base;
using FHS.Entities.Interfaces.Model.Base;
using Microsoft.AspNetCore.Mvc;

namespace FHS.Interfaces.Api.Controllers.Base
{
    public interface IBaseController<TListModel, TModel>
        where TListModel : IBaseListModel
        where TModel : IBaseModel
    {
        Task<ActionResult> CreateAsync([FromBody] TModel? entity);
        Task<ActionResult> DeleteAsync(int id);
        Task<ActionResult<TModel>> GetAsync(int id);
        Task<ActionResult<IEnumerable<TListModel>>> GetListAsync();
        Task<IActionResult> UpdateAsync(int id, [FromBody] TModel? entity);
    }
}