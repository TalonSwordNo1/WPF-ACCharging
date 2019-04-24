using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCharging.Data.Entities
{
    public class TestCaseResult
    {
        [Key]
        public string ResultId { get; set; }

        public string HistoryId { get; set; }

        public string CaseCode { get; set; }


        public bool? Passed { get; set; }


        public string Data { get; set; }
        public string LogFile { get; set; }
        public string ImageFile { get; set; }

        public ICollection<TestCaseCheckpoint> Checkpoints { get; set; }
    }
}
