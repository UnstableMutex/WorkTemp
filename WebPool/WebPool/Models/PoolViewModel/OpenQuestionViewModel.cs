namespace WebPool.Models
{
    public class OpenQuestionViewModel : QuestionViewModel, IControlName
    {
        public string Index { get; }
        public string Name { get; }
    }
}