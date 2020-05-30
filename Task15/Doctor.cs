using System;
using System.Threading;
using System.Threading.Tasks;

namespace Task15
{
    class Doctor 
    {
        private readonly Hospital _hospital;
        // идентификатор врача
        private readonly int _number;
        // класс для псевдовероятного рандома
        private readonly Random rnd;
        public bool IsWork { get; set; }

        public Doctor(Hospital hospital, int number)
        {
            _hospital = hospital;
            _number = number;
            rnd = new Random(_number);
        }

        public async void WorkAsync()
        {
            await Task.Run(Work);
        }

        private void Work()
        {
            while (!_hospital.IsDayOver)
            {
                if (!_hospital.IsHasNewPatient || IsWork)
                {
                    Thread.Sleep(10);
                    continue;
                }

                IsWork = true;
                var patient = _hospital.BeginInspection();
                var t = DateTime.Now;
                Inspection();
                Consulting();
                var time = DateTime.Now - t;
                IsWork = false;
                _hospital.EndInspection($"Doctor {_number} has ended inspection. Common time {time.TotalMilliseconds}ms\n");
            }
        }

        private void Inspection()
        {
            Thread.Sleep(rnd.Next(1, _hospital.Timing + 1) * Hospital.MagicTiming);
        }

        private void Consulting()
        {
            if (rnd.Next(10) >= 7) return; // с вероятностью 80 процентов доктор не будет консультировать
            var docNum = _hospital.GetDoctorForConsulting();
            _hospital.StandardLogger($"Doctor {_number} is consulting with doctor {docNum}\n");
            Thread.Sleep(rnd.Next(1, _hospital.Timing + 1) * Hospital.MagicTiming);
            _hospital.FreeDoctor(docNum);
        }

    }
}
