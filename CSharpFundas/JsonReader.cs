using Newtonsoft.Json.Linq;
using System.IO;
using System;


String myJsonString = File.ReadAllText("testData.json"); //var or string
var jsonObject = JToken.Parse(myJsonString);
Console.WriteLine(jsonObject.SelectToken("password").Value<String>());




