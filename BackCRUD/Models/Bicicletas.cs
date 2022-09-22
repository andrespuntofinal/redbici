﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackCRUD.Models
{
    public class Bicicletas
    {

        [BsonId]
        public ObjectId  Id { get; set; }
        public int IdBicicleta { get; set; }

        public string Color { get; set; }

        public string Modelo { get; set; }

        public decimal Latitud { get; set; }

        public decimal Longitud { get; set; }

        public string UserPropietario { get; set; }
        

    }
}
