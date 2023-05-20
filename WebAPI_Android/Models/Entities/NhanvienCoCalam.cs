using System;
using System.Collections.Generic;

namespace WebAPI_Android.Models.Entities;

public partial class NhanvienCoCalam
{
    public string Manhanvien { get; set; } = null!;

    public string Macalam { get; set; } = null!;

    public DateTime? Thoigianvao { get; set; }

    public DateTime? Thoigianra { get; set; }

    public virtual Calam MacalamNavigation { get; set; } = null!;

    public virtual Nhanvien ManhanvienNavigation { get; set; } = null!;
}
