using System.Drawing;

namespace TalentsoftTools
{
    public class Generic
    {
        public enum GenrateSolutionArguments
        {
            Build = 0,
            Rebuild = 1
        }

        public static Color ColorBranchUpToDate = Color.MediumSeaGreen;
        public static Color ColorBranchNeedUpdate = Color.Tomato;

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
