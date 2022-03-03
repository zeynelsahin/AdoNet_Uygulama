using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdoNet_Uygulama.DataAccses.Abstract;

namespace AdoNet_Uygulama.DataAccses.Concreate.AdoNet
{
    internal class AnIProductDal:AnIEntityRepositoryBase<Product>,IProductDal
    {
    }
}
