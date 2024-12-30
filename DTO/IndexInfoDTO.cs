using System;

namespace orb_api.DTO;

public class IndexInfoDTO
{
    public int Id { get; set; }
    public int ORBId { get; set; }
    public bool Copy { get; set; }
    public bool Props { get; set; }
    public bool Insurance { get; set; }
    public bool Rv { get; set; }
    public bool Tap { get; set; }
    public bool DTree { get; set; }
}
