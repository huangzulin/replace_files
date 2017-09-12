using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace replace_files
{
    class Program
    {
        static void Main(string[] args)
        {
            var currentpath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            Console.WriteLine("当前路径：" + currentpath);
            var oldValue = ""; var newValue = "";
            if (args.Length != 2)
            {
                Console.WriteLine("请输入旧值：");
                oldValue = Console.ReadLine();
                Console.WriteLine("请输入新值：");
                newValue = Console.ReadLine();
            }
            else
            {
                oldValue = args[0];
                newValue = args[1];
            }

            var filePaths = Directory.GetFiles(currentpath, "*", SearchOption.AllDirectories)
                .Where(x => !x.ToLower().EndsWith("exe") && !x.EndsWith("bat")).ToList();

            foreach (var p in filePaths)
            {
                string text = File.ReadAllText(p);
                text = text.Replace(oldValue, newValue);
                File.WriteAllText(p, text);
            }

        }

    }
}
