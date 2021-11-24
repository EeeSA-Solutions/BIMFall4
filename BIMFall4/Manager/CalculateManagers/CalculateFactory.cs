using BIMFall4.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIMFall4.Manager.CalculateManagers
{
    public class CalculateFactory : ICalculateFactory
    {
        public Calculate Create()
        {
            Calculate factory = new Calculate();
            return factory;
        }
    }
}