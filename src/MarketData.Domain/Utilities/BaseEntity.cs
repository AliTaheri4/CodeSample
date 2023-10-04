using System;

namespace MarketData.Domain.Utilities
{
    public class BaseEntity<T>
    {
        public T Id { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string? CreatedName { get; set; }
        public DateTime? ModifiedTime{ get; set; }
        public string? ModifiedName{ get; set; }
    }
}
