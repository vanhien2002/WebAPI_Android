using System;
using System.Collections.Generic;

namespace WebAPI_Android.Models.Entities;

public partial class Thucuong
{
    public string Manuoc { get; set; } = null!;

    public string? Maloai { get; set; }

    public string? Tennuoc { get; set; }

    public double? Gia { get; set; }

    public string? Size { get; set; }

    public string? Trangthai { get; set; }

    public virtual ICollection<CtHoadon> CtHoadons { get; set; } = new List<CtHoadon>();

    public virtual Loaithucuong? MaloaiNavigation { get; set; }
}
