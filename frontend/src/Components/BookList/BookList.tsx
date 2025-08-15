import React from 'react';
import type { Book } from '../../api/ApiModels';

interface BookListProps {
    books: Book[];
}

const BookList: React.FC<BookListProps> = ({ books }) => {
    return (
        <div className="max-w-6xl mx-auto px-4 py-8">
            <h1 className="text-3xl font-bold mb-6 text-gray-800">📚 Book List</h1>

            {books.length === 0 ? (<p className="text-gray-500">No books available.</p>) : (
                <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 gap-6">
                    {books.map((book) => (
                        <div key={book.id} className="bg-white shadow-md rounded-lg overflow-hidden hover:shadow-xl transition-shadow">
                            <img src={book.formats['image/jpeg'] || ""} alt={book.title} className="w-full h-56 object-cover"/>
                            <div className="p-4">
                                <h2 className="text-lg font-semibold text-gray-900 truncate">{book.title}</h2>
                                <p className="text-gray-600 text-sm">{book.authors.join(", ")}</p>
                            </div>
                        </div>
                    ))}
                </div>
            )}
        </div>
    );
};

export default BookList;