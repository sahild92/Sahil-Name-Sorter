using System.IO;
using System.Linq;
using System.Text;

namespace SahilNameSorterCore.Services
{
    public interface IGreeter
    {
        string ReadFile();
    }
    public class Greeter : IGreeter
    {
        public string ReadFile()
        {
            return "Press a key to sort a number";
        }
    }
}