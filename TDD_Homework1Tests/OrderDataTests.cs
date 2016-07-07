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
    class OrderModel
    {
        public int ID { get; set; }
        public int COST { get; set; }
        public int REVENUE { get; set; }
        public int SELLPRICE { get; set; }
    }

    [TestClass()]
    public class OrderDataTests
    {
        static IEnumerable<OrderModel> orderdata { get; set; }

        //測試專案初始化
        [AssemblyInitialize]
        public static void InitialOrderData(TestContext context)
        {
            orderdata = new List<OrderModel>
            {
                new OrderModel() { ID=1,  COST=1,  REVENUE=11,  SELLPRICE=21 },
                new OrderModel() { ID=2,  COST=2,  REVENUE=12,  SELLPRICE=22 },
                new OrderModel() { ID=3,  COST=3,  REVENUE=13,  SELLPRICE=23 },
                new OrderModel() { ID=4,  COST=4,  REVENUE=14,  SELLPRICE=24 },
                new OrderModel() { ID=5,  COST=5,  REVENUE=15,  SELLPRICE=25 },
                new OrderModel() { ID=6,  COST=6,  REVENUE=16,  SELLPRICE=26 },
                new OrderModel() { ID=7,  COST=7,  REVENUE=17,  SELLPRICE=27 },
                new OrderModel() { ID=8,  COST=8,  REVENUE=18,  SELLPRICE=28 },
                new OrderModel() { ID=9,  COST=9,  REVENUE=19,  SELLPRICE=29 },
                new OrderModel() { ID=10, COST=10, REVENUE=20, SELLPRICE=30 },
                new OrderModel() { ID=11, COST=11, REVENUE=21, SELLPRICE=31 },
            };
        }

        [TestMethod()]
        public void Get_Cost_Property_expected_List_6_15_24_21()
        {
            //Arrange
            var expected = new List<int> { 6, 15, 24, 21 };
            var service = new OrderData<OrderModel>();
            service.SetDatasource(orderdata);


            //Act
            Func<OrderModel, int> selectProperty = s => s.COST;
            var actual = service.GetDataByGroup(3, selectProperty);


            //Assert
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        [TestMethod()]
        public void Get_Revenue_Property_expected_List_50_66_60()
        {
            //Arrange
            var expected = new List<int> { 50, 66, 60 };
            var service = new OrderData<OrderModel>();
            service.SetDatasource(orderdata);


            //Act
            Func<OrderModel, int> selectProperty = s => s.REVENUE;
            var actual = service.GetDataByGroup(4, selectProperty);


            //Assert
            expected.ToExpectedObject().ShouldEqual(actual);
        }
    }
}