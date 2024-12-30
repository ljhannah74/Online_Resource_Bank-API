using System;

namespace orb_api.DTO;

public class ResourceDTO
{
    public int ResourceID { get; set; }
    public int ORBId { get; set; }
    public int ResourceTypeID { get; set; }
    public string? URL { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public DateTime? IndexDate { get; set; }
    public DateTime? ImageDate { get; set; }
    public string? Source { get; set; }
    public string? Address { get; set; }
    public string? State { get; set; }
    public string? City { get; set; }
    public string? Zip { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
}
