using BusinessEntities;
using Common;
using Raven.Client.Documents.Indexes;
using Raven.Client.Documents.Operations;
using Raven.Client.Documents.Queries;
using Raven.Client.Documents.Session;
using System;

namespace Data.Repositories
{
    [AutoRegister]
    public class Repository<T> : IRepository<T> where T : IdObject
    {
        private readonly IDocumentSession _documentSession;

        public Repository(IDocumentSession documentSession)
        {
            _documentSession = documentSession;
        }

        public void Save(T entity)
        {
            _documentSession.Store(entity);
        }

        public void Delete(T entity)
        {
            _documentSession.Delete(entity);
        }

        public T Get(Guid id)
        {
            return _documentSession.Load<T>(id.ToString());
        }

        protected void DeleteAll<TIndex>() where TIndex : AbstractIndexCreationTask<T>
        {
            //_documentSession.Advanced.DocumentStore.DatabaseCommands.DeleteByIndex(typeof(TIndex).Name, new IndexQuery());

            var indexName = typeof(TIndex).Name;

            // Create a query to match all documents
            var query = new IndexQuery { Query = $"FROM INDEX '{indexName}'" };

            // Use the Operations API to delete documents by query
            var operation = _documentSession.Advanced.DocumentStore.Operations.Send(new DeleteByQueryOperation(query));

            // Wait for the operation to complete
            operation.WaitForCompletion();
        }
    }
}