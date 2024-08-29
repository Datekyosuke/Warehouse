using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Warehouse.Model.Enum;


namespace Warehouse.Model
{
    public class Storage
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
        /// Date of arrival
        /// </summary>
        [Required]
        [JsonPropertyName("date")]
        public DateOnly Date { get; set; }

        /// <summary>
        /// vendor
        /// </summary>
        [Required]
        [JsonPropertyName("vendor")]
        public string Vendor { get; set; }

        /// <summary>
        /// status: on warehouse or not
        /// </summary>
        [Required]
        [JsonPropertyName("status")]
        public StatusWarehouse StatusWarehouse { get; set; }

        /// <summary>
        /// Data change status
        /// </summary>
        [Required]
        [JsonPropertyName("dateStatus")]
        public DateOnly DateStatus { get; set; }
    }
}
