using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIMFall4.Manager.CalculateManagers
{
    public class SummaryCalculations
    {
        /// Vi vill ha alla categories med ett värde ovasett om det finns i DB. tex groceries sätts till 0 om det inte finns en exp under den kategorin.
        /// Vill hålla det loose kopplat. 
        /// Total exp per kat, total bud per kat och kvarstående saldo per kat(bud-exp)
        /// 

        // vi behöver ett interface med metod som skapar en instans. Sen kalla på factory i nästa steg. Kanske lyfta ut logik till egen klass
        ICalculateFactory.Create() ????
    }
}