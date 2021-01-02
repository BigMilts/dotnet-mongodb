using System;
using Api.Data.collections;
using MongoDB.Driver;

namespace Api.Services
{
    public class InfectadoService
    {
        Data.MongoDB _mongoDB;
        IMongoCollection<Infectado> _infectadosCollection;

        public InfectadoService (Data.MongoDB mongoDB) 
        {
            _mongoDB = mongoDB;
            _infectadosCollection = _mongoDB.DB.GetCollection<Infectado>(typeof(Infectado).Name.ToLower());
        }
    }
}