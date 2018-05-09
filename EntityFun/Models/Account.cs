using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityFun.Models
{
    public class Account
    {
        public virtual int Id { get; set; }
        public virtual double Balance { get; set; }
        public virtual DateTime DateOpened { get; set; }
        public virtual int InterestRate { get; set; }
        public virtual DateTime InterestRatePeriod { get; set; }
    }
}