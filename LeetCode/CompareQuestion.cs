using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics.CodeAnalysis;
using static LeetCode.CompareQuestion.StudentComparer;

namespace LeetCode
{
    public class Student : IComparable
    {
        public Student(int id, string name)
        {
            Name = name;
            Id = id;
        }
        public int Id { get; set; }

        public string Name { get; set; }

        

        public int CompareTo(object obj)
        {
                if (obj == null )
                    return -1;
                return Name.CompareTo((obj as Student).Name);
            
        }
    }

    class CompareQuestion : BaseClass   
    {

        public override void Run()
        {
            base.Run();

            var list = new List<Student>();
            list.Add(new Student(2, "A"));
            list.Add(new Student(1, "B"));
            list.Add(new Student(3, "C"));
            list.Sort(new StudentComparer()
            { compareField = SortBy.Id });

            list.Sort(new StudentComparer()
            { compareField = SortBy.Name });

            list.Sort();
            list = list.OrderBy(a => a.Id).ToList();
            list = list.OrderBy(a => a.Name).ToList();

            


            var dic = new Dictionary<int, string>();
            dic.Add(2, "A");
            dic.Add(1, "B");
            dic.Add(3, "C");
            dic = dic.OrderBy(x => x.Key).ToDictionary(x=> x.Key, x=>x.Value);
            dic = dic.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);


            Student[] arrayList = new Student[]
                {
                  new Student(2, "A"),
                  new Student(1, "B"),
                  new Student(3, "C"),
                };
            var studentComparer = new StudentComparer();
            studentComparer.compareField = StudentComparer.SortBy.Id;
            Array.Sort(arrayList, studentComparer);

            Array.Sort(arrayList);
        }

        public class StudentComparer : IComparer<Student>
        {
            public enum SortBy
            {
                Id,
                Name
            }
            public SortBy compareField = SortBy.Id;
            
            public int Compare([AllowNull] Student x, [AllowNull] Student y)
            {
                switch (compareField)
                {
                    case SortBy.Id :
                       return x.Id.CompareTo(y.Id);

                    case SortBy.Name :
                        return x.Name.CompareTo(y.Name);
                }
                return x.Name.CompareTo(y.Name);
            }
        }
    }
}
