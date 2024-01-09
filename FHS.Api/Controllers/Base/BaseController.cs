using FHS.Entities.Dto;
using FHS.Entities.ListModel.Base;
using FHS.Entities.Model;
using FHS.Services.Interfaces.Base;
using Microsoft.AspNetCore.Mvc;

namespace FHS.Api.Controllers.Base;

[Route("api/[controller]")]
[ApiController]
public abstract class BaseController<TListModel, TModel, TEntity, TService> : ControllerBase
where TListModel : BaseListModel
where TModel : BaseModel
where TEntity : BaseEntity
where TService : IBaseCrudService<TListModel, TModel, TEntity>
{
    private protected readonly ILogger _logger;
    private protected readonly TService _service;

    protected BaseController(ILogger logger, TService service)
    {
        _logger = logger;
        _service = service;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TListModel>>> GetList()
    {
        try
        {
            var items = await _service.GetAllAsync();
            return Ok(items);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to fetch all items.");
            return StatusCode(500, "Internal server error");
        }
    }
}