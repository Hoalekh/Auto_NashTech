﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Services
{
    public partial class ListOfData
    {
       
            public List<Todo> Todos { get; set; }
        }

        public partial class Todo
        {
            public long Id { get; set; }
            public string Title { get; set; }
            public bool DoneStatus { get; set; }
            public string Description { get; set; }
        }
    
}
