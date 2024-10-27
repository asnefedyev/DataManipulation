using ru.ex1.ex2.commonsolutions;
using System.Data;

namespace Examples
{
    public class Truncate
    {
        public void JustTruncate()
        {
            using (IDbConnection conn = default)
            {
                new ManipulationDataSet(conn, true)
                    .Table("public", "student")
                    .Truncate();
            }
        }

        public void JustTruncateWithOutSchema()
        {
            using (IDbConnection conn = default)
            {
                new ManipulationDataSet(conn, true)
                    .Table("student")
                    .Truncate();
            }
        }

        public void JustTruncateWithOutSchemaToOwnerParameter()
        {
            using (IDbConnection conn = default)
            {
                new ManipulationDataSet(conn, true)
                    .Table("public.student")
                    .Truncate();
            }
        }
    }
}