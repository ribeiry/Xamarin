using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RestComXamarin.Models
{
    public class Repository
    {
        public async Task<List<Cat>> GetCats()
        {
            var Service = new Services.AzureService<Cat>();
            var Itens = await Service.GetTable();

            return Itens.ToList();

        }
    }
}
