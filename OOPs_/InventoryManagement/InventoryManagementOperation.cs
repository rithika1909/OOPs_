using Newtonsoft.Json;
using OOPs_.DataInventoryManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPs_.InventoryManagement
{
    public class InventoryManagementOperation
    {
        InventoryManagementDetails list;
        public void ReadInventoryJson(string filePath)
        {
            var json = File.ReadAllText(filePath);
            list = JsonConvert.DeserializeObject<InventoryManagementDetails>(json);
            Console.WriteLine("RiceList:");
            Display(list.RiceList);
            Console.WriteLine("WheatList:");
            Display(list.WheatList);
            Console.WriteLine("PulsesList:");
            Display(list.PulsesList);
        }
        public void AddInventoryManagement(string objectName)
        {
            InventoryDetails details = new InventoryDetails()
            {
                Name = Console.ReadLine(),
                Weight = Convert.ToInt32(Console.ReadLine()),
                PricePerKg = Convert.ToInt32(Console.ReadLine())
            };
            if (objectName.ToLower().Equals("rice"))
            {
                list.RiceList.Add(details);
            }
            if (objectName.ToLower().Equals("wheat"))
            {
                list.WheatList.Add(details);
            }
            if (objectName.ToLower().Equals("pulse"))
            {
                list.PulsesList.Add(details);
            }
        }
        public void DeleteInventoryManagement(string objectName, string inventoryName)
        {
            InventoryDetails details = new InventoryDetails();
            if (objectName.ToLower().Equals("rice"))
            {
                foreach (var data in list.RiceList)
                {
                    if (data.Name.Equals(inventoryName))
                        details = data;
                }
                if (details != null)
                    list.RiceList.Remove(details);
            }
            if (objectName.ToLower().Equals("wheat"))
            {
                foreach (var data in list.WheatList)
                {
                    if (data.Name.Equals(inventoryName))
                        details = data;
                }
                if (details != null)
                    list.WheatList.Remove(details);
            }
            if (objectName.ToLower().Equals("pulses"))
            {
                foreach (var data in list.PulsesList)
                {
                    if (data.Name.Equals(inventoryName))
                        details = data;
                }
                if (details != null)
                    list.PulsesList.Remove(details);
            }
            if (details == null)
                Console.WriteLine("No inventory details exist");
        }
        public void EditInventoryManagement(string objectName, string inventoryName)
        {
            InventoryDetails details = new InventoryDetails();
            if (objectName.ToLower().Equals("rice"))
            {
                foreach (var data in list.RiceList)
                {
                    if (data.Name.Equals(inventoryName))
                        details = data;
                }
                if (details != null)
                {
                    Console.WriteLine("Enter the option to edit\n 1.Name 2.Weight 3.PricePerKg");
                    int option = Convert.ToInt32(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            Console.WriteLine("Enter Name");
                            details.Name = Console.ReadLine();
                            break;
                        case 2:
                            Console.WriteLine("Enter Weight");
                            details.Weight = Convert.ToInt32(Console.ReadLine());
                            break;
                        case 3:
                            Console.WriteLine("Enter PricePerKg");
                            details.PricePerKg = Convert.ToInt32(Console.ReadLine());
                            break;
                    }
                }



            }
            if (objectName.ToLower().Equals("wheat"))
            {
                foreach (var data in list.WheatList)
                {
                    if (data.Name.Equals(inventoryName))
                        details = data;
                }
                if (details != null)
                {
                    Console.WriteLine("Enter the option to edit\n 1.Name 2.Weight 3.PricePerKg");
                    int option = Convert.ToInt32(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            Console.WriteLine("Enter Name");
                            details.Name = Console.ReadLine();
                            break;
                        case 2:
                            Console.WriteLine("Enter Weight");
                            details.Weight = Convert.ToInt32(Console.ReadLine());
                            break;
                        case 3:
                            Console.WriteLine("Enter PricePerKg");
                            details.PricePerKg = Convert.ToInt32(Console.ReadLine());
                            break;
                    }
                }
            }
            if (objectName.ToLower().Equals("pulses"))
            {
                foreach (var data in list.PulsesList)
                {
                    if (data.Name.Equals(inventoryName))
                        details = data;
                }
                if (details != null)
                {
                    Console.WriteLine("Enter the option to edit\n 1.Name 2.Weight 3.PricePerKg");
                    int option = Convert.ToInt32(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            Console.WriteLine("Enter Name");
                            details.Name = Console.ReadLine();
                            break;
                        case 2:
                            Console.WriteLine("Enter Weight");
                            details.Weight = Convert.ToInt32(Console.ReadLine());
                            break;
                        case 3:
                            Console.WriteLine("Enter PricePerKg");
                            details.PricePerKg = Convert.ToInt32(Console.ReadLine());
                            break;
                    }
                }
            }
        }
        public void WriteToJsonFile(string filePath)
        {
            var json = JsonConvert.SerializeObject(list);
            File.WriteAllText(filePath, json);
        }
        public void Display(List<InventoryDetails> list)
        {
            foreach (var data in list)
            {
                Console.WriteLine("Name:" + data.Name + " Weight:" + data.Weight + " PricePerKg:" + data.PricePerKg);
            }
        }
    }
}
