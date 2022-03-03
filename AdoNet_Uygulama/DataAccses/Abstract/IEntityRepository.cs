using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNet_Uygulama.DataAccses.Abstract
{
    public interface IEntityRepository<T> where  T:class,IEntity,new()
    {
        List<T> GetAll(string komut,int adet);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
