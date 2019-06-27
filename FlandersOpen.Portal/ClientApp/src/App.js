import React, { Component } from 'react';
import { Route } from 'react-router';
import { AppContext } from  "./components/common/AppContext";

import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';

import { TeamsPage } from "./components/Teams/TeamsPage";
import { CompetitionsPage } from "./components/Competitions/CompetitionsPage";

export default class App extends Component {
  constructor(props) {
    super(props);

    this.ajaxStarted = () => {
      this.setState(state => ({
        ajaxCounter: state.ajaxCounter + 1
      }));
    };

    this.ajaxEnded = () => {
      this.setState(state => ({
        ajaxCounter: state.ajaxCounter - 1
      }));
    };

    this.state = {
      ajaxCounter: 0,
      ajaxStarted: this.ajaxStarted,
      ajaxEnded: this.ajaxEnded,
      fullWidth: false  
    }
  }

  static displayName = App.name;

  render () {
    return (
      <AppContext.Provider value={this.state}>
        <Layout>
          <Route exact path='/' component={Home} />
          <Route path='/counter' component={Counter} />
          <Route path='/fetch-data' component={FetchData} />
          <Route path='/teams' component={TeamsPage} />
          <Route path='/competitions' component={CompetitionsPage} />
        </Layout>
      </AppContext.Provider>
    );
  }
}