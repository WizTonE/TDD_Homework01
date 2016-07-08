using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDD_Homework1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpectedObjects;

namespace TDD_Homework1.Tests
{
    class Order
    {
        public int Id { get; set; }
        public int Cost { get; set; }
        public int Revenue { get; set; }
        public int Sellprice { get; set; }
    }

    [TestClass()]
    public class OrderPagingTests
    {
        private IEnumerable<Order> orders { get; set; }

        //測試專案初始化
        [TestInitialize]
        public void InitialOrders()
        {
            orders = new List<Order>
            {
                new Order() { Id=1,  Cost=1,  Revenue=11,  Sellprice=21 },
                new Order() { Id=2,  Cost=2,  Revenue=12,  Sellprice=22 },
                new Order() { Id=3,  Cost=3,  Revenue=13,  Sellprice=23 },
                new Order() { Id=4,  Cost=4,  Revenue=14,  Sellprice=24 },
                new Order() { Id=5,  Cost=5,  Revenue=15,  Sellprice=25 },
                new Order() { Id=6,  Cost=6,  Revenue=16,  Sellprice=26 },
                new Order() { Id=7,  Cost=7,  Revenue=17,  Sellprice=27 },
                new Order() { Id=8,  Cost=8,  Revenue=18,  Sellprice=28 },
                new Order() { Id=9,  Cost=9,  Revenue=19,  Sellprice=29 },
                new Order() { Id=10, Cost=10, Revenue=20,  Sellprice=30 },
                new Order() { Id=11, Cost=11, Revenue=21,  Sellprice=31 },
            };
        }

        [TestMethod()]
        public void Get_Cost_Property_expected_List_6_15_24_21()
        {
            //Arrange
            var expected = new List<int> { 6, 15, 24, 21 };
            var service = new OrderProcess();

            //Act
            Func<Order, int> selectProperty = s => s.Cost;
            var actual = service.GetDataByPaging(orders, 3, selectProperty);
            
            //Assert
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        [TestMethod()]
        public void Get_Revenue_Property_expected_List_50_66_60()
        {
            //Arrange
            var expected = new List<int> { 50, 66, 60 };
            var service = new OrderProcess();
            
            //Act
            Func<Order, int> selectProperty = s => s.Revenue;
            var actual = service.GetDataByPaging(orders, 4, selectProperty);
            
            //Assert
            expected.ToExpectedObject().ShouldEqual(actual);
        }
    }
}