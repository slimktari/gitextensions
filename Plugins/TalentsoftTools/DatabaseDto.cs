using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentsoftTools
{
    public class DatabaseDto
    {
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public string BackupFilePath { get; set; }
        public string PathToRelocate { get; set; }
    }
}
