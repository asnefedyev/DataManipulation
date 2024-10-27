using ru.ex1.ex2.commonsolutions;
using System.Data;

namespace Examples
{
    public class Update
    {
        public void FlexibleUpdate(string studentId, string firstName, string lastName, string secondName)
        {
            using (IDbConnection conn = default)
            {
                var student =
                    new ManipulationDataSet(conn, true)
                    .Table("public", "student")
                        .WithKeys("studentId").Set(studentId);

                    if (!ReferenceEquals(lastName, null)) student.Column("last_name").Set(lastName);
                    if (!ReferenceEquals(firstName, null)) student.Column("first_name").Set(firstName);
                    if (!ReferenceEquals(secondName, null)) student.Column("second_name").Set(secondName);

                student.Update();
            }
        }

        public void JustUpdate()
        {
            IDbConnection conn = default;
            using (var student = new ManipulationDataSet(conn))
            {
                student.Table("public", "student")
                    .WithKeys("studentId").Set("123456789")
                    .Column("studentUid").Set(8888888888888)
                .Update();
            }
        }
    }
}