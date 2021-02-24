namespace EntityFrameworkCore
{
    public class CategoryEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public Status Status { get; set; }
        public bool Active { get; set; }
    }

    public enum Status
    {
        Active,
        InActive
    }

    // Entity properties
    //https://docs.microsoft.com/en-us/ef/core/modeling/entity-properties?tabs=data-annotations%2Cwithout-nrt

    //Primary Key
    //[Key]
    //.HasKey(c => c.Property)

    //Included and excluded properties
    //[NotMapped]
    //.Ignore(x => x.Property)

    //Column names
    //[Column("columnname_in_database")]
    //.HasColumnName("columnname_in_database")

    //Column data types
    //[Column(TypeName = "varchar(200)")]
    //[Column(TypeName = "decimal(5, 2)")]
    //.HasColumnType("varchar(200)")
    //.HasColumnType("decimal(5, 2)")

    //Maximum length
    //[MaxLength(500)]
    //.HasMaxLength(500)

    //Required and optional properties
    //[Required] 
    //.IsRequired()

    //Column comments
    //[Comment("Description of the column")]
    //.HasComment("Description of the column")
}
