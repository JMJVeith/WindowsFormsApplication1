namespace View
{
    public class ConsoleEntity
    {
        private static ConsoleEntity display;
        private static IConsole console;

        private ConsoleEntity(){}

        public static ConsoleEntity initialize(IConsole new_console)
        {
            if(display == null)
            {
                console = new_console;
                display = new ConsoleEntity();
            }
            return display;
        }

        public static void print(string msg)
        {
            if (console == null) return;
            console.print(msg);
        }

        public static void clear()
        {
            console.clear();
        }
    }
}
