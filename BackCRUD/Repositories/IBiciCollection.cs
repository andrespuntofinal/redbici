using BackCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackCRUD.Repositories
{
    public interface IBiciCollection
    {

        Task InsertBici(Bicicletas bicicleta);

        Task UpdateBici(Bicicletas bicicleta);

        Task DeleteBici(string id);

        Task<List<Bicicletas>> GetAllBicicletas();

        Task<Bicicletas> GetBicicletasById(string id);

    }
}
