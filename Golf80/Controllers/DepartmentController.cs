using Golf80.BusinessEntities;
using Golf80.BusinessLogic.Interfaces;
using Golf80.Infrastrucure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Golf80.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentManager _manager;

        public DepartmentController(IDepartmentManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ServiceResponse<IReadOnlyCollection<DepartmentViewModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(
                ServiceResponseHelper
                .GetSuccessResponse(
                    await
                    _manager
                    .GetAllAsync()
                    )
                );
        }
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ServiceResponse<DepartmentViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
        public async Task<IActionResult> GetAllAsync(int id)
        {
            return Ok(
                ServiceResponseHelper
                .GetSuccessResponse(
                    await
                    _manager
                    .GetAsync(id)
                    )
                );
        }
        [HttpPost]
        [ProducesResponseType(typeof(ServiceResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
        public async Task<IActionResult> AddAsync(DepartmentAddModel department)
        {
            return Ok(
                ServiceResponseHelper
                .GetSuccessResponse(
                    await
                    _manager
                    .AddAsync(department)
                    )
                );
        }
        [HttpPut]
        [ProducesResponseType(typeof(ServiceResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
        public async Task<IActionResult> UpdateAsync(DepartmentUpdateModel department)
        {
            var result = await
                    _manager
                    .UpdateAsync(department);
            return Ok(result
                ? ServiceResponseHelper.GetSuccessResponse(result)
                : ServiceResponseHelper.GetFailureResponse<bool>());
        }
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(ServiceResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await
                    _manager
                    .DeleteAsync(id);
            return Ok(result
                ? ServiceResponseHelper.GetSuccessResponse(result)
                : ServiceResponseHelper.GetFailureResponse<bool>());
        }
    }
}
