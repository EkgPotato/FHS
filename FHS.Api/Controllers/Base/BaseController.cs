using FHS.Domain.Interfaces.Dto.Base;
using FHS.Entities.Interfaces.ListModel.Base;
using FHS.Entities.Interfaces.Model.Base;
using FHS.Interfaces.Api.Controllers.Base;
using FHS.Interfaces.Services.Base;
using FHS.Resources.Exceptions;
using FHS.Utilities.Common.Crud;
using FHS.Utilities.Exceptions.Service;
using Microsoft.AspNetCore.Mvc;

namespace FHS.Api.Controllers.Base;

[Route("api/[controller]")]
[ApiController]
public abstract class BaseController<TListModel, TModel, TEntity, TService> : ControllerBase,
    IBaseController<TListModel, TModel>
    where TListModel : class, IBaseListModel
    where TModel : class, IBaseModel
    where TEntity : class, IBaseEntity
    where TService : IBaseCrudService<TListModel, TModel, TEntity>
{
    private protected readonly ILogger _logger;
    private protected readonly TService _service;

    protected BaseController(ILogger logger, TService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet("{id}")]
    [ActionName("GetAsync")]
    public async Task<ActionResult<TModel>> GetAsync(int id)
    {
        try
        {
            var item = await _service.GetAsync(id);

            if (item != null)
            {
                return Ok(item);
            }
            else
            {
                return NotFound();
            }
        }
        catch (InvalidIdException)
        {
            return BadRequest();
        }
        catch (Exception ex)
        {
            _logger.LogError("Error in method {method}: {exception}", nameof(GetAsync), ex);
            return StatusCode(500, ControllerExceptionMessages.Internal_Server_Error);
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TListModel>>> GetListAsync()
    {
        try
        {
            var item = await _service.GetAllAsync();

            if (item != null)
            {
                return Ok(item);
            }
            else
            {
                return BadRequest();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError("Error in method {method}: {exception}", nameof(GetListAsync), ex);
            return StatusCode(500, ControllerExceptionMessages.Internal_Server_Error);
        }
    }

    [HttpPost]
    public async Task<ActionResult> CreateAsync([FromBody] TModel? model)
    {
        try
        {
            var result = new CrudResult();

            await _service.CreateAsync(model, result);

            if (result.Succeed())
            {
                return CreatedAtAction(nameof(this.GetAsync), new { id = model.Id }, model);
            }
            else
            {
                return base.UnprocessableEntity(result.Messages);
            }
        }
        catch (ModelNullException)
        {
            return BadRequest();
        }
        catch (Exception ex)
        {
            _logger.LogError("Error in method {method} on entity {entity}: {exception} ", nameof(CreateAsync), model.ToString(), ex);
            return StatusCode(500, ControllerExceptionMessages.Internal_Server_Error);
        }
    }

    [HttpPost("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] TModel? model)
    {
        try
        {
            var result = new CrudResult();

            await _service.UpdateAsync(id, model, result);

            if (result.Succeed())
            {
                return CreatedAtAction(nameof(GetAsync), new { id = model.Id }, model);
            }
            else
            {
                return base.UnprocessableEntity(result.Messages);
            }
        }
        catch (Exception ex) when (ex is ModelNullException || ex is InvalidIdException)
        {
            return BadRequest();
        }
        catch (Exception ex)
        {
            _logger.LogError("Error in method {method} on entity {entity}: {exception} ", nameof(UpdateAsync), model.ToString(), ex);
            return StatusCode(500, ControllerExceptionMessages.Internal_Server_Error);
        }
    }


    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        try
        {
            await _service.DeleteAsync(id);

            return Ok();
        }
        catch (InvalidIdException) 
        {
            return BadRequest();
        }
        catch (Exception ex)
        {
            _logger.LogError("Error in method {method}: {exception}", nameof(DeleteAsync), ex);
            return StatusCode(500, ControllerExceptionMessages.Internal_Server_Error);
        }
    }
}