using Npgsql;
using ru.ex1.ex2.commonsolutions;
using ManipulationDataSetSolution.Examples.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Examples
{
    public class Select
    {
        public void JustSelect(int id)
        {
            using (IDbConnection conn = default)
            {
                var document = new ManipulationDataSet(conn, true)
                    .Table("doc", "document")
                        .Column("author_id").As("userId").Get()
                        .Column("def_doc").As("definition").Get()
                    .WithKeys("id", DbType.Int32).Set(id)
                    .Select();
                var documentResult = from u in document select new { u.UserId, u.definition };
                foreach (var item in documentResult)
                {
                    Console.WriteLine($"{item.UserId} {item.definition}");                    
                }
            }
        }

        public List<DocumentModel> JustSelectWithModel()
        {
            using (IDbConnection conn = default)
            {
                var document = new ManipulationDataSet(conn, true)
                    .Table("doc", "document")
                        .Column("author_id").As("userId").Get()
                        .Column("def_doc").As("definition").Get()
                    .Select();
                var documentResult = from u in document select new DocumentModel { ModelId = u.UserId, ModelName = u.definition };
                return documentResult.ToList();
            }
        }

        public List<DocumentModel> JustSelectWithModelAndSqlQuery()
        {
            var sql = @"select id, name 
                        from document_vw where doc_type in(1,2,3) and doc_date >= :doc_date_p";
            using (IDbConnection conn = default)
            {
                var document = new ManipulationDataSet(conn, true)
                    .Table("doc", "document")
                        .Column("author_id").As("userId").Get()
                        .Column("def_doc").As("definition").Get()
                    .Select(sql, new NpgsqlParameter[] {new NpgsqlParameter("doc_date_p", DateTime.Now.AddDays(-1)) });
                var documentResult = from u in document select new DocumentModel { ModelId = u.UserId, ModelName = u.definition };
                return documentResult.ToList();
            }
        }
    }
}