using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignModel
{
    public class SimpleFactory
    {
        public static Product CreateInstance(string productType)
        {
            if (productType == "ProductA")
            {
                return new ProductA("ProductA");
            }
            return new ProductB("ProductA");
        }
    }
}