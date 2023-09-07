using System.IO.Ports;

namespace ImageCollector;

internal static class RotatingBoard
{
    private static readonly SerialPort? _serialPort;

    static RotatingBoard()
    {
        string[] ports = SerialPort.GetPortNames();

        if (ports.Length == 0)
        {
            throw new Exception("No COM ports found");
        }

        foreach (string port in ports)
        {
            try
            {
                _serialPort = new SerialPort(port, 115200);
                _serialPort.Open();
                _serialPort.Close();
            }
            catch (Exception e)
            {
                _serialPort = null;
                continue;
            }
        }

        if (_serialPort == null)
        {
            throw new Exception("No valid serial ports found");
        }
    }

    public static void Rotate(float degrees)
    {
        if (_serialPort == null)
        {
            throw new Exception("Serial port is null");
        }

        _serialPort.Open();

        _serialPort.WriteLine(degrees.ToString("F2"));

        Console.WriteLine($"Serial: {_serialPort.ReadLine()}");
        Console.WriteLine($"Serial: {_serialPort.ReadLine()}");

        _serialPort.Close();
    }
}
