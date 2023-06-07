using System.Text.Json;
using System.Text;

namespace ChatGPTApi.Models
{
    public class DiseaseListModel
    {
        public int Age { get; set; } 
        public bool HasChildren { get; set; }
        public string? HasChildrenString { get; set; }
        public string? TypeOfWork { get; set; }
        public string? Description { get; set; }

        public string? Gender { get; set; }
    }
}
