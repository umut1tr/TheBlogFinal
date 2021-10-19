using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace TheBlogFinal.Enums
{
    public enum ReadyStatus
    {
        [Description("Not Ready yet")]
        Incomplete,
        [Description("It is Ready for Production")]
        ProductionReady,
        [Description("Ready for Preview")]
        PreviewReady

    }
}
