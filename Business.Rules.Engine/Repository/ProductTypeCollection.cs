using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.Engine.Repository
{
    public class ProductTypeCollection
    {
        Dictionary<int, string> productType = new Dictionary<int, string>
        {
            {1, "PhysicalProduct"},
            {2, "PhysicalProduct"},
            {3, "Book"},
            {4, "Book"},
            {5, "ActivateMembership"},
            {6, "UpgradeMembership"},
            {7, "Video"},
            {8, "Video"}
        };

        public string GetProductType(int productId)
        {
            return productType[productId];
        }        
    }
}
