﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1Store.Catalogo.Data.Providers.MongoDb.Interfaces
{ 
	public interface IDocument
	{
		[BsonId]
		[BsonRepresentation(BsonType.String)]
		ObjectId Id { get; set; }

		DateTime CreatedAt { get; }
	}
}
