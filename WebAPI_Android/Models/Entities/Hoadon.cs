using System;
using System.Collections.Generic;

namespace WebAPI_Android.Models.Entities;

public partial class Hoadon
{
    public string Mahoadon { get; set; } = null!;

    public string? Manhanvien { get; set; }

    public string? Tenhoadon { get; set; }

    public DateTime? Ngayxuat { get; set; }

    public string? Trangthai { get; set; }

    public string? Maban { get; set; }

    public TimeSpan? Giora { get; set; }

    public TimeSpan? Giovao { get; set; }

    public virtual ICollection<CtHoadon> CtHoadons { get; set; } = new List<CtHoadon>();

    public virtual Ban? MabanNavigation { get; set; }

    public virtual Nhanvien? ManhanvienNavigation { get; set; }
}
