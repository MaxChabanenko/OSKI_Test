using Microsoft.EntityFrameworkCore;
using OSKI_Test.Models;

namespace OSKI_Test.Data
{
    public class QuizRepository : IRepository<Quiz>, IQuiz
    {
        private ApplicationDbContext Context;
        public QuizRepository(ApplicationDbContext context)
        {
            Context = context;
        }
        public void Create(Quiz ent)
        {
            Context.Quizzes.Add(ent);
            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = Context.Quizzes.Where(x => x.Id == id).Include(q => q.Questions).ThenInclude(p => p.Options).FirstOrDefault();
            Context.Quizzes.Remove(item);

            Context.SaveChanges();
        }

        public List<Quiz> ReadAll()
        {
            return Context.Quizzes.Include(q => q.Questions).ThenInclude(p => p.Options).ToList();
        }

        public Quiz ReadById(int id)
        {
            return Context.Quizzes.Where(x => x.Id == id).Include(q => q.Questions).ThenInclude(p => p.Options).FirstOrDefault();
        }

        public Quiz Update(Quiz ent)
        {
            var item = Context.Quizzes.AsNoTracking().Where(x => x.Id == ent.Id).Include(q => q.Questions).ThenInclude(p => p.Options).FirstOrDefault();
            if (item != null)
            {
                item.QuizName = ent.QuizName;
                item.Questions = ent.Questions;
                item.Id = ent.Id;

                Context.Quizzes.Update(item);
                Context.SaveChanges();
            }
            return item;
        }

        public void AssignQuiz(Quiz quiz, ApplicationUser user)
        {
            Context.QuizResponses.Add(new AssignedQuiz() { QuizId = quiz.Id, UserId = user.Id, Score = 0 });
            Context.SaveChanges();
        }

        public AssignedQuiz Submit(int quizId, string userId, List<Question> correctQ, int score)
        {

            var item = Context.QuizResponses.Where(x => x.QuizId == quizId&& x.UserId == userId).FirstOrDefault();

            item.Score = score;
            item.CorrectQuestions = correctQ;

            Context.QuizResponses.Update(item);
            Context.SaveChanges();


            return item;

        }
    }
}
