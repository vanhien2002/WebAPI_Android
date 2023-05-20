using System;
using System.Collections.Generic;

namespace WebAPI_Android.Models.Entities;

public partial class Ban
{
    public string Maban { get; set; } = null!;

    public string? Tenban { get; set; }

    public string? Trangthai { get; set; }

    public virtual ICollection<Hoadon> Hoadons { get; set; } = new List<Hoadon>();

    public virtual ICollection<Khachhang> Khachhangs { get; set; } = new List<Khachhang>();
}
