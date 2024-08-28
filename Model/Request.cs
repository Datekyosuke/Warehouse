using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WarehouseAccounting.Model.Enum;

namespace WarehouseAccounting.Model
{
    public class Request
    {
        /// <summary>
        /// ID. Auto increment
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Film material. matte/glossy/satin and other
        /// </summary>
        [Required]
        [JsonPropertyName("material")]
        public string Material { get; set; }

        /// <summary>
        /// Film color. usually 3 digits
        /// </summary>
        [JsonPropertyName("color")]
        public string Color { get; set; }

        /// <summary>
        /// Film size. form 1.5m to 6m. 
        /// </summary>
        [Required]
        [JsonPropertyName("size")]
        public float Size { get; set; }

        /// <summary>
        /// quantity of rollers. Whole number
        /// </summary>
        [Required]
        [JsonPropertyName("count")]
        public int Count { get; set; }

        /// <summary>
        /// Data order
        /// </summary>
        [Required]
        [JsonPropertyName("dateOrder")]
        public DateOnly DateOrder { get; set; }

        /// <summary>
        /// the person who made the order
        /// </summary>
        [Required]
        [JsonPropertyName("managerOrder")]
        public string ManagerOrder { get; set; }

        /// <summary>
        /// order status: ordered, found, purchased, on the way, arrived, archived
        /// </summary>
        [Required]
        [JsonPropertyName("status")]
        public Status Status { get; set; }

        /// <summary>
        /// Data change status
        /// </summary>
        [Required]
        [JsonPropertyName("dateStatus")]
        public DateOnly DateStatus { get; set; }


    }
}
