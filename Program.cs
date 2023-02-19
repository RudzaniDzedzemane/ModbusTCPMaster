// See https://aka.ms/new-console-template for more information

using ModbusTCPMaster;

ModbusTCPMaster.ModbusTCPMaster newMaster = new ModbusTCPMaster.ModbusTCPMaster("10.0.0.4", 502);

Console.WriteLine("This is a TCP Server Application");

newMaster.OpenConnectionAndprintMessages();

Console.ReadKey();
