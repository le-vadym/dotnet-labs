import React, { useState, useEffect } from 'react'
import { Form } from 'react-bootstrap';
import { useLocation, useNavigate } from 'react-router-dom';
import useDataService from '../../hooks/useDataService'
import { Book } from '../../models';
import BookService from '../../services/BookService';

const CreateUpdateBook = () => {
    const { createQuery, updateQuery } = useDataService(BookService);
    const { state: retrievedBook } = useLocation();
    const [book, setBook] = useState(new Book({}));
    const navigate = useNavigate();
    useEffect(() => {
        if (retrievedBook) {
            setBook(new Book(retrievedBook));
        }
    }, [retrievedBook]);

    const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        const id = (retrievedBook as Book)?.id;
        if (id) {
            await updateQuery.mutateAsync({ id, model: book });
        } else {
            await createQuery.mutateAsync(book);
        }
        goBack();
    };

    const goBack = () => navigate('/books', { replace: true });

    return (
        <>
            <h3>Book</h3>
            <Form onSubmit={async (e) => await handleSubmit(e)}>
                <Form.Group className='mb-3'>
                    <Form.Control required placeholder='Name'
                        type='text'
                        name='name'
                        value={book.name}
                        onChange={(e) => setBook(new Book({ ...book, name: e.target.value }))} />
                </Form.Group>
                <Form.Group className='mb-3'>
                    <Form.Control required placeholder='Author'
                        type='text'
                        name='author'
                        value={book.author}
                        onChange={(e) => setBook(new Book({ ...book, author: e.target.value }))} />
                </Form.Group>
                <Form.Group className='mb-3'>
                    <Form.Control required placeholder='Price'
                        type='number'
                        name='price'
                        value={book.price}
                        onChange={(e) => setBook(new Book({ ...book, price: Number(e.target.value) }))} />
                </Form.Group>

                <button type='submit' className='btn btn-success m-1'>Update</button>
                <button className='btn btn-secondary m-1' onClick={goBack}>Go Back</button>
            </Form>
        </>
    );
};

export default CreateUpdateBook;