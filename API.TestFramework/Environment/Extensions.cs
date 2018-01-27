﻿using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace API.TestFramework.Environment
{
    public static class Extensions
    {
        public static StringContent AsJson(this object o) => new StringContent(JsonConvert.SerializeObject(o), Encoding.UTF8, "application/json");
    }
}
