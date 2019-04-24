using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCharging.Data.Entities
{
    public class TestCaseCheckpoint
    {
        [Key]
        public string CheckpointId { get; set; }

        public string TestCaseResultId { get; set; }

        public string CaseCode { get; set; }

        public bool? Pass { get; set; }

        public int Index { get; set; }

        public string Content { get; set; }
        public string Requirement { get; set; }

        public string Data { get; set; }
    }
}
