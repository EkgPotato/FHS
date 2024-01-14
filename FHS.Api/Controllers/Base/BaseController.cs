using FHS.Entities.Dto;
using FHS.Entities.ListModel.Base;
using FHS.Entities.Model;
using FHS.Resources.Exceptions;
using FHS.Services.Interfaces.Base;
using FHS.Utilities.ServicesUtilities.Crud;
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

    [HttpPost("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] TModel updatedEntity)
    {
        try
        {
            var result = new CrudResult();

            _service.Validate(updatedEntity, result.ValidationMessages);

            if (result.ValidationMessages.Any())
            {
                return BadRequest(result.ValidationMessages);
            }

            await _service.UpdateAsync(id, updatedEntity, result);

            if (result.Succeed())
            {
                return NoContent();
            }
            else
            {
                return base.UnprocessableEntity(updatedEntity);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError("Error in method {method} on entity {entity}: {exception} ", nameof(UpdateAsync), updatedEntity.ToString(), ex);
            return StatusCode(500, ControllerExceptionMessages.Internal_Server_Error);
        }
    }

    [HttpPost]
    public async Task<ActionResult> CreateAsync([FromBody] TModel entity)
    {
        try
        {
            var result = new CrudResult();

            _service.Validate(entity, result.ValidationMessages);

            if (result.ValidationMessages.Any())
            {
                return BadRequest(result.ValidationMessages);
            }

            await _service.CreateAsync(entity, result);

            if (result.Succeed())
            {
                return CreatedAtAction(nameof(CreateAsync), entity);
            }
            else
            {
                return base.UnprocessableEntity(entity);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError("Error in method {method} on entity {entity}: {exception} ", nameof(CreateAsync), entity.ToString(), ex);
            return StatusCode(500, ControllerExceptionMessages.Internal_Server_Error);
        }
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
            _logger.LogError("Error in method {method}: {exception}", nameof(GetList), ex);
            return StatusCode(500, ControllerExceptionMessages.Internal_Server_Error);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TModel>> GetAsync(int id)
    {
        try
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var item = await _service.GetAsync(id);
            return Ok(item);
        }
        catch (Exception ex)
        {
            _logger.LogError("Error in method {method}: {exception}", nameof(GetAsync), ex);
            return StatusCode(500, ControllerExceptionMessages.Internal_Server_Error);
        }
    }
}