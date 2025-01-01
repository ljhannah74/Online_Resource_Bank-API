using System.Net;
using System.Runtime.CompilerServices;
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

        [HttpGet("{stateID}/{countyID}")]
        public ApiResponse<ORBDTO> GetOrbByCounty(int stateID, int countyID)
        {
            ApiResponse<ORBDTO> response = ApiResponseUtil<ORBDTO>.GetApiResponse(HttpStatusCode.OK);

            var orbInfo = _resourceBLL.GetOrbByCounty(stateID, countyID);

            response.data = orbInfo;

            return response;
        }

        [HttpPost("AddOrUpdateResourceByOrb")]
        public ApiResponse<object> AddOrUpdateResourceByOrb(ResourceDTO resourceDTO)
        {
            ApiResponse<object> response = ApiResponseUtil<object>.GetApiResponse(HttpStatusCode.OK);

            _resourceBLL.AddOrUpdateResourceByOrb(resourceDTO);

            return response;
        }

        [HttpGet("subscriptions/{orbId}")]
        public ApiResponse<IEnumerable<SubscriptionDTO>> GetSubscriptionsByOrb(int orbId)
        {
            ApiResponse<IEnumerable<SubscriptionDTO>> response = ApiResponseUtil<IEnumerable<SubscriptionDTO>>.GetApiResponse(HttpStatusCode.OK);

            var subscriptionList = _resourceBLL.GetSubscriptionsByOrb(orbId);

            response.data = subscriptionList;

            return response;
        }
    }
}
