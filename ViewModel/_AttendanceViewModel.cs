using SOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOP.ViewModel
{
    public class _AttendanceViewModel
    {
        public IEnumerable<Student> students { get; set; }
        public IQueryable<DateTime> dates { get; set; }
        public Dictionary<string, string> dict { get; set; }
    }
}