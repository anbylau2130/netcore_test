
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrigdePattern.OldImp{
    public class GreenRectangle : Rectangle {

        public GreenRectangle() {
        }
        public override void Draw()
        {
            Console.WriteLine("绿色长方形");
        }
    }
}