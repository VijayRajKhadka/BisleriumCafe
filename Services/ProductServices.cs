using BisleriumCafe.Components.Pages;
using BisleriumCafe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisleriumCafe.Services
{
    public class ProductServices : JsonServices<Coffee>
    {
        public static string coffeeProductFilePath = Utility.GetCoffeeDirectoryPath();

        
        public List<Coffee> CreateCoffee(String title, String description, Double price)
        {
            title = title.Trim().ToLower();
            description = description.Trim().ToLower();

            var coffee = GetAllData(coffeeProductFilePath);

            var coffeeExists = coffee.Any(x => x.Title.ToLower() == title);

            if (coffeeExists)
            {
                throw new Exception("Product with the same already exists, Please add any other title.");
            }

            var coffeeProduct = new Coffee()
            {
                Title = title,
                Description = description,
                Price = price

            };

            coffee.Add(coffeeProduct);

            SaveData(coffee, coffeeProductFilePath);

            return coffee;
        }


        public static List<Coffee> Delete(Guid id)
        {
            var coffees = GetAllData(coffeeProductFilePath);

            var coffee = coffees.FirstOrDefault(x => x.Id == id);

            if (coffee == null)
            {
                throw new Exception("Coffee not found.");
            }

            coffees.Remove(coffee);

            SaveData(coffees, coffeeProductFilePath);

            return coffees;
        }

        public List<Coffee> Update(Guid id, string title, string description, Double price)
        {


            var coffees = GetAllData(coffeeProductFilePath);

            var coffee = coffees.FirstOrDefault(x => x.Id ==id);

            if (coffee == null)
            {
                throw new Exception("Coffee not found.");
            }

            coffee.Title = title;
            coffee.Description = description;
            coffee.Price = price;
            coffee.LastModifiedAt = DateTime.Now;

            SaveData(coffees, coffeeProductFilePath);

            return coffees;
        }
        public static Coffee GetCoffeeByName(string name)
        {
            var coffees = GetAllData(coffeeProductFilePath).FirstOrDefault(x => x.Title == name);
            if (coffees == null)
            {
                throw new Exception("Coffee not found.");
            }
            return coffees;
        }
    }
    public class AddinsServices : JsonServices<AddIns>
    {
        public static string addinsFilePath = Utility.GetAddinsDirectoryPath();

        public List<AddIns> CreateAddins(String name, String unit, Double unitPrice)
        {
            name = name.Trim().ToLower();
            unit = unit.Trim().ToLower();

            var addins = GetAllData(addinsFilePath);

            var addinsExists = addins.Any(x => x.Name.ToLower() == name);

            if (addinsExists)
            {
                throw new Exception("Product with the same already exists, Please add any other title.");
            }

            var addinsProduct = new AddIns()
            {
                Name = name,
                Unit = unit,
                UnitPrice = unitPrice

            };

            addins.Add(addinsProduct);

            SaveData(addins, addinsFilePath);

            return addins;
        }


        public static List<AddIns> Delete(Guid id)
        {
            var addins = GetAllData(addinsFilePath);

            var addin = addins.FirstOrDefault(x => x.Id == id);

            if (addin == null)
            {
                throw new Exception("Addins not found.");
            }

            addins.Remove(addin);

            SaveData(addins, addinsFilePath);

            return addins;
        }

        public List<AddIns> Update(Guid id, string name, string unit, Double unitPrice)
        {


            var addins = GetAllData(addinsFilePath);

            var addin = addins.FirstOrDefault(x => x.Id == id);

            if (addin == null)
            {
                throw new Exception("Addins not found.");
            }

            addin.Name = name;
            addin.Unit= unit;
            addin.UnitPrice = unitPrice;
            addin.LastModifiedAt = DateTime.Now;

            SaveData(addins, addinsFilePath);

            return addins;
        }
        public static AddIns GetAddinsByName(string name)
        {
            var addins = GetAllData(addinsFilePath).FirstOrDefault(x => x.Name == name);
            if (addins == null)
            {
                throw new Exception("Coffee not found.");
            }
            return addins;
        }
    }
}
