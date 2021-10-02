using eTicketApp.Data.Base;
using eTicketApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicketApp.Data.Services
{
    public class ActorsService :EntityBaseRepository<Actor> , IActorsServices
    {
        

        public ActorsService(AppDbContext context):base(context) { }
        

        
    }
}
