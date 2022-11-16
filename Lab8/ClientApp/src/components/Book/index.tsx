import React from 'react';
import useDataService from '../../hooks/useDataService';
import BookService from '../../services/BookService';
import { useNavigate } from 'react-router-dom';
import { Book } from '../../models';
import { Link } from 'react-router-dom';

const Books = () => {
    const { queryAll, deleteQuery } = useDataService(BookService);
    const navigate = useNavigate();

    const deleteBook = async (id: string) => {
        await deleteQuery.mutateAsync(id);
    };

    const content = queryAll.isLoading
        ? <h2>Loading...</h2>
        : queryAll.isError
            ? <h2>Error</h2>
            : <table className='table table-striped'>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Author</th>
                        <th>Price</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    {queryAll.data?.map((book: Book) =>
                        <tr key={book.id}>
                            <td>
                                {book.name}
                            </td>
                            <td>
                                {book.author}
                            </td>
                            <td>
                                {book.price}
                            </td>
                            <td>
                                <button className='btn btn-warning' onClick={() => navigate('update', { state: book, replace: true })}>Edit</button>{" | "}
                                <button className='btn btn-danger' onClick={async () => await deleteBook(book.id)}>Delete</button>
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
    );
};

export default Books;