using Marten;
using MartenTextJoinBug.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MartenTextJoinBug
{
    public static class SessionExtension
    {
        public static void CreateEmailAndUser(this IDocumentSession session)
        {
            for( var i = 0; i < 3; i++)
            {
                var newUser = new User(Guid.NewGuid(), $"Test user {i}");
                var newEmail = new Email(Guid.NewGuid(), newUser.Id, $"Some content {i} {newUser.Name} ");

                session.Store(newUser);
                session.Store(newEmail);
            }

            session.SaveChanges();
        }
    }
}
