using System;

namespace AdapterDesign
{
    public class ProjectorImageResizer { }

    public interface IProjector
    {
        public void connectHDMIPort();
        public ProjectorImageResizer resizeImage();
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

        public ProjectorImageResizer resizeImage()
        {
            return new TVScreenImageResizer();
        }
    }

    public class TVScreenImageResizer : ProjectorImageResizer { }


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
           
        }
    }
}
