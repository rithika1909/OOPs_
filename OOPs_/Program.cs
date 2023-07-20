using OOPs_.DataInventoryManagement;
using System;
namespace OOPs_
{
    class Program
    {
        static string DataInventoryManagement_filePath = @"D:\OOPs_\OOPs_\DataInventoryManagement\InventoryData.json";
        public static void Main(string[] args)
        {

            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Enter the option:\n1.Data Inventory Management\n 2.Exit");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        InventoryDetailsOperation detailsOperation = new InventoryDetailsOperation();
                        detailsOperation.ReadInventoryJson(DataInventoryManagement_filePath);
                        break;
                    default:
                        flag = false;
                        break;


                }
            }
        }
    }
}
