using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdoNet_Uygulama.DataAccses.Abstract;

namespace AdoNet_Uygulama.DataAccses.Concreate.AdoNet
{
    internal class AnIEntityRepositoryBase<TEntity>:IEntityRepository<TEntity> where TEntity:class,IEntity,new()
    {
        private SqlConnection _connection =
            new SqlConnection(@"Server=DESKTOP-HNE43R2;Initial Catalog=Northwind;Integrated Security=true");
        public SqlConnection  ConnectionOpen()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
            return _connection;
        }
        public void ConnectionClose()
        {
            _connection.Close();
        }

        public List<TEntity> GetAll(string komut, int adet)
        {
            Dictionary<string,string> list = new Dictionary<string, string>();
            SqlCommand command = new SqlCommand(komut, ConnectionOpen());
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.HasRows)
            {
                for (int i = 0; i < 10; i++)
                {
                    list.Add(dataReader.GetName(i),dataReader.GetString(i));
                    Console.WriteLine($" {i + 1}. {dataReader.GetName(i)}");
                }

                dataReader.NextResult();
            }
            return new List<TEntity>();
        }

        public void Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
