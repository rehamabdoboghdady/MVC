using BL.Services;
using BL.ViewModel;
using DAL;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Store.Test
{
    [TestFixture]
    public class Class1
    {
        ProductService productService;
        CategoryService categoryService;
        Product pro;
        ProductViewModel productViewModel;
        CategoryViewModel categoryViewModel;

        [SetUp]
        public void SetUp()
        {
            pro = new Product();
            productService = new ProductService();
            productViewModel = new ProductViewModel();
            categoryService = new CategoryService();
            categoryViewModel = new CategoryViewModel();
        }

        [Test]
        public void GetProduct_Test()
        {
           
            var result = productService.GetProduct(12);
            Assert.That(result.Name, Is.EqualTo("NokiaAs"));
        }

        [Test]
        public void DeleteProduct_Test()
        {

            var result = productService.DeleteProduct(10);
            Assert.That(result, Is.EqualTo(false));
        }
        [Test]
        public void CheckProductExists_Test()
        {
            productViewModel.Name = "NokiaAs";
            
            var result = productService.CheckProductExists(productViewModel);
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void UpdateProduct_Test()
        {
            productViewModel.Id = 11;
            productViewModel.Name = "Hawawie";
            productViewModel.Price = 2000;
            productViewModel.Quantity = 6;
            productViewModel.Image = "Huawei-Y7a.jpg";
            productViewModel.Color = "Rose";
            productViewModel.CategoryID = 1;

            var result = productService.UpdateProduct(productViewModel);
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void SaveNewProduct_Test()
        {
            productViewModel.Id = 16;
            productViewModel.Name = "Samsung Galaxy";
            productViewModel.Price = 5000;
            productViewModel.Quantity = 5;
            productViewModel.Image = "Samsung Galaxy S20 FE.jpg";
            productViewModel.Color = "Rose";
            productViewModel.CategoryID = 3;

            var result = productService.SaveNewProduct(productViewModel);
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void GetAllProduct_Test()
        {

            var result = productService.GetAllProduct();
            int length = productService.GetAllProduct().Count;

            Assert.That(result.Count, Is.EqualTo(length));
        }

        [Test]
        public void GetCategory_Test()
        {

            var result = categoryService.GetCategory(2);
            Assert.That(result.CategoryName, Is.EqualTo("Nokia"));
        }

        [Test]
        public void DeleteCategory_Test()
        {

            var result = categoryService.DeleteCategory(7);
            Assert.That(result, Is.EqualTo(false));
        }


        [Test]
        public void CheckCategoryExists_Test()
        {
            categoryViewModel.CategoryName = "Nokia";
            var result = categoryService.CheckCategoryExists(categoryViewModel);
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void UpdateCategory_Test()
        {
            categoryViewModel.Id = 2;
            categoryViewModel.CategoryName = "Nokia";
            categoryViewModel.Description = "fast and has some Technology and Storage";
            var result = categoryService.UpdateCategory(categoryViewModel);
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void SaveNewCategory_Test()
        {
            categoryViewModel.Id = 6;
            categoryViewModel.CategoryName = "appel";
            categoryViewModel.Description = "fast and has some Technology and Storage";
            var result = categoryService.SaveNewCategory(categoryViewModel);
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void GetAllCategory_Test()
        {

            var result = categoryService.GetAllCategory();
            int length = categoryService.GetAllCategory().Count;

            Assert.That(result.Count, Is.EqualTo(length));
        }
    }
}