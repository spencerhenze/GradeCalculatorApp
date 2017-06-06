using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grade_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {

            Slogan();

            Console.WriteLine("How many total points do you expect to receive from all homeworks, Exams, and the semester project?\n");
            double pointsExpected = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("\nHow many unofficial absences are you planning to have?\n");
            int totalAbsences = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nHow many homework assignments do you plan to have missing?\n");
            int missingHomework = Convert.ToInt32(Console.ReadLine());

            double absencePenalty = CalAbsencePenalty(totalAbsences);
            double homeworkPenalty = CalHWPenalty(missingHomework);

            CalculateGrade(absencePenalty, homeworkPenalty, pointsExpected);

            Console.ReadKey();

        } //End of Main

        public static void Slogan()
        {
            Console.WriteLine("Welcome to the ITM 320 Grade Calculator!\n");
        } //End of Slogan()

        public static double CalAbsencePenalty(int totalAbsences)
        {
            double aPenalty;
            if (totalAbsences > 4)
            {
                aPenalty = (totalAbsences - 4) * 50;
            }
            else
            {
                aPenalty = 0;
            }
            return aPenalty;
        } //End of CalculateGrade()

        public static double CalHWPenalty(int numMissingHW)
        {
            double hwPenalty;

            if (numMissingHW > 2)
            {
                hwPenalty = (numMissingHW - 2) * 30;
            }
            else
            {
                hwPenalty = 0;
            }
            return hwPenalty;
        } // End CalculateHWPenalty()

        public static void CalculateGrade(double absencePenalty, double hwPenalty, double pointsExpected)
        {
            double pointsPossible = (3 * 100) + 100 + (10 * 10); // (exam points) + Project + (Homework)
            double totalScore = pointsExpected - hwPenalty - absencePenalty;
            double scorePercentage = (totalScore / pointsPossible) * 100;

            string letterGrade = "";
            string consoleComment = "";

            if (scorePercentage >= 90)
            {
                letterGrade = "A";
                consoleComment = "You're a rock star!!!";
            }
            else if (scorePercentage <90 && scorePercentage >= 80)
            {
                letterGrade = "B";
                consoleComment = "Nice job!";
            }
            else if (scorePercentage < 80 && scorePercentage >= 70)
            {
                letterGrade = "C";
                consoleComment = "Congrats, you'll pass.";
            }
            else if (scorePercentage < 70 && scorePercentage >= 60)
            {
                letterGrade = "D";
                consoleComment = "You'll need to do better than that chief.";
            }
            else if (scorePercentage < 60)
            {
                letterGrade = "F";
                consoleComment = "No bueno compadre...";
            }

            Console.WriteLine("\nAssuming the estimations you entered are accurate, your can expect a(n) " + scorePercentage + "%, which would give you a(n): " + letterGrade + "\n" + consoleComment);

        } // End CalculateGrade()

    } // End Class
} // End nameSpace
