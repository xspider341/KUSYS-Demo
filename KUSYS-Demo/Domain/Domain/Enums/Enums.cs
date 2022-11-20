using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public enum Role
    {
        [Description("Admin")]
        Admin = 1,
        [Description("User")]
        User = 2
    }
}
