using System;
using System.Collections.Generic;

namespace StudentMarksAPI.Models;

public partial class TblBookMaster
{
    public int BookId { get; set; }

    public string Title { get; set; } = null!;

    public string Author { get; set; } = null!;

    public float Price { get; set; }
}
