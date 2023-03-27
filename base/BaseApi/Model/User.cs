using System.ComponentModel.DataAnnotations;

namespace BaseApi.Model
{
    public class User
    {
        [Key]
        public long id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public int age { get; set; }
        public bool role { get; set; }
    }
}
