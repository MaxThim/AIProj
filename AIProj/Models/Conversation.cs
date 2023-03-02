namespace AIProj.Models
{
    public class Conversation
    {
        public List<QuestionAndAnswer> QuestionAndAnswers { get; } = new List<QuestionAndAnswer>();
        private int _count = 0;

        public Guid Id { get; }

        public Conversation()
        {
            Id = Guid.NewGuid();
        }

        public void AddQuestion(string question)
        {
            QuestionAndAnswers.Add(new(question));

            _count++;
        }

        public void AddAnswer(string answer)
        {
            QuestionAndAnswers[_count].Answer = answer;
        }

        public void AddQuestionAndAnswer(string question, string answer)
        {
            QuestionAndAnswers.Add(new(question, answer));

            _count++;
        }
    }
}
