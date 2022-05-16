using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Работа с values.json
            string jsonValues = File.ReadAllText(args[1]);

            Values values = JsonConvert.DeserializeObject<Values>(jsonValues);

            //Работа с tests.json
            string jsonTests = File.ReadAllText(args[0]);

            Tests tests = JsonConvert.DeserializeObject<Tests>(jsonTests);

            //присваем значения value в соответсвии с id
            foreach (Value value in values.values)
            {
                foreach (Test test in tests.tests)
                {
                    if (value.id == test.id)
                    {
                        test.value = value.value;
                    }

                    if (test.values != null)
                    {
                        foreach(var subTest in test.values)
                        {
                            if (value.id == subTest.id)
                            {
                                subTest.value = value.value;
                            }

                            if (subTest.values != null)
                            {
                                foreach (var subSubTest in subTest.values)
                                {
                                    if (value.id == subSubTest.id)
                                    {
                                        subSubTest.value = value.value;
                                    }

                                    if (subSubTest.values != null)
                                    {
                                        foreach (var subSubSubTest in subSubTest.values)
                                        {
                                            if (value.id == subSubSubTest.id)
                                            {
                                                subSubSubTest.value = value.value;
                                            }
                                        }
                                    }
                                }
                            } 
                        }
                    }
                }
            }

            //создаем и сохраняем json файл
            string jsonName = "report.json";

            var json = JsonConvert.SerializeObject(tests, Formatting.Indented);

            string pathToSaveNewJson = Path.GetFullPath(args[0]);

            string existingJsonName = Path.GetFileName(args[0]);

            string jsonPath = pathToSaveNewJson.Remove(pathToSaveNewJson.Length - existingJsonName.Length);

            pathToSaveNewJson = Path.Combine(jsonPath, jsonName);

            File.WriteAllText(pathToSaveNewJson, json);
        }


        public class Values
        {
            public List<Value> values { get; set; }
        }

        public class Value
        {
            public int id { get; set; }
            public string value { get; set; }
        }

        public class Tests
        {
            public List<Test> tests { get; set; }
        }

        public class Test
        {
            public int id { get; set; }
            public string title { get; set; }
            public string value { get; set; }
            public List<Test> values { get; set; }
        }

    }
}

