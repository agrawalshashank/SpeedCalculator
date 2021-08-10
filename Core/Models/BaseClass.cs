using System;

namespace Core.Models
{
    public class BaseClass
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public virtual bool Validate()
        {
            throw new System.Exception();
        }
    }
}
