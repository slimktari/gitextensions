namespace TalentsoftTools
{
    using System.Drawing;

    public class Generic
    {
        public enum GenrateSolutionArguments
        {
            Build = 0,
            Rebuild = 1
        }

        public static Color ColorBranchUpToDate = Color.LimeGreen;
        public static Color ColorBranchNeedUpdate = Color.Tomato;
        public static Color ColorBranchObsolete = Color.Gray;
        public static Color ColorProcessTaskFailed = Color.Red;
        public static Color ColorProcessTaskSuccess = Color.LimeGreen;
        public static Color ColorProcessTaskInProgress = Color.DodgerBlue;
        public static Color ColorProcessTaskWarning = Color.Gold;

        public const string PluginName = "Talentsoft Tools";
        public const int DefaultValueCheckMonitoInterval = 60;
        public const int DisableValueCheckMonitoInterval = 0;
        public const string DefaultDatabaseServer = ".";
        public const string DefaultDatabaseUserName = "ASPNET";
        public const string DefaultGitCleanExcludePattern = "*.mdf *.ldf";
        public const string DefaultSolutionFileName = "TalentSoft.sln";
        public const string DefaultDatabasePassword = "aspasp";
        public const string DefaultDatabaseRelocateFilePath = @"C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\";
        public const string DefaultDatabaseRelocateLogFilePath = @"C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\";
    }
}
