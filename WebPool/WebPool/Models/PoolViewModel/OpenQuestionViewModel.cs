using WebPool.DB.DBModels;

namespace WebPool.Models
{
    public class OpenQuestionViewModel : QuestionViewModel<OpenQuestion>
    {
        public OpenQuestionViewModel(OpenQuestion model) : base(model)
        {
        }

        public string Index { get; }
        public string Name { get; }
    }
}