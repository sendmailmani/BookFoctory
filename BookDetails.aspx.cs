using BookFactorys.EntityClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookFactorys
{
    public partial class BookDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtSearch.Focus();

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            try
            {
                if (Request.QueryString["isAdmin"] != null)
                {
                    bool isAdmin = Convert.ToBoolean(Request.QueryString["isAdmin"]);
                    if (!isAdmin)
                        addView.Visible = false;
                    else
                        addView.Visible = true;

                    List<BookEntity> books = Search();

                    if (books != null && books.Count > 0)
                    {
                        grdBookDetails.DataSource = books;
                        grdBookDetails.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
            }

        }

        /// <summary>
        /// Thsi method is used to search book based on author,category and book name 
        /// </summary>
        /// <returns></returns>
        public List<BookEntity> Search()
        {
            try
            {
                BookEntity bookDetails = null;
                List<BookEntity> listBook = new List<BookEntity>();
                using (SqlConnection conn = new SqlConnection(WebConfigurationManager.AppSettings.Get("ConnectionString")))
                {
                    using (SqlCommand command = conn.CreateCommand())
                    {

                        conn.Open();
                        command.CommandType = CommandType.Text;
                        command.Connection = conn;
                        string strQuery = "select BookName,BookCategory,AuthorName,Edition,Price from BookDetails where BookName like '" + txtSearch.Text + "'  or AuthorName like ='" + txtSearch.Text + "'  or BookCategory like ='" + txtSearch.Text + "'";
                        command.CommandText = strQuery;
                        IDataReader reader = null;
                        reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            bookDetails = new BookEntity();
                            bookDetails.BookName = Convert.ToString(reader[0]);
                            bookDetails.BookCategory = Convert.ToString(reader[1]);
                            bookDetails.Author = Convert.ToString(reader[2]);
                            bookDetails.Edition = Convert.ToString(reader[3]);
                            bookDetails.Price = Convert.ToString(reader[4]);


                            listBook.Add(bookDetails);
                        }

                    }
                }
                return listBook;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// This method id used to adding new book
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string newId;
                AddingNewBook(out newId);

                if (!string.IsNullOrEmpty(newId))
                {
                    lblMsg.Text = "Book Added successfully !";

                    Clear();
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
            }
        }

        /// <summary>
        /// This method is adding new book to database.
        /// </summary>
        public void AddingNewBook(out string newID)
        {
            try
            {
                SqlConnection conn = new SqlConnection(WebConfigurationManager.AppSettings.Get("ConnectionString"));
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"    INSERT INTO BookDetails
										( BookName, BookCategory, AuthorName, Edition, Price )
									VALUES
										( @BookName, @BookCategory, @AuthorName, @Edition, @Price )
									SELECT SCOPE_IDENTITY()";
                cmd.Parameters.AddWithValue("@BookName", txtBookName.Text);
                cmd.Parameters.AddWithValue("@BookCategory", txtBookCategoty.Text);
                cmd.Parameters.AddWithValue("@AuthorName", txtAuthorName.Text);
                cmd.Parameters.AddWithValue("@Edition", txtEdition.Text);
                cmd.Parameters.AddWithValue("@Price", txtPrice.Text);

                newID = cmd.ExecuteScalar().ToString();
                conn.Close();

            }
            catch (Exception ex)
            {
                newID = null;
                throw ex;
            }
        }

        /// <summary>
        /// This method is used to clear the value in all textbox
        /// </summary>
        public void Clear()
        {
            txtAuthorName.Text = string.Empty;
            txtBookCategoty.Text = string.Empty;
            txtBookName.Text = string.Empty;
            txtEdition.Text = string.Empty;
            txtPrice.Text = string.Empty;
        }
    }
}