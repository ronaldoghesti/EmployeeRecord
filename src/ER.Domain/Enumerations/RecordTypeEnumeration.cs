namespace ER.Domain.Enumerations
{
    public class RecordTypeEnumeration : Enumeration
    {
        public static readonly RecordTypeEnumeration Input = new RecordTypeEnumeration(1, "Entrada");
        public static readonly RecordTypeEnumeration Output = new RecordTypeEnumeration(2, "Saída");

        public RecordTypeEnumeration(int id, string name)
            : base(id, name)
        {
        }
    }
}
