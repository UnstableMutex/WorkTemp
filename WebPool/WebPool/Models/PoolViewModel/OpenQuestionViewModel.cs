using WebPool.DB.DBModels;

namespace WebPool.Models
{
    public class OpenQuestionViewModel : QuestionViewModel<QuestionBase>
    {
        public OpenQuestionViewModel(OpenQuestion model) : base(model)
        {
        }

        protected new OpenQuestion Model { get { return base.Model as OpenQuestion; } }

        public string Index { get; }
        public string Name { get; }
    }
}