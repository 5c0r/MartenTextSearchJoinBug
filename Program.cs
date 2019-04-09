using Marten;
using MartenTextJoinBug.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MartenTextJoinBug
{
    class Program
    {
        static void Main(string[] args)
        {
            var store = DocumentStore.For(storeOpts =>
            {
                storeOpts.Connection("host=localhost;port=5432;database=postgres;password=postgres;username=postgres");
                storeOpts.Schema.For<User>();
                storeOpts.Schema.For<Email>().FullTextIndex(x => x.Content);
            });

            store.Advanced.Clean.DeleteAllDocuments();

            var term = "content";
            var userDictionary = new Dictionary<Guid, User>();
            using (var session = store.OpenSession())
            {
                session.CreateEmailAndUser();

                var query = session.Query<Email>()
                    .Include(x => x.UserId, userDictionary)
                    //.Where(x => x.Content.PlainTextSearch(term)).ToList();
                    //.Where(x => x.Content.Search(term)).ToList();
                    .Where(x => x.Content.PhraseSearch(term)).ToList();

                query.ForEach(em => Console.WriteLine(em.Content));
            }

            Console.ReadLine();
        }
    }
}
