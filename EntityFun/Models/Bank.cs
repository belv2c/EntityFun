﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityFun.Models
{
    public class Bank
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<AccountType> AccountTypes { get; set; }
    }
}