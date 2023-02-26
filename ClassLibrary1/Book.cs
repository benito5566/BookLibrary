using System;

namespace Domain
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Editorial { get; set; }
        public BookStatus Status { get; set; }

        public Book(string name, string editorial)
        {
            Id = Guid.NewGuid();
            Name = name;
            Editorial = editorial;
            Status = BookStatus.Available;
        }
    }
}
