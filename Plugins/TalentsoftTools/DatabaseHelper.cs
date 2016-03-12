using System;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

namespace TalentsoftTools
{
    public class DatabaseHelper
    {
        public static bool RestoreDatabase(String databaseName, String filePath, String serverName, String userName, String password,
       String dataFilePath, String logFilePath)
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
                userName = "ASPNET";
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                password = "aspasp";
            }
            if (string.IsNullOrWhiteSpace(dataFilePath))
            {
                dataFilePath = @"C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\";
            }
            if (string.IsNullOrWhiteSpace(logFilePath))
            {
                logFilePath = @"C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\";
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

        public void BackupDatabase(String databaseName, String userName,
            String password, String serverName, String destinationPath)
        {
            Backup sqlBackup = new Backup();

            sqlBackup.Action = BackupActionType.Database;
            sqlBackup.BackupSetDescription = "ArchiveDataBase:" +
                                             DateTime.Now.ToShortDateString();
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
    }
}
