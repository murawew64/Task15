using System;


namespace Task15
{
    class Patient
    {
        public bool IsInfected { get; set; }
        public Patient()
        {
            if (new Random().Next(100) > 30) IsInfected = true; // задаю вероятность чувака быть больным 3 / 10
        }
    }
}
