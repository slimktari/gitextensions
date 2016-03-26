﻿using System.Collections.Generic;

namespace TalentsoftTools.Helpers
{
    using System;
    using Microsoft.SqlServer.Management.Common;
    using Microsoft.SqlServer.Management.Smo;

    /// <summary>
    /// Helper for manage databases.
    /// </summary>
    public class DatabaseHelper
    {
        /// <summary>
        /// Restores database.
        /// </summary>
        /// <param name="databaseName">Database name.</param>
        /// <param name="filePath">Backup database file to restore.</param>
        /// <param name="serverName">Database server.</param>
        /// <param name="userName">User name to server connect.</param>
        /// <param name="password">Password to server connect.</param>
        /// <param name="dataFilePath">Path to relocate database file.</param>
        /// <param name="logFilePath">Path to relocate database log file.</param>
        /// <returns></returns>
        public static bool RestoreDatabase(String databaseName, String filePath, String serverName, String userName, String password, String dataFilePath, String logFilePath)
        {
            if (string.IsNullOrWhiteSpace(databaseName) || string.IsNullOrWhiteSpace(filePath))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(serverName))
            {
                serverName = ".";
            }
            if (string.IsNullOrWhiteSpace(userName))
            {
                userName = Generic.DefaultDatabaseUserName;
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                password = Generic.DefaultDatabasePassword;
            }
            if (string.IsNullOrWhiteSpace(dataFilePath))
            {
                dataFilePath = Generic.DefaultDatabaseRelocateFilePath;
            }
            if (string.IsNullOrWhiteSpace(logFilePath))
            {
                logFilePath = Generic.DefaultDatabaseRelocateLogFilePath;
            }
            Restore sqlRestore = new Restore();

            BackupDeviceItem deviceItem = new BackupDeviceItem(filePath, DeviceType.File);
            sqlRestore.Devices.Add(deviceItem);
            sqlRestore.Database = databaseName;

            ServerConnection connection = new ServerConnection(serverName, userName, password);
            Server sqlServer = new Server(connection);

            Database db = sqlServer.Databases[databaseName];
            sqlRestore.Action = RestoreActionType.Database;
            String dataFileLocation = dataFilePath + databaseName + "_0.mdf";
            String logFileLocation = logFilePath + databaseName + "_1.ldf";
            db = sqlServer.Databases[databaseName];
            if (db != null)
            {
                sqlServer.KillAllProcesses(db.Name);
            }
            RelocateFile rf = new RelocateFile(databaseName, dataFileLocation);

            var logicalRestoreFiles = sqlRestore.ReadFileList(sqlServer);
            sqlRestore.RelocateFiles.Add(new RelocateFile(logicalRestoreFiles.Rows[0][0].ToString(), dataFileLocation));
            sqlRestore.RelocateFiles.Add(new RelocateFile(logicalRestoreFiles.Rows[1][0].ToString(), logFileLocation));

            sqlRestore.ReplaceDatabase = true;
            try
            {
                sqlRestore.SqlRestore(sqlServer);
                db = sqlServer.Databases[databaseName];
                db.SetOnline();
                sqlServer.Refresh();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Backup database.
        /// </summary>
        /// <param name="databaseName">Database name.</param>
        /// <param name="userName">User name to server connect.</param>
        /// <param name="password">Password to server connect.</param>
        /// <param name="serverName">Server name.</param>
        /// <param name="destinationPath">Destination path.</param>
        public void BackupDatabase(String databaseName, String userName, String password, String serverName, String destinationPath)
        {
            Backup sqlBackup = new Backup();

            sqlBackup.Action = BackupActionType.Database;
            sqlBackup.BackupSetDescription = "ArchiveDataBase:" + DateTime.Now.ToShortDateString();
            sqlBackup.BackupSetName = "Archive";
            sqlBackup.Database = databaseName;

            BackupDeviceItem deviceItem = new BackupDeviceItem(destinationPath, DeviceType.File);
            ServerConnection connection = new ServerConnection(serverName, userName, password);
            Server sqlServer = new Server(connection);

            Database db = sqlServer.Databases[databaseName];

            sqlBackup.Initialize = true;
            sqlBackup.Checksum = true;
            sqlBackup.ContinueAfterError = true;

            sqlBackup.Devices.Add(deviceItem);
            sqlBackup.Incremental = false;

            sqlBackup.ExpirationDate = DateTime.Now.AddDays(3);
            sqlBackup.LogTruncation = BackupTruncateLogType.Truncate;

            sqlBackup.FormatMedia = false;

            sqlBackup.SqlBackup(sqlServer);
        }

        /// <summary>
        /// Gets databases from settings.
        /// </summary>
        /// <param name="parameters">Settings parameters.</param>
        /// <param name="databases">Settings databases.</param>
        /// <returns>List of <see cref="DatabaseDto"/>.</returns>
        public static List<DatabaseDto> GetDatabasesFromPameters(string parameters, string databases)
        {
            if (string.IsNullOrWhiteSpace(parameters) || string.IsNullOrWhiteSpace(databases))
            {
                return new List<DatabaseDto>();
            }
            var databasesTab = databases.Split(';');
            var results = new List<DatabaseDto>();
            string userId = string.Empty;
            string password = string.Empty;
            string relocateDataFilePath = string.Empty;
            string dataSource = string.Empty;

            DatabaseDto databaseDto = null;
            foreach (var database in databasesTab)
            {
                if (!string.IsNullOrWhiteSpace(database) && database.Contains("="))
                {
                    string[] dict = database.Split('=');
                    if (dict.Length == 2)
                    {
                        switch (dict[0])
                        {
                            case "Initial Catalog":
                                databaseDto = new DatabaseDto
                                {
                                    DatabaseName = dict[1]
                                };
                                break;
                            case "BackupFilePath":
                                if (databaseDto != null && !string.IsNullOrWhiteSpace(databaseDto.DatabaseName))
                                {
                                    databaseDto.BackupFilePath = dict[1];
                                    results.Add(databaseDto);
                                }
                                break;
                        }
                    }
                }
            }
            foreach (var param in parameters.Split(';'))
            {
                if (!string.IsNullOrWhiteSpace(param) && param.Contains("="))
                {
                    string[] dict = param.Split('=');
                    if (dict.Length == 2)
                    {
                        switch (dict[0])
                        {
                            case "User ID":
                                userId = dict[1];
                                break;
                            case "Password":
                                password = dict[1];
                                break;
                            case "RelocateDataFilePath":
                                relocateDataFilePath = dict[1];
                                break;
                            case "Data Source":
                                dataSource = dict[1];
                                break;
                        }
                    }
                }
            }

            foreach (var result in results)
            {
                result.Password = password;
                result.PathToRelocate = relocateDataFilePath;
                result.ServerName = dataSource;
                result.UserId = userId;
            }
            return results;
        }
    }
}
