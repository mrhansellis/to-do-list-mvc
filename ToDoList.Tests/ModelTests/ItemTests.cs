using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList.Models;
using System.Collections.Generic;
using System;

namespace ToDoList.Tests
{
  [TestClass]
  public class ItemTests : IDisposable
  {
    public IConfiguration Configuration { get; set; }

    public void Dispose()
    {
      Item.ClearAll();
    }

    public ItemTests()
    {
      IConfigurationBuilder builder = new ConfigurationBuilder()
      .AddJsonFile("appsettings.json");
      Configuration = builder.Build();
      DBConfiguration.ConnectionString = Configuration["ConnectionStrings:TestConnection"];
    }

    /*[TestMethod]
    public void ItemConstructor_CreatesInstanceOfItem_Item()
    {
      Item newItem = new Item("test");
      Assert.AreEqual(typeof(Item), newItem.GetType());
    }
    [TestMethod]
    public void GetDescription_ReturnsDescription_String()
    {
      string description = "I am the dog.";
      Item newItem = new Item(description);
      string result = newItem.Description;
      Assert.AreEqual(description, result);
    }
    [TestMethod]
    public void SetDescription_SetDescription_String()
    {
      string description = "Walk the dog.";
      Item newItem = new Item(description);
      string updatedDescription = "Do the dishes";
      newItem.Description = updatedDescription;
      string result = newItem.Description;
      Assert.AreEqual(updatedDescription, result);
    }*/
    [TestMethod]
    public void GetAll_ReturnsEmptyList_ItemList()
    {
      List<Item> newList = new List<Item> { };
      List<Item> result = Item.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }
    [TestMethod]
    public void Equals_ReturnsTrueIfDescriptionsAreTheSame_Item()
    {
      //Arrange, Act
      Item firstItem = new Item("Mow the dog");
      Item secondItem = new Item("Mow the dog");
      //Assert
      Assert.AreEqual(firstItem, secondItem);
    }
    [TestMethod]
    public void Save_SavesToDatabase_ItemList()
    {
      //Arrange
      Item testItem = new Item("Mow the dog");
      //Act
      testItem.Save();
      List<Item> result = Item.GetAll();
      List<Item> testList = new List<Item>{testItem};
      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    
    [TestMethod]
    public void GetAll_ReturnsItems_ItemList()
    {
      string description01 = "Walk the dog";
      string description02 = "Wash the dishes";
      Item newItem1 = new Item(description01);
      newItem1.Save();
      Item newItem2 = new Item(description02);
      newItem2.Save();
      List<Item> newList = new List<Item> { newItem1, newItem2 };
      List<Item> result = Item.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }
    /*[TestMethod]
    public void GetId_ItemsInstantiateWithAnIdAndGetterReturns_Int()
    {
      string description = "Walk the dog.";
      Item newItem = new Item(description);
      int result = newItem.Id;
      Assert.AreEqual(1, result);
    }*/
    [TestMethod]
    public void Find_ReturnsCorrectItemFromDatabase_Item()
    {
      Item newItem = new Item("Walk the dog");
      Item newItem2 = newItem("wash the dishes");
      Item newItem1 = new Item(description01);
      Item newItem2 = new Item("description02");
      Item result = Item.Find(2);
      Assert.AreEqual(newItem2, result);
    }
  }
}