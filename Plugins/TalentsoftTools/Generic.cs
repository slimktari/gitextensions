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

        public enum VisualStudioVersion
        {
            Previous,
            Vs2003,
            Vs2005,
            Vs2008,
            Vs2010,
            Vs2013,
            Vs2015,
            VsNext
        }

        public const string PathToVsLauncher = "C:\\Program Files (x86)\\Common Files\\Microsoft Shared\\MSEnv\\VSLauncher.exe";
        
        public const string PathToVisualStudio8 = @"C:\Program Files (x86)\MSBuild\8.0\Bin\MSBuild.exe";
        public const string PathToVisualStudio9 = @"C:\Program Files (x86)\MSBuild\9.0\Bin\MSBuild.exe";
        public const string PathToVisualStudio10 = @"C:\Program Files (x86)\MSBuild\10.0\Bin\MSBuild.exe";
        public const string PathToVisualStudio11 = @"C:\Program Files (x86)\MSBuild\11.0\Bin\MSBuild.exe";
        public const string PathToVisualStudio12 = @"C:\Program Files (x86)\MSBuild\12.0\Bin\MSBuild.exe";
        public const string PathToVisualStudio14 = @"C:\Program Files (x86)\MSBuild\14.0\Bin\MSBuild.exe";

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
        public const string DefaultGitCleanExcludePattern = "*.mdf *.ldf";
        public const string DefaultSolutionFileName = "TalentSoft.sln";
        public const string DefaultDatabaseRelocateFilePath = @"C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\";
        public const string DefaultDatabaseRelocateLogFilePath = @"C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\";
    }
}
