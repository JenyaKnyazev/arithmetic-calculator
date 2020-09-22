using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string text,number1="",number2="";
            double result=0,result2=0;
            char oper,oper2='@';
            double res = 0;
            Console.WriteLine("arithmetic conculator enter like 15*5+2-4/8");
            text=Console.ReadLine();
            int i = 0,index_first,index_second,index;
            while (i < text.Length) {
                index = i;
                while (i<text.Length&&text[i] != '/' && text[i] != '*' && text[i] != '%')
                    i++;
                res = 0; 
                if (i < text.Length && (text[i] == '*' || text[i] == '/' || text[i] == '%')) {
                    number1 = "";
                    int r = index_first=i-1;
                    while (r > 0 &&( text[r] >= '0' && text[r] <= '9'||text[r]=='.' ))
                        r--;
                    if (text[r] == '+' || text[r] == '-')
                        oper2 = text[r];
                    if (text[r]<'0'||text[r]>'9')
                        r++;
                    while (r <= index_first)
                        number1 += text[r++];
                    res += double.Parse(number1);
                }
                while (i < text.Length && (text[i] == '*' || text[i] == '/' || text[i] == '%')){
                    oper = text[i];
                    number2="";
                    index_second = i + 1;
                    while (index_second < text.Length && (text[index_second] >= '0' && text[index_second] <= '9' || text[index_second]=='.'))
                        number2 += text[index_second++];
                    i = index_second;
                    if (oper == '*')
                        res *= double.Parse(number2);
                    else if (oper == '/')
                        res /= double.Parse(number2);
                    else if (oper == '%')
                        res %= double.Parse(number2);
                }
                if (result == 0)
                    result += res;
                if (oper2 == '+')
                    result += res;
                else if (oper2 == '-')
                    result -= res;
            }
            i = 0;
            oper2 = '@';
            while (i < text.Length) {
                number1 = "";
                while (i < text.Length && (text[i] >= '0' && text[i] <= '9' || text[i] == '.'))
                    number1 += text[i++];
                if (i < text.Length &&(text[i]=='*'||text[i]=='/'||text[i]=='%')){
                    i++;
                    while (i < text.Length && (text[i] <= '9' && text[i] >= '0'||text[i]=='.'))
                        i++;
                    number1 = "";
                }else if (i < text.Length ||!number1.Equals(""))
                {
                    res = double.Parse(number1);
                    if (oper2 == '+')
                        result += res;
                    else if (oper2 == '-')
                        result -= res;
                    else
                        result += res;
                }
                if (i < text.Length && (text[i] == '+' || text[i] == '-'))
                    oper2 = text[i++];
            }
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
