using ProductManagement.Business.Abstract;
using ProductManagement.DataAccess.Abstract;
using ProductManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Business.Concrete
{
    public class TimeService : ITimeService
    {
        private readonly ITimeDal _timeDal;

        public TimeService(ITimeDal timeDal)
        {
            _timeDal = timeDal;
        }

        public Time GetCurrentTime()
        {
            return _timeDal.GetById(1);
        }

        public void IncreaseCurrentTime(int increment)
        {
            var currentTime = _timeDal.GetById(1);
            currentTime.CurrentTime += increment;

            _timeDal.Update(currentTime);
        }

        public void ResetTime()
        {
            var currentTime = _timeDal.GetById(1);
            currentTime.CurrentTime=0;

            _timeDal.Update(currentTime);
        }
    }
}
