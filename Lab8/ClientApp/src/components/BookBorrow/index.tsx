import React from 'react'
import useDataService from '../../hooks/useDataService'
import { BookBorrow } from '../../models'
import BookBorrowService from '../../services/BookBorrowService'
import { useNavigate } from 'react-router-dom';
import { Link } from 'react-router-dom';


const BookBorrows = () => {
  const { queryAll, deleteQuery } = useDataService(BookBorrowService);
  const navigate = useNavigate();

  const deleteBookBorrow = async (id: string) => {
    await deleteQuery.mutateAsync(id);
  };

  const content = queryAll.isLoading
        ? <h2>Loading...</h2>
        : queryAll.isError
            ? <h2>Error</h2>
            : <table className='table table-striped'>
                <thead>
                    <tr>
                        <th>Book</th>
                        <th>Reader</th>
                        <th>Borrow Date</th>
                        <th>Return Date</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    {queryAll.data?.map((bookBorrow: BookBorrow) =>
                        <tr key={bookBorrow.id}>
                            <td>
                                {bookBorrow.book.name}, {bookBorrow.book.author}
                            </td>
                            <td>
                                {bookBorrow.reader.firstName}, {bookBorrow.reader.lastName}
                            </td>
                            <td>
                                {new Date(bookBorrow.borrowDate).toDateString()}
                            </td>
                            <td>
                              {new Date(bookBorrow.borrowDate) < new Date(bookBorrow.returnDate) ? new Date(bookBorrow.returnDate).toDateString() : ''}
                            </td>
                            <td>
                                <button className='btn btn-warning' onClick={() => navigate('update', { state: bookBorrow, replace: true })}>Edit</button>{" | "}
                                <button className='btn btn-danger' onClick={async () => await deleteBookBorrow(bookBorrow.id)}>Delete</button>
                            </td>
                        </tr>
                    )}
                </tbody>
            </table>

  return (
    <>
      <h1>Index</h1>
      <p>
        <Link to='create' className='btn btn-success'>Create New</Link>
      </p>
      {content}
    </>
  )
}

export default BookBorrows