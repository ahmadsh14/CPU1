using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            Simulator data = readFromFile<Simulator>.LoadTasksJSON("./ReadFromFile/readTasks.json");
            /*             Simulator dataXML = readFromFile<Simulator>.LoadTasksXML("./ReadWrite/ReadTaskXML.xml");
             */
            Console.WriteLine($"Num Of Processors: {data.ProcessorsCount}");
            Simulator simulator = new Simulator(data.ProcessorsCount, data.Tasks);
            simulator.RunSimulation();
        }
    }
}

