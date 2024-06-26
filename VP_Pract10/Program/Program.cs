﻿using ClassLibrary;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.Intrinsics.X86;
/* ПУНКТ 1*/

//string filePath = "C:\\Users\\user3\\OneDrive\\Рабочий стол\\Визуал прог\\ПЗ\\VP_Pract10\\test.txt";

//FileClass file = FileClass.Open(filePath);

//file = null;


//FileClass newFile = FileClass.Open(filePath);

//string line = newFile.ReadLine();
//Console.WriteLine(line);



/*ПУНКТ 3*/

//string filePath = "C:\\Users\\user3\\OneDrive\\Рабочий стол\\Визуал прог\\ПЗ\\VP_Pract10\\test.txt";
//FileClass file = FileClass.Open(filePath);
//file?.Dispose();
//FileClass newFile = FileClass.Open(filePath);

//string line = newFile.ReadLine();
//Console.WriteLine(line);


FileClass file = null;
string filePath = "C:\\Users\\user3\\OneDrive\\Рабочий стол\\Визуал прог\\ПЗ\\VP_Pract10\\test2.txt";
/*ПУНКТ 5*/
//try
//{
//    file = FileClass.Open(filePath);
//    file.WriteLine("Its new string");
//}
//finally
//{
//    file?.Dispose();
//}

/*ПУНКТ 6*/
//using (FileClass file1 = FileClass.Open(filePath))
//{
//    string line = file1.ReadLine();
//    Console.WriteLine(line);
//}

/*ПУНКТ 7*/
long startMemory = GC.GetTotalMemory(true);

Console.WriteLine("Начальный размер кучи: " + startMemory + " байт");


for (int i = 0; i < 3000; i++)
{
    new object();
}

// Получаем размер кучи после создания объектов
long afterAllocMemory = GC.GetTotalMemory(false);
Console.WriteLine("Размер кучи после выделения памяти для объектов: " + afterAllocMemory + " байт");

// Запускаем сборку мусора
GC.Collect();

// Получаем размер кучи после сборки мусора
long endMemory = GC.GetTotalMemory(true);
Console.WriteLine("Размер кучи после сборки мусора: " + endMemory + " байт");
