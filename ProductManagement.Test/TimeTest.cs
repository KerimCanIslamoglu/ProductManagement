using Moq;
using NUnit.Framework;
using ProductManagement.Business.Abstract;
using ProductManagement.DataAccess.Abstract;
using ProductManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Test
{
    [TestFixture]
    public class TimeTest
    {
        Mock<ITimeDal> _mockTimeDal;

        public TimeTest()
        {
            var time = new Time { Id = 1, CurrentTime = 0 };
            

            var mockTimeDal = new Mock<ITimeDal>();

            mockTimeDal.Setup(mr => mr.GetById(1)).Returns(time);

            mockTimeDal.Setup(mr => mr.Update(It.IsAny<Time>())).Callback(
                (Time target) =>
                {
                    var original = time;

                    if (original == null)
                    {
                        throw new InvalidOperationException();
                    }

                    original.Id = target.Id;
                    original.CurrentTime = target.CurrentTime;

                });


            _mockTimeDal = mockTimeDal;
        }


        [Test]
        public void TimeDal_GetInitialCurrentTime_ReturnsZero()
        {
            var time = _mockTimeDal.Object.GetById(1);

            Assert.IsNotNull(time);
            Assert.AreEqual(time.Id, 1);
            Assert.AreEqual(time.CurrentTime, 0);
        }

        [Test]
        public void TimeDal_IncreaseTime_ReturnsIncreasedCurrentTime()
        {
            var timeBeforeIncreased = _mockTimeDal.Object.GetById(1);
            var updatedTime = new Time
            {
                Id = 1,
                CurrentTime = timeBeforeIncreased.CurrentTime + 2
            };

            _mockTimeDal.Object.Update(updatedTime);

            var time = _mockTimeDal.Object.GetById(1);

            Assert.IsNotNull(time);
            Assert.AreEqual(time.Id, 1);
            Assert.AreEqual(time.CurrentTime, 2);
        }
    }
}
