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

            Car civicV2 = new Car();

            Car novo = (Car)copyInstance(civic, "testeReflection");

            Console.WriteLine(novo.Color);

           /*  Car gol = new Car();

            Car novo = (Car)copyInstance(gol, "testeReflection");
            Console.WriteLine(novo); */

            User fabio = new User();


        }

        static Object copyInstance(Object instance, string nameSpace)
        {
            string pathNameSpace = nameSpace;
            string pathClass = $"{pathNameSpace}.{instance.GetType().Name}";

            if (pathClass == instance.GetType().ToString())
            {
                var initialObj = instance.GetType();

                var propsClass = initialObj.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);

                object newInstance;
                newInstance = "";
                Type[] objectOfInstance = new Type[] {typeof(int), typeof(int), typeof(int), typeof(int), typeof(int)};
                
                ConstructorInfo? defaultConstructor = initialObj.GetConstructor(Type.EmptyTypes);

                /* if (defaultConstructor != null)
                {
                    newInstance = defaultConstructor.Invoke(null);
                }
                else
                {
                    ConstructorInfo constructor = initialObj.GetConstructors().First();
                    ParameterInfo[] parameters = constructor.GetParameters();

                    foreach (var item in parameters)
                    {
                       Console.WriteLine(item) ;
                    }

                    object[] defaultValues = parameters.Select(p => GetDefaultValue(p.ParameterType)).ToArray()!;

                    
                    newInstance = constructor.Invoke(defaultValues);
                } */


                foreach (var propOfObj in propsClass)
                {
                    if (propOfObj.CanWrite)
                    {
                        object value = propOfObj.GetValue(instance)!;
                        propOfObj.SetValue(newInstance, value);
                    }

                }

                return newInstance;

            }
            else
            {
                Console.WriteLine("O objeto nao pode ser criado");
            }

            return null!;
        }

        static object? GetDefaultValue(Type type)
        {
            return type.IsValueType ? Activator.CreateInstance(type) : null;
        }

    }

}

