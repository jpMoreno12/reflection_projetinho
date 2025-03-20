using System;
using System.Reflection;
using testeReflection;
using System.Linq;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car civic = new Car
            (
               chassi: "123kjhhc",
               id: 12,
               color: "black",
               labelPlate: "SSJoao"
            );

            Car gol = new Car
            (
                chassi: "Gol bola",
                id: 123,
                color: "yellow"
            );


            Car novo = (Car)copyInstance(gol, "testeReflection");
            Console.WriteLine(novo.Color);


            User fabio = new User
            (
                year: 30,
                name: "Fabio"
            );

            User novoUsuario = (User)copyInstance(fabio, "testeReflection");

            Console.WriteLine
            (
                novoUsuario.Name
            );

            Console.WriteLine("Crie uma Instancia da Classe Desejada: \nCar \nUser");
            string selectedClass = Console.ReadLine()!;
            Console.WriteLine();

            switch (selectedClass)
            {
                case "Car":
                Console.WriteLine();
                    break;
                case "User":
                Console.WriteLine();
                    break;
                default:
                Console.WriteLine("Classe selecionada nao existe");
                    break;
            }
        }

        static void createNewInstance(string className)
        {
            if(className == typeof(Car).ToString())
            {
                Console.WriteLine($"Digite o Nome da Instanca da Classe {className}: ");
                string nameInstance = Console.ReadLine()!;

                if(string.IsNullOrEmpty(nameInstance))
                {
                    Console.WriteLine("O nome está vazio. Digite um Nome válido");
                }

            }
        }

        static Object copyInstance(Object instance, string nameSpace)
        {
            string pathNameSpace = nameSpace;
            string pathClass = $"{pathNameSpace}.{instance.GetType().Name}";

            if (pathClass == instance.GetType().ToString())
            {
                object newInstance = "";

                var initialObj = instance.GetType();
                // busca apenas membros da instancia em questao e nao membros staticos
                //da classe
                var propsClass = initialObj.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);

                Type[] objectOfInstance = propsClass.Select(p => p.PropertyType).ToArray();

                ConstructorInfo? constructorInfo = initialObj.GetConstructor(
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic,
                objectOfInstance
                );

                if (constructorInfo != null)
                {

                    object[] paramValues = propsClass.Select(p => p.GetValue(instance)!).ToArray();

                    newInstance = constructorInfo.Invoke(paramValues);
                    return newInstance;
                }
                else
                {
                    Console.WriteLine("Construtor não encontrado!");
                }

                return newInstance;

            }
            else
            {
                Console.WriteLine("O objeto nao pode ser criado");
            }

            return null!;
        }

    }

}

