using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceApi.Services.Interfaces
{
    public interface IClientCarsService
    {
        public Task<string> Create(ClientCar clientCar);
        public List<ClientCar> ReadAll();
        public Task<string> Update(ClientCar clientCar);
        public Task<string> Delete(int id);
    }
}
