﻿using Newtonsoft.Json;

namespace OSKI_Test.Models
{
    public static class ObjectCopier
    {
        public static T CloneJson<T>(this T source)
        {
            if (ReferenceEquals(source, null))
                return default;

            var deserializeSettings = new JsonSerializerSettings { ObjectCreationHandling = ObjectCreationHandling.Replace };

            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(source), deserializeSettings);
        }
    }
}
