﻿

namespace BookHive.Application.DTOs
{
    public class PublisherDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public bool Status { get; set; }
        public int BookCount {  get; set; }
    }
}
