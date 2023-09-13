import React, { useEffect, useState } from 'react'
import { createAPIEndpoint, ENDPOINTS } from '../api'


export default function Quiz() {

    const [quiz, setQuiz] = useState([])

    useEffect(() => {

        createAPIEndpoint(ENDPOINTS.getAll)
            .fetch()
            .then(res => {
                setQuiz(res.data)
                console.log(res.data)
            })
            .catch(err => { console.log(err); })

    }, [])
    return (
        <div>
            {quiz.map((quizlet, index) => {

                return (
                    <div key={index} style={{ textAlign: 'center' }}>
                        <h1>Quiz # {quizlet.id} - {quizlet.quizName}</h1>
                        {quizlet.questions.map((question, index) => {

                            return (
                                <div key={index} style={{ textAlign: 'left' }}>
                                    <h1>Question # {question.id} - {question.text}</h1>
                                    <i style={{ color: 'orangered' }}>(Selected Option Id = {question.selectedOptionId})</i>
                                    {question.options.map((option, index) => {
                                        return (
                                            <ul>
                                                <li><h2>Option: # {index + 1} <i style={{ color: 'orangered' }}>(DB id = {option.id})</i> - {option.text}</h2></li>
                                            </ul>
                                        );
                                    })}


                                </div>
                            );
                        })}

                        <hr />
                    </div>
                );
            })}
        </div>

    );

}
