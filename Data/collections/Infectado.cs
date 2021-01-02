
using System;
using MongoDB.Driver.GeoJsonObjectModel;

namespace Api.Data.collections
{
    public class Infectado
    {
        public DateTime dataNascimento { get; set; }

        public string sexo { get; set; }

        public GeoJson2DGeographicCoordinates localizacao { get; set; }

        public Infectado(DateTime dataNascimento, string sexo, double latitude, double longitude)
        {
            this.dataNascimento = dataNascimento;
            this.sexo = sexo;
            this.localizacao = new GeoJson2DGeographicCoordinates(longitude, latitude);
        }
    }
}