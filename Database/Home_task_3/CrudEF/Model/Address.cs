
namespace CrudEF.Model;

public partial class Address
{
    public int Id { get; set; }

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual DataArtisian? DataArtisian { get; set; }

    public virtual ICollection<DeliveryOrder> DeliveryOrderDeliveryAddresses { get; set; } = new List<DeliveryOrder>();

    public virtual ICollection<DeliveryOrder> DeliveryOrderShippingAddresses { get; set; } = new List<DeliveryOrder>();

    public virtual ICollection<ManufactoryHub> ManufactoryHubs { get; set; } = new List<ManufactoryHub>();
}

