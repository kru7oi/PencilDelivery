using System;
using System.Collections.Generic;

namespace PencilDelivery.Models;

public partial class Photo
{
    public int Id { get; set; }

    public string Url { get; set; } = null!;

    public int ProductId { get; set; }

    public virtual Product Product { get; set; } = null!;
}
