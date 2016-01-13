﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.Drawing;
using System.IO;
using dotnet_clara.lib;
using CommandLine;
using CommandLine.Text;

namespace dotnet_clara
{
    class Program
    {
        static void Main()
        {
            Console.Write(".Net Clara version 0.2\n");
            Config config = new Config();
            config.initializeConfig();
            lib.Clara clara = new lib.Clara(config);
            while (true)
            {
                Console.Write(">");
                string[] args = Console.ReadLine().Split(' ');
                if (args[0] == "set")
                    config.SetConfig(args[1], args[2]);
                if (args[0] == "get")
                    Console.WriteLine("Info {0}:{1}", args[1], config.GetOneConfigInfo(args[1]));
                if (args[0] == "help")
                {
                    Console.WriteLine("*************HELP*****************");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();

                }
                if (args[0] == "render")
                {
                    var bytes = clara.scene.Render(args[1], "{width:1200, height:600}", "{}");
                    var imagePath = "g:\\aaa.png";

                    using (var imageFile = new FileStream(imagePath, FileMode.Create))
                    {
                        imageFile.Write(bytes, 0, bytes.Length);
                        imageFile.Flush();
                    }
                }
                if (args[0] == "export")
                {
                    var bytes = clara.scene.Export(args[1], args[2]);
                    var imagePath = "g:\\test.zip";

                    using (var imageFile = new FileStream(imagePath, FileMode.Create))
                    {
                        imageFile.Write(bytes, 0, bytes.Length);
                        imageFile.Flush();
                    }
                }
                if (args[0] == "clone")
                {
                    clara.scene.Clone(args[1]);
                }
                if (args[0] == "delete")
                {
                    clara.scene.Delete(args[1]);
                }

            }
        }

    }


}

