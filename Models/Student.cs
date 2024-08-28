using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPI_Student.Models;

public partial class Student
{
    [Key]
    public int Id { get; set; }

    public string? StudentName { get; set; }

    public string? StudentGender { get; set; }

    public int? Age { get; set; }

    public int? Class { get; set; }

    public string? FatherName { get; set; }
}
