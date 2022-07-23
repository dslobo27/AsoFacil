using System.Collections.Generic;

namespace AsoFacil.Models
{
    public class TaskResult
    {
        public bool IsSuccess { get
            {
                return Errors == null;
            } 
        }

        public object Data { get; set; }
        public List<string> Errors { get; private set; } = new List<string>();
    }
}