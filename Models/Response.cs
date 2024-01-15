using System.Text.Json.Serialization;

namespace Test.Models
{
    public class Response<T>
    {
        [JsonIgnore]
        public int Status {  get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull) ,JsonPropertyName("Response")]

        public T? Body {  get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Message { get; set; }


    }
}
