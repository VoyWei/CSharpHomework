using Microsoft.VisualStudio.TestTools.UnitTesting;
using Program1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program1.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        List<Order> orders = new List<Order>();

        [TestMethod()]
        public void DisplayOrderListTest()
        {   
            Assert.AreEqual(orders, orders);
        }

        [TestMethod()]
        public void AddOrderTest()
        {
            Assert.AreEqual(orders, orders);
        }

        [TestMethod()]
        public void DeleteOrderTest()
        {
            Assert.AreEqual(orders, orders);
        }

        [TestMethod()]
        public void SearchTest()
        {
            Assert.AreEqual(orders, orders);
        }

        [TestMethod()]
        public void SearchByOrderIDTest()
        {
            Assert.AreEqual(orders, orders);
        }

        [TestMethod()]
        public void SearchByProductNameTest()
        {
            Assert.AreEqual(orders, orders);
        }

        [TestMethod()]
        public void SearchByCustomerNameTest()
        {
            Assert.AreEqual(orders, orders);
        }

        [TestMethod()]
        public void EditOrderTest()
        {
            Assert.AreEqual(orders, orders);
        }

        [TestMethod()]
        public void ExportTest()
        {
            Assert.AreEqual(orders, orders);
        }

        [TestMethod()]
        public void ImportTest()
        {
            Assert.AreEqual(orders, orders);
        }
    }
}