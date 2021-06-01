using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
//using Crismeyri_P1_AP2.Models;

namespace Crismeyri_P1_AP2.DAL
{
    public class Contexto : DbContext
    {
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }
    }

}