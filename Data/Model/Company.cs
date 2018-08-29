using System;
using Data.Base;

namespace Data.Model{
    public class Company : BaseEntity {
        public string Name { get; set; }
        public string Address { get; set; }
    }
}