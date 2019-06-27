import React from 'react';

export default class Index extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            thermostats: []
        };
    }

    async componentWillMount() {
        this.fetchThermostats();
    }

    render() {
        return (
            <div>
                <h1>Hello, Welcome to Paostat.</h1>

            </div>
            )
    }

    async fetchThermostats() {
        fetch('/api/thermostats')
            .then(resp => resp.json())
            .then(data => console.log(data));
    }
}