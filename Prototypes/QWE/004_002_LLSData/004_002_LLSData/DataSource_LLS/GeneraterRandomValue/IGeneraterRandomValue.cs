using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component.GeneraterRandomValue
{
    public interface IGeneraterRandomValue
    {
        double NextDouble();
        IGeneraterRandomValue Get_InterfaseCopy();
    }
    public class GeneraterRandomValue : Random, IGeneraterRandomValue
    {
        public IGeneraterRandomValue Get_InterfaseCopy() 
        {return ((IGeneraterRandomValue)Activator.CreateInstance(this.GetType()));}
    }
}
