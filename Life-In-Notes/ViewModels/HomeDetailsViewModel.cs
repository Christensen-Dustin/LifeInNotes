﻿using Life_In_Notes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Life_In_Notes.ViewModels
{
    public class HomeDetailsViewModel
    {
        public Entry Entry { get; set; }

        public string PageTitle { get; set; }

        public string Title { get; set; }
    }
}
