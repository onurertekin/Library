﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Request.GeekYaparApi.Categories
{
    public class UpdateCategoriesRequest
    {
        public string name { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int status { get; set; }
    }
}
