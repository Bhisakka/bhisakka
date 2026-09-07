using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bhisakka.Models
{
    internal class AudioLogs
    {
        public int audioLogId { get; set; }
        public int consultationId { get; set; }
        public string filePath { get; set; }
        public DateTime startedAt { get; set; }
        public int durationSeconds { get; set; }


    }
}
