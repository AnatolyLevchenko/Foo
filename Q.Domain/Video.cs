using System;

namespace Q.Domain
{
    public class Video : BaseEntity
    {
        public string Name { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }
        public int CategoryId { get; set; }
    }
}
