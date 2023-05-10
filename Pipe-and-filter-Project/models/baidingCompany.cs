using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pipe_and_filte.Models
{
    public class baidingCompany
    {
        public int ID { get; set; }
        public string Nmae { get; set; }
        public string LicenseID { get; set; }
        public DateTime Vilidation { get; set; }
        
        public string filed { get; set; }
        public int RFQID { get; set; }
        public int diration { get; set; }
        public int cost { get; set; }
        
        public string filterStep { get; set; } 
        public virtual RFQ RFQ { get; set; }

    }
}