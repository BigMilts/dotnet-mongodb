using System.Collections.Generic;
using System;
using Api.Data.collections;
using Api.Models;
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

        public bool CreateObject(InfectadoDTO dto) 
        {
            try 
            {
                 var infectado = new Infectado(dto.DataNascimento, dto.Sexo, dto.Latitude, dto.Longitude);
                _infectadosCollection.InsertOne(infectado);
                 return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Falha ao criar Objeto");
                Console.WriteLine("Erro: " + ex.Message);
                return false;
            }
        }
    
        public List<Infectado> GetAll() 
        {
            try 
            {
                List<Infectado> infectados = _infectadosCollection.Find(Builders<Infectado>.Filter.Empty).ToList();
                return infectados;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Falha ao Buscar os objetos");
                Console.WriteLine("Erro: " + ex.Message);
                throw ex;
            }
        }

        public bool Update(InfectadoDTO dto) 
        {
            try 
            {
                var infectado = new Infectado(dto.DataNascimento, dto.Sexo, dto.Latitude, dto.Longitude);
                _infectadosCollection.UpdateOne(Builders<Infectado>.Filter
                .Where(obj=> obj.dataNascimento == dto.DataNascimento), Builders<Infectado>.Update.Set("sexo", dto.Sexo)); 
                return true;
            }
            catch(Exception ex) 
            {
                Console.WriteLine("Falha ao criar Objeto");
                Console.WriteLine("Erro: " + ex.Message);
                return false;
            }
        }

        public bool Delete(DateTime dataNasc)
        {
            try
            {
                _infectadosCollection.DeleteOne(Builders<Infectado>.Filter
                    .Where(obj => obj.dataNascimento == dataNasc));
                    return true;
            }
            catch(Exception ex) 
            {
                Console.WriteLine("Falha ao deletar Objeto");
                Console.WriteLine("Erro: " + ex.Message);
                return false;
            }
        }
    }
}