using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace _16_Hives
{
    abstract internal class Bee
    {
        public string Job { get; private set; }
        public abstract float CostPerShift { get; }

        public Bee(string job) 
        {
            Job = job;
        }

        public void WorkTheNextShift()
        {
            if (HoneyVault.ConsumeHoney(CostPerShift))
            {
                Console.WriteLine("Resta mel na colmeia, portanto chama 'DoJob'");
                DoJob();
            }
        }

        protected abstract void DoJob(); //sobreescrito por subclasse, não pode ter corpo "{}" pois é abstrata
    }

    /// <summary>
    /// Classe da rainha
    /// </summary>
    internal class Queen : Bee
    {
        public const float EGGS_PER_SHIFT = 0.45f;
        public const float HONEY_PER_UNASSIGNED_WORKER = 0.5f;

        private Bee[] workers = new Bee[0]; 
        private float eggs = 0; //numero de ovos
        private float unassignedWorkers = 3; //numero de operarias aguardando distribuiçãoo

        public string StatusReport { get; private set; }
        public override float CostPerShift { get { return 2.15f; } } //usa override tanto para 'virtual' quanto para 'abstract'
        
        public Queen() : base("Queen") 
        {
            AssignBee("Nectar Collector");
            AssignBee("Honey Manufacturer");
            AssignBee("Egg care");
        }

        protected override void DoJob()
        { 
            eggs = eggs + EGGS_PER_SHIFT;

            foreach (var worker in workers)
            {
                worker.WorkTheNextShift();
            }
            HoneyVault.ConsumeHoney(unassignedWorkers * HONEY_PER_UNASSIGNED_WORKER);
            UpdateStatusReport();
        }

        public void AssignBee(string job)
        {
            switch (job) 
            {
                case "Nectar Collector":
                    AddWorker(new NectarCollector());
                    break;
                case "Honey Manufacturer":
                    AddWorker(new HoneyManuFacturer());
                    break;
                case "Egg care":
                    AddWorker(new EggCare(this)); //esse 'this' é uma referência da próprio objeto em que está esse método, ou seja, um objeto rainha
                    break;
                default:
                    break;
            }
            UpdateStatusReport();
        }

        private void AddWorker(Bee worker)
        {
            if (unassignedWorkers >= 1)
            {
                unassignedWorkers--;
                Array.Resize(ref workers, workers.Length + 1);
                workers[workers.Length - 1] = worker;
            }  
        }

        public void CareForEggs(float eggsToConvert)
        {
            if (eggs >= eggsToConvert)
            {
                eggs = eggs - eggsToConvert;
                unassignedWorkers = unassignedWorkers + eggsToConvert;
            }
        }

        private void UpdateStatusReport()
        {
            StatusReport = $"Vault report: \n{HoneyVault.StatusReport}\n" + $"\nEgg count: {eggs:0.0}\nUnassigned workers:{unassignedWorkers:0.0}\n" 
                + $"{WorkerStatus("Nectar Collector")}\n{WorkerStatus("Honey Manufacturer")}" + $"\n{WorkerStatus("Egg Care")}\nTOTAL WORKERS: {workers.Length}";
        }

        private string WorkerStatus(string job)
        {
            int count = 0;
            foreach (Bee worker in workers)
                if (worker.Job == job) count++;
            string s = "s";
            if (count == 1) s = "";
            return $"{count} {job} bee{s}";
        }
    }

    /// <summary>
    /// Classe de coletor de nectar
    /// </summary>
    internal class NectarCollector : Bee
    {
        public const float NECTAR_COLLECTED_PER_SHIFT = 33.25f;
        public override float CostPerShift { get { return 1.95f; } }

        public NectarCollector():base("Nectar Collector") { }

        protected override void DoJob() 
        { 
            HoneyVault.CollectNectar(NECTAR_COLLECTED_PER_SHIFT);
        }
    }

    /// <summary>
    /// Classe de fazedor de mel
    /// </summary>
    internal class HoneyManuFacturer : Bee
    {
        public const float NECTAR_PROCESSED_PER_SHIFT = 33.15f;
        public override float CostPerShift { get { return 1.7f; } }

        public HoneyManuFacturer() : base("Honey Manufacturer") { }

        protected override void DoJob() 
        {
            HoneyVault.ConvertNectarToHoney(NECTAR_PROCESSED_PER_SHIFT);
        }
    }

    /// <summary>
    /// Classe de cuidador de ovo
    /// </summary>
    internal class EggCare : Bee
    {
        public const float CARE_PROGRESS_PER_SHIFT = 0.15f;
        public override float CostPerShift { get { return 1.35f; } }

        private Queen queen;
        public EggCare(Queen queen) : base("Egg Care") 
        {
            this.queen = queen;  //ta fazendo referência com a rainha da colmeia, vai poder se comunicar com ela
        }

        protected override void DoJob() 
        {
            queen.CareForEggs(CARE_PROGRESS_PER_SHIFT);
        }
    }

    static class HoneyVault
    {
        const float NECTAR_CONVERSION_RATIO = 19f;
        const float LOW_LEVEL_WARNING = 10f;

        private static float honey = 25f;
        private static float nectar = 100f;

        public static void CollectNectar(float amount)
        {
            if (amount > 0f) nectar += amount;
        }

        public static void ConvertNectarToHoney(float amount)
        {
            float nectarToConvert = amount;
            if (nectarToConvert > nectar) nectarToConvert = nectar;
            nectar -= nectarToConvert;
            honey += nectarToConvert * NECTAR_CONVERSION_RATIO;
        }

        public static bool ConsumeHoney(float amount)
        {
            if (honey >= amount) { 
                honey -= amount;
                return true;
            }
            return false;
        }

        public static string StatusReport
        {
            get
            {
                if (honey < LOW_LEVEL_WARNING)
                {
                    Console.WriteLine("LOW HONEY - ADD A HONEY MANUFACTURE");      
                }
                return $"{(int)honey}\n{(int)nectar}";
            }
        }
    }

    interface IDefend //qualquer classe que implementa a interface IDefend deve incluir um método 'Defend'
    {
        void Defend();
    }




}