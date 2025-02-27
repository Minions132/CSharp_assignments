using System;
using System.Data;
namespace Caculator{
    class Caculator{
        static void Main(string[] args){
            try{
                Console.WriteLine("请输入第一个数字:");
                double a = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("请输入第二个数字:");
                double b = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("请输入一个运算符(+,-,*,/):");
                char c = Convert.ToChar(Console.ReadLine());
                double result = 0;
                switch(c){
                    case '+':
                        result = a + b;
                        break;
                    case '-':
                        result = a - b;
                        break;
                    case '*':
                        result = a * b;
                        break;
                    case '/':
                        if(b == 0){
                            throw new DivideByZeroException("除数不能为零");
                        }
                        result = a / b;
                        break;
                    default:
                        throw new InvalidOperationException("运算符无效");
                }
                Console.WriteLine("计算结果:{0}", result);
            }
            catch(DivideByZeroException msg){
                Console.WriteLine("错误: " + msg.Message);
            }
            catch(InvalidOperationException msg){
                Console.WriteLine("错误: " + msg.Message);
            }
            Console.WriteLine("按任意键退出");
            Console.ReadKey();
        }
    }
}
