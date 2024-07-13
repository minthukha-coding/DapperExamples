using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DapperExamples.Dtos;
using DapperExamples.Share;

namespace DapperExamples.DapperExamples;

public class DapperExample
{
    private readonly DapperService _service;

    public DapperExample(DapperService service)
    {
        _service = service;
    }

    #region Read

    public void Run()
    {
        //Read();
        //Delete(2);
        Create("23424324", "234234", "3242342");
    }

    #endregion

    #region Read

    private void Read()
    {
        using IDbConnection db = new SqlConnection(Connection.connectionString.ConnectionString);
        List<BlogDto> lst = db.Query<BlogDto>("select * from tbl_blog").ToList();
        foreach (BlogDto blog in lst)
        {
            Console.WriteLine(blog.BlogTitle);
            Console.WriteLine(blog.BlogAuthor);
            Console.WriteLine(blog.BlogContent);
            Console.WriteLine("_______________________");
        }
    }

    #endregion

    #region Edit

    private void Edit(int id)
    {
        using IDbConnection db = new SqlConnection(Connection.connectionString.ConnectionString);
        var item = db.Query<BlogDto>("select * from tbl_blog where blogid = @BlogId",
            new BlogDto { BlogId = id }).FirstOrDefault();
        if (item == null)
        {
            Console.WriteLine("item is null");
            return;
        }

        Console.WriteLine(item.BlogTitle);
        Console.WriteLine(item.BlogAuthor);
        Console.WriteLine(item.BlogContent);
    }

    #endregion

    #region Create

    private void Create(string title, string author, string content)
    {
        var item = new BlogDto
        {
            BlogTitle = title,
            BlogAuthor = author,
            BlogContent = content
        };
        string query = @"INSERT INTO [dbo].[Tbl_Blog]
                            ([BlogTitle],
                            [BlogAuthor],
                            [BlogContent])
                VALUES
                    (@BlogTitle,
                    @BlogAuthor,
                    @BlogContent)";
        //using IDbConnection db = new SqlConnection(Connection.connectionString.ConnectionString);
        //int result = db.Execute(query, item);
        //string message = result > 0 ? "Create Blog Success" : "Create blog fail";
        //Console.WriteLine(message);
        _service.ExecuteQuery(query, item, "Create Blog Success", "Create blog fail");
    }

    #endregion

    #region Update

    private void Update(int id,string title, string author, string content)
    {
        var item = new BlogDto
        {
            BlogTitle = title,
            BlogAuthor = author,
            BlogContent = content
        };

        string query = @"UPDATE [dbo].[Tbl_Blog]
                            SET [BlogTitle] = @BlogTitle
                            ,[BlogAuthor] = @BlogAuthor
                            ,[BlogContent] = @BlogContent
                            WHERE BlogId=@BlogId";

        //using IDbConnection db = new SqlConnection(Connection.connectionString.ConnectionString);
        //int result = db.Execute(query, item);
        //string message = result > 0 ? "Update Blog Success" : "Update blog fail";
        //Console.WriteLine(message);
        _service.ExecuteQuery(query, item, "Update Blog Success", "Update blog fail");
    }

    #endregion

    #region Delete

    private void Delete(int id)
    {
        var item = new BlogDto
        {
            BlogId = id
        };
        string query = @"DELETE FROM [dbo].[Tbl_Blog] WHERE BlogId=@BlogId";

        //using IDbConnection db = new SqlConnection(Connection.connectionString.ConnectionString);
        //int result = db.Execute(query, item);
        //string message = result > 0 ? "Delete Blog Success" : "Delete blog fail";
        //Console.WriteLine(message);
        _service.ExecuteQuery(query,item, "Delete Blog Success", "Delete blog fail");
    }
    
    #endregion

}