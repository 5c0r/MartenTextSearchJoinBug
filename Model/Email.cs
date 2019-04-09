using System;

namespace MartenTextJoinBug.Model
{
    public sealed class Email
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Content { get; set; }

        public Email(Guid id, Guid userId, string content)
        {
            Id = id;
            UserId = userId;
            Content = content;
        }
    }
}
