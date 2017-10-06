using WebPool.DB.DBModels;

namespace WebPool.Models
{
    public class QuestionViewModel<T> : IViewModel<T>, IControlName where T : QuestionBase
    {
        protected virtual T Model { get; set; }

        public QuestionViewModel(T model)
        {
            Model = model;
        }

        public string Question => Model.Question;
        public string Index => Model.ID.Surr();
        public string Name => "Question";
    }

    interface IViewModel<in T>
    {

    }
}