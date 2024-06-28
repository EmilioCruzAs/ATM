using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Firstapp
{
    internal class Window
    {

        private int width {  get; set; }
        private int height {  get; set; }

      public Window(int Width, int Height)
        {
             width= Width;
            height = Height;
            init();
        }
        
      public void init()
        {
            Console.SetWindowSize(width, height);
        }

        
    }
}
