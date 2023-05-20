using System;
using System.Collections.Generic;

namespace WebAPI_Android.Models.Entities;

public partial class Khachhang
{
    public string Makhachhang { get; set; } = null!;

    public DateTime? Thoigianden { get; set; }

    public string? Maban { get; set; }

    public virtual Ban? MabanNavigation { get; set; }
}
