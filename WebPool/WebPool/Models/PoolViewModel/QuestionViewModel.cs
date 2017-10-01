using WebPool.DB.DBModels;

namespace WebPool.Models
{
    public class QuestionViewModel: IControlName
    {
        private readonly Question _model;

        public QuestionViewModel(Question model)
        {
            _model = model;
        }

        public string Index => _model.ID.Surr();
        public string Name => "Question";
    }
}