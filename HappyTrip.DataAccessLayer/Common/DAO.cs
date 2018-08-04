using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Configuration;

namespace HappyTrip.DataAccessLayer.Common
{
    /// <summary>
    /// Class that represents the common abstraction for all database related activities
    /// </summary>
    public abstract class DAO
    {
        #region Method to get database connection using Raw ADO.NET
        /// <summary>
        /// Gets the database connection for database. Inherited by all DAOs - ADO.NET Connection 
        /// </summary>
        /// <returns></returns>
        protected IDbConnection GetConnection()
        {
            string providerName = ConfigurationManager.ConnectionStrings["HappyTripConnectionString"].ProviderName;
            string connString = ConfigurationManager.ConnectionStrings["HappyTripConnectionString"].ConnectionString;
            DbConnection conn = DbProviderFactories.GetFactory(providerName).CreateConnection();
            conn.ConnectionString = connString;
            conn.Open();
            return conn;
        }
        #endregion

        #region Methods to create command object using Raw ADO.NET
        /// <summary>
        /// Creates a command object for a database connection with provided command text and command type.
        /// </summary>
        /// <returns></returns>
        protected IDbCommand CreateCommand(IDbConnection DbConnection, string CommandText)
        {
            return CreateCommand(DbConnection, CommandText, CommandType.Text);
        }
        protected IDbCommand CreateCommand(IDbConnection DbConnection, string CommandText, IDbTransaction DbTransaction)
        {
            return CreateCommand(DbConnection, CommandText, CommandType.Text, DbTransaction);
        }

        /// <summary>
        /// Creates a command object for a database connection with provided command text and command type.
        /// </summary>
        /// <returns></returns>
        protected IDbCommand CreateCommand(IDbConnection DbConnection, string CommandText, CommandType CommandType)
        {
            return CreateCommand(DbConnection, CommandText, CommandType, null);
        }
        protected IDbCommand CreateCommand(IDbConnection DbConnection, string CommandText, CommandType CommandType, IDbTransaction DbTransaction)
        {
            IDbCommand cmd = null;

            if (DbConnection.State != ConnectionState.Open)
            { DbConnection.Open(); }

            cmd = DbConnection.CreateCommand();
            if (DbTransaction != null)
            { cmd.Transaction = DbTransaction; }
            cmd.CommandText = CommandText;
            cmd.CommandType = CommandType;

            return cmd;
        }
        protected IDbCommand CreateCommandWithParameters(IDbConnection DbConnection, string CommandText, CommandType CommandType, params System.Data.IDataParameter[] Parameters)
        {
            IDbCommand cmd = CreateCommand(DbConnection, CommandText, CommandType, null);

            foreach (var param in Parameters)
            {
                cmd.Parameters.Add(param);
            }

            return cmd;
        }
        #endregion

        #region Methods to execute a storedprocedure/query using Raw ADO.NET
        /// <summary>
        /// Executes a storedprocedure with provided name and parameters.
        /// </summary>
        /// <returns></returns>
        protected int ExecuteStoredProcedure(string StoredProcedureName, params System.Data.IDataParameter[] Parameters)
        {
            using (IDbConnection Connection = GetConnection())
            {
                return ExecuteStoredProcedure(Connection, null, StoredProcedureName, Parameters);
            }
        }
        /// <summary>
        /// Executes a storedprocedure with provided name and parameters.
        /// </summary>
        /// <returns></returns>
        protected int ExecuteStoredProcedure(IDbConnection DbConnection, string StoredProcedureName, params System.Data.IDataParameter[] Parameters)
        {
            return ExecuteStoredProcedure(DbConnection, null, StoredProcedureName, Parameters);
        }
        /// <summary>
        /// Executes a storedprocedure with provided transaction, name and parameters.
        /// </summary>
        /// <returns></returns>
        protected int ExecuteStoredProcedure(IDbConnection DbConnection, IDbTransaction DbTransaction, string StoredProcedureName, params System.Data.IDataParameter[] Parameters)
        {
            IDbCommand cmd = null;

            cmd = DbConnection.CreateCommand();
            if (DbTransaction != null)
            { cmd.Transaction = DbTransaction; }
            cmd.CommandText = StoredProcedureName;
            cmd.CommandType = CommandType.StoredProcedure;

            foreach (var item in Parameters)
            { cmd.Parameters.Add(item); }

            return cmd.ExecuteNonQuery();
        }


        /// <summary>
        /// Executes a query.
        /// </summary>
        /// <returns></returns>
        protected int ExecuteQuery(string CommandText)
        {
            using (IDbConnection Connection = GetConnection())
            {
                return ExecuteQuery(Connection, null, CommandText);
            }
        }
        /// <summary>
        /// Executes a query.
        /// </summary>
        /// <returns></returns>
        protected int ExecuteQuery(IDbConnection DbConnection, string CommandText)
        {
            return ExecuteQuery(DbConnection, null, CommandText);
        }
        /// <summary>
        /// Executes a query under given transaction.
        /// </summary>
        /// <returns></returns>
        protected int ExecuteQuery(IDbConnection DbConnection, IDbTransaction DbTransaction, string CommandText)
        {
            IDbCommand cmd = null;

            cmd = DbConnection.CreateCommand();
            if (DbTransaction != null)
            { cmd.Transaction = DbTransaction; }
            cmd.CommandText = CommandText;
            cmd.CommandType = CommandType.Text;

            return cmd.ExecuteNonQuery();
        }


        /// <summary>
        /// Executes a storedprocedure with provided name and parameters and returns scalar value.
        /// </summary>
        /// <returns></returns>
        protected object ExecuteStoredProcedureScalar(string StoredProcedureName, params System.Data.IDataParameter[] Parameters)
        {
            using (IDbConnection Connection = GetConnection())
            {
                return ExecuteStoredProcedureScalar(Connection, null, StoredProcedureName, Parameters);
            }
        }
        /// <summary>
        /// Executes a storedprocedure with provided name and parameters and returns scalar value.
        /// </summary>
        /// <returns></returns>
        protected object ExecuteStoredProcedureScalar(IDbConnection DbConnection, string StoredProcedureName, params System.Data.IDataParameter[] Parameters)
        {
            return ExecuteStoredProcedureScalar(DbConnection, null, StoredProcedureName, Parameters);
        }
        /// <summary>
        /// Executes a storedprocedure with provided transaction, name and parameters, and returns scalar value.
        /// </summary>
        /// <returns></returns>
        protected object ExecuteStoredProcedureScalar(IDbConnection DbConnection, IDbTransaction DbTransaction, string StoredProcedureName, params System.Data.IDataParameter[] Parameters)
        {
            IDbCommand cmd = null;

            cmd = DbConnection.CreateCommand();
            if (DbTransaction != null)
            { cmd.Transaction = DbTransaction; }
            cmd.CommandText = StoredProcedureName;
            cmd.CommandType = CommandType.StoredProcedure;

            foreach (var item in Parameters)
            { cmd.Parameters.Add(item); }

            return cmd.ExecuteScalar();
        }


        /// <summary>
        /// Executes a query and returns a single value.
        /// </summary>
        /// <returns></returns>
        protected object ExecuteQueryScalar(string CommandText)
        {
            using (IDbConnection Connection = GetConnection())
            {
                return ExecuteQueryScalar(Connection, null, CommandText);
            }
        }
        /// <summary>
        /// Executes a query and returns a single value.
        /// </summary>
        /// <returns></returns>
        protected object ExecuteQueryScalar(IDbConnection DbConnection, string CommandText)
        {
            return ExecuteQueryScalar(DbConnection, null, CommandText);
        }
        /// <summary>
        /// Executes a query under given transaction and returns a single value.
        /// </summary>
        /// <returns></returns>
        protected object ExecuteQueryScalar(IDbConnection DbConnection, IDbTransaction DbTransaction, string CommandText)
        {
            IDbCommand cmd = null;

            cmd = DbConnection.CreateCommand();
            if (DbTransaction != null)
            { cmd.Transaction = DbTransaction; }
            cmd.CommandText = CommandText;
            cmd.CommandType = CommandType.Text;

            return cmd.ExecuteScalar();
        }


        /// <summary>
        /// Executes a storedprocedure with provided name and parameters and returns the results.
        /// </summary>
        /// <returns></returns>
        protected IDataReader ExecuteStoredProcedureResults(IDbConnection DbConnection, string StoredProcedureName, params System.Data.IDataParameter[] Parameters)
        {
            IDbCommand cmd = null;

            cmd = DbConnection.CreateCommand();
            cmd.CommandText = StoredProcedureName;
            cmd.CommandType = CommandType.StoredProcedure;

            foreach (var item in Parameters)
            { cmd.Parameters.Add(item); }

            return cmd.ExecuteReader();
        }
        /// <summary>
        /// Executes a storedprocedure with provided name and returns the results.
        /// </summary>
        /// <returns></returns>
        protected IDataReader ExecuteStoredProcedureResults(IDbConnection DbConnection, string StoredProcedureName)
        {
            return ExecuteQueryResults(DbConnection, StoredProcedureName, CommandType.StoredProcedure);
        }


        /// <summary>
        /// Executes a query and returns the results.
        /// </summary>
        /// <returns></returns>
        protected IDataReader ExecuteQueryResults(IDbConnection DbConnection, string CommandText)
        {
            return ExecuteQueryResults(DbConnection, CommandText, CommandType.Text);
        }
        /// <summary>
        /// Executes a storedprocedure/query and returns the results.
        /// </summary>
        /// <returns></returns>
        private IDataReader ExecuteQueryResults(IDbConnection DbConnection, string CommandText, CommandType CmdType)
        {
            IDbCommand cmd = null;

            cmd = DbConnection.CreateCommand();
            cmd.CommandText = CommandText;
            cmd.CommandType = CmdType;

            return cmd.ExecuteReader();
        }


        /// <summary>
        /// Executes a storedprocedure with provided name and returns the results in dataset.
        /// </summary>
        /// <returns></returns>
        protected DataSet ExecuteStoredProcedureDataSet(string StoredProcedureName)
        {
            using (IDbConnection Connection = GetConnection())
            {
                return ExecuteStoredProcedureDataSet(Connection, StoredProcedureName, null);
            }
        }
        /// <summary>
        /// Executes a storedprocedure with provided name and returns the results in dataset.
        /// </summary>
        /// <returns></returns>
        protected DataSet ExecuteStoredProcedureDataSet(IDbConnection DbConnection, string StoredProcedureName)
        {
            return ExecuteStoredProcedureDataSet(DbConnection, StoredProcedureName, null);
        }
        /// <summary>
        /// Executes a storedprocedure with provided name and parameters and returns the results in dataset.
        /// </summary>
        /// <returns></returns>
        protected DataSet ExecuteStoredProcedureDataSet(IDbConnection DbConnection, string StoredProcedureName, params System.Data.IDataParameter[] Parameters)
        {
            IDbCommand cmd = null;
            cmd = DbConnection.CreateCommand();
            cmd.CommandText = StoredProcedureName;
            cmd.CommandType = CommandType.StoredProcedure;

            if (Parameters != null)
            {
                foreach (var item in Parameters)
                { cmd.Parameters.Add(item); }
            }

            DataSet dataSet = new DataSet();
            IDbDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            dataAdapter.Fill(dataSet);

            return dataSet;
        }

        /// <summary>
        /// Executes a query and returns the results in dataset.
        /// </summary>
        /// <returns></returns>
        protected DataSet ExecuteQueryDataSet(string SqlQuery)
        {
            using (IDbConnection Connection = GetConnection())
            {
                return ExecuteQueryDataSet(Connection, SqlQuery, null);
            }
        }
        /// <summary>
        /// Executes a query and returns the results in dataset.
        /// </summary>
        /// <returns></returns>
        protected DataSet ExecuteQueryDataSet(IDbConnection DbConnection, string SqlQuery)
        {
            return ExecuteQueryDataSet(DbConnection, SqlQuery, null);
        }
        /// <summary>
        /// Executes a query with parameters and returns the results in dataset.
        /// </summary>
        /// <returns></returns>
        protected DataSet ExecuteQueryDataSet(IDbConnection DbConnection, string SqlQuery, params System.Data.IDataParameter[] Parameters)
        {
            IDbCommand cmd = null;
            cmd = DbConnection.CreateCommand();
            cmd.CommandText = SqlQuery;
            cmd.CommandType = CommandType.Text;

            if (Parameters != null)
            {
                foreach (var item in Parameters)
                { cmd.Parameters.Add(item); }
            }

            DataSet dataSet = new DataSet();
            IDbDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            dataAdapter.Fill(dataSet);

            return dataSet;
        }
        #endregion

        #region Helper Methods
        /// <summary>
        /// Rollback transaction.
        /// </summary>
        /// <returns></returns>
        protected void RollbackTransaction(IDbTransaction Transaction)
        {
            if ((Transaction != null) && (Transaction.Connection != null))
            {
                Transaction.Rollback();
            }
        }

        /// <summary>
        /// Rollback transaction and close connection.
        /// </summary>
        /// <returns></returns>
        protected void RollbackTransactionAndCloseConnection(IDbTransaction Transaction)
        {
            if ((Transaction != null) && (Transaction.Connection != null))
            {
                Transaction.Rollback();
                if (Transaction.Connection.State != ConnectionState.Closed)
                { Transaction.Connection.Close(); }
            }
        }
        #endregion
    }
}
