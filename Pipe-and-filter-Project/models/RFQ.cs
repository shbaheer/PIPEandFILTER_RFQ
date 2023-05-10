using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pipe_and_filte.Models
{
    public class RFQ
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string description { get; set; }
        public int filedID { get; set; }
        public int dirationdays { get; set; }
        public virtual filed filed { get; set; }
    }
}