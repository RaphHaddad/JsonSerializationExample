using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
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
                _FName = "Raph",
                _FirstName = "Raph"
            };

            var jsonSettings = new JsonSerializerSettings
            {
                ContractResolver = new SnakeCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore
            };

            var json = JsonConvert.SerializeObject(data, jsonSettings);//serialize object to snake_case1

            var obj = JsonConvert.DeserializeObject<MyClass>(json, jsonSettings);//desserialize object from snake_case1

            jsonSettings.ContractResolver = new SnakeCaseIntegerSeperatedPropertyNamesContractResolver();

            json = JsonConvert.SerializeObject(data, jsonSettings);//serialize object to snake_case_2

            obj = JsonConvert.DeserializeObject<MyClass>(json,jsonSettings); //deserialize object from snake_case_2

            //change settings to camelCase
            jsonSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            obj = JsonConvert.DeserializeObject<MyClass>(json, jsonSettings);//deserialization does not work

        }
    }
}
