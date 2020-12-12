using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAdmin
{
    public interface IConstructor<T>
    {
        T FillClass(params string[] values);
    }
}
