using System;
using System.Collections.Generic;

namespace nobsDAL;

public partial class PlannerItem
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? DueDate { get; set; }

    public bool? isCompleted { get; set; }
}
