using Core.Models;
using Newtonsoft.Json;
using Persistence.Contract;
using System.IO;

namespace Persistence
{
    public class IdRepository : IIdCreator
    {
        public int CreateId()
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory())
                + "//netcoreapp3.1//JSONDataFiles//Id.json";
            string content = File.ReadAllText(path);
            var baseObject = JsonConvert.DeserializeObject<BaseClass>(content);
            baseObject.Id = baseObject.Id + 1;
            File.WriteAllText(path, JsonConvert.SerializeObject(baseObject));
            return baseObject.Id;
        }
    }
}
