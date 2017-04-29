using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KeepCalmAndMIC.BusinessLayer
{
    public class WeekManagement : BaseManagement<WeekManagement>
    {
        public WeekManagement(IOwinContext owinContext) : base(owinContext) { }
}
}