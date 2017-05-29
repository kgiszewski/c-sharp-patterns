using PetaPoco;

namespace UnitOfWork.Models
{
    [TableName("MyDbEntities")]
    [PrimaryKey("Id")]
    public class MyDbEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
