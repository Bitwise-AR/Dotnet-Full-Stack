using System;
using System.Collections.Generic;

namespace StudentMarksAPI.Models;

public partial class TblStudentMaster
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int M1 { get; set; }

    public int M2 { get; set; }
}
