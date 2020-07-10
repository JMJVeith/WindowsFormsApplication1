namespace MVC
{
    public interface View<T>
    {
        void subscribe(Controller<T> controller);
    }
}
