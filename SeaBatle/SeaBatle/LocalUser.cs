﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBatle
{
    class LocalUser : IUser
    {
        public int Shoot()
        {
            Console.Write("pif");
            return 1;
        }
    }
}