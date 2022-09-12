# Проценты
**Необходимые библиотеки**
```
using System;
using System.Linq;
```

**Вызываем метод с аргументом из консоли. Выводим полученный результат на экран**
```
public static void Main(string[] args)
{
  Console.WriteLine(Calculate(Console.ReadLine()));
}
```
**Обрабатываем ввод**

```Console.ReadLine()``` - Считываем ввод консоли  
```Split(' ')``` - Разбиваем строку на массив строк, используя пробел как разделитель  
```Select(int.Parse)``` - Превращаем все значения из string в int. Получаем Enumarator из int  
```ToArray()``` - Превращаем Enumarable обратно в массив
```
var read = userInput.Split(' ').Select(double.Parse).ToArray();
```

❕ *Дальше мы могли бы проверять ввод на корректность, но по условию любой ввод корректный*

Создаем переменные для нужных нам данных. Можно было бы использовать просто значения по индексу в массиве read, но код был бы более запутанным для чтения.

Исходная сумму кредита
```
var principal = read[0];
```
Процентная ставка
```
var percentageRate = read[1];
```
Срок вклада в месяцах
```
var termMonths = read[2];
```
Для начала получаем процетную ставку за месяц - ```percentageRate / (100 * 12)```, так как проценты у нас указаны целочислено и за целый год
Далее каждый месяц прибавляется эта ставка. За первый месяц результат будет такой ```var result = principal + principal * percentageRate / (100 * 12)```, за второй ```var newResult = result + result * percentageRate / (100 * 12)```, что можно сократить так:
```
// Начальное значение
var result = principal
result *= 1 + percentageRate / (100 * 12)
```
Теперь нам нужно выполнить эту операцию ровно столько, сколько месяцев кредита. Для этого можно использовать цикл:
```
var result = principal;
for (var i = 0; i < termMonths; i++)
{
  result *= 1 + percentageRate / (100 * 12);
}
return result
```
**Вот и все**  
❕ Но по условию задачи нам необходимо сделать это без цикла. Заметим, что мы просто умножаем result на процентную ставку termMonths раз. Получается, что мы можем просто умножить ```principal``` на 1 + percentageRate / (100 * 12) в степени termMonths. Пояснение :
```
var percMonth = 1 + percentageRate / (100 * 12)
principal * percMonth - в первый месяц
principal * percMonth * percMonth - во второй месяц
principal * percMonth * percMonth * percMonth - в третий месяц
и т.д.
```
**Возвращаем результат**
```Math.Pow``` - возводит первое значение в степень второго
```
return principal * Math.Pow(1 + percentageRate / (100 * 12), termMonths);
```