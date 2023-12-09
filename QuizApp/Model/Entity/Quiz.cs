using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QuizApp.Model.Entity
{
    public class Quiz: ICloneable
    {
        public Guid Guid { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public List<Question> Questions { get; set; }
        public Quiz()
        {
            Guid = Guid.NewGuid();
            Questions = new List<Question>();
        }

        public object Clone()
        {
            return new Quiz()
            {
                Guid = Guid,
                Title = Title,
                Description = Description,
                Author = Author,
            };

        }
        public int ValidateQuestions()
        {
            if (Questions == null) return 0;

            if (!string.IsNullOrEmpty(Title))
            {
                int countQuestionValid = 0;
                for (int i = 0; i < Questions.Count; i++)
                {
                    if (Questions[i].IsValidated())
                    {
                        countQuestionValid++;
                    }
                    else
                    {
                        Questions.RemoveAt(i);
                    }
                }
                return countQuestionValid;
            };
            return 0;
        }

        public static List<Question> ScatterQuestions(List<Question> questions, int count = 0)
        {
            List<Question> result = new List<Question>();
            if (questions != null)
            {

                if (questions.Count > 0)
                {
                    int maxCount = questions.Count;

                    if (count <= 0 || count > maxCount) count = maxCount;

                    int[] busyIds = new int[count];

                    Random random = new Random();
                    //Раскидываем идентификаторы тестов
                    for (int i = 0; i < count; i++)
                    {
                        int id = random.Next(0, maxCount - 1);
                        if (!busyIds.Contains(id))
                        {
                            busyIds[i] = id;
                        }
                    }

                    // Выкидываем лишнее
                    for (int i = 0; i < maxCount; ++i)
                    {
                        result.Add(questions[i]); 
                    }
                }
            }

            return result;
        }
    }
}
