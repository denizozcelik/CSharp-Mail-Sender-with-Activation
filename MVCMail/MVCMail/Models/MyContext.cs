using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCMail.Models
{
    public class MyContext:DbContext
    {
        public MyContext()
        {
            Database.Connection.ConnectionString = "server=.;database=ActivationDB;uid=********;pwd==********;";
            // uid=********;pwd==********  You have to write your own Servers uid and password

        }

        public DbSet<Sample> Samples { get; set; }


    }
}