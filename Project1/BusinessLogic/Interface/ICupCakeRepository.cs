using System;
using System.Collections.Generic;



namespace BusinessLogic.Interface
{
      public interface ICupCakeRepository
    {

         List<CupCake> GetStores(List<CupCake> locations);


         CupCake SelectStore(List<CupCake> stores, int id);

         bool SearchForCustomer(Customer customer1);

         void AddNewCustomer(Customer customer1);

         Product GetProductByTitle(string search, CupCake b);

         void AddProductToOrder(Order o, Product p);

         Customer GetCustomerByName(string firstname, string lastname);

         void MakeOrder(int customerId, int storeId, Order blogic);

         List<Product> GetInventory(int storeId, List<Product> products);

         void DeleteInventory(CupCake b, Product p);

         List<CustomerOrderHistory> GetCustomerOrderHistory(Customer custHistory);

        List<StoreOrderHistory> GetStoreOrderHistory(int id);


    }
}
