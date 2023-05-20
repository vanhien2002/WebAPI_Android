using System;
using System.Collections.Generic;

namespace WebAPI_Android.Models.Entities;

public partial class Loaithucuong
{
    public string Maloai { get; set; } = null!;

    public string? Tenloai { get; set; }

    public virtual ICollection<Thucuong> Thucuongs { get; set; } = new List<Thucuong>();
}
