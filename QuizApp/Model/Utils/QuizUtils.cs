using QuizApp.Model.Data.Entity;
using QuizApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Model.Utils
{
    public static class QuizUtils
    {
        public static Question[] ShuffleAndCutQuestions(Question[] questions, int limit_count = 0)
        {
            int all_count = questions.Length;
            int[] busyIds = new int[all_count];
            for (int id = 0; id < busyIds.Length; ++id)
                busyIds[id] = id;

            Shuffler.Shuffle(busyIds);

            if (limit_count <= 0 || limit_count > all_count) 
                limit_count = all_count;

            Question[] result = new Question[limit_count];
            for (int id = 0; id < limit_count; ++id)
                result[id] = (Question)questions[busyIds[id]].Clone();
            return result;
        }
        public static Answer[] ShuffleAnswers(Answer[] answers)
        {
            int all_count = answers.Length;
            int[] busyIds = new int[all_count];
            for (int id = 0; id < busyIds.Length; ++id)
                busyIds[id] = id;

            Shuffler.Shuffle(busyIds);

            Answer[] result = new Answer[all_count];
            for (int id = 0; id < busyIds.Length; ++id)
                result[id] = (Answer)answers[busyIds[id]].Clone();
            return result;
        }
    }
}
