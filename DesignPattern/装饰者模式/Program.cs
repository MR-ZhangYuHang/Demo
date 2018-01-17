using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 装饰者模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Phone phone = new ApplePhone();
            Phone sphone = new SamSung();
            Decorator applePhoneWithSticker = new Sticker(sphone);

            applePhoneWithSticker.Print();
            Console.WriteLine("---------------");

            Decorator applePhoneWithAccessories = new Accessories(sphone);

            applePhoneWithAccessories.Print();
            Console.WriteLine("--------------");

            Sticker sticker = new Sticker(phone);
            Accessories applePhoneWithAccessoriesAndSticker = new Accessories(sticker);
            applePhoneWithAccessoriesAndSticker.Print();

            phone = new Sticker(phone);
            phone.Print();
            Console.ReadKey();

        }
    }
}
