using CinemaTickets.Data.BaseRepository;
using CinemaTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CinemaTickets.Data.Services
{
	public class ActorService : EntityBaseRepository<Actor>,IActorService
	{
        public ActorService(AppDbContext context):base(context)
        {
            
        }
    }
}
