using System;

namespace orb_api.DTO;

public class SubscriptionDTO
{
    public int SubscriptionID { get; set; }
    public int ORBId { get; set; }
    public int ResourceID { get; set; }
    public bool SubNeeded { get; set; }
    public bool WeSubscribe { get; set; }
    public string SubTerms { get; set; }
    public string SubFee { get; set; }
}
