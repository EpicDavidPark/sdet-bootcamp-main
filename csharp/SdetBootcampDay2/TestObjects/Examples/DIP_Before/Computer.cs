namespace SdetBootcampDay2.TestObjects.Examples.DIP_Before
{
    public class Computer
    {
        private readonly Keyboard keyboard;
        private readonly HDMonitor monitor;

        public Computer()
        {
            this.keyboard = new Keyboard();
            this.monitor = new HDMonitor();
        }
    }

    public class Keyboard
    {
    }

    public class HDMonitor
    {
    }
}
