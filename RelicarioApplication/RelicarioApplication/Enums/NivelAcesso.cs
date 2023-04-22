using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace RelicarioApplication.Enums
{
    public enum NivelAcesso
    {
        [Description("adminstrador")]
        Adm = 1,
        [Description("voluntario")]
        Voluntario = 2
    }
}
