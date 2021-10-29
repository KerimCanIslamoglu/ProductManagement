using ProductManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Business.Abstract
{
    public interface ITimeService
    {
        Time GetCurrentTime();
        void IncreaseCurrentTime(int increment);
        void ResetTime();
    }
}
