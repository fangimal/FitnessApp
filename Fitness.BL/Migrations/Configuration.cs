using System.Data.Entity.Migrations;

namespace Fitness.BL.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Fitness.BL.Controller.FitnessContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "CodeBlogFitness.BL.Controller.FitnessContext";
        }

        protected override void Seed(Fitness.BL.Controller.FitnessContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
