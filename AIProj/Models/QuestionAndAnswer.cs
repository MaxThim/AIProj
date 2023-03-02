namespace AIProj.Models
{
    public class QuestionAndAnswer
    {
        public QuestionAndAnswer(string question, string answer) 
        { 
            Question = question;
            Answer = answer;
        }

        public QuestionAndAnswer(string question) 
        { 
            Question = question;
        }


        private string? _answer;
        public string Question { get; init; }
        public string? Answer
        {
            get { return _answer; }
            set
            {
                if (_answer == null)
                {
                    _answer = value;
                }
            }
        }
    }
}
