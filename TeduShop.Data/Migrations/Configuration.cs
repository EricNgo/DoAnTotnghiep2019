namespace TeduShop.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TeduShop.Model.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TeduShop.Data.TeduShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TeduShop.Data.TeduShopDbContext context)
        {
            CreateProductCategorySample(context);
            CreateSlide(context);
            //  This method will be called after migrating to the latest version.

            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new TeduShopDbContext()));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new TeduShopDbContext()));

            var user = new ApplicationUser()
            {
                UserName = "huyenle",
                Email = "huyenle.international@gmail.com",
                EmailConfirmed = true,
                BirthDay = DateTime.Now,
                FullName = "LeHuyen"

            };

            manager.Create(user, "12345678$");

            if (!roleManager.Roles.Any())
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
                roleManager.Create(new IdentityRole { Name = "User" });
            }

            var adminUser = manager.FindByEmail("huyenle.international@gmail.com");

            manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });

        }

        private void CreateProductCategorySample(TeduShop.Data.TeduShopDbContext context)
        {
            if (context.ProductCategories.Count() == 0)
            {
                List<ProductCategory> listProductCategory = new List<ProductCategory>()
            {

                     new ProductCategory() { Name="MotorBike",Alias="motorbike",Status=true }
            };
                context.ProductCategories.AddRange(listProductCategory);
                context.SaveChanges();
            }

        }

        private void CreateSlide(TeduShopDbContext context)
        {
            if (context.Slides.Count() == 0)
            {
                List<Slide> listSlide = new List<Slide>()
                {
                    new Slide() {
                        Name ="Slide 1",
                        DisplayOrder =1,
                        Status =true,
                        Url ="#",
                        Image ="/Assets/client/images/bik1.jpg",
                        Content =   @"   <a href=""#""><h5>Mountain Bike 1<span>$114.00</span></h5></a>
                    <a class=""add-cart"" href=""single.html"">Quick Views</a>
                    <a class=""qck"" href=""single.html"">BUY NOWs</a>" },
                    new Slide() {
                        Name ="Slide 2",
                        DisplayOrder =2,
                        Status =true,
                        Url ="#",
                        Image ="/Assets/client/images/bik2.jpg",
                    Content=  @"   <a href=""#""><h5>Mountain Bike 2 <span>$70.00</span></h5></a>
                    <a class=""add-cart"" href=""single.html"">Quick View</a>
                    <a class=""qck"" href=""single.html"">BUY NOW</a>" },
                    new Slide() {
                        Name ="Slide 3",
                        DisplayOrder =3,
                        Status =true,
                        Url ="#",
                        Image ="/Assets/client/images/bik3.jpg",
                    Content=  @"   <a href=""#""><h5>Mountain Bike 3 <span>$40.00</span></h5></a>
                    <a class=""add-cart"" href=""single.html"">Quick View</a>
                    <a class=""qck"" href=""single.html"">BUY NOW</a>" }
                };
                context.Slides.AddRange(listSlide);
                context.SaveChanges();
            }
        }
    }
}
