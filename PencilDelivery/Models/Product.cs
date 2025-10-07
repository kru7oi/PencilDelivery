using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PencilDelivery.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    [DisplayFormat(DataFormatString = "{0:F0} ₽")]

    public decimal PricePerUnit { get; set; }

    public int UnitId { get; set; }

    public string? Volume { get; set; }

    public double Rating { get; set; }

    public string Description { get; set; } = null!;

    public string ExpirationDate { get; set; } = null!;

    public int CategoryId { get; set; }

    public int ManufacturerId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual Manufacturer Manufacturer { get; set; } = null!;

    public virtual ICollection<Photo> Photos { get; set; } = new List<Photo>();

    public virtual Unit Unit { get; set; } = null!;
}
