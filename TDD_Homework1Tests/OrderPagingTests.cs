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
        public int ID { get; set; }
        public int COST { get; set; }
        public int REVENUE { get; set; }
        public int SELLPRICE { get; set; }
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
                new Order() { ID=1,  COST=1,  REVENUE=11,  SELLPRICE=21 },
                new Order() { ID=2,  COST=2,  REVENUE=12,  SELLPRICE=22 },
                new Order() { ID=3,  COST=3,  REVENUE=13,  SELLPRICE=23 },
                new Order() { ID=4,  COST=4,  REVENUE=14,  SELLPRICE=24 },
                new Order() { ID=5,  COST=5,  REVENUE=15,  SELLPRICE=25 },
                new Order() { ID=6,  COST=6,  REVENUE=16,  SELLPRICE=26 },
                new Order() { ID=7,  COST=7,  REVENUE=17,  SELLPRICE=27 },
                new Order() { ID=8,  COST=8,  REVENUE=18,  SELLPRICE=28 },
                new Order() { ID=9,  COST=9,  REVENUE=19,  SELLPRICE=29 },
                new Order() { ID=10, COST=10, REVENUE=20,  SELLPRICE=30 },
                new Order() { ID=11, COST=11, REVENUE=21,  SELLPRICE=31 },
            };
        }

        [TestMethod()]
        public void Get_Cost_Property_expected_List_6_15_24_21()
        {
            //Arrange
            var expected = new List<int> { 6, 15, 24, 21 };
            var service = new OrderProcess();

            //Act
            Func<Order, int> selectProperty = s => s.COST;
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
            Func<Order, int> selectProperty = s => s.REVENUE;
            var actual = service.GetDataByPaging(orders, 4, selectProperty);
            
            //Assert
            expected.ToExpectedObject().ShouldEqual(actual);
        }
    }
}