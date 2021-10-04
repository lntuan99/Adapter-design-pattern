using System;

namespace AdapterDesign
{
    public interface IProjector
    {
        public void connectHDMIPort();
        public IProjector resizeImage();
    }

    public class LCDProjector : IProjector
    {
        public void connectHDMIPort()
        {
            Console.WriteLine("connect LCD");
            Console.WriteLine("[LCD] HDMI connecting...\n");
        }

        public IProjector resizeImage()
        {
            Console.WriteLine("[LCD] resize image...\n");
            return this;
        }
    }

    public class LEDProjector : IProjector
    {
        public void connectHDMIPort()
        {
            Console.WriteLine("connect LED");
            Console.WriteLine("[LED] HDMI connecting...\n");
        }

        public IProjector resizeImage()
        {
            Console.WriteLine("[LED] resize image...\n");

            return this;
        }
    }

    public class ScreenProjector : IProjector
    {
        TVScreen tvScreen;
        public ScreenProjector(TVScreen tv)
        {
            tvScreen = tv;
        }

        public void connectHDMIPort()
        {
            tvScreen.connectVGAPort();
        }

        public IProjector resizeImage()
        {
            Console.WriteLine("[TV] resize image...\n");

            return new ScreenProjector(tvScreen);
        }
    }


    public class TVScreen 
    {
        public void connectVGAPort()
        {
            Console.WriteLine("connect TVScreen");
            Console.WriteLine("[TV] VGA connecting...\n");
        }
    }


    class Program
    {

        static void Main(string[] args)
        {
            TVScreen tv = new TVScreen();
            LEDProjector led = new LEDProjector();
            LCDProjector lcd = new LCDProjector();

            ScreenProjector screenProjector = new ScreenProjector(tv);

            Console.WriteLine(">>-----------CONNECT-----------<<");
            led.connectHDMIPort();
            lcd.connectHDMIPort();
            screenProjector.connectHDMIPort();
            Console.WriteLine(">>-----------------------------<<\n");

            Console.WriteLine(">>---------RESIZE IMAGE---------<<");
            led.connectHDMIPort();
            lcd.connectHDMIPort();
            screenProjector.connectHDMIPort();
            Console.WriteLine(">>------------------------------<<");
        }
    }
}
