using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Formatting = Newtonsoft.Json.Formatting;

namespace Comp123_S1_Group1_L6
{
    public abstract class RepositoryBase
    {
        public abstract List<Customer> Customers { get; set; }

        public void Load(string filename)
        {
            using (FileStream file = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader reader = new StreamReader(file))
                {
                    JsonSerializer serializer = JsonSerializer.Create(new JsonSerializerSettings
                    {
                        Formatting = Formatting.Indented,
                        TypeNameHandling = TypeNameHandling.Auto
                    });

                    //add code here
                    Customers = serializer.Deserialize(reader, typeof(List<Customer>)) as List<Customer>;
                    
                    reader.Close();
                }
                file.Close();
            }
            //resolving circular reference
            foreach (Customer customer in Customers)
            {
                if (customer != null)
                {
                    foreach (Order order in customer.Orders)
                    {
                        order.Customer = customer;
                    }
                }
            }
        }

        public void Save(string filename)
        {
            using (FileStream file = new FileStream(filename, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter writer = new StreamWriter(file))
                {
                    JsonSerializer serializer = JsonSerializer.Create(new JsonSerializerSettings
                    {
                        Formatting = Formatting.Indented,
                        TypeNameHandling = TypeNameHandling.All
                    });

                    //add code here
                    serializer.Serialize(writer, Customers);
                    writer.Flush();

                    writer.Close();
                }
                file.Close();
            }
        }
    }
}
