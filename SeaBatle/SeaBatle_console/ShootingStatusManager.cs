using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBatle
{
    static class ShootingStatusManager
    {
        public static Status TakeShoot(IStatusManager obj)
        {
            return obj.TakeShoot();
        }
    }
}
