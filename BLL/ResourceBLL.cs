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

    public ORBDTO GetOrbByCounty(int stateId, int countyId)
    {
        return _context.GetOrbByCounty(stateId, countyId);
    }

    public void AddOrUpdateResourceByOrb(ResourceDTO resourceDTO)
    {
        _context.AddOrUpdateResourceByOrb(resourceDTO);
    }

    public IEnumerable<SubscriptionDTO> GetSubscriptionsByOrb(int orbId)
    {
        return _context.GetSubscriptionsByOrb(orbId);
    }
}
