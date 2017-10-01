using WebPool.DB.DBModels;

namespace WebPool.Models
{
    public class CheckedAnswerViewModel : IControlName
    {
        private readonly CheckAnswer _model;
        private readonly IControlName _parent;

        public CheckedAnswerViewModel(CheckAnswer model, IControlName parent)
        {
            _model = model;
            _parent = parent;
        }

        public string Answer => _model.Answer;
        public string Index => _parent.Index + _model.ID.Surr();
        public string Name => "CheckedAnswer";
    }
}