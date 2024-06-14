
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrigdePattern.OldImp{
    public class RedRectangle : Rectangle {

        public RedRectangle() {
        }

        public override void Draw()
        {
            Console.WriteLine("红色正方形");
        }
    }
}