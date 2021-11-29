﻿using BIMFall4.Manager.CalculateManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIMFall4.Interfaces
{
    interface ICalculateFactory
    {
        Calculate  Create();
    }
}