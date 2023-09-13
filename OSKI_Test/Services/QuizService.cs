using OSKI_Test.Data;
using OSKI_Test.Models;

namespace OSKI_Test.Services
{
    public class QuizService : IService<Quiz>
    {
        private IRepository<Quiz> _quizRepository;
        private IQuiz _quiz;
        public QuizService(IRepository<Quiz> quizRepository,IQuiz quiz)
        {
            _quizRepository = quizRepository;
            _quiz = quiz;
        }

        public void Create(Quiz entity)
        {
            _quizRepository.Create(entity);
        }

        public void Delete(int id)
        {
            _quizRepository.Delete(id);
        }
        public Quiz Update(Quiz entity)
        {
            return _quizRepository.Update(entity);
        }
        public List<Quiz> GetAll()
        {
            return _quizRepository.ReadAll().CloneJson();//to not give reference value for user to change
        }

        public Quiz GetById(int id)
        {
            return _quizRepository.ReadById(id).CloneJson();
        }

        public void AssignQuiz(Quiz quiz, ApplicationUser user)
        {
            _quiz.AssignQuiz(quiz, user);
        }
        public AssignedQuiz Submit(int quizId, string userId, List<Question> correctQ, int score)
        {
            return _quiz.Submit(quizId, userId, correctQ, score).CloneJson();
        }
    }
}
