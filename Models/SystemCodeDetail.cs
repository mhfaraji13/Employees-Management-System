using System;
using System.ComponentModel.DataAnnotations;

namespace Employesmhfdev.Models;

public class SystemCodeDetail : UserActivity
{
    [Key]
    public int Id { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }

}
