namespace wk8_james_kobell_cs.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using wk8_james_kobell_cs.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<wk8_james_kobell_cs.Models.wk8_james_kobell_csContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(wk8_james_kobell_cs.Models.wk8_james_kobell_csContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Carts.AddOrUpdate(x => x.Id,
            new Cart() { Id = 1, ProductID = "arm01", Name = "Freddie Arm", Price = 20.95M, Quantity = 2 },
            new Cart() { Id = 1, ProductID = "mum01", Name = "Mummy Mask", Price = 19.99M, Quantity = 2 },
            new Cart() { Id = 2, ProductID = "hulk01", Name = "Hulk Mask ", Price = 12.99M, Quantity = 4},
            new Cart() { Id = 2, ProductID = "martian01", Name = "Martian", Price = 69.99M, Quantity = 3 }
            );

            context.Categories.AddOrUpdate(x => x.CategoryID,
            new Categories { CategoryID = "costumes", ShortName = "Costumes", LongName = "Costumes" },
            new Categories { CategoryID = "decor", ShortName = "Decorations", LongName = "Party Decorations" },
            new Categories { CategoryID = "fx", ShortName = "FX", LongName = "Special Effects" },
            new Categories { CategoryID = "masks", ShortName = "Masks", LongName = "Masks" },
            new Categories { CategoryID = "props", ShortName = "Props", LongName = "Props" }
            );

            context.Costumes.AddOrUpdate(x => x.ProductID,
            new Costumes { ProductID = "frankc01", Name = "Frankenstein", Price = 39.99M },
            new Costumes { ProductID = "hippie01", Name = "Hippie", Price = 79.99M },
            new Costumes { ProductID = "jar01", Name = "JarJar", Price = 59.99M },
            new Costumes { ProductID = "martian01", Name = "Martian", Price = 69.99M },
            new Costumes { ProductID = "pow01", Name = "Austin Powers", Price = 79.99M },
            new Costumes { ProductID = "super01", Name = "Superman", Price = 39.99M }
            );

            context.Customers.AddOrUpdate(x => x.CustomerId,
            new Customer { CustomerId = 1, Fname = "John", Lname = "Doe", Address = "123 Maple St.", City = "Newtown", State = "WA", Zipcode = 98765 },
            new Customer { CustomerId = 2, Fname = "Jane", Lname = "Smith", Address = "123 Walnut St.", City = "Oldtown", State = "CA", Zipcode = 65432 }
            );

            context.Decorations.AddOrUpdate(x => x.ProductID,
            new Decorations { ProductID = "pumpkins01", Name = "Pumpkins", Price = 19.99M },
            new Decorations { ProductID = "moon02", Name = "Moon Disc", Price = 14.99M },
            new Decorations { ProductID = "moss01", Name = "Moss", Price = 9.99M },
            new Decorations { ProductID = "bat_lights01", Name = "Bat Lights", Price = 29.99M },
            new Decorations { ProductID = "scar_crow01", Name = "Scarecrow", Price = 19.99M },
            new Decorations { ProductID = "stream01", Name = "Ghost Stream", Price = 24.99M },
            new Decorations { ProductID = "vamp02", Name = "Vampire Poster", Price = 11.99M }
            );

            context.Fx.AddOrUpdate(x => x.ProductID,
            new FX { ProductID = "bl01", Name = "Black Light", Price = 89.99M },
            new FX { ProductID = "fog01", Name = "Fog Machine", Price = 129.99M },
            new FX { ProductID = "fogj01", Name = "Fog Juice 1ltr", Price = 9.95M },
            new FX { ProductID = "skullfog01", Name = "Skull Fogger", Price = 199.95M },
            new FX { ProductID = "str01", Name = "Mini-Strobe", Price = 69.99M },
            new FX { ProductID = "tlm01", Name = "Thunder/Ligntning", Price = 99.99M }
            );

            context.Masks.AddOrUpdate(x => x.ProductID,
            new Masks { ProductID = "fred01", Name = "Freddie Mask", Price = 18.99M },
            new Masks { ProductID = "mum01", Name = "Mummy Mask", Price = 19.99M },
            new Masks { ProductID = "vad01", Name = "Dark Vader", Price = 22.95M },
            new Masks { ProductID = "nix01", Name = "Nixon", Price = 9.95M },
            new Masks { ProductID = "vampm01", Name = "Vampire Mask", Price = 19.99M },
            new Masks { ProductID = "hulk01", Name = "Hulk Mask ", Price = 12.99M },
            new Masks { ProductID = "vik01", Name = "Viking Mask ", Price = 12.99M }
            );

            context.Props.AddOrUpdate(x => x.ProductID,
            new Props { ProductID = "arm01", Name = "Freddie Arm", Price = 20.95M },
            new Props { ProductID = "bats01", Name = "Flying Bats", Price = 18.95M },
            new Props { ProductID = "cat01", Name = "Deranged Cat", Price = 9.99M },
            new Props { ProductID = "head01", Name = "Mummy Head", Price = 19.95M },
            new Props { ProductID = "head02", Name = "Saw Head", Price = 29.95M },
            new Props { ProductID = "rat01", Name = "Ugly Rat", Price = 19.99M },
            new Props { ProductID = "rat02", Name = "Lrg. Ugly Rat", Price = 29.99M },
            new Props { ProductID = "skel01", Name = "Skeleton", Price = 14.95M }
            );
        }
    }
}
