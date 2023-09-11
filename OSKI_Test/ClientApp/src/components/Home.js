import React, { Component } from 'react';

export class Home extends Component {
    static displayName = Home.name;

    render() {
        return (
            <div>
                <h1>OSKI Solutions</h1>
                <h1>Chabanenko Max</h1>
                <p>User testing application. User should be able to sign in into application (sign up isn't required). Users can only see and pass tests that have been assigned to them. Once user completed the test, his mark should be stored and user should see the test as completed without ability to retake it. Only user-side functional is required (viewing available and completed tests, passing the test).</p>
                <b>Application requirements:</b>
                <br />
                <i>1. Backend (Web API)</i>
                <ul>
                    <li>Adhere to OOP & SOLID principles</li>
                    <li>One of the popular architectures</li>
                    <li>Authorization</li>
                </ul>
                <b>optional, would be a plus:</b>
                <ul>
                    <li>Swagger documentation</li>
                    <li>Cover functionality with unit tests</li>
                    <li>Cover functionality with integration tests</li>
                    <li>Add ability to run application inside Docker container</li>
                </ul>
                <i>2. Frontend (optional, would be a plus)</i>
                <ul>
                    <li>SPA app using one of the popular frameworks (React / Vue / Angular)</li>
                </ul>
            </div>
        );
    }
}
