using PetaPoco;

namespace UnitOfWork.Models
{
    [PrimaryKey("Id")]
    [TableName("MyOtherDbEntities")]
    public class MyOtherDbEntity
    {
        public long Id { get; set; }
        public string PhoneNumber { get; set; }
    }
}
