using System.Device.Gpio;
using System.Threading;

namespace Led
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            const int red = 13;
            const int blue = 26;
            const int green = 19;

            var gpio = new GpioController(PinNumberingScheme.Board);
            gpio.OpenPin(red, PinMode.Output);
            gpio.OpenPin(blue, PinMode.Output);
            gpio.OpenPin(green, PinMode.Output);

            try
            {
                while (true)
                {
                    gpio.Write(red, PinValue.High);
                    Thread.Sleep(100);
                    gpio.Write(red, PinValue.Low);
                    Thread.Sleep(100);
                    gpio.Write(blue, PinValue.High);
                    Thread.Sleep(100);
                    gpio.Write(blue, PinValue.Low);
                    Thread.Sleep(100);
                    gpio.Write(green, PinValue.High);
                    Thread.Sleep(100);
                    gpio.Write(green, PinValue.Low);
                    Thread.Sleep(100);
                }
            }
            finally
            {
                gpio.ClosePin(red);
                gpio.ClosePin(green);
                gpio.ClosePin(blue);
            }
        }
    }
}