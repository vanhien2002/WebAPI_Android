using System;
using System.Collections.Generic;

namespace WebAPI_Android.Models.Entities;

public partial class Calam
{
    public string Macalam { get; set; } = null!;

    public string? Tencalam { get; set; }

    public TimeSpan? Thoigianbatdau { get; set; }

    public TimeSpan? Thoigianketthuc { get; set; }

    public virtual ICollection<NhanvienCoCalam> NhanvienCoCalams { get; set; } = new List<NhanvienCoCalam>();
}
