using CinemaTickets.Data.Enums;
using CinemaTickets.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CinemaTickets.Data
{
    public class AppDbInitilizer
    {
        public static void Seed(IApplicationBuilder applicatonBuilder)
        {
            using(var serviceScope =applicatonBuilder.ApplicationServices.CreateScope()) 
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();

                //Cinema
                if(!context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(new List<Cinema>()
                    {
                        new Cinema()
                        {
                            Name="Vox Cinema",
                            Logo="https://th.bing.com/th/id/R.eee081869fd728fee70880fc2cbdcc4c?rik=ZvGFZF5vGIsV7w&riu=http%3a%2f%2flh3.googleusercontent.com%2fODqpZTzPeWjK-nlfWryULDWFP_jf8KRixWTlzoyNgjX4NMi1CU7wCnkzv-KupgpcQ6E%3dw300&ehk=SR8YaBosfnCs9Jp%2fgMypkHfdcKar9cS8Si7jjslV%2bTo%3d&risl=&pid=ImgRaw&r=0",
                            Description = "This is the description of the Vox cinema"
                        },
                        new Cinema()
                        {
                            Name="Renaisance Cinema",
                             Logo="https://th.bing.com/th/id/OIP.xrH0ojxU_T-Sr4CevE_6cQAAAA?pid=ImgDet&rs=1",
                            Description = "This is the description of the Renaisance cinema"
                        },
                        new Cinema()
                        {
                            Name="IMax Cinema",
                             Logo="https://th.bing.com/th/id/OIP.LYYiDmJ0HWEKT3Lwz_8GYwHaDt?pid=ImgDet&rs=1",
                            Description = "This is the description of the IMax cinema"
                        },
                        new Cinema()
                        {
                            Name="Stars Cinema",
                             Logo="https://th.bing.com/th/id/R.3bbb717b81b61362a1fd6ebde6f3d60e?rik=PIGzpB2rx3X%2bNA&riu=http%3a%2f%2fphoto.elcinema.com.s3.amazonaws.com%2fuploads%2f_310x310_e37dc2f24799b7a7a6205fd505db5aa11c3657f0f10a6c7f5ad9dfeffa977d66.jpg&ehk=l9pe9EgJGiQtUUFIRL3o3z%2fnH5DXGkV6%2bhTdft%2bsEfM%3d&risl=&pid=ImgRaw&r=0",
                            Description = "This is the description of the Stars cinema"
                        }
                    });
                    context.SaveChanges();
                }
                //Actors
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                            FullName = "Karim Abdel Aziz",
                            ProfilePictureUrl="https://www.themoviedb.org/t/p/w600_and_h900_bestv2/wp2xdch9SqrrpzsJNsZMJd2vRT5.jpg",
                            Bio="This is Bio of Karim Abdel Aziz"
                        },
                        new Actor()
                        {
                            FullName = "Ahmed Helmy",
                            ProfilePictureUrl="https://th.bing.com/th/id/R.91e017c6663bc6e739102750b4c71f98?rik=UDhbJPfCxuuEyg&pid=ImgRaw&r=0",
                            Bio="This is Bio of Ahmed Helmy"
                        },
                        new Actor()
                        {
                            FullName = "Aser Yassin",
                            ProfilePictureUrl="https://th.bing.com/th/id/OIP.wcX_Hvqlr3as60-8tDLDDAHaLH?pid=ImgDet&rs=1",
                            Bio="This is Bio of Aser Yassin"
                        },
                        new Actor()
                        {
                            FullName = "Ahmed Ezz",
                            ProfilePictureUrl="https://www.themoviedb.org/t/p/original/bFGhz5cnjJvwm2zmbIhqKtxs2wk.jpg",
                            Bio="This is Bio of Ahmed Ezz"
                        }
                    });
                    context.SaveChanges();
                }
                //producer
                if (!context.producers.Any())
                {
                    context.producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                            FullName = "Producer 1",
                            Bio = "This is the Bio of the first actor",
                            ProfilePictureUrl = "http://dotnethow.net/images/producers/producer-1.jpeg"

                        },
                        new Producer()
                        {
                            FullName = "Producer 2",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureUrl = "http://dotnethow.net/images/producers/producer-2.jpeg"
                        },
                        new Producer()
                        {
                            FullName = "Producer 3",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureUrl = "http://dotnethow.net/images/producers/producer-3.jpeg"
                        },
                        new Producer()
                        {
                            FullName = "Producer 4",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureUrl = "http://dotnethow.net/images/producers/producer-4.jpeg"
                        },
                        new Producer()
                        {
                            FullName = "Producer 5",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureUrl = "http://dotnethow.net/images/producers/producer-5.jpeg"
                        }
                    });
                    context.SaveChanges();
                }
				//Movies
				if (!context.Movies.Any())
				{
					context.Movies.AddRange(new List<Movies>()
					{
							new Movies()
							{
								Name="كيرة و الجن",
								Description="This is the description of the Kira and Gin",
								Price=120m,
								ImageUrl="https://th.bing.com/th/id/OIP._EcpwFm0yGKEnrCSjfLxawHaLc?pid=ImgDet&rs=1",
								TimeDate=new TimeDate{StartTime=DateTime.Now.AddDays(-10),
									EndTime=DateTime.Now.AddDays(10)},
								CinemaId = 2,
								ProducerId=1,
								MoviesCategory=MoviesCategory.Action,
							},
							new Movies()
							{
								Name="Openhimer",
								Description="This is the description of the Openhimer",
								Price=170m,
								ImageUrl="https://th.bing.com/th/id/OIP.XLH2nCXGy6ElA-pPSv6g7wAAAA?pid=ImgDet&rs=1",
								TimeDate=new TimeDate{StartTime=DateTime.Now,
									EndTime=DateTime.Now.AddDays(3)},
								CinemaId = 3,
								ProducerId=2,
								MoviesCategory=MoviesCategory.Documentary,
							},
							new Movies()
							{
								Name="تراب الماس",
								Description="This is the description of the Trab Almas",
								Price=120m,
								ImageUrl="https://pbs.twimg.com/media/DpLFlrAWwAQotMq.jpg",
								TimeDate=new TimeDate{StartTime=DateTime.Now,
									EndTime=DateTime.Now.AddDays(12)},
								CinemaId = 4,
								ProducerId=3,
								MoviesCategory=MoviesCategory.Drama,
							},
					});
					 context.SaveChanges();
				}


                //Actor_Movie

                if (!context.Actor_Movies.Any())
                {
                    context.Actor_Movies.AddRange(new List<Actor_Movie>()
                    {
                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 4
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 4
                        },

                         new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 5
                        },
                         new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 5
                        },

                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 6
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 6
                        },
                       

                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
