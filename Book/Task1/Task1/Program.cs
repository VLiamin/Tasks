using System;

namespace Task1
{
    class Program
    {
     
        public static void Main()
        {
            checked
            { // Начало проверяемого блока
                Byte b = 100;
                b += 100; // Это выражение проверяется на переполнение
                Console.WriteLine(b);
            }
            
        }   
        public static void PromoteEmployee(Object o)
        {
            // В этом месте компилятор не знает точно, на какой тип объекта
            // ссылается o, поэтому скомпилирует этот код
            // Однако в период выполнения CLR знает, на какой тип
            // ссылается объект o (приведение типа выполняется каждый раз),
            // и проверяет, соответствует ли тип объекта типу Employee
            // или другому типу, производному от Employee
            Employee e = (Employee)o;
        }
    }
    internal class Employee
    {

    }
    internal class Manager : Employee
    {

    }
}
