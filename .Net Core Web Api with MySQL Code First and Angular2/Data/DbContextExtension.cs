using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Linq;

using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using Models;

namespace Data
{
    public static class DbContextExtension
    {
        private const string SeedFolderName = "DatabaseSeed";

        public static bool AllMigrationsApplied(this DbContext context)
        {
            var applied = context.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);

            var total = context.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);

            return !total.Except(applied).Any();
        }

        public static void EnsureSeeded(this ApiTestContext context)
        {
            //if (!context.Users.Any())
            //{
            //    var users = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText("DatabaseSeed" + Path.DirectorySeparatorChar + "users.json"));
            //    context.AddRange(users);
            //    context.SaveChanges();
            //}

            //if (!context.Articles.Any())
            //{
            //    var randomUser = context.Users.FirstOrDefault();

            //    var articles = JsonConvert.DeserializeObject<List<Article>>(File.ReadAllText(@"DatabaseSeed" + Path.DirectorySeparatorChar + "articles.json"));
            //    articles.ForEach(a => a.Author = randomUser);

            //    context.AddRange(articles);
            //    context.SaveChanges();
            //}

            //if (!context.Tags.Any())
            //{
            //    var tags = JsonConvert.DeserializeObject<List<Tag>>(File.ReadAllText(@"DatabaseSeed" + Path.DirectorySeparatorChar + "tags.json"));
            //    context.Tags.AddRange(tags);
            //    context.SaveChanges();
            //}
        }
    }
}
