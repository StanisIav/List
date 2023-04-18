using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_06._03._23_Mon
{
    class Template
    {
        public class Obj<T>
        {
            public T[] arreyGlob = new T[0] { };
            public T[] arreySpare = new T[0] { };

            public Obj<T> AddItem(T item)
            {
                arreySpare = arreyGlob;
                int i = arreyGlob.Length;
                arreyGlob = new T[i + 1];
                for (int q = 0; q < i; q++) arreyGlob[q] = arreySpare[q];
                arreyGlob[i] = item;

                return this;
            }
        }

        public void Test()
        {
            Obj<string> test = new Obj<string>();
            test.AddItem("st").AddItem("at").AddItem("ST").AddItem("AS");
            foreach (var i in test.arreyGlob)
            {
                Console.WriteLine(i);
            }
        }
         
        Test();
    }
}
