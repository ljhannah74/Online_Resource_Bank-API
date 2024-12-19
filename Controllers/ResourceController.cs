using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using orb_api.BLL;
using orb_api.DAL;
using orb_api.DTO;

namespace orb_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        private ResourceBLL _resourceBLL = new ResourceBLL();

        [HttpGet]
        public ApiResponse<IEnumerable<StateDTO>> GetStates()
        {
            ApiResponse<IEnumerable<StateDTO>> response = ApiResponseUtil<IEnumerable<StateDTO>>.GetApiResponse(HttpStatusCode.OK);

            var stateList = _resourceBLL.GetStates();
            
            response.data = stateList;

            return response;
        }

        [HttpGet("{stateID}")]
        public ApiResponse<IEnumerable<CountyDTO>> GetCountiesByState(int stateID)
        {
            ApiResponse<IEnumerable<CountyDTO>> response = ApiResponseUtil<IEnumerable<CountyDTO>>.GetApiResponse(HttpStatusCode.OK);

            var countyList = _resourceBLL.GetCountiesByState(stateID);
            
            response.data = countyList;

            return response;
        }
    }
}
