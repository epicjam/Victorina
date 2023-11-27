﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Victorina.DAL.Contracts;
using Victorina.Core.Models;

namespace Victorina.DAL
{
    public class VictorinaDao : IVictorinaDao
    {
        private const string PATH = "C:\\Users\\Михаил\\Documents\\!УЧЕБА_ТОП АКАДЕМИЯ\\2_Домашние задания\\45_Сорок пятая неделя_(С#)_03.11.23\\Victorina.json";
        public void Create(Quiz quiz)
        {
            var quizzes = new List<Quiz>();

            if (File.Exists(PATH))
            {
                using (FileStream fs = new FileStream(PATH, FileMode.OpenOrCreate))
                {
                    quizzes = JsonSerializer.Deserialize<List<Quiz>>(fs);
                }
            }

            quizzes.Add(quiz);
            Write(quizzes);
        }

        public List<Quiz> GetQuiz()
        {
            var quizzes = new List<Quiz>();

             if (File.Exists(PATH))
            {
                using (FileStream fs = new FileStream(PATH, FileMode.OpenOrCreate))
                {
                    quizzes = JsonSerializer.Deserialize<List<Quiz>>(fs);
                }
            }

            return quizzes;
        }

        public void WriteAnswer(Quiz quize, Index index)
        {
            var quizzes = new List<Quiz>();

            using (FileStream fs = new FileStream(PATH, FileMode.OpenOrCreate))
            {
                quizzes = JsonSerializer.Deserialize<List<Quiz>>(fs);
            }

            quizzes[index] = quize;

            Write(quizzes);
        }

        private void Write(List<Quiz> quizzes)
        {
            using (FileStream fs = new FileStream(PATH, FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize<List<Quiz>>(fs, quizzes);
            }
        }
    }
}
