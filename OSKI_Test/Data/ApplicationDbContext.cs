using Duende.IdentityServer.EntityFramework.Entities;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OSKI_Test.Models;

namespace OSKI_Test.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {

        }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<AssignedQuiz> QuizResponses { get; set; }
        public DbSet<TrueAnswer> AnswerToQuestion { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AssignedQuiz>().HasKey(u => new { u.QuizId, u.UserId });
            modelBuilder.Entity<TrueAnswer>().HasKey(u => new { u.QuizId, u.QuestionId, u.OptionId });

        }

    }
}