using System.Collections.Generic;
using System.Linq;

namespace AsoFacil.Models
{
    public class TaskResult
    {
        public bool IsSuccess { get
            {
                return !Errors.Any();
            } 
        }

        public object Data { get; set; }
        public List<string> Errors { get; private set; } = new List<string>();
    }
}