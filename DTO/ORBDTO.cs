using System;

namespace orb_api.DTO;

public class ORBDTO
{
    public int ORBId { get; set; }
    public int StateId { get; set; }
    public int CountyId { get; set; }
    public DateTime? LastUpdate { get; set; }
    public string? CountyHomePage { get; set; }
    public string? Comments { get; set; }
}
