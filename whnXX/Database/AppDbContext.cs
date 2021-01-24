using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using whnXX.Moldes;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;


namespace whnXX.Database
{
    // 代码数据库之间链接
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        {

        }

        public DbSet<TouristRoute> TouristRoutes { get; set; }
        public DbSet<TouristRoutePicture> TouristRoutePictures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //    modelBuilder.Entity<TouristRoute>().HasData(new TouristRoute()
            //    {

            //        Id = Guid.NewGuid(),
            //        Title="css",
            //        Description="ddd",
            //        OriginalPrice=0,
            //        CreateTime=DateTime.UtcNow
            //    }) ;
            var touristRouteJsonData =  File.ReadAllText(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) +  @"/Database/touristRoutesMockData.json");
            IList<TouristRoute> touristRoutes = JsonConvert.DeserializeObject<IList<TouristRoute>>(touristRouteJsonData);

            modelBuilder.Entity<TouristRoute>().HasData(touristRoutes);

            var touristRouteJsonPicturesData = File.ReadAllText(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"/Database/touristRoutePicturesMockData.json");
            IList<TouristRoutePicture> touristRoutesPictures = JsonConvert.DeserializeObject<IList<TouristRoutePicture>>(touristRouteJsonPicturesData);

            modelBuilder.Entity<TouristRoutePicture>().HasData(touristRoutesPictures);

            base.OnModelCreating(modelBuilder);
        }
    }
}
