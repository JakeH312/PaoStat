import React, { Component } from 'react';

export default class App extends Component {
    constructor(props) {
        super(props);
        this.state = {
            thermostats: []
        };
    }

    async componentWillMount() {
        this.fetchThermostats()
    }



    render() {
        return (
            <div>
                <h1>Hello, Welcome to Paostat.</h1>
                {this.state.thermostats.map(t => <ThermostatController thermostat={t} />)}
            </div>
            
        )
    }

    fetchThermostats() {
        fetch('/api/thermostats')
            .then(resp => resp.json())
            .then(data => this.setState({ thermostats: data }, () => { console.log(this.state)}));
    }
}

class ThermostatController extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
            Name: 'Seed',
            Code: 'AA:BB:CC:DD:EE:FF',
            Location: 'Home',
            TemperatureSetting: 68.0,
            HumidityReading: 51,
            TemperatureReading: 110.0
        };
    }

    componentWillMount() {
        var thermo = this.props.thermostat;
        this.setState({
            Name: thermo.name,
            Code: thermo.code,
            Location: thermo.location,
            TemperatureSetting: thermo.temperatureSetting,
            HumidityReading: thermo.humiditiyReading,
            TemperatureReading: thermo.temperatureReading,
        })
    }

    render() {
        return (
            <div className={'card'} style={{ width: 300 + 'px' }}>
                <div className={'card-header'}>
                    <p>{this.state.Code}</p>
                </div>
                <div className={'card-body'}>
                    <p>Temperature Set</p>
                    <h1>{this.state.TemperatureSetting}</h1>
                    <p> Current Temperature </p>
                    <h1>{this.state.TemperatureReading}</h1>
                    <button onClick={() => this.handleTemp('up')}>
                        Raise Temperature
                                </button>
                    <button onClick={() => this.handleTemp('down')}>
                        Lower Temperature
                                </button>
                </div>
            </div>
        )
    }

    handleTemp( direction) {
        if (direction === 'up') {
            var temp = this.state.TemperatureSetting + 1;
            fetch(`/api/Thermostats/${this.state.Code}/temperature/${temp}`).then(() => {
                this.setState({ TemperatureSetting: temp });
            });
        }
        else {

            var temp = this.state.TemperatureSetting - 1;
            fetch(`/api/Thermostats/${this.state.Code}/temperature/${temp}`).then(() => {
                this.setState({ TemperatureSetting: temp });
            });

        }
    }
}
