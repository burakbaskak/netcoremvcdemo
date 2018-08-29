using System;

namespace Data.Base{
    public class BaseEntity: IBaseEntity {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
    }
}