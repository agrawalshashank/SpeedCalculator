using Core.Models;
using Newtonsoft.Json;
using Persistence.Contract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Persistence
{
    public class RepositoryBaseJSON<T> : IRepository<T> where T : BaseClass
    {     

        public void DeleteByClass<T>()
        {
            EmptyFile<T>();
        }

        public ICollection<T> GetAll()
        {
            string content = ReadFile<T>();
            return JsonConvert.DeserializeObject<ICollection<T>>(content);
        }

        public T GetById(int Id)
        {
            var data = GetAll();
            return data.FirstOrDefault(x => x.Id == Id);
        }

        public void Save(T entity)
        {
            var content = GetAll();
            content.Add(entity);
            WriteFile<T>(JsonConvert.SerializeObject(content));
        }

        public void Update(T entity)
        {
            var content = GetAll();
            var existingRecord = content.FirstOrDefault(x => x.Id == entity.Id);
            content.Remove(existingRecord);
            content.Add(entity);
            WriteFile<T>(JsonConvert.SerializeObject(content));
        }

        private string GetFileNameByType<T>()
        {
            if (typeof(T) == typeof(Driver))
            {
                return "Driver.json";
            }
            else if (typeof(T) == typeof(Trip))
            {
                return "Trip.json";
            }

            return string.Empty;
        }

        private string GetFilePath(string fileName)
        {
            return Directory.GetParent(System.IO.Directory.GetCurrentDirectory()) + "//netcoreapp3.1//JSONDataFiles//" + fileName;
        }

        private string ReadFile<T>()
        {
            var fileName = GetFileNameByType<T>();
            if (!string.IsNullOrEmpty(fileName))
            {
                return File.ReadAllText(GetFilePath(fileName));
            }

            return string.Empty;
        }

        private void WriteFile<T>(string content)
        {
            var fileName = GetFileNameByType<T>();
            if (!string.IsNullOrEmpty(fileName))
            {
                File.WriteAllText(GetFilePath(fileName), content);
            }
        }

        private void EmptyFile<T>()
        {
            var fileName = GetFileNameByType<T>();
            if (!string.IsNullOrEmpty(fileName))
            {
                File.WriteAllText(GetFilePath(fileName), string.Empty);
            }
        }
    }
}
