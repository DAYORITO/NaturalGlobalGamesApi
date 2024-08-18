using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace GamepageAPI.Models
{
    public class Games
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdGame { get; set; }
        [Required(ErrorMessage = "El nombre no debería estar vacío!")]
        public string GameName { get; set; }
        public string Genre { get; set; }
        public string AnnouncementYear { get; set; }
        public string GameImage { get; set; }
        public string Developer { get; set; }
        public string Distributor { get; set; }
        public string Summary { get; set; }
    }
}
