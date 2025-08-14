//import React from 'react'

interface Props {
    id: number,
    title: string,
    authors: string[],
    summaries: string[],
    subjects: string[],
    languages: string[],
    image: string
};

const BookInfo = ({id, title, authors, summaries, subjects, languages, image }: Props) => {
    return (
        <div>
            <img src={image} alt="Book Cover" />
            <h2 onClick={() => console.log(id)}>{title}</h2>
            <h3>Authors: {authors.join(', ')}</h3>
            <h4>Subjects: {subjects.join(', ')}</h4>
            <h4>Languages: {languages.join(', ')}</h4>
            <h5>Summaries:</h5>
            <div>
                {summaries.map((summary, index) => (<p key={index}>{summary}</p>))}
            </div>
        </div>
    )
}

export default BookInfo
