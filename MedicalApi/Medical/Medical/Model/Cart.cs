using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Medical.Model
{
    public class Cart
    {
        [Key]
        public int cartuniid { get; set; }
        public int Medid { get; set; }
        public string Mediname { get; set; }
        public int MediTypeid { get; set; }
        public string MediTypename { get; set; }
        public int amount { get; set; }
        public int quantity { get; set; }
        public string image { get; set; }
        public int userid { get; set; }
        public string username { get; set; }
    }
}
