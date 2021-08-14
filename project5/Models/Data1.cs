using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using project5.Models;

namespace project5.Models
{
    public class Data1 : DropCreateDatabaseIfModelChanges<BBBContext>
    {
        protected override void Seed(BBBContext context)
        {
            var variations = new List<Variation>
    {
                new Variation { Name = "Женские"},
                new Variation { Name = "Мужские"},
                new Variation { Name = "Унисекс"},
                new Variation { Name = "Детские"},
                new Variation { Name = "Фитнес‑браслеты"}
    };
            var brands = new List<Brand>
            {
                new Brand { Name = "Apple" },
                new Brand { Name = "Samsung" },
                new Brand { Name = "Huawei" },
                new Brand { Name = "Xiaomi" },
                new Brand { Name = "Realme" },
                new Brand { Name = "Honor" },
                new Brand { Name = "GOGPS" },
                new Brand { Name = "Garmin" },
                new Brand { Name = "Amazfit" },
                new Brand { Name = "Canyon" }
            };

            new List<Watche>
            {
                new Watche { Title = "Apple Watch Series SE", Variations = variations.Single(v => v.Name == "Унисекс"), Price = 8000, Year = 2017, Brands =  brands.Single(b => b.Name == "Apple"), WatchesBrandUrl = "/Content/Images/1.jpg" },
                new Watche { Title = "Apple Watch Series 3", Variations = variations.Single(v => v.Name == "Мужские"), Price = 9500, Year = 2018, Brands =  brands.Single(b => b.Name == "Apple"), WatchesBrandUrl = "/Content/Images/2.jpg" },
                new Watche { Title = "Apple Watch Series 4", Variations = variations.Single(v => v.Name == "Женские"), Price = 11300, Year = 2019, Brands =  brands.Single(b => b.Name == "Apple"), WatchesBrandUrl = "/Content/Images/3.jpg" },
                new Watche { Title = "Apple Watch Series 5", Variations = variations.Single(v => v.Name == "Детские"), Price = 12100, Year = 2020, Brands =  brands.Single(b => b.Name == "Apple"), WatchesBrandUrl = "/Content/Images/4.jpg" },
                new Watche { Title = "Apple Watch Series 6", Variations = variations.Single(v => v.Name == "Фитнес‑браслеты"), Price = 15000, Year = 2021, Brands =  brands.Single(b => b.Name == "Apple"), WatchesBrandUrl = "/Content/Images/5.jpg" },
                new Watche { Title = "Samsung Galaxy Watch Active 2", Variations = variations.Single(v => v.Name == "Женские"), Price = 10000, Year = 2020, Brands =  brands.Single(b => b.Name == "Samsung"), WatchesBrandUrl = "/Content/Images/6.jpg" },
                new Watche { Title = "Huawei Watch 3", Variations = variations.Single(v => v.Name == "Мужские"), Price = 2800, Year = 2018, Brands =  brands.Single(b => b.Name == "Huawei"), WatchesBrandUrl = "/Content/Images/7.jpg" },
                new Watche { Title = "Xiaomi Mi Band 6", Variations = variations.Single(v => v.Name == "Унисекс"), Price = 600, Year = 2019, Brands =  brands.Single(b => b.Name == "Xiaomi"), WatchesBrandUrl = "/Content/Images/8.jpg" },
                new Watche { Title = "Realme Watch S Smart", Variations = variations.Single(v => v.Name == "Детские"), Price = 800, Year = 2017, Brands =  brands.Single(b => b.Name == "Realme"), WatchesBrandUrl = "/Content/Images/9.jpg" },
                new Watche { Title = "HONOR Watch Magic Smart", Variations = variations.Single(v => v.Name == "Фитнес‑браслеты"), Price = 1000, Year = 2020, Brands =  brands.Single(b => b.Name == "Honor"), WatchesBrandUrl = "/Content/Images/10.jpg" },
                new Watche { Title = "GoGPS ME K13", Variations = variations.Single(v => v.Name == "Женские"), Price = 6000, Year = 2019, Brands =  brands.Single(b => b.Name == "GOGPS"), WatchesBrandUrl = "/Content/Images/11.jpg" },
                new Watche { Title = "Garmin Vivoactive 3 GPS", Variations = variations.Single(v => v.Name == "Мужские"), Price = 7700, Year = 2018, Brands =  brands.Single(b => b.Name == "Garmin"), WatchesBrandUrl = "/Content/Images/12.jpg" },
                new Watche { Title = "Canyon CNS-SW71SS", Variations = variations.Single(v => v.Name == "Унисекс"), Price = 3000, Year = 2021, Brands =  brands.Single(b => b.Name == "Canyon"), WatchesBrandUrl = "/Content/Images/13.jpg" },
               }.ForEach(b => context.Watches.Add(b));
        }
    }
}
