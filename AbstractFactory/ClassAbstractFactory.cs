using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    public class ClassAbstractFactory
    {
        private readonly DbProviderFactory _factory;

        public ClassAbstractFactory(DbProviderFactory factory)
        {
            _factory = factory;
        }

        public void Save(IEnumerable<ClassAbstractEntry> abstractEntries)
        {
            using (var connection = _factory.CreateConnection())
            {
                SetConnectionsString(connection);
                using (var command = _factory.CreateCommand())
                {
                    SetCommandArguments(abstractEntries);
                }
            }
        }

        private void SetConnectionsString(DbConnection connection) {}

        private void SetCommandArguments(IEnumerable<ClassAbstractEntry> abstractEntries) { }
    }
}
