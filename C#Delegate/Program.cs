using System.Diagnostics;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace C_Delegate
{
    //Task:
    //1.Func adinda delegate yaradin hansi ki bir
    //string parametr qebul edir ve void qaytarir.
    //2.MyClass adinda bir class yaradin hansi ki,
    //ozunde iki static olmayan method saxlayir(Space(), Reverse())


    //public void Space(string str);e_x_a_m_p_l_e -> bu metod sadece her herifin arasina(_)atir.
    //public void Reverse(string str)example -> bu metod ise stringi tersine cevirir.

    //3.Run adinda bir class yaradin hansi ki, ozunde runFunc(argument) adinda void function saxlayir.

    //Mesele budur ki, men consoldan bir soz daxil edecem
    //ve asagidaki runFunc i cagiracam.Netice olaraq hemen iki funksiya
    //yuxarida gosterdiyim kimi cavablar qaytarmalidir.

    //main-de bunnan artiq kod yaza bilmezsiniz.Amma Classlarda azadsiniz.
    //Burda esas diqqet etmeli oldugunuz meqam metodlar,
    //MyClass dadir ama men onlari Run da cagiriram.Yeni o metodlari delagate
    //seklinde Run a gonderib orda invoke elemek lazimdir.

    //public static void Main()
    //{
    //    Console.WriteLine("Enter the string : ");
    //    var str = Console.ReadLine();

    //    MyClass cls = new MyClass(str);
    //    Func funcDell = new Func(params) // params sadece sizin ora vereceyiniz parametrlerdi	

    //    burda funcDell-e functionlari verirsiniz

    //    Run run = new Run();
    //    run.runFunc(funcDell, str); //cagiranda Space() ve Reverse() functionlari ise dusmelidir
    //}
    public class MyClass
    {
        public void Space(string str)
        {
            string spaceStr = string.Join("_", str.ToCharArray());
            Console.WriteLine(spaceStr);
        }

        public void Reverse(string str)
        {
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            string reversedStr = new string(charArray);
            Console.WriteLine(reversedStr);
        }
    }

    public delegate void Func(string str);

    public class Run
    {
        public void RunFunc(Func func, string str)
        {
            func.Invoke(str);
        }
    }

    public class Program
    {
        public static void Main()
        {
            Console.Write("Enter the string : ");
            var str = Console.ReadLine();

            MyClass myClass = new MyClass();

            Func spaceFunc = new Func(myClass.Space);
            Func reverseFunc = new Func(myClass.Reverse);

            Run run = new Run();

            Console.WriteLine("Space Result");
            run.RunFunc(spaceFunc, str);

            Console.WriteLine();

            Console.WriteLine("Reverse Result");
            run.RunFunc(reverseFunc, str);
        }
    }
}


