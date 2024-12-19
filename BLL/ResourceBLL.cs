using System;
using orb_api.DAL;
using orb_api.DTO;

namespace orb_api.BLL;

public class ResourceBLL
{
    private ResourceDAL _context = new ResourceDAL();

    public IEnumerable<StateDTO> GetStates()
    {
        return  _context.GetAllStates();
    }

    public IEnumerable<CountyDTO> GetCountiesByState(int stateId)
    {
        return _context.GetCountiesByState(stateId);
    }

    public ORBDTO GetOrbsByCounty(int stateId, int countyId)
    {
        return _context.GetOrbsByCounty(stateId, countyId).First();
    }

}
