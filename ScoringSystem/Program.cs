using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoringSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = new List<ScoreItem>();

            var config = new ScoreConfiguration(new List<ScoreConfigurationItem>
            {
                new ScoreConfigurationItem
                {
                    Key = "var1",
                    Weight = 40
                },
                new ScoreConfigurationItem
                {
                    Key = "var2",
                    Weight = 23
                },
                new ScoreConfigurationItem
                {
                    Key = "var3",
                    Weight = 70
                },
                new ScoreConfigurationItem
                {
                    Key = "var4",
                    Weight = 90
                }
            });

            for(var i = 0; i < 1000000; i++)
            {
                items.Add(new ScoreItem(new object(), new float[] {i % 1000, i % 1000, i % 1000, i % 1000 }));
            }

            var syncDeterminant = new SynchronousScoreDeterminant(config);
            var syncSimdDeterminant = new SynchronousScoreSIMDDeterminant(config);
            var parallelDeterminant = new ParallelScoreDeterminant(config);
            var parallelSimdDeterminant = new ParallelScoreSIMDDeterminant(config);

            var sw1 = Stopwatch.StartNew();
            syncDeterminant.GetScoring(items);
            sw1.Stop();
            Console.WriteLine("Sync determinant elapsed miliseconds: " + sw1.Elapsed.TotalMilliseconds);

            var sw2 = Stopwatch.StartNew();
            syncSimdDeterminant.GetScoring(items);
            sw2.Stop();
            Console.WriteLine("Sync SIMD determinant elapsed miliseconds: " + sw2.Elapsed.TotalMilliseconds);

            var sw3 = Stopwatch.StartNew();
            parallelDeterminant.GetScoring(items);
            sw3.Stop();
            Console.WriteLine("Parallel determinant elapsed miliseconds: " + sw3.Elapsed.TotalMilliseconds);

            var sw4 = Stopwatch.StartNew();
            parallelSimdDeterminant.GetScoring(items);
            sw4.Stop();
            Console.WriteLine("Parallel SIMD determinant elapsed miliseconds: " + sw4.Elapsed.TotalMilliseconds);

            Console.ReadKey();
        }
    }
}
