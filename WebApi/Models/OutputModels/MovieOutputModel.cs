using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class MovieOutputModel
    {
        public int MvId { get; set; }
        public string MvTitle { get; set; } = null!;
        public string MvDate { get; set; } = null!;
        public int? GrId { get; set; }
    }
}
