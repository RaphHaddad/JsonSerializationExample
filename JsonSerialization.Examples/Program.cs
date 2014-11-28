using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization.ContractResolverExtentions;

namespace JsonSerialization.Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new MyClass
            {
                FName = "Raphael",
                First1Name = "Raph",
                FirstName = "Raph",
                FirstName1 = "Raph",
                FirstName_ = "Raph",
                _FName = "Raph"
            };

            var jsonSettings = new JsonSerializerSettings
            {
                ContractResolver = new SnakeCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore
            };

            var json = JsonConvert.SerializeObject(data, jsonSettings);

            Console.WriteLine(json);//without seperated integers

            jsonSettings.ContractResolver = new SnakeCaseIntegerSeperatedPropertyNamesContractResolver();

            json = JsonConvert.SerializeObject(data, jsonSettings);

            Console.WriteLine(json);
        }
    }
}
