using System;
using System.Collections.Generic;

namespace WebAPI_Android.Models.Entities;

public partial class CtHoadon
{
    public string Manuoc { get; set; } = null!;

    public string Mahoadon { get; set; } = null!;

    public string? Tennuoc { get; set; }

    public int? Sl { get; set; }

    public double? Dongia { get; set; }

    public string? Thanhtien { get; set; }

    public virtual Hoadon MahoadonNavigation { get; set; } = null!;

    public virtual Thucuong ManuocNavigation { get; set; } = null!;
}
