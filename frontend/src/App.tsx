import { useState, useEffect } from 'react';
import { fetchBookById } from './api/BooksApi';
import './App.css';
import BookInfo from './Components/BookItem/BookInfo';
import type { Book } from './api/ApiModels';

function App() {
    const [book, setBook] = useState<Book | null>(null);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        async function loadBook() {
            const result = await fetchBookById(222);
            setBook(result);
            setLoading(false);
        }
        loadBook();
    }, []);

    if (loading) {
        return <div>Loading...</div>;
    }

    return (
        <>
            {book && (
                <BookInfo
                    id={book.id}
                    title={book.title}
                    authors={book.authors.map(b => b.name)}
                    image={book.formats['image/jpeg'] || ""}
                    languages={book.languages}
                    subjects={book.subjects}
                    summaries={book.summaries}
                />
            )}
        </>
    );
}

export default App;