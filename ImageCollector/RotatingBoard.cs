using System.IO.Ports;

namespace ImageCollector;

internal static class RotatingBoard
{
    private static SerialPort? _serialPort = null;

    public static readonly string[] AVAILABLE_PORTS = SerialPort.GetPortNames();

    public static void SetPort(int index) => _serialPort = new SerialPort(AVAILABLE_PORTS[index], 115200);

    public static void Rotate(float degrees)
    {
        if (_serialPort == null)
        {
            throw new Exception("Serial port is null");
        }

        _serialPort.ReadTimeout = 5000;
        _serialPort.Open();

        _serialPort.WriteLine(degrees.ToString("F2"));

        Console.WriteLine($"Serial: {_serialPort.ReadLine()}");
        Thread.Sleep(3000);
        Console.WriteLine($"Serial: {_serialPort.ReadLine()}");

        _serialPort.Close();
    }
}
