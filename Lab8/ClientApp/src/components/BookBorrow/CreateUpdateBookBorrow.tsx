import React, { useState, useEffect } from 'react'
import { Form } from 'react-bootstrap';
import Select from 'react-select'
import { useLocation, useNavigate } from 'react-router-dom';
import useDataService from '../../hooks/useDataService'
import { BookBorrow } from '../../models';
import BookBorrowService from '../../services/BookBorrowService';
import ReaderService from '../../services/ReaderService';
import BookService from '../../services/BookService';

const CreateUpdateBookBorrow = () => {
    const { createQuery, updateQuery } = useDataService(BookBorrowService);
    const { queryAll: readersQuery } = useDataService(ReaderService);
    const { queryAll: booksQuery } = useDataService(BookService);

    const { state: retrievedBookBorrow } = useLocation();
    const [bookBorrow, setBookBorrow] = useState(new BookBorrow({}));
    const navigate = useNavigate();
    useEffect(() => {
        if (retrievedBookBorrow) {
            setBookBorrow(new BookBorrow(retrievedBookBorrow));
        }
    }, [retrievedBookBorrow]);

    const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        const id = (retrievedBookBorrow as BookBorrow)?.id;
        if (id) {
            await updateQuery.mutateAsync({ id, model: bookBorrow });
        } else {
            await createQuery.mutateAsync(bookBorrow);
        }
        goBack();
    };

    const goBack = () => navigate('/book_borrows', { replace: true });

    const getBookOptions = () => {
        if (!booksQuery.isSuccess) {
            return [] as Array<{value: string, label: string}>;
        }

        return booksQuery.data.map(book => ({ value: book.id, label: `${book.name}, ${book.author}` }));
    };

    const getReaderOptions = () => {
        if (!readersQuery.isSuccess) {
            return [] as Array<{value: string, label: string}>;
        }

        return readersQuery.data.map(reader => ({ value: reader.id, label: `${reader.firstName}, ${reader.lastName}` }));
    };

    const setBook = (bookId: string) => {
        const book = booksQuery.data?.filter(book => book.id === bookId)[0];
        if (book) {
            setBookBorrow({...bookBorrow, bookId: book.id, book});
        }
    };

    const setReader = (readerId: string) => {
        const reader = readersQuery.data?.filter(reader => reader.id === readerId)[0];
        if (reader) {
            setBookBorrow({...bookBorrow, readerId: reader.id, reader});
        }
    };

    return (
        <>
            <h3>Book Borrow</h3>
            <Form onSubmit={async (e) => await handleSubmit(e)}>
                <Form.Group className='mb-3'>
                    <Select required
                            options={getBookOptions()}
                            placeholder='Select Book'
                            onChange={(e) => setBook(e?.value || '')}
                            isSearchable />
                </Form.Group>
                <Form.Group className='mb-3'>
                    <Select required
                            options={getReaderOptions()}
                            placeholder='Select Reader'
                            onChange={(e) => setReader(e?.value || '')}
                            isSearchable />
                </Form.Group>

                <Form.Group className='mb-3'>
                    <Form.Control required placeholder='Borrow Date'
                        type='date'
                        name='borrowDate'
                        value={new Date(bookBorrow.borrowDate).toLocaleDateString('en-Ca')}
                        onChange={(e) => setBookBorrow(new BookBorrow({ ...bookBorrow, borrowDate: e.target.value }))} />
                </Form.Group>
                <Form.Group className='mb-3'>
                    <Form.Control required placeholder='Return Date'
                        type='date'
                        name='returnDate'
                        value={new Date(bookBorrow.returnDate).toLocaleDateString('en-Ca')}
                        onChange={(e) => setBookBorrow(new BookBorrow({ ...bookBorrow, returnDate: e.target.value }))} />
                </Form.Group>

                <button type='submit' className='btn btn-success m-1'>Update</button>
                <button className='btn btn-secondary m-1' onClick={goBack}>Go Back</button>
            </Form>
        </>
    )
}

export default CreateUpdateBookBorrow