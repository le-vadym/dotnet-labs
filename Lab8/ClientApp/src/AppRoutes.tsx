import React from "react";
import Addresses from "./components/Address";
import CreateUpdateAddress from "./components/Address/CreateUpdateAddress";
import Books from "./components/Book";
import CreateUpdateBook from "./components/Book/CreateUpdateBook";
import BookBorrows from "./components/BookBorrow";
import CreateUpdateBookBorrow from "./components/BookBorrow/CreateUpdateBookBorrow";
import { Home } from "./components/Home";
import Readers from "./components/Reader";
import CreateUpdateReader from "./components/Reader/CreateUpdateReader";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/books',
    element: <Books />
  },
  {
    path: '/books/create',
    element: <CreateUpdateBook />
  },
  {
    path: '/books/update',
    element: <CreateUpdateBook />
  },
  {
    path: '/addresses',
    element: <Addresses />
  },
  {
    path: '/addresses/create',
    element: <CreateUpdateAddress />
  },
  {
    path: '/addresses/update',
    element: <CreateUpdateAddress />
  },
  {
    path: '/readers',
    element: <Readers />
  },
  {
    path: '/readers/create',
    element: <CreateUpdateReader />
  },
  {
    path: '/readers/update',
    element: <CreateUpdateReader />
  },
  {
    path: '/book-borrows',
    element: <BookBorrows />
  },
  {
    path: '/book-borrows/create',
    element: <CreateUpdateBookBorrow />
  },
  {
    path: '/book-borrows/update',
    element: <CreateUpdateBookBorrow />
  },

];

export default AppRoutes;
