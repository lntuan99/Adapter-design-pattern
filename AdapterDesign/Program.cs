using System;

namespace AdapterDesign
{
    // Đầu tiên, bạn có một interface IMonitor như sau
    public interface IMonitor
    {
        public void MonitorConnector();
    }

    // Tạo một lớp SamSungMonitor implement interface IMonitor ở trên với cách kết nối thông qua cổng HDMI
    public class SamSungMonitor : IMonitor
    {
        public void HDMI()
        {
            Console.WriteLine("[Monitor]: HDMI cable connecting...");
        }

        public void MonitorConnector()
        {
            HDMI();
        }
    }

    // Và bạn cũng có một interface IVideoGraphicsArray như sau
    public interface IVideoGraphicsArray
    {
        public void VideoGraphicsArrayConnector();
    }

    // Một lớp RTX3060 implement interface IVideoGraphicsArray với cách kết nối thông qua cổng VGA
    public class RTX3060 : IVideoGraphicsArray
    {
        public void VGA()
        {
            Console.WriteLine("[Card]: VGA cable connecting...");
        }

        public void VideoGraphicsArrayConnector()
        {
            VGA();
        }
    }

    // Vấn đề đặt ra ở đây
    // Người dùng muốn kết nối màn hình với card mà họ có
    // Nhưng cổng kết nối của màn hình và card sử dụng là 2 cổng không giống nhau
    // Và để kết nối 2 thiết bị thì người dùng phải tìm cách để biến cả 2 cổng kết nối của 2 thiết bị là giống nhau

    // Ta cài đặt MonitorAdapter để chuyển cổng kết nối trên màn hìn thành cùng cổng kết nối như trên card mà ta sử dụng
    public class MonitorAdapter : IVideoGraphicsArray
    {
        IMonitor monitor;
        public MonitorAdapter(IMonitor m)
        {
            monitor = m;
        }

        public void VideoGraphicsArrayConnector()
        {
            Console.WriteLine("Monitor connector ====> Video Graphics Array connector");
            monitor.MonitorConnector();
        }
    }

    class Program
    {
        // Ví dụ: Người dùng có một màn hình samsung với cổng kết nối là HDMI, 1 card RTX 3060 với cổng kết nối là VGA
        // Nhung họ KHÔNG có 1 cable với 1 cổng HDMI, 1 cổng VGA
        // Mà họ chỉ có 1 cable với cả 2 cổng là đều VGA
        // Vì thế, họ đã sử dụng một đầu chuyển để chuyển đổi cổng HDMI trên màn hình thành cổng VGA 
        // Và người dùng đã có thể kết nối 2 thiết bị với nhau bằng sợi cable có 2 cổng đều là VGA
        static void Main(string[] args)
        {
            SamSungMonitor monitor = new SamSungMonitor();
            RTX3060 card = new RTX3060();

            // Gắn adapter, chuyển đổi cổng HDMI trên màn hình thành cổng VGA
            MonitorAdapter adapter = new MonitorAdapter(monitor);

            // Sau khi đã chuyển đổi cổng trên màn hình thành cổng cùng một loại cổng với card thì ta đã có thể kết nổi thành công
            card.VideoGraphicsArrayConnector();
            adapter.VideoGraphicsArrayConnector();
        }
    }
}
