using System.Data;
using ru.ex1.ex2.commonsolutions;

namespace Examples
{
    public class Insert
    {
        public void InsertWithoutTransaction() 
        {
            using (IDbConnection conn = default)
            {
                new ManipulationDataSet(conn, true)
                    .Table("public", "student")
                        .Column("last_name").Set("Иванов")
                        .Column("first_name").Set("Иван")
                        .Column("second_name").Set("Иванович")
                        .Column("studentId").Set("99999999999")
                        .Column("studentUid", DbType.Decimal).Set(123456789)
                    .Insert();
            }
        }

        public void InsertWithTransaction()
        {
            using (IDbConnection conn = default)
            {
                new ManipulationDataSet(conn, true)
                    .Table("public", "student")
                        .Column("last_name").Set("Иванов")
                        .Column("first_name").Set("Иван")
                        .Column("second_name").Set("Иванович")
                        .Column("studentId").Set("99999999999")
                        .Column("studentUid", DbType.Decimal).Set(123456789)
                    .WithTransaction(System.Transactions.IsolationLevel.ReadCommitted, 10, System.Transactions.TransactionScopeOption.Required)
                    .Insert();
            }
        }

        public void InsertWithGettingId()
        {
            using (IDbConnection conn = default)
            {
                new ManipulationDataSet(conn, true)
                    .Table("public", "student")
                        .Column("last_name").Set("Иванов")
                        .Column("first_name").Set("Иван")
                        .Column("second_name").Set("Иванович")
                        .Column("studentId", DbType.String).Set("99999999999")
                        .Column("studentUid", DbType.Decimal).Set(123456789)
                    .Insert("student_id", out var tpId);
            }
        }


        public void InsertWithManageConnectionId()
        {
            IDbConnection conn = default;
            new ManipulationDataSet(conn)
                .Table("public", "student")
                    .Column("last_name").Set("Иванов")
                    .Column("first_name").Set("Иван")
                    .Column("second_name").Set("Иванович")
                    .Column("studentId").Set("99999999999")
                    .Column("studentUid", DbType.Decimal).Set(123456789)
                .Insert("student_id", out var tpId);
        }
    }
}