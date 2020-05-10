using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LeetCodeUnitTest
{
    public class SampleCarTest
    {
        [Theory]
        [ClassData(typeof(CarClassData))]
        public void CarTest(Car car)
        {
            var output = car;
            Assert.NotNull(output);
        }
    }
    public class CarClassData : IEnumerable<object[]>
    {
        public Car car;
        public void PrepareData()
        {
            car = new Car
            {
                Id = 1,
                Price = 36000000,
                Manufacturer = new Manufacturer
                {
                    Country = "country",
                    Name = "name"
                }
            };
        }

        public IEnumerator<object[]> GetEnumerator()
        {
            PrepareData();

            yield return new object[] { car };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
      
    }
    public class Car
    {
        public int Id { get; set; }
        public long Price { get; set; }
        public Manufacturer Manufacturer { get; set; }
    }
    public class Manufacturer
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
}
