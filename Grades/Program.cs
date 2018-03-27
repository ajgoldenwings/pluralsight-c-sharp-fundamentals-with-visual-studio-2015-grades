using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            //SpeechSynthesizer synth = new SpeechSynthesizer();
            //synth.Speak("Hello! This is the grade book program");

            GradeBook book = new GradeBook();

            book.NameChanged += new NameChangedDelegate(OnNameChanged);

            book.Name = "Anthony's Grade Book";
            book.AddGrade(91);
            book.AddGrade(89.5f);

            GradeStatistics stats = book.ComputeStatistics();
            Console.WriteLine(book.Name);
            Console.WriteLine(stats.AverageGrade);
            Console.WriteLine(stats.HighestGrade);
            Console.WriteLine(stats.LowestGrade);

            GradeBook book2 = book;
            book2.AddGrade(75);
        }

        static void OnNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine($"Gradebook changing name from {args.ExistingName} to {args.NewName}");
        }
    }
}
