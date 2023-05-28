using System.IO;

namespace GradeBook
{
    public class DiskBook : Book
    {
        private string v;

        public DiskBook(string v): base(v)
        {
            this.v = v;
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            using(var writer = File.AppendText($"{Name}.txt")){
                writer.WriteLine(grade);
                if(GradeAdded != null){
                    GradeAdded(this, new System.EventArgs());
                }
            }
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            using(var reader = File.OpenText($"{Name}.txt")){
                var line = reader.ReadLine();
                while(line != null){
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }
            return result;
        }
    }
}