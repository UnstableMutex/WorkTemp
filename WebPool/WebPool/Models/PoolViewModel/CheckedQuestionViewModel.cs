using WebPool.DB.DBModels;

namespace WebPool.Models
{
    public class CheckedQuestionViewModel : QuestionViewModel, IControlName
    {
        private readonly Question _model;

        public CheckedQuestionViewModel(Question model)
        {
            _model = model;
        }
        public string Index => _model.ID.Surr();
        public string Name { get; }
    }
}