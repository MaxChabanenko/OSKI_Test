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
        /// <summary>
        /// Create quiz
        /// </summary>
        /// <remarks>
        /// Example:   
        ///
        ///{
        ///  "id": 0,
        ///  "quizName": "History (Completed)",
        ///  "questions": [
        ///    {
        ///      "id": 0,
        ///      "text": "In which year did World War I begin?",
        ///"options": [
        ///        {
        ///          "id": 0,
        ///          "text": "1923"
        ///        },
        ///        {
        ///          "id": 0,
        ///          "text": "1938"
        ///        },
        ///        {
        ///    "id": 0,
        ///          "text": "1917"
        ///        },
        ///        {
        ///    "id": 0,
        ///          "text": "1914"
        ///        }
        ///      ],
        ///      "selectedOptionId": 4
        ///    },
        ///{
        ///    "id": 0,
        ///      "text": "Where was John F. Kennedy assassinated?",
        ///"options": [
        ///        {
        ///        "id": 0,
        ///          "text": "New York"
        ///        },
        ///        {
        ///        "id": 0,
        ///          "text": "Austin"
        ///        },
        ///        {
        ///        "id": 0,
        ///          "text": "Dallas"
        ///        },
        ///        {
        ///        "id": 0,
        ///          "text": "Miami"
        ///        }
        ///      ],
        ///      "selectedOptionId": 6
        ///    }
        ///  ]
        ///}
        ///
        /// </remarks>
        /// <param name="quiz">Quiz</param>
        /// <returns></returns>
        [HttpPost("Create")]
        public IActionResult Create([FromBody] Quiz quiz)
        {
            quizService.Create(quiz);
            return Ok();
        }
        /// <summary>
        /// Get one quiz by id
        /// </summary>
        /// <param name="id">Quiz Id</param>
        /// <returns>First or Default Quiz found by Id</returns>
        [HttpGet("Read")]
        public IActionResult GetById(int id)
        {
            return Ok(quizService.GetById(id));
        }
        /// <summary>
        /// Get ALL quizes
        /// </summary>
        /// <returns>All quizes in DB</returns>
        [HttpGet("ReadAll")]
        public IEnumerable<Quiz> GetAllQuizzes()
        {
            return quizService.GetAll();
        }
        /// <summary>
        /// Update quiz
        /// </summary>
        /// <remarks>
        /// Finds quiz with the same ID and updates it's values
        /// </remarks>
        /// <param name="quiz">Quiz</param>
        /// <returns>Updated quiz</returns>
        [HttpPut("Update")]
        public IActionResult Update(Quiz quiz)
        {
            return Ok(quizService.Update(quiz));
        }
        /// <summary>
        /// Delete quiz
        /// </summary>
        /// <remarks>
        /// Deletes all related entities
        /// </remarks>
        /// <param name="id">Id</param>
        [HttpDelete("Delete")]
        public IActionResult DeleteQuiz(int id)
        {
            quizService.Delete(id);
            return Ok();
        }
        /// <summary>
        /// Assign quiz for user
        /// </summary>
        /// <param name="quizId">Quiz Id</param>
        /// <param name="userId">User Id (ASP.NET user's GUID)</param>
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
        /// <summary>
        /// Submit quiz
        /// </summary>
        /// <remarks>
        /// User must be assigned with Quiz and correct answer entry for questions must exist in DB
        /// </remarks>
        /// <param name="quizId">Quiz Id</param>
        /// <param name="userId">User Id (ASP.NET user's GUID)</param>
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
