using System.Text.Json.Serialization;

namespace StarWarsRestApi.Service.Models
{
    /// <summary>
    /// The common properties for all the models.
    /// </summary>
    public abstract class BaseModel
    {
        protected BaseModel(string modelType, int id)
        {
            ModelType = modelType;
            Id = id;
        }

        /// <summary>
        /// The model type.
        /// </summary>
        [JsonIgnore]
        public string ModelType { get; set; }

        /// <summary>
        /// The ID of the model.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// The date/time that this record was created.
        /// </summary>
        [JsonPropertyName("created")]
        public DateTimeOffset Created { get; set; } = DateTimeOffset.UtcNow;

        /// <summary>
        /// The date/time that this record was last edited.
        /// </summary>
        [JsonPropertyName("edited")]
        public DateTimeOffset Edited { get; set; } = DateTimeOffset.UtcNow;
    }
}
