using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceApi.Services
{
    public class ClientCarService : IClientCarService
    {
        ApplicationContext db = new ApplicationContext();
        public void Add()
        {
            var rand = new Random();

            CarBrand carBrand = new CarBrand
            {
                Name = String.Format($"Brand{rand.Next()}"),
                Country = String.Format($"Counry{rand.Next()}")
            };
            db.CarBrands.Add(carBrand);

            CarModel carModel = new CarModel
            {
                CarBrand = carBrand,
                Name = String.Format($"Model{rand.Next()}")
            };
            db.CarModels.Add(carModel);

            ModelGeneration modelGeneration = new ModelGeneration
            {
                CarModel = carModel,
                Name = String.Format($"Generation{rand.Next()}"),
                ProductionStart = String.Format($"Start{rand.Next()}"),
                ProductinEnd = String.Format($"End{rand.Next()}")
            };
            db.ModelGenerations.Add(modelGeneration);

            Client client = new Client
            {
                Name = String.Format($"Name{rand.Next()}"),
                Surname = String.Format($"Surname{rand.Next()}"),
                Patronymic = String.Format($"Patronymic{rand.Next()}"),
            };
            db.Clients.Add(client);

            ClientCar clientCar = new ClientCar
            {
                Client = client,
                ModelGeneration = modelGeneration,
                Milage = rand.Next() * 1000,
                ProductionYear = rand.Next()
            };
            db.ClientCars.Add(clientCar);

            db.SaveChanges();
        }
    }
}
