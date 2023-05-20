using System;
using System.Collections.Generic;

namespace WebAPI_Android.Models.Entities;

public partial class Chucvu
{
    public string Machucvu { get; set; } = null!;

    public string? Tenchucvu { get; set; }

    public virtual ICollection<Nhanvien> Nhanviens { get; set; } = new List<Nhanvien>();
}
