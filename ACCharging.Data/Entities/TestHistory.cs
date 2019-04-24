using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCharging.Data.Entities
{
    public class TestHistory
    {
        [Key]
        public string HistoryId { get; set; }

        public string TaskName { get; set; }

        public string TaskRemark { get; set; }
        public string Configuration { get; set; }

        public string User { get; set; }
        public DateTime LastModifiedTime { get; set; }
        public ICollection<TestCaseResult> TestResults { get; set; }
    }
}
