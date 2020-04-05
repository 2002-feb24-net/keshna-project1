using System;
using BusinessLogic;
using Xunit;

namespace Project0_Tester
{
    public class UnitTest1
    {
        
        [Fact]
        public void CustomerFirstNameNotEmpty()
        {
            string fname = "kk";
            Customer customer = new Customer("kk", "rana");
            customer.FirstName = fname;
            Assert.Equal(customer.FirstName, fname);

        }

        [Fact]
        public void CustomerFirstNameEmpty()
        {
            Customer customer = new Customer("kk", "rana");
            Assert.ThrowsAny<ArgumentException>(() => customer.FirstName = string.Empty);
        }

        [Fact]
        public void CustomerFirstNameTooLong()
        {
            Customer customer = new Customer("kk", "rana");
            Assert.ThrowsAny<ArgumentException>(() => customer.FirstName = "aliivavwdhdhahvajhvdasjhcvavcajvdsajvalvdl");
        }

        [Fact]
        public void CustomerLastNameNotEmpty()
        {
            string lname = "John";
            Customer customer = new Customer("kk", "rana");
            customer.LastName = lname;
            Assert.Equal(customer.LastName, lname);

        }

        [Fact]
        public void CustomerLastNameEmpty()
        {
            Customer customer = new Customer("kk", "rana");
            Assert.ThrowsAny<ArgumentException>(() => customer.LastName = string.Empty);
        }

        [Fact]
        public void CustomerLastNameTooLong()
        {
            Customer customer = new Customer("kk", "rana");
            Assert.ThrowsAny<ArgumentException>(() => customer.LastName = "abwdivibwvywibvivbibsvsbmxzbvlsavapiyva");
        }

        [Fact]
        public void ProductTitleNotEmpty()
        {
            string Pname = "Chocolate";
            Product product = new Product(1, "kk", (decimal)1.0, 1);
            product.Pname = Pname;
            Assert.Equal(product.Pname, Pname);
        }

        [Fact]
        public void ProductTitleEmpty()
        {
            Product product = new Product(1, "kk", (decimal)1.0, 1);
            Assert.ThrowsAny<ArgumentException>(() => product.Pname = string.Empty);
        }

        [Fact]
        public void ProductInventoryIsZero()
        {
            Product product = new Product(1, "kk", (decimal)1.0, 1);
            Assert.ThrowsAny<ArgumentException>(() => product.InventoryAmount = 0);
        }

        [Fact]
        public void ProductInventoryIsNegative()
        {
            Product product = new Product(1, "kk", (decimal)1.0, 1);
            Assert.ThrowsAny<ArgumentException>(() => product.InventoryAmount = -10);
        }


    }
}
