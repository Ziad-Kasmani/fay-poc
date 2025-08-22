namespace SocietyManagement.Application.DTOs;

public class VendorDto
{
    public Guid? Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ServiceType { get; set; } = string.Empty;
    public string ContactPerson { get; set; } = string.Empty;
    public string MobileNumber { get; set; } = string.Empty;
    public Guid SocietyId { get; set; }
}
