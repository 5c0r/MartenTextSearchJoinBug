using System;
using System.Collections.Generic;
using System.Text;

namespace MartenTextJoinBug.Model
{
    public sealed class User
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public User(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
