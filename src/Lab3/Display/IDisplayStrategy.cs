using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Display;

public interface IDisplayStrategy
{
    void Clear();
    void SetColor(Color color);
    void Out(string text);
}