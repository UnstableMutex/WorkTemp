using WebPool.DB.DBModels;

namespace WebPool.Models
{
    public class QuestionViewModel<T> : IControlName where T : QuestionBase
    {
        private readonly T _model;

        public QuestionViewModel(T model)
        {
            _model = model;
        }

        public string Index => _model.ID.Surr();
        public string Name => "Question";
    }
}