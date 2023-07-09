
namespace CrudEF.Model;

public partial class Payment
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public int PaymentMethodId { get; set; }

    public bool IsSuccessful { get; set; }

    public int ReceipId { get; set; }

    public virtual PaymentMethod PaymentMethod { get; set; } = null!;

    public virtual Receipt Receip { get; set; } = null!;
}
