using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OSKI_Test.Data;
using OSKI_Test.Models;
using OSKI_Test.Services;

namespace OSKI_Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuizController : ControllerBase
    {
        private readonly QuizService quizService;
        private readonly ApplicationDbContext context;

        public QuizController(QuizService vs, ApplicationDbContext ct)
        {
            quizService = vs;
            context = ct;
        }
        [HttpPost("Create")]
        public IActionResult Create([FromBody] Quiz v)
        {
            quizService.Create(v);
            return Ok();
        }
        [HttpGet("Read")]
        public IActionResult GetById(int id)
        {
            return Ok(quizService.GetById(id));
        }
        [HttpGet("ReadAll")]
        public IEnumerable<Quiz> GetAllQuizzes()
        {
            return quizService.GetAll();
        }
        [HttpPut("Update")]
        public IActionResult Update(Quiz quiz)
        {
            return Ok(quizService.Update(quiz));
        }

        [HttpDelete("Delete")]
        public IActionResult DeleteQuiz(int id)
        {
            quizService.Delete(id);
            return Ok();
        }

        [HttpPost("AssignQuiz")]
        public IActionResult AssignQuiz(int quizId, string userId)
        {
            Quiz quiz = quizService.GetById(quizId);
            ApplicationUser user = context.Users.Where(x => x.Id == userId).FirstOrDefault();
            if (quiz != null && user != null)
            {
                quizService.AssignQuiz(quiz, user);
                return Ok("Assigned");
            }
            else
                return BadRequest("User or Quiz not found");
        }

        [HttpPost("SubmitQuiz")]
        public IActionResult SubmitQuiz(int quizId, string userId)
        {
            Quiz quiz = context.Quizzes.AsNoTracking().Where(x => x.Id == quizId).Include(q => q.Questions).ThenInclude(p => p.Options).FirstOrDefault();
            ApplicationUser user = context.Users.Where(x => x.Id == userId).FirstOrDefault();

            int score = 0;
            List<Question> response = null;
            try
            {
                if (quiz != null && user != null)
                {
                    var ifAllowedQuiz = context.QuizResponses.Where(x => x.QuizId == quiz.Id && x.UserId == user.Id).FirstOrDefault();

                    if (ifAllowedQuiz != null && quiz.Questions.Count > 0)
                    {

                        response = new List<Question>();
                        foreach (var item in quiz.Questions)
                        {
                            var correct = context.AnswerToQuestion.Where(x => x.QuizId == quiz.Id && x.QuestionId == item.Id).FirstOrDefault();

                            if (correct == null)
                            {
                                return NotFound("No answer for this question in db");
                            }
                            else if (correct.OptionId == item.SelectedOptionId)
                            {
                                response.Add(item);
                                score++;
                            }


                        }

                        var result = quizService.Submit(quizId, userId, response, score);
                        return Ok(result);
                    }
                    else
                    {
                        return Unauthorized("Assign user and questions");
                    }
                }
                else
                {
                    return BadRequest("User or Quiz not found");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

        }


        
    }
}
