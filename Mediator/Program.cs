using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            Mediator mediator = new Mediator();

            Teacher bahri = new Teacher(mediator);
            bahri.Name = "Bahri";

            mediator.Teacher = bahri;

            Student koc = new Student(mediator);
            koc.Name = "KOÇ";

            Student sarı = new Student(mediator);
            sarı.Name = "sarı";

            mediator.Students = new List<Student> {koc,sarı};

            bahri.SendNewImageUrl("slide.jpg");
            bahri.RecieveQuetion("Is it true?", sarı);
            Console.ReadLine();
        }
    }

    abstract class CourseMember
    {
        protected Mediator Mediator;

        protected CourseMember(Mediator mediator)
        {
            Mediator = mediator;
        }
    }

    class Teacher : CourseMember
    {
        public Teacher(Mediator mediator) : base(mediator) { }
        public string Name { get; set; }

        public void RecieveQuetion(string question, Student student)
        {
            Console.WriteLine("Teacher recieved a question from {0},{1}",student.Name,question);
        }

        public void SendNewImageUrl(string url)
        {
            Console.WriteLine("{0} changed slide : {1}", url,Name);
            Mediator.UpdateImage(url);
        }

        public void AnswerQuestion(string answer,Student student)
        {
            Console.WriteLine("Teacher answered question {0},{1}", student.Name, answer);
        }
    }

    class Student : CourseMember
    {
        public Student(Mediator mediator) : base(mediator) { }
        public string Name { get; set; }

        public void RecieveImage(string url)
        {
            Console.WriteLine("Student recieved image : {0}", url);
        }

        public void RecieveAnswer(string answer)
        {
            Console.WriteLine("Student recieved answer {0}", answer);
        }
    }

    class Mediator
    {
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }

        public void UpdateImage(string url)
        {
            foreach (var student in Students)
            {
                student.RecieveImage(url);
            }
        }

        public void SendQuetion(string question,Student student)
        {
            Teacher.RecieveQuetion(question,student);
        }

        public void SendAnswer(string answer,Student student)
        {
            student.RecieveAnswer(answer);
        }
    }
}
