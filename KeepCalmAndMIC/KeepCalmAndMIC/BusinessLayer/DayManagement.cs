﻿using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KeepCalmAndMIC.BusinessLayer
{
    public class DayManagement : BaseManagement<DayManagement>
    {
        public DayManagement (IOwinContext owinContext) : base(owinContext) { }
    }
}