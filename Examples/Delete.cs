using ru.ex1.ex2.commonsolutions;
using System.Data;

namespace Examples
{
    public class Delete
    {
        public void JustDelete()
        {
            IDbConnection conn = default;
            using (var student = new ManipulationDataSet(conn))
            {
                student.Table("public", "student")
                    .WithKeys("studentUid", DbType.Decimal).Set(-1)
                .Delete()
                .ClearMetaData()
                .Table("public", "student")
                    .WithKeys("studentId").Set("123456789")
                    .WithKeys("studentUid", DbType.Decimal).Set(-2)
                .Delete();
            }
        }
    }
}
