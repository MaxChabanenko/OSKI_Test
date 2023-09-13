using OSKI_Test.Models;

namespace OSKI_Test.Data
{
    public interface IQuiz
    {
        void AssignQuiz(Quiz quiz, ApplicationUser user);

        AssignedQuiz Submit(int quizId, string userId, List<Question> correctQ, int score);
    }
}