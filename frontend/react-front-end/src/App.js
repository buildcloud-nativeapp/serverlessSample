import React, {Component} from 'react';
import WeekPlans from './components/weekplans';

class App extends React.Component {

  state = {
    weekPlans: []
  }

  componentDidMount() {
    fetch(process.env.REACT_APP_API_URL)
    .then(res => res.json())
    .then((data) => {
      this.setState({ weekPlans: data })
    })
    .catch(console.log);
  };

  render() {
    return (
      <WeekPlans weekPlans={this.state.weekPlans} />
    )
  }
}

export default App;

