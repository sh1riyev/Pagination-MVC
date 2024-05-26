using FiorelloFront.Models;
using Microsoft.EntityFrameworkCore;

namespace FiorelloFront.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext>options):base(options) { }

		public DbSet<Slider> Sliders { get; set; }
		public DbSet<SliderInfo> SliderInfo { get; set; }
		public DbSet<Blog>  Blogs { get; set; }
        public DbSet<Experts> Experts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Setting> Settings{ get; set; }
        public DbSet<Social> Socials { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>().HasQueryFilter(m => !m.IsDeleted);
            modelBuilder.Entity<Category>().HasQueryFilter(m => !m.IsDeleted);
            modelBuilder.Entity<Product>().HasQueryFilter(m => !m.IsDeleted);


            modelBuilder.Entity<Social>().HasData(
                new Social
                {
                    Id=1,
                    Name="Twitter",
                    Url= "https://twitter.com/home",
                    Icon= "<i class=\"fa-brands fa-twitter\"></i>"
                },
                   new Social
                   {
                       Id = 2,
                       Name = "Instagram",
                       Url = "https://www.instagram.com/",
                       Icon = "<i class=\"fa-brands fa-instagram\"></i>"
                   },
                      new Social
                      {
                          Id = 3,
                          Name = "Tumblr",
                          Url = "https://www.tumblr.com/",
                          Icon = "<i class=\"fa-brands fa-tumblr\"></i>"
                      },
                         new Social
                         {
                             Id = 4,
                             Name = "Pinterest",
                             Url = "https://www.pinterest.com/",
                             Icon = "<i class=\"fa-brands fa-pinterest\"></i>"
                         }

            );
            modelBuilder.Entity<Setting>().HasData(
                new Setting
                {
                    Id=1,
                    Key="HeaderLogo",
                    Value="logo.png"
                },
                  new Setting
                  {
                      Id = 2,
                      Key = "Phone",
                      Value = "+994508802323"
                  }
                );
            modelBuilder.Entity<Blog>().HasData(
				new Blog
				{
                    Id = 1,
                    Title = "Blog Ilgar",
                    Description = "Salam",
                    Image = "blog-feature-img-1.jpg",
                    CreateDate = DateTime.Now,
                    IsDeleted = false
                },
                new Blog
                {
                    Id = 2,
                    Title = "Blog Kmaran",
                    Description = "Salam",
                    Image = "blog-feature-img-3.jpg",
                    CreateDate = DateTime.Now,
                    IsDeleted = false


                },
                 new Blog
                {
                 Id = 3,
                 Title = "Blog Orxan",
                 Description = "Salam",
                 Image = "blog-feature-img-4.jpg",
                 CreateDate = DateTime.Now,
                 IsDeleted = false


                 }

                );


            modelBuilder.Entity<Experts>().HasData(
                new Experts
                {
                    Id = 1,
                    Image = "h3-team-img-1.png",
                    Name = "CRYSTAL BROOKS",
                    Position = "Florist",
                    IsDeleted = false,
                    CreateDate = DateTime.Now
                },
                      new Experts
                      {
                          Id = 2,
                          Image = "h3-team-img-2.png",
                          Name = "SHIRLEY HARRIS",
                          Position = "Manager",
                          IsDeleted = false,
                          CreateDate = DateTime.Now
                      },
                            new Experts
                            {
                                Id = 3,
                                Image = "h3-team-img-3.png",
                                Name = "BEVERLY CLARK",
                                Position = "Florist",
                                IsDeleted = false,
                                CreateDate = DateTime.Now
                            },
                                 new Experts
                                 {
                                     Id = 4,
                                     Image = "h3-team-img-4.png",
                                     Name = "AMANDA WATKINS",
                                     Position = "Florist",
                                     IsDeleted = false,
                                     CreateDate = DateTime.Now
                                 }
                );
        }
    }
}

