using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace DesignPatterns.Factory
{
    internal class Authentication
    {
        public Authentication(bool persistSecurityInfo, bool integratedSecurity, string userId, string password, bool encrypt)
        {
            PersistSecurityInfo = persistSecurityInfo;
            IntegratedSecurity = integratedSecurity;
            UserId = userId;
            Password = password;
            Encrypt = encrypt;
        }

        public Authentication(string userId, string password) : this(false, false, userId, password, false)
        {
        }

        public Authentication(string userId, string password, bool encrypt) : this(false, false, userId, password, encrypt)
        {
        }

        public Authentication() : this(false, true, string.Empty, string.Empty, false)
        {
        }

        public Authentication(bool encrypt) : this(false, true, string.Empty, string.Empty, encrypt)
        {
        }

        public bool PersistSecurityInfo { get; }
        public bool IntegratedSecurity { get; }
        public string UserId { get; }
        public string Password { get; }
        public bool Encrypt { get; }

        public override string ToString()
        {
            return IntegratedSecurity 
                ? $@"Persist Security Info={PersistSecurityInfo}; Integrated Security=True; Encrypt={Encrypt}"
                : $@"Persist Security Info={PersistSecurityInfo}; Integrated Security=False; Encrypt={Encrypt}; User ID={UserId}; Password={Password}";
        }
    }

    internal class AbstractFactory
    {
        public DbProviderFactory Provider { get; }
        public string DataSource { get; }
        public string InitialCatalog { get; }
        public Authentication Authentication { get; }
        public string ApplicationName { get; }
        public short ConnectTimeout { get; }
        public short PacketSize { get; }
        public string WorkstationId { get; }
        public string ConnectionString { get; private set; }

        public AbstractFactory(DbProviderFactory providerFactory, string dataSource, string initialCatalog, Authentication authentication, string applicationName, 
            string workstationId = null, short connectTimeout = 15, short packetSize = 8192)
        {
            Provider = providerFactory;
            DataSource = dataSource;
            InitialCatalog = initialCatalog;
            Authentication = authentication;
            ApplicationName = applicationName;
            ConnectTimeout = connectTimeout;
            if (ConnectTimeout < 15)
                ConnectTimeout = 15;
            PacketSize = packetSize;
            if (PacketSize < 512)
                PacketSize = 512;
            WorkstationId = workstationId;
            SetConnectionString();
        }

        private void SetConnectionString()
        {
            var workstation = !string.IsNullOrEmpty(WorkstationId) ? $@"Workstation ID={WorkstationId}" : $@"Workstation ID={System.Net.Dns.GetHostName()}";

            switch (Provider)
            {
                case OdbcFactory _:
                    ConnectionString = $@"Provider=SQLODBC; Driver={{Microsoft Access Driver (*.mdb)}}; DBQ=yourdatabasename.mdb; Application Name={ApplicationName}; Data Source={DataSource}; Initial Catalog={InitialCatalog};{Authentication}; Connect Timeout={ConnectTimeout}; Packet Size={PacketSize}; {workstation};";
                    break;
                case OleDbFactory _:
                    ConnectionString = $@"Provider=SQLOLEDB; Application Name={ApplicationName}; Data Source={DataSource}; Initial Catalog={InitialCatalog};{Authentication}; Connect Timeout={ConnectTimeout}; Packet Size={PacketSize}; {workstation};";
                    break;
                case SqlClientFactory _:
                    ConnectionString = $@"Application Name={ApplicationName}; Data Source={DataSource}; Initial Catalog={InitialCatalog};{Authentication}; Connect Timeout={ConnectTimeout}; Packet Size={PacketSize}; {workstation};";
                    break;
            }
            Console.WriteLine($@"ConnectionString=""{ConnectionString}""");
        }

        private void SetParameters(DbCommand cmd, Collection<(string name, object value)> parameters)
        {
            switch (Provider)
            {
                case OdbcFactory _:
                    foreach (var parameter in parameters)
                    {
                        cmd.Parameters.Add(new OdbcParameter(parameter.name, parameter.value));
                    }
                    break;
                case OleDbFactory _:
                    foreach (var parameter in parameters)
                    {
                        cmd.Parameters.Add(new OleDbParameter(parameter.name, parameter.value));
                    }
                    break;
                case SqlClientFactory _:
                    foreach (var parameter in parameters)
                    {
                        cmd.Parameters.Add(new SqlParameter(parameter.name, parameter.value));
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(Provider));
            }
        }

        public Collection<Collection<object>> SelectData(string query, 
            Collection<(string name, object value)> parameters, Collection<string> fieldNames)
        {
            var result = new Collection<Collection<object>>();
            if (Provider != null && !string.IsNullOrEmpty(ConnectionString))
            {
                using var connection = Provider.CreateConnection();
                if (connection != null)
                {
                    connection.ConnectionString = ConnectionString;
                    connection.Open();
                        
                    using var cmd = Provider.CreateCommand();
                    if (cmd != null)
                    {
                        cmd.CommandText = query;
                        SetParameters(cmd, parameters);
                        cmd.Connection = connection;
                        if (cmd.Connection.State == ConnectionState.Open)
                        {
                            using var reader = cmd.ExecuteReader();
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var record = new Collection<object>();
                                    foreach (var field in fieldNames)
                                    {
                                        record.Add(reader.GetFieldValue<object>(reader.GetOrdinal(field)));
                                    }

                                    result.Add(record);
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Connection is not open.");
                        }
                    }

                    connection.Close();
                }
            }
            return result;
        }
    }
}
