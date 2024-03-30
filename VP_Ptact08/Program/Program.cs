﻿using ClassLibrary;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.CompilerServices;


List<Item> items = new List<Item>();

// Добавление товаров в список
items.Add(new Item(1, "Футболка", "Синий", 15000.99, "Модный магазин", new DateOnly(2023, 5, 10)));
items.Add(new Item(2, "Джинсы", "Черный", 29.99, "Джинсовый мир", new DateOnly(2023, 4, 22)));
items.Add(new Item(3, "Кроссовки", "Белый", 49.99, "Спортивный магазин", new DateOnly(2023, 3, 15)));
items.Add(new Item(4, "Рубашка", "Красный", 24.99, "Модный магазин", new DateOnly(2023, 6, 5)));
items.Add(new Item(5, "Шорты", "Зеленый", 19.99, "Летний стиль", new DateOnly(2023, 7, 10)));
items.Add(new Item(6, "Платье", "Розовый", 39.99, "Модный магазин", new DateOnly(2023, 8, 20)));
items.Add(new Item(7, "Джинсы", "Серый", 59000.99, "Мужской стиль", new DateOnly(2024, 9, 3)));
Console.WriteLine("Список товаров: ");
foreach (Item item in items)
{
    Console.WriteLine(item);
}
/*Запрос 1. Отсортировать товары по поставщику, а затем по
наименованию*/

//Синтаксис 1
var even1_1 = 
            from item in items 
            orderby item.Provider
            select item;

var even1_2 =
    from item in items
    orderby item.ProductionDate
    select item;

//Синтаксис 2
IEnumerable<Item> even1_3 = items
    .OrderBy(i => i.Provider);

IEnumerable<Item> even1_4 = items
    .OrderBy(i => i.ProductionDate);

//Console.WriteLine("Сортировка по поставщику:");
//foreach (var item in even1_1)
//{
//    Console.WriteLine(item);
//}

//Console.WriteLine("\nСортировка по дате производства:");
//foreach (var item in even1_2)
//{
//    Console.WriteLine(item);
//}

//// Синтаксис 2
//Console.WriteLine("\nСортировка по поставщику (синтаксис 2):");
//foreach (var item in even1_3)
//{
//    Console.WriteLine(item);
//}

//Console.WriteLine("\nСортировка по дате производства (синтаксис 2):");
//foreach (var item in even1_4)
//{
//    Console.WriteLine(item);
//}

/*Запрос 2.  Вывести информацию о товарах конкретного поставщика*/

//Синтаксис 1
var even2_1 =
            from item in items
            where item.Provider == "Модный магазин"
            select item;
//Синтаксис 2
IEnumerable<Item> even2_2 = items
    .Where(i => i.Provider== "Модный магазин");

//Console.WriteLine("Информация о товарах от поставщика 'Модный магазин':");
//foreach (var item in even2_1)
//{
//    Console.WriteLine(item);
//}

//Console.WriteLine("\nИнформация о товарах от поставщика 'Модный магазин' (синтаксис 2):");
//foreach (var item in even2_2)
//{
//    Console.WriteLine(item);
//}

/*Запрос 3. Вывести три самых дорогих товара*/

//Синтаксис 1
var even3_1 =
            (from item in items
            orderby item.Price descending
             select item).Take(3);

//Синтаксис 2
IEnumerable<Item> even3_2 = items
.OrderByDescending(i=>i.Price).Take(3);

//Console.WriteLine("Три самых дорогих товара (синтаксис 1):");
//foreach (var item in even3_1)
//{
//    Console.WriteLine(item);
//}

//Console.WriteLine("\nТри самых дорогих товара (синтаксис 2):");
//foreach (var item in even3_2)
//{
//    Console.WriteLine(item);
//}

/*Запрос 4. Вывести информацию о товарах, произведенных в текущем
году.*/

//Синтаксис 1
var even4_1 =
            from item in items
            where item.ProductionDate.Year== DateTime.Now.Year
            select item;

//Синтаксис 4
IEnumerable<Item> even4_2 = items
    .Where(i =>i.ProductionDate.Year == DateTime.Now.Year);

//Console.WriteLine("Информация о товарах, произведенных в текущем году (синтаксис 1):");
//foreach (var item in even4_1)
//{
//    Console.WriteLine(item);
//}

//Console.WriteLine("\nИнформация о товарах, произведенных в текущем году (синтаксис 4):");
//foreach (var item in even4_2)
//{
//    Console.WriteLine(item);
//}

/*Запрос 5. Вывести информацию о последнем произведенном товаре*/


//Синтаксис 1
var even5_1 =
            (from item in items
            orderby item.ProductionDate descending
            select item).First();

//Синтаксис 2
IEnumerable<Item> even5_2 = items
    .OrderByDescending(i => i.ProductionDate).Take(1);

//Console.WriteLine("Информация о последнем произведенном товаре (синтаксис 1):");
//Console.WriteLine(even5_1);

//Console.WriteLine("\nИнформация о последнем произведенном товаре (синтаксис 2):");
//foreach (var item in even5_2)
//{
//    Console.WriteLine(item);
//}

/*Запрос 6.  Посчитать количество поставщиков товара с заданным наименованием*/

//Синтаксис 1
int even6_1 =
        (from item in items
        where item.Name == "Джинсы"
        select item.Provider).Distinct().Count();


int even6_2 = items
    .Where(i => i.Name == "Джинсы")
    .Select(i => i.Provider)
    .Distinct()
    .Count();

//Console.WriteLine($"Количество поставщиков товара 'Джинсы' (синтаксис 1): {even6_1}");

//Console.WriteLine($"Количество поставщиков товара 'Джинсы' (синтаксис 2): {even6_2}");


/*Запрос 7. Вывести поставщиков, которые поставляют товары только дороже 10000*/

//Синтаксис 1
var even7_1 =
        (from item in items
         where item.Price > 10000
         select item.Provider).Distinct();

//Синтаксис 2
IEnumerable<string> even7_2 = items
    .Where(i => i.Price>10000)
    .Select(i => i.Provider)
    .Distinct();


//Console.WriteLine("Поставщики, которые поставляют товары только дороже 10000 (синтаксис 1):");
//foreach (var provider in even7_1)
//{
//    Console.WriteLine(provider);
//}

//Console.WriteLine("\nПоставщики, которые поставляют товары только дороже 10000 (синтаксис 2):");
//foreach (var provider in even7_2)
//{
//    Console.WriteLine(provider);
//}

/*Запрос 8.Вывести товары, которые либо не поставлялись в текущем
году, либо их цена ниже средней цены всех товаров */

//Синтаксис 1
double even8_1 =
        (from item in items
         select item.Price).Average();

var filteredItems1 =
    from item in items
    where item.ProductionDate.Year != DateTime.Now.Year || item.Price < even8_1
    select item;

//Console.WriteLine("Товары, которые либо не поставлялись в текущем году, либо их цена ниже средней цены всех товаров:");
//foreach (var item in filteredItems1)
//{
//    Console.WriteLine(item);
//}

//Синтаксис 2
double even8_2 =items.Select(i => i.Price).Average();

IEnumerable<Item> filteredItems2 = items
             .Where(i => i.ProductionDate.Year != DateTime.Now.Year || i.Price < even8_1);

//Console.WriteLine("Товары, которые либо не поставлялись в текущем году, либо их цена ниже средней цены всех товаров:");
//foreach (var item in filteredItems2)
//{
//    Console.WriteLine(item);
//}


/*Запрос 9. Вывести полные наименования товаров в виде {Артикул}
{Наименование} {Цвет}*/

//Синтаксис 1
var even9_1 = from item in items
                select $"{item.Id} {item.Name} {item.Color}";

//Синтаксис 2
IEnumerable<string> even9_2 = items
    .Select(i => $"{i.Id} {i.Name} {i.Color}");

//Console.WriteLine("\nВывести полные наименования товаров в виде {Артикул} { Наименование}{ Цвет} (синтаксис 1):");
//foreach (var item in even9_1)
//{
//    Console.WriteLine(item.ToString());
//}

//Console.WriteLine("\nВывести полные наименования товаров в виде {Артикул} { Наименование}{ Цвет} (синтаксис 2):");
//foreach (var item in even9_2)
//{
//    Console.WriteLine(item.ToString());
//}

/*Запрос 10.Вывести минимальную цену товара для каждого поставщика */

//Синтаксис 1
var even10_1 = from item in items
                          group item by item.Provider into providerGroup
                          select new
                          {
                              Provider = providerGroup.Key,
                              MinPrice = providerGroup.Min(item => item.Price)
                          };
//Console.WriteLine("Минимальная цена для каждого поставщика (синтаксис 1):");
//foreach (var item in even10_1)
//{
//    Console.WriteLine($"Поставщик: {item.Provider}, Минимальная цена: {item.MinPrice}");
//}
//Синтаксис 2
IEnumerable<dynamic> even10_2 = items
    .GroupBy(i => i.Provider) 
    .Select(group => new { Provider = group.Key, MinPrice = group.Min(item => item.Price) });

//Console.WriteLine("Минимальная цена для каждого поставщика (синтаксис 2):");
//foreach (var item in even10_2)
//{
//    Console.WriteLine($"Поставщик: {item.Provider}, Минимальная цена: {item.MinPrice}");
//}