using StarWarsRestApi.Service.Serialization;
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
        /// The URI for this model.
        /// </summary>
        [JsonPropertyName("uri")]
        public string Uri { get => GetUri(); set => throw new NotImplementedException(); }

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

        /// <summary>
        /// Gets the Uri for this object.
        /// </summary>
        /// <returns>The Uri for this object as a string.</returns>
        public string GetUri()
            => new Uri(AppUriHelper.AppUri, $"/{ModelType}/{Id}").ToString();
    }
}
