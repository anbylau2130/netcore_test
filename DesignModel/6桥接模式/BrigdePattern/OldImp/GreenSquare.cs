
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrigdePattern.OldImp{
    public class GreenSquare : Square {

        public GreenSquare() {
        }
        public override void Draw()
        {
            Console.WriteLine("绿色正方形");
        }
    }
}