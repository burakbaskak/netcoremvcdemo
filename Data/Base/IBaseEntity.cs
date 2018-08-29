using System;

namespace Data.Base{
    public interface IBaseEntity {
        int Id { get; set; }
        bool IsDeleted { get; set; }
        DateTime CreatedDate { get; set; }
        int CreatedBy { get; set; }
    }
}