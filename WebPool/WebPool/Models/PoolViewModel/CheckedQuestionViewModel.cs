using WebPool.DB.DBModels;

namespace WebPool.Models
{
    public class CheckedQuestionViewModel : QuestionViewModel<CheckedQuestion>, IControlName
    {
        private readonly CheckedQuestion _model;

        public CheckedQuestionViewModel(CheckedQuestion model) : base(model)
        {
            _model = model;
        }
        public string Index => _model.ID.Surr();
        public string Name { get; }
    }
}