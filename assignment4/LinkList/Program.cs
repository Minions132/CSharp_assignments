using System;
using System.Security.Cryptography.X509Certificates;

namespace LinkList{
    public class Node<T>(T t)
    {
        public Node<T>? Next { get; set; } = null;
        public T Data { get; set; } = t;
    }
    public class GenericList<T>{
        private Node<T>? head;
        private Node<T>? tail;
        public GenericList(){
            head = null;
            tail = null;
        }
        public void Add(T t){
            Node<T> n = new Node<T>(t);
            if(tail == null){
                head = tail = n;
            }
            else{
                tail.Next = n;
                tail = tail.Next;
            }
        }
        public void ForEach(Action<T> action){
            if(head != null){
                Node<T> cur = head;
                while(cur != null){
                    action(cur.Data);
                    cur = cur.Next;
                }
            }
        }
    }
    class Program{
        static void Main(string[] args){
            GenericList<int> list = new GenericList<int>();
            Random random = new Random();
            for(int i = 0; i < 10; i++){
                int num = random.Next(1, 101);
                list.Add(num);
            }
            Console.WriteLine("Elements in the list:");
            list.ForEach(x => Console.WriteLine(x));
            int max = int.MinValue;
            list.ForEach(x => {if(x > max) max = x;});
            Console.WriteLine($"Maximum Value:{max}");
            int min = int.MaxValue;
            list.ForEach(x => {if(x < min) min = x;});
            Console.WriteLine($"Minimum Value:{min}");
            int sum = 0;
            list.ForEach(x => sum += x);
            Console.WriteLine($"Sum:{sum}");
        }
    }
}