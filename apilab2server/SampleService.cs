using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;
using Models;

namespace apilab2server
{
    public class SampleService : ISampleService
    {

        Dictionary<Guid, int> counts = new Dictionary<Guid, int>();
        public string Ping(string s)
        {
            Console.WriteLine("Exec ping method");
            return s;
        }

        public ComplexModelResponse PingComplexModel(ComplexModelInput inputModel)
        {
            Console.WriteLine("Input data. IntProperty: {0}, StringProperty: {1}", inputModel.IntProperty, inputModel.StringProperty);

            return new ComplexModelResponse
            {
                FloatProperty = float.MaxValue / 2,
                StringProperty = inputModel.StringProperty,
                ListProperty = inputModel.ListProperty,
                DateTimeOffsetProperty = inputModel.DateTimeOffsetProperty
            };
        }

        public int[] IntArray()
        {
            return new int[]
            {
                123,
                456,
                789
            };
        }

        public void VoidMethod(out string s)
        {
            s = "Value from server";
        }

        public Task<int> AsyncMethod()
        {
            return Task.Run(() => 42);
        }

        public int? NullableMethod(bool? arg)
        {
            return null;
        }

        public void XmlMethod(XElement xml)
        {
            Console.WriteLine(xml.ToString());
        }

        public ComplexReturnModel[] ComplexReturnModel()
        {
            return new ComplexReturnModel[]
            {
                new ComplexReturnModel
                {
                    Id = 1,
                    Name = "Item 1"
                },
                new ComplexReturnModel
                {
                    Id = 2,
                    Name = "Item 2"
                }
            };
        }
        public int PingKey(string key, Guid guid)
        {
            int currentCount;
            counts.TryGetValue(guid, out currentCount);

            counts[guid] = currentCount + 1;
            return counts[guid];
        }
    }
}