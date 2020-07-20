using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using GameAssignment.Models;

namespace GameAssignment.Context
{
    //  public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
   public class DatabaseInitializer : DropCreateDatabaseAlways<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            base.Seed(context);
            
            var games = new List<Game>
            {
                new Game {
                GameId = 1,
                Name = "Mario",
                year = 1993

            },

           new Game {
                GameId = 2,
                Name = "Contra",
                year = 1990

            }};

            
            context.Games.AddRange(games);

            context.SaveChanges();
        }

        public override void InitializeDatabase(DatabaseContext context)
        {
            context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction
                , string.Format("ALTER DATABASE [{0}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE", context.Database.Connection.Database));

            base.InitializeDatabase(context);
        }

    }
}