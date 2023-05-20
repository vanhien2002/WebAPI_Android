using System;
using System.Collections.Generic;

namespace WebAPI_Android.Models.Entities;

public partial class Nhanvien
{
    public string Manhanvien { get; set; } = null!;

    public string? Machucvu { get; set; }

    public string? Tennhanvien { get; set; }

    public string? Gioitinh { get; set; }

    public string? Diachi { get; set; }

    public string? Sdt { get; set; }

    public string? Taikhoan { get; set; }

    public string? Matkhau { get; set; }

    public virtual ICollection<Hoadon> Hoadons { get; set; } = new List<Hoadon>();

    public virtual Chucvu? MachucvuNavigation { get; set; }

    public virtual ICollection<NhanvienCoCalam> NhanvienCoCalams { get; set; } = new List<NhanvienCoCalam>();
}
