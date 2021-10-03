using System;

namespace AdapterDesign
{
    // Đầu tiên, bạn có một interface bear như thế này 
    public interface IBear
    {
        void Skin();
        void Roar();
    }

   
    // Tạo một lớp gấu trúc implement interface IBear ở trên
    public class Panda : IBear
    {
        public void Skin()
        {
            Console.WriteLine("Skin: My skin color is black and white");
        }

        public void Roar()
        {
            Console.WriteLine("Roar: I'm kung fu pandaaaaa...");
        }
    }

    // Và bạn cũng có một interface chó như sau
    // Không giống như những chú gấu, những chú chó sẽ sủa chứ không gầm (Bark() thay vì Roar())
    public interface IDog
    {
        void Skin();
        void Bark();
    }

    // Một lớp chó shiba implement interface IDog
    public class Shiba : IDog
    {
        public void Skin()
        {
            Console.Write("Skin: My skin color can be a lot of colors. ");
        }

        public void Bark()
        {
            Console.WriteLine("Bark: Go go go go go...");
        }
    }

    // Và dây là khúc gay cấn nhất. biến một chú chó thành một chú gấu trúc nào
    public class ShibaAdapter : IBear
    {
        Shiba shiba;
        public ShibaAdapter(Shiba s)
        {
            shiba = s;
        }

        //Để cho giống một chú gấu trúc thì dễ nhìn ra nhất có lẻ là thay đổi màu lông của chúng
        public void Skin()
        {
            shiba.Skin();
            Console.WriteLine("But my owner make my skin color become black and white");
        }

        // Sẽ ra sao khi bạn bảo chú chó của bạn gầm lên ???
        // Vâng. chúng không thể gầm, nhưng chúng có thể sủa
        // Vì vậy, ở đây ta cho chú chó shiba của mình thực hiện phương thức Bark()
        public void Roar()
        {
            Console.Write("I'm roaring: ");
            shiba.Bark();
        }
    }

    class Program
    {
        // Và ta có một hàm main như sau
        static void Main(string[] args)
        {
           
            // Và dây là những gì mà khách hàng của bạn muốn thấy
            Panda realPanda = new Panda();
            Console.WriteLine(">>           This is a real panda             <<");
            realPanda.Skin();
            realPanda.Roar();
            Console.WriteLine("---------------------------\n");

            // Nhưng bạn chỉ có một chú chó shiba
            // Và thông qua adapter, bạn đã biến chú shiba của mình thành một chú gấu trúc

            Shiba shiba = new Shiba();
            ShibaAdapter shibaFakePanda = new ShibaAdapter(shiba);
            Console.WriteLine(">>           This is a fake panda             <<");
            shibaFakePanda.Skin();
            shibaFakePanda.Roar();
            Console.WriteLine("---------------------------");
        }
    }
}
