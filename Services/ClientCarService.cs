using CarServiceApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceApi.Services
{
    public class ClientCarService : IClientCarsService
    {
        private ApplicationContext Context { get; set; }

        public ClientCarService(ApplicationContext db)
        {
            Context = db;
        }

        public async Task<string> Create(ClientCar clientCar)
        {
            bool success = true;
            try
            {
                Context.ClientCars.Add(clientCar);
                await Context.SaveChangesAsync();
            }
            catch (Exception)
            {
                success = false;
            }
            return success ? $"Create successful {clientCar.Id}" : "Create was not successful";
        }

        public async Task<string> Delete(int id)
        {
            bool success = true;
            var clientCar = Context.ClientCars.FirstOrDefault(p => p.Id == id);
            try
            {
                if (clientCar != null)
                {
                    Context.ClientCars.Remove(clientCar);
                    await Context.SaveChangesAsync();
                }
                else
                {
                    success = false;
                    throw new Exception("NotFoundException");
                }
            }
            catch (Exception)
            {
                success = false;
            }
            return success ? "Delete successful" : "Delete was not successful";
        }

        public List<ClientCar> ReadAll()
        {
            return Context.ClientCars.ToList();
        }

        public async Task<string> Update(ClientCar clientCar)
        {
            bool success = true;
            var car = Context.ClientCars.FirstOrDefault(m => m.Id == clientCar.Id);
            try
            {
                if (car != null)
                {
                    Context.ClientCars.Update(clientCar);
                    await Context.SaveChangesAsync();
                }
                else
                {
                    success = false;
                    throw new Exception("NotFoundException");
                }
            }
            catch (Exception)
            {
                success = false;
            }
            return success ? $"Update successful {car.Id}" : "Update was not successful";
        }
        //public void AddCars()
        //{
        //    var rand = new Random();

        //    CarBrand carBrand = new CarBrand
        //    {
        //        Name = String.Format($"Brand{rand.Next()}"),
        //        Country = String.Format($"Counry{rand.Next()}")
        //    };
        //    db.CarBrands.Add(carBrand);

        //    ClientCar clientCar = new ClientCar
        //    {
        //        CarBrand = carBrand,
        //        Name = String.Format($"Model{rand.Next()}")
        //    };
        //    db.ClientCars.Add(clientCar);

        //    ModelGeneration modelGeneration = new ModelGeneration
        //    {
        //        ClientCar = clientCar,
        //        Name = String.Format($"Generation{rand.Next()}"),
        //        ProductionStart = String.Format($"Start{rand.Next()}"),
        //        ProductinEnd = String.Format($"End{rand.Next()}")
        //    };
        //    db.ModelGenerations.Add(modelGeneration);

        //    Client client = new Client
        //    {
        //        Name = String.Format($"Name{rand.Next()}"),
        //        Surname = String.Format($"Surname{rand.Next()}"),
        //        Patronymic = String.Format($"Patronymic{rand.Next()}"),
        //    };
        //    db.Clients.Add(client);

        //    ClientCar clientCar = new ClientCar
        //    {
        //        Client = client,
        //        ModelGeneration = modelGeneration,
        //        Milage = rand.Next() * 1000,
        //        ProductionYear = rand.Next()
        //    };
        //    db.ClientCars.Add(clientCar);

        //    db.SaveChanges();
        //}
    }
}
