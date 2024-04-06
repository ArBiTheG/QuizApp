using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Model.Data.Entity
{
    [JsonObject(MemberSerialization.OptIn)]
    public class QuestionText : IQuestionText
    {
        [JsonRequired]
        [JsonProperty("guid")]
        public Guid Guid { get; set; }

        [JsonRequired]
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonRequired]
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("multiplier")]
        public double Multiplier { get; set; } = 1.0;

        [JsonIgnore]
        public string SelectText { get; set; }
        [JsonRequired]
        [JsonProperty("correct_text")]
        public string CorrectText { get; set; }
        public object Clone()
        {
#if DEBUG
            Console.WriteLine("Clone: " + ToString() + " / Guid: " + Guid);
#endif
            return new QuestionText
            {
                Guid = Guid,
                Title = Title,
                Description = Description,
                Multiplier = Multiplier,
                CorrectText = CorrectText,
            };
        }
        public QuestionText()
        {
            Guid = Guid.NewGuid();
        }

        public bool IsValidated()
        {
            if (!string.IsNullOrEmpty(Description))
            {
                if (CorrectText != null)
                {
                    return CorrectText.Length > 0;
                }
            };
            return false;
        }
    }
}
