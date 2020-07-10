namespace MVC
{
    public abstract class Controller<T>
    {
        public T model { get; set; }

        public Controller(View<T> view, T model)
        {
            view.subscribe(this);
            this.model = model;
        }
    }
}
