using System;
using System.Collections.Generic;
using System.Text;

namespace EfCore_3
{
    public class Instructor
    {
        public int Id { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string? Bio { get; set; }

        public DateTime JoinedDate { get; set; }

        public ICollection<Course> Courses { get; set; }
            = new List<Course>();
    }
}
