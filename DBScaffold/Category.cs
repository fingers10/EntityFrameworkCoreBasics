﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DBScaffold
{
    public partial class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
