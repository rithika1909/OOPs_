using Newtonsoft.Json;
using OOPs.StockManagement;
using OOPs_.InventoryManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPs_.CommercialDataProcessing
{
    public class CustomerStockOperation
    {
        List<CompanyStock> companyStock = new List<CompanyStock>();
        List<CustomerStock> customerStock = new List<CustomerStock>();
        int amount;
        public CustomerStockOperation(int amount)
        {
            this.amount = amount;
        }
        public void ReadCompanyStock(string filePath)
        {
            var json = File.ReadAllText(filePath);
            companyStock = JsonConvert.DeserializeObject<List<CompanyStock>>(json);
            Display(companyStock);

        }
        public void ReadCustomerStock(string filePath)
        {
            var json = File.ReadAllText(filePath);
            customerStock = JsonConvert.DeserializeObject<List<CustomerStock>>(json);
            Display(customerStock);

        }
        public void Display(List<CompanyStock> companyStock)
        {
            Console.WriteLine("Company Stock: ");
            foreach (var data in companyStock)
            {
                Console.WriteLine(data.StockName + " " + data.NoOfShares + " " + data.SharePrice);
            }
        }
        public void Display(List<CustomerStock> customerStock)
        {
            Console.WriteLine("Customer Stock: ");
            foreach (var data in customerStock)
            {
                Console.WriteLine(data.StockSymbol + " " + data.NoOfShares + " " + data.SharePrice);
            }
        }
        public void CustomerBuyStockFromCompany()
        {
            Console.WriteLine("Enter the stock name to buy");
            string stockName = Console.ReadLine();
            Console.WriteLine("Enter the No.of Shares");
            int shares = Convert.ToInt32(Console.ReadLine());
            CompanyStock buyStock = new CompanyStock();
            foreach (var data in companyStock)
            {
                if (data.StockName.Equals(stockName))
                {
                    buyStock = data;
                    if (data.NoOfShares >= shares && data.NoOfShares * shares >= amount)
                    {
                        data.NoOfShares -= shares;
                        amount -= data.NoOfShares * shares;
                    }
                    else
                    {
                        Console.WriteLine("Stock limit exceeded");
                    }
                }
            }
            if (buyStock == null)
                Console.WriteLine("Stock Name doesn't exists");
            else
            {
                CustomerStock buyCustomerStock = new CustomerStock();
                foreach (var stock in customerStock)
                {
                    if (stock.StockSymbol.Equals(stockName))
                    {
                        buyCustomerStock = stock;
                        stock.NoOfShares += shares;
                    }
                    else
                    {
                        buyCustomerStock.StockSymbol = stockName;
                        buyCustomerStock.NoOfShares = shares;
                        buyCustomerStock.SharePrice = buyStock.SharePrice;
                    }
                }
                customerStock.Add(buyCustomerStock);
            }
        }
        public void CustomerSellStocksToCompany()
        {
            Console.WriteLine("Enter the stock name to sell");
            string stockName = Console.ReadLine();
            Console.WriteLine("Enter the No.of Shares");
            int shares = Convert.ToInt32(Console.ReadLine());
            CustomerStock buyStock = new CustomerStock();
            foreach (var data in customerStock)
            {
                if (data.StockSymbol.Equals(stockName))
                {
                    buyStock = data;
                    if (data.NoOfShares >= shares && data.NoOfShares * shares >= amount)
                    {
                        data.NoOfShares -= shares;
                        amount -= data.NoOfShares * shares;
                    }
                    else
                    {
                        Console.WriteLine("Stock limit exceeded");
                    }
                }
            }
            if (buyStock == null)
                Console.WriteLine("Stock Name doesnt exists");
            else
            {
                CompanyStock buyCompanyStock = new CompanyStock();
                foreach (var stock in companyStock)
                {
                    if (stock.StockName.Equals(stockName))
                    {
                        buyCompanyStock = stock;
                        stock.NoOfShares += shares;
                    }
                    else
                    {
                        buyCompanyStock.StockName = stockName;
                        buyCompanyStock.NoOfShares = shares;
                        buyCompanyStock.SharePrice = buyStock.SharePrice;
                    }
                }
                companyStock.Add(buyCompanyStock);
            }
        }
        public void WriteToCompanyFile(string filePath)
        {
            var json = JsonConvert.SerializeObject(companyStock);
            File.WriteAllText(filePath, json);
        }
        public void WriteToCustomerFile(string filePath)
        {
            var json = JsonConvert.SerializeObject(customerStock);
            File.WriteAllText(filePath, json);
        }
    }
}